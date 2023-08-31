namespace Aimnext.MessageApiWrapper.App.Models.Http;

public static class LineHttpClientSettings
{
    public static string Token => "LineMessageApiToken";
    public static string Message => "LineMessageApiMessage";
    public static Uri Url => new Uri("https://api.line.me");
    // TODO: アクセストークンが変わったときの対応が出来ていない。
    public static string AccessToken => "eyJhbGciOiJIUzI1NiJ9.LdFKF0mQkZgjMfeWW_MKbz51Nv6CbKHeAY4RLPnxPFnP0MsDHL3cOE3PZIBi2RGfh47ltqckuoYxg6Os1H2qgVwes2jMVIaWIu7ExQtMLMQLGY9GMzQoiydK7ZpkvyTZ.GVEDNvDUYZSYFS713Fro4sg4HfDoN8GbywzGiHwyfaY";
}