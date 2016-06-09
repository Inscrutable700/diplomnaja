using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Managers
{
    public class GroupManager : ManagerBase
    {
        public GroupManager(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Group AddGroup(Group group)
        {
            return this.repositoryContext.GroupRepository.Add(group);
        }

        public void UpdateGroup(Group group)
        {
            this.repositoryContext.GroupRepository.Update(group);
        }

        public void DeleteGroup(Group group)
        {
            this.repositoryContext.GroupRepository.Delete(group);
        }

        public Group GetGroup(int groupID)
        {
            return this.repositoryContext.GroupRepository.Get(groupID);
        }

        public Group[] GetGroups()
        {
            return this.repositoryContext.GroupRepository.List();
        }

        public void AddUserToGroup(int groupID, int userID)
        {
            User user = this.repositoryContext.UserRepository.Get(userID);
            user.GroupID = groupID;
            this.repositoryContext.UserRepository.Update(user);
        }
    }
}
