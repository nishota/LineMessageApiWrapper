using Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.ChannelAccessToken;

[ApiController]
[Route("linedemo/token/[controller]")]
public class VerifyController : ControllerBase
{
    private readonly ILogger<CreateController> _logger;
    private readonly IAccessTokenService _accessTokenService;

    public VerifyController(
        ILogger<CreateController> logger,
        IAccessTokenService accessTokenService)
    {
        _logger = logger;
        _accessTokenService = accessTokenService;
    }

    [HttpPost(Name = "Verify")]
    public async Task<Response<AccessTokenInformation>> PostAsync(string accessToken)
    {
        var result = await _accessTokenService.VerifyAsync(accessToken);
        _logger.LogDebug("StatusCode : {statusCode}", result.StatusCode);
        _logger.LogDebug("Content(KeyId)  : {content}", result.Content?.ClientId ?? "Failed to Create AccessToken.");
        return result; 
    }
}