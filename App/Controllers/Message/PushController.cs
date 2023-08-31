using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.Message;

[ApiController]
[Route("linedemo/message/[controller]")]
public class PushController : ControllerBase
{
    private readonly ILogger<PushController> _logger;
    private readonly IMessageService _messageService;
    public PushController(
        ILogger<PushController> logger,
        IMessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost(Name = "PushMessage")]
    public async Task<Response<EmptyContent>> PostAsync(string userId, string message)
    {
        var result = await _messageService.PushAsyc(userId, message);
        _logger.LogDebug("StatusCode : {statusCode}", result.StatusCode);
        return result;
    }
}