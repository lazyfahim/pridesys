
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Membership.Repositories;

namespace TaskMan.Membership.UnitOfWorks
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
