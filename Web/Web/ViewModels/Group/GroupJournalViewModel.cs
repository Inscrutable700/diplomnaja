using System.Collections.Generic;

namespace Web.ViewModels
{
    public class GroupJournalViewModel
    {
        public GroupJournalViewModel()
        {
            this.Tests = new List<Test>();
            this.Users = new List<User>();
        }

        public string GroupName { get; set; }

        public List<Test> Tests { get; set; }

        public List<User> Users { get; set; }

        public class Test
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public int MaxPoints { get; set; }
        }

        public class User
        {
            public User()
            {
                this.Points = new Dictionary<int, double>();
            }

            public int ID { get; set; }

            public string Name { get; set; }

            public Dictionary<int, double> Points { get; set; }
        }
    }
}