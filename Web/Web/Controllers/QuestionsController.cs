using System.Web.Mvc;
using AutoMapper;
using Business;
using Data.Models;
using Web.ViewModels;
using System.Linq;

namespace Web.Controllers
{
    public class QuestionsController : Controller
    {
        public QuestionsController()
        {
            Mapper.CreateMap<AvailableAnswerViewModel, AvailableAnswer>();
            Mapper.CreateMap<AvailableAnswer, AvailableAnswerViewModel>();
            Mapper.CreateMap<QuestionViewModel, Question>();
            Mapper.CreateMap<Question, QuestionViewModel>()
                .ForMember(dest => dest.AvailableAnswers, ost => ost.MapFrom(src => Mapper.Map<AvailableAnswerViewModel[]>(src.AwailableAnswers)));
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Item(int userTestID, int? userQuestionID = null)
        {
            QuestionItemViewModel model = new QuestionItemViewModel();
            model.UserTestID = userTestID;
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(this.User.Identity.Name);
                UserTest userTest = businessContext.UserManager.GetUserTest(userTestID);
                model.IsCompleted = userTest.IsCompleted;
                UserTestAnswer[] questions = businessContext.UserManager.GetUserQuestions(user.ID, userTestID)
                    .OrderBy(q => q.ID)
                    .ToArray();
                UserTestAnswer userQuestion = null;
                if (userQuestionID != null)
                {
                    userQuestion = businessContext.UserManager
                        .GetUserQuestion(user.ID, userTestID, userQuestionID.Value);
                }
                else
                {
                    userQuestion = questions.FirstOrDefault();
                }

                model.Question = Mapper.Map<QuestionViewModel>(userQuestion.Question);
                model.UserTestAnswerID = userQuestion.ID;
                AvailableAnswer[] answers = businessContext.QuestionManager.GetAvailableAnswers(userQuestion.Question.ID);
                model.Question.AvailableAnswers = Mapper.Map<AvailableAnswerViewModel[]>(answers);
                model.AllQuestions = questions.Select(q => new SelectListItem
                {
                    Text = q.ID.ToString(),
                    Value = q.ID.ToString(),
                    Selected = q.ID == userQuestion.ID,
                })
                .ToArray();
            }

            return View(model);
        }

        public ActionResult NextItem(int userTestID, int? userQuestionID = null)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(this.User.Identity.Name);
                UserTestAnswer question = businessContext.UserManager
                    .GetNextUserQuestion(user.ID, userTestID, userQuestionID.Value);

                if(question == null)
                {
                    return this.RedirectToAction("Item", "Tests", new { userTestID = userTestID });
                }

                return this.RedirectToAction("Item", new { userTestID = userTestID, userQuestionID = question.ID });
            }
        }

        [HttpPost]
        public ActionResult Answer(int userTestID, int userQuestionID, int availableAnswerID)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.UserManager.AnswerQuestion(userQuestionID, availableAnswerID);
            }

            return this.RedirectToAction("NextItem", new { userTestID = userTestID, userQuestionID = userQuestionID });
        }

        public ActionResult AddOrUpdate(int? testID = null, int? id = null)
        {
            AddOrUpdateQuestionViewModel model = new AddOrUpdateQuestionViewModel();

            model.Question = new QuestionViewModel();
            model.Question.AvailableAnswers = new AvailableAnswerViewModel[0];
            if (testID != null)
            {
                model.Question.TestID = testID.Value;
            }
            using (BusinessContext businessContext = new BusinessContext())
            {
                if (id != null)
                {
                    Question question = businessContext.QuestionManager.GetQuestion(id.Value);
                    model.Question = Mapper.Map(question, model.Question);
                    for(int i = 0; i < model.Question.AvailableAnswers.Length; i++)
                    {
                        if (model.Question.AvailableAnswers[i].ID == question.RightAnswerID)
                        {
                            model.Question.RightAnswerNumber = i;
                        }
                    }

                    model.IsUpdate = true;
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(QuestionViewModel model)
        {
            if (model == null || model.AvailableAnswers == null || model.AvailableAnswers.Length <= 0)
            {
                return this.Content("Error");
            }

            using (BusinessContext businessContext = new BusinessContext())
            {
                if (model.ID == null)
                {
                    Question question = Mapper.Map<Question>(model);
                    AvailableAnswer[] answers = Mapper.Map<AvailableAnswer[]>(model.AvailableAnswers);
                    businessContext.QuestionManager.AddQuestion(question, answers, model.RightAnswerNumber);
                }
                else
                {
                    Question question = businessContext.QuestionManager.GetQuestion(model.ID.Value);
                    question = Mapper.Map(model, question);
                    AvailableAnswer[] answers = Mapper.Map<AvailableAnswer[]>(model.AvailableAnswers);
                    if(answers.Length > model.RightAnswerNumber)
                    {
                        answers[model.RightAnswerNumber].IsTrue = true;
                    }

                    businessContext.QuestionManager.UpdateQuestion(question, answers, model.RightAnswerNumber);
                }
            }

            return RedirectToAction("AddOrUpdate", "Tests", new { id = model.TestID });
        }
    }
}