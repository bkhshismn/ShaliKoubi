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
    public partial class frmBestanKariSalePish : Form
    {
        public frmBestanKariSalePish()
        {
            InitializeComponent();
        }
        public string NameFam { get; set; }
        public int CstmrID { get; set; }
        public int mablagh { get; set; }
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void frmBestanKariSalePish_Load(object sender, EventArgs e)
        {
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtMablagh.Text = mablagh.ToString();
            lblID.Text = CstmrID.ToString();
            lblName.Text = NameFam;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblBestanKareSaleGhbal] where CstmrID=" + CstmrID;
                con.Open();
                adp.Fill(dt);
                int mablgh = Convert.ToInt32(dt.Rows[0]["MablaghBes"]);
                con.Close();
            }
            catch (Exception)
            {
            }
           
            /////////////////////////////////////////////////////////////////////////
            string Sharh = "پرداخت بدهی سال گذشته " + NameFam;
            string pardkht = NameFam;
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
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblCost](CostMablagh,SharhHazine,Tavasot,CostDate,CostDiscription,Nahve)values(@CostMablagh,@SharhHazine,@Tavasot,@CostDate,@CostDiscription,@Nahve)";
                    cmd.Parameters.AddWithValue("@CostMablagh", Convert.ToInt64(txtMablagh.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@SharhHazine", Sharh);
                    cmd.Parameters.AddWithValue("@Tavasot", pardkht);
                    cmd.Parameters.AddWithValue("@Nahve", nahve);
                    cmd.Parameters.AddWithValue("@CostDate", txtDate.Text);
                    cmd.Parameters.AddWithValue("@CostDiscription", "طلب از سال پیش");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ///////////////////////////////////////////////////////////////////
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update [tblBestanKareSaleGhbal] Set MablaghBes = '" + (mablagh - (Convert.ToInt64(txtMablagh.Text.Replace(",", "")))) + "'where CstmrID=" + CstmrID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                }

                catch (Exception)
                {

                    MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
                }
        }
    }
}
