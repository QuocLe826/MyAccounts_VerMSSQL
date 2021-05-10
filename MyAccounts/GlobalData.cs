﻿using MyAccounts.Libraries.Enums;

namespace MyAccounts.Forms
{
    public static class GlobalData
    {
        public static string CONFIG_FILE = "serverconfig.json";
        public static string CONFIG_PATH = "System//config//" + CONFIG_FILE;

        /// <summary>
        /// Biến lưu Server kết nối hệ thống
        /// </summary>
        public static string ServerName = string.Empty;

        /// <summary>
        /// Biến lưu tên database hệ thống
        /// </summary>
        public static string DatabaseName = string.Empty;

        /// <summary>
        /// Biến lưu database type hệ thống
        /// </summary>
        public static Enums.DatabaseSystemType DatabaseProvider;

        /// <summary>
        /// Biến lưu User Id đăng nhập hệ thống
        /// </summary>
        public static int UserId = -1;

        /// <summary>
        /// Biến lưu Username đăng nhập hệ thống
        /// </summary>
        public static string UserLogin = string.Empty;

        /// <summary>
        /// Biến lưu Password khi login
        /// </summary>
        public static string PasswordLogin = string.Empty;

        /// <summary>
        /// Biến lưu first name của user đăng nhập hệ thống
        /// </summary>
        public static string FirstName = string.Empty;

        /// <summary>
        /// Biến lưu last name của user đăng nhập hệ thống
        /// </summary>
        public static string LastName = string.Empty;

        /// <summary>
        /// Biến lưu database user
        /// </summary>
        public static string DatabaseUserName = string.Empty;

        /// <summary>
        /// Biến lưu database password
        /// </summary>
        public static string DatabasePassword = string.Empty;

        /// <summary>
        /// Biến lưu ngôn ngữ hệ thống
        /// </summary>
        public static string DefaultLanguage = string.Empty;

        /// <summary>
        /// Biến lưu server authentication
        /// </summary>
        public static string ServerAuthentication = string.Empty;

        /// <summary>
        /// Biến lưu Culture Info của hệ thống
        /// </summary>
        public static string CutureInfo = string.Empty;
    }
}
