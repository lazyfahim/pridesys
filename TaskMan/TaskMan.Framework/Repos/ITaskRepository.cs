
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Repos
{
    public interface ITaskRepository : IRepository<Task, int, FrameworkContext>
    {
    }
}
