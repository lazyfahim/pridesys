
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;

namespace TaskMan.Framework.Entities
{
    public class Comment : IEntity<int>
    {
        public int Id { get;set;}
        public string CommentBody { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
