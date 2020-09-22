
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Membership.Entities;

namespace TaskMan.Membership.Services
{
    public interface IAdminManager
    {
        (IList<User> records, int total, int totalDisplay) GetAdminList(int pageIndex, int pageSize, string searchText, string sortText);
    }
}
