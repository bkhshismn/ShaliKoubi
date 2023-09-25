using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaliKoubi
{
    public partial class frmCombine : Form
    {
        public frmCombine()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        CheckBox chkbox = new CheckBox();
        method mt = new method();
        void Titr()
        {
            dgvInSearch.Columns[0].HeaderText = "کد مشتری";
            dgvInSearch.Columns[0].Width = 50;
            dgvInSearch.Columns[1].HeaderText = " نام";
            dgvInSearch.Columns[1].Width = 70;
            dgvInSearch.Columns[2].HeaderText = "نام خانوادگی";
            dgvInSearch.Columns[2].Width = 90;
            dgvInSearch.Columns[3].HeaderText = "تلفن";
            dgvInSearch.Columns[4].HeaderText = "آدرس";
            dgvInSearch.Columns[5].HeaderText = "نوع مشتری";
        }
        void Uapdate(int indext)
        {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update tblInput Set chk='" + 1 + "' where InputID =" + indext;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
        }
        //private void chkBoxChange(object sender, EventArgs e)
        //{
        //    if (chkbox.Checked== true)
        //    {
        //        dgvInputList.Rows.s= true;
        //    }
        //    //for (int k = 0; k <= dgvInputList.RowCount - 1; k++)
        //    //{
        //    //    this.dgvInputList[0, k].Value = this.chkbox.Checked;
        //    //}
        //    //this.dgvInputList.EndEdit();
        //}
        int CstmCode = -1;
        void DisplayCustomerAndInput()
        {
            //dgvInputList.AllowUserToAddRows = false;
            //dgvInputList.Columns.Clear();
            //DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
            //colCB.Name = "chkcol";
            //colCB.HeaderText = "انتخاب";
            //colCB.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvInputList.Columns.Add(colCB);
            //Rectangle rect = this.dgvInputList.GetCellDisplayRectangle(0, -1, true);
            //chkbox.Size = new Size(18, 18);
            //rect.Offset(10, 2);
            //chkbox.Location = rect.Location;
            //chkbox.CheckedChanged += chkBoxChange;
            //this.dgvInputList.Controls.Add(chkbox);
            //------------------------------------------------------------------------------
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_tblCstmrAndtblInput where CstmrID=" + CstmCode+"AND chk !="+1;
            adp.Fill(ds, "View_tblCstmrAndtblInput");
            dgvInputList.DataSource = ds;
            dgvInputList.DataMember = "View_tblCstmrAndtblInput";
            //************************************
            //dgvCstmr.DataSource = ds;
            //dgvCstmr.DataMember = "tblCstmr";
            dgvInputList.Columns[0].HeaderText = "کد محصول";
            dgvInputList.Columns[0].Width = 70;

            dgvInputList.Columns[1].HeaderText = "نام مشتری ";
            dgvInputList.Columns[1].Width = 90;

            dgvInputList.Columns[2].HeaderText = "نام خانوادگی";

            dgvInputList.Columns[3].HeaderText = "کد مشتری";
            dgvInputList.Columns[3].Width = 90;

            dgvInputList.Columns[4].HeaderText = "نوع برنج";
            dgvInputList.Columns[4].Width = 90;

            dgvInputList.Columns[5].HeaderText = "تعداد کیسه برنج";
            dgvInputList.Columns[5].Width = 120;

            dgvInputList.Columns[6].HeaderText = "وزن محصول";
            dgvInputList.Columns[6].Width = 110;

            dgvInputList.Columns[7].Visible = false;
            dgvInputList.Columns[1].Visible = false;
            dgvInputList.Columns[2].Visible = false;
            dgvInputList.Columns[3].Visible = false;
            dgvInputList.Columns[9].Visible = false;
            dgvInputList.Columns[10].Visible = false;
            dgvInputList.Columns[8].HeaderText = " تاریخ ورود";
            dgvInputList.Columns[6].Width = 100;
            //dgvInput.Columns[5].Visible = false;
        }
        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
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

            con.Close();
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
            this.lblName.Text = dt.Rows[0][1].ToString();
            this.lblFam.Text = dt.Rows[0][2].ToString();
            con.Close();
            
            CstmCode = indx;
            //InputID = indx;
            lblID.Text = indx.ToString();
            dgvInSearch.Visible = false;
            DisplayCustomerAndInput();
            btnCloseDgv.Visible = true;
            dgvInputList.Visible = true;
            //chek_selected = true;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 0;
            int[] DCstmrID = new int[dgvInputList.SelectedRows.Count];
            double[] DInTedadKise = new double[dgvInputList.SelectedRows.Count];
            int[] DInWeight = new int[dgvInputList.SelectedRows.Count];
            string[] DInNo = new string[dgvInputList.SelectedRows.Count];
            string[] DInDate = new string[dgvInputList.SelectedRows.Count];
            int DCstmrID1 = -1;
            double DInTedadKise1 = 0;
            int DInWeight1 = 0;
            string DInNo1 = "";
            System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
            string Date = dt.GetYear(DateTime.Now).ToString() + "/" + dt.GetMonth(DateTime.Now).ToString("0#") + "/" + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            string DInDate1 = "";
            string id = "";


            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {

                DCstmrID[i] = (int)dgvInputList.SelectedRows[i].Cells[3].Value;
                DInNo[i] = (string)dgvInputList.SelectedRows[i].Cells[4].Value;
                DInTedadKise[i] = (double)dgvInputList.SelectedRows[i].Cells[5].Value;
                DInWeight[i] = (int)dgvInputList.SelectedRows[i].Cells[6].Value;
                DInDate[i] = (string)dgvInputList.SelectedRows[i].Cells[8].Value;
                //Uapdate((int)dgvInputList.SelectedRows[i].Cells[0].Value);

            }
            int[] idi = new int[dgvInputList.SelectedRows.Count];
            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {
                idi[i] = (int)dgvInputList.SelectedRows[i].Cells[0].Value;
                id += ((string)dgvInputList.SelectedRows[i].Cells[0].Value.ToString() + ",");
                DInNo1 += ((string)dgvInputList.SelectedRows[i].Cells[4].Value + ",");
                DInTedadKise1 += (double)dgvInputList.SelectedRows[i].Cells[5].Value;
                DInWeight1 += (int)dgvInputList.SelectedRows[i].Cells[6].Value;
                DInDate1 += ((string)dgvInputList.SelectedRows[i].Cells[8].Value + "-");
                k = i;

            }
            //DCstmrID1 = int.Parse(lblID.Text);

            DCstmrID1 = (int)dgvInputList.SelectedRows[k].Cells[3].Value;
            //---------------------------------------------------
            #region Convert
            //Tabdil ax be byte
            Image m = pictureBox1.Image;
            MemoryStream ms = new MemoryStream();
            m.Save(ms, m.RawFormat);
            #endregion
            byte[] PicArray1 = ms.ToArray();
            try
            {
                //byte[] PicArray = File.ReadAllBytes(pictureBox1.ImageLocation);
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [tblInput](CstmrID,InNo,InTedadKise,InWeight,InPic,InDate,Discription,chk)values(@CstmrID,@InNo,@InTedadKise,@InWeight,@InPic,@InDate,@Discription,@chk)";
                cmd.Parameters.AddWithValue("@CstmrID", DCstmrID1);
                cmd.Parameters.AddWithValue("@InNo", DInNo1);
                cmd.Parameters.AddWithValue("@InTedadKise", Convert.ToInt32(DInTedadKise1));
                cmd.Parameters.AddWithValue("@InWeight", Convert.ToInt32(DInWeight1));
                cmd.Parameters.AddWithValue("@InPic", SqlDbType.VarBinary).Value = PicArray1;
                cmd.Parameters.AddWithValue("@InDate", Date);
                cmd.Parameters.AddWithValue("@Discription", "این رکورد با ترکیب محصولات با شماده آی دی:" + id + "در تاریخ های:" + DInDate1 + "ایجاد شده است.");
                cmd.Parameters.AddWithValue("@chk", 0);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ادغام محصولات با موفقیت انجام شد.");
                for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblInput] where InputID = @n";
                    cmd.Parameters.AddWithValue("@n", idi[i]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                lblName.Text = "";
                lblFam.Text = "";
                lblID.Text = "";
                DisplayCustomerAndInput();
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblBNo(No)values(@a)";
                    cmd.Parameters.AddWithValue("@a", DInNo1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                }
                //pictureBox1.ImageLocation = null;
            }
            catch (Exception)
            {
                MessageBox.Show(".خطایی در ثبت اطلاعات رخ داده است");
            }
        }

        private void dgvInputList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                this.cms1.Show(this.dgvInputList, e.Location);
                cms1.Show(Cursor.Position);
            }
        }

        private void frmCombine_Load(object sender, EventArgs e)
        {
            
            dgvInSearch.Visible = false;
            dgvInputList.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            btnCloseDgv.Visible = false;
            pictureBox1.Visible = false;
        }

        private void btnCloseDgv_Click(object sender, EventArgs e)
        {
            dgvInputList.Visible = false;
            btnCloseDgv.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int k = 0;
            int[] DCstmrID = new int[dgvInputList.SelectedRows.Count];
            double[] DInTedadKise = new double[dgvInputList.SelectedRows.Count];
            int[] DInWeight = new int[dgvInputList.SelectedRows.Count];
            string[] DInNo = new string[dgvInputList.SelectedRows.Count];
            string[] DInDate = new string[dgvInputList.SelectedRows.Count];
            int DCstmrID1 = -1;
            double DInTedadKise1 = 0;
            int DInWeight1 = 0;
            string DInNo1 = "";
            System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
            string Date = dt.GetYear(DateTime.Now).ToString() + "/" + dt.GetMonth(DateTime.Now).ToString("0#") + "/" + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            string DInDate1 = "";
            string id = "";


            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {

                DCstmrID[i] = (int)dgvInputList.SelectedRows[i].Cells[3].Value;
                DInNo[i] = (string)dgvInputList.SelectedRows[i].Cells[4].Value;
                DInTedadKise[i] = (double)dgvInputList.SelectedRows[i].Cells[5].Value;
                DInWeight[i] = (int)dgvInputList.SelectedRows[i].Cells[6].Value;
                DInDate[i] = (string)dgvInputList.SelectedRows[i].Cells[8].Value;
                //Uapdate((int)dgvInputList.SelectedRows[i].Cells[0].Value);

            }
            int[] idi = new int[dgvInputList.SelectedRows.Count];
            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {
                idi[i] = (int)dgvInputList.SelectedRows[i].Cells[0].Value;
                id += ((string)dgvInputList.SelectedRows[i].Cells[0].Value.ToString() + ",");
                DInNo1 += ((string)dgvInputList.SelectedRows[i].Cells[4].Value + ",");
                DInTedadKise1 += (double)dgvInputList.SelectedRows[i].Cells[5].Value;
                DInWeight1 += (int)dgvInputList.SelectedRows[i].Cells[6].Value;
                DInDate1 += ((string)dgvInputList.SelectedRows[i].Cells[8].Value + "-");
                k = i;

            }
            //DCstmrID1 = int.Parse(lblID.Text);
           
           DCstmrID1 = (int)dgvInputList.SelectedRows[k].Cells[3].Value;
            //---------------------------------------------------
            #region Convert
            //Tabdil ax be byte
            Image m = pictureBox1.Image;
            MemoryStream ms = new MemoryStream();
            m.Save(ms, m.RawFormat);
            #endregion
            byte[] PicArray1 = ms.ToArray();
            try
            {
                //byte[] PicArray = File.ReadAllBytes(pictureBox1.ImageLocation);
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [tblInput](CstmrID,InNo,InTedadKise,InWeight,InPic,InDate,Discription,chk)values(@CstmrID,@InNo,@InTedadKise,@InWeight,@InPic,@InDate,@Discription,@chk)";
                cmd.Parameters.AddWithValue("@CstmrID", DCstmrID1);
                cmd.Parameters.AddWithValue("@InNo", DInNo1);
                cmd.Parameters.AddWithValue("@InTedadKise", Convert.ToInt32(DInTedadKise1));
                cmd.Parameters.AddWithValue("@InWeight", Convert.ToInt32(DInWeight1));
                cmd.Parameters.AddWithValue("@InPic", SqlDbType.VarBinary).Value = PicArray1;
                cmd.Parameters.AddWithValue("@InDate", Date);
                cmd.Parameters.AddWithValue("@Discription", "این رکورد با ترکیب محصولات با شماده آی دی:" + id + "در تاریخ های:" + DInDate1 + "ایجاد شده است.");
                cmd.Parameters.AddWithValue("@chk", 0);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ادغام محصولات با موفقیت انجام شد.");
                for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from [tblInput] where InputID = @n";
                    cmd.Parameters.AddWithValue("@n", idi[i]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                lblName.Text = "";
                lblFam.Text = "";
                lblID.Text = "";
                DisplayCustomerAndInput();
                try
                {
                    con.Close();
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblBNo(No)values(@a)";
                    cmd.Parameters.AddWithValue("@a", DInNo1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

                }
                //pictureBox1.ImageLocation = null;
            }
            catch (Exception)
            {
                MessageBox.Show(".خطایی در ثبت اطلاعات رخ داده است");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            dgvInputList.Visible = true;
            btnCloseDgv.Visible = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtInFamSearch.Text = "";
            textBoxX3.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX3.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            Titr();
        }

    }
}
