using Aimnext.MessageApiWrapper.App.Models.ChannelAccessToken;
using Aimnext.MessageApiWrapper.App.Models.Http;

namespace Aimnext.MessageApiWrapper.App.Services
{
    public interface IAccessTokenService
    {
        Task<Response<AccessToken>> CreateAsync();
        Task<Response<AccessTokenInformation>> VerifyAsync(string accessToken);
        Task<Response<KeyIdList>> GetTokenKidAsync();
        Task<Response<EmptyContent>> RevokeAsync(string clientId, string channelSecret, string accessToken);
    }
}