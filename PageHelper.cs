    public class PageHelper
    {
        private readonly int _totalRecordCount;
        private readonly int _pageSize;

        public readonly int PageCount;
        private int _currentPageRecordCount;

        public PageHelper(int recordCount, int pageSize)
        {
            if (recordCount == 0 || pageSize == 0)
                throw new Exception("Record count or page size must not be 0.");
            if (pageSize > recordCount)
                throw new Exception("Page size must not be greater than record count.");

            _totalRecordCount = recordCount;
            _pageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)recordCount / pageSize);
        }

        public int CurrentRecord => CurrentPage < PageCount ? (1 * CurrentPage) * _pageSize - _currentPageRecordCount : _totalRecordCount - _currentPageRecordCount;

        public int CurrentPage { get; private set; }

        public bool NextPage()
        {
            if (CurrentPage >= PageCount)
                return false;

            CurrentPage++;
            _currentPageRecordCount = CurrentPage < PageCount ? _pageSize : _totalRecordCount - (CurrentPage - 1) * _pageSize;
            return true;
        }
        public bool NextItem()
        {
            if (_currentPageRecordCount <= 0)
                return false;

            _currentPageRecordCount--;
            return true;
        }
    }
