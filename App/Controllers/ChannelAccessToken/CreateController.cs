using Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.ChannelAccessToken;

[ApiController]
[Route("linedemo/token/[controller]")]
public class CreateController : ControllerBase
{
    private readonly ILogger<CreateController> _logger;
    private readonly IAccessTokenService _accessTokenService;

    public CreateController(
        ILogger<CreateController> logger,
        IAccessTokenService accessTokenService)
    {
        _logger = logger;
        _accessTokenService = accessTokenService;
    }

    [HttpPost(Name = "Create")]
    public async Task<Response<AccessToken>> PostAsync()
    {
        var result = await _accessTokenService.CreateAsync();
        _logger.LogDebug("StatusCode : {statusCode}", result.StatusCode);
        _logger.LogDebug("Content(KeyId)  : {content}", result.Content?.KeyId ?? "Failed to Create AccessToken.");
        return result;
    }
}