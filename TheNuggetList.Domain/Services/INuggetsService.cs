#region

using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Util.Paging;

#endregion

namespace TheNuggetList.Domain.Services
{
    public interface INuggetsService
    {
        PagedList<Nugget> GetPagedNuggets(int currentPage, int pageSize, int pageLinksToDisplay);
        Nugget GetNuggetByID(long id);
        void SaveNugget(Nugget nugget);
        Nugget SaveNugget(string nuggetTitle, string nuggetDescription, long memberID);
    }
}