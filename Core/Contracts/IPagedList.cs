using Core.Contracts;

namespace Core.Contracts {
    public interface IPagedList {
        public int PageCount { get; }

        public int TotalItemCount { get; }

        public int PageIndex { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }
    }
}

public interface IPagedList<out T> : IPagedList, IEnumerable<T> {
    T this[int index] { get; }

    int Count { get; }
}