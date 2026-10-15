using System.Web.Http;
using FastAndroidAPI.Models;
using System.Data;
using CORNAttendanceApi.Models;
using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;

namespace FastAndroidAPI.Controllers
{
    public class MultiTenantController : ApiController
    {
        DatabaseLayer dbLayer = new DatabaseLayer();

        [HttpGet]
        public HttpResponseMessage GetClientInfo(string Pin)
        {
            var req = Request;
            var headers = req.Headers;
            MultiTenant returnData = null;
            Messages returnmsg = null;
            try
            {
                DataTable dtConn = dbLayer.GetClientConnection(Pin);
                if (dtConn.Rows.Count > 0)
                {
                    returnData = new MultiTenant
                    {
                        ClientID = Convert.ToInt32(dtConn.Rows[0]["clientID"]),
                        ClientConnString = dtConn.Rows[0]["clientConnString"].ToString(),
                        BackGroundImage = dtConn.Rows[0]["ImagePath1"].ToString(),
                        Logo = dtConn.Rows[0]["ImagePath2"].ToString()
                    };
                }
                else
                {
                    returnData = new MultiTenant
                    {
                        ClientID = 0,
                        ClientConnString = "Pin not verfied",
                        BackGroundImage = "",
                        Logo = ""
                    };
                }
                return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());
            }
            catch (Exception ex)
            {
                returnmsg = new Messages
                {
                    Message = ex.ToString(),
                    Satus = "Exception"
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, returnmsg, new JsonMediaTypeFormatter());
            }
        }        
    }
}