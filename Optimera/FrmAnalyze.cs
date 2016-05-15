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
using DevExpress.XtraCharts;
using DevExpress.Utils;	
using Gurobi;

namespace Optimera
{
    public partial class FrmAnalyze : DevExpress.XtraEditors.XtraForm
    {
        public FrmAnalyze()
        {
            InitializeComponent();
        }

        

        private void FrmAnalyze_Load(object sender, EventArgs e)
        {
            

            MyGlobals.model.Update();

            //MODEL INFORMATION
            lblObj.Text = "";
            lblCon.Text = "";

            //OBJECTIVE FUNCTION
            int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
            if (int_sense == -1)
                lblObj.Text = "MAXIMIZE";
            else
                lblObj.Text = "MINIMIZE";

            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();
            for (int i = 0; i < func.Size; i++)
                lblObj.Text = lblObj.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";

            //CONSTRAINTS
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

            MyGlobals.model.Optimize();
            
            //VARIABLE TYPE PIE CHART

            //variables type count
            int varnum = MyGlobals.model.Get(GRB.IntAttr.NumVars);
            int NXnum = MyGlobals.model.Get(GRB.IntAttr.NumNZs);            
            int INTnum = MyGlobals.model.Get(GRB.IntAttr.NumIntVars);
            int BINnum = MyGlobals.model.Get(GRB.IntAttr.NumBinVars);
            int CONnum = 0;
            int SEMINTnum = 0;
            int SEMICONnum = 0;


            GRBVar[] allVar = MyGlobals.model.GetVars();
            for (int i = 0; i < allVar.Length; i++)
            {
                if (allVar[i].Get(GRB.CharAttr.VType) == 'C')
                    CONnum++;
                if (allVar[i].Get(GRB.CharAttr.VType) == 'S')
                    SEMICONnum++;
                if (allVar[i].Get(GRB.CharAttr.VType) == 'N')
                    SEMINTnum++;
                
            }


            Dictionary<string, int> D = new Dictionary<string, int>();
            D.Add("Integer", INTnum);
            D.Add("Binary", BINnum);
            D.Add("Continous", CONnum);
            D.Add("Semi-Integer", SEMINTnum);
            D.Add("Semi-Continous", SEMICONnum);

            // Create a chart.
            ChartControl chartControl1 = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series Series_VarType = new Series("Series1", ViewType.Pie);
            chartControl1.Series.Add(Series_VarType);            

            // Bind chart to dictionary
            Series_VarType.DataSource = new BindingSource(D, null);

            // Specify data members to bind the series.
            Series_VarType.ArgumentScaleType = ScaleType.Qualitative;
            Series_VarType.ArgumentDataMember = "Key";
            Series_VarType.ValueScaleType = ScaleType.Numerical;
            Series_VarType.ValueDataMembers.AddRange(new string[] { "Value" });

            // Adjust the text pattern of the series label.
            PieSeriesLabel label = (PieSeriesLabel)Series_VarType.Label;            
            label.TextPattern = "{A}: {V:F1} ({VP:P0})";

            chartControl1.PaletteName = "Flow";
            chartControl1.PaletteBaseColorNumber = 0;

            // Dock the chart into its parent and add it to the current form.
            chartControl1.Dock = DockStyle.Bottom;
            groupBox1.Controls.Add(chartControl1);

            //OPTIMIZATION RESULTS
            lblRuntime.Text = "";
            lblSolCount.Text = "";
            lblOptimal.Text = "";
            lblInfeasible.Text = "";
            lblRuntime.Text = "";

            lblObjSol.Text = "";
            lblbound.Text = "";
            lblGap.Text = "";

            
            double Runtime = MyGlobals.model.Get(GRB.DoubleAttr.Runtime);
           

            if (MyGlobals.model.Get(GRB.IntAttr.Status) == GRB.Status.OPTIMAL)
            {
                double ObjSol = MyGlobals.model.Get(GRB.DoubleAttr.ObjVal);
                double Bound = MyGlobals.model.Get(GRB.DoubleAttr.ObjBound);
                double Gap = MyGlobals.model.Get(GRB.DoubleAttr.MIPGap);
                int SolCount = MyGlobals.model.Get(GRB.IntAttr.SolCount);

                lblOptimal.Text = "OPTIMAL";
                lblSolCount.Text = SolCount.ToString();                
                lblRuntime.Text = Math.Round(Runtime, 3).ToString();

                lblObjSol.Text = ObjSol.ToString();
                lblbound.Text = Bound.ToString();
                lblGap.Text = Gap.ToString();
                
            }
            else
            {

                lblInfeasible.Text = "INFEASIBLE";                
                lblRuntime.Text = Runtime.ToString();


            }
            //ALGORITHM ITERATION CHART
            double simplex = MyGlobals.model.Get(GRB.DoubleAttr.IterCount);
            int bar = MyGlobals.model.Get(GRB.IntAttr.BarIterCount);
            double barrier =  Convert.ToDouble(bar);
            double branchncut = MyGlobals.model.Get(GRB.DoubleAttr.NodeCount);

            
            Dictionary<string, double> DA = new Dictionary<string, double>();
            DA.Add("Simplex Iterations", simplex);
            DA.Add("Barrier Iterations", barrier);
            DA.Add("Branch-n-Cut Nodes", branchncut);
            
            // Create a chart.
            ChartControl chartControl2 = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series Series_Iteration = new Series("Series2", ViewType.Bar);
            chartControl2.Series.Add(Series_Iteration);

            // Bind chart to dictionary
            Series_Iteration.DataSource = new BindingSource(DA, null);

            // Specify data members to bind the series.
            Series_Iteration.ArgumentScaleType = ScaleType.Qualitative;
            Series_Iteration.ArgumentDataMember = "Key";
            Series_Iteration.ValueScaleType = ScaleType.Numerical;
            Series_Iteration.ValueDataMembers.AddRange(new string[] { "Value" });

            // Adjust the text pattern of the series label.
            BarSeriesLabel lbl = (BarSeriesLabel)Series_Iteration.Label;
            lbl.TextPattern = "{V:F1}";

            Legend legend = chartControl2.Legend;
            // Display the chart control's legend.
            legend.Visible = false;


            chartControl2.PaletteName = "Flow";
            chartControl2.PaletteBaseColorNumber = 0;

            // Dock the chart into its parent and add it to the current form.
            chartControl2.Dock = DockStyle.Fill;
            pnl_algo.Controls.Add(chartControl2);

            //COEFF STATS CHART
            double MAXCOEFF = MyGlobals.model.Get(GRB.DoubleAttr.MaxCoeff);
            double MINCOEFF = MyGlobals.model.Get(GRB.DoubleAttr.MinCoeff);
            double MAXBOUND = MyGlobals.model.Get(GRB.DoubleAttr.MaxBound);
            double MINBOUND = MyGlobals.model.Get(GRB.DoubleAttr.MinBound);
            double MAXOBJCOEFF = MyGlobals.model.Get(GRB.DoubleAttr.MaxObjCoeff);
            double MINOBJCOEFF = MyGlobals.model.Get(GRB.DoubleAttr.MinObjCoeff);            

            
            // Create a chart.
            ChartControl chartControl3 = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series Series_Coeff = new Series("Series3", ViewType.RangeBar);
            // Add points to them.
            Series_Coeff.Points.Add(new SeriesPoint("Matrix Coefficient", MAXCOEFF, MINCOEFF));
            Series_Coeff.Points.Add(new SeriesPoint("Variable Bound", MAXBOUND, MINBOUND));
            Series_Coeff.Points.Add(new SeriesPoint("Linear Obj Coefficient", MAXOBJCOEFF, MINOBJCOEFF));
            
            chartControl3.Series.Add(Series_Coeff);
            
            
            // Adjust the text pattern of the series label.
            RangeBarSeriesLabel lbl2 = (RangeBarSeriesLabel)Series_Coeff.Label;
            lbl2.TextPattern = "{V:F1}";

            // Hide the legend (if necessary).
            chartControl3.Legend.Visible = false;


            chartControl3.PaletteName = "Flow";
            chartControl3.PaletteBaseColorNumber = 0;

            // Dock the chart into its parent and add it to the current form.
            chartControl3.Dock = DockStyle.Fill;
            pnl_coeff.Controls.Add(chartControl3);




           


        }


        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}