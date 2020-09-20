
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;

namespace TaskMan.Framework.Entities
{
    public class Post : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
