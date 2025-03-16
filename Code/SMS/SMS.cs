using System;
using DBHelper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace SMS
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:SMSDal
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class SMSDal
    {
        // <summary>
        /// Add Verification Code
        /// </summary>
        /// <param name="Phone">Phone Number/Email</param>
        /// <param name="ClassId">Source ID: (1 = Registration, 2 = Password Recovery, 3 = Login)</param>
        /// <param name="Number">Verification Code</param>
        /// <param name="IP">IP</param>
        /// <returns>Return Codes:-3 = Sent Successfully -2 = User's Sent Messages Exceed the Set Limit -4 = IP Exceeds the Set Limit -1 = Cannot Resend Within 60 Seconds</returns>
        public int AddSMS(string Phone,int ClassID,string Number,string IP)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = Phone },
                new SqlParameter("@ClassID", SqlDbType.Int, 4) { Value = ClassID },
                new SqlParameter("@Number", SqlDbType.NVarChar, 6) { Value = Number },
                new SqlParameter("@IP", SqlDbType.NVarChar, 50) { Value = IP },
              
            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("SMS_Add", parameters);
        }
        /// <summary>
        /// Verify Verification Code  
        /// </summary>
        /// <param name="Phone">Phone Number/Email</param>
        /// <param name="ClassId">Source ID: (1 = Registration, 2 = Password Recovery, 3 = Login)</param>
        /// <param name="Number">Verification Code</param>
        /// <param name="IP">IP</param>
        /// <returns>Return Codes:-1 = Fully Meets the Requirements  -2 = Does Not Meet the Search Criteria</returns>
        public int CheckSMS(string Phone, int ClassID, string Number, string IP)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            SqlParameter[] parameters =
            {
               new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = Phone },
                new SqlParameter("@ClassID", SqlDbType.Int, 4) { Value = ClassID },
                new SqlParameter("@Number", SqlDbType.NVarChar, 6) { Value = Number },
                new SqlParameter("@IP", SqlDbType.NVarChar, 50) { Value = IP },


            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("SMS_Check", parameters);

        }


    }

}
