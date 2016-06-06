using Data;
using Data.Models;

namespace Business.Managers
{
    public class UserManager : ManagerBase
    {
        public UserManager(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public User AddUser(User user)
        {
            return this.repositoryContext.UserRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            this.repositoryContext.UserRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            this.repositoryContext.UserRepository.Delete(user);
        }

        public User GetUser(int userID)
        {
            return this.repositoryContext.UserRepository.Get(userID);
        }

        public User[] GetUsers()
        {
            return this.repositoryContext.UserRepository.List();
        }
    }
}
