using System.Data.Entity;
using Data.Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<AcademicSubject> AcademicSubjects { get; set; }
 
        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<AvailableAnswer> AvailableAnswer { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupToTest> GroupToTests { get; set; }

        public DbSet<UserTest> UserTests { get; set; }

        public DbSet<UserTestAnswer> UserTestAnswers { get; set; }
    }
}
