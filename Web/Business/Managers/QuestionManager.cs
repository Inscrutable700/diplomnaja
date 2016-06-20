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

        public Question AddQuestion(Question question, AvailableAnswer[] answers, int rightAnswerNumber)
        {
            question = this.repositoryContext.QuestionRepository.Add(question);
            this.AddAnswers(question, answers, rightAnswerNumber);
            return question;
        }

        public void UpdateQuestion(Question question, AvailableAnswer[] answers, int rightAnswerNumber)
        {
            this.repositoryContext.QuestionRepository.Update(question);
            this.AddAnswers(question, answers, rightAnswerNumber);
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

        private void AddAnswers(Question question, AvailableAnswer[] answers, int rightAnswerNumber)
        {
            if (answers != null)
            {
                //answers = answers.Where(a => !string.IsNullOrEmpty(a.AnswerString)).ToArray();

                var answersForRemove = this.repositoryContext.AvailableAnswerRepository.List(question.ID);
                this.repositoryContext.AvailableAnswerRepository.DeleteRange(answersForRemove);
                
                foreach (AvailableAnswer answer in answers)
                {
                    answer.QuestionID = question.ID;
                }

                answers = this.repositoryContext.AvailableAnswerRepository.AddRange(answers);

                if (answers.Length > rightAnswerNumber)
                {
                    question.RightAnswerID = answers[rightAnswerNumber].ID;
                    this.repositoryContext.QuestionRepository.Update(question);
                }
            }
        }

        public AvailableAnswer[] GetAvailableAnswers(int questionID)
        {
            return this.repositoryContext.AvailableAnswerRepository.List(questionID);
        }
    }
}
