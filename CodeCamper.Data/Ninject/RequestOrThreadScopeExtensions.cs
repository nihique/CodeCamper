using System.Diagnostics;
using System.Web;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace CodeCamper.Data.Ninject
{
    public static class RequestOrThreadScopeExtensions
    {
        public static IBindingNamedWithOrOnSyntax<T> InRequestOrThreadScope<T>(this IBindingWhenInNamedWithOrOnSyntax<T> binding)
        {
            if (HttpRuntime.AppDomainAppId != null)
            {
                // is web app
                Debug.WriteLine("InRequestScope");
                return binding.InRequestScope();
            }

            // is windows app
            Debug.WriteLine("InThreadScope");
            return binding.InThreadScope();
        }
    }
}