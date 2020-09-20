
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;

namespace TaskMan.Framework.Entities
{
    public class Vote : IEntity<int>
    {
        public int Id { get; set; }
        public bool IsUpVote{get;set;}
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
