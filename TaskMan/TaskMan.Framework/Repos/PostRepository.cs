
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Repos
{
    public class PostRepository:Repository<Post,int,FrameworkContext>,IPostRepository
    {
        public PostRepository(FrameworkContext context):base(context)
        {
        }
    }
}
