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
    public partial class frmViewNimdone : Form
    {
        public frmViewNimdone()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int VNimDone()
        {
            int ndone = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblKNDone] where NoNDone  Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
                adp.Fill(dt);
                int cunt = dt.Rows.Count;           
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        ndone += Convert.ToInt32(dt.Rows[i]["WNDone"]);
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
            return  ndone ;
        }
        void NimDoneDGV()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblNDone where NoNDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%"); ;
            adp.Fill(ds, "tblNDone");
            dgvSabosDo.DataSource = ds;
            dgvSabosDo.DataMember = "tblNDone";
            dgvSabosDo.Columns[0].HeaderText = "کد";
            dgvSabosDo.Columns[0].Width = 30;
            dgvSabosDo.Columns[1].HeaderText = "وزن نیمدونه";
            dgvSabosDo.Columns[2].HeaderText = "قیمت هر کیلو";
            dgvSabosDo.Columns[3].HeaderText = "خریدار";
            dgvSabosDo.Columns[5].HeaderText = "مبلغ";
            dgvSabosDo.Columns[4].HeaderText = "فروشنده";
            dgvSabosDo.Columns[6].HeaderText = "تاریخ";
            dgvSabosDo.Columns[7].HeaderText = "توضیحات";
            dgvSabosDo.Columns[8].HeaderText = "نوع";
        }
        public int[] ViewMahsol()
        {
            int[] mahsol = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayMahsol where NoNDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int nimdone = 0;
            int done = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {

                    nimdone += Convert.ToInt32(dt.Rows[i]["WNimdone"]);
                    done += Convert.ToInt32(dt.Rows[i]["WDone"]);
                }
            }
            else
            {
            }



            mahsol[1] = nimdone;
            mahsol[0] = done;
            return mahsol;
        }
        public int[] ViewNimDone()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblNDone where NoNDone  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WNDone"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["NDoneMajmo"]);
                }
            }
            else
            {
            }


            report[0] = ndone;
            report[1] = majmo;
            return report;
        }
        private void frmViewNimdone_Load(object sender, EventArgs e)
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
                adp.SelectCommand.CommandText = "select * from PayMahsol where NoNDone  Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
                adp.Fill(dt);
                int KharidiNimDone = VNimDone();
                int cunt = dt.Rows.Count;
                int ndone = 0;
                int majmo = 0;
                if (cunt > 0 || KharidiNimDone>0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        ndone += Convert.ToInt32(dt.Rows[i]["WNimdone"]);
                    }
                }
                else
                {
                    MessageBox.Show("رکورد خالی می باشد");
                }
                lblNDoneKol.Text = ndone.ToString();
            int[] Mahsol = ViewMahsol();
            int[] NimDone = ViewNimDone();
            int NDoneMododAnbar = (Mahsol[1]+ KharidiNimDone) - NimDone[0];
            lblNDoneKol.Text = (Mahsol[1] + KharidiNimDone).ToString("N0");
            lblNDoneFrosh.Text = NimDone[0].ToString("N0");
            lblNDoneMojod.Text = NDoneMododAnbar.ToString("N0");
            NimDoneDGV();
            }
            catch (Exception)
            {
                MessageBox.Show("رکورد خالی می باشد");

            }

        }
    }
}
