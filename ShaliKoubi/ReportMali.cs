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
    public partial class ReportMali : Form
    {
        public ReportMali()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        private void ReportMali_Load(object sender, EventArgs e)
        {
            txtPayDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtPayDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [PayMahsol] where MPayDate between '"+ txtPayDate2.Text + "'and '" + txtPayDate1.Text + "'";
                adp.Fill(ds, "PayMahsol");
                dataGridViewX1.DataSource = ds;
                dataGridViewX1.DataMember = "PayMahsol";
        }

    }
}
