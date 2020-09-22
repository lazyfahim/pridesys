
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Membership.Contexts;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Repositories
{
    public interface IUserRepository : IRepository<User, int, MemberShipContext>
    {
        List<int> GetUserIdListOfProvidedRole(string roleNameNormalized);
    }
}
