using System;
using System.Data;
using System.Data.SqlClient;
using FastAndroidAPI.Models;
using System.Collections.Generic;

namespace CORNAttendanceApi.Models
{
    public class DatabaseLayer
    {
        public DataTable GetClientConnection(string ClientPIN)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["myConnectionString"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UspGetClientConnection";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ClientPIN", ClientPIN);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetAndoridUser(string LoginID, string Password, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetUSERSAndroid";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@LOGIN_ID", LoginID);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetArea(int p_Distributor_Id, int p_SaleForce_Id, int p_Area_Id, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetSaleForceArea";
                cmd.Connection = con;
                if (p_Distributor_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_Id);
                }
                if (p_SaleForce_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@SALEFORCE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SALEFORCE_ID", p_SaleForce_Id);
                }
                if (p_Area_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@AREA_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AREA_ID", p_Area_Id);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetRoute(int p_DISTRIBUTOR_ID, int p_USER_ID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetAssignedDISTRIBUTOR_ROUTE";
                cmd.Connection = con;
                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@USER_ID", p_USER_ID);
                }
                if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_DISTRIBUTOR_ID);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetCustomer(int p_DISTRIBUTOR_ID, int p_USER_ID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetSaleForceCustomerSync";
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@SALEFORCE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SALEFORCE_ID", p_USER_ID);
                }
                if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_DISTRIBUTOR_ID);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetChannel(int p_ParentID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectCODESAndroid";
                cmd.Connection = con;
                if (p_ParentID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@PARENT_REF_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PARENT_REF_ID", p_ParentID);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable GetSKUHierarchy(int p_Sku_Type_Id, int p_Sku_Hie_Id, int p_Parent_Sku_Hie_Id, int Companyid, int p_USER_ID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectSKU_HIERARCHYAssigned";
                cmd.Connection = con;
                if (p_Sku_Hie_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@SKU_HIE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SKU_HIE_ID", p_Sku_Hie_Id);
                }
                if (Companyid == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@COMPANY_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COMPANY_ID", Companyid);
                }
                if (p_Parent_Sku_Hie_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@PARENT_SKU_HIE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PARENT_SKU_HIE_ID", p_Parent_Sku_Hie_Id);
                }
                if (p_Sku_Type_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@SKU_HIE_TYPE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SKU_HIE_TYPE_ID", p_Sku_Type_Id);
                }
                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@USER_ID", p_USER_ID);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetSKU(int p_Distributor_ID, int p_Principal_Id, int p_User_Id, DateTime p_ClosedDate, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetSKUAndroid";
                cmd.Connection = con;
                if (p_User_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@USER_ID", p_User_Id);
                }
                if (p_Distributor_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_ID);
                }
                if (p_Principal_Id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@PRINCIPAL_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PRINCIPAL_ID", p_Principal_Id);
                }
                if (p_ClosedDate == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@DAYCLOSED", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DAYCLOSED", p_ClosedDate);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetSKUGroup(string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectSKU_Groups";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Dist_ID", DBNull.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetPromotion(int p_DISTRIBUTOR_ID, DateTime pDate, int p_TypeID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetPromotionAndroid";
                cmd.Connection = con;
                if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_DISTRIBUTOR_ID);
                }
                if (p_TypeID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@TypeID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TypeID", p_TypeID);
                }
                if (pDate == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@DATE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DATE", pDate);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetUnOrderStatus(string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetUnOrderStatus";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetAndoridMenu(int p_UserID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetAndroidMenu";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@USER_ID", p_UserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetComplaintReason(int p_DistributorID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetComplaintReasonAndroid";
                cmd.Connection = con;
                if (p_DistributorID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DistributorID", p_DistributorID);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        
        public DataTable GetImagePath(string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspGetImagePath";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable InsertOrderBookerStartDay(int p_DISTRIBUTOR_ID, int p_USER_ID, string ConnectionString)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmdDetail = new SqlCommand();
                cmdDetail.CommandType = CommandType.StoredProcedure;
                cmdDetail.CommandText = "uspInsertAndroidOBDailyProcess";
                cmdDetail.Connection = con;

                if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@DistributorID", p_DISTRIBUTOR_ID);
                }

                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@OrderBookerID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@OrderBookerID", p_USER_ID);
                }

                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@CreatedBy", p_USER_ID);
                }

                cmdDetail.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmdDetail);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertOrderBookerEndDay(int p_DISTRIBUTOR_ID, int p_USER_ID,DateTime p_StartDayDateTime, string ConnectionString)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();

                SqlCommand cmdDetail = new SqlCommand();
                cmdDetail.CommandType = CommandType.StoredProcedure;
                cmdDetail.CommandText = "uspUpdateAndroidOBDailyProcess";
                cmdDetail.Connection = con;

                if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@DistributorID", p_DISTRIBUTOR_ID);
                }

                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@OrderBookerID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@OrderBookerID", p_USER_ID);
                }

                if (p_StartDayDateTime == Constants.DateNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@StartDayDateTime", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@StartDayDateTime", p_StartDayDateTime);
                }

                if (p_USER_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@CreatedBy", p_USER_ID);
                }

                cmdDetail.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable ExecGetStoreProcedure(SpData data, string ConnectionString)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = data.SpName;
                cmd.Connection = con;
                if (data.Parameters.Count > 0)
                {
                    foreach (var item in data.Parameters)
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public bool Add_OrderAndroid(int p_Distributor_id, string p_MANUAL_ORDER_ID, int p_TOWN_ID, long p_AREA_ID, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, int p_OrderTypeId,
 decimal p_TOTAL_AMOUNT, decimal p_EXTRA_DISCOUNT_AMOUNT, decimal p_STANDARD_DISCOUNT_AMOUNT, decimal p_GST_AMOUNT, decimal p_TOTAL_NET_AMOUNT, decimal p_SCHEME_AMOUNT, int p_STATUS_ID, OrderModal dtOrderDetail,int p_UserId, DateTime p_Document_Date, decimal p_SEDAmount, decimal p_TSTAmount, string p_REMARKS, decimal p_Extra_Tax, decimal p_Standard_discount_by_VAlue, decimal p_Standard_dis_Per_Value, decimal p_SED_By_value, decimal p_SEd_Per_Value
    , decimal p_Standard_discount_by_Value_TO, decimal p_Standard_discount_by_Value_AD, decimal p_Standard_dis_Per_Value_TO, decimal p_Standard_dis_Per_Value_AD, decimal p_SED_By_Value_TO, decimal p_SED_By_Value_AD, decimal p_SEd_Per_Value_TO, decimal p_SEd_Per_Value_AD, DateTime p_Punching_Date,DateTime p_TimeIn,DateTime p_TimeOut, decimal p_Latitude, decimal p_Longitude, string p_PhotoPath1, string p_PhotoPath2, string p_PhotoPath3, string p_PhotoPath4, string p_PhotoPath5, string ConnectionString)
        {
            long m_SALE_ORDER_ID = 0;
            long m_SALE_ORDER_DETAIL_ID = 0;
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();
                objTrans = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = objTrans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertSALE_ORDER_MASTERAndroid";
                cmd.Connection = con;
                if (p_Distributor_id == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_id);
                }
                if (p_TOWN_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@TOWN_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TOWN_ID", p_TOWN_ID);
                }

                if (p_PRINCIPAL_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@PRINCIPAL_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PRINCIPAL_ID", p_PRINCIPAL_ID);
                }

                if (p_ORDERBOOKER_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@ORDERBOOKER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ORDERBOOKER_ID", p_ORDERBOOKER_ID);
                }

                if (p_DELIVERYMAN_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@DELIVERYMAN_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DELIVERYMAN_ID", p_DELIVERYMAN_ID);
                }

                if (p_STATUS_ID == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@STATUS_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STATUS_ID", p_STATUS_ID);
                }

                cmd.Parameters.AddWithValue("@LEGEND_ID", DBNull.Value);

                if (p_OrderTypeId == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@ORDER_TYPE_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ORDER_TYPE_ID", p_OrderTypeId);
                }

                if (p_UserId == Constants.IntNullValue)
                {
                    cmd.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@USER_ID", p_UserId);
                }

                if (p_TOTAL_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@TOTAL_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TOTAL_AMOUNT", p_TOTAL_AMOUNT);
                }

                if (p_EXTRA_DISCOUNT_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@EXTRA_DISCOUNT_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EXTRA_DISCOUNT_AMOUNT", p_EXTRA_DISCOUNT_AMOUNT);
                }

                if (p_STANDARD_DISCOUNT_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_AMOUNT", p_STANDARD_DISCOUNT_AMOUNT);
                }

                if (p_GST_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@GST_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@GST_AMOUNT", p_GST_AMOUNT);
                }

                if (p_TOTAL_NET_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@TOTAL_NET_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TOTAL_NET_AMOUNT", p_TOTAL_NET_AMOUNT);
                }

                if (p_SCHEME_AMOUNT == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SCHEME_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SCHEME_AMOUNT", p_SCHEME_AMOUNT);
                }

                if (p_SEd_Per_Value == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE", p_SEd_Per_Value);
                }

                if (p_TSTAmount == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@TST_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TST_AMOUNT", p_TSTAmount);
                }

                if (p_SEDAmount == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT", p_SEDAmount);
                }

                if (p_Extra_Tax == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@EXTRA_TAX", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@EXTRA_TAX", p_Extra_Tax);
                }

                if (p_Standard_discount_by_VAlue == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE", p_Standard_discount_by_VAlue);
                }

                if (p_Standard_dis_Per_Value == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE", p_Standard_dis_Per_Value);
                }

                if (p_SED_By_value == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE", p_SED_By_value);
                }

                if (p_Document_Date == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@DOCUMENT_DATE", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOCUMENT_DATE", p_Document_Date);
                }

                if (p_Punching_Date == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@TIME_STAMP", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TIME_STAMP", p_Punching_Date);
                }

                cmd.Parameters.AddWithValue("@LASTUPDATE_DATE", DateTime.Now);

                if (p_AREA_ID == Constants.LongNullValue)
                {
                    cmd.Parameters.AddWithValue("@AREA_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@AREA_ID", p_AREA_ID);
                }

                if (p_SOLD_TO == Constants.LongNullValue)
                {
                    cmd.Parameters.AddWithValue("@SOLD_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SOLD_TO", p_SOLD_TO);
                }

                if (p_SHIP_TO == Constants.LongNullValue)
                {
                    cmd.Parameters.AddWithValue("@SHIP_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SHIP_TO", p_SHIP_TO);
                }
                if (p_MANUAL_ORDER_ID == null)
                {
                    cmd.Parameters.AddWithValue("@MANUAL_ORDER_ID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MANUAL_ORDER_ID", p_MANUAL_ORDER_ID);
                }

                if (p_REMARKS == null)
                {
                    cmd.Parameters.AddWithValue("@REMARKS", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@REMARKS", p_REMARKS);
                }

                if (p_SED_By_Value_TO == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_TO", p_SED_By_Value_TO);
                }

                if (p_SED_By_Value_AD == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_AD", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_AD", p_SED_By_Value_AD);
                }

                if (p_SEd_Per_Value_TO == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_TO", p_SEd_Per_Value_TO);
                }

                if (p_SEd_Per_Value_AD == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_AD", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_AD", p_SEd_Per_Value_AD);
                }

                if (p_Standard_discount_by_Value_TO == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_TO", p_Standard_discount_by_Value_TO);
                }

                if (p_Standard_discount_by_Value_AD == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_AD", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_AD", p_Standard_discount_by_Value_AD);
                }

                if (p_Standard_dis_Per_Value_TO == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_TO", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_TO", p_Standard_dis_Per_Value_TO);
                }

                if (p_Standard_dis_Per_Value_AD == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_AD", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_AD", p_Standard_dis_Per_Value_AD);
                }

                if (p_TimeIn == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@TIME_IN", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TIME_IN", p_TimeIn);
                }

                if (p_TimeOut == Constants.DateNullValue)
                {
                    cmd.Parameters.AddWithValue("@TIME_OUT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TIME_OUT", p_TimeOut);
                }

                if (p_Latitude == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@Latitude", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Latitude", p_Latitude);
                }

                if (p_Longitude == Constants.DecimalNullValue)
                {
                    cmd.Parameters.AddWithValue("@Longitude", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Longitude", p_Longitude);
                }

                if (p_PhotoPath1 == null)
                {
                    cmd.Parameters.AddWithValue("@PhotoPath1", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhotoPath1", p_PhotoPath1);
                }

                if (p_PhotoPath2 == null)
                {
                    cmd.Parameters.AddWithValue("@PhotoPath2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhotoPath2", p_PhotoPath2);
                }

                if (p_PhotoPath3 == null)
                {
                    cmd.Parameters.AddWithValue("@PhotoPath3", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhotoPath3", p_PhotoPath3);
                }

                if (p_PhotoPath4 == null)
                {
                    cmd.Parameters.AddWithValue("@PhotoPath4", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhotoPath4", p_PhotoPath4);
                }

                if (p_PhotoPath5 == null)
                {
                    cmd.Parameters.AddWithValue("@PhotoPath5", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PhotoPath5", p_PhotoPath5);
                }

                SqlParameter parm = new SqlParameter("@SALE_ORDER_ID", SqlDbType.BigInt);
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);


                cmd.ExecuteNonQuery();
                m_SALE_ORDER_ID = (long)((IDataParameter)(cmd.Parameters["@SALE_ORDER_ID"])).Value;

                if (m_SALE_ORDER_ID > 0)
                {
                    foreach (var dr in dtOrderDetail.OrderDetail)
                    {
                        SqlCommand cmdDetail = new SqlCommand();
                        cmdDetail.Transaction = objTrans;
                        cmdDetail.CommandType = CommandType.StoredProcedure;
                        cmdDetail.CommandText = "spInsertSALE_ORDER_DETAIL";
                        cmdDetail.Connection = con;
                        if (p_Distributor_id == Constants.IntNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_id);
                        }
                        if (dr.SKUID == Constants.IntNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SKU_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SKU_ID", dr.SKUID);
                        }

                        if (dr.Quantity == Constants.IntNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@QUANTITY_UNIT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@QUANTITY_UNIT", dr.Quantity);
                        }

                        if (dr.Price == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@UNIT_PRICE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@UNIT_PRICE", dr.Price);
                        }

                        if (dr.GSTRate == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_RATE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_RATE", dr.GSTRate);
                        }

                        SqlParameter parmDetail = new SqlParameter("@SALE_ORDER_DETAIL_ID", SqlDbType.BigInt);
                        parmDetail.Direction = ParameterDirection.Output;
                        cmdDetail.Parameters.Add(parmDetail);
                        if (dr.Amount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@AMOUNT", dr.Amount);
                        }

                        if (dr.StandardDiscount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT", dr.StandardDiscount);
                        }

                        if (dr.ExtraDiscount  == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@EXTRA_DISCOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@EXTRA_DISCOUNT", dr.ExtraDiscount);
                        }

                        if (dr.GSTAmount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_AMOUNT", dr.GSTAmount);
                        }

                        if (dr.NetAmount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@NET_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@NET_AMOUNT", dr.NetAmount);
                        }

                        if (dr.TSTAmount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@TST_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@TST_AMOUNT", dr.TSTAmount);
                        }

                        if (dr.SedAmount == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT", dr.SedAmount);
                        }

                        cmdDetail.Parameters.AddWithValue("@TIME_STAMP", p_Document_Date);

                        cmdDetail.Parameters.AddWithValue("@IS_DELETED", false);

                        cmdDetail.Parameters.AddWithValue("@SALE_ORDER_ID", m_SALE_ORDER_ID);


                        cmdDetail.Parameters.AddWithValue("@BATCH_NO", "T");

                        if (dr.Unit_In_Case == Constants.IntNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@UNITS_IN_CASE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@UNITS_IN_CASE", dr.Unit_In_Case);
                        }

                        if (dr.ExtraTax == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@EXTRA_TAX", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@EXTRA_TAX", dr.ExtraTax);
                        }

                        if (dr.GSTPrice == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_PRICE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@GST_PRICE", dr.GSTPrice);
                        }

                        if (dr.StandardDiscountByValue == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE", dr.StandardDiscountByValue);
                        }

                        if (dr.StandardDiscountPerValue == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE", dr.StandardDiscountPerValue);
                        }

                        if (dr.SedAmountByValue == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE", dr.SedAmountByValue);
                        }

                        if (dr.SedAmountPerValue == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE", dr.SedAmountPerValue);
                        }

                        if (dr.StandardDiscountByValueTo == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_TO", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_TO", dr.StandardDiscountByValueTo);
                        }

                        if (dr.StandardDiscountByValueAd == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_AD", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_BY_VALUE_AD", dr.StandardDiscountByValueAd);
                        }

                        if (dr.StandardDiscountPerValueTo == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_TO", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_TO", dr.StandardDiscountPerValueTo);
                        }

                        if (dr.StandardDiscountPerValueAd == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_AD", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@STANDARD_DISCOUNT_PER_VALUE_AD", dr.StandardDiscountPerValueAd);
                        }

                        if (dr.SedAmountByValueTo == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_TO", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_TO", dr.SedAmountByValueTo);
                        }

                        if (dr.SedAmountByValueAD == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_AD", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_BY_VALUE_AD", dr.SedAmountByValueAD);
                        }

                        if (dr.SedAmountPerValueTo == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_TO", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_TO", dr.SedAmountPerValueTo);
                        }
                        if (dr.SedAmountPerValueAd == Constants.DecimalNullValue)
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_AD ", DBNull.Value);
                        }
                        else
                        {
                            cmdDetail.Parameters.AddWithValue("@SED_AMOUNT_PER_VALUE_AD ", dr.SedAmountPerValueAd);
                        }
                        cmdDetail.ExecuteNonQuery();
                        m_SALE_ORDER_DETAIL_ID = (long)((IDataParameter)(cmdDetail.Parameters["@SALE_ORDER_DETAIL_ID"])).Value;
                    }

                    foreach (var df in dtOrderDetail.FreeSKU)
                    {
                        SqlCommand cmdFree = new SqlCommand();
                        cmdFree.Transaction = objTrans;
                        cmdFree.CommandType = CommandType.StoredProcedure;
                        cmdFree.CommandText = "spInsertSALE_ORDER_PROMOTION";
                        cmdFree.Connection = con;
                        if (p_Distributor_id == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_id);
                        }

                        cmdFree.Parameters.AddWithValue("@SCHEME_ID", DBNull.Value);

                        if (df.PromotionID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@PROMOTION_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@PROMOTION_ID", df.PromotionID);
                        }

                        if (df.BasketID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@BASKET_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@BASKET_ID", df.BasketID);
                        }

                        if (df.BasketDetailID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@BASKET_DETAIL_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@BASKET_DETAIL_ID", df.BasketDetailID);
                        }

                        if (df.PromotionOfferID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@PROMOTION_OFFER_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@PROMOTION_OFFER_ID", df.PromotionOfferID);
                        }

                        if (df.SKUID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@SKU_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@SKU_ID", df.SKUID);
                        }

                        if (df.Quantity == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY", df.Quantity);
                        }

                        if (df.MasterSKUID == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@MASTER_SKU_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@MASTER_SKU_ID", df.MasterSKUID);
                        }

                        if (p_UserId == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@USER_ID", p_UserId);
                        }

                        SqlParameter parmFree = new SqlParameter("@SALE_ORDER_PROMOTION_ID", SqlDbType.BigInt);
                        parmFree.Direction = ParameterDirection.Output;
                        cmdFree.Parameters.Add(parmFree);

                        if (df.Price == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@UNIT_PRICE", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@UNIT_PRICE", df.Price);
                        }

                        if (df.Amount == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@AMOUNT", df.Amount);
                        }

                        if (df.GSTAmount == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@GST_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@GST_AMOUNT", df.GSTAmount);
                        }
                        if (df.TSTAmount == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@TST_AMOUNT", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@TST_AMOUNT", df.TSTAmount);
                        }

                        cmdFree.Parameters.AddWithValue("@SED_AMOUNT", 0);

                        if (p_Document_Date == Constants.DateNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@DOCUMENT_DATE", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@DOCUMENT_DATE", p_Document_Date);
                        }

                        cmdFree.Parameters.AddWithValue("@TIME_STAMP", DateTime.Now);

                        cmdFree.Parameters.AddWithValue("@LAST_UPDATED", DateTime.Now);

                        if (df.GSTRate == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@GST_RATE", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@GST_RATE", df.GSTRate);
                        }

                        if (m_SALE_ORDER_ID == Constants.LongNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@SALE_ORDER_ID", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@SALE_ORDER_ID", m_SALE_ORDER_ID);
                        }

                        if (df.ExtraTax == Constants.DecimalNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@EXTRA_TAX", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@EXTRA_TAX", df.ExtraTax);
                        }

                        if (df.QuantityTo == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY_TO", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY_TO", df.QuantityTo);
                        }

                        if (df.QuantityAd == Constants.IntNullValue)
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY_AD", DBNull.Value);
                        }
                        else
                        {
                            cmdFree.Parameters.AddWithValue("@QUANTITY_AD", df.QuantityAd);
                        }
                        cmdFree.ExecuteNonQuery();
                    }
                    objTrans.Commit();
                }
                else
                {
                    objTrans.Rollback();
                }
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertOutletOrderStatus(int p_Distributor_id, int p_PRINCIPAL_ID, int p_ORDERBOOKER_ID, int p_UserId, OutletUnOrder dtOrderDetail, string ConnectionString)
        {
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();
                objTrans = con.BeginTransaction();

                SqlCommand cmdDetail = new SqlCommand();
                cmdDetail.Transaction = objTrans;
                cmdDetail.CommandType = CommandType.StoredProcedure;
                cmdDetail.CommandText = "spInsertCUSTOMER_ORDER_STATUSSync";
                cmdDetail.Connection = con;
                if (p_Distributor_id == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_Distributor_id);
                }

                if (p_PRINCIPAL_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@PRINCIPAL_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PRINCIPAL_ID", p_PRINCIPAL_ID);
                }

                if (dtOrderDetail.SectionID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@AREA_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@AREA_ID", dtOrderDetail.SectionID);
                }

                if (dtOrderDetail.OutletID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@CUSTOMER_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@CUSTOMER_ID", dtOrderDetail.OutletID);
                }

                if (dtOrderDetail.DocumentDate == Constants.DateNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@DOCUMENT_DATE", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@DOCUMENT_DATE", dtOrderDetail.DocumentDate);
                }

                if (dtOrderDetail.ReasonID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@STATUS_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@STATUS_ID", dtOrderDetail.ReasonID);
                }

                if (p_UserId == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@USER_ID", p_UserId);
                }

                if (p_ORDERBOOKER_ID == Constants.IntNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@ORDERBOOKER_ID", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@ORDERBOOKER_ID", p_ORDERBOOKER_ID);
                }

                if (dtOrderDetail.TimeIn == Constants.DateNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@TIME_IN", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@TIME_IN", dtOrderDetail.TimeIn);
                }

                if (dtOrderDetail.TimeOut == Constants.DateNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@TIME_OUT", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@TIME_OUT", dtOrderDetail.TimeOut);
                }

                if (dtOrderDetail.Comments == null)
                {
                    cmdDetail.Parameters.AddWithValue("@REMARKS", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@REMARKS", dtOrderDetail.Comments);
                }

                if (dtOrderDetail.Latitude == Constants.DecimalNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@Latitude", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@Latitude", dtOrderDetail.Latitude);
                }

                if (dtOrderDetail.Longitude == Constants.DecimalNullValue)
                {
                    cmdDetail.Parameters.AddWithValue("@Longitude", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@Longitude", dtOrderDetail.Longitude);
                }

                if (dtOrderDetail.PhotoPath1 == null)
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath1", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath1", dtOrderDetail.PhotoPath1);
                }

                if (dtOrderDetail.PhotoPath2 == null)
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath2", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath2", dtOrderDetail.PhotoPath2);
                }

                if (dtOrderDetail.PhotoPath3 == null)
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath3", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath3", dtOrderDetail.PhotoPath3);
                }

                if (dtOrderDetail.PhotoPath4 == null)
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath4", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath4", dtOrderDetail.PhotoPath4);
                }
                if (dtOrderDetail.PhotoPath5 == null)
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath5", DBNull.Value);
                }
                else
                {
                    cmdDetail.Parameters.AddWithValue("@PhotoPath5", dtOrderDetail.PhotoPath5);
                }
                cmdDetail.ExecuteNonQuery();
                objTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertCustomerAndroid(int p_DISTRIBUTOR_ID, int p_USER_ID, List<Outlet> dtDetail, string ConnectionString)
        {
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmdFree = new SqlCommand();
            try
            {
                con.Open();
                objTrans = con.BeginTransaction();

                foreach (var dr in dtDetail)
                {
                    cmdFree = new SqlCommand();
                    cmdFree.Transaction = objTrans;
                    cmdFree.CommandType = CommandType.StoredProcedure;
                    cmdFree.CommandText = "uspSelectSETTINGS_TABLE";
                    cmdFree.Connection = con;
                    if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                    {
                        cmdFree.Parameters.AddWithValue("@DistributorId", DBNull.Value);
                    }
                    else
                    {
                        cmdFree.Parameters.AddWithValue("@DistributorId", p_DISTRIBUTOR_ID);
                    }
                    cmdFree.Parameters.AddWithValue("@TableName", "CUSTOMERTEMPORARY");
                    cmdFree.Parameters.AddWithValue("@FieldName", "CUSTOMER_ID");
                    SqlDataAdapter da = new SqlDataAdapter(cmdFree);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    long CustomerId = 0;
                    string StrCode = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CustomerId = long.Parse(ds.Tables[0].Rows[0]["Value"].ToString()) + 1;

                        if (CustomerId.ToString().Length == 1)
                        {
                            StrCode = "OT0000" + CustomerId.ToString();
                        }
                        else if (CustomerId.ToString().Length == 2)
                        {
                            StrCode = "OT000" + CustomerId.ToString();
                        }
                        else if (CustomerId.ToString().Length == 3)
                        {
                            StrCode = "OT00" + CustomerId.ToString();
                        }
                        else if (CustomerId.ToString().Length == 4)
                        {
                            StrCode = "OT0" + CustomerId.ToString();
                        }
                        else if (CustomerId.ToString().Length == 5)
                        {
                            StrCode = "OT" + CustomerId.ToString();
                        }
                    }

                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.Transaction = objTrans;
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.CommandText = "uspInsertCUSTOMER_ANDROID";
                    cmdDetail.Connection = con;

                    cmdDetail.Parameters.AddWithValue("@CUSTOMER_ID", CustomerId);

                    if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@DISTRIBUTOR_ID", p_DISTRIBUTOR_ID);
                    }

                    if (p_USER_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@USER_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@USER_ID", p_USER_ID);
                    }

                    cmdDetail.Parameters.AddWithValue("@CUSTOMER_CODE", StrCode);

                    if (dr.OutletName == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@CUSTOMER_NAME", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CUSTOMER_NAME", dr.OutletName);
                    }

                    if (dr.OwnerName == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@CONTACT_PERSON", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CONTACT_PERSON", dr.OwnerName);
                    }

                    if (dr.PhoneNumber == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@MOBILE_NUMBER", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@MOBILE_NUMBER", dr.PhoneNumber);
                    }
                    if (dr.OutletAddress == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@ADDRESS", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@ADDRESS", dr.OutletAddress);
                    }

                    if (dr.SectionID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@AREA_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@AREA_ID", dr.SectionID);
                    }

                    if (dr.LocalityID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@ROUTE_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@ROUTE_ID", dr.LocalityID);
                    }

                    if (dr.ChannelID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@CHANNEL_TYPE_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CHANNEL_TYPE_ID", dr.ChannelID);
                    }
                    if (dr.TownID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@TOWN_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@TOWN_ID", dr.TownID);
                    }

                    if (dr.AreaTypeId == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@AreaTypeId", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@AreaTypeId", dr.AreaTypeId);
                    }

                    if (dr.SubChannelID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@SUB_CHANNEL_TYPE_ID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@SUB_CHANNEL_TYPE_ID", dr.SubChannelID);
                    }

                    if (dr.Comments == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@REMARKS", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@REMARKS", dr.Comments);
                    }

                    if (dr.LandMark == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@LandMark", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@LandMark", dr.LandMark);
                    }

                    if (dr.Latitude == Constants.DecimalNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@Latitude", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Latitude", dr.Latitude);
                    }

                    if (dr.Longtidue == Constants.DecimalNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@Longitdue", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Longitdue", dr.Longtidue);
                    }

                    if (dr.PhotoPath1 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath1", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath1", dr.PhotoPath1);
                    }

                    if (dr.PhotoPath2 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath2", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath2", dr.PhotoPath2);
                    }

                    if (dr.PhotoPath3 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath3", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath3", dr.PhotoPath3);
                    }

                    if (dr.PhotoPath4 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath4", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath4", dr.PhotoPath4);
                    }

                    if (dr.PhotoPath5 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath5", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@PhotoPath5", dr.PhotoPath5);
                    }

                    cmdDetail.Parameters.AddWithValue("@WHATSAPP_NO", "");
                    cmdDetail.Parameters.AddWithValue("@CNIC", "");

                    cmdDetail.ExecuteNonQuery();
                }
                objTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertCustomerComplaint(int p_DISTRIBUTOR_ID, int p_USER_ID, List<OutletCompalint> dtDetail, string ConnectionString)
        {
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmdFree = new SqlCommand();
            try
            {
                con.Open();
                objTrans = con.BeginTransaction();

                foreach (var dr in dtDetail)
                {

                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.Transaction = objTrans;
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.CommandText = "uspInsertCustomerComplaint";
                    cmdDetail.Connection = con;

                    if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@DistributorID", p_DISTRIBUTOR_ID);
                    }
                    
                    if (dr.CustomerID == Constants.LongNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CustomerID", dr.CustomerID);
                    }

                    if (dr.DocumentDate == Constants.DateNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@DocumentDate", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@DocumentDate", dr.DocumentDate);
                    }

                    if (dr.ComplaintReasonID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@ComplaintReasonID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@ComplaintReasonID", dr.ComplaintReasonID);
                    }

                    if (dr.Remarks == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Remarks", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Remarks", dr.Remarks);
                    }

                    if (p_USER_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CreatedBy", p_USER_ID);
                    }

                    cmdDetail.ExecuteNonQuery();
                }
                objTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertMarchandise(int p_DISTRIBUTOR_ID, int p_USER_ID, List<Marchandise> dtDetail, string ConnectionString)
        {
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmdFree = new SqlCommand();
            try
            {
                con.Open();
                objTrans = con.BeginTransaction();

                foreach (var dr in dtDetail)
                {
                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.Transaction = objTrans;
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.CommandText = "uspInsertMarchandise";
                    cmdDetail.Connection = con;

                    if (p_DISTRIBUTOR_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@DistributorID", p_DISTRIBUTOR_ID);
                    }

                    if (dr.OutletID == Constants.LongNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CustomerID", dr.OutletID);
                    }

                    if (dr.DocumentDate == Constants.DateNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@DocumentDate", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@DocumentDate", dr.DocumentDate);
                    }

                    if (dr.Remarks == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Remarks", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Remarks", dr.Remarks);
                    }

                    if (dr.BFMarchanImg1 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path1", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path1", dr.BFMarchanImg1);
                    }

                    if (dr.BFMarchanImg2 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path2", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path2", dr.BFMarchanImg2);
                    }

                    if (dr.BFMarchanImg3 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path3", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path3", dr.BFMarchanImg3);
                    }

                    if (dr.BFMarchanImg4 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path4", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path4", dr.BFMarchanImg4);
                    }

                    if (dr.BFMarchanImg5 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path5", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image1Path5", dr.BFMarchanImg5);
                    }

                    if (dr.AFMarchanImg1 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path1", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path1", dr.AFMarchanImg1);
                    }

                    if (dr.AFMarchanImg2 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path2", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path2", dr.AFMarchanImg2);
                    }

                    if (dr.AFMarchanImg3 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path3", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path3", dr.AFMarchanImg3);
                    }

                    if (dr.AFMarchanImg4 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path4", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path4", dr.AFMarchanImg4);
                    }

                    if (dr.AFMarchanImg5 == null)
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path5", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@Image2Path5", dr.AFMarchanImg5);
                    }

                    if (p_USER_ID == Constants.IntNullValue)
                    {
                        cmdDetail.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                    }
                    else
                    {
                        cmdDetail.Parameters.AddWithValue("@CreatedBy", p_USER_ID);
                    }

                    cmdDetail.ExecuteNonQuery();
                }
                objTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertReplacement(int p_DistributorID, long p_CustomerID,DateTime p_DocumentDate, int p_ReplacementTypeID, int p_CreatedBy, List<Replacement> dtDetail, string ConnectionString)
        {
            long mReplacementID = 0;
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                if (dtDetail.Count > 0)
                {
                    con.Open();
                    objTrans = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Transaction = objTrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "uspInsertReplacementMaster";
                    cmd.Connection = con;
                    if (p_DistributorID == Constants.IntNullValue)
                    {
                        cmd.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DistributorID", p_DistributorID);
                    }

                    if (p_CustomerID == Constants.LongNullValue)
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", p_CustomerID);
                    }

                    if (p_DocumentDate == Constants.DateNullValue)
                    {
                        cmd.Parameters.AddWithValue("@DocumentDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DocumentDate", p_DocumentDate);
                    }

                    if (p_ReplacementTypeID == Constants.IntNullValue)
                    {
                        cmd.Parameters.AddWithValue("@ReplacementTypeID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ReplacementTypeID", p_ReplacementTypeID);
                    }

                    if (p_CreatedBy == Constants.IntNullValue)
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", p_CreatedBy);
                    }


                    SqlParameter parm = new SqlParameter("@ReplacementID", SqlDbType.BigInt);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);


                    cmd.ExecuteNonQuery();
                    mReplacementID = (long)((IDataParameter)(cmd.Parameters["@ReplacementID"])).Value;

                    if (mReplacementID > 0)
                    {
                        foreach (var dr in dtDetail)
                        {
                            SqlCommand cmdDetail = new SqlCommand();
                            cmdDetail.Transaction = objTrans;
                            cmdDetail.CommandType = CommandType.StoredProcedure;
                            cmdDetail.CommandText = "uspInsertReplacementDetail";
                            cmdDetail.Connection = con;

                            cmdDetail.Parameters.AddWithValue("@ReplacementID", mReplacementID);

                            if (p_DistributorID == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@DistributorID", p_DistributorID);
                            }

                            if (dr.ReasonID== Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@ReasonID", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@ReasonID", dr.ReasonID);
                            }

                            if (dr.SKUID == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@SKUID", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@SKUID", dr.SKUID);
                            }

                            if(dr.BATCHNO == null)
                            {
                                cmdDetail.Parameters.AddWithValue("BATCHNO", dr.BATCHNO);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("BATCHNO", DBNull.Value);
                            }

                            if (dr.Price == Constants.DecimalNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@Price", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Price", dr.Price);
                            }

                            if (dr.Quantity == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@Quantity", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Quantity", dr.Quantity);
                            }

                            if (dr.InvoiceNo == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceNo", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceNo", dr.InvoiceNo);
                            }

                            if (dr.InvoiceDate == Constants.DateNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceDate",dr.InvoiceDate);
                            }

                            if (dr.Description == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@Description", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Description", dr.Description);
                            }

                            if (dr.StockImage1 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage1", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage1", dr.StockImage1);
                            }

                            if (dr.StockImage2 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage2", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage2", dr.StockImage2);
                            }

                            if (dr.StockImage3 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage3", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage3", dr.StockImage3);
                            }

                            if (dr.StockImage4 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage4", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage4", dr.StockImage4);
                            }

                            if (dr.StockImage5 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage5", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@StockImage5", dr.StockImage5);
                            }

                            if (dr.InvoiceImage1 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage1", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage1", dr.InvoiceImage1);
                            }

                            if (dr.InvoiceImage2 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage2", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage2", dr.InvoiceImage2);
                            }

                            if (dr.InvoiceImage3 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage3", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage3", dr.InvoiceImage3);
                            }

                            if (dr.InvoiceImage4 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage4", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage4", dr.InvoiceImage4);
                            }

                            if (dr.InvoiceImage5 == null)
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage5", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@InvoiceImage5", dr.InvoiceImage5);
                            }
                            cmdDetail.ExecuteNonQuery();
                        }
                        objTrans.Commit();
                    }
                    else
                    {
                        objTrans.Rollback();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool InsertCustomerStock(int p_DistributorID, long p_CustomerID, DateTime p_DocumentDate, int p_CreatedBy, List<StockPosition> dtDetail, string ConnectionString)
        {
            long mCustomerStocktID = 0;
            SqlTransaction objTrans = null;
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                if (dtDetail.Count > 0)
                {
                    con.Open();
                    objTrans = con.BeginTransaction();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Transaction = objTrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "uspInsertCustomerStocktMaster";
                    cmd.Connection = con;
                    if (p_DistributorID == Constants.IntNullValue)
                    {
                        cmd.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DistributorID", p_DistributorID);
                    }

                    if (p_CustomerID == Constants.LongNullValue)
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", p_CustomerID);
                    }

                    if (p_DocumentDate == Constants.DateNullValue)
                    {
                        cmd.Parameters.AddWithValue("@DocumentDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DocumentDate", p_DocumentDate);
                    }
                    

                    if (p_CreatedBy == Constants.IntNullValue)
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CreatedBy", p_CreatedBy);
                    }


                    SqlParameter parm = new SqlParameter("@CustomerStocktID", SqlDbType.BigInt);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);


                    cmd.ExecuteNonQuery();
                    mCustomerStocktID = (long)((IDataParameter)(cmd.Parameters["@CustomerStocktID"])).Value;

                    if (mCustomerStocktID > 0)
                    {
                        foreach (var dr in dtDetail)
                        {
                            SqlCommand cmdDetail = new SqlCommand();
                            cmdDetail.Transaction = objTrans;
                            cmdDetail.CommandType = CommandType.StoredProcedure;
                            cmdDetail.CommandText = "uspInsertCustomerStocktDetail";
                            cmdDetail.Connection = con;

                            cmdDetail.Parameters.AddWithValue("@CustomerStocktID", mCustomerStocktID);

                            if (p_DistributorID == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@DistributorID", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@DistributorID", p_DistributorID);
                            }


                            if (dr.SKUID == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@SKUID", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@SKUID", dr.SKUID);
                            }

                            if (dr.Quantity == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@Quantity", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Quantity", dr.Quantity);
                            }

                            if (dr.Unit_In_Case == Constants.IntNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@Unit_In_Case", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Unit_In_Case", dr.Unit_In_Case);
                            }

                            if (dr.Price == Constants.DecimalNullValue)
                            {
                                cmdDetail.Parameters.AddWithValue("@Price", DBNull.Value);
                            }
                            else
                            {
                                cmdDetail.Parameters.AddWithValue("@Price", dr.Price);
                            }

                            cmdDetail.ExecuteNonQuery();
                        }
                        objTrans.Commit();
                    }
                    else
                    {
                        objTrans.Rollback();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objTrans.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }
        }               
    }
}