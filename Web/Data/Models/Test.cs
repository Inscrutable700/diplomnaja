using System.Collections.Generic;

namespace Data.Models
{
    public class Test
    {
        public int ID { get; set; }

        public int AcademicSubjectID { get; set; }

        public AcademicSubject AcademicSubject { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }

        public int CountQuestions { get; set; }
    }
}
