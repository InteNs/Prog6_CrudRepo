using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MyBlogStarter.Repositories;
using Ninject;

namespace MyBlogStarter.ViewModels
{
    public class NinjectServiceLocator
    {
        private IKernel Kernel { get; set; }
        public NinjectServiceLocator()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IBlogRepository>().To<DummyBlogRepository>();

        }
        public MainViewModel Main => Kernel.Get<MainViewModel>();
    }
}
