
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Services
{
    public interface ITaskService
    {
        (IList<Task>, int, int) GetPosts(int pageNum, string searchText);
        void AddTask(Task task);
        (IList<Task>, int, int) GetOwned(string username,int pageIndex = 1, int pageSize = 10);
        Task GetTask(int id, string username);
        void Delete(string username, int id);
        void update(Task task);
        (IList<Task>, int, int) GetAssigned(string username, int page = 1, int pageSize = 10);
    }
}
