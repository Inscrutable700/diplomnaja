using System;

namespace Data.Models
{
    public class GroupToTest
    {
        public int ID { get; set; }

        public int GroupID { get; set; }

        public Group Group { get; set; }

        public int TestID { get; set; }

        public Test Test { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public int QuestionCount { get; set; }

        public int PointsForComplete { get; set; }
    }
}
