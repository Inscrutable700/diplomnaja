using System;
using System.Data.Entity;
using System.Linq;
using Data.Models;

namespace Data.Repositories
{
    public class AcademicSubjectRepository : RepositoryBase, IRepository<AcademicSubject>
    {
        public AcademicSubjectRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public AcademicSubject Add(AcademicSubject entity)
        {
            AcademicSubject subject = this.DataContext.AcademicSubjects.Add(entity);
            this.DataContext.SaveChanges();
            return subject;
        }

        public AcademicSubject[] AddRange(AcademicSubject[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(AcademicSubject entity)
        {
            this.DataContext.AcademicSubjects.Remove(entity);
            this.DataContext.SaveChanges();
        }

        public AcademicSubject Get(int id)
        {
            return this.DataContext.AcademicSubjects
                .SingleOrDefault(a => a.ID == id);
        }

        public AcademicSubject[] List()
        {
            return this.DataContext.AcademicSubjects.ToArray();
        }

        public void Update(AcademicSubject entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
