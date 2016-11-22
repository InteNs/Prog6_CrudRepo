using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogStarter.Domain;

namespace MyBlogStarter.Repositories
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();
        bool Add(Blog blog);
        bool Delete(Blog blog);
    }
}
