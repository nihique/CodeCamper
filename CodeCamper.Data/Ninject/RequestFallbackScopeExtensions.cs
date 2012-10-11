using System.Diagnostics;
using Ninject.Syntax;
using Ninject.Web.Common;

namespace CodeCamper.Data.Ninject
{
    public static class RequestFallbackScopeExtensions
    {
        public static IBindingNamedWithOrOnSyntax<T> InRequestFallbackScope<T>(this IBindingWhenInNamedWithOrOnSyntax<T> binding)
        {
            // try to set InRequestScope
            var defaultScopeCallback = binding.Kernel.Settings.DefaultScopeCallback;
            var inRequestScope = binding.InRequestScope();
            var newScopeCallback = binding.BindingConfiguration.ScopeCallback;

            // if scope callback returned to default callback, then we cannot use InRequestScope => fallback to InThreadScope
            if (newScopeCallback == defaultScopeCallback)
            {
                Debug.WriteLine("InThreadScope");
                return binding.InThreadScope();
            }

            Debug.WriteLine("InRequestScope");
            return inRequestScope;
        }
    }
}