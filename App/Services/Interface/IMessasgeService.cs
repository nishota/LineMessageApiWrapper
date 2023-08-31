using Aimnext.MessageApiWrapper.App.Models.Http;

namespace Aimnext.MessageApiWrapper.App.Services
{
    public interface IMessageService
    {
        Task<Response<EmptyContent>> BroadcastAsync(string message);
        Task<Response<EmptyContent>> PushAsyc(string userId, string message);
        Task<Response<EmptyContent>> ReplyAsyc(string replyToken, string message);
    }
}