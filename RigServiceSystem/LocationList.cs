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
    public partial class LocationList : Form
    {
        LocationRepository repo = new LocationRepository();
        public LocationList()
        {
            InitializeComponent();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.ShowDialog();
            FillGrid();
        }

        private void LocationList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            try
            {
                DataSet ds = repo.GetLocationList();
                if(ds.Tables.Count>0)
                {
                    gridControl1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            UserRepository user = new UserRepository();
            user.AddToFavoriteForms(this.Name, this.Text, Program.UserId);
        }
    }
}
