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
    public partial class frmConrolAnbar : Form
    {
        public frmConrolAnbar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        int CstmID = -1;
        int ProcessID = -1;
        DataTable GetMahsol(int id)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select distinct * from tblCstmr as cstmr inner join  View_New_customerToHesab  as b on cstmr.id=b.CstmrID where CstmrID=N'" + id + "'";
            dt = tc.ExecuteReader();
            return dt;
        }
        public void AddButton()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "خروج";
            btn.Name = "btnTasvie";
            btn.Text = "خروج";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 50;
            dgvAnbar.Columns.Add(btn);
        }
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_New_customerToHesab where Id=" + CstmID;
            adp.Fill(ds, "View_New_customerToHesab");
            dgvAnbar.DataSource = ds;

            dgvAnbar.DataMember = "View_New_customerToHesab";

            //************************************

            dgvAnbar.Columns["ProcessID"].Visible = false;
            dgvAnbar.Columns["OutputID"].Visible = false;
            dgvAnbar.Columns["CstmrID"].Visible = false;
            dgvAnbar.Columns["Name"].Visible = false;
            dgvAnbar.Columns["Family"].Visible = false;
            dgvAnbar.Columns["MoshtariID"].Visible = false;
            dgvAnbar.Columns["id"].Visible = false;
            dgvAnbar.Columns["InTedadKise"].HeaderText = "تعداد شالی";
            dgvAnbar.Columns["InTedadKise"].Width = 50;
            dgvAnbar.Columns["InNo"].HeaderText = "نوع شالی";
            dgvAnbar.Columns["InDate"].HeaderText = "تاریخ ورود";

            dgvAnbar.Columns["Code"].HeaderText = "کد محصول";
            dgvAnbar.Columns["Code"].Width = 60;

            dgvAnbar.Columns["TedadKiseDone"].HeaderText = "تعداد برنج";
            dgvAnbar.Columns["TedadKiseDone"].Width = 50;

            dgvAnbar.Columns["WeightDone"].HeaderText = "وزن برنج";
            dgvAnbar.Columns["WeightDone"].Width = 70;
            dgvAnbar.Columns["WeightDone"].Visible = false;
            dgvAnbar.Columns["Done"].HeaderText = "وزن برنج";
            dgvAnbar.Columns["Done"].Width = 70;

            dgvAnbar.Columns["WeightSabos1"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["WeightSabos1"].Width = 70;
            dgvAnbar.Columns["WeightSabos1"].Visible = false;
            dgvAnbar.Columns["Sabos"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["Sabos"].Width = 70;


            dgvAnbar.Columns["weightNimdone"].HeaderText = "وزن نیم دانه";
            dgvAnbar.Columns["weightNimdone"].Width = 70;
            dgvAnbar.Columns["weightNimdone"].Visible = false;
            dgvAnbar.Columns["Nimdone"].HeaderText = "وزن نیم دانه";
            dgvAnbar.Columns["Nimdone"].Width = 70;

            dgvAnbar.Columns["OutDate"].HeaderText = "تاریخ تبدیل";
            dgvAnbar.Columns["OutDate"].Width = 90;

            dgvAnbar.Columns["Anbar"].HeaderText = "شماره انبار";
            dgvAnbar.Columns["Anbar"].Width = 50;

            dgvAnbar.Columns["bed"].HeaderText = "بدهی";
            dgvAnbar.Columns["bed"].Width = 200;

            dgvAnbar.Columns["InWeight"].HeaderText = "وزن شالی";
            dgvAnbar.Columns["InWeight"].Width = 50;

        }
        void LoadfrmViewAnbar()
        {
            try
            {
                ftmveiwAnbar anbr = new ftmveiwAnbar();
                anbr.ProcessID = ProcessID;
                anbr.CstmrName = lblName.Text;
                anbr.CstmrID = CstmID;
                anbr.Done = Convert.ToDouble(dgvAnbar.CurrentRow.Cells["Done"].Value);
                anbr.Nimdone = Convert.ToDouble(dgvAnbar.CurrentRow.Cells["Nimdone"].Value); ;
                anbr.Sabos = Convert.ToDouble(dgvAnbar.CurrentRow.Cells["Sabos"].Value);
                anbr.NoDone = Convert.ToString(dgvAnbar.CurrentRow.Cells["InNo"].Value);
                anbr.DateFer = Convert.ToString(dgvAnbar.CurrentRow.Cells["OutDate"].Value);
                anbr.TShali = Convert.ToDouble(dgvAnbar.CurrentRow.Cells["InTedadKise"].Value);

                if (anbr.ShowDialog() == DialogResult.OK)
                {
                    Display();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در نمایش فرم خروج از انبار رخ داده است");
            }
        }
        private void frmConrolAnbar_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            txtSName.FindForm();
         }
        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSName.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }
        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Family Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInFamSearch.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }
        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }
        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
                con.Close();
            CstmID = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + CstmID;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = dt.Rows[0]["Name"].ToString();// + " " + dt.Rows[0][2].ToString(); ;              
                txtSName.WatermarkText = dt.Rows[0]["Name"].ToString();
                txtInFamSearch.WatermarkText = dt.Rows[0]["Family"].ToString();
                con.Close();
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
           
            txtSName.Text = "";
            txtInFamSearch.Text = "";
            txtSID.Text = "";
            Display();
            AddButton();
            dgvInSearch.Visible = false;
            //    txtSID.WatermarkText = dt.Rows[0]["DastiID"].ToString();
            //}
            //catch (Exception)
            //{
            //}
        }
        private void dgvAnbar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvAnbar.Columns["bed"].Index && e.RowIndex != this.dgvAnbar.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
        private void dgvAnbar_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dgvAnbar.Rows[e.RowIndex].Selected = true;
                if (dgvAnbar.Columns[e.ColumnIndex].Name == "btnTasvie")
                {

                    ProcessID = (int)dgvAnbar.Rows[e.RowIndex].Cells["ProcessID"].Value;
                    LoadfrmViewAnbar();
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
