using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GroupToTestRepository : RepositoryBase, IRepository<GroupToTest>
    {
        public GroupToTestRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public GroupToTest Add(int groupID, int testID, int questionsPerUser, DateTime? dateStart, DateTime? dateEnd)
        {
            GroupToTest entity = this.DataContext.GroupToTests
                .FirstOrDefault(gt => gt.GroupID == groupID && gt.TestID == testID);

            if (entity != null)
            {
                return entity;
            }

            entity = new GroupToTest
            {
                GroupID = groupID,
                TestID = testID,
                QuestionCount = questionsPerUser,
                DateStart = dateStart,
                DateEnd = dateEnd,
            };

            entity = this.DataContext.GroupToTests.Add(entity);
            this.DataContext.SaveChanges();
            return entity;
        }

        public GroupToTest Add(GroupToTest entity)
        {
            entity = this.DataContext.GroupToTests.Add(entity);
            this.DataContext.SaveChanges();
            return entity;
        }

        public GroupToTest[] ListByGroup(int groupID)
        {
            return this.DataContext.GroupToTests
                .Include(gt => gt.Group)
                .Include(gt => gt.Test)
                .Where(gt => gt.GroupID == groupID)
                .ToArray();
        }

        public GroupToTest[] ListByTest(int testID)
        {
            return this.DataContext.GroupToTests
                .Include(gt => gt.Group)
                .Include(gt => gt.Test)
                .Where(gt => gt.TestID == testID)
                .ToArray();
        }

        public GroupToTest[] AddRange(GroupToTest[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(GroupToTest entity)
        {
            throw new NotImplementedException();
        }

        public GroupToTest Get(int id)
        {
            throw new NotImplementedException();
        }

        public GroupToTest Get(int groupID, int testID)
        {
            return this.DataContext.GroupToTests
                .FirstOrDefault(gt => gt.GroupID == groupID && gt.TestID == testID);
        }

        public GroupToTest[] List()
        {
            throw new NotImplementedException();
        }

        public void Update(GroupToTest entity)
        {
            throw new NotImplementedException();
        }
    }
}
