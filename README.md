# PagedResults
A C# Generic Class to paginate an IQueryable.

## How To Use

### Get a PagedResult Object
```cs
return new PagedResults<ModelName>
            (_Context.DbSetName,
                pageNumber,
                resultsPerPage);
```

### Razorpages Partial
```html
<nav aria-label="Page navigation example">
    <ul class="pagination">
        @if (@Model.PagedResults.CurrentPage != 1) // Show a link to the first page as well as previous page as long as we are not on the first page.
        {
            <li class="page-item"><a href="./@Model.PagedResults.FirstPage" class="page-link">First</a></li>
            <li class="page-item">
                <a href="./@Model.PagedResults.PreviousPage" class="page-link">
                    <span aria-hidden="true">&laquo;</span>
                    <span class="sr-only">Previous</span>
                </a></li>
        }
        
        @{ var pageCount = @Model.PagedResults.PageCount; }
        
        @for (int i = 1; i <= pageCount + 1 && i < 10; i++)
        {
            var currentPage = @Model.PagedResults.CurrentPage;
            if (pageCount > 10)
            {
                var activePage = ((currentPage - 5) + i);
                var active = activePage == currentPage ? "active" : string.Empty;
                if (activePage <= (pageCount - 1) && (activePage > 0))
                {
                    <li class="page-item @active"><a href="./@activePage" class="page-link">@activePage</a></li>
                }
            }
            else
            {
                var active = i == currentPage ? "active" : string.Empty;
                <li class="page-item @active"><a href="./@i" class="page-link">@i</a></li>
            }
        }
        
        
        
        @if (@Model.PagedResults.CurrentPage != @Model.PagedResults.LastPage)
        {
            <li class="page-item"><a href="./@Model.PagedResults.NextPage" class="page-link">
                <span aria-hidden="true">&raquo;</span>
                <span class="sr-only">Next</span>
            </a></li>
            <li class="page-item"><a href="./@Model.PagedResults.LastPage" class="page-link">Last</a></li>
        }
    </ul>
</nav>
```

## Further Reading
For further reading and to understand how this works in detail read our developer's writeup on this class https://nsuchy.me/2020/04/08/easily-paginating-your-entityframework-core-queries-with-c-generics/
