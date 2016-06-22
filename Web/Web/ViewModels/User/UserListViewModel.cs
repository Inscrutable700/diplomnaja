using Core.Enums;

namespace Web.ViewModels
{
    public class UserListViewModel
    {
        public UserViewModel[] Users { get; set; }

        public bool IsAdmin { get; set; }
    }
}