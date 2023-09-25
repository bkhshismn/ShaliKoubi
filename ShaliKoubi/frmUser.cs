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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adb = new SqlDataAdapter();
            adb.SelectCommand = new SqlCommand();
            adb.SelectCommand.Connection = con;
            adb.SelectCommand.CommandText = "select * from tblUser";
            adb.Fill(ds,"tblUser");
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "tblUser";
            dgvUser.Columns[0].HeaderText = "کد";
            dgvUser.Columns[0].Width = 50;
            dgvUser.Columns[1].HeaderText = "نام کاربری";
            dgvUser.Columns[2].HeaderText = "کلمه عبور";
            dgvUser.Columns[3].HeaderText = "شماره همراه";
            dgvUser.Columns[3].Width = 170;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            labelX4.Text = "";
            if (txtName.Text==""||txtPass.Text=="")
            {
                labelX4.Text = "فیلد های خالی را پر کنید...";
                
                if (txtName.Text == "")
                {
                    labelX5.Text = "*";
                }
                if (txtPass.Text  == "")
                {
                    labelX6.Text = "*";
                }
            }
            else
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblUser(usrName,usrPass,usrTel)values(@a,@b,@c)";
                    cmd.Parameters.AddWithValue("@a", txtName.Text);
                    cmd.Parameters.AddWithValue("@b", txtPass.Text);
                    cmd.Parameters.AddWithValue("@c", txtTel.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    Display();
                    txtName.Text = "";
                    txtPass.Text = "";
                    txtTel.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                }
            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            labelX5.Text = "";
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            labelX6.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from tblUser where id=@n";
                cmd.Parameters.AddWithValue("@n", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در حذف کاربر رخ داده است.");
            }
          
        }
    }
}
