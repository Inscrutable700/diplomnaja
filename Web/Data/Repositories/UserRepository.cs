using System.Data.Entity;
using System.Linq;
using Data.Models;

namespace Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public User Add(User entity)
        {
            User newUser = this.dataContext.Users.Add(entity);
            this.dataContext.SaveChanges();
            return newUser;
        }

        public void Delete(User entity)
        {
            this.dataContext.Users.Remove(entity);
            this.dataContext.SaveChanges();
        }

        public User Get(int id)
        {
            return this.dataContext.Users.SingleOrDefault(u => u.ID == id);
        }

        public User[] List()
        {
            return this.dataContext.Users.ToArray();
        }

        public void Update(User entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
            this.dataContext.SaveChanges();
        }
    }
}
