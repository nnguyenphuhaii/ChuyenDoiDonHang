using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ChuyenDoiDonHang
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Khởi tạo và hiển thị Form1
            Application.Run(new Form1());
        }
    }
}