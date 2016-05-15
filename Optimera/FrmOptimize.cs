using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Gurobi;

namespace Optimera
{
    public partial class FrmOptimize : DevExpress.XtraEditors.XtraForm
    {

        IWorkbook workbook;
        WorksheetCollection worksheets;
        Worksheet worksheet;

        public FrmOptimize()
        {
            InitializeComponent();
        }

        private void FrmOptimize_Load(object sender, EventArgs e)
        {
            refresh_display();
        }


        private void refresh_display()
        {

            //model information
            lblObj.Text = "";
            lblCon.Text = "";
            lblOptimal.Text = "";
            lblInfeasible.Text = "";


            MyGlobals.model.Update();
            //objective function
            int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
            if (int_sense == -1)
                lblObj.Text = "MAXIMIZE";
            else
                lblObj.Text = "MINIMIZE";

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();
            for (int i = 0; i < func.Size; i++)
                lblObj.Text = lblObj.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";


            //constraints
            GRBConstr[] allCons = MyGlobals.model.GetConstrs();
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
                    lblCon.Text += " " + con_info.GetCoeff(i) + con_info.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
                lblCon.Text += " " + co_sense + " " + co_RHS + "\n";

            }

            // Optimize model
            MyGlobals.model.Optimize();
            int optimstatus = MyGlobals.model.Get(GRB.IntAttr.Status);

            //If the model is infeasible or unbounded, turn off presolve and solve the model again
            if (optimstatus == GRB.Status.INF_OR_UNBD)
            {
                MyGlobals.model.GetEnv().Set(GRB.IntParam.Presolve, 0);
                MyGlobals.model.Optimize();
                optimstatus = MyGlobals.model.Get(GRB.IntAttr.Status);
            }

            //if the model is optimal, display solution in a worksheet
            if (optimstatus == GRB.Status.OPTIMAL)
            {
                load_optimal();
            }

            //if the model is infeasible, compute IIS
            else if (optimstatus == GRB.Status.INFEASIBLE)
            {

                lblInfeasible.Text = "INFEASIBLE";

                //compute IIS
                lblfollowing.Visible = true;
                lblRemove.Enabled = true;
                lblRemove.Visible = true;
                lblRemove.Text = "";

                MyGlobals.model.ComputeIIS();
                foreach (GRBConstr c in MyGlobals.model.GetConstrs())
                {
                    if (c.Get(GRB.IntAttr.IISConstr) == 1)
                    {
                        lblRemove.Text += c.Get(GRB.StringAttr.ConstrName) + "  ";
                    }
                }
                btnRemove.Enabled = true;
                btnRemove.Visible = true;

                spreadsheetControl1.Visible = false;
                btn_Excel.Enabled = false;
                btn_HTML.Enabled = false;
                btn_PDF.Enabled = false;
                btn_SaveSol.Enabled = false;
            }

            //if the model is unbounded
            else if (optimstatus == GRB.Status.UNBOUNDED)
            {

                lblInfeasible.Text = "UNBOUNED\nModel cannot be solved.";

                spreadsheetControl1.Visible = false;
                btn_Excel.Enabled = false;
                btn_HTML.Enabled = false;
                btn_PDF.Enabled = false;
                btn_SaveSol.Enabled = false;
            }

            //NEITHER INFEASIBLE, NOR OPTIMAL, NOR UNBOUNDED
            else
            {
                lblInfeasible.Text = "Optimization stopped with \nstatus = " + optimstatus;
            }
        }
        private void load_optimal()
        {
            lblOptimal.Text = "OPTIMAL";
            GRBVar[] allVar = MyGlobals.model.GetVars();
            spreadsheetControl1.Visible = true;

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

            xlWorkSheet.Cells[1, 4] = "Objective Value";
            xlWorkSheet.Cells[2, 4] = MyGlobals.model.Get(GRB.DoubleAttr.ObjVal);

            for (int k = 0; k < allVar.Length; k++)
            {
                xlWorkSheet.Cells[k + 2, 1] = allVar[k].Get(GRB.StringAttr.VarName);
                xlWorkSheet.Cells[k + 2, 2] = allVar[k].Get(GRB.DoubleAttr.X);
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

            // Enable filtering for the specified cell range.
            Range range = worksheet["A1:E100"];
            worksheet.AutoFilter.Apply(range);

            btn_Excel.Enabled = true;
            btn_HTML.Enabled = true;
            btn_PDF.Enabled = true;
            btn_SaveSol.Enabled = true;
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
        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Solution_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //SAVE FILES
        private void btn_SaveSol_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveFileDialog1.Filter = "Solution Files (*.sol)|*.sol";
            saveFileDialog1.DefaultExt = "sol";
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fname = saveFileDialog1.FileName;
            MyGlobals.model.Write(fname + ".sol");
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            // Save the modified document to a stream. 
            using (FileStream stream = new FileStream("OutputWorksheet.xlsx",
                FileMode.Create, FileAccess.ReadWrite))
            {
                workbook.SaveDocument(stream, DocumentFormat.OpenXml);
                MessageBox.Show("Your solution has been saved as XLSX.");
            }

        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            
           
        }

        private void btn_HTML_Click(object sender, EventArgs e)
        {
           
            FileStream htmlStream = new FileStream("OutputWorksheet.html", FileMode.Create);
            workbook.ExportToHtml(htmlStream, worksheet.Index);
            MessageBox.Show("Your solution has been saved as HTML.");

            
        }

        private void btn_PDF_Click(object sender, EventArgs e)
        {
            using (FileStream pdfFileStream = new FileStream("OutputWorksheet.pdf", FileMode.Create))
            {
                workbook.ExportToPdf(pdfFileStream);
                MessageBox.Show("Your solution has been saved as PDF.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //If the problem cannot be solved, use IIS iteratively to Find all conflicting constraints.
            //Loop until we reduce to a model that can be solved
            LinkedList<string> removed = new LinkedList<string>();
            while (true)
            {
                foreach (GRBConstr c in MyGlobals.model.GetConstrs())
                {
                    if (c.Get(GRB.IntAttr.IISConstr) == 1)
                    {                       
                        removed.AddFirst(c.Get(GRB.StringAttr.ConstrName));
                        MyGlobals.model.Remove(c);
                        break;
                    }
                }                

                MyGlobals.model.Optimize();
                int status = MyGlobals.model.Get(GRB.IntAttr.Status);

                if (status == GRB.Status.UNBOUNDED)
                {
                    refresh_display();
                    return;
                }
                if (status == GRB.Status.OPTIMAL)
                {
                    refresh_display();
                    return;
                }
                if ((status != GRB.Status.INF_OR_UNBD) &&
                    (status != GRB.Status.INFEASIBLE))
                {
                    refresh_display();
                    return;
                }
            }           

        }

    }
}