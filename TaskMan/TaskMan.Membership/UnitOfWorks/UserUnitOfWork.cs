
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskMan.Data;
using TaskMan.Membership.Contexts;
using TaskMan.Membership.Repositories;

namespace TaskMan.Membership.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWork, IUserUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; }

        public UserUnitOfWork(MemberShipContext context, IUserRepository userRepository) : base(context)
        {
            this.UserRepository = userRepository;
        }
    }
}
