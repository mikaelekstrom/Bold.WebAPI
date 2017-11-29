using System;
using System.Web.Http;
using Bold.WebAPI.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Bold.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureOAuth(app);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}