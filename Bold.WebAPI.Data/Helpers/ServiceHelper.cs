using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Data.Helpers
{
    internal static class ServiceHelper
    {
        public static IServer GetIServerServiceWrapper()
        {
            return new ServiceWrapper<IServer>(Constants.Configuration.ConfigName).Channel;
        }
    }
}
