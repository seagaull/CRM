using System;

namespace Overtime.Infrastructure
{
    public class Paggination
    {
        public Paggination()
        {
        }

        public Paggination(int totalCount, int page, int perPage)
        {
            TotalCount = totalCount;
            Page = page;
            PerPage = perPage;
            TotalPages = (int) Math.Ceiling((float) TotalCount/perPage);
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
                return Page + 1;
            }
        }

        public int PreviousPage
        {
            get
            {
                if (!HasPrevious)
                    throw new InvalidOperationException();
                return Page - 1;
            }
        }
    }
}