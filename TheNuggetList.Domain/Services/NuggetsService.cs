#region

using System.Linq;
using TheNuggetList.Domain.Entities;
using TheNuggetList.Domain.Repositories;
using TheNuggetList.Domain.Util.Paging;

#endregion

namespace TheNuggetList.Domain.Services
{
    public class NuggetsService : INuggetsService
    {
        private readonly INuggetsRepository _repository;

        public NuggetsService(IServiceLocator serviceLocator)
        {
            _repository = serviceLocator.Get<INuggetsRepository>();
        }

        #region INuggetsService Members

        public PagedList<Nugget> GetPagedNuggets(int currentPage, int pageSize, int pageLinksToDisplay)
        {
            return _repository.Nuggets.OrderByDescending(x => x.Created).ToPagedList(currentPage, pageSize, pageLinksToDisplay);
        }

        public Nugget GetNuggetByID(long id)
        {
            return _repository.GetNuggetByID(id);
        }

        public void SaveNugget(Nugget nugget)
        {
            _repository.SaveNugget(nugget);
        }

        public Nugget SaveNugget(string nuggetTitle, string nuggetDescription, long memberID)
        {
            var newNugget = new Nugget
                                {
                                    Title = nuggetTitle,
                                    Description = nuggetDescription,
                                    MemberID = memberID
                                };

            _repository.SaveNugget(newNugget);

            return newNugget;
        }

        #endregion
    }
}