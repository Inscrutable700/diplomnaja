namespace Web.ViewModels
{
    public class GroupViewModel
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public UserViewModel[] Users { get; set; }
    }
}