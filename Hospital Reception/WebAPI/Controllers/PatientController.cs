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
    public class PatientController : ApiController
    {
        private PatientManagementService patientService = new PatientManagementService();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(patientService.Get());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(patientService.GetById(id));
        }

        [HttpPut]
        public IHttpActionResult Update(PatientDTO patientDTO)
        {
            ResponseMessage response = new ResponseMessage();

            if (patientService.Update(patientDTO))
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
        public IHttpActionResult Save(PatientDTO patientDTO)
        {
            if (!patientDTO.Validate())
                return Json(new ResponseMessage { Code = 500, Error = "Data is not valid!" });
            ResponseMessage response = new ResponseMessage();

            if (patientService.Save(patientDTO))
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

            if (patientService.Delete(id))
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
