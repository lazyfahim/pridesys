
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Framework.Entities;
using TaskMan.Framework.UOW;

namespace TaskMan.Framework.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskUnitOfWork _uow;
        public TaskService(ITaskUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddTask(Task task)
        {
            _uow.TaskRepository.Add(task);
            _uow.Save();
        }

        public void Delete(string username, int id)
        {
            var task = GetTask(id, username);
            if(task != null)
            {
                if (task.User.UserName == username)
                {
                    _uow.TaskRepository.Remove(id);
                    _uow.Save();
                    return;
                }
                    
            }
            throw new Exception("Unauthorized");
        }

        public (IList<Task>, int, int) GetAssigned(string username, int page = 1,int pageSize=10)
        {
            var res = _uow.TaskRepository.GetDynamic(x => x.AssignedTo.UserName == username, null,
                x => x.Include(y => y.AssignedTo).Include(y => y.User), page, pageSize, false);
            return res;
        }

        public (IList<Task>, int, int) GetOwned(string username,int pageIndex = 1,int pageSize = 10)
        {
            var res = _uow.TaskRepository.GetDynamic(x => x.User.UserName == username,null,
                x => x.Include(y => y.AssignedTo).Include(y => y.User),pageIndex, pageSize,false);
            return res;
        }

        public (IList<Task>, int, int) GetPosts(int pageNum, string searchText)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(int id, string username)
        {
            var task = _uow.TaskRepository
                .Get(x => x.Id == id && 
                (x.User.UserName == username || x.AssignedTo.UserName == username), 
                null, i => i.Include(x => x.User).Include(x => x.AssignedTo), false).FirstOrDefault();
            return task;
        }

        public void update(Task task)
        {
            _uow.TaskRepository.Edit(task);
            _uow.Save();
        }
    }
}
