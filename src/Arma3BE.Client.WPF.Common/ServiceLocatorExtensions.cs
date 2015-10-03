using System;
using Microsoft.Practices.ServiceLocation;

namespace Arma3BE.Client.WPF.Common
{
    public static class ServiceLocatorExtensions
    {
        public static object TryResolve(this IServiceLocator locator, Type type)
        {
            try
            {
                return locator.GetInstance(type);
            }
            catch (ActivationException)
            {
                return null;
            }
        }

        public static T TryResolve<T>(this IServiceLocator locator) where T : class
        {
            return locator.TryResolve(typeof (T)) as T;
        }
    }
}