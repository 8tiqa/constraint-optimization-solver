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
    public partial class FrmChangeCon : DevExpress.XtraEditors.XtraForm
    {
        GRBConstr constraint;
        GRBVar variable;
        public bool use_infinite_ub = false;

        //form load
        public FrmChangeCon()
        {
            InitializeComponent();           
            populate_cmbConstraint();

            //populate var_type combobox
            cmbVarType.Items.Add("BINARY");
            cmbVarType.Items.Add("CONTINUOUS");
            cmbVarType.Items.Add("INTERGER");
            cmbVarType.Items.Add("SEMI-CONTINUOUS");
            cmbVarType.Items.Add("SEMI-INTERGER");


            //populate sense combobox
            cmbSense.Items.Add("EQUAL");
            cmbSense.Items.Add("LESS EQUAL");
            cmbSense.Items.Add("GREATER EQUAL");
        }

        public void populate_cmbConstraint()
        {
            //Get all constraints 
            GRBConstr[] allCon = MyGlobals.model.GetConstrs();


            //populate dictionary
            Dictionary<string, GRBConstr> D = new Dictionary<string, GRBConstr>();
            String Conexp, co_name;
            Char co_sense;
            double co_RHS;
            GRBLinExpr con_info;

            for (int i = 0; i < allCon.Length; i++)
            {
                co_name = allCon[i].Get(GRB.StringAttr.ConstrName);
                co_sense = allCon[i].Get(GRB.CharAttr.Sense);
                co_RHS = allCon[i].Get(GRB.DoubleAttr.RHS);
                con_info = (GRBLinExpr)MyGlobals.model.GetRow(allCon[i]);

                Conexp = co_name + ": ";
                for (int n = 0; n < con_info.Size; n++)
                {
                    Conexp += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
                }
                Conexp += " " + co_sense + " " + co_RHS + "\n";

                D.Add(Conexp, allCon[i]);


            }
            // Bind combobox(add new var) to dictionary
            cmbCon.DataSource = new BindingSource(D, null);
            cmbCon.DisplayMember = "Key";
            cmbCon.ValueMember = "Value";

            // Bind combobox(edit var) to dictionary
            cmbCon2.DataSource = new BindingSource(D, null);
            cmbCon2.DisplayMember = "Key";
            cmbCon2.ValueMember = "Value";

            // Bind combobox(edit Sense) to dictionary
            cmbCon3.DataSource = new BindingSource(D, null);
            cmbCon3.DisplayMember = "Key";
            cmbCon3.ValueMember = "Value";

            // Bind combobox(edit RHS) to dictionary
            cmbCon4.DataSource = new BindingSource(D, null);
            cmbCon4.DisplayMember = "Key";
            cmbCon4.ValueMember = "Value";

            // Bind combobox(delete Var) to dictionary
            cmbCon5.DataSource = new BindingSource(D, null);
            cmbCon5.DisplayMember = "Key";
            cmbCon5.ValueMember = "Value";
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmChangeCon_Load(object sender, EventArgs e)
        {

        }

        

        //ADD NEW VARIABLE TO CONSTRAINT
        //Constraint is selected     
        private void cmbCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon.SelectedItem).Value;

            ///////////////////////////////////////////////////////////////////
            //display variables that are not in constraint already
            /*GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);
            GRBVar[] allVar = MyGlobals.model.GetVars();

            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            {
                for (int j = 0; j < con_info.Size; j++)
                {
                    if (allVar[i].Get(GRB.StringAttr.VarName) == con_info.GetVar(i).Get(GRB.StringAttr.VarName))
                        continue;

                    D.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]);
                }

            }*/
            GRBVar[] allVar = MyGlobals.model.GetVars();
            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            {
                D.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]);

            }
            // Bind combobox(add new var) to dictionary
            cmbAddVar.DataSource = new BindingSource(D, null);
            cmbAddVar.DisplayMember = "Key";
            cmbAddVar.ValueMember = "Value";
            ////////////////////////////////////////////////////////////////////

        }
        //Add variable
        private void btnUpdate_Click(object sender, EventArgs e) 
        {

            {
                try
                {
                    //change GRBConst into GRBConst[]
                    GRBConstr[] CON = new GRBConstr[1];
                    CON[0] = constraint;

                    double var_coco;
                    double.TryParse(txtAddCon.Text, out var_coco);
                    //change double into double[]
                    Double[] COEFF = new Double[1];
                    COEFF[0] = var_coco;

                    //add variable to constraint
                    MyGlobals.model.ChgCoeff(constraint, variable, var_coco);
                        

                    MyGlobals.model.Update();
                    populate_cmbConstraint();
                    BtnOK.Enabled = true;
                    BtnCancel.Enabled = false;

                    lblUpdate.Text = "";
                    lblUpdate.Text = constraint.Get(GRB.StringAttr.ConstrName) + ": ";

                    GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

                    for (int n = 0; n < con_info.Size; n++)
                    {
                        lblUpdate.Text += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
                    }
                    lblUpdate.Text += " " + constraint.Get(GRB.CharAttr.Sense) + " " + constraint.Get(GRB.DoubleAttr.RHS) + "\n";
                


                }
                catch (GRBException exc)
                {
                    MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

                }

            }
        }

        private void cmbAddVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbAddVar.SelectedItem).Value;
        }


        //Add brand new variable
        //upperbound infinty check
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
        //new variable is added to constraint
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string var_name = txtVarName.Text;
                string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);

                double var_lb, var_ub;
                double var_obco, var_coco;
                double.TryParse(txtlb.Text, out var_lb);
                double.TryParse(txtub.Text, out var_ub);
                double.TryParse(txtObCo.Text, out var_obco);
                double.TryParse(txtCo_coeff.Text, out var_coco);

                //change GRBConst into GRBConst[]
                GRBConstr[] CON = new GRBConstr[1];
                CON[0] = constraint;


                //change double into double[]
                Double[] COEFF = new Double[1];
                COEFF[0] = var_coco;

                GRBVar x;
                switch (var_type)
                {

                    case "BINARY":
                        if (use_infinite_ub == false)
                            x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, 'B', CON, COEFF, var_name);
                        else
                            x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, 'B', CON, COEFF, var_name);
                        break;


                    case "CONTINUOUS":
                        if (use_infinite_ub == false)
                            x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, 'C', CON, COEFF, var_name);
                        else
                            x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, 'C', CON, COEFF, var_name);
                        break;

                    case "INTERGER":
                        if (use_infinite_ub == false)
                            x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, 'I', CON, COEFF, var_name);
                        else
                            x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, 'I', CON, COEFF, var_name);
                        break;

                    case "SEMI-CONTINUOUS":
                        if (use_infinite_ub == false)
                            x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, 'S', CON, COEFF, var_name);
                        else
                            x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, 'S', CON, COEFF, var_name);
                        break;

                    case "SEMI-INTERGER":
                        if (use_infinite_ub == false)
                            x = MyGlobals.model.AddVar(var_lb, var_ub, var_obco, 'N', CON, COEFF, var_name);
                        else
                            x = MyGlobals.model.AddVar(var_lb, GRB.INFINITY, var_obco, 'N', CON, COEFF, var_name);
                        break;

                }
                MyGlobals.model.Update();
                populate_cmbConstraint();
                BtnOK.Enabled = true;
                BtnCancel.Enabled = false;

                lblUpdate.Text = "";
                lblUpdate.Text = constraint.Get(GRB.StringAttr.ConstrName) + ": ";               

                GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

                for (int n = 0; n < con_info.Size; n++)
                {
                    lblUpdate.Text += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
                }
                lblUpdate.Text += " " + constraint.Get(GRB.CharAttr.Sense) + " " + constraint.Get(GRB.DoubleAttr.RHS) + "\n";
                

            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }
            txtVarName.Clear();
            txtlb.Clear();
            txtub.Clear();
        }

        //EDIT VARIABLE
        private void cmbCon2_SelectedIndexChanged(object sender, EventArgs e)
        {

            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon2.SelectedItem).Value;
            GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            GRBVar var;
            for (int i = 0; i < con_info.Size; i++)
            {
                var = con_info.GetVar(i);
                D.Add(con_info.GetVar(i).Get(GRB.StringAttr.VarName), var);
            }


            // Bind combobox(add new var) to dictionary
            cmbVarName2.DataSource = new BindingSource(D, null);
            cmbVarName2.DisplayMember = "Key";
            cmbVarName2.ValueMember = "Value";



        }

        private void cmbVarName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbVarName2.SelectedItem).Value;
        }

        private void btn_Update2_Click(object sender, EventArgs e)
        {
            try
            {

                double var_coco;
                double.TryParse(txtCoeff2.Text, out var_coco);
                MyGlobals.model.ChgCoeff(constraint, variable, var_coco);


                MyGlobals.model.Update();
                populate_cmbConstraint();
                BtnOK.Enabled = true;
                BtnCancel.Enabled = false;

                lblUpdate2.Text = "";
                lblUpdate2.Text = constraint.Get(GRB.StringAttr.ConstrName) + ": ";               

                GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

                for (int n = 0; n < con_info.Size; n++)
                {
                    lblUpdate2.Text += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
                }
                lblUpdate2.Text += " " + constraint.Get(GRB.CharAttr.Sense) + " " + constraint.Get(GRB.DoubleAttr.RHS) + "\n";
                

            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }
            txtVarName.Clear();
            txtlb.Clear();
            txtub.Clear();
                                

        }

        // EDIT SENSE
        private void cmbCon3_SelectedIndexChanged(object sender, EventArgs e)
        {
            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon3.SelectedItem).Value;
        }

        private void btnUpdate_3_Click(object sender, EventArgs e)
        {
            string sense = this.cmbSense.GetItemText(this.cmbSense.SelectedItem);
            switch (sense)
            {
                case "EQUAL":
                    constraint.Set(GRB.CharAttr.Sense, '=');
                    break;
                case "LESS EQUAL":
                    constraint.Set(GRB.CharAttr.Sense, '<');
                    break;
                case "GREATER EQUAL":
                    constraint.Set(GRB.CharAttr.Sense, '>');
                    break;

            }

            //display constraint
            MyGlobals.model.Update();
            populate_cmbConstraint();
            BtnOK.Enabled = true;
            BtnCancel.Enabled = false;

            lblUpdate3.Text = "";
            lblUpdate3.Text = constraint.Get(GRB.StringAttr.ConstrName) + ": ";

            GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

            for (int n = 0; n < con_info.Size; n++)
            {
                lblUpdate3.Text += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
            }
            lblUpdate3.Text += " " + constraint.Get(GRB.CharAttr.Sense) + " " + constraint.Get(GRB.DoubleAttr.RHS) + "\n";
            
        }

        private void Tab_EditSense_Click(object sender, EventArgs e)
        {

        }

        //EDIT RHS
        private void cmbCon4_SelectedIndexChanged(object sender, EventArgs e)
        {
            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon4.SelectedItem).Value;
        }
        private void txtRHS_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtRHS.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid RHS. Please enter an integer value.");
                txtRHS.Focus();
            }
        }

        private void btnUpdate_4_Click(object sender, EventArgs e)
        {
            double RHS;
            double.TryParse(txtRHS.Text, out RHS);
            constraint.Set(GRB.DoubleAttr.RHS, RHS);


            MyGlobals.model.Update();
            populate_cmbConstraint();
            BtnOK.Enabled = true;
            BtnCancel.Enabled = false;

            lblUpdate4.Text = "";
            lblUpdate4.Text = constraint.Get(GRB.StringAttr.ConstrName) + ": ";

            GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

            for (int n = 0; n < con_info.Size; n++)
            {
                lblUpdate4.Text += " " + con_info.GetCoeff(n) + con_info.GetVar(n).Get(GRB.StringAttr.VarName) + " +";
            }
            lblUpdate4.Text += " " + constraint.Get(GRB.CharAttr.Sense) + " " + constraint.Get(GRB.DoubleAttr.RHS) + "\n";
            
        }



        //DELETE Variable
        private void cmbCon5_SelectedIndexChanged(object sender, EventArgs e)
        {
            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon5.SelectedItem).Value;
            GRBLinExpr con_info = (GRBLinExpr)MyGlobals.model.GetRow(constraint);

            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            GRBVar var;
            for (int i = 0; i < con_info.Size; i++)
            {
                var = con_info.GetVar(i);
                D.Add(con_info.GetVar(i).Get(GRB.StringAttr.VarName), var);
            }


            // Bind combobox(delete var) to dictionary
            cmbVarName3.DataSource = new BindingSource(D, null);
            cmbVarName3.DisplayMember = "Key";
            cmbVarName3.ValueMember = "Value";

        }

        private void cmbVarName3_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbVarName3.SelectedItem).Value;  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double coeff = 0;
            MyGlobals.model.ChgCoeff(constraint, variable, coeff);
            MyGlobals.model.Update();
            populate_cmbConstraint();
            BtnOK.Enabled = true;
            BtnCancel.Enabled = false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Hide();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void cmbSense_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void txtCo_coeff_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtCo_coeff.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Objective Coefficient. Please enter an integer value.");
                txtCo_coeff.Focus();
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

        private void cmbVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);
            if (var_type == "BINARY")
            {
                txtlb.Text = "0";
                txtub.Text = "1";


            }
        }
        
       







       

    }
}