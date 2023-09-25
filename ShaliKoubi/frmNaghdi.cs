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
    public partial class frmNaghdi : Form
    {
        public frmNaghdi()
        {
            InitializeComponent();
        }
        public int CustmID { get; set; }
        public string CstmrName { get; set; }
        public string CstmrFam { get; set; }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
       
        /// <summary>
        /// Pardakht dastmozd karkhane be sorate naghdi ya Carti
        /// </summary>
        public void PayNaghd()
        {
            //try
            //{
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [PayNaghd](CstmrID,Paynaghd,PayCard,chkNaghd,NPayDate,NaghdDiscription,Takhfif)values(@CstmrID,@Paynaghd,@PayCard,@chkNaghd,@NPayDate,@Discription,@Takhfif)";
                cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                cmd.Parameters.AddWithValue("@Paynaghd", Convert.ToInt32(txtPayNaghd.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@PayCard", Convert.ToInt32(txtPayCard.Text.Replace(",", "")));
                cmd.Parameters.AddWithValue("@chkNaghd", 1);
                cmd.Parameters.AddWithValue("@NPayDate", txtPayDate1.Text);
                cmd.Parameters.AddWithValue("@Discription", txtPayNaghdDiscription.Text);
                cmd.Parameters.AddWithValue("@Takhfif", Convert.ToInt32(txtTakhfif.Text.Replace(",", "")));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                txtPayNaghd.Text = "";
                txtPayCard.Text = "";
                txtTakhfif.Text = "";
                txtPayNaghdDiscription.Text = "";
                lnTxtCard.Visible = false;
                lnTxtNaghd.Visible = false;

            //}
            //catch (Exception)
            //{
               
            //    MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
            //}
        }

        void DisplayNaghdi()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [PayNaghd] where CstmrID="+ CustmID;
                adp.Fill(ds, "PayNaghd");
                dgvPNaghd.DataSource = ds;
                dgvPNaghd.DataMember = "PayNaghd";
                dgvPNaghd.Columns[0].HeaderText = "کد";
                dgvPNaghd.Columns[0].Width = 30;
                dgvPNaghd.Columns[1].HeaderText = "کد مشتری";
                dgvPNaghd.Columns[2].HeaderText = "پرداخت نقدی";
                dgvPNaghd.Columns[3].HeaderText = "پرداخت کارتی";
                dgvPNaghd.Columns[6].Width = 120;
                dgvPNaghd.Columns[4].Visible = false;
                dgvPNaghd.Columns[5].HeaderText = "تاریخ پرداخت";
                dgvPNaghd.Columns[6].HeaderText = "میزان تخفیف(به تومان)";
                dgvPNaghd.Columns[7].HeaderText = "توضیحات";
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            txtPayNaghd.Text = "";
            txtPayCard.Text = "";
            txtPayNaghdDiscription.Text = "";
            txtTakhfif.Text = "";
        }

        private void frmNaghdi_Load(object sender, EventArgs e)
        {
            txtPayDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lnTxtCard.Visible = false;
            lnTxtNaghd.Visible = false;

            lblID.Text = CustmID.ToString();
            lblName.Text = CstmrName.ToString();
            lblFam.Text = CstmrFam.ToString();

            DisplayNaghdi();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPayNaghd.Text == "" && txtPayCard.Text == "")
            {
                lnTxtCard.Visible = true;
                lnTxtNaghd.Visible = true;
                MessageBox.Show("لطفا یکی از فیلدهای مشخص شده را پر کنید");
            }
            else
            {
                //try
                //{
                    if (txtPayNaghd.Text != "" && txtPayCard.Text != "")
                    {
                        con.Close();
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT into [PayNaghd](CstmrID,Paynaghd,PayCard,chkNaghd,NPayDate,NaghdDiscription,Takhfif)values(@CstmrID,@Paynaghd,@PayCard,@chkNaghd,@NPayDate,@Discription,@Takhfif)";
                        cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                        cmd.Parameters.AddWithValue("@Paynaghd", Convert.ToInt32(txtPayNaghd.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@PayCard", Convert.ToInt32(txtPayCard.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@chkNaghd", 1);
                        cmd.Parameters.AddWithValue("@NPayDate", txtPayDate1.Text);
                        cmd.Parameters.AddWithValue("@Discription", txtPayNaghdDiscription.Text);
                        cmd.Parameters.AddWithValue("@Takhfif", Convert.ToInt32(txtTakhfif.Text.Replace(",", "")));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                        txtPayNaghd.Text = "";
                        txtPayCard.Text = "";
                        txtTakhfif.Text = "";
                        txtPayNaghdDiscription.Text = "";
                        lnTxtCard.Visible = false;
                        lnTxtNaghd.Visible = false;
                    }
                    if (txtPayNaghd.Text != "" && txtPayCard.Text == "")
                    {
                        con.Close();
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT into [PayNaghd](CstmrID,Paynaghd,PayCard,chkNaghd,NPayDate,NaghdDiscription,Takhfif)values(@CstmrID,@Paynaghd,@PayCard,@chkNaghd,@NPayDate,@Discription,@Takhfif)";
                        cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                        cmd.Parameters.AddWithValue("@Paynaghd", Convert.ToInt32(txtPayNaghd.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@PayCard", 0);
                        cmd.Parameters.AddWithValue("@chkNaghd", 1);
                        cmd.Parameters.AddWithValue("@NPayDate", txtPayDate1.Text);
                        cmd.Parameters.AddWithValue("@Discription", txtPayNaghdDiscription.Text);
                        cmd.Parameters.AddWithValue("@Takhfif", Convert.ToInt32(txtTakhfif.Text.Replace(",", "")));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                        txtPayNaghd.Text = "";
                        txtPayCard.Text = "";
                        txtTakhfif.Text = "";
                        txtPayNaghdDiscription.Text = "";
                        lnTxtCard.Visible = false;
                        lnTxtNaghd.Visible = false;
                    }
                    if (txtPayNaghd.Text == "" && txtPayCard.Text != "")
                    {
                        con.Close();
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT into [PayNaghd](CstmrID,Paynaghd,PayCard,chkNaghd,NPayDate,NaghdDiscription,Takhfif)values(@CstmrID,@Paynaghd,@PayCard,@chkNaghd,@NPayDate,@Discription,@Takhfif)";
                        cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                        cmd.Parameters.AddWithValue("@Paynaghd",0);
                        cmd.Parameters.AddWithValue("@PayCard", Convert.ToInt32(txtPayCard.Text.Replace(",", "")));
                        cmd.Parameters.AddWithValue("@chkNaghd", 1);
                        cmd.Parameters.AddWithValue("@NPayDate", txtPayDate1.Text);
                        cmd.Parameters.AddWithValue("@Discription", txtPayNaghdDiscription.Text);
                        cmd.Parameters.AddWithValue("@Takhfif", Convert.ToInt32(txtTakhfif.Text.Replace(",", "")));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                        txtPayNaghd.Text = "";
                        txtPayCard.Text = "";
                        txtTakhfif.Text = "";
                        txtPayNaghdDiscription.Text = "";
                        lnTxtCard.Visible = false;
                        lnTxtNaghd.Visible = false;
                    }


                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
                //}
            }


            txtPayCard.Focus();
        }

        private void dgvPNaghd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = (int)dgvPNaghd.Rows[e.RowIndex].Cells[0].Value;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayNaghd where NaghdID=" + Id;
            con.Open();
            adp.Fill(dt);
            this.txtPayNaghd.Text = dt.Rows[0][2].ToString();
            this.txtPayCard.Text = dt.Rows[0][3].ToString();
            this.txtPayDate1.Text = dt.Rows[0][5].ToString();
            this.txtTakhfif.Text = dt.Rows[0][6].ToString();
            this.txtPayNaghdDiscription.Text = dt.Rows[0][7].ToString();
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Id !=-1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update PayNaghd Set PayNaghd=N'" + txtPayNaghd.Text.Replace(",", "") + "',PayCard=N'" + txtPayCard.Text.Replace(",", "") + "',NPayDate=N'" + txtPayDate1.Text + "',Takhfif=N'" + txtTakhfif.Text.Replace(",", "") + "',NaghdDiscription=N'" + txtPayNaghdDiscription.Text + "' where NaghdID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtPayNaghd.Text = "";
                    txtPayCard.Text = "";
                    txtPayNaghdDiscription.Text = "";
                    txtTakhfif.Text = "";
                    txtPayNaghdDiscription.Text = "";
                    DisplayNaghdi();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (Id != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from PayNaghd where NaghdID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("حذف اطلاعات انجام شد.");
                    txtPayNaghd.Text = "";
                    txtPayCard.Text = "";
                    txtPayNaghdDiscription.Text = "";
                    txtTakhfif.Text = "";
                    txtPayNaghdDiscription.Text = "";
                    DisplayNaghdi();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }

        }

        private void txtPayCard_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtPayCard.Text != string.Empty)
                {
                    txtPayCard.Text = string.Format("{0:N0}", double.Parse(txtPayCard.Text.Replace(",", "")));
                    txtPayCard.Select(txtPayCard.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        //private void txtPayNaghd_TextChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (txtPayNaghd.Text != string.Empty)
        //        {
        //            txtPayNaghd.Text = string.Format("{0:N0}", double.Parse(txtPayNaghd.Text.Replace(",", "")));
        //            txtPayNaghd.Select(txtPayCard.TextLength, 0);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
        //    }
        //}

        private void txtTakhfif_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtTakhfif.Text != string.Empty)
                {
                    txtTakhfif.Text = string.Format("{0:N0}", double.Parse(txtTakhfif.Text.Replace(",", "")));
                    txtTakhfif.Select(txtTakhfif.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void dgvPNaghd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvPNaghd.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 3 && e.RowIndex != this.dgvPNaghd.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void txtPayNaghd_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtPayNaghd.Text != string.Empty)
                {
                    txtPayNaghd.Text = string.Format("{0:N0}", double.Parse(txtPayNaghd.Text.Replace(",", "")));
                    txtPayNaghd.Select(txtPayNaghd.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
    }
}
