namespace Core.Dto
{
    public class UserTestsDto
    {
        public UserTestDto[] AvailableTests { get; set; }

        public UserTestDto[] PassedTests { get; set; }

        public UserTestDto[] FutureTests { get; set; }
    }
}
