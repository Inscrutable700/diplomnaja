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
        public GroupManager(RepositoryContext repositoryContext, BusinessContext businessContext)
            : base(repositoryContext, businessContext)
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

        public void AddTestToGroup(int groupID, int testID, int questionsPerUser, int points, DateTime? dateStart, DateTime? dateEnd)
        {
            GroupToTest groupToTest = this.repositoryContext.GroupToTestRepository.Get(groupID, testID);

            if (groupToTest == null)
            {
                groupToTest = this.repositoryContext.GroupToTestRepository.Add(groupID, testID, questionsPerUser, points, dateStart, dateEnd);
                this.businessContext.UserManager.AssignTestToUsers(groupID, testID, groupToTest);
            }
        }
        
        public Test[] GetTests(int groupID)
        {
            GroupToTest[] groupSubjects = this.repositoryContext.GroupToTestRepository.ListByGroup(groupID);
            return groupSubjects.Select(gs => gs.Test).ToArray();
        }

        public GroupToTest[] GetGroupTests(int groupID)
        {
            return this.repositoryContext.GroupToTestRepository.ListByGroup(groupID).ToArray();
        }

        public User[] GetUsers(int groupID)
        {
            return this.repositoryContext.UserRepository.ListByGroup(groupID);
        }
    }
}
