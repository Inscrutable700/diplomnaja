using System.Collections.Generic;

namespace Data.Models
{
    public class Question
    {
        public int ID { get; set; }

        public string QuestionString { get; set; }

        public int TestID { get; set; }

        public Test Test { get; set; }

        public ICollection<AvailableAnswer> AwailableAnswers { get; set; }
    }
}
