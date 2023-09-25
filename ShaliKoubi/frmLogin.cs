using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShaliKoubi
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void btnEnter_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();

            f.UserName = txtName.Text;
            //if (txtName.Text == "saman")
            //{
            //    MessageBox.Show("  اعتبار اکانت شما منقصی شده است", "هشدار",MessageBoxButtons.OK, MessageBoxIcon.Information );
            //    this.Close();
            //}
            //else
            //{
                //try
                //{

                    con.Close();
                    int i = 0;
                    cmd = new SqlCommand("Select count(*) from tblUser where usrName=@a AND usrPass=@b", con);
                    cmd.Parameters.AddWithValue("@a", txtName.Text);
                    cmd.Parameters.AddWithValue("@b", txtPass.Text);
                    con.Open();
                    i = (int)cmd.ExecuteScalar();
                    if (i > 0)
                    {
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                    else
                    {
                        MessageBox.Show("نام کاربری یا گذرواژه نادرست است.");
                    }
                    con.Close();
                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("مشکلی در ورود اطلاعات رخ داده است.");
                //}
            //}
          
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //txtName.Focus();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
