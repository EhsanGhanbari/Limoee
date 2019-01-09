using System;
using System.Configuration;
using System.Security.Claims;
using Limoee.Web.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Owin;
using Owin.Security.Providers.LinkedIn;
using Owin.Security.Providers.Yahoo;

namespace Limoee.Web.UI
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {

            app.CreatePerOwinContext<LimoeeUserManager>(LimoeeUserManager.Create);
            app.CreatePerOwinContext<LimoeeRoleManager>(LimoeeRoleManager.Create);
        
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            // Uncomment the following lines to enable logging in with third party login providers
            //http://social.microsoft.com/Forums/en-US/439bf289-27a2-43b7-b3c0-2450c6852461/mvc-5-owin-yahoo-provider-does-not-return-user-email-address-at-registration?forum=Offtopic
            #region "Microsoft"
            //var microsoftClientId = ConfigurationManager.AppSettings["MicrosoftClientId"];
            //var microsoftClientSecret = ConfigurationManager.AppSettings["MicrosoftClientSecret"];
            //https://account.live.com/developers/applications/create
            //app.UseMicrosoftAccountAuthentication(clientId: microsoftClientId, clientSecret: microsoftClientSecret);
            #endregion

            #region "LinkedIn"
            var linkedInId = ConfigurationManager.AppSettings["LinkedInId"];
            var linkedInSecret = ConfigurationManager.AppSettings["LinkedInSecret"];
            //https://developer.linkedin.com
            app.UseLinkedInAuthentication(clientId: linkedInId, clientSecret: linkedInSecret);
            #endregion

            #region "Facebook"
            var facebookAppId = ConfigurationManager.AppSettings["FacebookAppId"];
            var facebookAppSecret = ConfigurationManager.AppSettings["FacebookAppSecret"];
            var facebookAuthenticationOptions = new FacebookAuthenticationOptions()
            {
                AppId = facebookAppId,
                AppSecret = facebookAppSecret
            };
            facebookAuthenticationOptions.Scope.Add("email");

            app.UseFacebookAuthentication(facebookAuthenticationOptions);
            #endregion

            #region "Twitter"
            //var twitterId = ConfigurationManager.AppSettings["TwitterAppId"];
            //var twitterSecret = ConfigurationManager.AppSettings["TwitterAppSecret"];
            //app.UseTwitterAuthentication(consumerKey: twitterId, consumerSecret: twitterSecret);
            #endregion

            #region "Yahoo"
            //var yahooId = ConfigurationManager.AppSettings["YahooConsumerKey"];
            //var yahooSecret = ConfigurationManager.AppSettings["YahooConsumerSecret"];
            //http://www.beabigrockstar.com/blog/introducing-the-yahoo-linkedin-oauth-security-providers-for-owin/
            //app.UseYahooAuthentication(consumerKey: yahooId, consumerSecret: yahooSecret);
            #endregion

            #region "Google"
            var googleClientId = ConfigurationManager.AppSettings["GoogleClientId"];
            var googleClientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];
            var googleOAuth2AuthenticationOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = googleClientId,
                ClientSecret = googleClientSecret,
                CallbackPath = new PathString("/account/ExternalGoogleLoginCallback")
            };

            app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
            #endregion

            
        }
    }
}