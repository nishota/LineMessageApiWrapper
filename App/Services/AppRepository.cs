using Aimnext.MessageApiWrapper.App.Models.Database;

namespace Aimnext.MessageApiWrapper.App.Services;

public class AppRepository : IAppRepository
{
    private readonly AppDBContext _appDBContext;
    public AppRepository(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async Task<bool> SaveMessage(string id, string messageId, string message)
    {
        try
        {
            _appDBContext.m_userdata.Add(new m_userdata{
                Id = id,
                MessageId = messageId,
                Message = message
            });
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}