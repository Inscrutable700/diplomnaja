using System.Linq;
using System.Data.Entity;
using Data.Models;
using System;

namespace Data.Repositories
{
    public class TestRepository : RepositoryBase, IRepository<Test>
    {
        public TestRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Test Add(Test entity)
        {
            Test test = this.DataContext.Tests.Add(entity);
            this.DataContext.SaveChanges();
            return test;
        }

        public Test[] AddRange(Test[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Test entity)
        {
            this.DataContext.Tests.Remove(entity);
            this.DataContext.SaveChanges();
        }

        public Test Get(int id)
        {
            return this.DataContext.Tests
                .Include(t => t.Questions.Select(q => q.AwailableAnswers))
                .SingleOrDefault(t => t.ID == id);
        }

        public Test[] List()
        {
            return this.DataContext.Tests.ToArray();
        }

        public Test[] List(int academicSubjectID)
        {
            return this.DataContext.Tests
                .Include(t => t.Questions.Select(q => q.AwailableAnswers))
                .Where(t => t.AcademicSubjectID == academicSubjectID)
                .ToArray();
        }

        public void Update(Test entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
