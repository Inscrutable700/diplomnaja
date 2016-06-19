using AutoMapper;
using Business;
using Data.Models;
using System.Linq;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class GroupsController : Controller
    {
        public GroupsController()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<Group, GroupViewModel>()
                .ForMember(dest => dest.Users, ost => ost.MapFrom(src => Mapper.Map<UserViewModel[]>(src.Users)));
            Mapper.CreateMap<GroupViewModel, Group>();
            Mapper.CreateMap<User, SelectListItem>()
                .ForMember(dest => dest.Text, ost => ost.MapFrom(src => $"{src.Name} ({src.Email})"))
                .ForMember(dest => dest.Value, ost => ost.MapFrom(src => src.ID.ToString()))
                .ForMember(dest => dest.Group, ost => ost.Ignore());
        }

        // GET: AcademicSubject
        public ActionResult Index()
        {
            GroupListViewModel model = new GroupListViewModel();
            using (BusinessContext businessContext = new BusinessContext())
            {
                Group[] groups = businessContext.GroupManager.GetGroups();
                model.Groups = Mapper.Map<GroupViewModel[]>(groups);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult AddOrUpdate(int? id = null)
        {
            AddOrUpdateGroupViewModel model = new AddOrUpdateGroupViewModel();
            model.Group = new GroupViewModel();

            using(BusinessContext businessContext = new BusinessContext())
            {
                User[] allUsers = businessContext.UserManager.GetUsers();
                Test[] allTests = businessContext.TestManager.GetTests();

                if (id != null)
                {
                    Group group = businessContext.GroupManager.GetGroup(id.Value);
                    model.Group = Mapper.Map(group, model.Group);
                    allUsers = allUsers.Union(group.Users).ToArray();
                    Test[] tests = businessContext.GroupManager.GetTests(id.Value);
                    model.Group.Tests = Mapper.Map<TestViewModel[]>(tests);
                    allTests = allTests.Union(tests).ToArray();
                    model.IsUpdate = true;
                }

                model.AllOtherUsers = Mapper.Map<SelectListItem[]>(allUsers);
                model.AllOtherTests = Mapper.Map<SelectListItem[]>(allTests);
            }
            
            return View(model);
        }

        public ActionResult AddOrUpdate(GroupViewModel model)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                if (model.ID == null)
                {
                    Group group = Mapper.Map<Group>(model);
                    businessContext.GroupManager.AddGroup(group);
                }
                else
                {
                    Group group = businessContext.GroupManager.GetGroup(model.ID.Value);
                    group = Mapper.Map(model, group);
                    businessContext.GroupManager.UpdateGroup(group);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddUserToGroup(int groupID, int userID)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.GroupManager.AddUserToGroup(groupID, userID);
            }

            return RedirectToAction("AddOrUpdate", new { id = groupID });
        }

        public ActionResult AddTestToGroup(int groupID, int testID, int questionsPerUser)
        {
            using (BusinessContext businessContext = new BusinessContext())
            {
                businessContext.GroupManager.AddTestToGroup(groupID, testID, questionsPerUser);
            }

            return RedirectToAction("AddOrUpdate", new { id = groupID });
        }
    }
}