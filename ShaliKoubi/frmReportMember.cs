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
    public partial class frmReportMember : Form
    {
        public frmReportMember()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int ID = -1;
        #region Method
        /// <summary>
        ///Hoghogh
        /// </summary>
        int Hoghogh()
        {
            int majmo = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblMember where mmbrID=" + ID;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
               
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        majmo = Convert.ToInt32(dt.Rows[i]["mmbrFee"]);
                    }

                }
                else
                {
                    MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {
                
            }
          
            return majmo;
        }

        int HoghoghDaryafti()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSalary where mmbrID=" + ID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["SalaryMablagh"]);
                }

            }
            else
            {
                MessageBox.Show("رکورد حقوق دریافتی خالی می باشد");
            }
            return majmo;
        }
        #endregion
        void DisplayNaghdi()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblSalary] where mmbrID=" + ID;
                adp.Fill(ds, "tblSalary");
                dgvSalary.DataSource = ds;
                dgvSalary.DataMember = "tblSalary";
                dgvSalary.Columns[0].Visible = false;
                dgvSalary.Columns[1].HeaderText = "کد پرسنلی";
                dgvSalary.Columns[1].Width = 50;
                dgvSalary.Columns[2].HeaderText = "مبلغ پرداختی";
                dgvSalary.Columns[2].Width = 120;
                dgvSalary.Columns[3].HeaderText = "تاریخ پرداخت";
                dgvSalary.Columns[3].Width = 133;
                dgvSalary.Columns[4].HeaderText = "نحوه پرداخت";
                dgvSalary.Columns[4].Width = 120;
                dgvSalary.Columns[5].HeaderText = "توضیحات";
                dgvSalary.Columns[5].Width = 300;
                dgvSalary.Columns[6].Visible = false;
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMember where mmbrName Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSName.Text + "%");
            adp.Fill(ds, "tblMember");
            dgvInSearch.DataSource = ds;
           
            dgvInSearch.DataMember = "tblMember";
            dgvInSearch.Columns["mmbrID"].HeaderText = "کد کارمندی";
            dgvInSearch.Columns["mmbrID"].Width = 50;
            dgvInSearch.Columns[1].HeaderText = " نام";
            dgvInSearch.Columns[1].Width = 70;
            dgvInSearch.Columns[2].HeaderText = "نام خانوادگی";
            dgvInSearch.Columns[2].Width = 90;
            dgvInSearch.Columns[3].HeaderText = "تلفن";
            dgvInSearch.Columns[4].HeaderText = "نوع قرارداد";
            dgvInSearch.Columns[5].HeaderText = "تاریخ شروع قرارداد";
            dgvInSearch.Columns[7].HeaderText = "آدرس";
            dgvInSearch.Columns[6].HeaderText = "نوع مشتری";

            dgvInSearch.Visible = true;
        }

        private void frmReportMember_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;

        }

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                con.Close();
                int indx = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                //labelX4.Text = indx.ToString();
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblMember where mmbrID=" + indx;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = dt.Rows[0][1].ToString();
                this.lblFam.Text = dt.Rows[0][2].ToString();
                this.lblID.Text = dt.Rows[0][0].ToString();
                con.Close();
                
                ID = indx;
                lblID.Text = indx.ToString();
                txtSID.Text = "";
                dgvInSearch.Visible = false;
                DisplayNaghdi();
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //Hoghogh
            int hoghogh = Hoghogh();
            lblHoghoghMahane.Text = hoghogh.ToString("N0");

            int Majmohoghogh = HoghoghDaryafti();
            lblPardakhtShode.Text = Majmohoghogh.ToString("N0");

            int TalabAzHoghogh = ((hoghogh * 12) - Majmohoghogh);
            lblTalab.Text= TalabAzHoghogh.ToString("N0");

            int Bedehkari = (Majmohoghogh-(hoghogh * 12));
            if (Bedehkari <0)
            {
                lblBedehkar.Text = "0";

            }
            else
            {
                lblBedehkar.Text=Bedehkari.ToString("N0");
            }

        }

        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMember where mmbrFam Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInFamSearch.Text + "%");
            adp.Fill(ds, "tblMember");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMember";
            dgvInSearch.Columns[1].HeaderText = " نام";
            dgvInSearch.Columns[1].Width = 70;
            dgvInSearch.Columns[2].HeaderText = "نام خانوادگی";
            dgvInSearch.Columns[2].Width = 90;
            dgvInSearch.Columns[3].HeaderText = "تلفن";
            dgvInSearch.Columns[4].HeaderText = "نوع قرارداد";
            dgvInSearch.Columns[5].HeaderText = "تاریخ شروع قرارداد";
            dgvInSearch.Columns[7].HeaderText = "آدرس";
            dgvInSearch.Columns[6].HeaderText = "نوع مشتری";
            dgvInSearch.Visible = true;
        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMember where mmbrID Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblMember");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMember";
            dgvInSearch.Columns[1].HeaderText = " نام";
            dgvInSearch.Columns[1].Width = 70;
            dgvInSearch.Columns[2].HeaderText = "نام خانوادگی";
            dgvInSearch.Columns[2].Width = 90;
            dgvInSearch.Columns[3].HeaderText = "تلفن";
            dgvInSearch.Columns[4].HeaderText = "نوع قرارداد";
            dgvInSearch.Columns[5].HeaderText = "تاریخ شروع قرارداد";
            dgvInSearch.Columns[7].HeaderText = "آدرس";
            dgvInSearch.Columns[6].HeaderText = "نوع مشتری";
            dgvInSearch.Visible = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {

            txtInFamSearch.Text = "";
            txtSName.Text = "";
            txtSID.Text = "";
            dgvInSearch.Visible = false;
        }

        private void dgvSalary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvSalary.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmKargarMotfareghe().ShowDialog();
        }
    }
}
