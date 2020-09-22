
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Repos
{
    public class TaskRepository:Repository<Task,int,FrameworkContext>,ITaskRepository
    {
        public TaskRepository(FrameworkContext context):base(context)
        {
        }
    }
}
