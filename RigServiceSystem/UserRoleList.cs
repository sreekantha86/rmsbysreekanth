﻿using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class UserRoleList : Form
    {
        public UserRoleList()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            UserRepository user = new UserRepository();
            user.AddToFavoriteForms(this.Name, this.Text, Program.UserId);
        }
    }
}
