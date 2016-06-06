using Data.Repositories;

namespace Data
{
    public class RepositoryContext
    {
        private DataContext dataContext;

        private UserRepository userRepository;

        public RepositoryContext()
        {
            this.dataContext = new DataContext();
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.dataContext);
                }

                return this.userRepository;
            }
        }
    }
}
