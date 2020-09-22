
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Repos;

namespace TaskMan.Framework.UOW
{
    public interface ITaskUnitOfWork:IUnitOfWork
    {
        public ITaskRepository TaskRepository { get; }
    }
}
