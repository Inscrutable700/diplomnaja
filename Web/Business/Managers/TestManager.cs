using System;
using Data;
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

        public void Finish(int userID, int userTestID)
        {
            UserTest userTest = this.repositoryContext.UserTestRepository.Get(userTestID);
            if(userTest.UserID != userID)
            {
                return;
            }

            UserTestAnswer[] userAnswers = this.repositoryContext.UserTestAnswerRepository.List(userTestID);
            double pointsPerQuestion = userTest.GroupToTest.PointsForComplete / userAnswers.Length;
            double testPoints = 0;
            foreach(UserTestAnswer userTestAnswer in userAnswers)
            {
                if (userTestAnswer.DateCompleted != null)
                {
                    if (userTestAnswer.AnswerID == userTestAnswer.Question.RightAnswerID)
                    {
                        userTestAnswer.Points = pointsPerQuestion;
                        testPoints += pointsPerQuestion;
                    }
                    else
                    {
                        userTestAnswer.Points = -pointsPerQuestion;
                        testPoints -= pointsPerQuestion;
                    }

                    this.repositoryContext.UserTestAnswerRepository.Update(userTestAnswer);
                }
            }

            userTest.Points = testPoints;
            userTest.DateCompleted = DateTime.UtcNow;
            userTest.IsCompleted = true;
            this.repositoryContext.UserTestRepository.Update(userTest);
        }
    }
}
