
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Services
{
    public interface IMemberService : IDisposable
    {
        (IList<User> records, int total, int totalDisplay) GetUserList(int pageIndex, int pageSize, string searchText, string sortText);

        User GetUser(int id);

        void UpdateUserInformation(User user);
    }
}
