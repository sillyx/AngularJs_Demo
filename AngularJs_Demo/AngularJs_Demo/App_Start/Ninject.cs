using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using BLL;

namespace AngularJs_Demo
{
    public class Ninject
    {
        public static IKernel kernel;
        static Ninject()
        {
            kernel = new StandardKernel();
        }
        public static void SetupCore()
        {
            kernel.Bind<IService>().To<Service>();
        }

    }
}