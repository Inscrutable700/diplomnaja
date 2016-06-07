using System;
using System.Data.Entity;
using System.Linq;
using Data.Models;

namespace Data.Repositories
{
    public class QuestionRepository : RepositoryBase, IRepository<Question>
    {
        public QuestionRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Question Add(Question entity)
        {
            Question question = this.DataContext.Questions.Add(entity);
            this.DataContext.SaveChanges();
            return question;
        }

        public Question[] AddRange(Question[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Question entity)
        {
            this.DataContext.Questions.Remove(entity);
            this.DataContext.SaveChanges();
        }

        public Question Get(int id)
        {
            return this.DataContext.Questions
                .Include(q => q.AwailableAnswers)
                .SingleOrDefault(q => q.ID == id);
        }

        public Question[] List()
        {
            return this.DataContext.Questions
                .Include(q => q.AwailableAnswers)
                .ToArray();
        }

        public Question[] List(int testID)
        {
            return this.DataContext.Questions
                .Include(q => q.AwailableAnswers)
                .Where(q => q.TestID == testID)
                .ToArray();
        }

        public void Update(Question entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
