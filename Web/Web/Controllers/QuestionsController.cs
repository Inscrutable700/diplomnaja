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

        public ActionResult Item(int userTestID, int? userQuestionID = null)
        {
            QuestionItemViewModel model = new QuestionItemViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(this.User.Identity.Name);
                Question[] questions = businessContext.UserManager.GetUserQuestions(user.ID, userTestID);
                Question userQuestion = null;
                if (userQuestionID != null)
                {
                    userQuestion = businessContext.UserManager
                        .GetUserQuestion(user.ID, userTestID, userQuestionID.Value);
                }
                else
                {
                    userQuestion = questions.FirstOrDefault();
                }

                model.QuestionViewModel = Mapper.Map<QuestionViewModel>(userQuestion);
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
                return this.Content("Vse hernja");
            }

            using (BusinessContext businessContext = new BusinessContext())
            {
                if (model.ID == null)
                {
                    Question question = Mapper.Map<Question>(model);
                    AvailableAnswer[] answers = Mapper.Map<AvailableAnswer[]>(model.AvailableAnswers);
                    businessContext.QuestionManager.AddQuestion(question, answers);
                }
                else
                {
                    Question question = businessContext.QuestionManager.GetQuestion(model.ID.Value);
                    question = Mapper.Map(model, question);
                    AvailableAnswer[] answers = Mapper.Map<AvailableAnswer[]>(model.AvailableAnswers);
                    businessContext.QuestionManager.UpdateQuestion(question, answers);
                }
            }

            return RedirectToAction("AddOrUpdate", "Tests", new { id = model.TestID });
        }
    }
}