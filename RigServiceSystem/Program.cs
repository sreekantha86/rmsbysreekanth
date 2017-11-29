using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigServiceSystem
{
    static class Program
    {
        private static int FyId;
        private static string FyName;
        private static string UId;
        private static string UName;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        public static int FinancialYearId
        {
            get { return FyId; }
            set { FyId = value;}
        }
        public static string FinancialYearName
        {
            get { return FyName; }
            set { FyName = value; }
        }
        public static string UserId
        {
            get { return UId; }
            set { UId = value; }
        }
        public static string UserName
        {
            get { return UName; }
            set { UName = value; }
        }
    }
}
