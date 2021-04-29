﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounts.Libraries.Constants
{
    public class MessageTitle
    {
        public static string SystemInformation = @"Information";
        public static string SystemWarning = @"Warning";
        public static string SystemError = @"Error";
        public static string SystemConfirm = @"Confirm";
    }

    public class CommonConstants
    {
        public static Dictionary<string, string> DicDatabaseProvider = new Dictionary<string, string>()
        {
            { "MSSQL", "Microsoft SQL Server" }
        };

        public static Dictionary<string, string> DicAuthentications = new Dictionary<string, string>()
        {
            { "WindowsAuth", "Windows Authentication" },
            { "ServerAuth", "Server Authentication"}
        };

        public static Dictionary<string, string> DicStatus = new Dictionary<string, string>()
        {
            { "Y", "Active" },
            { "N", "Inactive"}
        };
    }
}
