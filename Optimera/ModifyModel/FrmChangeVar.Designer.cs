namespace Optimera
{
    partial class FrmChangeVar
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
            this.lblVar = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.cmbVarName = new System.Windows.Forms.ComboBox();
            this.chkInfinite = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObCo = new System.Windows.Forms.TextBox();
            this.cmbVarType = new System.Windows.Forms.ComboBox();
            this.txtub = new System.Windows.Forms.TextBox();
            this.txtlb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVar
            // 
            this.lblVar.Location = new System.Drawing.Point(36, 320);
            this.lblVar.Name = "lblVar";
            this.lblVar.ReadOnly = true;
            this.lblVar.Size = new System.Drawing.Size(660, 172);
            this.lblVar.TabIndex = 38;
            this.lblVar.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(49, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "All Variables:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbVarName);
            this.groupBox1.Controls.Add(this.chkInfinite);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtObCo);
            this.groupBox1.Controls.Add(this.cmbVarType);
            this.groupBox1.Controls.Add(this.txtub);
            this.groupBox1.Controls.Add(this.txtlb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(29, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 240);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Variables";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(591, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Update";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbVarName
            // 
            this.cmbVarName.FormattingEnabled = true;
            this.cmbVarName.Location = new System.Drawing.Point(146, 36);
            this.cmbVarName.Name = "cmbVarName";
            this.cmbVarName.Size = new System.Drawing.Size(521, 21);
            this.cmbVarName.TabIndex = 14;
            this.cmbVarName.SelectedIndexChanged += new System.EventHandler(this.cmbVarName_SelectedIndexChanged);
            // 
            // chkInfinite
            // 
            this.chkInfinite.AutoSize = true;
            this.chkInfinite.Location = new System.Drawing.Point(474, 153);
            this.chkInfinite.Name = "chkInfinite";
            this.chkInfinite.Size = new System.Drawing.Size(60, 17);
            this.chkInfinite.TabIndex = 13;
            this.chkInfinite.Text = "Infinite";
            this.chkInfinite.UseVisualStyleBackColor = true;
            this.chkInfinite.CheckedChanged += new System.EventHandler(this.chkInfinite_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(21, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Objective Coefficient";
            // 
            // txtObCo
            // 
            this.txtObCo.Location = new System.Drawing.Point(146, 95);
            this.txtObCo.Name = "txtObCo";
            this.txtObCo.Size = new System.Drawing.Size(520, 21);
            this.txtObCo.TabIndex = 11;
            // 
            // cmbVarType
            // 
            this.cmbVarType.FormattingEnabled = true;
            this.cmbVarType.Location = new System.Drawing.Point(146, 64);
            this.cmbVarType.Name = "cmbVarType";
            this.cmbVarType.Size = new System.Drawing.Size(521, 21);
            this.cmbVarType.TabIndex = 10;
            // 
            // txtub
            // 
            this.txtub.Location = new System.Drawing.Point(145, 149);
            this.txtub.Name = "txtub";
            this.txtub.Size = new System.Drawing.Size(323, 21);
            this.txtub.TabIndex = 7;
            // 
            // txtlb
            // 
            this.txtlb.Location = new System.Drawing.Point(146, 125);
            this.txtlb.Name = "txtlb";
            this.txtlb.Size = new System.Drawing.Size(520, 21);
            this.txtlb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Variable UpperBound:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(21, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Variable LowerBound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Variable Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable Name:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(540, 500);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 40;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(621, 500);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 39;
            this.BtnOK.Text = "OK";
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FrmChangeVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 535);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.lblVar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChangeVar";
            this.Load += new System.EventHandler(this.FrmChangeVar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox lblVar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.ComboBox cmbVarName;
        private System.Windows.Forms.CheckBox chkInfinite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObCo;
        private System.Windows.Forms.ComboBox cmbVarType;
        private System.Windows.Forms.TextBox txtub;
        private System.Windows.Forms.TextBox txtlb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
        private DevExpress.XtraEditors.SimpleButton BtnOK;
    }
}