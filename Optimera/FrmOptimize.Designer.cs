namespace Optimera
{
    partial class FrmOptimize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptimize));
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.lblObj = new System.Windows.Forms.RichTextBox();
            this.lblCon = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Solution = new System.Windows.Forms.GroupBox();
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.btn_HTML = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PDF = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Excel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SaveSol = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.lblOptimal = new System.Windows.Forms.Label();
            this.lblInfeasible = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRemove = new System.Windows.Forms.RichTextBox();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lblfollowing = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Solution.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(851, 548);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 41;
            this.btn_OK.Text = "OK";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lblObj
            // 
            this.lblObj.Location = new System.Drawing.Point(148, 63);
            this.lblObj.Name = "lblObj";
            this.lblObj.ReadOnly = true;
            this.lblObj.Size = new System.Drawing.Size(233, 60);
            this.lblObj.TabIndex = 31;
            this.lblObj.Text = "";
            // 
            // lblCon
            // 
            this.lblCon.Location = new System.Drawing.Point(17, 167);
            this.lblCon.Name = "lblCon";
            this.lblCon.ReadOnly = true;
            this.lblCon.Size = new System.Drawing.Size(363, 322);
            this.lblCon.TabIndex = 32;
            this.lblCon.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCon);
            this.groupBox1.Controls.Add(this.lblObj);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 509);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(148, 138);
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
            this.label2.Location = new System.Drawing.Point(145, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Given the Objective Function";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 137);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // Solution
            // 
            this.Solution.Controls.Add(this.lblfollowing);
            this.Solution.Controls.Add(this.btnRemove);
            this.Solution.Controls.Add(this.lblRemove);
            this.Solution.Controls.Add(this.lblOptimal);
            this.Solution.Controls.Add(this.lblInfeasible);
            this.Solution.Controls.Add(this.label7);
            this.Solution.Controls.Add(this.spreadsheetControl1);
            this.Solution.Location = new System.Drawing.Point(403, 12);
            this.Solution.Name = "Solution";
            this.Solution.Size = new System.Drawing.Size(534, 508);
            this.Solution.TabIndex = 40;
            this.Solution.TabStop = false;
            this.Solution.Text = "Solution";
            this.Solution.Enter += new System.EventHandler(this.Solution_Enter);
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Location = new System.Drawing.Point(16, 128);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Size = new System.Drawing.Size(507, 338);
            this.spreadsheetControl1.TabIndex = 33;
            this.spreadsheetControl1.Text = "Spd_Results";
            // 
            // btn_HTML
            // 
            this.btn_HTML.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_HTML.Appearance.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.btn_HTML.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_HTML.Appearance.Options.UseBackColor = true;
            this.btn_HTML.Appearance.Options.UseBorderColor = true;
            this.btn_HTML.Location = new System.Drawing.Point(750, 548);
            this.btn_HTML.Name = "btn_HTML";
            this.btn_HTML.Size = new System.Drawing.Size(85, 23);
            this.btn_HTML.TabIndex = 42;
            this.btn_HTML.Text = "Export to HTML";
            this.btn_HTML.Click += new System.EventHandler(this.btn_HTML_Click);
            // 
            // btn_PDF
            // 
            this.btn_PDF.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_PDF.Appearance.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.btn_PDF.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_PDF.Appearance.Options.UseBackColor = true;
            this.btn_PDF.Appearance.Options.UseBorderColor = true;
            this.btn_PDF.Location = new System.Drawing.Point(648, 548);
            this.btn_PDF.Name = "btn_PDF";
            this.btn_PDF.Size = new System.Drawing.Size(96, 23);
            this.btn_PDF.TabIndex = 43;
            this.btn_PDF.Text = "Export to PDF";
            this.btn_PDF.Click += new System.EventHandler(this.btn_PDF_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Excel.Appearance.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.btn_Excel.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Excel.Appearance.Options.UseBackColor = true;
            this.btn_Excel.Appearance.Options.UseBorderColor = true;
            this.btn_Excel.Location = new System.Drawing.Point(547, 548);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(95, 23);
            this.btn_Excel.TabIndex = 44;
            this.btn_Excel.Text = "Export to Excel";
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btn_SaveSol
            // 
            this.btn_SaveSol.Location = new System.Drawing.Point(456, 548);
            this.btn_SaveSol.Name = "btn_SaveSol";
            this.btn_SaveSol.Size = new System.Drawing.Size(85, 23);
            this.btn_SaveSol.TabIndex = 45;
            this.btn_SaveSol.Text = "Save .sol";
            this.btn_SaveSol.Click += new System.EventHandler(this.btn_SaveSol_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // lblOptimal
            // 
            this.lblOptimal.AutoSize = true;
            this.lblOptimal.BackColor = System.Drawing.Color.White;
            this.lblOptimal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimal.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOptimal.Location = new System.Drawing.Point(174, 27);
            this.lblOptimal.Name = "lblOptimal";
            this.lblOptimal.Size = new System.Drawing.Size(99, 23);
            this.lblOptimal.TabIndex = 46;
            this.lblOptimal.Text = "OPTIMAL";
            // 
            // lblInfeasible
            // 
            this.lblInfeasible.AutoSize = true;
            this.lblInfeasible.BackColor = System.Drawing.Color.White;
            this.lblInfeasible.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfeasible.ForeColor = System.Drawing.Color.Crimson;
            this.lblInfeasible.Location = new System.Drawing.Point(161, 27);
            this.lblInfeasible.Name = "lblInfeasible";
            this.lblInfeasible.Size = new System.Drawing.Size(127, 23);
            this.lblInfeasible.TabIndex = 45;
            this.lblInfeasible.Text = "INFEASIBLE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(50, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 44;
            this.label7.Text = "Solution Status";
            // 
            // lblRemove
            // 
            this.lblRemove.Enabled = false;
            this.lblRemove.Location = new System.Drawing.Point(16, 91);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.ReadOnly = true;
            this.lblRemove.Size = new System.Drawing.Size(382, 31);
            this.lblRemove.TabIndex = 36;
            this.lblRemove.Text = "";
            this.lblRemove.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(404, 91);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(109, 26);
            this.btnRemove.TabIndex = 48;
            this.btnRemove.Text = "Remove Constraints";
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblfollowing
            // 
            this.lblfollowing.AutoSize = true;
            this.lblfollowing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblfollowing.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfollowing.ForeColor = System.Drawing.Color.White;
            this.lblfollowing.Location = new System.Drawing.Point(50, 62);
            this.lblfollowing.Name = "lblfollowing";
            this.lblfollowing.Size = new System.Drawing.Size(270, 16);
            this.lblfollowing.TabIndex = 49;
            this.lblfollowing.Text = "The following constraints couldnt be satisfied:";
            this.lblfollowing.Visible = false;
            // 
            // FrmOptimize
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 623);
            this.ControlBox = false;
            this.Controls.Add(this.btn_SaveSol);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.btn_PDF);
            this.Controls.Add(this.btn_HTML);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.Solution);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOptimize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmOptimize_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Solution.ResumeLayout(false);
            this.Solution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private System.Windows.Forms.RichTextBox lblObj;
        private System.Windows.Forms.RichTextBox lblCon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox Solution;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private DevExpress.XtraEditors.SimpleButton btn_HTML;
        private DevExpress.XtraEditors.SimpleButton btn_PDF;
        private DevExpress.XtraEditors.SimpleButton btn_Excel;
        private DevExpress.XtraEditors.SimpleButton btn_SaveSol;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Label lblOptimal;
        private System.Windows.Forms.Label lblInfeasible;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private System.Windows.Forms.RichTextBox lblRemove;
        private System.Windows.Forms.Label lblfollowing;
    }
}