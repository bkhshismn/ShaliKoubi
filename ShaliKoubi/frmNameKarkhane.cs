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
    public partial class frmNameKarkhane : Form
    {
        public frmNameKarkhane()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        public void GetData()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblNameKarkhane]";
                adp.Fill(ds, "tblNameKarkhane");
                con.Open();
                adp.Fill(dt);
                txtName.Text = dt.Rows[0]["NameKarkhane"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtTell.Text = dt.Rows[0]["Tell"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                con.Close();
            }
            catch (Exception)
            {
            }
        }
        private void frmNameKarkhane_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update tblNameKarkhane Set NameKarkhane=N'" + txtName.Text + "',Address=N'" + txtAddress.Text + "',Tell=N'" + txtTell.Text + "',Mobile=N'" + txtMobile.Text + "' where ID =" + 1;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ویرایش اطلاعات انجام شد.");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
          
        }
    }
}
