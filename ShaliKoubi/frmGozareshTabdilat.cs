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
    public partial class frmGozareshTabdilat : Form
    {
        public frmGozareshTabdilat()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        double GetTedadShali()
        {
            double tedad = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblInput  where InDate between '" + txtFerDate1.Text + "' and '" + txtFerDate2.Text + "'";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;

                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        tedad += Convert.ToInt32(dt.Rows[i]["InTedadKise"]);
                    }
                }
                else
                {
                    //MessageBox.Show("رکورد خالی می باشد");
                }
            }
            catch (Exception)
            {

            }
            
           
            return tedad;

        }
        private void frmGozareshTabdilat_Load(object sender, EventArgs e)
        {
            txtFerDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtFerDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");

            txtFerDate3.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtFerDate4.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblOutput  where OutDate between '" + txtFerDate1.Text + "' and '" + txtFerDate2.Text +"'";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int nimdone = 0;
            int tdone = 0;
            int vdone = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WeightSabos1"]);
                    nimdone += Convert.ToInt32(dt.Rows[i]["weightNimdone"]);
                    vdone += Convert.ToInt32(dt.Rows[i]["TedadKiseDone"]);
                    tdone += Convert.ToInt32(dt.Rows[i]["WeightDone"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            lbltBereng.Text = vdone.ToString("N0");
            lblVberenj.Text = tdone.ToString("N0");
            lblVNimdone.Text = nimdone.ToString("N0");
            lblVSabos.Text = sabos1.ToString("N0");
            lblShali.Text = GetTedadShali().ToString("N0");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_InputReport where InDate between '" + txtFerDate3.Text+"'and '"+txtFerDate4.Text+ "' And PrccChecker =" + 0;
            adp.Fill(ds, "tblInput");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "tblInput";
            //************************************
            dgvInput.Columns["Name"].HeaderText = "نام";
            dgvInput.Columns["Name"].Width = 90;
            dgvInput.Columns["Family"].HeaderText = "نام خانوادگی";
            dgvInput.Columns["Family"].Width = 90;
            dgvInput.Columns["CstmrID"].HeaderText = "کد مشتری";
            dgvInput.Columns["CstmrID"].Width = 70;
            dgvInput.Columns["InputID"].HeaderText = "کد محصول";
            dgvInput.Columns["InputID"].Width = 75;
            dgvInput.Columns["InNo"].HeaderText = "نوع شالی";
            dgvInput.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns["InDate"].HeaderText = " تاریخ ورود";
            dgvInput.Columns["Discription"].HeaderText = " توضیحات";
            dgvInput.Columns["Discription"].Width = 200;
            dgvInput.Columns["PrccChecker"].Visible = false;
        }
    }
}
