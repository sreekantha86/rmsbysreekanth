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
            obj.ShowDialog();
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
    }
}
