namespace Optimera
{
    partial class FrmAddObj
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSense = new System.Windows.Forms.RichTextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.button7 = new DevExpress.XtraEditors.SimpleButton();
            this.lblObj = new System.Windows.Forms.RichTextBox();
            this.btn_Undo = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddTerm = new DevExpress.XtraEditors.SimpleButton();
            this.cmbVarName = new System.Windows.Forms.ComboBox();
            this.txtCoeff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSense = new System.Windows.Forms.ComboBox();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSense);
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.lblObj);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(24, 292);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(834, 230);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Objective Function";
            // 
            // lblSense
            // 
            this.lblSense.Location = new System.Drawing.Point(32, 36);
            this.lblSense.Name = "lblSense";
            this.lblSense.ReadOnly = true;
            this.lblSense.Size = new System.Drawing.Size(281, 32);
            this.lblSense.TabIndex = 38;
            this.lblSense.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(32, 191);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 36;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(673, 191);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 23);
            this.button7.TabIndex = 29;
            this.button7.Text = "Add Objective Function";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblObj
            // 
            this.lblObj.Location = new System.Drawing.Point(32, 74);
            this.lblObj.Name = "lblObj";
            this.lblObj.ReadOnly = true;
            this.lblObj.Size = new System.Drawing.Size(780, 97);
            this.lblObj.TabIndex = 34;
            this.lblObj.Text = "";
            // 
            // btn_Undo
            // 
            this.btn_Undo.Enabled = false;
            this.btn_Undo.Location = new System.Drawing.Point(565, 104);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(75, 23);
            this.btn_Undo.TabIndex = 37;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddTerm);
            this.groupBox1.Controls.Add(this.btn_Undo);
            this.groupBox1.Controls.Add(this.cmbVarName);
            this.groupBox1.Controls.Add(this.txtCoeff);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(24, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 145);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Term(s) to your objective function";
            // 
            // btnAddTerm
            // 
            this.btnAddTerm.Location = new System.Drawing.Point(646, 104);
            this.btnAddTerm.Name = "btnAddTerm";
            this.btnAddTerm.Size = new System.Drawing.Size(75, 23);
            this.btnAddTerm.TabIndex = 28;
            this.btnAddTerm.Text = "Add Term";
            this.btnAddTerm.Click += new System.EventHandler(this.btnAddTerm_Click);
            // 
            // cmbVarName
            // 
            this.cmbVarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVarName.FormattingEnabled = true;
            this.cmbVarName.Location = new System.Drawing.Point(208, 62);
            this.cmbVarName.Name = "cmbVarName";
            this.cmbVarName.Size = new System.Drawing.Size(513, 26);
            this.cmbVarName.TabIndex = 9;
            this.cmbVarName.SelectedIndexChanged += new System.EventHandler(this.cmbVarName_SelectedIndexChanged);
            // 
            // txtCoeff
            // 
            this.txtCoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoeff.Location = new System.Drawing.Point(208, 24);
            this.txtCoeff.Name = "txtCoeff";
            this.txtCoeff.Size = new System.Drawing.Size(513, 24);
            this.txtCoeff.TabIndex = 6;
            this.txtCoeff.TextChanged += new System.EventHandler(this.txtCoeff_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(139, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coefficient:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(123, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbSense);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(834, 99);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Sense";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(113, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(301, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Do you want to maximize or minimize your objective function?";
            // 
            // cmbSense
            // 
            this.cmbSense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSense.FormattingEnabled = true;
            this.cmbSense.Location = new System.Drawing.Point(116, 55);
            this.cmbSense.Name = "cmbSense";
            this.cmbSense.Size = new System.Drawing.Size(605, 26);
            this.cmbSense.TabIndex = 9;
            this.cmbSense.SelectedIndexChanged += new System.EventHandler(this.cmbSense_SelectedIndexChanged);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(783, 537);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 38;
            this.btnNext.Text = "Next >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(56, 537);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 39;
            this.btnBack.Text = "< Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(697, 537);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 40;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 537);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 572);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmAddObj";
            this.Text = "Building Model - Step 2: Add Objective Function";
            this.Load += new System.EventHandler(this.FrmAddObj_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox lblObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbVarName;
        private System.Windows.Forms.TextBox txtCoeff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSense;
        private DevExpress.XtraEditors.SimpleButton btn_Undo;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton button7;
        private DevExpress.XtraEditors.SimpleButton btnAddTerm;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private System.Windows.Forms.RichTextBox lblSense;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}