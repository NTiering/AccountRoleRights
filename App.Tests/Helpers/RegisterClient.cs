using System;
using App.Contracts;
using Ninject;

namespace App.Tests.Helpers
{
    class RegisterClient : IRegisterClient
    {
        private IKernel kernel = new StandardKernel();

        public void Register(Type @interface, object instance, string named = "")
        {
            kernel.Bind(@interface).ToConstant(instance).Named(String.IsNullOrWhiteSpace(named) ? instance.GetType().FullName : named);
        }

        public void Register(Type @interface, Type instance, string named = "")
        {
            kernel.Bind(@interface).To(instance).Named(String.IsNullOrWhiteSpace(named) ? instance.GetType().FullName : named);
        }

        public T Get<T>()
        {
            return kernel.Get<T>();
        }
    }

}