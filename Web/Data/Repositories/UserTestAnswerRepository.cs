using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserTestAnswerRepository : RepositoryBase, IRepository<UserTestAnswer>
    {
        public UserTestAnswerRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public UserTestAnswer Add(UserTestAnswer entity)
        {
            throw new NotImplementedException();
        }

        public UserTestAnswer[] AddRange(UserTestAnswer[] entities)
        {
            entities = this.DataContext.UserTestAnswers.AddRange(entities).ToArray();
            this.DataContext.SaveChanges();
            return entities;
        }

        public void Delete(UserTestAnswer entity)
        {
            throw new NotImplementedException();
        }

        public UserTestAnswer Get(int id)
        {
            throw new NotImplementedException();
        }

        public UserTestAnswer[] List()
        {
            throw new NotImplementedException();
        }

        public UserTestAnswer[] List(int userTestID)
        {
            return this.DataContext.UserTestAnswers
                .Include(uta => uta.Question)
                .Where(uta => uta.UserTestID == userTestID)
                .ToArray();
        }

        public void Update(UserTestAnswer entity)
        {
            throw new NotImplementedException();
        }
    }
}
