namespace Console.Models;

public sealed class PagedResult<T>
{
    public List<T> Items { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}

public sealed class AgentSummary
{
    public Guid AgentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string PolicyName { get; set; } = string.Empty;
    public decimal TrustScore { get; set; }
}

public sealed class RegisterAgentRequest
{
    public string Name { get; set; } = string.Empty;
    public string OwnerId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
}

public sealed class AssignPolicyRequest
{
    public Guid AgentId { get; set; }
    public string PolicyName { get; set; } = string.Empty;
}

public sealed class PolicySummary
{
    public string PolicyName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
}

public sealed class PolicyDetails
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public DateTimeOffset? CreatedOn { get; set; }
    public string? Default { get; set; }
    public List<PolicyRule> Rules { get; set; } = [];
}

public sealed class PolicyRule
{
    public string Name { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
    public int Priority { get; set; }
}

public sealed class TokenRequest
{
    public Guid AgentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ExternalToken { get; set; }
}

public sealed class TokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
}

public sealed class HealthResponse
{
    public string Status { get; set; } = string.Empty;
    public string HealthCheckDuration { get; set; } = string.Empty;
}

public sealed class HitlPendingItem
{
    public string Id { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public Guid AgentId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}

public sealed class HitlStatusResponse
{
    public string Id { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public HitlRequestDetails? Request { get; set; }
}

public sealed class HitlRequestDetails
{
    public string Id { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public Dictionary<string, string> Headers { get; set; } = [];
    public string? Body { get; set; }
    public string Reason { get; set; } = string.Empty;
    public Guid AgentId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}

public sealed class HitlDecisionRequest
{
    public string? Comment { get; set; }
}

public sealed class ProxyCallRequest
{
    public string Method { get; set; } = "GET";
    public string TargetUrl { get; set; } = string.Empty;
    public string? JsonBody { get; set; }
    public string? ContentType { get; set; } = "application/json";
    public Dictionary<string, string> Headers { get; set; } = [];
}

public sealed class ApiCallResult
{
    public int StatusCode { get; set; }
    public bool IsSuccessStatusCode { get; set; }
    public string ReasonPhrase { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public Dictionary<string, string> Headers { get; set; } = [];
    public string? ErrorMessage { get; set; }
}

public sealed class AuditEntry
{
    public string Id { get; set; } = string.Empty;
    public string AgentId { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Decision { get; set; } = string.Empty;
    public DateTimeOffset? Timestamp { get; set; }
}
