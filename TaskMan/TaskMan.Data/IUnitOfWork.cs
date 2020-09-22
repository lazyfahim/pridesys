using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
