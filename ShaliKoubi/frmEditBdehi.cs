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
    public partial class frmEditBdehi : Form
    {
        public frmEditBdehi()
        {
            InitializeComponent();
        }
        public int CstmrID { get; set; }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        System.Globalization.PersianCalendar date = new System.Globalization.PersianCalendar();
        int TabdilID = -1;

        int firstdone = 0;
        int firstnimdone = 0;
        int firstsabos = 0;

        int newdone = 0;
        int newnimdone = 0;
        int newsabos = 0;
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMahsolBedSalePish where  CstmrID=" + CstmrID;
            adp.Fill(ds, "tblMahsolBedSalePish");
            dgvAnbar.DataSource = ds;
            dgvAnbar.DataMember = "tblMahsolBedSalePish";

            //************************************
            dgvAnbar.Columns["CstmrID"].Visible = false;

            dgvAnbar.Columns["OutputID"].HeaderText = "کد تبدیل";
            dgvAnbar.Columns["OutputID"].Width = 60;

            dgvAnbar.Columns["VazneDone"].HeaderText = "وزن دونه";
            dgvAnbar.Columns["VazneDone"].Width = 70;
            dgvAnbar.Columns["NerkhDone"].HeaderText = "نرخ دونه";
            dgvAnbar.Columns["NerkhDone"].Width = 70;

            dgvAnbar.Columns["VazneSabos"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["VazneSabos"].Width = 70;
            dgvAnbar.Columns["NerkhSabos"].HeaderText = "نرخ سبوس";
            dgvAnbar.Columns["NerkhSabos"].Width = 70;

            dgvAnbar.Columns["VazneNimdone"].HeaderText = "وزن نیم دونه";
            dgvAnbar.Columns["VazneNimdone"].Width = 70;
            dgvAnbar.Columns["NerkhNimdone"].HeaderText = "نرخ نیم دونه";
            dgvAnbar.Columns["NerkhNimdone"].Width = 70;

            dgvAnbar.Columns["MablaghMahsol"].HeaderText = "پرداخت";
            dgvAnbar.Columns["MablaghMahsol"].Width = 90;

        }
        /// <summary>
        /// Get First Data Into tblAnbarKhoroji
        /// </summary>

        public void GetFirstData(int id)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarKhorji where OutputID=" + id;
            con.Open();
            adp.Fill(dt);
            firstdone = (int)dt.Rows[0]["WeightDone"];
            firstnimdone = (int)dt.Rows[0]["WeightNimdone"];
            firstsabos = (int)dt.Rows[0]["WeightSabos1"];
            con.Close();
        }
        public void GetNewData(int id)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMahsolBedSalePish where OutputID=" + id + "AND CstmrID=" + CstmrID;
            con.Open();
            adp.Fill(dt);
            newdone = (int)dt.Rows[0]["VazneDone"];
            newnimdone = (int)dt.Rows[0]["VazneNimdone"];
            newsabos = (int)dt.Rows[0]["VazneSabos"];
            con.Close();
            txtWDone.Text = ( (int)dt.Rows[0]["VazneDone"]).ToString();
            txtWNimdone.Text = ( (int)dt.Rows[0]["VazneNimdone"]).ToString();
            txtWSabos.Text = ( (int)dt.Rows[0]["VazneSabos"]).ToString();
            txtFeeDone.Text = ((int)dt.Rows[0]["NerkhDone"]).ToString();
            txtFeeNimdone.Text = ((int)dt.Rows[0]["NerkhNimdone"]).ToString();
            txtFeeSabos.Text = ((int)dt.Rows[0]["NerkhSabos"]).ToString();
        }
        public void UpdatetblAnbarKhoroji(int WDone, int WSabos, int WNDone, int outid)
        {
            //try
            //{
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Update [tblAnbarKhorji] Set WeightDone=N'" + WDone + "',WeightSabos1=N'" + WSabos + "',weightNimdone=N'" + WNDone + "' where OutputID=" + outid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            //}
        }
        public void UpdatetblListAnbar(int WDone, int WSabos, int WNDone, int outid)
        {
            //try
            //{
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Update [tblListAnbar] Set WDone=N'" + WDone + "',WSabos=N'" + WSabos + "',WNDone=N'" + WNDone + "' where OutputID=" + outid;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            //}
        }
        private void txtWNimdone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeNimdone.Text != "")
                {
                    txtMND.Text = (int.Parse(txtWNimdone.Text) * int.Parse(txtFeeNimdone.Text)).ToString("N0");
                }
                else
                {
                    txtMND.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtFeeNimdone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWNimdone.Text != "")
                {
                    txtMND.Text = (int.Parse(txtWNimdone.Text) * int.Parse(txtFeeNimdone.Text)).ToString("N0");

                }
                else
                {
                    txtMND.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtWSabos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeSabos.Text != "")
                {
                    txtMS.Text = (int.Parse(txtWSabos.Text) * int.Parse(txtFeeSabos.Text)).ToString("N0");
                }
                else
                {
                    txtMS.Text = "0";

                }
            }
            catch (Exception)
            {

            }
        }

        private void txtFeeSabos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWSabos.Text != "")
                {
                    txtMS.Text = (int.Parse(txtWSabos.Text) * int.Parse(txtFeeSabos.Text)).ToString("N0");

                }
                else
                {
                    txtMS.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeDone.Text != "")
                {
                    txtMD.Text = (int.Parse(txtFeeDone.Text) * int.Parse(txtWDone.Text)).ToString("N0");

                }
                else
                {
                    txtMD.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtFeeDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWDone.Text != "")
                {
                    txtMD.Text = (int.Parse(txtFeeDone.Text) * int.Parse(txtWDone.Text)).ToString("N0");

                }
                else
                {
                    txtMD.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void frmEditBdehi_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvAnbar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAnbar.Rows[e.RowIndex].Selected = true;
            TabdilID = (int)dgvAnbar.Rows[e.RowIndex].Cells["OutputID"].Value;            
            lblCodeTabdil.Text = TabdilID.ToString();
            GetFirstData(TabdilID);
            GetNewData(TabdilID);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            int editDone = (firstdone+newdone)-int.Parse(txtWDone.Text);
            int editNimdone = (firstnimdone + newnimdone) - int.Parse(txtWNimdone.Text); 
            int editSabos = (firstsabos + newsabos) - int.Parse(txtWSabos.Text);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdatetblAnbarKhoroji(editDone, editSabos, editNimdone, TabdilID);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            UpdatetblListAnbar(int.Parse(txtWDone.Text), int.Parse(txtWSabos.Text), int.Parse(txtWNimdone.Text), TabdilID);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Update [tblMahsolBedSalePish] Set VazneDone=N'" + int.Parse(txtWDone.Text) + "',VazneSabos=N'" + int.Parse(txtWSabos.Text) + "',VazneNimdone=N'" + int.Parse(txtWNimdone.Text) + "', NerkhDone=N'" + int.Parse(txtFeeDone.Text) + "',NerkhSabos=N'" + int.Parse(txtFeeSabos.Text) + "',NerkhNimdone=N'" + int.Parse(txtFeeNimdone.Text) + "',MablaghMahsol=N'" + int.Parse(lblMajmoeMahsol.Text.Replace(",","")) + "' where OutputID=" + TabdilID;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

                MessageBox.Show("ویرایش با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
        }

        private void txtMND_TextChanged(object sender, EventArgs e)
        {
            lblMajmoeMahsol.Text = (int.Parse(txtMD.Text.Replace(",", "")) + int.Parse(txtMND.Text.Replace(",", "")) + int.Parse(txtMS.Text.Replace(",", ""))).ToString("N0");
        }

        private void txtMS_TextChanged(object sender, EventArgs e)
        {
            lblMajmoeMahsol.Text = (int.Parse(txtMD.Text.Replace(",", "")) + int.Parse(txtMND.Text.Replace(",", "")) + int.Parse(txtMS.Text.Replace(",", ""))).ToString("N0");
        }

        private void txtMD_TextChanged(object sender, EventArgs e)
        {
            lblMajmoeMahsol.Text = (int.Parse(txtMD.Text.Replace(",", "")) + int.Parse(txtMND.Text.Replace(",", "")) + int.Parse(txtMS.Text.Replace(",", ""))).ToString("N0");
        }
    }
}
