
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Repos;

namespace TaskMan.Framework.UOW
{
    public interface IPostUnitOfWork
    {
        public ITaskRepository PostRepository { get; }
    }
}
