using System.Web;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace CodeCamper.Data.Ninject
{
    public static class RequestOrThreadScopeExtensions
    {
        public static IBindingNamedWithOrOnSyntax<T> InRequestOrThreadScope<T>(this IBindingWhenInNamedWithOrOnSyntax<T> binding)
        {
            return HttpRuntime.AppDomainAppId != null ? binding.InRequestScope() : binding.InThreadScope();
        }
    }
}