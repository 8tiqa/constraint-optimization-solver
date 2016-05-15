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
    public partial class FrmAddCon : DevExpress.XtraEditors.XtraForm
    {
        public string sense;
        public double RHS;
        GRBVar term;

        //Form Constructor and Loader
        public FrmAddCon()
        {
            InitializeComponent();

            GRBVar[] allVar = MyGlobals.model.GetVars();
            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            { D.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]); }
            // Bind combobox to dictionary
            cmbVarName.DataSource = new BindingSource(D, null);
            cmbVarName.DisplayMember = "Key";
            cmbVarName.ValueMember = "Value";

            MyGlobals.obj.Clear();

            cmbSense.Items.Add("EQUAL");
            cmbSense.Items.Add("LESS EQUAL");
            cmbSense.Items.Add("GREATER EQUAL");
        }

        private void FrmAddCon_Load(object sender, EventArgs e)
        {

        }

        //Add LHS
        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            try
            {
                term = ((KeyValuePair<string, GRBVar>)cmbVarName.SelectedItem).Value;
                double coeff;
                double.TryParse(txtCoeff.Text, out coeff);


                MyGlobals.obj.AddTerm(coeff, term);
                btn_Undo.Enabled = true;

                lblConstraint.Text = lblConstraint.Text + " " + coeff + " " + term.Get(GRB.StringAttr.VarName) + " +";

            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }
            txtCoeff.Clear();
            
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            MyGlobals.obj.Remove(term);
            btn_Undo.Enabled = false;
        }

        //add sense
        private void cmbSense_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSense.Text = "";
            sense = this.cmbSense.GetItemText(this.cmbSense.SelectedItem);
            lblSense.Text = sense;
        }

        //add rhs
        private void btnAddRHS_Click(object sender, EventArgs e)
        {
            lblRHS.Text = "";
            Double.TryParse(txtRHS.Text, out RHS);
            lblRHS.Text = txtRHS.Text;
        }

        //add constraint by name
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string Cname = txtName.Text;
                string message = "Constraint " + Cname + " successfully added to the Model.";
                string caption = "Constraint Added";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                if (sense == "EQUAL")
                {
                    MyGlobals.model.AddConstr(MyGlobals.obj, GRB.EQUAL, RHS, Cname);
                    MessageBox.Show(message, caption, buttons);
                    MyGlobals.obj.Clear();
                }
                else if (sense == "LESS EQUAL")
                {
                    MyGlobals.model.AddConstr(MyGlobals.obj, GRB.LESS_EQUAL, RHS, Cname);
                    MessageBox.Show(message, caption, buttons);
                    MyGlobals.obj.Clear();
                }
                else if (sense == "GREATER EQUAL")
                {
                    MyGlobals.model.AddConstr(MyGlobals.obj, GRB.GREATER_EQUAL, RHS, Cname);
                    MessageBox.Show(message, caption, buttons);
                    MyGlobals.obj.Clear();
                }
                MyGlobals.model.Update();
                btnOptimize.Enabled = true;
                btn_Undo.Enabled = false;
                btnCancel.Enabled = false;
                btnOK.Enabled = true;
            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }
            txtCoeff.Clear();
            txtRHS.Clear();
            txtName.Clear();
            lblConstraint.Text = " ";
            lblSense.Text = " ";
            lblRHS.Text = " ";
            btnCancel.Enabled = false;
            btn_Undo.Enabled = false;


        }

        //clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            MyGlobals.obj.Clear();
            lblRHS.Text = "";
            lblSense.Text = "";
            lblConstraint.Text = "";
            txtCoeff.Text = "";
            txtName.Text = "";
            txtRHS.Text = "";
            btn_Undo.Enabled = false;
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new FrmAddObj();
            frm.Show();
            this.Close();
        }

        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        //ok -> close
        private void btnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Hide();            
            this.Close();
        }

        //Validation Checks   
        private void txtCoeff_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^-?[0-9]*(?:\.[0-9]*)?$");


            if (re.IsMatch(txtCoeff.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid Co-efficient. Please enter an integer value.");
                txtCoeff.Focus();
            }
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new FrmOptimize();
            frm.Show();
            this.Close();
        }

        private void cmbVarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCoeff.Text = "1";
        }



    }
}