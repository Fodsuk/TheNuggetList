#region

using Ninject;

#endregion

namespace TheNuggetList.Domain.Services
{
    public class NinjectServiceLocator : IServiceLocator
    {
        private readonly IKernel _kernel;

        public NinjectServiceLocator(IKernel kernel)
        {
            _kernel = kernel;
        }

        #region IServiceLocator Members

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }

        #endregion
    }
}