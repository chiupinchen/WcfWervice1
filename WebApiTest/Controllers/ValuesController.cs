using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;


namespace WebApiTest.Controllers
{

    public class MyActionFilterAttribute : ActionFilterAttribute 
    {

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            
            base.OnActionExecuting(actionContext);
        }
    
    }

    [MyActionFilter]
    public class ValuesController : ApiController
    {

        public class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

        }

        private IList<Employee> list = new List<Employee>(){
            new Employee()
        {
        Id = 12345, FirstName = "John", LastName = "Human"
        },
        new Employee()
        {
        Id = 12346, FirstName = "Jane", LastName = "Public"
        },
        new Employee()
        {
        Id = 12347, FirstName = "Joseph", LastName = "Law"
        }
        };

       
        public HttpResponseMessage Get()
        {
            //Configuration.Services.GetTraceWriter().Info(Request, "category1", "message1");

            IEnumerable<string> myHeaderValues;
            Request.Headers.TryGetValues("myHeaderValues", out myHeaderValues);


            var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, list.First());

            string uri = Url.Link("DefaultApi", new { id = list.First().Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }
        

        //public HttpResponseMessage Get()
        //{

        //    var t = Request.CreateResponse<IEnumerable<Employee>>(HttpStatusCode.PaymentRequired, list, new XmlMediaTypeFormatter());

        //    return t;

        //}


        //// GET api/values
        //public HttpResponseMessage Get()
        //{

        //    //return new string[] { "value1", "value2" };

        //    var response = new HttpResponseMessage()
        //    {
        //        StatusCode = (HttpStatusCode)422, // Unprocessable Entity
        //        ReasonPhrase = "Invalid Department"
        //    };



        //    return response;

        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
