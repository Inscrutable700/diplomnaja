using System;
using Business.Managers;
using Data;

namespace Business
{
    public class BusinessContext : IDisposable
    {
        private RepositoryContext repositoryContext;

        private UserManager userManager;

        private AcademicSubjectManager academicSubjectManager;

        private TestManager testManager;

        private QuestionManager questionManager;

        private GroupManager groupManager;

        public BusinessContext()
        {
            this.repositoryContext = new RepositoryContext();
        }

        public UserManager UserManager
        {
            get
            {
                if( this.userManager == null)
                {
                    this.userManager = new UserManager(this.repositoryContext, this);
                }

                return this.userManager;
            }
        }

        public AcademicSubjectManager AcademicSubjectManager
        {
            get
            {
                if (this.academicSubjectManager == null)
                {
                    this.academicSubjectManager = new AcademicSubjectManager(this.repositoryContext, this);
                }

                return this.academicSubjectManager;
            }
        }

        public TestManager TestManager
        {
            get
            {
                if (this.testManager == null)
                {
                    this.testManager = new TestManager(this.repositoryContext, this);
                }

                return this.testManager;
            }
        }

        public QuestionManager QuestionManager
        {
            get
            {
                if (this.questionManager == null)
                {
                    this.questionManager = new QuestionManager(this.repositoryContext, this);
                }

                return this.questionManager;
            }
        }

        public GroupManager GroupManager
        {
            get
            {
                if(this.groupManager == null)
                {
                    this.groupManager = new GroupManager(this.repositoryContext, this);
                }

                return this.groupManager;
            }
        }

        public void Dispose()
        {
            repositoryContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
