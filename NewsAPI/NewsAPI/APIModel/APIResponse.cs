using System.Net;

namespace NewsAPI.APIModel;

public class APIResponse
{
    public APIResponse()
    {
        ErrorMessage = new List<string>();
    }

    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public List<string> ErrorMessage { get; set; }
}