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
    public partial class frmNamayeshCheck : Form
    {
        public frmNamayeshCheck()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        string datesabt = "";
        string dateNow;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int ID = -1;
        private void LoadfrmCheckTaghir(int id)
        {
            frmCheckTaghir frm = new frmCheckTaghir();

            frm.CheckID = id;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.X = Cursor.Position.X;
            frm.Y = Cursor.Position.Y;
            frm.ShowDialog();
        }
        void DisplayCheckPardakhti()
        {

            // dateNow = "'" + dateNow + "'";
            try
            {
                con.Close();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCheck where Bes=1  and ChkDate >=N'" + dateNow + "'order by ChkDate ASC";// + " order by ChkDate desc";
            adp.Fill(ds, "tblCheck");
            dgvPCheckPardakhti.DataSource = ds;
            dgvPCheckPardakhti.DataMember = "tblCheck";
            dgvPCheckPardakhti.Columns["CheckID"].HeaderText = "کد";
                dgvPCheckPardakhti.Columns["CheckID"].Width = 50;
                dgvPCheckPardakhti.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheckPardakhti.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheckPardakhti.Columns["ChkDate"].Width = 70;
                dgvPCheckPardakhti.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheckPardakhti.Columns["Shomare"].HeaderText = "شماره چک";
                dgvPCheckPardakhti.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheckPardakhti.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheckPardakhti.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheckPardakhti.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheckPardakhti.Columns["No"].Visible = false;
                dgvPCheckPardakhti.Columns["DateSabt"].HeaderText = "تاریخ ثبت";
                dgvPCheckPardakhti.Columns["DateSabt"].Width = 70;
                dgvPCheckPardakhti.Columns["Discription"].HeaderText = "توضیحات";
                dgvPCheckPardakhti.Columns["Discription"].Width = 500;
                dgvPCheckPardakhti.Columns["Vaziat"].Visible = false;
                dgvPCheckPardakhti.Columns["Bed"].Visible = false;
                dgvPCheckPardakhti.Columns["Bes"].Visible = false;
                dgvPCheckPardakhti.Columns["MoshtariID"].Visible = false;
                dgvPCheckPardakhti.Columns["VaziatText"].HeaderText = "وضعیت";
                dgvPCheckPardakhti.Columns["MoshtariID"].Visible = false;
                for (int i = 0; i < dgvPCheckPardakhti.RowCount; i++)
                {
                    if (dgvPCheckPardakhti.Rows[i].Cells["ChkDate"].Value.ToString() == dateNow.ToString())
                    {
                        dgvPCheckPardakhti.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
            catch (Exception)
            {
               // MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }
        void DisplayCheckDaryafti()
        {
            //dateNow = "'" + dateNow + "'";
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCheck where Bed=1 and ChkDate >=N'" + dateNow + "'order by ChkDate ASC";// + " order by ChkDate desc";
                adp.Fill(ds, "tblCheck");
                dgvPCheckDaryafti.DataSource = ds;
                dgvPCheckDaryafti.DataMember = "tblCheck";
                dgvPCheckDaryafti.Columns["CheckID"].HeaderText = "کد";
                dgvPCheckDaryafti.Columns["CheckID"].Width = 50;
                dgvPCheckDaryafti.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheckDaryafti.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheckDaryafti.Columns["ChkDate"].Width = 70;
                dgvPCheckDaryafti.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheckDaryafti.Columns["Shomare"].HeaderText = "شماره چک";
                dgvPCheckDaryafti.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheckDaryafti.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheckDaryafti.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheckDaryafti.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheckDaryafti.Columns["No"].Visible = false;
                dgvPCheckDaryafti.Columns["DateSabt"].HeaderText = "تاریخ ثبت";
                dgvPCheckDaryafti.Columns["DateSabt"].Width = 70;
                dgvPCheckDaryafti.Columns["Discription"].HeaderText = "توضیحات";
                dgvPCheckDaryafti.Columns["Discription"].Width = 500;
                dgvPCheckDaryafti.Columns["Vaziat"].Visible = false;
                dgvPCheckDaryafti.Columns["Bed"].Visible = false;
                dgvPCheckDaryafti.Columns["Bes"].Visible = false;
                dgvPCheckDaryafti.Columns["MoshtariID"].Visible = false;
                dgvPCheckDaryafti.Columns["VaziatText"].HeaderText = "وضعیت";
                dgvPCheckDaryafti.Columns["MoshtariID"].Visible = false;
                for (int i = 0; i < dgvPCheckDaryafti.RowCount; i++)
                {
                    if (dgvPCheckDaryafti.Rows[i].Cells["ChkDate"].Value.ToString() == dateNow.ToString())
                    {
                        dgvPCheckDaryafti.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
            catch (Exception)
            {
                // MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }
        private void frmNamayeshCheck_Load(object sender, EventArgs e)
        {
            dateNow = dt.GetYear(DateTime.Now).ToString() + "/" + dt.GetMonth(DateTime.Now).ToString("0#") + "/" + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayCheckDaryafti();
            DisplayCheckPardakhti();
            btnRefresh.Visible = false;
        }

        private void dgvPCheckPardakhti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPCheckPardakhti.Columns["Mablagh"].Index && e.RowIndex != this.dgvPCheckPardakhti.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if ( dgvPCheckPardakhti.Columns["ChkDate"].Equals(dateNow.ToString()) )
            {
                dgvPCheckPardakhti.Columns["ChkDate"].DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void dgvPCheckDaryafti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPCheckDaryafti.Columns["Mablagh"].Index && e.RowIndex != this.dgvPCheckDaryafti.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void dgvPCheckPardakhti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = (int)dgvPCheckPardakhti.Rows[e.RowIndex].Cells["CheckID"].Value;
                LoadfrmCheckTaghir(ID);
            }
            catch (Exception)
            {

            }
           
        }

        private void dgvPCheckDaryafti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = (int)dgvPCheckDaryafti.Rows[e.RowIndex].Cells["CheckID"].Value;
                LoadfrmCheckTaghir(ID);
               
            }
            catch (Exception)
            {

            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCheckPardakhti();
            DisplayCheckDaryafti();
        }
    }
}
