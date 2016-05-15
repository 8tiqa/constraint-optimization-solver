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
    public partial class FrmDeleteVar : DevExpress.XtraEditors.XtraForm
    {
        GRBVar variable;
        public FrmDeleteVar()
        {
            InitializeComponent();
            populate_cmbVariable();

        }
        public void populate_cmbVariable()
        {
            //VarNames
            GRBVar[] allVar = MyGlobals.model.GetVars();
            Dictionary<string, GRBVar> D = new Dictionary<string, GRBVar>();
            for (int i = 0; i < allVar.Length; i++)
            {
                D.Add(allVar[i].Get(GRB.StringAttr.VarName), allVar[i]);

            }
            // Bind combobox to dictionary
            cmbVarName.DataSource = new BindingSource(D, null);
            cmbVarName.DisplayMember = "Key";
            cmbVarName.ValueMember = "Value";
        }
        private void FrmDeleteVar_Load(object sender, EventArgs e)
        {

        }

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

            cmbVarType.Enabled = false;

            double var_lb = variable.Get(GRB.DoubleAttr.LB);
            txtlb.Text = var_lb.ToString();
            txtlb.Enabled = false;

            double var_ub = variable.Get(GRB.DoubleAttr.UB);
            txtub.Text = var_ub.ToString();
            txtub.Enabled = false;

            double var_obcoeff = variable.Get(GRB.DoubleAttr.Obj);
            txtObCo.Text = var_obcoeff.ToString();
            txtObCo.Enabled = false;

            lblVar.Text = "";
            GRBColumn Constraints = MyGlobals.model.GetCol(variable);
            for (int i = 0; i < Constraints.Size; i++)
            {
                lblVar.Text = lblVar.Text + "\nIn Constraint " + Constraints.GetConstr(i).Get(GRB.StringAttr.ConstrName) + " with Coefficient " + Constraints.GetCoeff(i);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this variable?", "", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                MyGlobals.model.Remove(variable);
                MyGlobals.model.Update();
                MessageBox.Show("Variable deleted.");
                lblVar.Text = "";
                populate_cmbVariable();
                btnOK.Enabled = true;


            }
        }



    }
}