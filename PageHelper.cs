public class PageHelper
{
  private readonly int _totalItemCount;
  private readonly int _pageSize;
  public readonly int PageCount;
  private int _lastItemOfPage;

  /// <param name="itemCount">Total number of items</param>
  /// <param name="pageSize">Number of items in a page</param>
  public PageHelper(int itemCount, int pageSize)
  {
      if (itemCount == 0 || pageSize == 0)
          throw new Exception("Item count or page size must not be 0.");
      if (pageSize > itemCount)
          throw new Exception("Page size must not be greater than item count.");

      _totalItemCount = itemCount;
      _pageSize = pageSize;
      PageCount = (int)Math.Ceiling((double)itemCount / pageSize);
  }

  public int CurrentItem { get; private set; }
  public int CurrentPage { get; private set; }

  public bool NextPage()
  {
      if (CurrentItem >= _totalItemCount)
          return false;

      CurrentPage++;
      _lastItemOfPage = CurrentPage < PageCount ? _lastItemOfPage + _pageSize : _totalItemCount;
      return true;
  }
  public bool NextItem()
  {
      if (CurrentItem >= _lastItemOfPage)
          return false;

      CurrentItem++;
      return true;
  }
}
