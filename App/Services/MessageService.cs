using System.Text.Json;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Models.Message;

namespace Aimnext.MessageApiWrapper.App.Services;

public class MessageService : IMessageService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MessageService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Response<EmptyContent>> BroadcastAsync(string message)
    {
        var url = "/v2/bot/message/broadcast";
        // NOTE: テキストメッセージを送る想定。画像などは別途実装が必要。
        // TODO: 単一メッセージを送る実装
        var datas = new Messages
        {
            Texts = new()
        };
        datas.Add(new() { Text = message });

        var json = JsonSerializer.Serialize(datas);
        var content = CreateStringContent(json);
        var executor = new RequestExecutor<EmptyContent>(_httpClientFactory);
        return await executor.PostAsync(LineHttpClientSettings.Message, url, content);
    }

    // NOTE: 対ユーザへメッセージを送ることしか想定していない。
    // NOTE: 対グループの実装は、別途必要。
    public async Task<Response<EmptyContent>> PushAsyc(string userId, string message)
    {
        var url = "/v2/bot/message/push";
        // NOTE: テキストメッセージを送る想定。画像などは別途実装が必要。
        // TODO: 単一メッセージを送る実装
        var datas = new MessagesTo
        {
            To = userId,
            Texts = new()
        };
        datas.Add(new() { Text = message });

        var content = CreateStringContent(JsonSerializer.Serialize(datas));
        var executor = new RequestExecutor<EmptyContent>(_httpClientFactory);
        return await executor.PostAsync(LineHttpClientSettings.Message, url, content);
    }

    public async Task<Response<EmptyContent>> ReplyAsyc(string replyToken, string message)
    {
        var url = "/v2/bot/message/reply";
        var datas = new MessagesReply
        {
            ReplyToken = replyToken,
            Texts = new()
        };
        datas.Add(new() { Text = message });
        var content = CreateStringContent(JsonSerializer.Serialize(datas));
        var executor = new RequestExecutor<EmptyContent>(_httpClientFactory);
        return await executor.PostAsync(LineHttpClientSettings.Message, url, content);
    }

    private StringContent CreateStringContent(string datas)
    {
        var content = new StringContent(datas);
        content.Headers.Remove("Content-Type");
        content.Headers.Add("Content-Type", "application/json");
        return content;
    }
}