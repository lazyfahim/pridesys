
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;
using TaskMan.Framework.UOW;

namespace TaskMan.Framework.Services
{
    public class TaskService:ITaskService
    {
        private readonly IPostUnitOfWork _uow;
        public TaskService(IPostUnitOfWork uow)
        {
            _uow = uow;
        }

        public (IList<Task>, int, int) GetPosts(int pageNum, string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
