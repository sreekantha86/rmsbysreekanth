namespace RigServiceSystem
{
    partial class Operations
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
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNewWell = new DevExpress.XtraEditors.SimpleButton();
            this.cmdUpdateOperations = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtCurrentDepth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtSection = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDaysOnWell = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtWellType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlanDepth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtOperation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtWell = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDepth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysOnWell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWellType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanDepth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(53, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "Select Rig";
            // 
            // lstRig
            // 
            this.lstRig.Location = new System.Drawing.Point(117, 12);
            this.lstRig.Name = "lstRig";
            this.lstRig.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lstRig.Properties.NullText = "";
            this.lstRig.Size = new System.Drawing.Size(285, 20);
            this.lstRig.TabIndex = 25;
            this.lstRig.TextChanged += new System.EventHandler(this.lstRig_TextChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::RigServiceSystem.Properties.Resources.operations;
            this.simpleButton2.Location = new System.Drawing.Point(613, 160);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(130, 31);
            this.simpleButton2.TabIndex = 73;
            this.simpleButton2.Text = "Edit Operation";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // cmdNewWell
            // 
            this.cmdNewWell.Image = global::RigServiceSystem.Properties.Resources.Well;
            this.cmdNewWell.Location = new System.Drawing.Point(613, 84);
            this.cmdNewWell.Name = "cmdNewWell";
            this.cmdNewWell.Size = new System.Drawing.Size(130, 31);
            this.cmdNewWell.TabIndex = 46;
            this.cmdNewWell.Text = "New Well";
            this.cmdNewWell.Click += new System.EventHandler(this.cmdNewWell_Click);
            // 
            // cmdUpdateOperations
            // 
            this.cmdUpdateOperations.Image = global::RigServiceSystem.Properties.Resources.operations;
            this.cmdUpdateOperations.Location = new System.Drawing.Point(613, 121);
            this.cmdUpdateOperations.Name = "cmdUpdateOperations";
            this.cmdUpdateOperations.Size = new System.Drawing.Size(130, 31);
            this.cmdUpdateOperations.TabIndex = 47;
            this.cmdUpdateOperations.Text = "Update Operation";
            this.cmdUpdateOperations.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = global::RigServiceSystem.Properties.Resources.Rig;
            this.groupControl1.Controls.Add(this.txtCurrentDepth);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.txtSection);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.txtDaysOnWell);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.txtWellType);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtPlanDepth);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtOperation);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtWell);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtLocation);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Location = new System.Drawing.Point(2, 41);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(605, 182);
            this.groupControl1.TabIndex = 45;
            this.groupControl1.Text = "Rig Current Operation Details";
            // 
            // txtCurrentDepth
            // 
            this.txtCurrentDepth.Location = new System.Drawing.Point(429, 107);
            this.txtCurrentDepth.Name = "txtCurrentDepth";
            this.txtCurrentDepth.Properties.ReadOnly = true;
            this.txtCurrentDepth.Size = new System.Drawing.Size(160, 20);
            this.txtCurrentDepth.TabIndex = 69;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(352, 110);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(69, 13);
            this.labelControl12.TabIndex = 70;
            this.labelControl12.Text = "Current Depth";
            // 
            // txtSection
            // 
            this.txtSection.Location = new System.Drawing.Point(429, 78);
            this.txtSection.Name = "txtSection";
            this.txtSection.Properties.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(160, 20);
            this.txtSection.TabIndex = 65;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(346, 81);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(75, 13);
            this.labelControl8.TabIndex = 66;
            this.labelControl8.Text = "Current Section";
            // 
            // txtDaysOnWell
            // 
            this.txtDaysOnWell.Location = new System.Drawing.Point(429, 134);
            this.txtDaysOnWell.Name = "txtDaysOnWell";
            this.txtDaysOnWell.Properties.ReadOnly = true;
            this.txtDaysOnWell.Size = new System.Drawing.Size(160, 20);
            this.txtDaysOnWell.TabIndex = 63;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(317, 137);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(104, 13);
            this.labelControl11.TabIndex = 64;
            this.labelControl11.Text = "Days On Current Well";
            // 
            // txtWellType
            // 
            this.txtWellType.Location = new System.Drawing.Point(114, 77);
            this.txtWellType.Name = "txtWellType";
            this.txtWellType.Properties.ReadOnly = true;
            this.txtWellType.Size = new System.Drawing.Size(189, 20);
            this.txtWellType.TabIndex = 61;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(45, 81);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(62, 13);
            this.labelControl10.TabIndex = 62;
            this.labelControl10.Text = "Type Of Well";
            // 
            // txtPlanDepth
            // 
            this.txtPlanDepth.Location = new System.Drawing.Point(114, 107);
            this.txtPlanDepth.Name = "txtPlanDepth";
            this.txtPlanDepth.Properties.ReadOnly = true;
            this.txtPlanDepth.Size = new System.Drawing.Size(189, 20);
            this.txtPlanDepth.TabIndex = 59;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(13, 110);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(93, 13);
            this.labelControl9.TabIndex = 60;
            this.labelControl9.Text = "Planned Well Depth";
            // 
            // txtOperation
            // 
            this.txtOperation.Location = new System.Drawing.Point(114, 133);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.Properties.ReadOnly = true;
            this.txtOperation.Size = new System.Drawing.Size(189, 20);
            this.txtOperation.TabIndex = 49;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 137);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "Current Operation";
            // 
            // txtWell
            // 
            this.txtWell.Location = new System.Drawing.Point(114, 47);
            this.txtWell.Name = "txtWell";
            this.txtWell.Properties.ReadOnly = true;
            this.txtWell.Size = new System.Drawing.Size(189, 20);
            this.txtWell.TabIndex = 47;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Well Name";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(429, 47);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(160, 20);
            this.txtLocation.TabIndex = 45;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(341, 50);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(80, 13);
            this.labelControl6.TabIndex = 46;
            this.labelControl6.Text = "Current Location";
            this.labelControl6.Click += new System.EventHandler(this.labelControl6_Click_1);
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 225);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.cmdNewWell);
            this.Controls.Add(this.cmdUpdateOperations);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstRig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Operations";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operations";
            this.Load += new System.EventHandler(this.Operations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstRig.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentDepth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysOnWell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWellType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanDepth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lstRig;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtWellType;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtPlanDepth;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtOperation;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtWell;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton cmdNewWell;
        private DevExpress.XtraEditors.TextEdit txtCurrentDepth;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtSection;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtDaysOnWell;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton cmdUpdateOperations;
    }
}