using Business.Dto;
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

        public User GetUser(string email)
        {
            return this.repositoryContext.UserRepository.Get(email);
        }

        public User[] GetUsers()
        {
            return this.repositoryContext.UserRepository.List();
        }

        public UserTest[] GetUserCompletedTests(int userID)
        {
            return this.repositoryContext.UserTestRepository.ListByUser(userID, onlyCompleted: true);
        }

        public UserTestsDto GetUserTests(int userID)
        {
            UserTestsDto result = new UserTestsDto();
            User user = this.repositoryContext.UserRepository.Get(userID);
            if (user != null)
            {
                UserTest[] userTests = this.repositoryContext.UserTestRepository.ListByUser(userID);
                result.AvailableTests = userTests
                    .Where(ut => !ut.IsCompleted)
                    .Where(ut => ut.GroupToTest.DateStart == null || ut.GroupToTest.DateStart.Value < DateTime.UtcNow)
                    .Where(ut => ut.GroupToTest.DateEnd == null || ut.GroupToTest.DateEnd.Value > DateTime.UtcNow)
                    .ToArray();

                result.PassedTests = userTests
                    .Where(ut => ut.IsCompleted || ut.GroupToTest.DateEnd == null || ut.GroupToTest.DateEnd.Value < DateTime.UtcNow)
                    .ToArray();

                result.FutureTests = userTests
                    .Where(ut => ut.GroupToTest.DateStart != null && ut.GroupToTest.DateStart.Value > DateTime.UtcNow)
                    .ToArray();
            }
            
            return result;
        }

        public UserTest GetUserTest(int userTestID)
        {
            return this.repositoryContext.UserTestRepository.Get(userTestID);
        }

        public void AssignTestToUsers(int groupID, int testID, GroupToTest grouptToTest)
        {
            User[] groupUsers = this.repositoryContext.UserRepository.ListByGroup(groupID);
            Question[] questions = this.repositoryContext.QuestionRepository.List(testID);

            foreach (User user in groupUsers)
            {
                Question[] randomQuestions = GetRandomQuestions(grouptToTest.QuestionCount, questions);
                UserTest userTest = this.repositoryContext.UserTestRepository.Add(user.ID, testID, grouptToTest.ID);

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
            Random random = new Random();
            List<Question> randomQuestions = new List<Question>();
            Question[] questionsT = new List<Question>(questions).ToArray();
            for(int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(i, count - 1);
                randomQuestions.Add(questionsT[randomIndex]);
                Question temp = questionsT[i];
                questionsT[i] = questionsT[randomIndex];
                questionsT[randomIndex] = temp;
            }

            return randomQuestions.ToArray();
        }

        public UserTestAnswer GetUserQuestion(int userID, int userTestID, int userAnswerID)
        {
            UserTestAnswer userTestAnswer = this.repositoryContext.UserTestAnswerRepository.Get(userAnswerID);
            return userTestAnswer;
        }

        public UserTestAnswer GetNextUserQuestion(int userID, int userTestID, int currentAnswerID)
        {
            UserTestAnswer userTestAnswer = this.repositoryContext.UserTestAnswerRepository.GetNext(userTestID, currentAnswerID);
            return userTestAnswer;
        }

        public UserTestAnswer[] GetUserQuestions(int userID, int userTestID)
        {
            UserTestAnswer[] userTestAnswers = this.repositoryContext.UserTestAnswerRepository.List(userTestID);
            return userTestAnswers.ToArray();
        }

        public void AnswerQuestion(int userTestAnswerID, int availableAnswerID)
        {
            UserTestAnswer userTestAnswer = this.repositoryContext.UserTestAnswerRepository.Get(userTestAnswerID);
            userTestAnswer.AnswerID = availableAnswerID;
            userTestAnswer.DateCompleted = DateTime.UtcNow;
            this.repositoryContext.UserTestAnswerRepository.Update(userTestAnswer);
        }
    }
}
