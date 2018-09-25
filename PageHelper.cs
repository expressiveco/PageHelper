   public class PageHelper
    {
        private readonly int _totalRecordCount;
        private readonly int _pageSize;
        public readonly int PageCount;
        private int _lastRecordOfPage;

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

        public int CurrentRecord { get; private set; }
        public int CurrentPage { get; private set; }

        public bool NextPage()
        {
            if (CurrentRecord >= _totalRecordCount)
                return false;

            CurrentPage++;
            _lastRecordOfPage = CurrentPage < PageCount ? _lastRecordOfPage + _pageSize : _totalRecordCount;
            return true;
        }
        public bool NextItem()
        {
            if (CurrentRecord >= _lastRecordOfPage)
                return false;

            CurrentRecord++;
            return true;
        }
    }
