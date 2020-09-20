
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Services
{
    public interface IUserService : IDisposable
    {
        User GetUserDetails(int userId);
        void EditUser(User user);

        void EditProfilePicture(User user);

        Task<string> GetToken(string username, string password,byte[] key);
    }
}
