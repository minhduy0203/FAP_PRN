using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;

namespace FAPWeb_Se1705.Service
{
    public class GroupService : IGroupService
    {
        private IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public List<Group> GetGroups()
        {
            return groupRepository.GetGroups();
        }
    }
}
