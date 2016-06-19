using System;

namespace Data.Models
{
    public class UserTest
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public int TestID { get; set; }

        public Test Test { get; set; }

        public DateTime DateAssigned { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}
