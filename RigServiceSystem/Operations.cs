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
    public partial class Operations : Form
    {
        WellRepository well = new WellRepository();
        public Operations()
        {
            InitializeComponent();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void cmdNewWell_Click(object sender, EventArgs e)
        {
            Well obj = new Well();
            obj.ShowDialog(this);
            obj.Dispose();
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OperationsUpdate obj = new OperationsUpdate();
            obj.ShowDialog();
            obj.Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void Operations_Load(object sender, EventArgs e)
        {

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
