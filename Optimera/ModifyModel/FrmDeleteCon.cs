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
    public partial class FrmDeleteCon : DevExpress.XtraEditors.XtraForm
    {
        GRBConstr constraint;
        public FrmDeleteCon()
        {
            InitializeComponent();
            populate_cmbDeleteConstraint();

        }

        public void populate_cmbDeleteConstraint()
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
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmDeleteCon_Load(object sender, EventArgs e)
        {

        }

        private void cmbCon_SelectedIndexChanged(object sender, EventArgs e)
        {
            constraint = ((KeyValuePair<string, GRBConstr>)cmbCon.SelectedItem).Value;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Are you sure you want to delete this Constraint?", "", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                MyGlobals.model.Remove(constraint);
                MyGlobals.model.Update();
                MessageBox.Show("Constraint deleted.");
                populate_cmbDeleteConstraint();
            }
            btn_OK.Enabled = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Update();
            this.Close();
        }
    }
}