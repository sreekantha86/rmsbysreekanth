﻿namespace RigServiceSystem
{
    partial class LocationList
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
            this.cmdPin = new DevExpress.XtraEditors.PictureEdit();
            this.cmdDelete = new DevExpress.XtraEditors.PictureEdit();
            this.cmdEdit = new DevExpress.XtraEditors.PictureEdit();
            this.cmdNew = new DevExpress.XtraEditors.PictureEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmdPin);
            this.panelControl1.Controls.Add(this.cmdDelete);
            this.panelControl1.Controls.Add(this.cmdEdit);
            this.panelControl1.Controls.Add(this.cmdNew);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(579, 36);
            this.panelControl1.TabIndex = 6;
            // 
            // cmdPin
            // 
            this.cmdPin.EditValue = global::RigServiceSystem.Properties.Resources.pin;
            this.cmdPin.Location = new System.Drawing.Point(69, 2);
            this.cmdPin.Name = "cmdPin";
            this.cmdPin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdPin.Properties.Appearance.Options.UseBackColor = true;
            this.cmdPin.Size = new System.Drawing.Size(28, 29);
            this.cmdPin.TabIndex = 4;
            this.cmdPin.Click += new System.EventHandler(this.cmdPin_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.EditValue = global::RigServiceSystem.Properties.Resources.delete;
            this.cmdDelete.Location = new System.Drawing.Point(546, 3);
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
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(2, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(579, 251);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
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
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Code";
            this.gridColumn1.FieldName = "LocCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Location";
            this.gridColumn2.FieldName = "LocName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Latitude";
            this.gridColumn3.FieldName = "LocLatitude";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Longitude";
            this.gridColumn4.FieldName = "LocLongitude";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "LocId";
            this.gridColumn5.FieldName = "LocId";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // LocationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(583, 291);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LocationList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Locations";
            this.Load += new System.EventHandler(this.LocationList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit cmdDelete;
        private DevExpress.XtraEditors.PictureEdit cmdEdit;
        private DevExpress.XtraEditors.PictureEdit cmdNew;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.PictureEdit cmdPin;
    }
}