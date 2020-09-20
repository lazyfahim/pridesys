
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Data;
using TaskMan.Membership.Contexts;
using TaskMan.Membership.Entities;
using TaskMan.Membership.Services;

namespace TaskMan.Membership.DataSeed
{
    public class UserDataSeeder : DataSeeder
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        private readonly User _adminUser;
        private readonly User _memberUser;

        private readonly Role _adminRole;
        private readonly Role _memberRole;

        public UserDataSeeder(UserManager userManager, RoleManager roleManager, MemberShipContext context) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _adminUser = new User("admin", "admin@mailboss.com");
            _memberUser = new User("member", "member@mailboss.com");

            _adminRole = new Role("admin");
            _memberRole = new Role("member");
        }

        public override async Task SeedAsync()
        {
            await SeedUsersAsync();
        }

        private async Task SeedUsersAsync()
        {
            if (await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper()) == null)
            {
                var result = await _userManager.CreateAsync(_adminUser, "Admin@1234");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRolesAsync(_adminRole))
                    {
                        await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
                    }
                }
            }

            if (await _userManager.FindByNameAsync(_memberUser.UserName.ToUpper()) == null)
            {
                var result = await _userManager.CreateAsync(_memberUser, "User@1234");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRolesAsync(_memberRole))
                    {
                        await _userManager.AddToRoleAsync(_memberUser, _memberRole.Name);
                    }
                }
            }
        }

        private async Task<bool> CheckAndCreateRolesAsync(Role role)
        {
            if ((await _roleManager.FindByNameAsync(role.Name)) == null)
            {
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;
        }
    }
}