using MVC.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly Uri _url = new Uri("https://localhost:44392/api/patient");

        // GET: Patient
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //make the request
                HttpResponseMessage response = await client.GetAsync("");

                //parse the response and return data
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData =
                    JsonConvert.DeserializeObject<List<PatientVM>>(jsonString);
                return View(responseData);

            }
        }
    }
}