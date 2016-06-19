﻿using Data;
using Data.Models;

namespace Business.Managers
{
    public class TestManager : ManagerBase
    {
        public TestManager(RepositoryContext repositoryContext, BusinessContext businessContext)
            : base(repositoryContext, businessContext)
        {
        }

        public Test AddTest(Test test)
        {
            return this.repositoryContext.TestRepository.Add(test);
        }

        public Test GetTest(int id)
        {
            return this.repositoryContext.TestRepository.Get(id);
        }

        public Test[] GetTests()
        {
            return this.repositoryContext.TestRepository.List();
        }

        public Test[] GetTests(int subjectID)
        {
            return this.repositoryContext.TestRepository.List(subjectID);
        }

        public void UpdateTest(Test test)
        {
            this.repositoryContext.TestRepository.Update(test);
        }
    }
}
