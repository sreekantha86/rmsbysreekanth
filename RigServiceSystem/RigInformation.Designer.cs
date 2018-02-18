namespace RigServiceSystem
{
    partial class RigInformation
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
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lstRig = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRigSpecification = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtManufacturer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtModelNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOperatingDays = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrentLocation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrentWell = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtCurrentOperation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtRooms = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoPeopleInHand = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRigSpecification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatingDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentWell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRooms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoPeopleInHand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(57, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 28;
            this.labelControl5.Text = "Select Rig";
            // 
            // lstRig
            // 
            this.lstRig.Location = new System.Drawing.Point(121, 12);
            this.lstRig.Name = "lstRig";
            this.lstRig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lstRig.Properties.NullText = "";
            this.lstRig.Size = new System.Drawing.Size(302, 20);
            this.lstRig.TabIndex = 27;
            this.lstRig.TextChanged += new System.EventHandler(this.lstRig_TextChanged);
            // 
            // txtRigSpecification
            // 
            this.txtRigSpecification.Location = new System.Drawing.Point(121, 44);
            this.txtRigSpecification.Name = "txtRigSpecification";
            this.txtRigSpecification.Properties.ReadOnly = true;
            this.txtRigSpecification.Size = new System.Drawing.Size(302, 20);
            this.txtRigSpecification.TabIndex = 47;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(35, 47);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 13);
            this.labelControl6.TabIndex = 48;
            this.labelControl6.Text = "Rig Specification";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(121, 76);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Properties.ReadOnly = true;
            this.txtManufacturer.Size = new System.Drawing.Size(302, 20);
            this.txtManufacturer.TabIndex = 49;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(48, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 50;
            this.labelControl1.Text = "Manufacturer";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(538, 76);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Properties.ReadOnly = true;
            this.txtModelNo.Size = new System.Drawing.Size(169, 20);
            this.txtModelNo.TabIndex = 51;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(485, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 52;
            this.labelControl2.Text = "Model No.";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(121, 108);
            this.txtProject.Name = "txtProject";
            this.txtProject.Properties.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(302, 20);
            this.txtProject.TabIndex = 53;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(79, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 54;
            this.labelControl3.Text = "Project";
            // 
            // txtOperatingDays
            // 
            this.txtOperatingDays.Location = new System.Drawing.Point(121, 140);
            this.txtOperatingDays.Name = "txtOperatingDays";
            this.txtOperatingDays.Properties.ReadOnly = true;
            this.txtOperatingDays.Size = new System.Drawing.Size(302, 20);
            this.txtOperatingDays.TabIndex = 55;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 143);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(100, 13);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "Safe Operating Days";
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Location = new System.Drawing.Point(121, 172);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.Properties.ReadOnly = true;
            this.txtCurrentLocation.Size = new System.Drawing.Size(302, 20);
            this.txtCurrentLocation.TabIndex = 57;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(32, 175);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 13);
            this.labelControl7.TabIndex = 58;
            this.labelControl7.Text = "Current Location";
            // 
            // txtCurrentWell
            // 
            this.txtCurrentWell.Location = new System.Drawing.Point(121, 204);
            this.txtCurrentWell.Name = "txtCurrentWell";
            this.txtCurrentWell.Properties.ReadOnly = true;
            this.txtCurrentWell.Size = new System.Drawing.Size(302, 20);
            this.txtCurrentWell.TabIndex = 59;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(52, 207);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 13);
            this.labelControl8.TabIndex = 60;
            this.labelControl8.Text = "Current Well";
            // 
            // txtCurrentOperation
            // 
            this.txtCurrentOperation.Location = new System.Drawing.Point(538, 204);
            this.txtCurrentOperation.Name = "txtCurrentOperation";
            this.txtCurrentOperation.Properties.ReadOnly = true;
            this.txtCurrentOperation.Size = new System.Drawing.Size(169, 20);
            this.txtCurrentOperation.TabIndex = 61;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(445, 207);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(88, 13);
            this.labelControl9.TabIndex = 62;
            this.labelControl9.Text = "Current Operation";
            // 
            // txtRooms
            // 
            this.txtRooms.Location = new System.Drawing.Point(538, 236);
            this.txtRooms.Name = "txtRooms";
            this.txtRooms.Properties.ReadOnly = true;
            this.txtRooms.Size = new System.Drawing.Size(169, 20);
            this.txtRooms.TabIndex = 65;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(455, 239);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(78, 13);
            this.labelControl10.TabIndex = 66;
            this.labelControl10.Text = "Rooms Available";
            // 
            // txtNoPeopleInHand
            // 
            this.txtNoPeopleInHand.Location = new System.Drawing.Point(121, 236);
            this.txtNoPeopleInHand.Name = "txtNoPeopleInHand";
            this.txtNoPeopleInHand.Properties.ReadOnly = true;
            this.txtNoPeopleInHand.Size = new System.Drawing.Size(302, 20);
            this.txtNoPeopleInHand.TabIndex = 63;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 239);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(108, 13);
            this.labelControl11.TabIndex = 64;
            this.labelControl11.Text = "No. Of People In Hand";
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = global::RigServiceSystem.Properties.Resources.Rig;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 262);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(751, 218);
            this.groupControl1.TabIndex = 67;
            this.groupControl1.Text = "Rig History";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(745, 182);
            this.gridControl1.TabIndex = 69;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Well Name";
            this.gridColumn1.FieldName = "WellName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 442;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Spud Date";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 132;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Completion Date";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Well Depth";
            this.gridColumn4.FieldName = "WellDepth";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 141;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Type Of Well";
            this.gridColumn5.FieldName = "WellTypeName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 238;
            // 
            // RigInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 481);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtRooms);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.txtNoPeopleInHand);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtCurrentOperation);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtCurrentWell);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtCurrentLocation);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtOperatingDays);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtRigSpecification);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstRig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RigInformation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rig Information";
            this.Load += new System.EventHandler(this.RigInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRigSpecification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManufacturer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatingDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentWell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRooms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoPeopleInHand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lstRig;
        private DevExpress.XtraEditors.TextEdit txtRigSpecification;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtManufacturer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtModelNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtProject;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtOperatingDays;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCurrentLocation;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtCurrentWell;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtCurrentOperation;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtRooms;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtNoPeopleInHand;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;

    }
}