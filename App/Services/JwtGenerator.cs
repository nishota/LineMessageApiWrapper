using Jose;

namespace Aimnext.MessageApiWrapper.App.Services;

public class JwtGenerator : IJwtGenerator
{
    public string Generate()
    {
        var payload = Models.JwtSettings.PayLoad;
        var header = Models.JwtSettings.Header;
        var jwk = Jwk.FromDictionary(Models.JwtSettings.Jwk);
        return Jose.JWT.Encode(payload, jwk, JwsAlgorithm.RS256, header);
    }
}