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
using System.IO;
using Gurobi;

namespace Optimera
{
    public partial class FrmOpenModel_LPFile : DevExpress.XtraEditors.XtraForm
    {
        public FrmOpenModel_LPFile()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Model Files (LP)|*.LP";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                //Dispose previous model
                MyGlobals.model.Dispose();
                MyGlobals.env.Dispose();

                lblFilename.Text = "";
                lblObjective.Text = "";
                lblVar.Text = "";
                lblCon.Text = "";


                MyGlobals.env = new GRBEnv();
                MyGlobals.model = new GRBModel(MyGlobals.env, openFileDialog1.FileName);
                btn_Optimize.Enabled = true;

                if (ext == ".lp")
                {

                    lblFilename.Text = openFileDialog1.FileName;


                    //objective function
                    int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
                    if (int_sense == -1)
                    {
                        lblObjective.Text = "MAXIMIZE";
                    }
                    else
                    {
                        lblObjective.Text = "MINIMIZE";
                    }
                    GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

                    for (int i = 0; i < func.Size; i++)
                    {
                        lblObjective.Text = lblObjective.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
                    }

                    //variables
                    GRBVar[] allVars = MyGlobals.model.GetVars();
                    int n;
                    for (n = 0; n < allVars.Length; n++)
                    {
                        lblVar.Text += allVars[n].Get(GRB.StringAttr.VarName) + ", ";
                    }

                    //constraints
                    GRBLinExpr con_info;
                    GRBConstr[] allCons = MyGlobals.model.GetConstrs();
                    string co_name;
                    char co_sense;
                    double co_RHS;

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
                    MessageBox.Show("The File is not LP.");
                    MyGlobals.model.Dispose();
                    MyGlobals.env.Dispose();

                }


            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Dispose previous model
            MyGlobals.model.Dispose();
            MyGlobals.env.Dispose();
            this.Close();

        }

        private void btn_Optimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new FrmOptimize();
            frm.Show();
            this.Close();
        }
    }
}