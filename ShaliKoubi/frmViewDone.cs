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
    public partial class frmViewDone : Form
    {
        public frmViewDone()
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
            adp.SelectCommand.CommandText = "select * from tblDone where NoDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%"); ;
            adp.Fill(ds, "tblDone");
            dgvSabosDo.DataSource = ds;
            dgvSabosDo.DataMember = "tblDone";
            dgvSabosDo.Columns[0].HeaderText = "کد";
            dgvSabosDo.Columns[0].Width = 30;
            dgvSabosDo.Columns[1].HeaderText = "وزن برنج";
            dgvSabosDo.Columns[2].HeaderText = "قیمت هر کیلو";
            dgvSabosDo.Columns[3].HeaderText = "خریدار";
            dgvSabosDo.Columns[5].HeaderText = "مبلغ";
            dgvSabosDo.Columns[4].HeaderText = "فروشنده";
            dgvSabosDo.Columns[6].HeaderText = "تاریخ";
            dgvSabosDo.Columns[7].HeaderText = "توضیحات";
            dgvSabosDo.Columns[8].HeaderText = "نوع";
        }
        public int ViewMahsol()
        {
            int mahsol;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayMahsol where NoDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int done = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    done += Convert.ToInt32(dt.Rows[i]["WDone"]);
                }
            }
            else
            {
            }




            mahsol = done;
            return mahsol;
        }
        public int ViewDone()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblDone where NoDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WDone"]);
                }
            }
            else
            {
            }
            return ndone;
        }
        int VDone()
        {
            int ndone = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblKDone] where NoDone  Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
                adp.Fill(dt);

                int cunt = dt.Rows.Count;

                int majmo = 0;
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        ndone += Convert.ToInt32(dt.Rows[i]["WDone"]);
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("رکورد خالی می باشد");
            }

            return ndone;
        }
        private void frmViewDone_Load(object sender, EventArgs e)
        {
            mt.DisplayCombo(cmbBerenjNo);
        }
        private void cmbBerenjNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNDoneKol.Text = "";
            lblNDoneMojod.Text = "";
            lblNDoneFrosh.Text = "";

            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from PayMahsol where NoDone  Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
                 adp.Fill(dt);
                int DoneKharidi = VDone();
                int cunt = dt.Rows.Count;
                int ndone = 0;
                if (cunt > 0 || DoneKharidi>0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        ndone += Convert.ToInt32(dt.Rows[i]["WDone"]);
                    }
                }
                else
                {
                    MessageBox.Show("رکورد خالی می باشد");
                }
                int Mahsol = ViewMahsol();
                int Done = ViewDone();
                int NDoneMododAnbar = (Mahsol + DoneKharidi) - Done;
                lblNDoneKol.Text = (Mahsol + DoneKharidi).ToString("N0");
                lblNDoneFrosh.Text = Done.ToString("N0");
                lblNDoneMojod.Text = ((NDoneMododAnbar) - Done).ToString("N0");
                NimDoneDGV();
                }
            catch (Exception)
            {
                MessageBox.Show("رکورد خالی می باشد");
            }
        }
    }
}
