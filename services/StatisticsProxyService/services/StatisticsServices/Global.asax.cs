using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Ninject.Extensions.Wcf;
using Ninject;
using RestService.DI;

namespace RestService
{
    public class Global : NinjectWcfApplication
    {
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new WCFNinjectModule());
        }
    }
}