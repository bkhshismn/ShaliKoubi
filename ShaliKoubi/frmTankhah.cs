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
    public partial class frmTankhah : Form
    {
        public frmTankhah()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void KoleMablagh()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblTankhah";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int Hazine = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    Hazine += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                }
            }
            else
            {
                
            }
            lblKolMablagh.Text = Hazine.ToString("N0");
        }
        public void Display()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblTankhah]";
                adp.Fill(ds, "tblTankhah");
                dgvTankhah.DataSource = ds;
                dgvTankhah.DataMember = "tblTankhah";
                dgvTankhah.Columns["PayID"].HeaderText = "کد";
                dgvTankhah.Columns["PayID"].Width = 70;
                dgvTankhah.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvTankhah.Columns["DadeBeShakhs"].HeaderText = "پرداخت به";
                dgvTankhah.Columns["DadeBeShakhs"].Width = 120;
                dgvTankhah.Columns["Sharh"].HeaderText = "شرح پرداخت";
                dgvTankhah.Columns["Sharh"].Width = 160;
                dgvTankhah.Columns["No"].HeaderText = "نحوه پرداخت";
                dgvTankhah.Columns["No"].Width = 70;
                dgvTankhah.Columns["Date"].HeaderText = "تاریخ";
                dgvTankhah.Columns["No"].HeaderText = "نوع پرداخت";
                dgvTankhah.Columns["No"].Width = 100;
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void frmTankhah_Load(object sender, EventArgs e)
        {
            KoleMablagh();
            txtMablagh.Focus();
            Display();
            txtsearchDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void buttonX4_Click(object sender, EventArgs e)
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
            if (nahve=="")
            {
                MessageBox.Show(".لطفا نوع پردهخت را انتخاب کنین");
            }
            else
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [tblTankhah](Mablagh,DadeBeShakhs,Sharh,Date,No)values(@Mablagh,@DadeBeShakhs,@Sharh,@Date,@No)";
                cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@DadeBeShakhs", txtPardakht.Text);
                cmd.Parameters.AddWithValue("@Sharh", txtsharh.Text);
                cmd.Parameters.AddWithValue("@Date", txtDate.Text);
                cmd.Parameters.AddWithValue("@No", nahve);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                KoleMablagh();
                MessageBox.Show("ثبت با موفقیت انجام شد");
                Display();
                txtMablagh.Focus();
                txtMablagh.Text = "";
                txtPardakht.Text = "";
                txtsharh.Text = "";


            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
            }
            txtMablagh.Focus();
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
            if (nahve == "")
            {
                MessageBox.Show(".لطفا نوع پردهخت را انتخاب کنین");
            }
            else
            if (Id != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblTankhah Set No=N'" + nahve + "',Mablagh=N'" + txtMablagh.Text.Replace(",", "") + "',DadeBeShakhs=N'" + txtPardakht.Text + "',Sharh=N'" + txtsharh.Text + "', Date=N'" + txtDate.Text + "'   where PayID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    KoleMablagh();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    Display();
                    txtMablagh.Focus();
                    txtMablagh.Text = "";
                    txtPardakht.Text = "";
                    txtsharh.Text = "";
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            
        }

        private void dgvTankhah_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = (int)dgvTankhah.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblTankhah where PayID=" + Id;
                con.Open();
                adp.Fill(dt);
                this.txtMablagh.Text = dt.Rows[0]["Mablagh"].ToString();
                this.txtPardakht.Text = dt.Rows[0]["DadeBeShakhs"].ToString();
                this.txtsharh.Text = dt.Rows[0]["Sharh"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                chkNaghd.Checked = false;
                chkCard.Checked = false;
                chkCheck.Checked = false;
                if (dt.Rows[0]["No"].ToString() == "نقدی")
                {
                    chkNaghd.Checked = true;
                }
                else if (dt.Rows[0]["No"].ToString() == "کارت به کارت")
                {
                    chkCard.Checked = true;
                }
                else if (dt.Rows[0]["No"].ToString() == "چک")
                {
                    chkCheck.Checked = true;
                }
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید");
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
                        cmd.CommandText = "delete from tblTankhah where PayID=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        Display();
                        txtMablagh.Focus();
                        txtMablagh.Text = "";
                        txtPardakht.Text = "";
                        txtsharh.Text = "";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }

        private void txtSharSearch_TextChanged(object sender, EventArgs e)
        {

            dgvTankhah.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblTankhah where Sharh Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSharSearch.Text + "%");
            adp.Fill(ds, "tblTankhah");
            dgvTankhah.DataSource = ds;
            dgvTankhah.DataMember = "tblTankhah";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtSharSearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dgvTankhah.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblTankhah where Date Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtsearchDate.Text + "%");
            adp.Fill(ds, "tblTankhah");
            dgvTankhah.DataSource = ds;
            dgvTankhah.DataMember = "tblTankhah";
        }

        private void dgvTankhah_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dgvTankhah.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void buttonX4_Click_1(object sender, EventArgs e)
        {
           
            txtMablagh.Text = "";
            txtPardakht.Text = "";
            txtsharh.Text = "";
            txtMablagh.Focus();
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
    }
}
