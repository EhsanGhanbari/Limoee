namespace Limoee.Repository.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private LimoeeDataContext _dataContext;
        public LimoeeDataContext Get()
        {
            return _dataContext ?? (_dataContext = new LimoeeDataContext());
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}