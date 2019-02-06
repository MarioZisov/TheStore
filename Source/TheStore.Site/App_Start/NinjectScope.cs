namespace TheStore.Site.App_Start
{
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    public class NinjectScope : IDependencyScope
    {
        private IResolutionRoot resolutionRoot;

        public NinjectScope(IResolutionRoot kernel)
        {
            this.resolutionRoot = kernel;
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)this.resolutionRoot;
            if (disposable != null) disposable.Dispose();
            this.resolutionRoot = null;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.resolutionRoot.Resolve(request).ToList();
        }
    }
}