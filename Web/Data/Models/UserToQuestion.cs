namespace Data.Models
{
    public class UserToQuestion
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public int QuestionID { get; set; }

        public Question Question { get; set; }
    }
}
