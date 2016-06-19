using System.Linq;
using Data;
using Data.Models;

namespace Business.Managers
{
    public class QuestionManager : ManagerBase
    {
        public QuestionManager(RepositoryContext repositoryContext, BusinessContext businessContext)
            : base(repositoryContext, businessContext)
        {
        }

        public Question AddQuestion(Question question, AvailableAnswer[] answers)
        {
            question = this.repositoryContext.QuestionRepository.Add(question);
            this.AddAnswers(question.ID, answers);
            return question;
        }

        public void UpdateQuestion(Question question, AvailableAnswer[] answers)
        {
            this.repositoryContext.QuestionRepository.Update(question);
            this.AddAnswers(question.ID, answers);
        }

        public Question GetQuestion(int id)
        {
            return this.repositoryContext.QuestionRepository.Get(id);
        }

        public Question[] GetQuestions(int testID)
        {
            return this.repositoryContext.QuestionRepository.List(testID);
        }

        public void DeleteQuestion(Question question)
        {
            this.repositoryContext.QuestionRepository.Delete(question);
        }

        private void AddAnswers(int questionID, AvailableAnswer[] answers)
        {
            if (answers != null)
            {
                answers = answers.Where(a => !string.IsNullOrEmpty(a.AnswerString)).ToArray();

                var answersForRemove = this.repositoryContext.AvailableAnswerRepository.List(questionID);
                this.repositoryContext.AvailableAnswerRepository.DeleteRange(answersForRemove);
                
                foreach (AvailableAnswer answer in answers)
                {
                    answer.QuestionID = questionID;
                }

                this.repositoryContext.AvailableAnswerRepository.AddRange(answers);
            }
        }

        public AvailableAnswer[] GetAvailableAnswers(int questionID)
        {
            return this.repositoryContext.AvailableAnswerRepository.List(questionID);
        }
    }
}
