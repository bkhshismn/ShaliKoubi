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
    public partial class frmCost : Form
    {
        public frmCost()
        {
            InitializeComponent();
        }
        int Id = -1;
        public void DisplayCombo()
        {
            string query = "SELECT  SharheKharid FROM [tblSharhKharid]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
            cmbSharh.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbSharh.Items.Add(dt.Rows[i]["SharheKharid"]);
            }
        }

        void DisplayHazine()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblcost]";
                adp.Fill(ds, "tblcost");
                dgvHazine.DataSource = ds;
                dgvHazine.DataMember = "tblcost";
                dgvHazine.Columns["CostID"].HeaderText = "کد";
                dgvHazine.Columns["CostID"].Width = 70;
                dgvHazine.Columns["CostMablagh"].HeaderText = " مبلغ";
                dgvHazine.Columns["CostMablagh"].Width = 70;
                dgvHazine.Columns["SharhHazine"].HeaderText = "شرح هزینه";
                dgvHazine.Columns["SharhHazine"].Width = 160;
                dgvHazine.Columns["Nahve"].HeaderText = "نحوه پرداخت";
                dgvHazine.Columns["Nahve"].Width = 70;
                dgvHazine.Columns["Tavasot"].HeaderText = "توسط";
                dgvHazine.Columns["CostDate"].HeaderText = "تاریخ هزینه";
                dgvHazine.Columns["CostDate"].Width = 70;
                dgvHazine.Columns["CostDiscription"].HeaderText = "توضیحات";
                dgvHazine.Columns["CostDiscription"].Width = 150;
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }

        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        private void frmCost_Load(object sender, EventArgs e)
        {
            txtHazineDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            DisplayCombo();
            DisplayHazine();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmShKharid().ShowDialog();
        }

        private void cmbSharh_Click(object sender, EventArgs e)
        {
            DisplayCombo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked == true)
            {
                nahve += chkNaghd.Text;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }
            if (nahve == "")
            {
                MessageBox.Show(".لطفا نوع پردهخت را انتخاب کنین");
            }
            else
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblCost](CostMablagh,SharhHazine,Tavasot,CostDate,CostDiscription,Nahve)values(@CostMablagh,@SharhHazine,@Tavasot,@CostDate,@CostDiscription,@Nahve)";
                    cmd.Parameters.AddWithValue("@CostMablagh", Convert.ToInt64(txtMablagh.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@SharhHazine", cmbSharh.Text);
                    cmd.Parameters.AddWithValue("@Tavasot", txtTavasot.Text);
                    cmd.Parameters.AddWithValue("@Nahve", nahve);
                    cmd.Parameters.AddWithValue("@CostDate", txtHazineDate.Text);
                    cmd.Parameters.AddWithValue("@CostDiscription", txtCostDis.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت پرداخت نقدی با موفقیت انجام شد");
                    txtMablagh.Text = "";
                    cmbSharh.Text = "";
                    txtCostDis.Text = "";
                    txtTavasot.Text = "";

                    DisplayHazine();

                }

                catch (Exception)
                {

                    MessageBox.Show("مشکلی در ثبت پرداخت نقدی وجود دارد");
                }
                cmbSharh.Focus();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from tblCost where CostId=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtMablagh.Text = "";
                        cmbSharh.Text = "";
                        txtCostDis.Text = "";
                        txtTavasot.Text = "";
                        DisplayHazine();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
                
        }

        private void dgvHazine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = (int)dgvHazine.Rows[e.RowIndex].Cells[0].Value;
                string ckk = "";
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCost where CostID=" + Id;
                con.Open();
                adp.Fill(dt);
                this.txtMablagh.Text = dt.Rows[0]["CostMablagh"].ToString();
                this.cmbSharh.Text = dt.Rows[0]["SharhHazine"].ToString();
                this.txtTavasot.Text = dt.Rows[0]["Tavasot"].ToString();
                ckk = dt.Rows[0]["Nahve"].ToString();
                if (ckk == "نقدی")
                {
                    chkNaghd.Checked = true;
                }
                else if (ckk == "کارت به کارت")
                {
                    chkCard.Checked = true;
                }
                else if (ckk == "چک")
                {
                    chkCheck.Checked = true;
                }
                this.txtHazineDate.Text = dt.Rows[0]["CostDate"].ToString();
                this.txtCostDis.Text = dt.Rows[0]["CostDiscription"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید");
            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string nahve = "";
            if (chkNaghd.Checked == true)
            {
                nahve += chkNaghd.Text;
            }
            if (chkCard.Checked == true)
            {
                nahve += chkCard.Text;
            }
            if (chkCheck.Checked == true)
            {
                nahve += chkCheck.Text;
            }
            if (Id != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update tblCost Set CostMablagh=N'" + txtMablagh.Text.Replace(",", "") + "',SharhHazine=N'" + cmbSharh.Text + "',Tavasot=N'" + txtTavasot.Text + "',CostDate=N'" + txtHazineDate.Text + "',CostDiscription=N'" + txtCostDis.Text + "',Nahve=N'"+ nahve + "' where CostID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtMablagh.Text = "";
                    cmbSharh.Text = "";
                    txtCostDis.Text = "";
                    txtTavasot.Text = "";
                    DisplayHazine();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtMablagh.Text = "";
            cmbSharh.Text = "";
            txtCostDis.Text = "";
            txtTavasot.Text = "";
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtMablagh.Text != string.Empty)
                {
                    txtMablagh.Text = string.Format("{0:N0}", double.Parse(txtMablagh.Text.Replace(",", "")));
                    txtMablagh.Select(txtMablagh.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void dgvHazine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dgvHazine.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
        private void dgvHazine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCost where SharhHazine Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
            adp.Fill(ds, "tblCost");
            dgvHazine.DataSource = ds;
            dgvHazine.DataMember = "tblCost";
            dgvHazine.Columns[0].HeaderText = "کد";
            dgvHazine.Columns[0].Width = 70;
            dgvHazine.Columns[1].HeaderText = " مبلغ";
            dgvHazine.Columns[1].Width = 70;
            dgvHazine.Columns[2].HeaderText = "شرح هزینه";
            dgvHazine.Columns[2].Width = 200;
            dgvHazine.Columns[3].HeaderText = "توسط";
            dgvHazine.Columns[4].HeaderText = "تاریخ هزینه";
            dgvHazine.Columns[4].Width = 70;
            dgvHazine.Columns[5].HeaderText = "توضیحات";
            dgvHazine.Columns[5].Width = 150;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
        }

        private void chkNaghd_CheckedChanged(object sender, EventArgs e)
        {
            chkCard.Checked = false;
            chkCheck.Checked = false;
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            chkNaghd.Checked = false;
            chkCheck.Checked = false;
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {

            chkCard.Checked = false;
            chkNaghd.Checked = false;
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
