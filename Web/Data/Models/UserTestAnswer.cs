using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class UserTestAnswer
    {
        public int ID { get; set; }

        public int UserTestID { get; set; }

        public UserTest UserTest { get; set; }

        public int QuestionID { get; set; }

        public Question Question { get; set; }

        [ForeignKey("Answer")]
        public int? AnswerID { get; set; }

        public AvailableAnswer Answer { get; set; }

        public DateTime DateAssigned { get; set; }

        public DateTime? DateCompleted { get; set; }

        public double Points { get; set; }
    }
}
