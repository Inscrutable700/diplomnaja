﻿using System;
using Data.Repositories;

namespace Data
{
    public class RepositoryContext : IDisposable
    {
        private DataContext dataContext;

        private UserRepository userRepository;

        private AcademicSubjectRepository academicSubjectRepository;

        private TestRepository testRepository;

        private QuestionRepository questionRepository;

        private AvailableAnswerRepository availableAnswerRepository;

        private GroupRepository groupRepository;

        private GroupToTestRepository groupToTestRepository;

        private UserTestRepository userTestRepository;

        private UserTestAnswerRepository userTestAnswerRepository;

        public RepositoryContext()
        {
            this.dataContext = new DataContext();
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.dataContext);
                }

                return this.userRepository;
            }
        }

        public AcademicSubjectRepository AcademicSubjectRepository
        {
            get
            {
                if (this.academicSubjectRepository == null)
                {
                    this.academicSubjectRepository = new AcademicSubjectRepository(this.dataContext);
                }

                return this.academicSubjectRepository;
            }
        }

        public TestRepository TestRepository
        {
            get
            {
                if(this.testRepository == null)
                {
                    this.testRepository = new TestRepository(this.dataContext);
                }

                return this.testRepository;
            }
        }

        public QuestionRepository QuestionRepository
        {
            get
            {
                if(this.questionRepository == null)
                {
                    this.questionRepository = new QuestionRepository(this.dataContext);
                }

                return this.questionRepository;
            }
        }

        public AvailableAnswerRepository AvailableAnswerRepository
        {
            get
            {
                if (this.availableAnswerRepository == null)
                {
                    this.availableAnswerRepository = new AvailableAnswerRepository(this.dataContext);
                }

                return this.availableAnswerRepository;
            }
        }

        public GroupRepository GroupRepository
        {
            get
            {
                if(this.groupRepository == null)
                {
                    this.groupRepository = new GroupRepository(this.dataContext);
                }

                return this.groupRepository;
            }
        }

        public GroupToTestRepository GroupToTestRepository
        {
            get
            {
                if(this.groupToTestRepository == null)
                {
                    this.groupToTestRepository = new GroupToTestRepository(this.dataContext);
                }

                return this.groupToTestRepository;
            }
        }

        public UserTestRepository UserTestRepository
        {
            get
            {
                if (this.userTestRepository == null)
                {
                    this.userTestRepository = new UserTestRepository(this.dataContext);
                }

                return this.userTestRepository;
            }
        }
         
        public UserTestAnswerRepository UserTestAnswerRepository
        {
            get
            {
                if (this.userTestAnswerRepository == null)
                {
                    this.userTestAnswerRepository = new UserTestAnswerRepository(this.dataContext);
                }

                return this.userTestAnswerRepository;
            }
        }

        public void Dispose()
        {
            this.dataContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
