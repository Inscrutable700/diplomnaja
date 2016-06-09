using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public GroupToTest Add(GroupToTest entity)
        {
            entity = this.DataContext.GroupToTests.Add(entity);
            this.DataContext.SaveChanges();
            return entity;
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
