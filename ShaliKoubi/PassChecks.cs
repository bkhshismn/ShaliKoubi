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
    public partial class PassChecks : Form
    {
        public PassChecks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        int vaziat = 0;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void DisplayChecki()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [PayCheck]";
                adp.Fill(ds, "PayCheck");
                dgvPCheck.DataSource = ds;
                dgvPCheck.DataMember = "PayCheck";
                dgvPCheck.Columns["CheckID"].HeaderText = "کد";
                dgvPCheck.Columns["CheckID"].Width = 50;
                dgvPCheck.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheck.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheck.Columns["ChkDate"].Width = 70;
                dgvPCheck.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheck.Columns["ShomareCheck"].HeaderText = "شماره چک";
                dgvPCheck.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheck.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheck.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheck.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheck.Columns["PayCheckDate"].HeaderText = "تاریخ ثبت چک";
                dgvPCheck.Columns["PayCheckDate"].Width = 70;
                dgvPCheck.Columns["Takhfif"].HeaderText = "میزان تخفیف(به تومان)";
                dgvPCheck.Columns["Takhfif"].Visible = false;
                dgvPCheck.Columns["chkCheck"].Visible = false;
                dgvPCheck.Columns["CheckDiscription"].HeaderText = "توضیحات";
                dgvPCheck.Columns["Babat"].HeaderText = "بابت";
                dgvPCheck.Columns["Vaziat"].HeaderText = "وضعیت";
                dgvPCheck.Columns["Vaziat"].Width = 50;
                //dgvPCheck.Columns["Vaziat"].Visible = false;
                dgvPCheck.Columns["CstumID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void PassChecks_Load(object sender, EventArgs e)
        {
            DisplayChecki();
        }

        private void dgvPCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPCheck.Rows[e.RowIndex].Selected = true;

            Id = (int)dgvPCheck.Rows[e.RowIndex].Cells[0].Value;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayCheck where CheckID=" + Id;
            con.Open();
            adp.Fill(dt);
            lblID.Text = dt.Rows[0]["CheckID"].ToString();
            this.txtNoBank.Text = dt.Rows[0]["NoBank"].ToString();
            this.txtChekDate.Text = dt.Rows[0]["ChkDate"].ToString();
            this.txtMablagh.Text = dt.Rows[0]["Mablagh"].ToString();
            this.txtShomareCheck.Text = dt.Rows[0]["ShomareCheck"].ToString();
            this.txtDarVajh.Text = dt.Rows[0]["Darvajh"].ToString();
            this.txtName.Text = dt.Rows[0]["FLName"].ToString();
            this.txtShomareHesab.Text = dt.Rows[0]["ShomareHesab"].ToString();
            this.txtShobe.Text = dt.Rows[0]["Shobe"].ToString();
            this.txtPayDate3.Text = dt.Rows[0]["PayCheckDate"].ToString();
            this.txtTakhfif.Text = dt.Rows[0]["Takhfif"].ToString();
            this.txtPayCheckDiscription.Text = dt.Rows[0]["CheckDiscription"].ToString();
             vaziat = (int)dt.Rows[0]["Vaziat"];
            if (vaziat==0)
            {
                lblVaziat.Text = "وصول نشده";
                btnPass.Text= "وصول شده";
                lblVaziat.ForeColor = Color.Red;
            }
            else
            {
                lblVaziat.Text = "وصول شده";
                btnPass.Text = "وصول نشده";
                lblVaziat.ForeColor = Color.Green;
            }
            con.Close();
            //btnSave.Enabled = false;
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        if (vaziat==0)
                        {
                            cmd.CommandText = "Update [PayCheck] Set Vaziat=N'" + 1 + "' where CheckID=" + Id;
                            lblVaziat.Text= "وصول شده";
                            btnPass.Text = "وصول نشده";
                            
                        }
                        if (vaziat == 1)
                        {
                            cmd.CommandText = "Update [PayCheck] Set Vaziat=N'" + 0 + "' where CheckID=" + Id;
                            lblVaziat.Text = "وصول نشده";
                            btnPass.Text = "وصول شده";
                           
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        DisplayChecki();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }

        private void lblVaziat_TextChanged(object sender, EventArgs e)
        {
            if (lblVaziat.Text== "وصول نشده")
            {
                lblVaziat.ForeColor = Color.Red;
            }
            else
            {
                lblVaziat.ForeColor = Color.Green;
            }
        }
    }
}
