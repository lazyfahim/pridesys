using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Membership.Entities;

namespace TaskMan.Framework.Entities
{
    public class Task : IEntity<int>,IHasUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AssignedToId { get; set; }
        public User AssignedTo { get; set; }
    }
}
