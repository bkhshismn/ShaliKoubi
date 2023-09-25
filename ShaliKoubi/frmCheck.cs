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
    public partial class frmCheck : Form
    {

        public frmCheck()
        {
            InitializeComponent();
        }
        public int CustmID { get; set; }
        public string CstmrName { get; set; }
        public string CstmrFam { get; set; }
        public string Refered { get; set; }
        public int Mablagh { get; set; }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void DisplayChecki()
        {
            if (Refered== "پرداخت کارمزد")
            {
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adp.SelectCommand = new SqlCommand();
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandText = "select * from [PayCheck] where CstumID=" + CustmID;
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
                    dgvPCheck.Columns["CheckDiscription"].HeaderText = "توضیحات";
                    dgvPCheck.Columns["Babat"].HeaderText = "بابت";
                    dgvPCheck.Columns["Vaziat"].Visible = false;
                    dgvPCheck.Columns["CstumID"].Visible = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
                }
            }
            
        }
        /// <summary>
        /// Pardakht dastmozd karkhane be sorate Daryaft Check
        /// </summary>
        public void PayCheck()
        {

            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [PayCheck] (NoBank,ChkDate,Mablagh,ShomareCheck,Darvajh,FLName,ShomareHesab,Shobe,PayCheckDate,chkCheck,CheckDiscription,Babat,Vaziat,CstumID)values(@NoBank,@ChkDate,@Mablagh,@ShomareCheck,@Darvajh,@FLName,@ShomareHesab,@Shobe,@PayCheckDate,@chkCheck,@Discription,@Babat,@Vaziat,@CstumID)";
                //cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                cmd.Parameters.AddWithValue("@NoBank", txtNoBank.Text);
                cmd.Parameters.AddWithValue("@ChkDate", txtChekDate.Text);
                cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@ShomareCheck", txtShomareCheck.Text);
                cmd.Parameters.AddWithValue("@Darvajh", txtDarVajh.Text);
                cmd.Parameters.AddWithValue("@FLName", txtName.Text);
                cmd.Parameters.AddWithValue("@ShomareHesab", Convert.ToInt64(txtShomareHesab.Text));
                cmd.Parameters.AddWithValue("@Shobe", txtShobe.Text);
                cmd.Parameters.AddWithValue("@PayCheckDate", txtPayDate3.Text);
                cmd.Parameters.AddWithValue("@chkCheck", 1);
                cmd.Parameters.AddWithValue("@Discription", txtPayCheckDiscription.Text);
                cmd.Parameters.AddWithValue("@Babat", Refered);
                cmd.Parameters.AddWithValue("@Vaziat", 0);
                cmd.Parameters.AddWithValue("@CstumID", CustmID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت پرداخت چکی با موفقیت انجام شد");
                lnBank.Visible = false;
                lnTarikh.Visible = false;
                lnShobe.Visible = false;
                lnMablaghCheck.Visible = false;
                lnDarvajh.Visible = false;
                lnShomareCheck.Visible = false;

                txtNoBank.Text = "";
                txtMablagh.Text = "0";
                txtShobe.Text = "";
                txtShomareCheck.Text = "";
                txtShomareHesab.Text = "";
                txtName.Text = "";
                txtDarVajh.Text = "";
                txtPayCheckDiscription.Text = "";
                txtTakhfif.Text = "";
                DisplayChecki();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ثبت پرداخت چکی وجود دارد");
            }
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            txtNoBank.Text = "";
            txtMablagh.Text = "0";
            txtShobe.Text = "";
            txtShomareCheck.Text = "";
            txtShomareHesab.Text = "";
            txtName.Text = "";
            txtDarVajh.Text = "";
            txtPayCheckDiscription.Text = "";
            txtTakhfif.Text = "";
            btnSave.Enabled = true;
        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            txtPayDate3.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtChekDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lnBank.Visible = false;
            lnTarikh.Visible = false;
            lnShobe.Visible = false;
            lnMablaghCheck.Visible = false;
            lnDarvajh.Visible = false;
            lnShomareCheck.Visible = false;

            lblID.Text = CustmID.ToString();
             lblName.Text =CstmrName.ToString();
            txtMablagh.Text = Mablagh.ToString("N0");

            DisplayChecki();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMablagh.Text == "" && txtNoBank.Text == "" && txtDarVajh.Text == "" && txtShobe.Text == "" && txtShomareCheck.Text == "" && txtChekDate.Text == "")
            {
                lnMablaghCheck.Visible = true;
                lnBank.Visible = true;
                lnDarvajh.Visible = true;
                lnShobe.Visible = true;
                lnShomareCheck.Visible = true;
                lnTarikh.Visible = true;
                return;
            }
            else
            {
                if (txtMablagh.Text == "")
                {
                    lnMablaghCheck.Visible = true;
                }
                if (txtNoBank.Text == "")
                {
                    lnBank.Visible = true;
                }
                if (txtDarVajh.Text == "")
                {
                    lnDarvajh.Visible = true;
                }
                if (txtShobe.Text == "")
                {
                    lnShobe.Visible = true;
                }
                if (txtShomareCheck.Text == "")
                {
                    lnShomareCheck.Visible = true;
                }
                if (txtChekDate.Text == "")
                {
                    lnTarikh.Visible = true;
                }
            }
            if (txtMablagh.Text != "" && txtNoBank.Text != "" && txtDarVajh.Text != "" && txtShobe.Text != "" && txtShomareCheck.Text != "" && txtChekDate.Text != "")
            {
                PayCheck();
            }
            txtNoBank.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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
                        cmd.CommandText = "Update [PayCheck] Set NoBank=N'" + txtNoBank.Text + "',ChkDate=N'" + txtChekDate.Text + "',ShomareCheck=N'" + txtShomareCheck.Text + "',Mablagh=N'" + txtMablagh.Text.Replace(",", "") + "',Darvajh=N'" + txtDarVajh.Text + "',FLName=N'" + txtName.Text + "',ShomareHesab=N'" + txtShomareHesab.Text + "',Shobe=N'" + txtShobe.Text + "',PayCheckDate=N'" + txtPayDate3.Text + "',Takhfif=N'" + txtTakhfif.Text.Replace(",", "") + "',CheckDiscription=N'" + txtPayCheckDiscription.Text + "' where CheckID=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                        txtTakhfif.Text = "";
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

        private void dgvPCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPCheck.Rows[e.RowIndex].Selected = true;
            try
            {
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
                con.Close();
                btnSave.Enabled = false;
            }
            catch (Exception)
            {
            }
                 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from [PayCheck] where CheckID=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                        txtTakhfif.Text = "";
                        DisplayChecki();
                        btnSave.Enabled = true;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
           
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtMablagh.Text != string.Empty || txtMablagh.Text != "0")
                {
                    txtMablagh.Text = string.Format("{0:N0}", double.Parse(txtMablagh.Text.Replace(",", "")));
                    txtMablagh.Select(txtMablagh.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
           
        }
    }
}
