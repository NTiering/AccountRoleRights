using Ninject;
using System.Web.Http.Dependencies;

namespace App.Api.IoC
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernel)
        : base(kernel)
        {
            this.kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel.BeginBlock());
        }
    }
}