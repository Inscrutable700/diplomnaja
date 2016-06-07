namespace Data.Models
{
    public class AvailableAnswer
    {
        public int ID { get; set; }
        
        public int QuestionID { get; set; }

        public Question Question { get; set; }

        public string AnswerString { get; set; }

        public bool IsTrue { get; set; }
    }
}
