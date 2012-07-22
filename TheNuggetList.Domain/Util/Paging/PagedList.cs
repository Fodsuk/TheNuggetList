#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace TheNuggetList.Domain.Util.Paging
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IQueryable<T> queryable, int pageNumber, int itemsPerPage, int pageLinksToDisplay)
        {
            PageLinksToDisplay = pageLinksToDisplay;
            TotalCount = queryable.Count();
            ItemsPerPage = itemsPerPage;
            CurrentPage = CorrectedPageNumber(pageNumber);
            AddRange(queryable.Skip((CurrentPage - 1)*itemsPerPage).Take(itemsPerPage).ToList());
        }

        public PagedList(List<T> queryable, int pageNumber, int itemsPerPage, int pageLinksToDisplay)
        {
            PageLinksToDisplay = pageLinksToDisplay;
            TotalCount = queryable.Count();
            ItemsPerPage = itemsPerPage;
            CurrentPage = CorrectedPageNumber(pageNumber);
            AddRange(queryable.Skip((CurrentPage - 1)*itemsPerPage).Take(itemsPerPage).ToList());
        }

        #region IPagedList Members

        public int PageLinksToDisplay { get; set; }

        public int OptimumStartPage
        {
            get
            {
                var optimum = CurrentPage -
                              (Convert.ToInt32(Math.Floor(PageLinksToDisplay/2.0) + (PageLinksToDisplay%2) - 1));
                if (PageLinksToDisplay > PageCount || optimum < 1)
                {
                    return 1;
                }
                else if (optimum > PageCount)
                {
                    return PageCount + 1 - PageLinksToDisplay;
                }
                else if (PageCount >= PageLinksToDisplay && ((PageCount - CurrentPage) < PageLinksToDisplay/2.0))
                {
                    return (PageCount - PageLinksToDisplay) + 1;
                }
                else
                {
                    return optimum;
                }
            }
        }

        public int OptimumEndPage
        {
            get
            {
                var optimum = CurrentPage + (Convert.ToInt32(Math.Floor(PageLinksToDisplay/2.0)));
                if (PageLinksToDisplay > PageCount || optimum > PageCount)
                {
                    return PageCount;
                }
                else if (optimum < 1)
                {
                    return PageLinksToDisplay;
                }
                else if (PageCount >= PageLinksToDisplay && optimum < PageLinksToDisplay)
                {
                    return PageLinksToDisplay;
                }
                else
                {
                    return optimum;
                }
            }
        }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int PageCount
        {
            get { return Convert.ToInt32(Math.Ceiling((TotalCount/(double) ItemsPerPage))); }
        }

        public bool IsPreviousPage
        {
            get { return (CurrentPage > 1); }
        }

        public bool IsNextPage
        {
            get { return (CurrentPage < PageCount); }
        }

        public bool IsFirstPage
        {
            get { return (CurrentPage == 1); }
        }

        public bool IsLastPage
        {
            get { return (CurrentPage == PageCount); }
        }

        #endregion

        private int CorrectedPageNumber(int pagenumber)
        {
            if (pagenumber <= 0)
            {
                return 1;
            }

            if (pagenumber > PageCount)
            {
                return PageCount;
            }

            return pagenumber;
        }
    }
}