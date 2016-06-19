using System.Web.Mvc;

namespace Web.ViewModels
{
    public class AddOrUpdateGroupViewModel
    {
        public GroupViewModel Group { get; set; }

        public bool IsUpdate { get; set; }

        public SelectListItem[] AllOtherUsers { get; set; }

        public SelectListItem[] AllOtherTests { get; set; }
    }
}