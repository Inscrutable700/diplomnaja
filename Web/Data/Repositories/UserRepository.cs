using System;
using System.Data.Entity;
using System.Linq;
using Data.Models;

namespace Data.Repositories
{
    public class UserRepository : RepositoryBase, IRepository<User>
    {
        public UserRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public User Add(User entity)
        {
            User newUser = this.DataContext.Users.Add(entity);
            this.DataContext.SaveChanges();
            return newUser;
        }

        public User[] AddRange(User[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            this.DataContext.Users.Remove(entity);
            this.DataContext.SaveChanges();
        }

        public User Get(int id)
        {
            return this.DataContext.Users.SingleOrDefault(u => u.ID == id);
        }

        public User[] List()
        {
            return this.DataContext.Users.ToArray();
        }

        public User[] ListByGroup(int groupID)
        {
            return this.DataContext.Users
                .Where(u => u.GroupID == groupID)
                .ToArray();
        }

        public void Update(User entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
