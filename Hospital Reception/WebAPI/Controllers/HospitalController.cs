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
    public class HospitalController : ApiController
    {

        private HospitalManagementService hospitalService = new HospitalManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(hospitalService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ResponseMessage response = new ResponseMessage();
            if (!(hospitalService.GetById(id).Validate())){
                response.Code = 500;
                response.Body = $"Hospital with ID:{id} is not found.";
                return Json(response);
            }
            return Json(hospitalService.GetById(id));
        }

        [HttpPut]
        public IHttpActionResult Update(HospitalDTO hospitalDto)
        {
            ResponseMessage response = new ResponseMessage();

            if (hospitalService.Update(hospitalDto))
            {
                response.Code = 200;
                response.Body = "Hospital is updated.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Hospital is not updated.";
            }

            return Json(response);
        }


        [HttpPost]
        public IHttpActionResult Save(HospitalDTO hospitalDto)
        {
            if (!hospitalDto.Validate())
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });
            ResponseMessage response = new ResponseMessage();

            if (hospitalService.Save(hospitalDto))
            {
                response.Code = 200;
                response.Body = "Hospital is saved.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Hospital is not saved.";
            }

            return Json(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (hospitalService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Hospital is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Hospital is not deleted.";
            }

            return Json(response);
        }

    }
}
