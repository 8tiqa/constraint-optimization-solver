namespace Optimera
{
    partial class FrmAnalyze
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCon = new System.Windows.Forms.RichTextBox();
            this.lblObj = new System.Windows.Forms.RichTextBox();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInfeasible = new System.Windows.Forms.Label();
            this.lblOptimal = new System.Windows.Forms.Label();
            this.lblSolCount = new System.Windows.Forms.Label();
            this.lblRuntime = new System.Windows.Forms.Label();
            this.lblObjSol = new System.Windows.Forms.Label();
            this.lblbound = new System.Windows.Forms.Label();
            this.lblGap = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_algo = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_coeff = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCon);
            this.groupBox1.Controls.Add(this.lblObj);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 660);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Variable Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Subjected To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Given the Objective Function";
            // 
            // lblCon
            // 
            this.lblCon.Location = new System.Drawing.Point(17, 167);
            this.lblCon.Name = "lblCon";
            this.lblCon.ReadOnly = true;
            this.lblCon.Size = new System.Drawing.Size(363, 253);
            this.lblCon.TabIndex = 32;
            this.lblCon.Text = "";
            // 
            // lblObj
            // 
            this.lblObj.Location = new System.Drawing.Point(17, 58);
            this.lblObj.Name = "lblObj";
            this.lblObj.ReadOnly = true;
            this.lblObj.Size = new System.Drawing.Size(363, 60);
            this.lblObj.TabIndex = 31;
            this.lblObj.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(860, 678);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnl_coeff);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.pnl_algo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblGap);
            this.groupBox2.Controls.Add(this.lblbound);
            this.groupBox2.Controls.Add(this.lblObjSol);
            this.groupBox2.Controls.Add(this.lblRuntime);
            this.groupBox2.Controls.Add(this.lblSolCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblOptimal);
            this.groupBox2.Controls.Add(this.lblInfeasible);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(425, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 660);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Optimization Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(393, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Run Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(365, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Solution Count";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(31, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Solution Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(31, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Best Objective";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(30, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Best Bound";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(30, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Gap %";
            // 
            // lblInfeasible
            // 
            this.lblInfeasible.AutoSize = true;
            this.lblInfeasible.BackColor = System.Drawing.Color.White;
            this.lblInfeasible.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfeasible.ForeColor = System.Drawing.Color.Crimson;
            this.lblInfeasible.Location = new System.Drawing.Point(17, 53);
            this.lblInfeasible.Name = "lblInfeasible";
            this.lblInfeasible.Size = new System.Drawing.Size(127, 23);
            this.lblInfeasible.TabIndex = 42;
            this.lblInfeasible.Text = "INFEASIBLE";
            // 
            // lblOptimal
            // 
            this.lblOptimal.AutoSize = true;
            this.lblOptimal.BackColor = System.Drawing.Color.White;
            this.lblOptimal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimal.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOptimal.Location = new System.Drawing.Point(30, 53);
            this.lblOptimal.Name = "lblOptimal";
            this.lblOptimal.Size = new System.Drawing.Size(99, 23);
            this.lblOptimal.TabIndex = 43;
            this.lblOptimal.Text = "OPTIMAL";
            // 
            // lblSolCount
            // 
            this.lblSolCount.AutoSize = true;
            this.lblSolCount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSolCount.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblSolCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSolCount.Location = new System.Drawing.Point(404, 53);
            this.lblSolCount.Name = "lblSolCount";
            this.lblSolCount.Size = new System.Drawing.Size(15, 16);
            this.lblSolCount.TabIndex = 44;
            this.lblSolCount.Text = "5";
            // 
            // lblRuntime
            // 
            this.lblRuntime.AutoSize = true;
            this.lblRuntime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRuntime.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblRuntime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRuntime.Location = new System.Drawing.Point(404, 112);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.Size = new System.Drawing.Size(33, 16);
            this.lblRuntime.TabIndex = 45;
            this.lblRuntime.Text = "0.00";
            // 
            // lblObjSol
            // 
            this.lblObjSol.AutoSize = true;
            this.lblObjSol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblObjSol.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblObjSol.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblObjSol.Location = new System.Drawing.Point(125, 93);
            this.lblObjSol.Name = "lblObjSol";
            this.lblObjSol.Size = new System.Drawing.Size(75, 16);
            this.lblObjSol.TabIndex = 46;
            this.lblObjSol.Text = "9.32556454";
            // 
            // lblbound
            // 
            this.lblbound.AutoSize = true;
            this.lblbound.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblbound.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblbound.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblbound.Location = new System.Drawing.Point(125, 118);
            this.lblbound.Name = "lblbound";
            this.lblbound.Size = new System.Drawing.Size(75, 16);
            this.lblbound.TabIndex = 47;
            this.lblbound.Text = "9.32556454";
            // 
            // lblGap
            // 
            this.lblGap.AutoSize = true;
            this.lblGap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblGap.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.lblGap.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGap.Location = new System.Drawing.Point(125, 141);
            this.lblGap.Name = "lblGap";
            this.lblGap.Size = new System.Drawing.Size(75, 16);
            this.lblGap.TabIndex = 48;
            this.lblGap.Text = "9.32556454";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 49;
            this.label4.Text = "Algorithm Iterations";
            // 
            // pnl_algo
            // 
            this.pnl_algo.Location = new System.Drawing.Point(26, 200);
            this.pnl_algo.Name = "pnl_algo";
            this.pnl_algo.Size = new System.Drawing.Size(469, 212);
            this.pnl_algo.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(31, 418);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Coefficient Statistics";
            // 
            // pnl_coeff
            // 
            this.pnl_coeff.Location = new System.Drawing.Point(26, 442);
            this.pnl_coeff.Name = "pnl_coeff";
            this.pnl_coeff.Size = new System.Drawing.Size(469, 212);
            this.pnl_coeff.TabIndex = 51;
            // 
            // FrmAnalyze
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 711);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAnalyze";
            this.Load += new System.EventHandler(this.FrmAnalyze_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox lblCon;
        private System.Windows.Forms.RichTextBox lblObj;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGap;
        private System.Windows.Forms.Label lblbound;
        private System.Windows.Forms.Label lblObjSol;
        private System.Windows.Forms.Label lblRuntime;
        private System.Windows.Forms.Label lblSolCount;
        private System.Windows.Forms.Label lblOptimal;
        private System.Windows.Forms.Label lblInfeasible;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_algo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_coeff;
        private System.Windows.Forms.Label label11;
    }
}