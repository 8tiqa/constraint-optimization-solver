using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Gurobi;


namespace Optimera
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
            InitSkinGallery();

        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }
        private void btn_File_New_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        //IMPORT MODEL FROM LP FILE

        private void btnFile_Open_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = new FrmOpenModel_LPFile();
            frm.Show();
        }

        private void btn_Import_LPFile_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = new FrmOpenModel_LPFile();
            frm.Show();

        }

        private void btnFile_Open_ItemPress(object sender, ItemClickEventArgs e)
        {

        }


        //VIEW MODEL
        private void ConItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            GRBConstr[] allCons = MyGlobals.model.GetConstrs();

            if (allCons.Length != 0)
            {
                txtCon.Visible = true;
                lblCon.Visible = true;
                lblCon.Text = "";

                GRBLinExpr con_info;
                string co_name;
                char co_sense;
                double co_RHS;
                int n;

                for (n = 0; n < allCons.Length; n++)
                {
                    co_name = allCons[n].Get(GRB.StringAttr.ConstrName);
                    co_sense = allCons[n].Get(GRB.CharAttr.Sense);
                    co_RHS = allCons[n].Get(GRB.DoubleAttr.RHS);


                    con_info = (GRBLinExpr)MyGlobals.model.GetRow(allCons[n]);

                    lblCon.Text += co_name + ": ";


                    for (int i = 0; i < con_info.Size; i++)
                    {
                        lblCon.Text += " " + con_info.GetCoeff(i) + con_info.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
                    }

                    lblCon.Text += " " + co_sense + " " + co_RHS + "\n";

                }


            }
            else
            {

                MessageBox.Show("You have not added any constraints!");
            }

        }

        private void ObjItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {

                txtObj.Visible = true;
                lblObj.Visible = true;
                lblObj.Text = "";

                //objective function
                int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
                if (int_sense == -1)
                {
                    lblObj.Text = "MAXIMIZE";
                }
                else if (int_sense == 1)
                {
                    lblObj.Text = "MINIMIZE";
                }

                for (int i = 0; i < func.Size; i++)
                {
                    lblObj.Text = lblObj.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
                }

            }
            else
            {

                MessageBox.Show("You have not added any objective function!");
            }

        }

        private void VarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                txtVar.Visible = true;
                lblVar.Visible = true;
                lblVar.Text = "";

                //VarNames                
                GRBVar[] allVar = MyGlobals.model.GetVars();
                for (int i = 0; i < allVar.Length; i++)
                {
                    lblVar.Text = lblVar.Text + "\n" + allVar[i].Get(GRB.DoubleAttr.LB) + " > " + allVar[i].Get(GRB.StringAttr.VarName) + " > " + allVar[i].Get(GRB.DoubleAttr.UB);

                }

            }
            else
            {

                MessageBox.Show("You have not added any variables!");
            }

        }

        //BUILD NEW MODEL
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = new FrmNewModel();
            frm.Show();
        }

        private void btnBuild_AddVar_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Checking if model is initialized          
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                Form frm = new FrmAddVar();
                frm.Show();
            }
            else
            {
                Form frm = new FrmNewModel();
                frm.Show();
            }

        }

        private void btnBuild_AddObj_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                Form frm = new FrmAddObj();
                frm.Show();
            }
            else
            {

                MessageBox.Show("You have not added any variables!");
            }
        }

        private void btnBuild_AddCon_ItemClick(object sender, ItemClickEventArgs e)
        {

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {

                Form frm = new FrmAddCon();
                frm.Show();

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        //OPTIMIZE
        private void btn_ImportOptimize_ItemClick(object sender, ItemClickEventArgs e)
        {

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                Form frm = new FrmOptimize();
                frm.Show();
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");

        }

        private void btn_Build_Optimize_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                Form frm = new FrmOptimize();
                frm.Show();
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        private void btnModify_Optimize_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                Form frm = new FrmOptimize();
                frm.Show();
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }
        private void btnView_Optimize_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                Form frm = new FrmOptimize();
                frm.Show();
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }



        //SAVE MODEL TO DISK
        private void btnFileSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                saveFileDialog1.ShowDialog();
                saveFileDialog1.Filter = "Model Files (*.lp)|*.lp";
                saveFileDialog1.DefaultExt = "lp";
                //saveFileDialog1.AddExtension = true;
            }
            else
                MessageBox.Show("There is no model to save.");
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fname = saveFileDialog1.FileName;
            MyGlobals.model.Write(fname + ".lp");
        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                saveFileDialog1.ShowDialog();
                saveFileDialog1.Filter = "Model Files (*.lp)|*.lp";
                saveFileDialog1.DefaultExt = "lp";
                //saveFileDialog1.AddExtension = true;
            }
            else
                MessageBox.Show("There is no model to save.");
        }


        //MODIFY VARIABLES
        private void btnModify_EditVar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                Form frm = new FrmChangeVar();
                frm.Show();

            }
            else
                MessageBox.Show("You have not added any variables in your model!");
        }

        private void btnModify_DeleteVar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MyGlobals.model.GetVars().Length >= 1)
            {

                Form frm = new FrmDeleteVar();
                frm.Show();

            }
            else
                MessageBox.Show("You have not added any variables in your model");
        }

        private void btnModify_AddVar_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Checking if model is initialized          
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                Form frm = new FrmAddVar();
                frm.Show();
            }
            else
            {
                Form frm = new FrmNewModel();
                frm.Show();
            }

        }

        //MODIFY CONSTRAINTS
        private void btnModify_AddCon_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {

                Form frm = new FrmAddCon();
                frm.Show();

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");

        }

        private void btnModify_EditCon_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBConstr[] allCons = MyGlobals.model.GetConstrs();

            if (allCons.Length != 0)
            {

                Form frm = new FrmChangeCon();
                frm.Show();

            }
            else
                MessageBox.Show("You have not added any constraints in your model!");

        }

        private void btnModify_DeleteCon_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBConstr[] allCons = MyGlobals.model.GetConstrs();

            if (allCons.Length != 0)
            {

                Form frm = new FrmDeleteCon();
                frm.Show();

            }
            else
                MessageBox.Show("You have not added any constraints in your model!");

        }

        //MODIFY CONSTRAINTS
        private void btnModify_EditObj_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();
            if (func.Size != 0)
            {
                Form frm = new FrmChangeObj();
                frm.Show();
            }
            else
                MessageBox.Show("You have not added any objective function in your model!");
        }

        private void btnFile_Exit_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to close the application?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }


        }


        // SAVE SOLUTION TO DISK
        private void btnView_SaveSol_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                MyGlobals.model.Optimize();
                saveFileDialog2.ShowDialog();
                saveFileDialog2.Filter = "Solution Files (*.sol)|*.sol";
                saveFileDialog2.DefaultExt = "sol";

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");




        }

        //EXPORT SOLUTION FILES
        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string fname = saveFileDialog1.FileName;
            MyGlobals.model.Write(fname + ".sol");
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                // Optimize model
                MyGlobals.model.Optimize();
                int optimstatus = MyGlobals.model.Get(GRB.IntAttr.Status);
                GRBVar[] allVar = MyGlobals.model.GetVars();

                IWorkbook workbook;
                WorksheetCollection worksheets;
                Worksheet worksheet;

                //EXCEL WORKBOOK DOCUMENT FORMATION
                Excel.Application xlApp = new
                Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Variables";
                xlWorkSheet.Cells[1, 2] = "Value";
                xlWorkSheet.Cells[1, 3] = "Status";
                xlWorkSheet.Cells[1, 4] = "Objective Value";

                if (optimstatus == GRB.Status.OPTIMAL)
                {
                    xlWorkSheet.Cells[2, 3] = "Optimal";
                    xlWorkSheet.Cells[2, 4] = MyGlobals.model.Get(GRB.DoubleAttr.ObjVal);

                    for (int k = 0; k < allVar.Length; k++)
                    {
                        xlWorkSheet.Cells[k + 2, 1] = allVar[k].Get(GRB.StringAttr.VarName);
                        xlWorkSheet.Cells[k + 2, 2] = allVar[k].Get(GRB.DoubleAttr.X);
                    }
                }

                if (optimstatus == GRB.Status.INFEASIBLE)
                {
                    xlWorkSheet.Cells[2, 3] = "Infeasible";
                }

                xlWorkBook.SaveAs("d:\\solutiondraft.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //LOADING DOCUMENT
                spreadsheetControl1.LoadDocument("d:\\solutiondraft.xls");
                workbook = spreadsheetControl1.Document;
                worksheets = workbook.Worksheets;
                worksheet = workbook.Worksheets["Sheet1"];

                FileStream htmlStream = new FileStream("OutputWorksheet.html", FileMode.Create);
                workbook.ExportToHtml(htmlStream, worksheet.Index);
                MessageBox.Show("Your solution has been saved as HTML.");

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        private void btnView_Excel_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                // Optimize model
                MyGlobals.model.Optimize();
                int optimstatus = MyGlobals.model.Get(GRB.IntAttr.Status);
                GRBVar[] allVar = MyGlobals.model.GetVars();

                IWorkbook workbook;
                WorksheetCollection worksheets;
                Worksheet worksheet;

                //EXCEL WORKBOOK DOCUMENT FORMATION
                Excel.Application xlApp = new
                Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Variables";
                xlWorkSheet.Cells[1, 2] = "Value";
                xlWorkSheet.Cells[1, 3] = "Status";
                xlWorkSheet.Cells[1, 4] = "Objective Value";

                if (optimstatus == GRB.Status.OPTIMAL)
                {
                    xlWorkSheet.Cells[2, 3] = "Optimal";
                    xlWorkSheet.Cells[2, 4] = MyGlobals.model.Get(GRB.DoubleAttr.ObjVal);

                    for (int k = 0; k < allVar.Length; k++)
                    {
                        xlWorkSheet.Cells[k + 2, 1] = allVar[k].Get(GRB.StringAttr.VarName);
                        xlWorkSheet.Cells[k + 2, 2] = allVar[k].Get(GRB.DoubleAttr.X);
                    }
                }

                if (optimstatus == GRB.Status.INFEASIBLE)
                {
                    xlWorkSheet.Cells[2, 3] = "Infeasible";
                }

                xlWorkBook.SaveAs("d:\\solutiondraft.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //LOADING DOCUMENT
                spreadsheetControl1.LoadDocument("d:\\solutiondraft.xls");
                workbook = spreadsheetControl1.Document;
                worksheets = workbook.Worksheets;
                worksheet = workbook.Worksheets["Sheet1"];

                // Save the modified document to a stream. 
                using (FileStream stream = new FileStream("OutputWorksheet.xlsx",
                    FileMode.Create, FileAccess.ReadWrite))
                {
                    workbook.SaveDocument(stream, DocumentFormat.OpenXml);
                    MessageBox.Show("Your solution has been saved as XLSX.");
                }

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnView_PDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                // Optimize model
                MyGlobals.model.Optimize();
                int optimstatus = MyGlobals.model.Get(GRB.IntAttr.Status);
                GRBVar[] allVar = MyGlobals.model.GetVars();

                IWorkbook workbook;
                WorksheetCollection worksheets;
                Worksheet worksheet;

                //EXCEL WORKBOOK DOCUMENT FORMATION
                Excel.Application xlApp = new
                Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Variables";
                xlWorkSheet.Cells[1, 2] = "Value";
                xlWorkSheet.Cells[1, 3] = "Status";
                xlWorkSheet.Cells[1, 4] = "Objective Value";

                if (optimstatus == GRB.Status.OPTIMAL)
                {
                    xlWorkSheet.Cells[2, 3] = "Optimal";
                    xlWorkSheet.Cells[2, 4] = MyGlobals.model.Get(GRB.DoubleAttr.ObjVal);

                    for (int k = 0; k < allVar.Length; k++)
                    {
                        xlWorkSheet.Cells[k + 2, 1] = allVar[k].Get(GRB.StringAttr.VarName);
                        xlWorkSheet.Cells[k + 2, 2] = allVar[k].Get(GRB.DoubleAttr.X);
                    }
                }

                if (optimstatus == GRB.Status.INFEASIBLE)
                {
                    xlWorkSheet.Cells[2, 3] = "Infeasible";
                }

                xlWorkBook.SaveAs("d:\\solutiondraft.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //LOADING DOCUMENT
                spreadsheetControl1.LoadDocument("d:\\solutiondraft.xls");
                workbook = spreadsheetControl1.Document;
                worksheets = workbook.Worksheets;
                worksheet = workbook.Worksheets["Sheet1"];

                using (FileStream pdfFileStream = new FileStream("OutputWorksheet.pdf", FileMode.Create))
                {
                    workbook.ExportToPdf(pdfFileStream);
                    MessageBox.Show("Your solution has been saved as PDF.");
                }

            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");


        }

        //ANALYZE RESULTS
        private void btnView_Analyze_ItemClick(object sender, ItemClickEventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if (func.Size != 0)
            {
                Form frm = new FrmAnalyze();
                frm.Show();
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        private void iHelp_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }


    public static class MyGlobals
    {
        //Creating the environment
        public static GRBEnv env = new GRBEnv("firstapp.log");
        //Creating an empty model
        public static GRBModel model = new GRBModel(env);
        public static GRBLinExpr obj = 0.0;
    }

        
        
}