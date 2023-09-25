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
    public partial class frmCheckTaghir : Form
    {
        public frmCheckTaghir()
        {
            InitializeComponent();
        }
    SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
    SqlCommand cmd = new SqlCommand();
    method mt = new method();
    string datesabt = "";
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        public int CheckID { get; set; }
        public int No { get; set; }//1=daryafti and 2 = pardakhti
        public int X { get; set; }
        public int Y { get; set; }
        int vaziat = 0;
        string vaziat_text = "";
       public void fun_vaziat()
        {
           
          if (rdbPass.Checked==true)
            {
                vaziat = 1;
                vaziat_text = "پاس شد";
            }
            else if (rdbBargasht.Checked==true)
            {
                vaziat = 2;
                vaziat_text = "برگشتی";
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (rdbPass.Checked == false && rdbBargasht.Checked == false)
            {
                MessageBox.Show("لطفا یکی از گزینه ها را انتخاب کنید");
            }
            else
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update [tblCheck] Set Vaziat ='" + vaziat + "',vaziatText=N'" + vaziat_text + "' where CheckID=" + CheckID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    CheckID = -1;
                }
                catch (Exception)
                {
                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            this.Close();
            var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "frmModiriatCheck").FirstOrDefault();
            if (null != frm)
            {
                frmModiriatCheck master = (frmModiriatCheck)Application.OpenForms["frmModiriatCheck"];
                master.btnRefresh.PerformClick();
            }
            var frm1 = Application.OpenForms.Cast<Form>().Where(x => x.Name == "frmNamayeshCheck").FirstOrDefault();
            if (null != frm1)
            {
                frmNamayeshCheck master = (frmNamayeshCheck)Application.OpenForms["frmNamayeshCheck"];
                master.btnRefresh.PerformClick();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbPass_CheckedChanged(object sender, EventArgs e)
        {
            fun_vaziat();
        }

        private void rdbBargasht_CheckedChanged(object sender, EventArgs e)
        {
            fun_vaziat();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void frmCheckTaghir_Load(object sender, EventArgs e)
        {
           

        }

        private void frmCheckTaghir_LocationChanged(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
