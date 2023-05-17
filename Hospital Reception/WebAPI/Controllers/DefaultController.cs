using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: Default
        [HttpGet]
        public IHttpActionResult Version()
        {
            return Json("API Version 1.0");
        }
    }
}
