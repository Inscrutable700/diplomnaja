namespace Data.Repositories
{
    public abstract class RepositoryBase
    {
        private DataContext dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected DataContext DataContext
        {
            get
            {
                return this.dataContext;
            }
        }
    }
}
