
using System;
using System.Collections.Generic;
using System.Text;
using TaskMan.Framework.Entities;

namespace TaskMan.Framework.Services
{
    public interface IPostService
    {
        (IList<Post>, int, int) GetPosts(int pageNum, string searchText);
    }
}
