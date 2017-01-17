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
                cmd.CommandText += " A.NOTE";
                cmd.CommandText += " FROM " + TABLES.TB_PRODUCT_HISTORY + " A";

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

                    if (_identNumber.Length > 0)
                    {
                        if (where.Length > 0)
                        {
                            where += " AND ";
                        }
                        else
                        {
                            where += " WHERE ";
                        }

                        where += " A.IDENT_NUMBER LIKE '%" + _identNumber + "%'";
                    }
                }

                if (_userId.Length > 0)
                {
                    if (where.Length > 0)
                    {
                        where += " AND ";
                    }
                    else
                    {
                        where += " WHERE ";
                    }

                    where += "A.USER_ID = '" + _userId + "'";
                }

                if (_demoStatusCode.Length > 0)
                {
                    if (where.Length > 0)
                    {
                        where += " AND ";
                    }
                    else
                    {
                        where += " WHERE ";
                    }

                    where += "A.PRODUCT_STATUS_CODE = '" + _demoStatusCode + "'";
                }

                if (_useChk == false)
                {
                    if(_historyChk == false)
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
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = conn;

                cmd.CommandText = "UPDATE " + TABLES.TB_PRODUCT_INFO + " SET ";
                cmd.CommandText += "USE_YN = '1'";
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

                bRet = true;

            }
            catch (Exception ex)
            {
                //transaction.Rollback();
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

            MySqlCommand cmd = new MySqlCommand();
            
            try
            {
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
                
                bRet = true;            
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return bRet;
        }
    }
}
