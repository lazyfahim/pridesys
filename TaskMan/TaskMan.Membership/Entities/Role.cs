using Microsoft.AspNetCore.Identity;

namespace TaskMan.Membership.Entities
{
    public class Role: IdentityRole<int>
    {
        public Role() : base()
        {

        }

        public Role(string roleName) : base(roleName)
        {

        }
    }
}