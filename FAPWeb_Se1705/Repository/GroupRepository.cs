using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private FAPPRJContext context;

        public GroupRepository(FAPPRJContext context)
        {
            this.context = context;
        }

        public List<Group> GetGroups()
        {
            return context.Groups.ToList();
        }
    }
}
