using System.Web.Mvc;

namespace Web.ViewModels
{
    public class AddOrUpdateTestViewModel
    {
        public TestViewModel Test { get; set; }

        public QuestionViewModel[] Questions { get; set; }

        public SelectListItem[] AcademicSubjects { get; set; }

        public bool IsUpdate { get; set; }
    }
}