using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Messages;

namespace WebAPI.Controllers
{
    public class DoctorController : ApiController
    {

        private DoctorManagementService doctorService = new DoctorManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(doctorService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id) 
        {
            ResponseMessage response = new ResponseMessage();
            if (!(doctorService.GetById(id).Validate()))
            {
                response.Code = 500;
                response.Body = $"Doctor with ID:{id} is not found.";
                return Json(response);
            }
            return Json(doctorService.GetById(id));
        }


        [HttpPut]
        public IHttpActionResult Update(DoctorDTO doctorDTO)
        {
            ResponseMessage response = new ResponseMessage();

            if (doctorService.Update(doctorDTO))
            {
                response.Code = 200;
                response.Body = "Doctor is updated.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Doctor is not updated.";
            }

            return Json(response);
        }


        [HttpPost]
        public IHttpActionResult Save(DoctorDTO doctorDTO)
        {
            if (!doctorDTO.Validate())
            {
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });
            }

            ResponseMessage response = new ResponseMessage();

            if (doctorService.Save(doctorDTO))
            {

                response.Code = 200;
                response.Body = "Doctor is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Doctor is not saved.";
            }

            return Json(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (doctorService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Doctor is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Doctor is not deleted.";
            }

            return Json(response);
        }

    }
}
