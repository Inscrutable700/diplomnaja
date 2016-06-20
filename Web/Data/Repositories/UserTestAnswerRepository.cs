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
            return this.DataContext.UserTestAnswers
                .Include(uta => uta.Question)
                .SingleOrDefault(uta => uta.ID == id);
        }

        public UserTestAnswer GetNext(int userTestID, int id)
        {
            return this.DataContext.UserTestAnswers
                .Include(uta => uta.Question)
                .Where(uta => uta.UserTestID == userTestID)
                .Where(uta => uta.QuestionID > id)
                .OrderBy(uta => uta.ID)
                .FirstOrDefault();
        }

        public UserTestAnswer[] List()
        {
            throw new NotImplementedException();
        }

        public UserTestAnswer[] List(int userTestID)
        {
            return this.DataContext.UserTestAnswers
                .Include(uta => uta.Question)
                .Include(uta => uta.Answer)
                .Where(uta => uta.UserTestID == userTestID)
                .ToArray();
        }

        public void Update(UserTestAnswer entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
