using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Product_Manage_System
{
    class DBMan
    {
        private static MySqlConnection conn = null;

        public static bool CreateConnection(String conStr)
        {
            bool bRet = false;

            try
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Connecting)
                        conn.Close();

                    conn = null;
                }

                conn = new MySqlConnection(conStr);
                conn.Open();

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }

            return bRet;
        }

        public static bool CloseConnection()
        {
            bool bRet = false;

            try
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Connecting)
                        conn.Close();

                    conn = null;
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bRet;
        }

        // 로그인
        public static bool LoginOffline(String id, String pwd, out DataTable dt)
        {
            bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT A.USER_ID AS USER_ID,";
                cmd.CommandText += " A.USER_NAME AS USER_NAME,";
                cmd.CommandText += " B.USER_PASSWORD AS USER_PASSWORD,";
                cmd.CommandText += " B.USER_FINGERPRINT AS USER_FINGERPRINT,";
                cmd.CommandText += " B.USER_BARCODE AS USER_BARCODE,";
                cmd.CommandText += " B.AUTHORITY_CODE AS AUTHORITY_CODE,";
                cmd.CommandText += " A.USE_YN AS USE_YN";
                cmd.CommandText += " FROM " + TABLES.TB_USER_INFO + " A, " + TABLES.TB_USER_ROLE + " B ";
                cmd.CommandText += " where A.user_id = '" + id + "' and B.USER_PASSWORD = '" + pwd + "' AND A.user_id = B.user_id";

                dt.TableName = TABLES.TB_USER_ROLE;
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_ID);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_NAME);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_PASSWORD);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_FINGERPRINT);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_BARCODE);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.AUTHORITY_CODE);
                dt.Columns.Add(COLUMNS.TB_USER_INFO_ROLE_JOIN.USE_YN);
                
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_ID] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_ID].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_NAME] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_NAME].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_PASSWORD] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_PASSWORD].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_FINGERPRINT] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_FINGERPRINT].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_BARCODE] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_BARCODE].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.AUTHORITY_CODE] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.AUTHORITY_CODE].ToString();
                    row[COLUMNS.TB_USER_INFO_ROLE_JOIN.USE_YN] = reader[COLUMNS.TB_USER_INFO_ROLE_JOIN.USE_YN].ToString();

                    dt.Rows.Add(row);
                }
                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }
       
            return bRet;
        }

        // Product Info List
        //public static bool SelectProductRentalList(string _productName, string _productCode, string _userId, string _demoStatusCode, string _identNumber, bool _historyChk, bool _useChk, out DataTable dt)
        public static bool SelectProductInfoList(string _productName, string _productCode, bool useChk, out DataTable dt)
        {
            bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT A.IDENT_NUMBER,";
                cmd.CommandText += " A.PRODUCT_NAME,";
                cmd.CommandText += " A.PRODUCT_CODE,";
                cmd.CommandText += " A.PROPERTY_TYPE_CODE,";
                cmd.CommandText += " A.BOX_NUMBER,";
                cmd.CommandText += " A.BOX_NAME,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'PROPERTY_TYPE_CODE' AND A.PROPERTY_TYPE_CODE = B.COMMON_CODE ) AS PROPERTY_TYPE_NAME,";
                cmd.CommandText += " A.PROPERTY_PURPOSE_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'PROPERTY_PURPOSE_CODE' AND A.PROPERTY_PURPOSE_CODE = B.COMMON_CODE ) AS PROPERTY_PURPOSE_NAME,";
                cmd.CommandText += " A.COMPANY_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'COMPANY_CODE' AND A.COMPANY_CODE = B.COMMON_CODE ) AS COMPANY_NAME,";
                cmd.CommandText += " A.COMPETENCY_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'COMPETENCY_CODE' AND A.COMPETENCY_CODE = B.COMMON_CODE ) AS COMPETENCY_NAME";
                cmd.CommandText += " FROM " + TABLES.TB_PRODUCT_INFO + " A";
                
                string where = "";

                if (_productName.Length > 0 || _productCode.Length > 0)
                {
                    if (_productName.Length > 0)
                    {
                        where += " WHERE A.PRODUCT_NAME LIKE '%" + _productName + "%'";
                    }

                    if (_productCode.Length > 0)
                    {
                        if (where.Length > 0)
                        {
                            where += " AND ";
                        }
                        else
                        {
                            where += " WHERE ";
                        }

                        where += " A.PRODUCT_CODE LIKE '%" + _productCode + "%'";
                    }
                }

                if(useChk == false)
                {
                    if (where.Length > 0)
                    {
                        where += " AND ";
                    }
                    else
                    { 
                        where += " WHERE ";
                    }

                    where += "A.USE_YN = '1'";
                }

                cmd.CommandText += where;
                
                dt.TableName = TABLES.TB_USER_ROLE;
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER] = reader[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER].ToString();
                
                    dt.Rows.Add(row);
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }
        // Product Box List 
        public static bool SelectProductBoxList(string _productCode, string _identNumber, out DataTable dt)
        {
             bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT A.PRODUCT_NAME,";
                cmd.CommandText += " A.PRODUCT_CODE,";
                cmd.CommandText += " A.IDENT_NUMBER,";
                cmd.CommandText += " B.BOX_NAME,";
                cmd.CommandText += " B.BOX_NUMBER";
                cmd.CommandText += " FROM TB_PRODUCT_HISTORY A,";
                cmd.CommandText += " TB_PRODUCT_INFO B";
             
                cmd.CommandText += " WHERE A.IDENT_NUMBER = B.IDENT_NUMBER";
                cmd.CommandText += " AND A.PRODUCT_CODE = B.PRODUCT_CODE";
                //cmd.CommandText += " AND B.PRODUCT_CODE ='" + _productCode + "'";
                cmd.CommandText += " AND A.PRODUCT_STATUS_CODE = 'RT' ";

                dt.TableName = TABLES.TB_USER_ROLE;
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE);
              //  dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER] = reader[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE].ToString();
                 //   row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER] = reader[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER].ToString();

                    dt.Rows.Add(row);
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;

        }
        // Product Rental List
        public static bool SelectProductRentalList(string _productName, string _productCode, string _userId, string _demoStatusCode, string _identNumber, bool _historyChk, bool _useChk, out DataTable dt)
        {
            bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT A.IDENT_NUMBER,";
                cmd.CommandText += " A.PRODUCT_CODE,";
                cmd.CommandText += " A.PRODUCT_NAME,";
                cmd.CommandText += " A.PROPERTY_TYPE_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'PROPERTY_TYPE_CODE' AND A.PROPERTY_TYPE_CODE = B.COMMON_CODE ) AS PROPERTY_TYPE_NAME,";
                cmd.CommandText += " A.PROPERTY_PURPOSE_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'PROPERTY_PURPOSE_CODE' AND A.PROPERTY_PURPOSE_CODE = B.COMMON_CODE ) AS PROPERTY_PURPOSE_NAME,";
                cmd.CommandText += " A.COMPANY_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'COMPANY_CODE' AND A.COMPANY_CODE = B.COMMON_CODE ) AS COMPANY_NAME,";
                cmd.CommandText += " A.COMPETENCY_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'COMPETENCY_CODE' AND A.COMPETENCY_CODE = B.COMMON_CODE ) AS COMPETENCY_NAME,";
                cmd.CommandText += " A.USER_ID,";
                cmd.CommandText += " DATE_FORMAT(A.PRODUCT_RENTAL_TIME,'%Y-%m-%d') AS PRODUCT_RENTAL_TIME,";
                cmd.CommandText += " DATE_FORMAT(A.PRODUCT_RETURN_TIME,'%Y-%m-%d') AS PRODUCT_RETURN_TIME,";
                cmd.CommandText += " DATE_FORMAT(A.PRODUCT_SAMPLE_RENTAL_TIME,'%Y-%m-%d') AS PRODUCT_SAMPLE_RENTAL_TIME,";
                cmd.CommandText += " DATE_FORMAT(A.PRODUCT_SAMPLE_RETURN_TIME,'%Y-%m-%d') AS PRODUCT_SAMPLE_RETURN_TIME,";
                cmd.CommandText += " A.PRODUCT_STATUS_CODE,";
                cmd.CommandText += " ( SELECT B.COMMON_NAME FROM " + TABLES.TB_COMMON_CODE + " B WHERE COMMON_GROUP_CODE = 'PRODUCT_STATUS_CODE' AND A.PRODUCT_STATUS_CODE = B.COMMON_CODE ) AS PRODUCT_STATUS_NAME,";
                cmd.CommandText += " A.NOTE,";
                cmd.CommandText += " B.BOX_NAME,";
                cmd.CommandText += " B.BOX_NUMBER";
                cmd.CommandText += " FROM " + TABLES.TB_PRODUCT_HISTORY + " A, " + TABLES.TB_PRODUCT_INFO + " B";
                cmd.CommandText += " WHERE A.IDENT_NUMBER = B.IDENT_NUMBER AND A.PRODUCT_CODE = B.PRODUCT_CODE";

                string where = "";

                if (_productName.Length > 0 || _productCode.Length > 0)
                {
                    if (_productName.Length > 0)
                    {
                        where += " AND A.PRODUCT_NAME LIKE '%" + _productName + "%'";
                    }

                    if (_productCode.Length > 0)
                    {
                        
                            where += " AND ";
                            where += " A.PRODUCT_CODE LIKE '%" + _productCode + "%'";
                        
                    }

                    if (_identNumber.Length > 0)
                    {
                        
                            where += " AND ";
                            where += " A.IDENT_NUMBER LIKE '%" + _identNumber + "%'";
                        
                    }
                }

                if (_userId.Length > 0)
                {
                    
                        where += " AND ";
                        where += "A.USER_ID = '" + _userId + "'";
                   
                }

                if (_demoStatusCode.Length > 0)
                {
                    
                        where += " AND ";
                        where += "A.PRODUCT_STATUS_CODE = '" + _demoStatusCode + "'";
                   
                }

                if (_useChk == false)
                {
                    if (_historyChk == false)
                    {
                        
                            where += " AND ";
                            where += "A.USE_YN = '1'";
                        
                    }
                }

                cmd.CommandText += where;

                dt.TableName = TABLES.TB_USER_ROLE;
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPANY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.USER_ID);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RENTAL_TIME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RETURN_TIME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RENTAL_TIME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RETURN_TIME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.NOTE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER] = reader[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.USER_ID] = reader[COLUMNS.TB_PRODUCT_HISTORY.USER_ID].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RENTAL_TIME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RENTAL_TIME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RETURN_TIME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RETURN_TIME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RENTAL_TIME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RENTAL_TIME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RETURN_TIME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RETURN_TIME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.NOTE] = reader[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME] = reader[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER] = reader[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER].ToString();

                    dt.Rows.Add(row);
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool ReturnProductInfo(DataRow rowCompany)
        {
            bool bRet = false;

            MySqlTransaction tran = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand();
            
            try
            {
                cmd.Transaction = tran;
                cmd.Connection = conn;
                // 바코드로 찍은 박스 네임으로 업데이트 한다. 
                cmd.CommandText = "UPDATE " + TABLES.TB_PRODUCT_INFO + " SET ";
                cmd.CommandText += "USE_YN = '1', BOX_NUMBER = '" + rowCompany[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER].ToString() + "'";
                cmd.CommandText += ", BOX_NAME = '" + rowCompany[COLUMNS.TB_PRODUCT_INFO.BOX_NAME].ToString() + "'";
                cmd.CommandText += " WHERE IDENT_NUMBER ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_CODE ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_NAME ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString() + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE " + TABLES.TB_PRODUCT_HISTORY + " SET ";
                cmd.CommandText += "USE_YN = '0', PRODUCT_STATUS_CODE = 'RE', PRODUCT_RETURN_TIME = now()";
                cmd.CommandText += " WHERE IDENT_NUMBER ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_CODE ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_NAME ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString() + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE " + TABLES.TB_PRODUCT_INFO + " SET ";
                cmd.CommandText += "BOX_NAME = ( SELECT BOX_NAME FROM " + TABLES.TB_BOX_INFO;
                cmd.CommandText += " WHERE BOX_NUMBER = '" + rowCompany[COLUMNS.TB_BOX_INFO.BOX_NUMBER].ToString() + "')";
                cmd.CommandText += " WHERE BOX_NUMBER = '" + rowCompany[COLUMNS.TB_BOX_INFO.BOX_NUMBER].ToString() + "'";
                cmd.ExecuteNonQuery();

                tran.Commit();

                bRet = true;

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return bRet;
        }

        public static bool InsertProductHistory(DataRow rowCompany)
        {
            bool bRet = false;

            MySqlTransaction tran = conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand();
            
            try
            {
                cmd.Transaction = tran;
                cmd.Connection = conn;

                cmd.CommandText = "UPDATE " + TABLES.TB_PRODUCT_INFO + " SET ";
                cmd.CommandText += "USE_YN = '0'";
                cmd.CommandText += " WHERE IDENT_NUMBER ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_CODE ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString() + "'";
                cmd.CommandText += " AND PRODUCT_NAME ='" + rowCompany[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString() + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT " + TABLES.TB_PRODUCT_HISTORY;
                cmd.CommandText += " (IDENT_NUMBER, PRODUCT_CODE, PRODUCT_NAME, PROPERTY_TYPE_CODE, PROPERTY_PURPOSE_CODE, COMPANY_CODE, COMPETENCY_CODE, USER_ID, PRODUCT_RENTAL_TIME, PRODUCT_STATUS_CODE, NOTE, USE_YN) ";
                cmd.CommandText += " VALUES('" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.USER_ID].ToString() + "'";
                cmd.CommandText += ", now()";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString() + "'";
                cmd.CommandText += ",'" + rowCompany[COLUMNS.TB_PRODUCT_HISTORY.USE_YN].ToString() + "')";
                cmd.ExecuteNonQuery();

                tran.Commit();

                bRet = true;            
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return bRet;
        }

        /// <summary>
        /// 이상현
        /// </summary>
        /// <param name="COMMON_GROUP_CODE"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool selectCommonCodeByGroupCode(string COMMON_GROUP_CODE, out DataTable dt)
        {
            bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT COMMON_CODE, COMMON_NAME, COMMON_GROUP_CODE FROM ";
                cmd.CommandText += "TB_COMMON_CODE WHERE COMMON_GROUP_CODE = '" + COMMON_GROUP_CODE + "'";


                dt.TableName = TABLES.TB_COMMON_CODE;
                dt.Columns.Add(COLUMNS.TB_COMMON_CODE.COMMON_CODE);
                dt.Columns.Add(COLUMNS.TB_COMMON_CODE.COMMON_NAME);
                dt.Columns.Add(COLUMNS.TB_COMMON_CODE.COMMON_GROUP_CODE);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_COMMON_CODE.COMMON_CODE] = reader[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
                    row[COLUMNS.TB_COMMON_CODE.COMMON_NAME] = reader[COLUMNS.TB_COMMON_CODE.COMMON_NAME].ToString();
                    row[COLUMNS.TB_COMMON_CODE.COMMON_GROUP_CODE] = reader[COLUMNS.TB_COMMON_CODE.COMMON_GROUP_CODE].ToString();


                    dt.Rows.Add(row);
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool selectProductInfo(string PRODUCT_NAME, string PRODUCT_CODE, string PROPERTY_TYPE_CODE, string PROPERTY_PURPOSE_CODE,
                                            string COMPANY_CODE, string COMPETENCY_CODE, string IDENT_NUMBER,
                                            string BOX_NAME, string BOX_NUMBER, out DataTable dt)
        {
            bool bRet = false;
            dt = new DataTable();

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT A.IDENT_NUMBER, A.PRODUCT_CODE, A.PRODUCT_NAME, A.PROPERTY_TYPE_CODE, A.BOX_NAME, A.BOX_NUMBER, ";
                cmd.CommandText += "( SELECT B.COMMON_NAME FROM   TB_COMMON_CODE B WHERE COMMON_GROUP_CODE = 'COMPETENCY_CODE' AND A.BOX_COMPETENCY = B.COMMON_CODE ) AS BOX_COMPETENCY_NAME, ";
                cmd.CommandText += "A.BOX_COMPETENCY AS BOX_COMPETENCY_CODE, ";
                cmd.CommandText += "( SELECT B.COMMON_NAME FROM   TB_COMMON_CODE B WHERE COMMON_GROUP_CODE = 'PROPERTY_TYPE_CODE' AND A.PROPERTY_TYPE_CODE = B.COMMON_CODE ) AS PROPERTY_TYPE_NAME, ";
                cmd.CommandText += "A.PROPERTY_PURPOSE_CODE, ";
                cmd.CommandText += "( SELECT B.COMMON_NAME FROM   TB_COMMON_CODE B WHERE COMMON_GROUP_CODE = 'PROPERTY_PURPOSE_CODE' AND A.PROPERTY_PURPOSE_CODE = B.COMMON_CODE ) AS PROPERTY_PURPOSE_NAME, ";
                cmd.CommandText += "A.COMPANY_CODE, ";
                cmd.CommandText += "( SELECT B.COMMON_NAME FROM   TB_COMMON_CODE B WHERE COMMON_GROUP_CODE = 'COMPANY_CODE' AND A.COMPANY_CODE = B.COMMON_CODE ) AS COMPANY_NAME, ";
                cmd.CommandText += "A.COMPETENCY_CODE, ";
                cmd.CommandText += "( SELECT B.COMMON_NAME FROM   TB_COMMON_CODE B WHERE COMMON_GROUP_CODE = 'COMPETENCY_CODE' AND A.COMPETENCY_CODE = B.COMMON_CODE ) AS COMPETENCY_NAME ";
                cmd.CommandText += " FROM TB_PRODUCT_INFO A";

                string where = string.Empty;
                if (PRODUCT_NAME.Length > 0)
                    where += " WHERE A.PRODUCT_NAME LIKE '%" + PRODUCT_NAME + "%'";

                if (PRODUCT_CODE.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.PRODUCT_CODE LIKE '%" + PRODUCT_CODE + "%'";
                }

                if (PROPERTY_TYPE_CODE.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.PROPERTY_TYPE_CODE = '" + PROPERTY_TYPE_CODE + "'";
                }

                if (PROPERTY_PURPOSE_CODE.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.PROPERTY_PURPOSE_CODE = '" + PROPERTY_PURPOSE_CODE + "'";
                }

                if (COMPANY_CODE.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.COMPANY_CODE = '" + COMPANY_CODE + "'";
                }

                if (COMPETENCY_CODE.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.COMPETENCY_CODE = '" + COMPETENCY_CODE + "'";
                }

                if (IDENT_NUMBER.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.IDENT_NUMBER = '" + IDENT_NUMBER + "'";
                }

                if (BOX_NAME.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.BOX_NAME LIKE '%" + BOX_NAME + "%'";
                }

                if (BOX_NUMBER.Length > 0)
                {
                    if (where.Length > 0)
                        where += " AND ";
                    else
                        where += " WHERE ";

                    where += " A.BOX_NUMBER = '" + BOX_NUMBER + "'";
                }

                cmd.CommandText += where;

                dt.TableName = TABLES.TB_PRODUCT_INFO;
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_NAME);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_CODE);
                dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_NAME);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER] = reader[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_NAME].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_CODE] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_CODE].ToString();
                    row[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_NAME] = reader[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_NAME].ToString();
                    dt.Rows.Add(row);
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool InsertProductAdd(string PRODUCT_NAME, string PRODUCT_CODE, string PROPERTY_TYPE_CODE, string PROPERTY_PURPOSE_CODE,
                                            string COMPANY_CODE, string COMPETENCY_CODE, string IDENT_NUMBER,
                                            string BOX_NAME, string BOX_NUMBER, string BOX_COMPETENCY)
        {
            bool bRet = false;

            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string in_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                cmd.Connection = conn;

                cmd.CommandText = "INSERT TB_PRODUCT_INFO ";
                cmd.CommandText += " (IDENT_NUMBER, PRODUCT_NAME, PRODUCT_CODE, PROPERTY_TYPE_CODE, PROPERTY_PURPOSE_CODE, COMPANY_CODE ,COMPETENCY_CODE, ";
                cmd.CommandText += "CREATE_BY, CREATE_DATE, UPDATE_BY, USE_YN, BOX_NAME, BOX_NUMBER, BOX_COMPETENCY) ";
                cmd.CommandText += " VALUES('" + IDENT_NUMBER + "'";
                cmd.CommandText += ",'" + PRODUCT_NAME + "'";
                cmd.CommandText += ",'" + PRODUCT_CODE + "'";
                cmd.CommandText += ",'" + PROPERTY_TYPE_CODE + "'";
                cmd.CommandText += ",'" + PROPERTY_PURPOSE_CODE + "'";
                cmd.CommandText += ",'" + COMPANY_CODE + "'";
                cmd.CommandText += ",'" + COMPETENCY_CODE + "'";
                cmd.CommandText += ",'" + Common.strUSER_ID + "'";
                cmd.CommandText += ",'" + in_date + "'";
                cmd.CommandText += ",'" + "" + "'";
                cmd.CommandText += ",'" + "1" + "'";
                cmd.CommandText += ",'" + BOX_NAME + "'";
                cmd.CommandText += ",'" + BOX_NUMBER + "'";
                cmd.CommandText += ",'" + BOX_COMPETENCY + "')";

                cmd.ExecuteNonQuery();

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool selectBoxInfo(string BOX_NUMBER, out string BOX_NAME, out string BOX_COMPETENCY)
        {
            bool bRet = false;
            BOX_NAME = string.Empty;
            BOX_COMPETENCY = string.Empty;

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT BOX_NAME, BOX_NUMBER, BOX_COMPETENCY";
                cmd.CommandText += " FROM TB_BOX_INFO WHERE BOX_NUMBER = '" + BOX_NUMBER + "'";

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    BOX_NAME = reader["BOX_NAME"].ToString();
                    BOX_COMPETENCY = reader["BOX_COMPETENCY"].ToString();
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool selectBoxSeiral(out string BOX_SERIAL_NO)
        {
            bool bRet = false;
            BOX_SERIAL_NO = string.Empty;

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "SELECT BOX_SERIAL_NO";
                cmd.CommandText += " FROM TB_BOX_SERIAL_NO";

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    BOX_SERIAL_NO = reader["BOX_SERIAL_NO"].ToString();
                }

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool UpdateBoxSeiral(string BOX_SERIAL_NO)
        {
            bool bRet = false;

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "UPDATE TB_BOX_SERIAL_NO";
                cmd.CommandText += " SET BOX_SERIAL_NO = '" + BOX_SERIAL_NO + "'";

                reader = cmd.ExecuteReader();

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }

        public static bool InsertBoxInfo(string BOX_NAME, string BOX_NUMBER, string BOX_COMPETENCY)
        {
            bool bRet = false;

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader = null;

            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO TB_BOX_INFO (BOX_NUMBER, BOX_NAME, BOX_COMPETENCY) VALUES";
                cmd.CommandText += " ('" + BOX_NUMBER + "', '" + BOX_NAME + "', '" + BOX_COMPETENCY + "')";

                reader = cmd.ExecuteReader();

                bRet = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
            }

            return bRet;
        }
    }
}
