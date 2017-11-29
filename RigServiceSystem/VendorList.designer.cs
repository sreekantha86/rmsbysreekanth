namespace EMS
{
    partial class VendorList
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
            this.Delete = new DevExpress.XtraEditors.SimpleButton();
            this.cmdAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VendorId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendorTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Country = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(7, 383);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // cmdAddNew
            // 
            this.cmdAddNew.Location = new System.Drawing.Point(687, 383);
            this.cmdAddNew.Name = "cmdAddNew";
            this.cmdAddNew.Size = new System.Drawing.Size(75, 23);
            this.cmdAddNew.TabIndex = 3;
            this.cmdAddNew.Text = "Add New";
            this.cmdAddNew.Click += new System.EventHandler(this.cmdAddNew_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(764, 358);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VendorId,
            this.VendorName,
            this.ContactPerson,
            this.VendorTypeName,
            this.Country});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // VendorId
            // 
            this.VendorId.Caption = "VendorId";
            this.VendorId.FieldName = "VendorId";
            this.VendorId.Name = "VendorId";
            // 
            // VendorName
            // 
            this.VendorName.Caption = "VendorName";
            this.VendorName.FieldName = "VendorName";
            this.VendorName.Name = "VendorName";
            this.VendorName.OptionsColumn.AllowEdit = false;
            this.VendorName.Visible = true;
            this.VendorName.VisibleIndex = 0;
            // 
            // ContactPerson
            // 
            this.ContactPerson.Caption = "ContactPerson";
            this.ContactPerson.FieldName = "ContactPerson";
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.OptionsColumn.AllowEdit = false;
            this.ContactPerson.Visible = true;
            this.ContactPerson.VisibleIndex = 1;
            // 
            // VendorTypeName
            // 
            this.VendorTypeName.Caption = "Vendor Type";
            this.VendorTypeName.FieldName = "VendorTypeName";
            this.VendorTypeName.Name = "VendorTypeName";
            this.VendorTypeName.OptionsColumn.AllowEdit = false;
            this.VendorTypeName.Visible = true;
            this.VendorTypeName.VisibleIndex = 2;
            // 
            // Country
            // 
            this.Country.Caption = "Country";
            this.Country.FieldName = "CountryName";
            this.Country.Name = "Country";
            this.Country.OptionsColumn.AllowEdit = false;
            this.Country.Visible = true;
            this.Country.VisibleIndex = 3;
            // 
            // VendorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(768, 415);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.cmdAddNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorList";
            this.Text = "VendorList";
            this.Load += new System.EventHandler(this.VendorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Delete;
        private DevExpress.XtraEditors.SimpleButton cmdAddNew;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn VendorId;
        private DevExpress.XtraGrid.Columns.GridColumn VendorName;
        private DevExpress.XtraGrid.Columns.GridColumn ContactPerson;
        private DevExpress.XtraGrid.Columns.GridColumn VendorTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn Country;
    }
}