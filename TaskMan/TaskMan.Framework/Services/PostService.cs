
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;
using TaskMan.Framework.UOW;

namespace TaskMan.Framework.Services
{
    public class PostService:IPostService
    {
        private readonly IPostUnitOfWork _uow;
        public PostService(IPostUnitOfWork uow)
        {
            _uow = uow;
        }

        public (IList<Post>, int, int) GetPosts(int pageNum, string searchText)
        {
            return _uow.PostRepository
                .GetDynamic(x => x.Title.Contains(searchText),
                    null,
                    x => x.Include(y => y.Comments).ThenInclude(c => c.Votes)
                    , pageNum, 10, true);
        }
    }
}
