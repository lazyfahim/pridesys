
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Services
{
    public interface ITaskService
    {
        (IList<Task>, int, int) GetPosts(int pageNum, string searchText);
    }
}
