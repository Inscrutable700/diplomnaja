using System.Web.Mvc;

namespace Web.ViewModels
{
    public class QuestionItemViewModel
    {
        public QuestionViewModel Question { get; set; }

        public SelectListItem[] AllQuestions { get; set; }

        public bool IsCompleted { get; set; }
    }
}