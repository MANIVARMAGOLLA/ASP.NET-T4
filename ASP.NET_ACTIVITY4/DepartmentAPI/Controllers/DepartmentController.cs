using DepartmentBL;
using DepartmentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DepartmentAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpPost]
       public HttpResponseMessage AddNewDepartment(departmentDTO newObj)
        {
            try
            {
                if (newObj != null)
                {
                    departmentBL blobj = new departmentBL();
                    int result = blobj.AddNewDepartment(newObj);
                    if (result == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Department added sucessfull");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, "Department  not added ");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "check all your inputs ");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
