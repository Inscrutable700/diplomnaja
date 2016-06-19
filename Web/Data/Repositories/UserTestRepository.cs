using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserTestRepository : RepositoryBase, IRepository<UserTest>
    {
        public UserTestRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public UserTest Add(int userID, int testID)
        {
            UserTest userTest = this.DataContext.UserTests
                .SingleOrDefault(ut => ut.UserID == userID && testID == testID);
            if (userTest!= null)
            {
                return userTest;
            }

            userTest = new UserTest
            {
                UserID = userID,
                TestID = testID,
                DateAssigned = DateTime.UtcNow,
            };

            userTest = this.DataContext.UserTests.Add(userTest);
            this.DataContext.SaveChanges();
            return userTest;
        }

        public UserTest Add(UserTest entity)
        {
            entity = this.DataContext.UserTests.Add(entity);
            this.DataContext.SaveChanges();
            return entity;
        }

        public UserTest[] AddRange(UserTest[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserTest entity)
        {
            throw new NotImplementedException();
        }

        public UserTest Get(int id)
        {
            throw new NotImplementedException();
        }

        public UserTest[] List()
        {
            throw new NotImplementedException();
        }

        public void Update(UserTest entity)
        {
            throw new NotImplementedException();
        }

        UserTest IRepository<UserTest>.Add(UserTest entity)
        {
            throw new NotImplementedException();
        }
    }
}
