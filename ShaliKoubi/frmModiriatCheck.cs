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
    public partial class frmModiriatCheck : Form
    {
        public frmModiriatCheck()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        string datesabt = "";
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int ID = -1;
    
        private void LoadfrmCheckTaghir(int id)
        {
            frmCheckTaghir frm = new frmCheckTaghir();

            frm.CheckID=id;
            frm.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            frm.X = Cursor.Position.X;
            frm.Y = Cursor.Position.Y;
            frm.ShowDialog();
        }
        void DisplayCheckPardakhti()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblCheck] where Bes=" + 1+" order by CheckID desc";
                adp.Fill(ds, "tblCheck");
                dgvPCheck1.DataSource = ds;
                dgvPCheck1.DataMember = "tblCheck";
                dgvPCheck1.Columns["CheckID"].HeaderText = "کد";
                dgvPCheck1.Columns["CheckID"].Width = 50;
                dgvPCheck1.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheck1.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheck1.Columns["ChkDate"].Width = 70;
                dgvPCheck1.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheck1.Columns["Shomare"].HeaderText = "شماره چک";
                dgvPCheck1.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheck1.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheck1.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheck1.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheck1.Columns["No"].Visible = false;
                dgvPCheck1.Columns["DateSabt"].HeaderText = "تاریخ ثبت";
                dgvPCheck1.Columns["DateSabt"].Width = 70;
                dgvPCheck1.Columns["Discription"].HeaderText = "توضیحات";
                dgvPCheck1.Columns["Discription"].Width = 500;
                dgvPCheck1.Columns["Vaziat"].Visible = false;
                dgvPCheck1.Columns["Bed"].Visible = false;
                dgvPCheck1.Columns["Bes"].Visible = false;
                dgvPCheck1.Columns["MoshtariID"].Visible = false;
                dgvPCheck1.Columns["VaziatText"].HeaderText = "وضعیت";
                dgvPCheck1.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }
        void DisplayCheckDaryafti()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblCheck] where Bed=" + 1 + " order by CheckID desc";
                adp.Fill(ds, "tblCheck");
                dgvPCheck.DataSource = ds;
                dgvPCheck.DataMember = "tblCheck";
                dgvPCheck.Columns["CheckID"].HeaderText = "کد";
                dgvPCheck.Columns["CheckID"].Width = 50;
                dgvPCheck.Columns["NoBank"].HeaderText = "نام بانک";
                dgvPCheck.Columns["ChkDate"].HeaderText = "تاریخ وصول";
                dgvPCheck.Columns["ChkDate"].Width = 70;
                dgvPCheck.Columns["Mablagh"].HeaderText = "مبلغ";
                dgvPCheck.Columns["Shomare"].HeaderText = "شماره چک";
                dgvPCheck.Columns["Darvajh"].HeaderText = "در وجه";
                dgvPCheck.Columns["FLName"].HeaderText = "نام صاحب چک";
                dgvPCheck.Columns["ShomareHesab"].HeaderText = "شماره حساب";
                dgvPCheck.Columns["Shobe"].HeaderText = "شعبه";
                dgvPCheck.Columns["No"].Visible = false;
                dgvPCheck.Columns["DateSabt"].HeaderText = "تاریخ ثبت";
                dgvPCheck.Columns["DateSabt"].Width = 70;
                dgvPCheck.Columns["Discription"].HeaderText = "توضیحات";
                dgvPCheck.Columns["Discription"].Width = 500;
                dgvPCheck.Columns["Vaziat"].Visible = false;
                dgvPCheck.Columns["Bed"].Visible = false;
                dgvPCheck.Columns["Bes"].Visible = false;
                dgvPCheck.Columns["MoshtariID"].Visible = false;
                dgvPCheck.Columns["VaziatText"].HeaderText = "وضعیت";
                dgvPCheck.Columns["MoshtariID"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }
        private void frmModiriatCheck_Load(object sender, EventArgs e)
        {
            lnBank1.Visible = false;
            lnTarikh1.Visible = false;
            lnShobe1.Visible = false;
            lnMablaghCheck1.Visible = false;
            lnDarvajh1.Visible = false;
            lnShomareCheck1.Visible = false;
            txtChekDate1.Text = dt.GetYear(DateTime.Now).ToString()  + dt.GetMonth(DateTime.Now).ToString("0#")  + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            datesabt = dt.GetYear(DateTime.Now).ToString() + "/" + dt.GetMonth(DateTime.Now).ToString("0#") + "/" + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lnBank.Visible = false;
            lnTarikh.Visible = false;
            lnShobe.Visible = false;
            lnMablaghCheck.Visible = false;
            lnDarvajh.Visible = false;
            lnShomareCheck.Visible = false;
            txtChekDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            btnRefresh.Visible = false;
            DisplayCheckPardakhti();
            DisplayCheckDaryafti();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtMablagh1.Text == "")
            {
                lnMablaghCheck1.Visible = true;
            }
            if (txtNoBank1.Text == "")
            {
                lnBank1.Visible = true;
            }
            if (txtDarVajh1.Text == "")
            {
                lnDarvajh1.Visible = true;
            }
            if (txtShobe1.Text == "")
            {
                lnShobe1.Visible = true;
            }
            if (txtShomareCheck1.Text == "")
            {
                lnShomareCheck1.Visible = true;
            }
            if (txtChekDate1.Text == "")
            {
                lnTarikh1.Visible = true;
            }
            if (txtMablagh1.Text != "" && txtNoBank1.Text != "" && txtDarVajh1.Text != "" && txtShobe1.Text != "" && txtShomareCheck1.Text != "" && txtChekDate1.Text != "")
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblCheck] (NoBank,ChkDate,Mablagh,Shomare,Darvajh,FLName,ShomareHesab,Shobe,Discription,Vaziat,vaziatText,Bes,DateSabt)values(@NoBank,@ChkDate,@Mablagh,@Shomare,@Darvajh,@FLName,@ShomareHesab,@Shobe,@Discription,@Vaziat,@vaziatText,@Bes,@DateSabt)";
                    cmd.Parameters.AddWithValue("@NoBank", txtNoBank1.Text);
                    cmd.Parameters.AddWithValue("@ChkDate", txtChekDate1.Text);
                    cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt32(txtMablagh1.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@Shomare", txtShomareCheck1.Text);
                    cmd.Parameters.AddWithValue("@Darvajh", txtDarVajh1.Text);
                    cmd.Parameters.AddWithValue("@FLName", txtName1.Text);
                    cmd.Parameters.AddWithValue("@ShomareHesab", txtShomareHesab1.Text);
                    cmd.Parameters.AddWithValue("@Shobe", txtShobe1.Text);
                    cmd.Parameters.AddWithValue("@Discription", txtPayCheckDiscription1.Text);
                    cmd.Parameters.AddWithValue("@Vaziat", 0);//1=Pardakht/ 2=Bargsasht/ 3= Tamdid va poshtnvisi
                    cmd.Parameters.AddWithValue("@vaziatText", "پرداختی");
                    cmd.Parameters.AddWithValue("@Bes", 1);
                    cmd.Parameters.AddWithValue("@DateSabt", datesabt);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت اطلاعات انجام شد.");
                    txtNoBank1.Text = "";
                    txtMablagh1.Text = "0";
                    txtShobe1.Text = "";
                    txtShomareCheck1.Text = "";
                    txtShomareHesab1.Text = "";
                    txtName1.Text = "";
                    txtDarVajh1.Text = "";
                    txtPayCheckDiscription1.Text = "";
                    DisplayCheckPardakhti();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت وجود دارد");
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtNoBank1.Text = "";
            txtMablagh1.Text = "0";
            txtShobe1.Text = "";
            txtShomareCheck1.Text = "";
            txtShomareHesab1.Text = "";
            txtName1.Text = "";
            txtDarVajh1.Text = "";
            txtPayCheckDiscription1.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Update [tblCheck] Set NoBank=N'" + txtNoBank1.Text +
                            "',ChkDate=N'" + txtChekDate1.Text + 
                            "',Shomare=N'" + txtShomareCheck1.Text +
                            "',Mablagh=N'" + txtMablagh1.Text.Replace(",", "") +
                            "',Darvajh=N'" + txtDarVajh1.Text +
                            "',FLName=N'" + txtName1.Text + 
                            "',ShomareHesab=N'" + txtShomareHesab1.Text + 
                            "',Shobe=N'" + txtShobe1.Text + 
                            "',Discription=N'" + txtPayCheckDiscription1.Text +
                            "' where CheckID=" + ID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ID = -1;
                        DisplayCheckPardakhti();
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        txtNoBank1.Text = "";
                        txtMablagh1.Text = "0";
                        txtShobe1.Text = "";
                        txtShomareCheck1.Text = "";
                        txtShomareHesab1.Text = "";
                        txtName1.Text = "";
                        txtDarVajh1.Text = "";
                        txtPayCheckDiscription1.Text = "";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }

        private void dgvPCheck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            try
            {
                dgvPCheck1.Rows[e.RowIndex].Selected = true;
                ID = (int)dgvPCheck1.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCheck where CheckID=" + ID;
                con.Open();
                adp.Fill(dt);
                this.txtNoBank1.Text = dt.Rows[0]["NoBank"].ToString();//txtShobe
;
                this.txtChekDate1.Text = dt.Rows[0]["ChkDate"].ToString();
                this.txtMablagh1.Text = dt.Rows[0]["Mablagh"].ToString();
                this.txtShomareCheck1.Text = dt.Rows[0]["Shomare"].ToString();
                this.txtDarVajh1.Text = dt.Rows[0]["Darvajh"].ToString();
                this.txtName1.Text = dt.Rows[0]["FLName"].ToString();
                this.txtShomareHesab1.Text = dt.Rows[0]["ShomareHesab"].ToString();
                this.txtShobe1.Text = dt.Rows[0]["Shobe"].ToString();

                this.txtPayCheckDiscription1.Text = dt.Rows[0]["Discription"].ToString();

                con.Close();
              
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("آیا مایل به حذف رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from [tblCheck] where CheckID=" + ID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ID = -1;
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtNoBank1.Text = "";
                        txtMablagh1.Text = "0";
                        txtShobe1.Text = "";
                        txtShomareCheck1.Text = "";
                        txtShomareHesab1.Text = "";
                        txtName1.Text = "";
                        txtDarVajh1.Text = "";
                        txtPayCheckDiscription1.Text = "";
                        DisplayCheckPardakhti();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                    finally { con.Close(); }
                }
                else { MessageBox.Show("لطفا روی رکورد  مورد نظر کلیک کنید"); }
            }
        }


        private void buttonX10_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Update [tblCheck] Set NoBank=N'" + txtNoBank.Text +
                            "',ChkDate=N'" + txtChekDate.Text +
                            "',Shomare=N'" + txtShomareCheck.Text +
                            "',Mablagh=N'" + txtMablagh.Text.Replace(",", "") +
                            "',Darvajh=N'" + txtDarVajh.Text +
                            "',FLName=N'" + txtName.Text +
                            "',ShomareHesab=N'" + txtShomareHesab.Text +
                            "',Shobe=N'" + txtShobe.Text +
                            "',Discription=N'" + txtPayCheckDiscription.Text +
                            "' where CheckID=" + ID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ID = -1;
                        DisplayCheckDaryafti();
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ID != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from [tblCheck] where CheckID=" + ID;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ID = -1;
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        txtNoBank.Text = "";
                        txtMablagh.Text = "0";
                        txtShobe.Text = "";
                        txtShomareCheck.Text = "";
                        txtShomareHesab.Text = "";
                        txtName.Text = "";
                        txtDarVajh.Text = "";
                        txtPayCheckDiscription.Text = "";
                        DisplayCheckDaryafti();

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                    finally { con.Close(); }
                }
                else { MessageBox.Show("لطفا روی رکورد  مورد نظر کلیک کنید"); }
            }
        }

        private void btnSaveDaryaft_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDaryaft_Click_1(object sender, EventArgs e)
        {

            if (txtMablagh.Text == "")
            {
                lnMablaghCheck.Visible = true;
            }
            if (txtNoBank.Text == "")
            {
                lnBank.Visible = true;
            }
            if (txtDarVajh.Text == "")
            {
                lnDarvajh.Visible = true;
            }
            if (txtShobe.Text == "")
            {
                lnShobe.Visible = true;
            }
            if (txtShomareCheck.Text == "")
            {
                lnShomareCheck.Visible = true;
            }
            if (txtChekDate.Text == "")
            {
                lnTarikh.Visible = true;
            }
            if (txtMablagh.Text != "" && txtNoBank.Text != "" && txtDarVajh.Text != "" && txtShobe.Text != "" && txtShomareCheck.Text != "" && txtChekDate.Text != "")
            {
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblCheck] (NoBank,ChkDate,Mablagh,Shomare,Darvajh,FLName,ShomareHesab,Shobe,Discription,Vaziat,vaziatText,Bed,DateSabt)values(@NoBank,@ChkDate,@Mablagh,@Shomare,@Darvajh,@FLName,@ShomareHesab,@Shobe,@Discription,@Vaziat,@vaziatText,@Bes,@DateSabt)";
                    cmd.Parameters.AddWithValue("@NoBank", txtNoBank.Text);
                    cmd.Parameters.AddWithValue("@ChkDate", txtChekDate.Text);
                    cmd.Parameters.AddWithValue("@Mablagh", Convert.ToInt32(txtMablagh.Text.Replace(",", "")));
                    cmd.Parameters.AddWithValue("@Shomare", txtShomareCheck.Text);
                    cmd.Parameters.AddWithValue("@Darvajh", txtDarVajh.Text);
                    cmd.Parameters.AddWithValue("@FLName", txtName.Text);
                    cmd.Parameters.AddWithValue("@ShomareHesab", txtShomareHesab.Text);
                    cmd.Parameters.AddWithValue("@Shobe", txtShobe.Text);
                    cmd.Parameters.AddWithValue("@Discription", txtPayCheckDiscription.Text);
                    cmd.Parameters.AddWithValue("@Vaziat", 0);//0=Pardakht/ 1=Bargsasht/ 2= Tamdid va poshtnvisi
                    cmd.Parameters.AddWithValue("@vaziatText", "دریافتی");
                    cmd.Parameters.AddWithValue("@Bes", 1);
                    cmd.Parameters.AddWithValue("@DateSabt", datesabt);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ثبت اطلاعات انجام شد.");
                    txtNoBank.Text = "";
                    txtMablagh.Text = "0";
                    txtShobe.Text = "";
                    txtShomareCheck.Text = "";
                    txtShomareHesab.Text = "";
                    txtName.Text = "";
                    txtDarVajh.Text = "";
                    txtPayCheckDiscription.Text = "";
                    DisplayCheckDaryafti();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت وجود دارد");
                }
            }
        }

        private void dgvPCheck_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                dgvPCheck.Rows[e.RowIndex].Selected = true;
                ID = (int)dgvPCheck.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCheck where CheckID=" + ID;
                con.Open();
                adp.Fill(dt);
                this.txtNoBank.Text = dt.Rows[0]["NoBank"].ToString();
                this.txtChekDate.Text = dt.Rows[0]["ChkDate"].ToString();
                this.txtMablagh.Text = dt.Rows[0]["Mablagh"].ToString();
                this.txtShomareCheck.Text = dt.Rows[0]["Shomare"].ToString();
                this.txtDarVajh.Text = dt.Rows[0]["Darvajh"].ToString();
                this.txtName.Text = dt.Rows[0]["FLName"].ToString();
                this.txtShomareHesab.Text = dt.Rows[0]["ShomareHesab"].ToString();
                this.txtShobe.Text = dt.Rows[0]["Shobe"].ToString();
                this.txtPayCheckDiscription.Text = dt.Rows[0]["Discription"].ToString();

                con.Close();
              
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب اطلاعات رخ داده است");
            }
            finally { con.Close(); }
        }

        private void dgvPCheck1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPCheck1.Columns["Mablagh"].Index && e.RowIndex != this.dgvPCheck1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void dgvPCheck_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvPCheck.Columns["Mablagh"].Index && e.RowIndex != this.dgvPCheck.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtMablagh.Text != string.Empty || txtMablagh.Text != "0")
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

        private void txtMablagh1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtMablagh1.Text != string.Empty || txtMablagh1.Text != "0")
                {
                    txtMablagh1.Text = string.Format("{0:N0}", double.Parse(txtMablagh1.Text.Replace(",", "")));
                    txtMablagh1.Select(txtMablagh.TextLength, 0);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCheckPardakhti();
            DisplayCheckDaryafti();
        }

        private void dgvPCheck1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadfrmCheckTaghir(ID);
        }

        private void dgvPCheck_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadfrmCheckTaghir(ID);
        }
    }
}
