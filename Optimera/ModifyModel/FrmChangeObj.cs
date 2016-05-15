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
using System.Text.RegularExpressions;
using Gurobi;

namespace Optimera
{
    public partial class FrmChangeObj : DevExpress.XtraEditors.XtraForm
    {
        GRBVar variable;
        public bool use_infinite_ub = false;

        //form constructor
        public FrmChangeObj()
        {
            InitializeComponent();
            populate_lblObj();

            //populate var_type combobox
            cmbVarType.Items.Add("BINARY");
            cmbVarType.Items.Add("CONTINUOUS");
            cmbVarType.Items.Add("INTERGER");
            cmbVarType.Items.Add("SEMI-CONTINUOUS");
            cmbVarType.Items.Add("SEMI-INTERGER");


            //populate sense combobox
            cmbSense.Items.Add("MINIMIZE");
            cmbSense.Items.Add("MAXIMIZE");

           


            
            
        }


        //updates objective and variable
        public void populate_lblObj()
        {
            lblObj.Text = "";
            MyGlobals.model.Update();

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
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            for (int i = 0; i < func.Size; i++)
            {
                lblObj.Text = lblObj.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
            }            

            //populate variables present in obj
            GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetObjective();

            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            GRBVar var;
            for (int i = 0; i < con_info.Size; i++)
            {
                var = con_info.GetVar(i);
                D.Add(con_info.GetVar(i).Get(GRB.StringAttr.VarName), var);
            }
            // Bind combobox(edit var) to dictionary
            cmbVarName2.DataSource = new BindingSource(D, null);
            cmbVarName2.DisplayMember = "Key";
            cmbVarName2.ValueMember = "Value";

            // Bind combobox(delet var) to dictionary
            cmbVarName3.DataSource = new BindingSource(D, null);
            cmbVarName3.DisplayMember = "Key";
            cmbVarName3.ValueMember = "Value";

            //populate all variables combobox addvar
            GRBVar[] allVar = MyGlobals.model.GetVars();
            Dictionary<string, GRBVar> D2 = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            {
                D2.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]);

            }
            // Bind combobox(add new var) to dictionary
            cmbAddVar.DataSource = new BindingSource(D2, null);
            cmbAddVar.DisplayMember = "Key";
            cmbAddVar.ValueMember = "Value";


        }

        private void FrmChangeObj_Load(object sender, EventArgs e)
        {

        }

        

        //create and add variable
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
                    populate_lblObj();
                    BtnOK.Enabled = true;
                    BtnCancel.Enabled = false;
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

        //validation checks
        private void txtObCo_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtObCo.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Objective Coefficient. Please enter an integer value.");
                txtObCo.Focus();
            }
        }

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

        // add variable
        private void cmbAddVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbAddVar.SelectedItem).Value;
            txtCoeff_addvar.Text = "1";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double var_coeff;
            double.TryParse(txtCoeff_addvar.Text, out var_coeff);
            variable.Set(GRB.DoubleAttr.Obj, var_coeff);

            MyGlobals.model.Update();
            populate_lblObj();


            BtnCancel.Enabled = false;
            BtnOK.Enabled = true;
        }

        private void txtCoeff_addvar_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtCoeff_addvar.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Objective Coefficient. Please enter an integer value.");
                txtCoeff_addvar.Focus();
            }
        }

        //Edit variable
        private void cmbVarName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbVarName2.SelectedItem).Value;
            double var_obcoeff = variable.Get(GRB.DoubleAttr.Obj);
            txtCoeff2.Text = var_obcoeff.ToString();

            
        }

        private void txtCoeff2_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtCoeff2.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Objective Coefficient. Please enter an integer value.");
                txtCoeff2.Focus();
            }
        }

        private void btn_Update2_Click(object sender, EventArgs e)
        {
            double var_coeff;
            double.TryParse(txtCoeff2.Text, out var_coeff);
            variable.Set(GRB.DoubleAttr.Obj, var_coeff);

            MyGlobals.model.Update();
            populate_lblObj();

            BtnCancel.Enabled = false;
            BtnOK.Enabled = true;
        }

        //Delete variable
        private void cmbVarName3_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbVarName3.SelectedItem).Value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double var_coeff = 0.0;
            variable.Set(GRB.DoubleAttr.Obj, var_coeff);


            MyGlobals.model.Update();
            populate_lblObj();


            BtnCancel.Enabled = false;
            BtnOK.Enabled = true;
        }

        private void cmbSense_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_3_Click(object sender, EventArgs e)
        {
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();
            string sense = this.cmbSense.GetItemText(this.cmbSense.SelectedItem);          
            
            try
            {
                if (sense == "MAXIMIZE")
                {
                    MyGlobals.model.Set(GRB.IntAttr.ModelSense, GRB.MAXIMIZE);                    
                }

                else if (sense == "MINIMIZE")
                {
                    MyGlobals.model.Set(GRB.IntAttr.ModelSense, GRB.MINIMIZE);      

                }
                MyGlobals.model.Update();
                populate_lblObj();

                BtnCancel.Enabled = false;
                BtnOK.Enabled = true;
            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }

        }

        private void cmbVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObCo.Text = "1";
            string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);
            if (var_type == "BINARY")
            {
                txtlb.Text = "0";
                txtub.Text = "1";


            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Hide();
            this.Close();
        }
    }
}