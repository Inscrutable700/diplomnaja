using System.Web.Mvc;
using AutoMapper;
using Business;
using Data.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            Mapper.CreateMap<User, UserViewModel>();
        }

        // GET: user
        [Authorize(Roles = "admin, teacher")]
        public ActionResult Index()
        {
            UserListViewModel model = new UserListViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                model.IsAdmin = this.User.IsInRole("admin");
                User[] users = businessContext.UserManager.GetUsers();
                model.Users = Mapper.Map<User[], UserViewModel[]>(users);
            }

            return View(model);
        }

        [Authorize(Roles = "admin, teacher")]
        public ActionResult Item(int id)
        {
            UserItemViewModel model = new UserItemViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                User user = businessContext.UserManager.GetUser(id);
                model.UserInfo = Mapper.Map<User, UserViewModel>(user);
            }

            return View(model);
        }

        [Authorize(Roles = "admin, teacher")]
        public ActionResult Tests(int userID)
        {

            return View();
        }
    }
}