using Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aimnext.MessageApiWrapper.App.Controllers.ChannelAccessToken;

[ApiController]
[Route("linedemo/token/[controller]")]
public class GetTokenKidController : ControllerBase
{
    private readonly ILogger<GetTokenKidController> _logger;
    private readonly IAccessTokenService _accessTokenService;

    public GetTokenKidController(
        ILogger<GetTokenKidController> logger,
        IAccessTokenService accessTokenService)
    {
        _logger = logger;
        _accessTokenService = accessTokenService;
    }
    [HttpGet(Name = "GetTokenKid")]
    public async Task<Response<KeyIdList>> Get()
    {
        var result = await _accessTokenService.GetTokenKidAsync();
        _logger.LogInformation("StatusCode : {statusCode}", result.StatusCode);
        _logger.LogInformation("Content(KeyId)  : {content}", result.Content?.Kids[0] ?? "Failed to get Key id.");
        return result; 
    }
}