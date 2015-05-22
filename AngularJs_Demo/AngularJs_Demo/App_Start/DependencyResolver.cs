using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using BLL;

namespace AngularJs_Demo
{
    public class DependencyResolver : IDependencyResolver
    {
        public IKernel kernel;
        public DependencyResolver()
        {
            kernel = new StandardKernel();
            this.AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IService>().To<Service>();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }
    } 
}