using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Your.Application.Models
{
    public class PagedResults<T>
    {
        public int PageCount { get; }
        public int ItemCount { get; }
        public int Skip { get; }
        public int Take { get; }
        public int FirstPage { get; }
        public int LastPage { get; }
        public int NextPage { get; }
        public int PreviousPage { get; }
        public IEnumerable<T> PageOfResults { get; }

        public PagedResults(IQueryable<T> results, int pageNumber, int resultsPerPage)
        {
            PageCount = (int) Math.Ceiling((double) ItemCount / resultsPerPage);
            ItemCount = results.Count();
            
            Skip = (pageNumber - 1) * resultsPerPage;
            Take = resultsPerPage;
            
            PageOfResults = results.Skip(Skip).Take(Take).ToList();
            
            FirstPage = 1;
            LastPage = PageCount;
            
            NextPage = Math.Min(pageNumber + 1, LastPage);
            PreviousPage = Math.Max(pageNumber - 1, FirstPage);
            
        }
    }
}
