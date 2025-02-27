﻿using System;
using System.Data;
using System.Data.SqlClient;
using MyAccounts.Libraries.Helpers;
using MyAccounts.Libraries.Security;
using MyAccounts.Services.BaseServices;

namespace MyAccounts.Services.Commons
{
    public class UsersService: BaseService
    {
        public UsersService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string Login(string username, string password)
        {
            try
            {
                var query = @"select UserCode, Password from Users where UserCode = @username and Status = 'Y'";
                var dt = ExecuteDataTable(query, CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@password", password));
                if (dt.Rows.Count == 1)
                {
                    var passDecrypt = RSASecurity.Decrypt(Functions.ToString(dt.Rows[0]["Password"]) + "=");
                    if (!password.Equals(passDecrypt))
                    {
                        return "Incorrect Username or Password!";
                    }
                    query = @"update Users set LastLogin = GETDATE() where UserCode = @username and Status = 'Y'";
                    var res = ExecuteNonQuery(query, CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@password", password));
                    if (res <= 0)
                    {
                        return "Login failed";
                    }
                    return string.Empty;
                }
                return "Login failed!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable GetUserInfo(string username)
        {
            try
            {
                var query = "Users_GetUserInfo";
                return ExecuteDataTable(query, CommandType.StoredProcedure, new SqlParameter("@username", username));
            }
            catch (Exception e)
            {
                return new DataTable();
            }
        }

        public string ChangePassword(string username, string curPassword, string newPassword, string confirmPassword)
        {
            try
            {
                var query = @"select UserCode, Password from Users where UserCode = @username and Status = 'Y'";
                var dt = ExecuteDataTable(query, CommandType.Text, new SqlParameter("@username", username));
                if (dt.Rows.Count > 0)
                {
                    var passDecrypt = RSASecurity.Decrypt(Functions.ToString(dt.Rows[0]["Password"]) + "=");
                    if (!curPassword.Equals(passDecrypt))
                    {
                        return "Incorrect Current password";
                    }
                    if (!newPassword.Equals(confirmPassword))
                    {
                        return "Incorrect Confirm password";
                    }

                    newPassword = RSASecurity.Encrypt(newPassword);
                    newPassword = newPassword.Remove(newPassword.Length - 1, 1);
                    query = "Update Users set Password = @password where UserCode = @username and Status = 'Y'";
                    var res = ExecuteNonQuery(query, CommandType.Text, new SqlParameter("@username", username), new SqlParameter("@password", newPassword));
                    if (res <= 0)
                    {
                        return "Password change failed!";
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
