using System.Web.Http;
using System.Web.Mvc;

namespace MaritimeDojo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Init();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
