using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
    public class UserTestViewModel
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? AcademicSubjectID { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public bool IsCompleted { get; set; }
    }
}