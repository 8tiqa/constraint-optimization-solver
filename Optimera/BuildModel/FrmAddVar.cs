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
using Gurobi;
using System.Text.RegularExpressions;

namespace Optimera
{
    public partial class FrmAddVar : DevExpress.XtraEditors.XtraForm
    {
        public bool use_infinite_ub = false;
        //form constructor
        public FrmAddVar()
        {
            InitializeComponent();
            cmbVarType.Items.Add("BINARY");
            cmbVarType.Items.Add("CONTINUOUS");
            cmbVarType.Items.Add("INTERGER");
            cmbVarType.Items.Add("SEMI-CONTINUOUS");
            cmbVarType.Items.Add("SEMI-INTERGER");

            cmbVarType.Text = "BINARY";
            txtObCo.Text = "0";
            txtlb.Text = "0";
            txtub.Text = "1";
        }

        private void FrmAddVar_Load(object sender, EventArgs e)
        {
            //VarNames
            lblVar.Text = "";
            GRBVar[] allVar = MyGlobals.model.GetVars();
            for (int i = 0; i < allVar.Length; i++)
            {
                lblVar.Text = lblVar.Text + "\n" + allVar[i].Get(GRB.DoubleAttr.LB) + " > " + allVar[i].Get(GRB.StringAttr.VarName) + " > " + allVar[i].Get(GRB.DoubleAttr.UB);

            }            
        }

        //validation checks onf inputfields
        private void txtlb_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtlb.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid lowerbound. Please enter an integer value.");
                txtlb.Focus();
            }
        }

        private void txtub_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtub.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid upperbound. Please enter an integer value.");
                txtub.Focus();
            }
        }

        private void txtObCo_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtObCo.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Objective Coefficient. Please enter an integer value.");
                txtObCo.Focus();
            }
        }

        private void cmbVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);
            if (var_type == "BINARY")
            {
                txtlb.Text = "0";
                txtub.Text = "1";


            }
        }

        private void chkInfinite_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInfinite.Checked == true)
            {
                use_infinite_ub = true;
                txtub.Enabled = false;
            }
            else
            {
                use_infinite_ub = false;
                txtub.Enabled = true;
            }
        }

        //Add variable to model
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string var_name = txtVarName.Text;
                string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);

                double var_lb, var_ub;
                double var_obco;
                double.TryParse(txtlb.Text, out var_lb);
                double.TryParse(txtub.Text, out var_ub);
                double.TryParse(txtObCo.Text, out var_obco);

                //input check
                if (var_name != "")
                {
                    GRBVar x;
                    switch (var_type)
                    {

                        case "BINARY":
                            if (use_infinite_ub == false)
                            {
                                x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, GRB.BINARY, var_name);
                            }
                            else
                                x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, GRB.BINARY, var_name);
                            break;

                        case "CONTINUOUS":
                            if (use_infinite_ub == false)
                            {
                                x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, GRB.CONTINUOUS, var_name);
                            }
                            else
                                x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, GRB.CONTINUOUS, var_name);

                            break;

                        case "INTERGER":
                            if (use_infinite_ub == false)
                            {
                                x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, GRB.INTEGER, var_name);

                            }
                            else
                                x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, GRB.INTEGER, var_name);
                            break;

                        case "SEMI-CONTINUOUS":
                            if (use_infinite_ub == false)
                            {
                                x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, GRB.SEMICONT, var_name);

                            }
                            else
                                x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, GRB.SEMICONT, var_name);
                            break;
                        case "SEMI-INTERGER":
                            if (use_infinite_ub == false)
                            {
                                x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, GRB.SEMIINT, var_name);

                            }
                            else
                                x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, GRB.SEMIINT, var_name);
                            break;
                    }
                    MyGlobals.model.Update();

                    //display variables
                    lblVar.Text = "";
                    GRBVar[] allVar = MyGlobals.model.GetVars();
                    for (int i = 0; i < allVar.Length; i++)
                    {
                        lblVar.Text = lblVar.Text + "\n" + allVar[i].Get(GRB.DoubleAttr.LB) + " > " + allVar[i].Get(GRB.StringAttr.VarName) + " > " + allVar[i].Get(GRB.DoubleAttr.UB);

                    }
                    //enable add objective
                    btnNext.Enabled = true;
                    btnCancel.Enabled = false;
                    

                }
                else
                    MessageBox.Show("You have not specified any variable name.");


            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }
            txtVarName.Clear();
            txtlb.Clear();
            txtub.Clear();
        }

        //direct to addobjective
        private void btnNext_Click(object sender, EventArgs e)
        {           
            if (MyGlobals.model.GetVars().Length >= 1)
            {
                MyGlobals.model.Update();
                this.Hide();
                Form frm = new FrmAddObj();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You have not added any variables!");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Hide();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        


    }
}