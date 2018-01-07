using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class RigOperationsDailyReport : Form
    {
        WellRepository well = new WellRepository();
        public RigOperationsDailyReport()
        {
            InitializeComponent();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if(lstRig.Text == "")
            {
                MessageBox.Show("please select a Rig");
                lstRig.Focus();
                return;
            }
            else
            {
                int RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
                RigOperationDailyReportViewer viewer = new RigOperationDailyReportViewer();
                viewer.RigId = RigId;
                viewer.ShowDialog(this);
            }
        }

        private void RigOperationsDailyReport_Load(object sender, EventArgs e)
        {
            FillRig();
        }
        private void FillRig()
        {
            try
            {
                DataSet dsRig = well.fillRig();
                lstRig.Properties.DataSource = dsRig.Tables[0];
                lstRig.Properties.DisplayMember = "RigName";
                lstRig.Properties.ValueMember = "RigId";
                lstRig.Properties.NullText = "";
                lstRig.Properties.PopulateColumns();
                lstRig.Properties.Columns["RigId"].Visible = false;
                lstRig.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
