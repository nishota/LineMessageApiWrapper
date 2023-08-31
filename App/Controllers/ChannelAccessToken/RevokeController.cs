using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.ChannelAccessToken;
[ApiController]
[Route("linedemo/token/[controller]")]
public class RevokeController : ControllerBase
{
    private readonly ILogger<RevokeController> _logger;
    private readonly IAccessTokenService _accessTokenService;

    public RevokeController(
        ILogger<RevokeController> logger,
        IAccessTokenService accessTokenService)
    {
        _logger = logger;
        _accessTokenService = accessTokenService;
    }
    [HttpPost(Name = "Revoke")]
    public async Task<Response<EmptyContent>> PostAsync(string clientId, string channelSecret, string accessToken)
    {
        var result = await _accessTokenService.RevokeAsync(clientId, channelSecret, accessToken);
        _logger.LogDebug("StatusCode : {statusCode}", result.StatusCode);
        return result; 
    }
}