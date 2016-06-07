namespace Web.ViewModels
{
    public class AvailableAnswerViewModel
    {
        public int? ID { get; set; }

        public int QuestionID { get; set; }

        public string AnswerString { get; set; }

        public bool IsTrue { get; set; }
    }
}