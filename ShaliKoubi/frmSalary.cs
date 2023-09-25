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
    public partial class frmSalary: Form
    {
        public frmSalary()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dat = new System.Globalization.PersianCalendar();
        method mt = new method();
        int Id = -1;
        int mmbr = -1;
        string ckk = "";
        int hoghogh = 0;
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
                adp.SelectCommand.CommandText = "select * from tblMember where mmbrID=" + mmbr;
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
            adp.SelectCommand.CommandText = "select * from tblSalary where mmbrID=" + mmbr;
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
        void DisplayNaghdi()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblSalary] where mmbrID=" + mmbr;
                adp.Fill(ds, "tblSalary");
                dgvSalary.DataSource = ds;
                dgvSalary.DataMember = "tblSalary";
                dgvSalary.Columns[0].Visible=false;
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
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }

        void DisplaySalary()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblSalary] where SalaryID=" + Id;
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
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        void Titlr()
        {
            dgvInSearch.Columns[0].HeaderText = "کد";
            dgvInSearch.Columns[0].Width = 30;
            dgvInSearch.Columns[1].HeaderText = "نام ";
            dgvInSearch.Columns[1].Width = 70;
            dgvInSearch.Columns[2].HeaderText = "نام خانوادگی";
            dgvInSearch.Columns[3].HeaderText = "شماره همراه";
            dgvInSearch.Columns[3].Width = 120;
            dgvInSearch.Columns[4].HeaderText = " نوع همکاری";
            dgvInSearch.Columns[4].Width = 100;
            dgvInSearch.Columns[5].HeaderText = "تاریخ شروع قرارداد ";
            dgvInSearch.Columns[5].Width = 120;
            dgvInSearch.Columns[6].HeaderText = "حقوق دریافتی ";
            dgvInSearch.Columns[7].HeaderText = "آدرس";
            dgvInSearch.Columns[7].Width = 170;
        }

        private void txtInNameSearch_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMember where mmbrName Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInNameSearch.Text + "%");
            adp.Fill(ds, "tblMember");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblMember";
            Titlr();
            //mt.Titr(dgvInSearch);
        }

        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
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
            Titlr();
            //mt.Titr(dgvInSearch);
        }

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                con.Close();
                int indx = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
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
                this.lblNo.Text = dt.Rows[0][4].ToString();
                con.Close();
                mmbr = indx;
                lblID.Text = indx.ToString();
                dgvInSearch.Visible = false;
                lblDaryafti.Text = mt.Salary(mmbr).ToString("N0");
                //lblTalab.Text=(mt.MemberFee(mmbr)- mt.Salary(mmbr)).ToString("N0");
                DisplayNaghdi();
                hoghogh = Hoghogh();
                int Majmohoghogh = HoghoghDaryafti();
                int Bedehkari = ( (hoghogh * 12)- Majmohoghogh);
                if (Bedehkari < 0)
                {
                    lblTalab.Text = "0";

                }
                else
                {
                    lblTalab.Text = Bedehkari.ToString("N0");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked== true)
            {
                nahve += chkNaghd.Text ;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text ;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [tblSalary](mmbrID,SalaryMablagh,SalaryDate,SalaryNahve,SalaryDiscription)values(@mmbrID,@SalaryMablagh,@SalaryDate,@SalaryNahve,@SalaryDiscription)";
                cmd.Parameters.AddWithValue("@mmbrID", mmbr);
                cmd.Parameters.AddWithValue("@SalaryMablagh", Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@SalaryDate", txtSDate.Text);
                cmd.Parameters.AddWithValue("@SalaryNahve", nahve);
                cmd.Parameters.AddWithValue("@SalaryDiscription", txtSDiscription.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                DisplayNaghdi();
                txtMablagh.Text = "";
                txtSDiscription.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
            }
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;        
            line3.Visible = false;
            line4.Visible = false;
            //DisplayNaghdi();
            txtSDate.Text = dat.GetYear(DateTime.Now).ToString() + dat.GetMonth(DateTime.Now).ToString("0#") + dat.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void chkNaghd_CheckedChanged(object sender, EventArgs e)
        {
            chkCard.Checked = false;
            chkCheck.Checked = false;
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            chkNaghd.Checked = false;
            chkCheck.Checked = false;
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            chkCard.Checked = false;
            chkNaghd.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked == true)
            {
                nahve += chkNaghd.Text;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }

            if (Id != -1)
            {
                try
                { 
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblSalary Set SalaryMablagh=N'" + txtMablagh.Text.Replace(",", "") + "',SalaryDate=N'" + txtSDate.Text + "',SalaryNahve=N'" + nahve + "',SalaryDiscription=N'" + txtSDiscription.Text +"' where SalaryID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    DisplayNaghdi();
                    //DisplaySalary();
                    txtSDiscription.Text = "";
                    txtMablagh.Text = "";
                    chkNaghd.Checked = false;
                    chkCheck.Checked = false;
                    chkCard.Checked = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
        }

        private void dgvSalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = (int)dgvSalary.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblSalary where SalaryID=" + Id;
                con.Open();
                adp.Fill(dt);
                this.txtMablagh.Text = dt.Rows[0][2].ToString();
                mmbr = Convert.ToInt32(dt.Rows[0][1]);
                this.txtSDate.Text = dt.Rows[0][3].ToString();
                this.ckk = dt.Rows[0][4].ToString();
                this.txtSDiscription.Text = dt.Rows[0][5].ToString();
                con.Close();
                chkNaghd.Checked = false;
                chkCard.Checked = false;
                chkCheck.Checked = false;
                if (ckk == "نقدی")
                {
                    chkNaghd.Checked = true;
                }
                else if (ckk == "کارت به کارت")
                {
                    chkCard.Checked = true;
                }
                else if (ckk == "چک")
                {
                    chkCheck.Checked = true;
                }
            }
            catch (Exception)
            {               
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from tblSalary where SalaryID=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtSDiscription.Text = "";
                        txtMablagh.Text = "";
                        chkNaghd.Checked = false;
                        chkCheck.Checked = false;
                        chkCard.Checked = false;
                        DisplayNaghdi();
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
                if (txtMablagh.Text != string.Empty)
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

        private void dgvSalary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvSalary.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtInFamSearch.Text = "";
            txtInNameSearch.Text = "";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
