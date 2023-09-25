using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;


namespace ShaliKoubi
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        bool check_Click = false;
        int CstmCode = -1;
        int CstmrID = -1;
        int InputID = -1;
        bool chek = false;
        bool chek_selected = false;
        int dgvInput_check = 0;
        int dgvInput_checked = 0;
        Image img = null;
        method mt = new method();
        double vazneshali = 0;
        public void VazneKiseShali()
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
                vazneshali = (double)dt.Rows[0]["WKiseShali"];
                con.Close();
            }
            catch (Exception)
            {
            }

        }
        public void DisplayCombo()
        {
            con.Close();
            string query = "SELECT  No FROM [tblBNo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
            cmbBerenjNo.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbBerenjNo.Items.Add(dt.Rows[i]["No"]);
            }
        }
        #region Method
        public Image Fun_img(byte[] pic)
        {
            MemoryStream m = new MemoryStream(pic);
            return Image.FromStream(m);
        }
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            //************************************
            //dgvCstmr.DataSource = ds;
            //dgvCstmr.DataMember = "tblCstmr";
            dgvInSearch.Columns[0].HeaderText = "کد";
            dgvInSearch.Columns[0].Width = 30;
            dgvInSearch.Columns[1].HeaderText = "نام ";
            dgvInSearch.Columns[1].Width = 120;
            dgvInSearch.Columns[2].HeaderText = "کد ملی";
            dgvInSearch.Columns[3].HeaderText = "شماره همراه";
            dgvInSearch.Columns[3].Width = 120;
            dgvInSearch.Columns[5].HeaderText = "نوع مشتری";
            dgvInSearch.Columns[4].HeaderText = "آدرس";
            dgvInSearch.Columns[4].Width = 170;
            dgvInSearch.Columns[4].Visible = true;
        }
        void DisplayInput()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblInput where CstmrID="+CstmCode;
            adp.Fill(ds, "tblInput");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "tblInput";
            //************************************
            //dgvCstmr.DataSource = ds;
            //dgvCstmr.DataMember = "tblCstmr";
            dgvInput.Columns[0].HeaderText = "کد محصول";
            dgvInput.Columns[0].Visible = false;
            dgvInput.Columns[0].Width = 80;
            dgvInput.Columns[1].HeaderText = "کد محصول";
            dgvInput.Columns[1].Width = 60;
            dgvInput.Columns[2].Visible = false;
            dgvInput.Columns[2].HeaderText = "کد مشتری ";
            dgvInput.Columns[2].Width = 90;
            dgvInput.Columns[3].HeaderText = "نوع شالی";
            dgvInput.Columns[4].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns[4].Width = 120;
            dgvInput.Columns[5].HeaderText = "وزن";
            dgvInput.Columns[5].Width = 100;
            dgvInput.Columns[6].Visible = false;
            dgvInput.Columns[6].HeaderText = "عکس";
            dgvInput.Columns[7].HeaderText = " تاریخ ورود";
            dgvInput.Columns[7].Width = 120;
            dgvInput.Columns[8].HeaderText = " توضیحات";
            dgvInput.Columns[8].Width = 200;
            dgvInput.Columns[9].Visible = false;
            dgvInput.Columns[10].Visible = false;

            //dgvInput.Columns[5].Visible = false;
        }
        /// <summary>
        /// In Tabe Jadval Customer Va Jadval Input Ra Ba Ham Edgham Mikonad.
        /// </summary>
        void DisplayCustomerAndInput()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_tblCstmrAndtblInput where CstmrID=" + CstmCode;
            adp.Fill(ds, "View_tblCstmrAndtblInput");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "View_tblCstmrAndtblInput";
            //************************************
            //dgvCstmr.DataSource = ds;
            //dgvCstmr.DataMember = "tblCstmr";
            dgvInput.Columns[0].HeaderText = "کد محصول";
            dgvInput.Columns[0].Width = 70;

            dgvInput.Columns[1].HeaderText = "نام مشتری ";
            dgvInput.Columns[1].Width = 90;

            dgvInput.Columns[2].HeaderText = "نام خانوادگی";

            dgvInput.Columns[3].HeaderText = "کد مشتری";
            dgvInput.Columns[3].Width = 90;

            dgvInput.Columns[4].HeaderText = "نوع شالی";
            dgvInput.Columns[4].Width = 90;

            dgvInput.Columns[5].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns[5].Width = 110;

            dgvInput.Columns[6].HeaderText = "وزن محصول";
            dgvInput.Columns[6].Width = 120;

            dgvInput.Columns[7].Visible = false;
            dgvInput.Columns[8].HeaderText = " تاریخ ورود";
            dgvInput.Columns[6].Width = 100;
            //dgvInput.Columns[5].Visible = false;
        }
        #endregion
        private void frmInput_Load(object sender, EventArgs e)
        {
            btnCombine.Visible = false;
            DisplayCombo();
            lblChek_TedadBerenj.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = false;
            groupPanel5.Enabled = false;
            pictureBox2.Visible = false;
            System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtInNameSearch.Focus();
            VazneKiseShali();
            

        }

        private void txtInNameSearch_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInNameSearch.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);

        }

        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Show();
        }

        private void txtPrsnlFee_TextChanged(object sender, EventArgs e)
        {
            groupPanel5.Enabled = true;
            chek = true;
        }

        private void txtInFamSearch_TextChanged_1(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Family Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInFamSearch.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indx = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                //labelX4.Text = indx.ToString();
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + indx;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = (dt.Rows[0]["Name"].ToString());// + " "+ dt.Rows[0][2].ToString());
                txtInNameSearch.Text = "";
                txtInFamSearch.Text = "";
                txtSID.Text = "";

                txtInNameSearch.WatermarkText = dt.Rows[0]["Name"].ToString();
                txtInFamSearch.WatermarkText = "Family";
                 
                con.Close();
                CstmCode = indx;
                InputID = indx;
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                txtSID.WatermarkText = dt.Rows[0]["DastiID"].ToString();
                dgvInSearch.Visible = false;
                chek_selected = true;
                check_Click = true;
                DisplayInput();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
            cmbBerenjNo.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblInput] where InputID = @n";
                    cmd.Parameters.AddWithValue("@n", InputID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                    InputID = -1;
                    DisplayInput();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در حذف کاربر رخ داده است.");
                }
            }    
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "All Pictures(*.*)|*.jpg;*bmp;*gif;*.png";
                op.ShowDialog();
                pictureBox1.ImageLocation = op.FileName;
               
            }
            catch (Exception)
            {

                
            }
                    
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtInFamSearch.Text = "";
            txtInNameSearch.Text = "";
            txtSID.Text = "";
            txtInFamSearch.WatermarkText = "";
            txtInNameSearch.WatermarkText = "";
            txtSID.WatermarkText = "";
            dgvInSearch.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_Click == true)
                {
                    #region Convert
                    //Tabdil ax be byte
                    Image m = pictureBox2.Image;
                    MemoryStream ms = new MemoryStream();
                    m.Save(ms, m.RawFormat);
                    #endregion
                    byte[] PicArray1 = ms.ToArray();
                    int weight = 0;
                    if (chek_selected == true)
                    {
                        if (txtTedadBerenj.Text == "")
                        {
                            MessageBox.Show(".لطفا فیلد تعداد کیسه را پر کنید");
                            lblChek_TedadBerenj.Visible = true;
                        }
                        if (txtWeight.Text != "")
                        {
                            weight = Convert.ToInt32(txtWeight.Text.Replace(",", ""));
                        }
                        if (txtTedadBerenj.Text == "" && txtWeight.Text != "")
                        {
                            txtTedadBerenj.Text = Math.Round( (Convert.ToInt32(txtWeight.Text) / vazneshali)).ToString();
                        }
                        if (txtWeight.Text == "")
                        {
                            txtWeight.Text = (Convert.ToDouble(txtTedadBerenj.Text) * vazneshali).ToString();
                        }
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT into [tblInput](CstmrID,InNo,InTedadKise,InWeight,InPic,InDate,Discription,Code)values(@CstmrID,@InNo,@InTedadKise,@InWeight,@InPic,@InDate,@Discription,@Code)";
                        cmd.Parameters.AddWithValue("@CstmrID", CstmCode);
                        cmd.Parameters.AddWithValue("@Code", txtCodeDasti.Text);
                        cmd.Parameters.AddWithValue("@InNo", cmbBerenjNo.Text);
                        cmd.Parameters.AddWithValue("@InTedadKise", Convert.ToDouble(txtTedadBerenj.Text));
                        cmd.Parameters.AddWithValue("@InWeight", txtWeight.Text.Replace(",", ""));
                        cmd.Parameters.AddWithValue("@InPic", SqlDbType.VarBinary).Value = PicArray1;
                        cmd.Parameters.AddWithValue("@InDate", txtDate.Text);
                        cmd.Parameters.AddWithValue("@Discription", txtDiscription.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        txtTedadBerenj.Text = "";
                        txtWeight.Text = "";
                        pictureBox1.ImageLocation = null;
                    }
                    else
                    {
                        MessageBox.Show(".لطفا مشتری را انتخاب کنید");
                        line3.Visible = true;
                        line4.Visible = true;
                    }
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    DisplayInput();
                }
                else
                {
                    MessageBox.Show("لطفا فرد مورد نظر را جستوجو و انتخاب نمایید");
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
            }
        }

        private void txtTedadBerenj_TextChanged(object sender, EventArgs e)
        {
            lblChek_TedadBerenj.Visible = false;
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtTedadBerenj.Text = "";
            txtWeight.Text = "";
            lblName.Text = "";
            lblID.Text = "";
            DisplayInput();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (InputID ==-1)
            {
                MessageBox.Show(".لطفا رکورد مورد نظر جهت ویرایش را انتخاب کنید");
            }
            else
            {
                if (txtTedadBerenj.Text == "")
                {
                    MessageBox.Show(".لطفا فیلد تعداد کیسه را پر کنید");
                    lblChek_TedadBerenj.Visible = true;
                }
                else
                {                 
                    dgvInput_checked++;

                    #region Convert
                    //Tabdil ax be byte
                    Image m = pictureBox1.Image;
                    MemoryStream ms = new MemoryStream();
                    m.Save(ms, m.RawFormat);
                    #endregion
                    byte[] PicArray1 = ms.ToArray();
                    var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستید؟", "هشدار", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandText = "Update tblInput Set CstmrID='" + CstmrID + "',InNo=N'" + cmbBerenjNo.Text + "',Code=N'" + txtCodeDasti.Text + "',InTedadKise='" + txtTedadBerenj.Text + "',InWeight='" + txtWeight.Text + "',InPic=@pic,InDate='" + txtDate.Text + "' where InputID =" + InputID;
                            cmd.Parameters.AddWithValue("@pic", PicArray1);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("ویرایش اطلاعات انجام شد.");
                            cmd.Parameters.Clear();
                                txtTedadBerenj.Text = "";
                                txtWeight.Text = "";
                                lblName.Text = "";
                                lblID.Text = "";
                            DisplayInput();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                        }
                    }
                }               
            }
            
        }
       
        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvInput.Rows[e.RowIndex].Selected = true;
                int indx = (int)dgvInput.Rows[e.RowIndex].Cells["InputID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_tblCstmrAndtblInput where InputID=" + indx;
                con.Open();
                adp.Fill(dt);
                con.Close();
                InputID = indx;
                CstmrID = (int)dt.Rows[0][3];
                txtTedadBerenj.Text = dt.Rows[0]["InTedadKise"].ToString();
                txtCodeDasti.Text = dt.Rows[0]["Code"].ToString();
                cmbBerenjNo.Text = dt.Rows[0]["InNo"].ToString();
                txtDate.Text = dt.Rows[0]["InDate"].ToString();
                txtWeight.Text = dt.Rows[0]["InWeight"].ToString();
                img = Fun_img((byte[])dt.Rows[0]["InPic"]);
                pictureBox1.Image = Fun_img((byte[])dt.Rows[0]["InPic"]);
                dgvInput_check++;
            }
            catch (Exception)
            {

            }
            finally { con.Close(); }        
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            new frmCombine().ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            new frmNo().ShowDialog();
        }

        private void cmbBerenjNo_Click(object sender, EventArgs e)
        {
            DisplayCombo();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            StiReport st = new StiReport();
            st["@id"] = CstmCode;
            st.Load(Application.StartupPath + "/rptInput.mrt");
            st.Show();


        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {

            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where DastiID Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayInput();
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void dgvInSearch_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
    }
}
