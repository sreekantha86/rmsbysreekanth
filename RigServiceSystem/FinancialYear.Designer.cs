namespace RigServiceSystem
{
    partial class FinancialYear
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFYName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.mskFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.mskTo = new DevExpress.XtraEditors.DateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmdCancel = new DevExpress.XtraEditors.PictureEdit();
            this.cmdSave = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFYName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "F.Y Name";
            // 
            // txtFYName
            // 
            this.txtFYName.Location = new System.Drawing.Point(70, 48);
            this.txtFYName.Name = "txtFYName";
            this.txtFYName.Properties.MaxLength = 50;
            this.txtFYName.Size = new System.Drawing.Size(205, 20);
            this.txtFYName.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(40, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "From";
            // 
            // mskFrom
            // 
            this.mskFrom.EditValue = null;
            this.mskFrom.Location = new System.Drawing.Point(70, 76);
            this.mskFrom.Name = "mskFrom";
            this.mskFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mskFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mskFrom.Size = new System.Drawing.Size(125, 20);
            this.mskFrom.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(52, 104);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(12, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "To";
            // 
            // mskTo
            // 
            this.mskTo.EditValue = null;
            this.mskTo.Location = new System.Drawing.Point(70, 101);
            this.mskTo.Name = "mskTo";
            this.mskTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mskTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mskTo.Size = new System.Drawing.Size(125, 20);
            this.mskTo.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cmdCancel);
            this.panelControl1.Controls.Add(this.cmdSave);
            this.panelControl1.Location = new System.Drawing.Point(1, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(342, 36);
            this.panelControl1.TabIndex = 8;
            // 
            // cmdCancel
            // 
            this.cmdCancel.EditValue = global::RigServiceSystem.Properties.Resources.cancel;
            this.cmdCancel.Location = new System.Drawing.Point(309, 5);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Properties.Appearance.Options.UseBackColor = true;
            this.cmdCancel.Size = new System.Drawing.Size(28, 29);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click_1);
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
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click_1);
            // 
            // FinancialYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(345, 161);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.mskTo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.mskFrom);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtFYName);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinancialYear";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Year";
            this.Load += new System.EventHandler(this.FinancialYear_Load);
            this.Click += new System.EventHandler(this.FinancialYear_Click);
            ((System.ComponentModel.ISupportInitialize)(this.txtFYName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtFYName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit mskFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit mskTo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit cmdSave;
        private DevExpress.XtraEditors.PictureEdit cmdCancel;
    }
}