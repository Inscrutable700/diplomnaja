using Data.Models;

namespace Business.Dto
{
    public class UserTestsDto
    {
        public UserTest[] AvailableTests { get; set; }

        public UserTest[] PassedTests { get; set; }

        public UserTest[] FutureTests { get; set; }
    }
}
