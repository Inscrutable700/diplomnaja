using System.Web.Mvc;
using AutoMapper;
using Business;
using Data.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AcademicSubjectController : Controller
    {
        public AcademicSubjectController()
        {
            Mapper.CreateMap<AcademicSubject, AcademicSubjectViewModel>();
            Mapper.CreateMap<AcademicSubjectViewModel, AcademicSubject>();
        }

        // GET: AcademicSubject
        public ActionResult Index()
        {
            AcademicSubjectListViewModel model = new AcademicSubjectListViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                AcademicSubject[] subjects = businessContext.AcademicSubjectManager.GetAcademicSubjects();
                model.AcademicSubjects = Mapper.Map<AcademicSubjectViewModel[]>(subjects);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrUpdate(int? id = null)
        {
            AddOrUpdateAcademicSubjectViewModel model = new AddOrUpdateAcademicSubjectViewModel();
            model.AcademicSubject = new AcademicSubjectViewModel();

            if (id != null)
            {
                using (BusinessContext businessContext = new BusinessContext())
                {
                    AcademicSubject subject = businessContext.AcademicSubjectManager.GetAcademicSubject(id.Value);
                    model.AcademicSubject = Mapper.Map(subject, model.AcademicSubject);
                }

                model.IsUpdate = true;
            }

            return View(model);
        }

        public ActionResult AddOrUpdate(AcademicSubjectViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                if (model.ID == null)
                {
                    AcademicSubject subject = Mapper.Map<AcademicSubject>(model);
                    businessContext.AcademicSubjectManager.AddAcademicSubject(subject);
                }
                else
                {
                    AcademicSubject subject = businessContext.AcademicSubjectManager.GetAcademicSubject(model.ID.Value);
                    subject = Mapper.Map(model, subject);
                    businessContext.AcademicSubjectManager.UpdateAcademicSubject(subject);
                }
            }

            return RedirectToAction("Index");
        }
    }
}