using Aimnext.MessageApiWrapper.App.Models.Database;
using Aimnext.MessageApiWrapper.App.Models.Http;
using Aimnext.MessageApiWrapper.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// TODO: あとでappsetting.jsonに移動
// NOTE: Factoryにする意味ない？
builder.Services.AddHttpClient(LineHttpClientSettings.Token, httpClient =>
{
    httpClient.BaseAddress = LineHttpClientSettings.Url;
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
});

builder.Services.AddHttpClient(LineHttpClientSettings.Message, httpClient =>
{
    httpClient.BaseAddress = LineHttpClientSettings.Url;
    var accessToken = LineHttpClientSettings.AccessToken;
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Authorization, $"Bearer {accessToken}"
    );
    httpClient.DefaultRequestHeaders.Add(
        "X-Line-Retry-Key", $"{Guid.NewGuid().ToString()}"
    );
});

var section = builder.Configuration.GetSection("AppDBContext");
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySQL(section.Get<string>()));

builder.Services.AddTransient<IAccessTokenService, AccessTokenService>();
builder.Services.AddTransient<IJwtGenerator, JwtGenerator>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IAppRepository, AppRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "v1", Version = "v1" });
});
builder.Host.UseNLog();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger(c =>
{
    c.RouteTemplate = "linedemo/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/linedemo/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "linedemo";
});

app.UseAuthorization();

app.MapControllers();

app.Run();
