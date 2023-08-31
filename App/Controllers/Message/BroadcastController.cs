using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.Message;

[ApiController]
[Route("linedemo/message/[controller]")]
public class BroadcastController : ControllerBase
{
    private readonly ILogger<BroadcastController> _logger;
    private readonly IMessageService _messageService;
    public BroadcastController(
        ILogger<BroadcastController> logger,
        IMessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost(Name = "BroadcastMessage")]
    public async Task<Response<EmptyContent>> PostAsync(string message)
    {
        var result = await _messageService.BroadcastAsync(message);
        _logger.LogDebug("StatusCode : {statusCode}", result.StatusCode);
        return result;
    }
}