using System.Web.Mvc;
using AutoMapper;
using Business;
using Data.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class TestsController : Controller
    {
        public TestsController()
        {
            Mapper.CreateMap<Test, TestViewModel>();
            Mapper.CreateMap<TestViewModel, Test>();
            Mapper.CreateMap<AcademicSubject, SelectListItem>()
                .ForMember(dest => dest.Value, ost => ost.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.Text, ost => ost.MapFrom(src => src.Name));
            Mapper.CreateMap<Question, QuestionViewModel>();
        }

        // GET: Test
        public ActionResult Index()
        {
            TestListViewModel model = new TestListViewModel();
            model.Tests = new TestViewModel[0];
            using (BusinessContext businessContext = new BusinessContext())
            {
                Test[] tests = businessContext.TestManager.GetTests();
                model.Tests = Mapper.Map<TestViewModel[]>(tests);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrUpdate(int? id = null)
        {
            AddOrUpdateTestViewModel model = new AddOrUpdateTestViewModel();

            model.Test = new TestViewModel();
            model.Questions = new QuestionViewModel[0];
            using (BusinessContext businessContext = new BusinessContext())
            {
                AcademicSubject[] subjects = businessContext.AcademicSubjectManager.GetAcademicSubjects();
                model.AcademicSubjects = Mapper.Map<SelectListItem[]>(subjects);

                if (id != null)
                {
                    Test test = businessContext.TestManager.GetTest(id.Value);
                    model.Test = Mapper.Map(test, model.Test);

                    Question[] questions = businessContext.QuestionManager.GetQuestions(id.Value);
                    model.Questions = Mapper.Map<QuestionViewModel[]>(questions);

                    foreach (var subject in model.AcademicSubjects)
                    {
                        subject.Selected = subject.Value == test.AcademicSubjectID.ToString();
                    }

                    model.IsUpdate = true;
                }
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOrUpdate(TestViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                if (model.ID == null)
                {
                    Test test = Mapper.Map<Test>(model);
                    businessContext.TestManager.AddTest(test);
                }
                else
                {
                    Test test = businessContext.TestManager.GetTest(model.ID.Value);
                    test = Mapper.Map(model, test);
                    businessContext.TestManager.UpdateTest(test);
                }
            }

            return RedirectToAction("Index");
        }
    }
}