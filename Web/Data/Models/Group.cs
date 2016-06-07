using System.Collections.Generic;

namespace Data.Models
{
    public class Group
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
