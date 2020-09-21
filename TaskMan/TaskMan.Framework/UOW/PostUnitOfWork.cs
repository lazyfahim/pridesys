
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
        public PostUnitOfWork(FrameworkContext context, ITaskRepository postRepository) : base(context)
        {
            PostRepository = postRepository;
        }

        public ITaskRepository PostRepository { get; private set; }
    }
}
