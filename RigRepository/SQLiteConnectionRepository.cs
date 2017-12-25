using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class SQLiteConnectionRepository
    {
        public string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string conString = String.Format("Data Source={0};Version=3;",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\RigMS\\RmsTemp.db3");
        public bool IsTempDBExists()
        {            
            return System.IO.File.Exists(Path + @"\RigMS\RmsTemp.db3");
        }
        public void CreateSqlLiteDatabase()
        {
            try
            {
                if(!System.IO.File.Exists(Path + @"\RigMS\RmsTemp.db3"))
                {
                    if (!System.IO.Directory.Exists(Path + @"\RigMS\"))
                    {
                        System.IO.Directory.CreateDirectory(Path + @"\RigMS\");
                    }
                    SQLiteConnection.CreateFile(Path + @"\RigMS\RmsTemp.db3");
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public void ChangePassword()
        {
            using (SQLiteConnection con = new SQLiteConnection(Path + @"\RigMS\RmsTemp.db3"))
            {
                con.Open();
                con.ChangePassword("@SKRMS1986$#");
            }
        }
        public void SetPassword()
        {
            using (SQLiteConnection con = new SQLiteConnection(Path + @"\RigMS\RmsTemp.db3"))
            {
                con.Open();
                con.SetPassword("@SKRMS1986$#");
            }
        }
        public SQLiteConnection getConnection()
        {
            SQLiteConnection con = new SQLiteConnection(conString);
            con.Open();
            return con;
        }
    }
}
