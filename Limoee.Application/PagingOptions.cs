namespace Limoee.Application
{
    public class PagingOptions
    {
        protected PagingOptions()
        {
            PageSize = 30;
            PageIndex = 1;
        }
        public PagingOptions(int pageIndex, int pageSize) 
        {
            PageSize = (pageSize <= 100 ? pageSize : 100);
            PageIndex = pageIndex;
        }

        public int PageIndex { get; protected set; }

        public int PageSize { get; protected set; }

    }
}