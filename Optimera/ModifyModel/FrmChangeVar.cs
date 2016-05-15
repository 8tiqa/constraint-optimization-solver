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

namespace Optimera
{
    public partial class FrmChangeVar : DevExpress.XtraEditors.XtraForm
    {
        public bool use_infinite_ub = false;
        GRBVar variable;

        //Form Constructor & Loader
        public FrmChangeVar()
        {
            InitializeComponent();
            //VarNames
            GRBVar[] allVar = MyGlobals.model.GetVars();
            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            {
                D.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]);
                lblVar.Text = lblVar.Text + "\n" + allVar[i].Get(GRB.DoubleAttr.LB) + " > " + allVar[i].Get(GRB.StringAttr.VarName) + " > " + allVar[i].Get(GRB.DoubleAttr.UB);

            }
            // Bind combobox to dictionary
            cmbVarName.DataSource = new BindingSource(D, null);
            cmbVarName.DisplayMember = "Key";
            cmbVarName.ValueMember = "Value";

            //VarType
            cmbVarType.Items.Add("BINARY");
            cmbVarType.Items.Add("CONTINUOUS");
            cmbVarType.Items.Add("INTERGER");
            cmbVarType.Items.Add("SEMI-CONTINUOUS");
            cmbVarType.Items.Add("SEMI-INTERGER");

            
        }

        private void FrmChangeVar_Load(object sender, EventArgs e)
        {

        }

        //populating fields on variable selection
        private void cmbVarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = ((KeyValuePair<string, GRBVar>)cmbVarName.SelectedItem).Value;

            char var_type = variable.Get(GRB.CharAttr.VType);
            switch (var_type)
            {
                case 'C':
                    cmbVarType.Text = "CONTINUOUS";
                    break;
                case 'B':
                    cmbVarType.Text = "BINARY";
                    break;
                case 'I':
                    cmbVarType.Text = "INTEGER";
                    break;
                case 'S':
                    cmbVarType.Text = "SEMI-CONTINUOUS";
                    break;
                case 'N':
                    cmbVarType.Text = "SEMI-INTEGER";
                    break;
            }

            double var_lb = variable.Get(GRB.DoubleAttr.LB);
            txtlb.Text = var_lb.ToString();

            double var_ub = variable.Get(GRB.DoubleAttr.UB);
            txtub.Text = var_ub.ToString();

            double var_obcoeff = variable.Get(GRB.DoubleAttr.Obj);
            txtObCo.Text = var_obcoeff.ToString();
        }
        //populating fields on infinity upper bound selection 
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
        //updating changes to variable
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                string var_type = this.cmbVarType.GetItemText(this.cmbVarType.SelectedItem);
                string var_name = variable.Get(GRB.StringAttr.VarName);
                double var_lb, var_ub;
                double var_obco;
                double.TryParse(txtlb.Text, out var_lb);
                double.TryParse(txtub.Text, out var_ub);
                double.TryParse(txtObCo.Text, out var_obco);


                switch (var_type)
                {

                    case "BINARY":
                        if (use_infinite_ub == false)
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, var_ub);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'B');
                        }
                        else
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, GRB.INFINITY);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'B');
                        }
                        break;

                    case "CONTINUOUS":
                        if (use_infinite_ub == false)
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, var_ub);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'C');
                        }
                        else
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, GRB.INFINITY);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'C');
                        }
                        break;

                    case "INTERGER":
                        if (use_infinite_ub == false)
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, var_ub);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'I');
                        }
                        else
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, GRB.INFINITY);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'I');
                        }
                        break;

                    case "SEMI-CONTINUOUS":
                        if (use_infinite_ub == false)
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, var_ub);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'S');
                        }
                        else
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, GRB.INFINITY);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'S');
                        }
                        break;
                    case "SEMI-INTERGER":
                        if (use_infinite_ub == false)
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, var_ub);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'N');
                        }
                        else
                        {
                            variable.Set(GRB.DoubleAttr.LB, var_lb);
                            variable.Set(GRB.DoubleAttr.UB, GRB.INFINITY);
                            variable.Set(GRB.DoubleAttr.Obj, var_obco);
                            variable.Set(GRB.CharAttr.VType, 'N');
                        }
                        break;
                }
                MyGlobals.model.Update();
                lblVar.Text = "";
                GRBVar[] allVar = MyGlobals.model.GetVars();
                for (int i = 0; i < allVar.Length; i++)
                {
                    lblVar.Text = lblVar.Text + "\n" + allVar[i].Get(GRB.DoubleAttr.LB) + " > " + allVar[i].Get(GRB.StringAttr.VarName) + " > " + allVar[i].Get(GRB.DoubleAttr.UB);

                }
                BtnOK.Enabled = true;

            }
            catch (GRBException exc)
            {
                MessageBox.Show("Error code: " + exc.ErrorCode + ". " + exc.Message, "Error occured", MessageBoxButtons.OK);

            }


            txtlb.Clear();
            txtub.Clear();
            txtObCo.Clear();
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

      

    }
}