#region

using System;
using System.Data.Common;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

#endregion

namespace TheNuggetList.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

		public NinjectControllerFactory(IKernel kernel)
        {
			_kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            return (IController) _kernel.Get(controllerType);
        }
    }
}