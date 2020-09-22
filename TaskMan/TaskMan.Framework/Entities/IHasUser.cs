using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Membership.Entities;

namespace TaskMan.Framework.Entities
{
    public interface IHasUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
