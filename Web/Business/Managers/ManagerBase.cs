using Data;

namespace Business.Managers
{
    public abstract class ManagerBase
    {
        protected RepositoryContext repositoryContext;

        protected BusinessContext businessContext;

        public ManagerBase(RepositoryContext repositoryContext, BusinessContext businessContext)
        {
            this.repositoryContext = repositoryContext;
            this.businessContext = businessContext;
        }
    }
}
