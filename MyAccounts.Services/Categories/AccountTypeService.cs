﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyAccounts.Libraries.Helpers;
using MyAccounts.Services.BaseServices;

namespace MyAccounts.Services.Categories
{
    public class AccountTypeService: BaseService
    {
        public AccountTypeService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DataTable GetAccountType()
        {
            try
            {
                var query = "AccountType_GetData";
                return ExecuteDataTable(query, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable SearchAccountType(string code, string name, string status, string descriptions)
        {
            try
            {
                var query = "AccountType_SearchData";
                return ExecuteDataTable(query, CommandType.StoredProcedure,
                    new SqlParameter("@code", code),
                    new SqlParameter("@name", name),
                    new SqlParameter("@status", status),
                    new SqlParameter("@descriptions", descriptions));
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public Tuple<string, string> ProcessAccountType(DataTable dt, string actionType)
        {
            try
            {
                var query = "AccountType_ProcessData";
                var dtResult = ExecuteDataTable(query, CommandType.StoredProcedure,
                    new SqlParameter("@code", Functions.ToString(dt.Rows[0]["Code"])),
                    new SqlParameter("@name", Functions.ToString(dt.Rows[0]["Name"])),
                    new SqlParameter("@status", Functions.ToString(dt.Rows[0]["Status"])),
                    new SqlParameter("@descriptions", Functions.ToString(dt.Rows[0]["Descriptions"])),
                    new SqlParameter("@actionType", actionType));
                if (dtResult.Rows.Count > 0)
                {
                    return new Tuple<string, string>("", "");
                }
                return actionType.Equals("A")
                    ? new Tuple<string, string>("Data added failed!", "Thêm dữ liệu thất bại!")
                    : new Tuple<string, string>("Data update failed!", "Cập nhật dữ liệu thất bại!");
            }
            catch (Exception ex)
            {
                return new Tuple<string, string>(ex.Message, ex.Message);
            }
        }

        public Tuple<string, string> DeleteAccountType(string code)
        {
            try
            {
                var query = "AccountType_DeleteData";
                var dt = ExecuteDataTable(query, CommandType.StoredProcedure, new SqlParameter("@code", code));
                if (dt.Rows.Count > 0)
                {
                    return new Tuple<string, string>(Functions.ToString(dt.Rows[0][0]), Functions.ToString(dt.Rows[0][1]));
                }
                return new Tuple<string, string>("Delete failed!", "Xóa thất bại!");
            }
            catch (Exception ex)
            {
                return new Tuple<string, string>(ex.Message, ex.Message);
            }
        }
    }
}
