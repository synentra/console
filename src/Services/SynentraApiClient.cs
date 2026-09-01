using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Console.Models;

namespace Console.Services;

public sealed class SynentraApiClient(HttpClient httpClient, ConsoleState state)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public Task<PagedResult<AgentSummary>?> GetAgentsAsync(int page, int pageSize) =>
        GetFromJsonAsync<PagedResult<AgentSummary>>($"agents?page={page}&pageSize={pageSize}");

    public Task<PagedResult<PolicySummary>?> GetPoliciesAsync(int page, int pageSize) =>
        GetFromJsonAsync<PagedResult<PolicySummary>>($"policies?page={page}&pageSize={pageSize}");

    public Task<PagedResult<AuditEntry>?> GetAuditAsync(int page, int pageSize) =>
        GetFromJsonAsync<PagedResult<AuditEntry>>($"Audit?page={page}&pageSize={pageSize}");

    public Task<PolicyDetails?> GetPolicyAsync(string name) =>
        GetFromJsonAsync<PolicyDetails>($"policies/{Uri.EscapeDataString(name)}");

    public Task<List<HitlPendingItem>?> GetPendingHitlAsync() =>
        GetFromJsonAsync<List<HitlPendingItem>>("hitl");

    public Task<HitlStatusResponse?> GetHitlStatusAsync(string id) =>
        GetFromJsonAsync<HitlStatusResponse>($"hitl/status/{Uri.EscapeDataString(id)}");

    public Task<ApiCallResult> RegisterAgentAsync(RegisterAgentRequest request) =>
        SendJsonAsync(HttpMethod.Post, "agents", request, false);

    public Task<ApiCallResult> AssignPolicyAsync(AssignPolicyRequest request) =>
        SendJsonAsync(HttpMethod.Put, $"agents/{request.AgentId}/policy", request, false);

    public Task<ApiCallResult> DeleteAgentAsync(Guid agentId) =>
        SendJsonAsync(HttpMethod.Delete, $"agents/{agentId}", null, false);

    public Task<ApiCallResult> LiftQuarantineAsync(Guid agentId) =>
        SendJsonAsync(HttpMethod.Post, $"agents/{agentId}/lift-quarantine", null, false);

    public async Task<TokenResponse?> ExchangeTokenAsync(TokenRequest request)
    {
        var result = await SendJsonAsync(HttpMethod.Post, "tokens", request, false);
        if (!result.IsSuccessStatusCode)
        {
            return null;
        }

        return JsonSerializer.Deserialize<TokenResponse>(result.Body, JsonOptions);
    }

    public async Task<HealthResponse?> GetHealthAsync()
    {
        using var request = BuildRequest(HttpMethod.Get, "health", includeAuth: false);
        using var response = await httpClient.SendAsync(request);

        if (response.Content is null)
        {
            return null;
        }

        await using var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<HealthResponse>(stream, JsonOptions);
    }

    public Task<ApiCallResult> ApproveHitlAsync(string id, HitlDecisionRequest request) =>
        SendJsonAsync(HttpMethod.Post, $"hitl/{Uri.EscapeDataString(id)}/approve", request, false);

    public Task<ApiCallResult> DenyHitlAsync(string id, HitlDecisionRequest request) =>
        SendJsonAsync(HttpMethod.Post, $"hitl/{Uri.EscapeDataString(id)}/deny", request, false);

    public Task<ApiCallResult> GetAuditByIdAsync(string id) =>
        SendJsonAsync(HttpMethod.Get, $"Audit/{Uri.EscapeDataString(id)}", null, false);

    public async Task<ApiCallResult> SendProxyRequestAsync(ProxyCallRequest proxyRequest)
    {
        var method = new HttpMethod(proxyRequest.Method.ToUpperInvariant());
        var target = proxyRequest.TargetUrl.Trim();
        var path = $"proxy/{target}";

        using var request = BuildRequest(method, path, includeAuth: true);

        foreach (var header in proxyRequest.Headers)
        {
            if (!string.IsNullOrWhiteSpace(header.Key) && !string.IsNullOrWhiteSpace(header.Value))
            {
                request.Headers.TryAddWithoutValidation(header.Key.Trim(), header.Value.Trim());
            }
        }

        if (!string.IsNullOrWhiteSpace(proxyRequest.JsonBody))
        {
            var contentType = string.IsNullOrWhiteSpace(proxyRequest.ContentType)
                ? "application/json"
                : proxyRequest.ContentType;

            request.Content = new StringContent(proxyRequest.JsonBody, Encoding.UTF8, contentType);
        }

        using var response = await httpClient.SendAsync(request);
        return await BuildResultAsync(response);
    }

    private async Task<T?> GetFromJsonAsync<T>(string path)
    {
        using var request = BuildRequest(HttpMethod.Get, path, includeAuth: false);
        using var response = await httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode || response.Content is null)
        {
            return default;
        }

        await using var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<T>(stream, JsonOptions);
    }

    private async Task<ApiCallResult> SendJsonAsync(HttpMethod method, string path, object? payload, bool includeAuth)
    {
        using var request = BuildRequest(method, path, includeAuth);

        if (payload is not null)
        {
            var json = JsonSerializer.Serialize(payload);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        using var response = await httpClient.SendAsync(request);
        return await BuildResultAsync(response);
    }

    private HttpRequestMessage BuildRequest(HttpMethod method, string path, bool includeAuth)
    {
        var request = new HttpRequestMessage(method, state.BuildEndpoint(path));

        if (includeAuth && state.HasToken)
        {
            request.Headers.TryAddWithoutValidation(state.AuthHeaderName, state.GetAuthHeaderValue());
        }

        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return request;
    }

    private static async Task<ApiCallResult> BuildResultAsync(HttpResponseMessage response)
    {
        var result = new ApiCallResult
        {
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            StatusCode = (int)response.StatusCode,
            ReasonPhrase = response.ReasonPhrase ?? string.Empty
        };

        foreach (var header in response.Headers)
        {
            result.Headers[header.Key] = string.Join(", ", header.Value);
        }

        if (response.Content is not null)
        {
            foreach (var header in response.Content.Headers)
            {
                result.Headers[header.Key] = string.Join(", ", header.Value);
            }

            result.Body = await response.Content.ReadAsStringAsync();
        }

        if (!result.IsSuccessStatusCode)
        {
            result.ErrorMessage = $"Request failed with status {result.StatusCode} ({result.ReasonPhrase}).";
        }

        return result;
    }
}
