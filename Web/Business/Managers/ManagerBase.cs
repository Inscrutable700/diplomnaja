using Data;

namespace Business.Managers
{
    public abstract class ManagerBase
    {
        protected RepositoryContext repositoryContext;

        public ManagerBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
    }
}
