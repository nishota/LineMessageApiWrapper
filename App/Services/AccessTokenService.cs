using System.Web;
using Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
using Aimnext.MessageApiWrapper.App.Models.Http;

namespace Aimnext.MessageApiWrapper.App.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IHttpClientFactory _httpClientFactory;
    public AccessTokenService(
        IJwtGenerator jwtGenerator,
        IHttpClientFactory httpClientFactory)
    {
        _jwtGenerator = jwtGenerator;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Response<AccessToken>> CreateAsync()
    {
        var url = "/oauth2/v2.1/token";
        var datas = new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"},
            {"client_assertion", $"{_jwtGenerator.Generate()}"}
        };
        var executor = new RequestExecutor<AccessToken>(_httpClientFactory);
        return await executor.PostAsync(LineHttpClientSettings.Token, url, new FormUrlEncodedContent(datas));
    }

    public async Task<Response<AccessTokenInformation>> VerifyAsync(string accessToken)
    {
        var url = "/oauth2/v2.1/verify";
        var datas = new Dictionary<string, string>
        {
            {"access_token", $"{accessToken}"}
        };
        var query = HttpUtility.ParseQueryString("");
        foreach (var (k, v) in datas)
        {
            query.Add(k, v);
        }
        var executor = new RequestExecutor<AccessTokenInformation>(_httpClientFactory);
        return await executor.GetAsync(LineHttpClientSettings.Token, url, query);
    }

    public async Task<Response<KeyIdList>> GetTokenKidAsync()
    {
        var url = "/oauth2/v2.1/tokens/kid";
        var datas = new Dictionary<string, string>
        {
            {"client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"},
            {"client_assertion", $"{_jwtGenerator.Generate()}"}
        };
        var query = HttpUtility.ParseQueryString("");
        foreach (var (k, v) in datas)
        {
            query.Add(k, v);
        }
        var executor = new RequestExecutor<KeyIdList>(_httpClientFactory);
        return await executor.GetAsync(LineHttpClientSettings.Token, url, query);
    }

    public async Task<Response<EmptyContent>> RevokeAsync(string clientId, string channelSecret, string accessToken)
    {
        var url = "/oauth2/v2.1/revoke";
        var datas = new Dictionary<string, string>
        {
            {"client_id", $"{clientId}"},
            {"client_secre", $"{channelSecret}"},
            {"access_token", $"{accessToken}"}
        };
        var executor = new RequestExecutor<EmptyContent>(_httpClientFactory);
        return await executor.PostAsync(LineHttpClientSettings.Token, url, new FormUrlEncodedContent(datas));
    }
}