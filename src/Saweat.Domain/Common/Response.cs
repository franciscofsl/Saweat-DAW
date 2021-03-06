namespace Saweat.Domain.Common;

public class Response<T>
{
    private Response()
    {
    }

    public bool Success { get; set; }

    public string[] ValidationErrors { get; set; } = Array.Empty<string>();

    public T? Data { get; set; }

    public static Response<T> CreateResponse(T? data, bool success = true, IEnumerable<string>? errors = null)
    {
        return new Response<T>
        {
            Data = data,
            Success = success,
            ValidationErrors = errors?.ToArray() ?? Array.Empty<string>()
        };
    }
}
