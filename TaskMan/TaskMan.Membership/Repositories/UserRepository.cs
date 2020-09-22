
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Data;
using TaskMan.Membership.Contexts;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Repositories
{
    public class UserRepository : Repository<User, int, MemberShipContext>, IUserRepository
    {
        public UserRepository(MemberShipContext context) : base(context)
        {

        }

        public List<int> GetUserIdListOfProvidedRole(string roleNameNormalized)
        {
            return GetUserListBasedOnRoleProvided(roleNameNormalized.ToUpper());
        }

        private List<int> GetUserListBasedOnRoleProvided(string roleNameNormalized)
        {
            var roleId = _dbContext.Roles.Where(x => x.NormalizedName == roleNameNormalized).Select(x => x.Id).ToList().First();
            List<int> userIdList = _dbContext.UserRoles.Where(x => x.RoleId == roleId).Select(x => x.UserId).Distinct().ToList();
            return userIdList;
        }
    }
}
