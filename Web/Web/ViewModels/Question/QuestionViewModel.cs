namespace Web.ViewModels
{
    public class QuestionViewModel
    {
        public int? ID { get; set; }

        public string QuestionString { get; set; }

        public int TestID { get; set; }

        public AvailableAnswerViewModel[] AvailableAnswers { get; set; }

        public int RightAnswerNumber { get; set; }
    }
}