using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FastAndroidAPI.Models;
using System.Data;
using System;
using CORNAttendanceApi.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.Script.Serialization;

namespace FastAndroidAPI.Controllers
{
    public class ExecuteSPController : ApiController
    {
        DatabaseLayer dbLayer = new DatabaseLayer();
        EncryptDecrypt decrypt = new EncryptDecrypt();

        [Route("api/ExecuteSP/Get")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage Get(SpData data)
        {
            Messages returnData = null;
            var req = Request;
            var header = req.Headers;
            string connstring = "";
            try
            {
                if (header.Contains("x-conn"))
                {
                    connstring = header.GetValues("x-conn").First();
                }
                DataTable DataReturned = dbLayer.ExecGetStoreProcedure(data, decrypt.DecryptValue(connstring));
                return Request.CreateResponse(HttpStatusCode.OK, new { DataReturned });
            }
            catch (Exception ex)
            {
                returnData = new Messages
                {
                    Message = ex.ToString(),
                    Satus = "Exception"
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, returnData, new JsonMediaTypeFormatter());
            }
        }

        [Route("api/ExecuteSP/Test")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage Test(int intg, OrderModal OrderDetail)
        {
            Messages returnData = null;
            var req = Request;
            var header = req.Headers;
            string connstring = "";
            try
            {
                if (header.Contains("x-conn"))
                {
                    connstring = header.GetValues("x-conn").First();
                }
                bool flag = true;// dbLayer.ExecInsertStoreProcedure(data, decrypt.DecryptValue(connstring));
                return Request.CreateResponse(HttpStatusCode.OK, new { returnData });
            }
            catch (Exception ex)
            {
                returnData = new Messages
                {
                    Message = ex.ToString(),
                    Satus = "Exception"
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, returnData, new JsonMediaTypeFormatter());
            }
        }
    }
}