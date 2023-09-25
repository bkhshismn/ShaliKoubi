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
    public partial class frmCostomer : Form
    {
        int[] Chek_id = null;
        public frmCostomer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int CstmCode = -1;
        void Cstm()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            CstmCode = (int)dt.Rows[cunt - 1]["id"];
        }
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adb = new SqlDataAdapter();
            adb.SelectCommand = new SqlCommand();
            adb.SelectCommand.Connection = con;
            adb.SelectCommand.CommandText = "select * from View_Customer";
            adb.Fill(ds, "View_Customer");
            
            dgvCstmr.DataSource = ds;
            dgvCstmr.DataMember = "View_Customer";
            dgvCstmr.Columns[0].Visible = false;
            dgvCstmr.Columns["DastiID"].HeaderText = "کد مشتری";
            dgvCstmr.Columns["DastiID"].Width = 70;
            dgvCstmr.Columns["Name"].HeaderText = "نام ";
            dgvCstmr.Columns["Name"].Width = 120;
            dgvCstmr.Columns["Family"].HeaderText = "کد ملی";
            dgvCstmr.Columns["Family"].Width = 120;
            dgvCstmr.Columns["Tel"].HeaderText = "شماره همراه";
            dgvCstmr.Columns["Tel"].Width = 120;
            dgvCstmr.Columns["No"].HeaderText = "نوع مشتری";
            dgvCstmr.Columns["Address"].HeaderText = "آدرس";
            dgvCstmr.Columns["Address"].Width = 170;
        }
        int[] CheckCstmr()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int x = 0;
            int indx = -1;
            string name = "";
            string fam = "";
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    name = dt.Rows[i]["Name"].ToString();
                    fam = dt.Rows[i]["Family"].ToString();
                    if (name == txtName.Text && fam == txtFam.Text)
                    {
                        x = 1;
                        indx = (int)dt.Rows[i]["id"];
                    }
                    break;
                }              
            }
            report[0] = x;
            report[1] = indx;
            return report;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int[] chk = CheckCstmr();

            if (chk[0]==0)
            {
                labelX4.Text = "";
                if (txtName.Text == "" || txtFam.Text == "" || cmbNo.Text == "")
                {
                    labelX4.Text = "فیلد های خالی را پر کنید...";

                    if (txtName.Text == "")
                    {
                        labelX9.Text = "*";
                    }
                    if (txtFam.Text == "")
                    {
                        labelX10.Text = "*";
                    }
                    if (cmbNo.Text == "")
                    {
                        labelX11.Text = "*";
                    }
                }
                else
                {
                    try
                    {
                        using (var ts = new System.Transactions.TransactionScope())
                        {
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into tblCstmr(Name,Family,Tel,Address,No,DastiID)values(@Name,@Family,@Tel,@Address,@No,@DastiID)";
                            cmd.Parameters.AddWithValue("@Name", txtName.Text);
                            cmd.Parameters.AddWithValue("@Family", txtFam.Text);
                            cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@No", cmbNo.Text);
                            cmd.Parameters.AddWithValue("@DastiID", txtDasti.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("ثبت با موفقیت انجام شد");
                            Display();
                            Cstm();
                            mt.InsetAnbar(CstmCode);
                            ts.Complete();
                        }
                            txtName.Text = "";
                            txtFam.Text = "";
                            txtTel.Text = "";
                            cmbNo.Text = "";
                            txtAddress.Text = "";
                        txtDasti.Text = "";

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                    }
                }
            }
            else
            {
                MessageBox.Show("مشتری با این مشخصات قبلا با کد " + chk[1] + " در سیستم ثبت شده است");
            }
           
        }

        private void frmCostomer_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from tblCstmr where id=@n";
                cmd.Parameters.AddWithValue("@n", CstmCode);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update tblCstmr Set Name=N'" + txtName.Text + 
                    "',Family=N'" + txtFam.Text +
                    "',Tel=N'" + txtTel.Text +
                    "',Address=N'" + txtAddress.Text +
                      "',DastiID=N'" + txtDasti.Text +
                    "',No=N'" + cmbNo.Text + "' where id=" + CstmCode;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ویرایش اطلاعات انجام شد.");
                Display();
                txtName.Text = "";
                txtFam.Text = "";
                txtTel.Text = "";
                cmbNo.Text = "";
                txtAddress.Text = "";
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }


        }

        private void frmCostomer_Activated(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvCstmr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd.Parameters.Clear();
            labelX3.Enabled = true;
            labelX7.Enabled = true;
            labelX8.Enabled = true;
            txtTel.Enabled = true;
            cmbNo.Enabled = true;
            txtAddress.Enabled = true;
            int indx = (int)dgvCstmr.Rows[e.RowIndex].Cells[0].Value;
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + indx;
            con.Open();
            adp.Fill(dt);
            CstmCode = indx;
            this.txtName.Text = dt.Rows[0]["Name"].ToString();
            this.txtFam.Text = dt.Rows[0]["Family"].ToString();
            this.txtTel.Text = dt.Rows[0]["Tel"].ToString();
            this.cmbNo.Text = dt.Rows[0]["no"].ToString();
            this.txtAddress.Text = dt.Rows[0]["Address"].ToString();
            this.txtDasti.Text = dt.Rows[0]["DastiID"].ToString();
            con.Close();
            CstmCode = indx;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            dgvCstmr.Visible = true;
            dgvCstmr.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvCstmr.DataSource = ds;
            dgvCstmr.DataMember = "tblCstmr";
            mt.Titr(dgvCstmr);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            dgvCstmr.Visible = true;
            dgvCstmr.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Family Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX2.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvCstmr.DataSource = ds;
            dgvCstmr.DataMember = "tblCstmr";
            mt.Titr(dgvCstmr);
        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            dgvCstmr.Visible = true;
            dgvCstmr.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvCstmr.DataSource = ds;
            dgvCstmr.DataMember = "tblCstmr";
            mt.Titr(dgvCstmr);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
            textBoxX2.Text = "";
            txtSID.Text = "";
        }

        private void dgvCstmr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
