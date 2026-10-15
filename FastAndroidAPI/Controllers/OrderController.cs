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
    public class OrderController : ApiController
    {
        DatabaseLayer dbLayer = new DatabaseLayer();
        EncryptDecrypt decrypt = new EncryptDecrypt();
        
        [Route("api/Order/InsertOrder")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage InsertOrder(int DistributorID, long OutletID, int TownID, int SectionID, int UserID, decimal GrossAmount, decimal ExtraDiscount, decimal StandardDiscount, decimal TotalGST, decimal NetAmount, DateTime DocumentDate
            , string Comments, DateTime TimeIn, DateTime TimeOut, decimal SchemeAmount, decimal TstAmount, decimal SedAmount, decimal ExtraTax, decimal StandardDiscountByValue, decimal StandardDiscountPerValue, decimal SedDiscountByValue
            , decimal SedDiscountPerValue, decimal StandardDiscountByValueTo, decimal StandardDiscountByValueAd, decimal StandardDiscountPerValueTo, decimal StandardDiscountPerValueAd, decimal SedAmountByValueTo, decimal SedAmountByValueAd, decimal SedAmountPerValueTo, decimal SedAmountPerValueAd,decimal Latitude,decimal Longitude,string PhotoPath1,string PhotoPath2,string PhotoPath3,string PhotoPath4,string PhotoPath5,int OrderPaymentType, OrderModal dtOrderDetail)
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
                int OrderType = Constants.Cash_Order_Id;                
                if(OrderPaymentType == 0)
                {
                    OrderType = Constants.Cash_Order_Id;
                }
                else if (OrderPaymentType ==1)
                {
                    OrderType = Constants.Credit_Order_Id;
                }
                                
                bool flag = dbLayer.Add_OrderAndroid(DistributorID, null, TownID, SectionID, 1, OutletID, OutletID, UserID, 0, OrderType,
            GrossAmount, ExtraDiscount, StandardDiscount, TotalGST, NetAmount, SchemeAmount, Constants.Order_Pending_Id, dtOrderDetail, UserID, DocumentDate, SedAmount, TstAmount, Comments, ExtraTax, StandardDiscountByValue
            , StandardDiscountPerValue, SedDiscountByValue, SedDiscountPerValue, StandardDiscountByValueTo, StandardDiscountByValueAd, StandardDiscountPerValueTo, StandardDiscountPerValueAd, SedAmountByValueTo, SedAmountByValueAd
            , SedAmountPerValueTo, SedAmountPerValueAd, DocumentDate,TimeIn,TimeOut, Latitude, Longitude,PhotoPath1,PhotoPath2,PhotoPath3,PhotoPath4,PhotoPath5, decrypt.DecryptValue(connstring));


                if (flag)
                {
                    returnData = new Messages
                    {
                        Message = "Order Inserted.",
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

        [Route("api/Order/InsertNoOrder")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage InsertNoOrder(int DistributorID, int UserID, OutletUnOrder dtUnOrder)
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
                bool flag = dbLayer.InsertOutletOrderStatus(DistributorID, 1, UserID, UserID, dtUnOrder, decrypt.DecryptValue(connstring));

                if (flag)
                {
                    returnData = new Messages
                    {
                        Message = "1 Row inserted",
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