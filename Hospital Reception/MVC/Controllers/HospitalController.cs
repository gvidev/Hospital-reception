using ApplicationService.DTOs;
using MVC.ViewModels;
using MVC.ViewModels.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HospitalController : Controller
    {

        private readonly Uri _url = new Uri("https://localhost:44392/api/hospital");

        // GET: Hospital
        public async Task<ActionResult> Index(IndexVM model)
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
                    JsonConvert.DeserializeObject<List<HospitalVM>>(jsonString);



                model.Pager = model.Pager ?? new PagerVM();

                model.Pager.Page = model.Pager.Page <= 0
                                            ? 1
                                            : model.Pager.Page;

                model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                                            ? 12
                                            : model.Pager.ItemsPerPage;


                model.Filter = model.Filter ?? new FilterVM();


                model.Pager.PagesCount = (int)Math.Ceiling(responseData.Where(u =>
                string.IsNullOrEmpty(model.Filter.HospitalName) || u.HospitalName.Contains(model.Filter.HospitalName)).Count() / (double)model.Pager.ItemsPerPage);


                model.Items =responseData
                                        .OrderBy(i => i.Id)
                                        .Where(u =>
                                               string.IsNullOrEmpty(model.Filter.HospitalName) || u.HospitalName.Contains(model.Filter.HospitalName))
                                        .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                                        .Take(model.Pager.ItemsPerPage)
                                        .ToList();

                return View(model);

            }
        }

        public async Task<ActionResult> Details(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = _url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.GetAsync("hospital/" + id);

                // parse the response and return data
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<HospitalVM>(jsonString);
                return View(responseData);
            }
        }

        // api/hospital/create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(HospitalVM hospitalVM)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = _url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(hospitalVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("", byteContent);

                    // for testing purposes
                    // string jsonString = await response.Content.ReadAsStringAsync();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // api/hospital/edit/id
        public async Task<ActionResult> Edit(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = _url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.GetAsync("hospital/" + id);

                // parse the response and return data
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<HospitalVM>(jsonString);
                return View(responseData);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(HospitalVM hospitalVM)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = _url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(hospitalVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.PutAsync("", byteContent);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // api/hospital/id
        public async Task<ActionResult> Delete(int id)
        {
            // string accessToken = await GetAccessToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = _url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.DeleteAsync("hospital/" + id);

                return RedirectToAction("Index");
            }
        }
    }
}