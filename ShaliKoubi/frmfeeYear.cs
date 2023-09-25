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
    public partial class frmfeeYear : Form
    {
        public frmfeeYear()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int Id = 2;
        int Idd = -1;
        method mt = new method();

        //public void DisplayCombo()
        //{
        //    con.Close();
        //    string query = "SELECT  No FROM [tblBNo]";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    con.Open();
        //    cmd.ExecuteScalar();
        //    con.Close();
        //    cmbBerenjNo.Items.Clear();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        cmbBerenjNo.Items.Add(dt.Rows[i]["No"]);
        //    }
        //}
        void Display()
        {

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblFeeYear]";
                adp.Fill(ds, "tblFeeYear");
                con.Open();
                adp.Fill(dt);
                txtFeeYear.Text= dt.Rows[0]["FeeYear"].ToString();
                txtKiseTajeri.Text = dt.Rows[0]["KiseTajeri"].ToString();
                txtVaznKeshavarzi.Text = dt.Rows[0]["VaznKeshavarzi"].ToString();
                txtVaznTajeri.Text = dt.Rows[0]["VaznTajeri"].ToString();
                txtSabos.Text = dt.Rows[0]["SabosNarm"].ToString();
                txtDo.Text = dt.Rows[0]["KeshteDo"].ToString();

                txtVaznSabos1.Text = dt.Rows[0]["WSabosNarm"].ToString();
                txtVaznSabos2.Text = dt.Rows[0]["WSabosDo"].ToString();
                txtWD.Text = dt.Rows[0]["WKDone"].ToString();
                txtShali.Text = dt.Rows[0]["WKiseShali"].ToString();
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }

        void DisplayN()
        {

            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblBNo]";
                adp.Fill(ds, "tblBNo");
                dgvNo.DataSource = ds;
                dgvNo.DataMember = "tblBNo";
                dgvNo.Columns["BNoID"].Visible = false;

                dgvNo.Columns["No"].HeaderText = "نوع شالی";
                dgvNo.Columns["No"].Width = 90;

                dgvNo.Columns["FDone"].HeaderText = "نرخ برنج";
                dgvNo.Columns["FDone"].Width = 70;

                dgvNo.Columns["FNimdone"].HeaderText = "نرخ نیمدونه";
                dgvNo.Columns["FNimdone"].Width = 70;



            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        private void frmfeeYear_Load(object sender, EventArgs e)
        {
            Display();
            DisplayN();
            //DisplayCombo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            con.Close();
            if (Id !=-1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblFeeYear Set KiseTajeri=N'" + Convert.ToInt32(txtKiseTajeri.Text.Replace(",", "")) + "',FeeYear=N'" + Convert.ToInt32(txtFeeYear.Text.Replace(",", "")) + "',VaznTajeri=N'" + Convert.ToInt32(txtVaznTajeri.Text.Replace(",", "")) + "', VaznKeshavarzi=N'" + Convert.ToInt32(txtVaznKeshavarzi.Text.Replace(",", "")) + "',SabosNarm=N'" + Convert.ToInt32(txtSabos.Text.Replace(",", "")) + "',KeshteDo=N'" + Convert.ToInt32(txtDo.Text.Replace(",", "")) + "',WSabosNarm=N'" +txtVaznSabos1.Text + "',WSabosDo=N'" +txtVaznSabos2.Text + "',WKiseShali=N'" + txtShali.Text + "',WKDone=N'" + txtWD.Text + "' where YearsID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtFeeYear.Text = "";
                    txtKiseTajeri.Text = "";
                    txtVaznTajeri.Text = "";
                    txtVaznKeshavarzi.Text = "";
                    Display();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
           
        }

        private void dgvNo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Close();
            Idd = (int)dgvNo.Rows[e.RowIndex].Cells[0].Value;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblBNo where BNoID=" + Idd;
            con.Open();
            adp.Fill(dt);
            txtND.Text = dt.Rows[0]["FNimdone"].ToString();
            txtD.Text = dt.Rows[0]["FDone"].ToString();
            cmbBerenjNo.Text= dt.Rows[0]["No"].ToString();
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Idd != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblBNo Set FDone=N'" + Convert.ToInt32(txtD.Text.Replace(",", "")) + "',FNimdone=N'" + Convert.ToInt32(txtND.Text.Replace(",", "")) + "' where BNoID=" + Idd;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtD.Text = "";
                    txtND.Text = "";
                    DisplayN();
                    cmd.Parameters.Clear();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
        }

        private void txtFeeYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeYear.Text != string.Empty)
                {
                    txtFeeYear.Text = string.Format("{0:N0}", double.Parse(txtFeeYear.Text.Replace(",", "")));
                    txtFeeYear.Select(txtFeeYear.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtKiseTajeri_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtKiseTajeri.Text != string.Empty)
                {
                    txtKiseTajeri.Text = string.Format("{0:N0}", double.Parse(txtKiseTajeri.Text.Replace(",", "")));
                    txtKiseTajeri.Select(txtKiseTajeri.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtDo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDo.Text != string.Empty)
                {
                    txtDo.Text = string.Format("{0:N0}", double.Parse(txtDo.Text.Replace(",", "")));
                    txtDo.Select(txtDo.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtVaznTajeri_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVaznTajeri.Text != string.Empty)
                {
                    txtVaznTajeri.Text = string.Format("{0:N0}", double.Parse(txtVaznTajeri.Text.Replace(",", "")));
                    txtVaznTajeri.Select(txtVaznTajeri.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtVaznKeshavarzi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVaznKeshavarzi.Text != string.Empty)
                {
                    txtVaznKeshavarzi.Text = string.Format("{0:N0}", double.Parse(txtVaznKeshavarzi.Text.Replace(",", "")));
                    txtVaznKeshavarzi.Select(txtVaznKeshavarzi.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtSabos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSabos.Text != string.Empty)
                {
                    txtSabos.Text = string.Format("{0:N0}", double.Parse(txtSabos.Text.Replace(",", "")));
                    txtSabos.Select(txtSabos.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtND_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtND.Text != string.Empty)
                {
                    txtND.Text = string.Format("{0:N0}", double.Parse(txtND.Text.Replace(",", "")));
                    txtND.Select(txtND.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtD.Text != string.Empty)
                {
                    txtD.Text = string.Format("{0:N0}", double.Parse(txtD.Text.Replace(",", "")));
                    txtD.Select(txtD.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void dgvNo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvNo.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 3 && e.RowIndex != this.dgvNo.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
    }
}
