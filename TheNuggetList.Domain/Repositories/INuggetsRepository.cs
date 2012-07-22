#region

using System.Linq;
using TheNuggetList.Domain.Entities;

#endregion

namespace TheNuggetList.Domain.Repositories
{
    public interface INuggetsRepository
    {
        IQueryable<Nugget> Nuggets { get; }
        void SaveNugget(Nugget nugget);
        void DeleteNugget(Nugget nugget);
        Nugget GetNuggetByID(long nuggetID);
    }
}