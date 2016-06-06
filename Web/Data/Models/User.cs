using Core.Enums;

namespace Data.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public UserType Type { get; set; }
    }
}
