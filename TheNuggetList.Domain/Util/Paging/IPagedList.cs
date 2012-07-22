namespace TheNuggetList.Domain.Util.Paging
{
    public interface IPagedList
    {
        int TotalCount { get; set; }

        int CurrentPage { get; set; }

        int ItemsPerPage { get; set; }

        int PageLinksToDisplay { get; set; }

        int OptimumStartPage { get; }

        int OptimumEndPage { get; }

        int PageCount { get; }

        bool IsPreviousPage { get; }

        bool IsNextPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }
    }
}