namespace Web.ViewModels
{
    public class AddOrUpdateAcademicSubjectViewModel
    {
        public AcademicSubjectViewModel AcademicSubject { get; set; }

        public TestViewModel[] Tests { get; set; }

        public bool IsUpdate { get; set; }
    }
}