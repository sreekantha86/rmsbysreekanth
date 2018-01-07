namespace RigServiceSystem
{
    partial class RigOperationsDailyReport
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
            this.cmdPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(17, 29);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 28;
            this.labelControl5.Text = "Select Rig";
            // 
            // lstRig
            // 
            this.lstRig.Location = new System.Drawing.Point(81, 26);
            this.lstRig.Name = "lstRig";
            this.lstRig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lstRig.Properties.NullText = "";
            this.lstRig.Size = new System.Drawing.Size(285, 20);
            this.lstRig.TabIndex = 27;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Image = global::RigServiceSystem.Properties.Resources.print;
            this.cmdPrint.Location = new System.Drawing.Point(133, 70);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(130, 31);
            this.cmdPrint.TabIndex = 47;
            this.cmdPrint.Text = "Show Print Preview";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // RigOperationsDailyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 132);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstRig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RigOperationsDailyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daily Report - Rig Operations";
            this.Load += new System.EventHandler(this.RigOperationsDailyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lstRig;
        private DevExpress.XtraEditors.SimpleButton cmdPrint;
    }
}