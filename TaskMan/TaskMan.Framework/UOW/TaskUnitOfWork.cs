
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Repos;

namespace TaskMan.Framework.UOW
{
    public class TaskUnitOfWork : UnitOfWork, ITaskUnitOfWork
    {
        public TaskUnitOfWork(FrameworkContext context, ITaskRepository taskRepository) : base(context)
        {
            TaskRepository = taskRepository;
        }

        public ITaskRepository TaskRepository { get; private set; }
    }
}
