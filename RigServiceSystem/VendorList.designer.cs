namespace RigServiceSystem
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VendorId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ContactPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VendorTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Country = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmdDelete = new DevExpress.XtraEditors.PictureEdit();
            this.cmdEdit = new DevExpress.XtraEditors.PictureEdit();
            this.cmdNew = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 40);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(764, 373);
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmdDelete);
            this.panelControl1.Controls.Add(this.cmdEdit);
            this.panelControl1.Controls.Add(this.cmdNew);
            this.panelControl1.Location = new System.Drawing.Point(0, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(768, 36);
            this.panelControl1.TabIndex = 5;
            // 
            // cmdDelete
            // 
            this.cmdDelete.EditValue = global::RigServiceSystem.Properties.Resources.delete;
            this.cmdDelete.Location = new System.Drawing.Point(738, 2);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.Properties.Appearance.Options.UseBackColor = true;
            this.cmdDelete.Size = new System.Drawing.Size(28, 29);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.EditValue = global::RigServiceSystem.Properties.Resources.edit;
            this.cmdEdit.Location = new System.Drawing.Point(38, 3);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdEdit.Properties.Appearance.Options.UseBackColor = true;
            this.cmdEdit.Size = new System.Drawing.Size(28, 29);
            this.cmdEdit.TabIndex = 1;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.EditValue = global::RigServiceSystem.Properties.Resources.new_small;
            this.cmdNew.Location = new System.Drawing.Point(4, 2);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdNew.Properties.Appearance.Options.UseBackColor = true;
            this.cmdNew.Size = new System.Drawing.Size(28, 29);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // VendorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(768, 415);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VendorList";
            this.Text = "List of Vendors";
            this.Load += new System.EventHandler(this.VendorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNew.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn VendorId;
        private DevExpress.XtraGrid.Columns.GridColumn VendorName;
        private DevExpress.XtraGrid.Columns.GridColumn ContactPerson;
        private DevExpress.XtraGrid.Columns.GridColumn VendorTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn Country;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit cmdDelete;
        private DevExpress.XtraEditors.PictureEdit cmdEdit;
        private DevExpress.XtraEditors.PictureEdit cmdNew;
    }
}