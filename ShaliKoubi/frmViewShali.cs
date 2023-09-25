using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaliKoubi
{
    public partial class frmViewShali : Form
    {
        public frmViewShali()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
       
      
        void NimDoneDGV()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKShali where NoShali  Like '%' + @s + '%' and Bes="+1;
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%"); ;
            adp.Fill(ds, "tblKShali");
            dgvSabosDo.DataSource = ds;
            dgvSabosDo.DataMember = "tblKShali";
            dgvSabosDo.Columns[0].HeaderText = "کد";
            dgvSabosDo.Columns[0].Width = 30;
            dgvSabosDo.Columns[1].HeaderText = "وزن شالی";
            dgvSabosDo.Columns[2].HeaderText = "قیمت هر کیلو";
            dgvSabosDo.Columns[3].HeaderText = "خریدار";
            dgvSabosDo.Columns[5].HeaderText = "مبلغ";
            dgvSabosDo.Columns[4].HeaderText = "فروشنده";
            dgvSabosDo.Columns[6].HeaderText = "تاریخ";
            dgvSabosDo.Columns[7].HeaderText = "توضیحات";
            dgvSabosDo.Columns[8].HeaderText = "نوع";
            dgvSabosDo.Columns["Bed"].Visible = false;
            dgvSabosDo.Columns["Bes"].Visible = false;
        }

        public int GetWShaliKharidariShode()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKShali where NoShali  Like '%' + @s + '%' and Bed="+1;
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WShali"]);
                }
            }
            else
            {
            }
            return ndone;
        }
        public int GetWShaliForoshRafte()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKShali where NoShali  Like '%' + @s + '%' and Bes=" + 1;
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WShali"]);
                }
            }
            else
            {
            }
            return ndone;
        }
        private void frmViewShali_Load(object sender, EventArgs e)
        {
            mt.DisplayCombo(cmbBerenjNo);
            lblNDoneKol.Text = GetWShaliKharidariShode().ToString("N0");
            lblNDoneFrosh.Text = GetWShaliForoshRafte().ToString("N0");
            lblNDoneMojod.Text=(GetWShaliKharidariShode()- GetWShaliForoshRafte()).ToString("N0");
            NimDoneDGV();
           
        }

        private void cmbBerenjNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNDoneKol.Text = GetWShaliKharidariShode().ToString("N0");
            lblNDoneFrosh.Text = GetWShaliForoshRafte().ToString("N0");
            lblNDoneMojod.Text = (GetWShaliKharidariShode() - GetWShaliForoshRafte()).ToString("N0");
            NimDoneDGV();
        }
    }
}
