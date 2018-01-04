namespace RigServiceSystem
{
    partial class Rig
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
            this.lstLocation = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lstRigType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtManufacturer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtProject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtModelNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtDateOfDeploy = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstRigType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateOfDeploy.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateOfDeploy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmdCancel);
            this.panelControl1.Controls.Add(this.cmdSave);
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(545, 36);
            this.panelControl1.TabIndex = 14;
            // 
            // cmdCancel
            // 
            this.cmdCancel.EditValue = global::RigServiceSystem.Properties.Resources.cancel;
            this.cmdCancel.Location = new System.Drawing.Point(514, 2);
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
            this.cmdSave.EditValueChanged += new System.EventHandler(this.cmdSave_EditValueChanged);
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // lstLocation
            // 
            this.lstLocation.Location = new System.Drawing.Point(104, 172);
            this.lstLocation.Name = "lstLocation";
            this.lstLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lstLocation.Properties.NullText = "";
            this.lstLocation.Size = new System.Drawing.Size(155, 20);
            this.lstLocation.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(104, 52);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(70, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Rig ID";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Rig Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 175);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Location";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(58, 267);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(104, 264);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(371, 62);
            this.txtRemarks.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 204);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "Rig Type";
            // 
            // lstRigType
            // 
            this.lstRigType.Location = new System.Drawing.Point(104, 202);
            this.lstRigType.Name = "lstRigType";
            this.lstRigType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lstRigType.Properties.NullText = "";
            this.lstRigType.Size = new System.Drawing.Size(155, 20);
            this.lstRigType.TabIndex = 5;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(104, 112);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(155, 20);
            this.txtManufacturer.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 114);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 26;
            this.labelControl6.Text = "Rig Manufaturer";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(104, 142);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(155, 20);
            this.txtProject.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(47, 145);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "Rig Project";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(104, 232);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(155, 20);
            this.txtModelNo.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(55, 235);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(44, 13);
            this.labelControl8.TabIndex = 30;
            this.labelControl8.Text = "Model No";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(276, 235);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(96, 13);
            this.labelControl9.TabIndex = 31;
            this.labelControl9.Text = "Date of Deployment";
            // 
            // txtDateOfDeploy
            // 
            this.txtDateOfDeploy.EditValue = null;
            this.txtDateOfDeploy.Location = new System.Drawing.Point(379, 232);
            this.txtDateOfDeploy.Name = "txtDateOfDeploy";
            this.txtDateOfDeploy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateOfDeploy.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateOfDeploy.Size = new System.Drawing.Size(96, 20);
            this.txtDateOfDeploy.TabIndex = 7;
            // 
            // Rig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(547, 342);
            this.Controls.Add(this.txtDateOfDeploy);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstRigType);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lstLocation);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rig";
            this.Load += new System.EventHandler(this.Rig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstRigType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateOfDeploy.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateOfDeploy.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit cmdCancel;
        private DevExpress.XtraEditors.PictureEdit cmdSave;
        private DevExpress.XtraEditors.LookUpEdit lstLocation;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lstRigType;
        private DevExpress.XtraEditors.TextEdit txtManufacturer;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtProject;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtModelNo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit txtDateOfDeploy;
    }
}