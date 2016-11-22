using System;
using System.Collections.Generic;
using MyBlogStarter.Domain;

namespace MyBlogStarter.Repositories
{
    public class DummyBlogRepository : IBlogRepository
    {
        private readonly List<Blog> _blogs;

        public DummyBlogRepository()
        {
            _blogs = new List<Blog>
            {
                new Blog {Id = 1, Author = "Mark Havekes", Title = "Prog6 Week1", TimeStamp = new DateTime(2016, 12, 5), Content = "dit was echt een leuke les!"},
                new Blog {Id = 2, Author = "Mark Havekes", Title = "Prog6 Week2", TimeStamp = new DateTime(2016, 12, 13), Content = "deze les echt supervette dingen geleerd!"},
                new Blog {Id = 3, Author = "Piet Jan", Title = "programeerles", TimeStamp = new DateTime(2016, 12, 6), Content = "Gister progameren gehad, en we hebben niet eens geprogrameerd!"},
                new Blog {Id = 4, Author = "Randy Random", Title = "Destruction", TimeStamp = new DateTime(2016, 12, 13), Content = "Ha! ik heb ze dit keer echt goed te pakken gehad."},
                new Blog {Id = 5, Author = "Cassandra Classic", Title = "rustige opbouw", TimeStamp = new DateTime(2016, 12, 13), Content = "Je moet rustig beginnen, maar dan opbouwen naar iets onmogelijks."}
                
            };
        }
        public List<Blog> GetAll()
        {
            return _blogs;
        }

        public bool Add(Blog blog)
        {
            if (blog == null) return false;
            _blogs.Add(blog);
            return true;
        }

        public bool Delete(Blog blog)
        {
            if (blog == null || !_blogs.Contains(blog)) return false;
            _blogs.Remove(blog);
            return true;
        }
    }
}
