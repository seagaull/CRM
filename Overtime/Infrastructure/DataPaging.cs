using System;
using System.Collections;
using System.Collections.Generic;

namespace Overtime.Infrastructure
{
    public class DataPaging<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _currentItem;

        public DataPaging(IEnumerable<T> currentItem, int totalCount, int page, int perPage)
        {
            _currentItem = currentItem;
            TotalCount = totalCount;
            Page = page;
            PerPage = perPage;
            TotalPages = totalCount/perPage;
            HasNext = page < TotalPages;
            HasPrevious = page > 1;
        }

        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

        public int NextPage
        {
            get
            {
                if (!HasNext)
                    throw new InvalidOperationException();
                return ++Page;
            }
        }

        public int PreviousPage
        {
            get
            {
                if (!HasPrevious)
                    throw new InvalidOperationException();
                return --Page;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _currentItem.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}