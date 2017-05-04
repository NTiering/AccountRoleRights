using App.Contracts;
using System;
using Ninject;

namespace App.Mvc
{
    public class NinjectRegisterClient : IRegisterClient
    {
        private IKernel kernel;

        public NinjectRegisterClient(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public void Register(Type @interface, object instance, string named = "")
        {
            kernel
                .Bind(@interface)
                .ToConstant(instance)
                .Named(String.IsNullOrEmpty(named) ? instance.GetType().FullName : named);
        }

        public void Register(Type @interface, Type instance, string named = "")
        {
            kernel
                .Bind(@interface)
                .To(instance).Named(String.IsNullOrEmpty(named) ? instance.GetType().FullName : named);

        }
    }
}