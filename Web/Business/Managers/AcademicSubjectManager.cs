using Data;
using Data.Models;

namespace Business.Managers
{
    public class AcademicSubjectManager : ManagerBase
    {
        public AcademicSubjectManager(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public AcademicSubject AddAcademicSubject(AcademicSubject subject)
        {
            return this.repositoryContext.AcademicSubjectRepository.Add(subject);
        }

        public AcademicSubject GetAcademicSubject(int id)
        {
            return this.repositoryContext.AcademicSubjectRepository.Get(id);
        }

        public AcademicSubject[] GetAcademicSubjects()
        {
            return this.repositoryContext.AcademicSubjectRepository.List();
        }

        public void UpdateAcademicSubject(AcademicSubject subject)
        {
            this.repositoryContext.AcademicSubjectRepository.Update(subject);
        }
    }
}
