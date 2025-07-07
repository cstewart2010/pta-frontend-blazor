using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PokemonTabletopAdventures.Web.Constants;
using System.Text.Json;

namespace PokemonTabletopAdventures.Web.Domain;

public class Response
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    public Response(HttpResponseMessage response, string content)
    {
        Content = content;
        IsSuccessful = response.IsSuccessStatusCode;
        if (!response.IsSuccessStatusCode)
        {
            ProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(content , Options);
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.AccessToken, out var tokens))
        {
            ActivityToken = tokens.FirstOrDefault();
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.SessionAuth, out var auths))
        {
            SessionAuth = auths.FirstOrDefault();
        }
    }

    public string? Content { get; }
    public string? ActivityToken { get; }
    public string? SessionAuth { get; }
    public bool IsSuccessful { get; }
    public ProblemDetails? ProblemDetails { get; }
}
public class Response<T>
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    public Response(HttpResponseMessage response, string content)
    {
        Content = content;
        IsSuccessful = response.IsSuccessStatusCode;
        if (response.IsSuccessStatusCode)
        {
            Data = JsonSerializer.Deserialize<T>(content, Options);
        }
        else
        {
            ProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(content);
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.AccessToken, out var tokens))
        {
            ActivityToken = tokens.FirstOrDefault();
        }
        if (response.Headers.TryGetValues(PtaHeaderNames.SessionAuth, out var auths))
        {
            SessionAuth = auths.FirstOrDefault();
        }
    }

    public string? Content { get; }
    public T? Data { get; }
    public string? ActivityToken { get; }
    public string? SessionAuth { get; }
    public bool IsSuccessful { get; }
    public ProblemDetails? ProblemDetails { get; set; }
}
