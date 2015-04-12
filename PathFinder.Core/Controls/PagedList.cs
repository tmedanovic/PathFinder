using System.Collections.Generic;

namespace PathFinder.Core.Controls
{
    public class PagedList<T> : IPagedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<int> PreviousPages { get; set; }
        public List<int> NextPages { get; set; }
        public List<T> Items { get; set; }
    }
}
