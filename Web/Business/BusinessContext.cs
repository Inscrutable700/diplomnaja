using Business.Managers;
using Data;

namespace Business
{
    public class BusinessContext
    {
        private RepositoryContext repositoryContext;

        private UserManager userManager;

        public BusinessContext()
        {
            this.repositoryContext = new RepositoryContext();
        }

        public UserManager UserManager
        {
            get
            {
                if( this.userManager == null)
                {
                    this.userManager = new UserManager(this.repositoryContext);
                }

                return this.userManager;
            }
        }
    }
}
