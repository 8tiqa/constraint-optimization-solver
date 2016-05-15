namespace Optimera
{
    partial class FrmAddCon
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddRHS = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRHS = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.button7 = new DevExpress.XtraEditors.SimpleButton();
            this.lblRHS = new System.Windows.Forms.RichTextBox();
            this.lblSense = new System.Windows.Forms.RichTextBox();
            this.lblConstraint = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSense = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddTerm = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Undo = new DevExpress.XtraEditors.SimpleButton();
            this.cmbVarName = new System.Windows.Forms.ComboBox();
            this.txtCoeff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnOptimize = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddRHS);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtRHS);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(12, 253);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 128);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add number at the Right Hand Side";
            // 
            // btnAddRHS
            // 
            this.btnAddRHS.Location = new System.Drawing.Point(606, 68);
            this.btnAddRHS.Name = "btnAddRHS";
            this.btnAddRHS.Size = new System.Drawing.Size(75, 23);
            this.btnAddRHS.TabIndex = 42;
            this.btnAddRHS.Text = "Add RHS";
            this.btnAddRHS.Click += new System.EventHandler(this.btnAddRHS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(119, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "RHS:";
            // 
            // txtRHS
            // 
            this.txtRHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRHS.Location = new System.Drawing.Point(168, 38);
            this.txtRHS.Name = "txtRHS";
            this.txtRHS.Size = new System.Drawing.Size(513, 24);
            this.txtRHS.TabIndex = 10;
            this.txtRHS.TextChanged += new System.EventHandler(this.txtRHS_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.lblRHS);
            this.groupBox4.Controls.Add(this.lblSense);
            this.groupBox4.Controls.Add(this.lblConstraint);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtName);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(12, 398);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(731, 250);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Name your Constraint";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(608, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 47;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(608, 194);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 43;
            this.button7.Text = "Add";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lblRHS
            // 
            this.lblRHS.Location = new System.Drawing.Point(581, 28);
            this.lblRHS.Name = "lblRHS";
            this.lblRHS.ReadOnly = true;
            this.lblRHS.Size = new System.Drawing.Size(102, 36);
            this.lblRHS.TabIndex = 37;
            this.lblRHS.Text = "";
            // 
            // lblSense
            // 
            this.lblSense.Location = new System.Drawing.Point(444, 28);
            this.lblSense.Name = "lblSense";
            this.lblSense.ReadOnly = true;
            this.lblSense.Size = new System.Drawing.Size(131, 36);
            this.lblSense.TabIndex = 36;
            this.lblSense.Text = "";
            // 
            // lblConstraint
            // 
            this.lblConstraint.Location = new System.Drawing.Point(170, 31);
            this.lblConstraint.Name = "lblConstraint";
            this.lblConstraint.ReadOnly = true;
            this.lblConstraint.Size = new System.Drawing.Size(268, 112);
            this.lblConstraint.TabIndex = 35;
            this.lblConstraint.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(116, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(47, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Building Constraint: ";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(170, 164);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(513, 24);
            this.txtName.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbSense);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(12, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(731, 82);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Comparison ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(82, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Comparator:";
            // 
            // cmbSense
            // 
            this.cmbSense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSense.FormattingEnabled = true;
            this.cmbSense.Location = new System.Drawing.Point(162, 31);
            this.cmbSense.Name = "cmbSense";
            this.cmbSense.Size = new System.Drawing.Size(519, 26);
            this.cmbSense.TabIndex = 9;
            this.cmbSense.SelectedIndexChanged += new System.EventHandler(this.cmbSense_SelectedIndexChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 124);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build the variable side of the constraint equality";
            // 
            // btnAddTerm
            // 
            this.btnAddTerm.Location = new System.Drawing.Point(525, 88);
            this.btnAddTerm.Name = "btnAddTerm";
            this.btnAddTerm.Size = new System.Drawing.Size(75, 23);
            this.btnAddTerm.TabIndex = 41;
            this.btnAddTerm.Text = "Add Term";
            this.btnAddTerm.Click += new System.EventHandler(this.btnAddTerm_Click);
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(606, 88);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(75, 23);
            this.btn_Undo.TabIndex = 40;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // cmbVarName
            // 
            this.cmbVarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVarName.FormattingEnabled = true;
            this.cmbVarName.Location = new System.Drawing.Point(162, 52);
            this.cmbVarName.Name = "cmbVarName";
            this.cmbVarName.Size = new System.Drawing.Size(519, 26);
            this.cmbVarName.TabIndex = 9;
            this.cmbVarName.SelectedIndexChanged += new System.EventHandler(this.cmbVarName_SelectedIndexChanged);
            // 
            // txtCoeff
            // 
            this.txtCoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoeff.Location = new System.Drawing.Point(162, 22);
            this.txtCoeff.Name = "txtCoeff";
            this.txtCoeff.Size = new System.Drawing.Size(519, 24);
            this.txtCoeff.TabIndex = 6;
            this.txtCoeff.TextChanged += new System.EventHandler(this.txtCoeff_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(89, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coefficient:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(71, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variable Name:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 655);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 44;
            this.btnBack.Text = "<Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 655);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(537, 655);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOptimize
            // 
            this.btnOptimize.Enabled = false;
            this.btnOptimize.Location = new System.Drawing.Point(620, 655);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(75, 23);
            this.btnOptimize.TabIndex = 47;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // FrmAddCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 738);
            this.ControlBox = false;
            this.Controls.Add(this.btnOptimize);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAddCon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Building Model - Step 3: Adding Constraints";
            this.Load += new System.EventHandler(this.FrmAddCon_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRHS;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox lblRHS;
        private System.Windows.Forms.RichTextBox lblSense;
        private System.Windows.Forms.RichTextBox lblConstraint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbVarName;
        private System.Windows.Forms.TextBox txtCoeff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnAddRHS;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton button7;
        private DevExpress.XtraEditors.SimpleButton btnAddTerm;
        private DevExpress.XtraEditors.SimpleButton btn_Undo;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnOptimize;
    }
}