using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace WebApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

                
            );
            config.Services.Replace(typeof(ITraceWriter), new SimpleTracer());

        }
    }

    public class SimpleTracer: ITraceWriter
    {

        public void Trace(System.Net.Http.HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }

        protected void WriteTrace(TraceRecord rec)
        {
            var message = string.Format("{0};{1};{2}",
                rec.Operator, rec.Operation, rec.Message);
            System.Diagnostics.Trace.WriteLine(message, rec.Category);
        }
        
    }
}
