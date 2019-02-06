using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace TheStore.Site.App_Start
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectResolver(IKernel kernel)
            :base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(this.kernel.BeginBlock());
        }
    }
}