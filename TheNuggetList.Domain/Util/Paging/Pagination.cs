#region

using System.Linq;

#endregion

namespace TheNuggetList.Domain.Util.Paging
{
    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> queryable, int currentPage, int pageSize,
                                                  int pageLinksToDisplay)
        {
            return new PagedList<T>(queryable, currentPage, pageSize, pageLinksToDisplay);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> queryable, int currentPage, int pageLinksToDisplay)
        {
            return new PagedList<T>(queryable, currentPage, 4, pageLinksToDisplay);
        }
    }
}