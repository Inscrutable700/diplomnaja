using Core.Dto;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Managers
{
    public class UserManager : ManagerBase
    {
        public UserManager(RepositoryContext repositoryContext, BusinessContext businessContext)
            : base(repositoryContext, businessContext)
        {
        }

        public User AddUser(User user)
        {
            return this.repositoryContext.UserRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            this.repositoryContext.UserRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            this.repositoryContext.UserRepository.Delete(user);
        }

        public User GetUser(int userID)
        {
            return this.repositoryContext.UserRepository.Get(userID);
        }

        public User[] GetUsers()
        {
            return this.repositoryContext.UserRepository.List();
        }

        public UserTestsDto GetUserTests(int userID)
        {
            UserTestsDto result = new UserTestsDto();
            User user = this.repositoryContext.UserRepository.Get(userID);
            if (user.GroupID != null)
            {
                Group group = this.repositoryContext.GroupRepository.Get(user.GroupID.Value);
                Test[] tests = this.repositoryContext.TestRepository.List();

            }
            
            return result;
        }

        public void AssignTestToUsers(int groupID, int testID, int countQuestions)
        {
            User[] groupUsers = this.repositoryContext.UserRepository.ListByGroup(groupID);
            Question[] questions = this.repositoryContext.QuestionRepository.List(testID);

            foreach (User user in groupUsers)
            {
                Question[] randomQuestions = GetRandomQuestions(countQuestions, questions);
                UserTest userTest = this.repositoryContext.UserTestRepository.Add(user.ID, testID);

                List<UserTestAnswer> userTestAnswers = new List<UserTestAnswer>();
                foreach(Question question in randomQuestions)
                {
                    userTestAnswers.Add(new UserTestAnswer
                    {
                        UserTestID = userTest.ID,
                        QuestionID = question.ID,
                        DateAssigned = DateTime.UtcNow,
                    });
                }

                this.repositoryContext.UserTestAnswerRepository.AddRange(userTestAnswers.ToArray());
            }
        }

        public Question[] GetRandomQuestions(int count, Question[] questions)
        {
            List<Question> randomQuestions = new List<Question>();
            randomQuestions = questions.Take(count).ToList();

            return randomQuestions.ToArray();
        }
    }
}
