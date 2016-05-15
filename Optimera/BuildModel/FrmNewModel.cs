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
    public partial class FrmNewModel : DevExpress.XtraEditors.XtraForm
    {
        public FrmNewModel()
        {
            InitializeComponent();
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            MyGlobals.model.Dispose();
            MyGlobals.env.Dispose();

            MyGlobals.env = new GRBEnv();
            // GRBEnv env = new GRBEnv("firstapp.log");
            MyGlobals.model = new GRBModel(MyGlobals.env);


            string model_name = txtName.Text;
            MyGlobals.model.Set(GRB.StringAttr.ModelName, model_name);


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

        private void FrmNewModel_Load(object sender, EventArgs e)
        {

        }
    }
}