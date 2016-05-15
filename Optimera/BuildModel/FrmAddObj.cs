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
    public partial class FrmAddObj : DevExpress.XtraEditors.XtraForm
    {
        public string sense;
        GRBVar term;
        //Form Constructor
        public FrmAddObj()
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

            cmbSense.Items.Add("Minimize");
            cmbSense.Items.Add("Maximize");
        }

        public void if_obj_loaded()
        {
            //IF OBJ IS ALREADY SET
            int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if ((int_sense == -1) || (int_sense == 1))
            {
                if (func.Size != 0)
                {
                    lblObj.Text = "";
                    lblSense.Text = "";

                    if (int_sense == -1)
                    {
                        lblSense.Text = "MAXIMIZE";
                        cmbSense.Text = "MAXIMIZE";
                    }
                    else if (int_sense == 1)
                    {
                        lblSense.Text = "MINIMIZE";
                        cmbSense.Text = "MINIMIZE";
                    
                    }


                    for (int i = 0; i < func.Size; i++)
                    {
                        lblObj.Text = lblObj.Text + " " + func.GetCoeff(i) + func.GetVar(i).Get(GRB.StringAttr.VarName) + " +";
                    }
                    cmbSense.Enabled = false;
                    cmbVarName.Enabled = false;
                    txtCoeff.Enabled = false;
                    btn_Undo.Enabled = false;
                    button7.Enabled = false;
                    btnClear.Enabled = false;
                    btnAddTerm.Enabled = false;
                    btnOK.Enabled = true;
                    btnNext.Enabled = true;
                }
            }
        }

        private void FrmAddObj_Load(object sender, EventArgs e)
        {
            if_obj_loaded();
        }

        //Add term(s)
        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            try
            {
                term = ((KeyValuePair<string, GRBVar>)cmbVarName.SelectedItem).Value;

                double coeff;
                double.TryParse(txtCoeff.Text, out coeff);

                MyGlobals.obj.AddTerm(coeff, term);

                lblObj.Text = lblObj.Text + " " + coeff + " " + term.Get(GRB.StringAttr.VarName) + " +";
                btn_Undo.Enabled = true;

            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }

            txtCoeff.Clear();
        }

        //Add Sense
        private void cmbSense_SelectedIndexChanged(object sender, EventArgs e)
        {
            sense = this.cmbSense.GetItemText(this.cmbSense.SelectedItem);
            lblSense.Text = sense;
           
        }

        //Clear and undo
        private void btnClear_Click(object sender, EventArgs e)
        {
            MyGlobals.obj.Clear();
            lblObj.Text = "";
            lblSense.Text = "";
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            MyGlobals.obj.Remove(term);
            btn_Undo.Enabled = false;
        }

        //Save Obj
        private void button7_Click(object sender, EventArgs e)
        {
            string message = "Objective Function successfully added to the Model.";
            string caption = "Objective Function Added";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            try
            {
                if (sense == "Maximize")
                {
                    MyGlobals.model.SetObjective(MyGlobals.obj, GRB.MAXIMIZE);
                    MessageBox.Show(message, caption, buttons);
                    MyGlobals.obj.Clear();
                    lblObj.Text = "";
                    lblSense.Text = "";
                }
                else if (sense == "Minimize")
                {
                    MyGlobals.model.SetObjective(MyGlobals.obj, GRB.MINIMIZE);
                    MessageBox.Show(message, caption, buttons);
                    MyGlobals.obj.Clear();
                    lblObj.Text = "";
                    lblSense.Text = "";
                }
            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }

            MyGlobals.model.Update();
            if_obj_loaded();
            btnCancel.Enabled = false;
            btnOK.Enabled = true;
            btnNext.Enabled = true;
        }

        private void txtCoeff_TextChanged(object sender, EventArgs e)
        {
            Regex re = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            if (re.IsMatch(txtCoeff.Text.Trim()) == false)
            {
                MessageBox.Show("Invalid upperbound. Please enter an integer value.");
                txtCoeff.Focus();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int int_sense = MyGlobals.model.Get(GRB.IntAttr.ModelSense);
            GRBLinExpr func = (GRBLinExpr)MyGlobals.model.GetObjective();

            if ((int_sense == -1) || (int_sense == 1))
            {
                if (func.Size != 0)
                {
                    this.Hide();
                    Form frm = new FrmAddCon();
                    frm.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
            }
            else
                MessageBox.Show("Your Objective Function is not initialized. \nPlease build your model.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new FrmAddVar();
            frm.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Hide();
            this.Close();
        }

        private void cmbVarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCoeff.Text = "1";
        }
  

    }
}