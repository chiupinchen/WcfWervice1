using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //EditClicked += (s, e) => { s.GetType(); };

            //EditClicked(this, new EventArgs());

            //MyDelegate p = (s,e)=>{s.GetType(); return 1;};

            //p(null,null);
        }

        
        //void MvcApplication_EditClicked(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //event EventHandler EditClicked;

        //public delegate int MyDelegate(object sender, EventArgs e);

    }
}
