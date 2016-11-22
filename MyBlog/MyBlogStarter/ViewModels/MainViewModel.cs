using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyBlogStarter.Domain;
using MyBlogStarter.Lib;
using MyBlogStarter.Repositories;

namespace MyBlogStarter.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Blog> Blogs { get; set; }
        public Blog SelectedBlog { get; set; }
        private IBlogRepository Repository { get; set; }

        public Blog NewBlog { get; set; }

        public ICommand DeleteBlogCommand { get; set; }
        public ICommand AddBlogCommand { get; set; }

        public MainViewModel(IBlogRepository repository)
        {
            Repository = repository;
            DeleteBlogCommand = new RelayCommand(p => true, p => DeleteBlog());
            AddBlogCommand = new RelayCommand(p => ValidBlog(), p => AddBlog());

            Blogs = new ObservableCollection<Blog>(Repository.GetAll());
            NewBlog = new Blog();
            
        }

        private void DeleteBlog()
        {
            if (Repository.Delete(SelectedBlog))
            {
                Blogs.Remove(SelectedBlog);
            }
        }

        private void AddBlog()
        {
            if (!Repository.Add(NewBlog)) return;
            Blogs.Add(NewBlog);
            NewBlog = new Blog();
        }

        private bool ValidBlog()
        {
            return NewBlog.Author != null &&
                   NewBlog.Content != null &&
                   NewBlog.Title != null;
        }
    }
}
