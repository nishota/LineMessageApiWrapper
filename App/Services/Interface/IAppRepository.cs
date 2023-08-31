namespace Aimnext.MessageApiWrapper.App.Services;

public interface IAppRepository
{
    Task<bool> SaveMessage(string id, string messageId, string message);
}