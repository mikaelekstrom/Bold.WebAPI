using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Commons.Helpers
{
    public static class ServiceHelper
    {
        public static IServer GetIServerServiceWrapper()
        {
            return new ServiceWrapper<IServer>(Constants.Constants.Configuration.ConfigName, 
                SecurityMode.None,
                WSMessageEncoding.Text, SetClientCredentials())
                .Channel;
        }

        private static ClientCredentials SetClientCredentials()
        {
            try
            {
                var userName = ConfigurationManager.AppSettings[Constants.Constants.Configuration.Username];
                var password = ConfigurationManager.AppSettings[Constants.Constants.Configuration.Password];

                return new ClientCredentials
                {
                    UserName = { UserName = userName, Password = password},
                };
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
