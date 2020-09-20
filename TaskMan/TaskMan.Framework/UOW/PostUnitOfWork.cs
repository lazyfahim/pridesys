
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Data;
using TaskMan.Framework.Repos;

namespace TaskMan.Framework.UOW
{
    public class PostUnitOfWork : UnitOfWork, IPostUnitOfWork
    {
        public PostUnitOfWork(FrameworkContext context, IPostRepository postRepository) : base(context)
        {
            PostRepository = postRepository;
        }

        public IPostRepository PostRepository { get; private set; }
    }
}
