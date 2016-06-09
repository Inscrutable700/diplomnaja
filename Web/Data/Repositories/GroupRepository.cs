using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GroupRepository : RepositoryBase, IRepository<Group>
    {
        public GroupRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        public Group Add(Group entity)
        {
            Group group = this.DataContext.Groups.Add(entity);
            this.DataContext.SaveChanges();
            return group;
        }

        public Group[] AddRange(Group[] entities)
        {
            Group[] groups = this.DataContext.Groups.AddRange(entities).ToArray();
            this.DataContext.SaveChanges();
            return groups;
        }

        public void Delete(Group entity)
        {
            this.DataContext.Groups.Remove(entity);
            this.DataContext.SaveChanges();
        }

        public Group Get(int id)
        {
            return this.DataContext.Groups
                .Include(g => g.Users)
                .SingleOrDefault(g => g.ID == id);
        }

        public Group[] List()
        {
            return this.DataContext.Groups.ToArray();
        }

        public void Update(Group entity)
        {
            this.DataContext.Entry(entity).State = EntityState.Modified;
            this.DataContext.SaveChanges();
        }
    }
}
