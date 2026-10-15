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

namespace FastAndroidAPI.Controllers
{
    public class OutletController : ApiController
    {
        DatabaseLayer dbLayer = new DatabaseLayer();
        EncryptDecrypt decrypt = new EncryptDecrypt();

        [Route("api/Outlet/GetOutlet")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetOutlet(int DistributorID, int UserID)
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
                DataTable dt = dbLayer.GetCustomer(DistributorID, UserID, decrypt.DecryptValue(connstring));
                List<Outlet> customer = new List<Outlet>();
                customer = Helper.ConvertDataTable<Outlet>(dt);
                return Request.CreateResponse(HttpStatusCode.OK, new { customer });
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

        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetChannel()
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
                DataTable dtChannel = dbLayer.GetChannel(Constants.CustomerChannelType, decrypt.DecryptValue(connstring));

                List<Channel> channel = new List<Channel>();
                channel = Helper.ConvertDataTable<Channel>(dtChannel);

                DataTable dtChannelSub = dbLayer.GetChannel(Constants.CustomerSubChannelType, decrypt.DecryptValue(connstring));

                List<ChannelSub> channelsub = new List<ChannelSub>();
                channelsub = Helper.ConvertDataTable<ChannelSub>(dtChannelSub);

                return Request.CreateResponse(HttpStatusCode.OK, new { channel, channelsub });
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

        [Route("api/Outlet/GetComplaintReason")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetComplaintReason()
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
                DataTable dtReason = dbLayer.GetComplaintReason(Constants.IntNullValue, decrypt.DecryptValue(connstring));

                List<ComplaintReasons> reason = new List<ComplaintReasons>();
                reason = Helper.ConvertDataTable<ComplaintReasons>(dtReason);
                
                return Request.CreateResponse(HttpStatusCode.OK, new { reason });
            }
            catch(Exception ex)
            {
                returnData = new Messages
                {
                    Message = ex.ToString(),
                    Satus = "Exception"
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, returnData, new JsonMediaTypeFormatter());
            }
        }

        [Route("api/Outlet/GetUnOrderReason")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetUnOrderReason()
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
                DataTable dtReason = dbLayer.GetUnOrderStatus(decrypt.DecryptValue(connstring));

                List<UnOrderReasons> reason = new List<UnOrderReasons>();
                reason = Helper.ConvertDataTable<UnOrderReasons>(dtReason);

                return Request.CreateResponse(HttpStatusCode.OK, new { reason });
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

        [Route("api/Outlet/InsertOutlet")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage InsertOutlet(int DistributorID, int UserID,List<Outlet> dtCustomer)
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

                bool flag = dbLayer.InsertCustomerAndroid(DistributorID, UserID, dtCustomer, decrypt.DecryptValue(connstring));

                if (flag)
                {
                    returnData = new Messages
                    {
                        Message = dtCustomer.Count.ToString() + " Row(s) inserted",
                        Satus = "OK"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());
                }
                else
                {
                    returnData = new Messages
                    {
                        Message = "Some error occured",
                        Satus = "Error"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());

                }
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

        [Route("api/Outlet/InsertOutletComplaint")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage InsertOutletComplaint(int DistributorID, int UserID,List<OutletCompalint> dtComplaint)
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
                bool flag = dbLayer.InsertCustomerComplaint(DistributorID, UserID, dtComplaint, decrypt.DecryptValue(connstring));
                if (flag)
                {
                    returnData = new Messages
                    {
                        Message = dtComplaint.Count.ToString() + " Row(s) inserted",
                        Satus = "OK"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());
                }
                else
                {
                    returnData = new Messages
                    {
                        Message = "Some error occured",
                        Satus = "Error"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());
                }
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

        [Route("api/Outlet/InsertOutletStock")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage InsertOutletStock(int DistributorID, long CustomerID, DateTime DocumentDate, int UserID, List<StockPosition> dtStock)
        {
            var req = Request;
            var header = req.Headers;
            Messages returnData = null;
            try
            {
                string connstring = "";
                if (header.Contains("x-conn"))
                {
                    connstring = header.GetValues("x-conn").First();
                }

                bool flag = dbLayer.InsertCustomerStock(DistributorID, CustomerID, DocumentDate, UserID, dtStock, decrypt.DecryptValue(connstring));

                if (flag)
                {
                    returnData = new Messages
                    {
                        Message = dtStock.Count.ToString() + " Row(s) inserted",
                        Satus = "OK"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());
                }
                else
                {
                    returnData = new Messages
                    {
                        Message = "Some error occured",
                        Satus = "Error"
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, returnData, new JsonMediaTypeFormatter());

                }
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