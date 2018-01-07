using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;

namespace RigServiceSystem
{
    public partial class RigOperationDailyReportViewer : Form
    {
        WellRepository well = new WellRepository();
        public int RigId = 0;
        public RigOperationDailyReportViewer()
        {
            InitializeComponent();
        }
        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
        }

        private void RigOperationDailyReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = well.GetDetailedOperationReportOnRig(RigId);
                
                string XmlPath = Application.StartupPath + "//XML/RigOperationReport.xml";
                //string XmlPath = @"C:\Freelancer\Ravi\EMS\EMS\BuyerInvoice112.xml";
                ds.WriteXml(XmlPath, XmlWriteMode.WriteSchema);
                                
                ReportDocument crpt = new ReportDocument();
                crpt.Load(Application.StartupPath + "//Reports/rptRigOperationDailyReport.rpt");

                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = XmlPath;
                connectionInfo.DatabaseName = "NewDataSet";
                connectionInfo.UserID = "";
                connectionInfo.Password = "";
                SetDBLogonForReport(connectionInfo, crpt);

                crpt.Database.Tables[0].SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = crpt;

                TableLogOnInfos tableInfo = crystalReportViewer1.LogOnInfo;
                foreach (TableLogOnInfo info in tableInfo)
                {
                    info.ConnectionInfo = connectionInfo;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }     
        }
    }
}
