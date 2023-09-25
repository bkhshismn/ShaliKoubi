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
    public partial class frmPrsnl : Form
    {
        public frmPrsnl()
        {
            InitializeComponent();
        }
        int indx = -1;
        int MemberCode = -1;
        #region SQL
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        #endregion
        #region Method
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * from tblMember";
            adp.Fill(ds,"tblMember");
            dgvMember.DataSource = ds;
            dgvMember.DataMember = "tblMember";
            //**************************************************
            dgvMember.Columns[0].HeaderText = "کد پرسنلی";
            dgvMember.Columns[0].Width = 100;
            dgvMember.Columns[1].HeaderText = "نام ";
            dgvMember.Columns[1].Width = 70;
            dgvMember.Columns[2].HeaderText = "نام خانوادگی";
            dgvMember.Columns[3].HeaderText = "شماره همراه";
            dgvMember.Columns[3].Width = 120;
            dgvMember.Columns[4].HeaderText = " نوع همکاری";
            dgvMember.Columns[4].Width = 100;
            dgvMember.Columns[5].HeaderText = "تاریخ شروع قرارداد ";
            dgvMember.Columns[5].Width = 120;
            dgvMember.Columns[6].HeaderText = "حقوق دریافتی ";
            dgvMember.Columns[7].HeaderText = "آدرس";
            dgvMember.Columns[7].Width = 170;
        }
        #endregion
        private void frmPrsnl_Load(object sender, EventArgs e)
        {
            Display();
            //grpMmbr.Enabled = false;
            System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");      
        }

        private void cmbPrsnlNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrsnlNo.SelectedIndex ==1 )
            {
                grpMmbr.Enabled = true;
            }
            else
            {
                grpMmbr.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblMain.Text = "";
            if (txtPrsnlName.Text == "" || txtPrsnlFam.Text == "" || cmbPrsnlNo.Text == "")
            {
                lblMain.Text = "فیلد های خالی را پر کنید...";

                if (txtPrsnlName.Text == "")
                {
                    lblName.Text = "*";
                }
                if (txtPrsnlFam.Text == "")
                {
                    lblFam.Text = "*";
                }
                if (cmbPrsnlNo.Text == "")
                {
                    lblNo.Text = "*";
                }
            }
            else
            {
                try
                {
                    if (cmbPrsnlNo.SelectedIndex == 0)
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into tblMember(mmbrName,mmbrFam,mmbrTel,mmbrNo,mmbrDate,mmbrFee,mmbrAddress)values(@a,@b,@c,@d,@e,@f,@g)";
                        cmd.Parameters.AddWithValue("@a", txtPrsnlName.Text);
                        cmd.Parameters.AddWithValue("@b", txtPrsnlFam.Text);
                        cmd.Parameters.AddWithValue("@c", txtPrsnlTel.Text);
                        cmd.Parameters.AddWithValue("@d", cmbPrsnlNo.Text);
                        cmd.Parameters.AddWithValue("@e", "");
                        cmd.Parameters.AddWithValue("@f", "");
                        cmd.Parameters.AddWithValue("@g", txtAddress.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ثبت با موفقیت انجام شد");
                        Display();
                        txtPrsnlName.Text = "";
                        txtPrsnlFam.Text = "";
                        txtPrsnlTel.Text = "";
                        cmbPrsnlNo.Text = "";
                        txtPrsnlFee.Text = "";
                        txtAddress.Text = "";
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into tblMember(mmbrName,mmbrFam,mmbrTel,mmbrNo,mmbrDate,mmbrFee,mmbrAddress)values(@a,@b,@c,@d,@e,@f,@g)";
                        cmd.Parameters.AddWithValue("@a", txtPrsnlName.Text);
                        cmd.Parameters.AddWithValue("@b", txtPrsnlFam.Text);
                        cmd.Parameters.AddWithValue("@c", txtPrsnlTel.Text);
                        cmd.Parameters.AddWithValue("@d", cmbPrsnlNo.Text);
                        cmd.Parameters.AddWithValue("@e", txtDate.Text);
                        cmd.Parameters.AddWithValue("@f", txtPrsnlFee.Text.Replace(",", ""));
                        cmd.Parameters.AddWithValue("@g", txtAddress.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ثبت با موفقیت انجام شد");
                        Display();
                        txtPrsnlName.Text = "";
                        txtPrsnlFam.Text = "";
                        txtPrsnlTel.Text = "";
                        cmbPrsnlNo.Text = "";
                        txtPrsnlFee.Text = "";
                        txtAddress.Text = "";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from [tblMember] where mmbrID = @n";
                cmd.Parameters.AddWithValue("@n",MemberCode);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                this.txtPrsnlName.Text = "";
                this.txtPrsnlFam.Text = "";
                this.txtPrsnlTel.Text = "";
                this.cmbPrsnlNo.Text = "";
                this.txtDate.Text = "";
                this.txtPrsnlFee.Text = "";
                this.txtAddress.Text = "";

            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در حذف کاربر رخ داده است.");
            }
            Display();
            grpMmbr.Enabled = false;
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indx = (int)dgvMember.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblMember where mmbrID=" + indx;
                con.Open();
                adp.Fill(dt);
                if (String.Compare(dt.Rows[0][4].ToString(), "کارمند    ") == 0)
                {
                    grpMmbr.Enabled = true;
                    //lblTel.Enabled = true;
                    //labelNo.Enabled = true;
                    txtPrsnlTel.Enabled = true;
                    cmbPrsnlNo.Enabled = true;
                    txtAddress.Enabled = true;
                    this.txtPrsnlName.Text = dt.Rows[0][1].ToString();
                    this.txtPrsnlFam.Text = dt.Rows[0][2].ToString();
                    this.txtPrsnlTel.Text = dt.Rows[0][3].ToString();
                    this.cmbPrsnlNo.Text = dt.Rows[0][4].ToString();
                    this.txtDate.Text = dt.Rows[0][5].ToString();
                    this.txtPrsnlFee.Text = dt.Rows[0][6].ToString();
                    this.txtAddress.Text = dt.Rows[0][7].ToString();
                }
                else
                {
                    grpMmbr.Enabled = false;
                    txtPrsnlTel.Enabled = true;
                    cmbPrsnlNo.Enabled = true;
                    txtAddress.Enabled = true;
                    this.txtPrsnlName.Text = dt.Rows[0][1].ToString();
                    this.txtPrsnlFam.Text = dt.Rows[0][2].ToString();
                    this.txtPrsnlTel.Text = dt.Rows[0][3].ToString();
                    this.cmbPrsnlNo.Text = dt.Rows[0][4].ToString();
                    this.txtDate.Text = dt.Rows[0][5].ToString();
                    this.txtPrsnlFee.Text = dt.Rows[0][6].ToString();
                    this.txtAddress.Text = dt.Rows[0][7].ToString();
                }

                con.Close();
                MemberCode = indx;
            }
            catch (Exception)
            {

            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //

            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update tblMember Set mmbrName=N'" + txtPrsnlName.Text + "',mmbrFam=N'" + txtPrsnlFam.Text + "',mmbrTel=N'" + txtPrsnlTel.Text + "',mmbrNo=N'" + cmbPrsnlNo.Text + "',mmbrDate=N'" + txtDate.Text + "',mmbrFee=N'" + txtPrsnlFee.Text.Replace(",", "") + "',mmbrAddress=N'" + txtAddress.Text + "' where mmbrID=" + MemberCode;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ویرایش اطلاعات انجام شد.");
                Display();
                this.txtPrsnlName.Text = "";
                this.txtPrsnlFam.Text = "";
                this.txtPrsnlTel.Text = "";
                this.cmbPrsnlNo.Text = "";
                this.txtDate.Text = "";
                this.txtPrsnlFee.Text = "";
                this.txtAddress.Text = "";

                grpMmbr.Enabled = false;
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
           
        }

        private void txtPrsnlFee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrsnlFee.Text != string.Empty)
                {
                    txtPrsnlFee.Text = string.Format("{0:N0}", double.Parse(txtPrsnlFee.Text.Replace(",", "")));
                    txtPrsnlFee.Select(txtPrsnlFee.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void dgvMember_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != this.dgvMember.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
    }
}
