using System.Collections.Generic;

namespace PathFinder.Core.Controls
{
    public interface IPagedList<T> : IPageInfo
    {
        List<T> Items { get; set; }
    }

    public interface IPageInfo
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; set; }

        int TotalPages { get; set; }

        List<int> PreviousPages { get; set; }

        List<int> NextPages { get; set; }
    }
}
