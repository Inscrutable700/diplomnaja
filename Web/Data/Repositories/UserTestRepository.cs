using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserTestRepository : RepositoryBase, IRepository<UserTest>
    {
        public UserTestRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public UserTest Add(int userID, int testID, int groupToTestID)
        {
            UserTest userTest = this.DataContext.UserTests
                .SingleOrDefault(ut => ut.UserID == userID && ut.TestID == testID);
            if (userTest!= null)
            {
                return userTest;
            }

            userTest = new UserTest
            {
                UserID = userID,
                TestID = testID,
                GroupToTestID = groupToTestID,
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
            return this.DataContext.UserTests
                .Include(ut => ut.Test)
                .Include(ut => ut.GroupToTest)
                .Include(ut => ut.GroupToTest.Group)
                .Include(ut => ut.User)
                .SingleOrDefault(ut => ut.ID == id);
        }

        public UserTest[] List()
        {
            throw new NotImplementedException();
        }

        public UserTest[] ListByUser(int userID, bool onlyCompleted = false)
        {
            var userTests = this.DataContext.UserTests
                .Include(ut => ut.Test)
                .Include(ut => ut.GroupToTest)
                .Include(ut => ut.User)
                .Where(ut => ut.UserID == userID);

            if (onlyCompleted)
            {
                userTests = userTests.Where(ut => ut.IsCompleted);
            }

            return userTests.ToArray();
        }

        public void Update(UserTest entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }

        UserTest IRepository<UserTest>.Add(UserTest entity)
        {
            throw new NotImplementedException();
        }
    }
}
