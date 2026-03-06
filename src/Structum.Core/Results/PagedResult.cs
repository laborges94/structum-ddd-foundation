namespace Structum.Core.Results;

public class PagedResult<T> : Result<IReadOnlyList<T>>
{
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }

    public int TotalPages =>
        (int)Math.Ceiling((double)TotalCount / PageSize);

    public bool HasNextPage => Page < TotalPages;

    public bool HasPreviousPage => Page > 1;

    private PagedResult(
        IReadOnlyList<T> items,
        int page,
        int pageSize,
        int totalCount)
        : base(items)
    {
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    private PagedResult(IEnumerable<Error> errors)
        : base(errors) { }

    public static PagedResult<T> Success(
        IReadOnlyList<T> items,
        int page,
        int pageSize,
        int totalCount) 
        => new(
            items, 
            page, 
            pageSize, 
            totalCount);

    public new static PagedResult<T> Failure(Error error)
        => new([error]);

    public new static PagedResult<T> Failure(IEnumerable<Error> errors)
        => new(errors);
}