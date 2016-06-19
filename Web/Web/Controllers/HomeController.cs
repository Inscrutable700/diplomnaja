using AutoMapper;
using Business;
using Business.Dto;
using Data.Models;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(this.User.Identity.Name);
                UserTestsDto userTests = businessContext.UserManager.GetUserTests(user.ID);
                model.AvailableTests = Mapper.Map<UserTestViewModel[]>(userTests.AvailableTests);
                model.PassedTests = Mapper.Map<UserTestViewModel[]>(userTests.PassedTests);
                model.FutureTests = Mapper.Map<UserTestViewModel[]>(userTests.FutureTests);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}