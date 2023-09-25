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
    public partial class frmShKharid : Form
    {
        public frmShKharid()
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
            adb.SelectCommand.CommandText = "select * from tblSharhKharid";
            adb.Fill(ds, "tblSharhKharid");

           dataGridViewX1.DataSource = ds;
            dataGridViewX1.DataMember = "tblSharhKharid";
            dataGridViewX1.Columns[0].HeaderText = "کد";
            dataGridViewX1.Columns[0].Width = 30;
            dataGridViewX1.Columns[1].HeaderText = "عنوان ";
            dataGridViewX1.Columns[1].Width = 200;
           
        }
        private void frmShKharid_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into tblSharhKharid(SharheKharid)values(@a)";
                cmd.Parameters.AddWithValue("@a", txtSharh.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت با موفقیت انجام شد");
                Display();
                txtSharh.Text = "";

            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int x = Convert.ToInt32(dataGridViewX1.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from tblSharhKharid where id=@n";
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
}
