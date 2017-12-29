namespace RigServiceSystem
{
    partial class Location
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmdCancel = new DevExpress.XtraEditors.PictureEdit();
            this.cmdSave = new DevExpress.XtraEditors.PictureEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtLatitude = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLongitude = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLatitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongitude.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmdCancel);
            this.panelControl1.Controls.Add(this.cmdSave);
            this.panelControl1.Location = new System.Drawing.Point(0, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(492, 36);
            this.panelControl1.TabIndex = 16;
            // 
            // cmdCancel
            // 
            this.cmdCancel.EditValue = global::RigServiceSystem.Properties.Resources.cancel;
            this.cmdCancel.Location = new System.Drawing.Point(461, 2);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Properties.Appearance.Options.UseBackColor = true;
            this.cmdCancel.Size = new System.Drawing.Size(28, 29);
            this.cmdCancel.TabIndex = 1;
            // 
            // cmdSave
            // 
            this.cmdSave.EditValue = global::RigServiceSystem.Properties.Resources.save;
            this.cmdSave.Location = new System.Drawing.Point(4, 2);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Properties.Appearance.Options.UseBackColor = true;
            this.cmdSave.Size = new System.Drawing.Size(28, 29);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(100, 48);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Location Code";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(348, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Location Name";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(100, 152);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(348, 96);
            this.txtRemarks.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(53, 154);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Remarks";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(100, 100);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(155, 20);
            this.txtLatitude.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(55, 103);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 22;
            this.labelControl4.Text = "Latitude";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(100, 126);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(155, 20);
            this.txtLongitude.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(47, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "Longitude";
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 263);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Location";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Location";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLatitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLongitude.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit cmdCancel;
        private DevExpress.XtraEditors.PictureEdit cmdSave;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtLatitude;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLongitude;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}