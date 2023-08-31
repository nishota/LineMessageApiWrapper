using System.Net;
using System.Text.Json;
using Aimnext.MessageApiWrapper.App.Models.Event;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Models.Message;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("linedemo/[controller]")]
public class WebHookController : ControllerBase
{
    private readonly ILogger<WebHookController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMessageService _messageService;
    private readonly IAppRepository _appRepository;

    public WebHookController(
        ILogger<WebHookController> logger,
        IHttpClientFactory httpClientFactory,
        IMessageService messageService,
        IAppRepository appRepository)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _messageService = messageService;
        _appRepository = appRepository;
    }

    [HttpPost(Name = "WebHook")]
    public async Task<Response<EmptyContent>> PostAsync(WebHookEvent webHookEvent)
    {
        // TODO: 本番用に実装する場合は、Lineからの署名を確認する必要がある
        // https://developers.line.biz/ja/reference/messaging-api/#request-headers
        // if(署名が誤りかどうか)
        // {
        //     return new Response<EmptyContent>(){ StatusCode = HttpStatusCode.BadRequest };
        // }
        _logger.LogInformation("WebHook is Working!!");
        _logger.LogInformation("Event :{data}", JsonSerializer.Serialize(webHookEvent));
        foreach (var e in webHookEvent.Events)
        {
            var type = e.Type;
            if (string.IsNullOrEmpty(type)) continue;
            switch (type)
            {
                // DBにユーザIDとメッセージ内容を保存する
                case EventType.MESSAGE:
                    
                    string messageId;
                    string message;
                    string id = e.Source.Type switch
                    {
                        SourceType.USER => e.Source.UserId,
                        SourceType.GROUP => e.Source.GroupId,
                        SourceType.ROOM => e.Source.RoomId,
                        _ => ""
                    };

                    messageId = e.Message.Id;
                    message = e.Message.Text;

                    var result = await _appRepository.SaveMessage(id, messageId, message)
                        ? "登録OK":"登録NG";

                    // 登録成否の応答メッセージを返す
                    await _messageService.ReplyAsyc(e.ReplyToken, result);
                    continue;
                // 他のイベントは実装しない
                default:
                    continue;
            }
        }
        return new Response<EmptyContent>() { StatusCode = HttpStatusCode.OK };
    }

    private StringContent CreateStringContent(string datas)
    {
        var content = new StringContent(datas);
        content.Headers.Remove("Content-Type");
        content.Headers.Add("Content-Type", "application/json");
        return content;
    }
}