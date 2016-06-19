namespace Web.ViewModels
{
    public class HomeViewModel
    {
        public UserTestViewModel[] AvailableTests { get; set; }

        public UserTestViewModel[] PassedTests { get; set; }

        public UserTestViewModel[] FutureTests { get; set; }
    }
}