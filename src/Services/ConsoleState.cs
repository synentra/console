namespace Console.Services;

public sealed class ConsoleState
{
    public string BaseUrl { get; set; } = "http://localhost:7080";
    public string AuthHeaderName { get; set; } = "Synentra-Authorization";
    public string AccessToken { get; set; } = string.Empty;

    public bool HasToken => !string.IsNullOrWhiteSpace(AccessToken);

    public Uri BuildEndpoint(string relativePath)
    {
        var normalizedBase = BaseUrl.Trim().TrimEnd('/');
        var normalizedPath = relativePath.TrimStart('/');
        return new Uri($"{normalizedBase}/{normalizedPath}");
    }

    public string GetAuthHeaderValue() => $"Bearer {AccessToken.Trim()}";
}
