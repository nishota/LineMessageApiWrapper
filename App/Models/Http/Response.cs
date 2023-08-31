using System.Net;

namespace Aimnext.MessageApiWrapper.App.Models.Http;

public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Content { get; set; }
    public string? Message { get; set; } 
}