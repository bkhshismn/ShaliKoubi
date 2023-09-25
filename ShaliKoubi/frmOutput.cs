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
    public partial class frmOutput : Form
    {
        public frmOutput()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        #region Variables
        bool nim = false;
        double TedadKise = 0;
        int CstmCode = -1;
        int cstmID = -1;
        int outid = -1;
        int OutPutID = -1;
        int PrccID = -1;
        int Id = -1;
        double vs1 = 0;
        double vs2 = 0;
        int x=0;
        double y =0;
        string NoMoshtari = "";
        string NoBerenj = "";
        int fSabos = 0;
        int fNimdone = 0;
        int ProcessIdtblAnbarKhoroji = -1;
        int ProcessIdtblOutput = -1;
        int outIDtblAnbarKhoroji = -1;
        int NoKarmozd = 0;//1=kisei , 2 = vazni
        //tblFeeYear/////////////////////////
        double VaznKise = 0;
        int NkiseTajeri = 0;
        int NKiseKeshavarz = 0;
        int NVazniKeshavarz = 0;
        int NVazniTajer = 0;
        int NKharidSabos = 0;
        int NKeshteDo = 0;
        double VaznSabosNarm = 0;
        double VaznSabosDo = 0;
        int karmozdkise = 0;
        int karmozdvazn = 0;
        string InNo = "";
        //DataTable_Mahsolat------------------------------------
        DataTable dt_Done = new DataTable();
        DataTable dt_Ndone = new DataTable();
        DataTable dt_SabosNarm = new DataTable();
        //-------------------------------------------
        int noDone = 0;
        bool chk_nime = false;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        #endregion
        #region Methods
        void NOMoshtari()
        {
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + cstmID;
            con.Open();
            adp.Fill(dt);
            NoMoshtari = dt.Rows[0]["No"].ToString();
        }
        void DisplayProcessView()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_InputAndProcess where CstmrID=" + CstmCode + "AND chk_Process !=1";
            adp.Fill(ds, "View_InputAndProcess");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "View_InputAndProcess";
            //************************************

            dgvInput.Columns["Code"].HeaderText = "کد محصول";
            dgvInput.Columns["Code"].Width = 70;
            dgvInput.Columns["InputID"].Visible = false;

            dgvInput.Columns["CstmrID"].HeaderText = "کد مشتری";
            dgvInput.Columns["CstmrID"].Width = 70;
            dgvInput.Columns["CstmrID"].Visible = false;

            dgvInput.Columns["Name"].HeaderText = "نام ";
            dgvInput.Columns["Name"].Width = 90;
            dgvInput.Columns["Name"].Visible = false;

            dgvInput.Columns["Family"].HeaderText = "نام خانوادگی";
            dgvInput.Columns["Family"].Width = 90;
            dgvInput.Columns["Family"].Visible = false;

            dgvInput.Columns["InNo"].HeaderText = "نوع شالی";
            dgvInput.Columns["InNo"].Width = 90;

            dgvInput.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns["InTedadKise"].Width = 90;

            dgvInput.Columns["InDate"].HeaderText = "تاریخ ورود به کارخانه";
            dgvInput.Columns["InDate"].Width = 90;

            dgvInput.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر(قسمت اول)";
            dgvInput.Columns["inputDate1"].Width = 90;

            dgvInput.Columns["NumberFer1"].HeaderText = "(قسمت اول)شماره فر";
            dgvInput.Columns["NumberFer1"].Width = 90;

            dgvInput.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه(قسمت اول)";
            dgvInput.Columns["TedadKiseFer1"].Width = 90;

            dgvInput.Columns["inputDate2"].HeaderText = "تاریخ ورود به فر(قسمت دوم)";
            dgvInput.Columns["inputDate2"].Width = 90;

            dgvInput.Columns["NumberFer2"].HeaderText = "شماره فر(قسمت دوم)";
            dgvInput.Columns["NumberFer2"].Width = 120;

            dgvInput.Columns["TedadKiseFer2"].HeaderText = "تعداد کیسه(قسمت دوم)";
            dgvInput.Columns["TedadKiseFer2"].Width = 120;
            dgvInput.Columns["CstmrID"].Visible = false;
            ////dgvInput.Columns["chk_Output"].Visible = false;
            dgvInput.Columns["ProcessID"].Visible = false;
            dgvInput.Columns["Discription"].Visible = false;
            dgvInput.Columns["InWeight"].Visible = false;
            dgvInput.Columns["chk_Process"].Visible = false;
        }
        void DisplayProcessView1()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_cstmrToOutputNew where Id=" + cstmID;
            adp.Fill(ds, "View_cstmrToOutputNew");
            dgvView.DataSource = ds;
            dgvView.DataMember = "View_cstmrToOutputNew";

            //************************************

            dgvView.Columns["ProcessID"].Visible = false;
            dgvView.Columns["OutputID"].Visible = false;
            dgvView.Columns["chk_Output"].Visible = false;
            dgvView.Columns["chk_Process"].Visible = false;
            dgvView.Columns["id"].Visible = false;
            dgvView.Columns["WightSabos2"].Visible = false;
            dgvView.Columns["Code"].HeaderText = "کد محصول";
            dgvView.Columns["InNo"].HeaderText = "نوع شالی";
            dgvView.Columns["Code"].Width = 70;

            dgvView.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
            dgvView.Columns["InTedadKise"].Width = 90;

            dgvView.Columns["TedadKiseDone"].HeaderText = "تعداد برنج";
            dgvView.Columns["TedadKiseDone"].Width = 90;

            dgvView.Columns["WeightDone"].HeaderText = "وزن برنج";
            dgvView.Columns["WeightDone"].Width = 90;

            dgvView.Columns["WeightSabos1"].HeaderText = "وزن سبوس";
            dgvView.Columns["WeightSabos1"].Width = 90;

            dgvView.Columns["weightNimdone"].HeaderText = "وزن نیم دونه";
            dgvView.Columns["weightNimdone"].Width = 90;

            dgvView.Columns["OutDate"].HeaderText = "تاریخ تبدیل";
            dgvView.Columns["OutDate"].Width = 90;

            dgvView.Columns["Anbar"].HeaderText = "شماره انبار";
            dgvView.Columns["Anbar"].Width = 50;

        }
        void Process()
        {
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_cstmrToOutputNew where id=" + cstmID+ "and OutputID="+ OutPutID;
            con.Open();
            adp.Fill(dt);
            PrccID = (int)dt.Rows[0]["ProcessID"];
            con.Close();
        }
        void GetFeeYear()
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
                NKiseKeshavarz = Convert.ToInt32(dt.Rows[0]["FeeYear"].ToString());
                NkiseTajeri = Convert.ToInt32(dt.Rows[0]["KiseTajeri"].ToString());
                NVazniKeshavarz = Convert.ToInt32(dt.Rows[0]["VaznKeshavarzi"].ToString());
                NVazniTajer = Convert.ToInt32(dt.Rows[0]["VaznTajeri"].ToString());
                NKharidSabos = Convert.ToInt32(dt.Rows[0]["SabosNarm"].ToString());
                NKeshteDo = Convert.ToInt32(dt.Rows[0]["KeshteDo"].ToString());

                VaznSabosNarm = Convert.ToDouble(dt.Rows[0]["WSabosNarm"].ToString());
                VaznSabosDo = Convert.ToDouble(dt.Rows[0]["WSabosDo"].ToString());
                VaznKise = Convert.ToDouble(dt.Rows[0]["WKDone"].ToString());
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }

        DataTable GetNoMahsol()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select BNoID from tblBNo where No=N'"+lblInNo.Text+"'";
            dt=tc.ExecuteReader();
            return dt;
        }
        DataTable Get_tblMahsol(string tblName)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from "+tblName+ " where [RefProcessID]='" + PrccID + "'";
            dt = tc.ExecuteReader();
            return dt;
        }

        /// <summary>
        ///  bedast avardan gheymat sabos narm
        /// </summary>
        /// <returns>feesabos</returns>
        private int FeeSabos()
        {
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            SqlDataAdapter adp1 = new SqlDataAdapter();
            adp1.SelectCommand = new SqlCommand();
            adp1.SelectCommand.Connection = con;
            adp1.SelectCommand.CommandText = "select * from tblFeeYear ";
            con.Open();
            adp1.Fill(dt1);
            int feesabos = (int)dt1.Rows[0]["SabosNarm"];
            con.Close();
            return feesabos;
        }
        /// <summary>
        /// bedast avardan gheymat nimdone
        /// </summary>
        /// <returns>feenimdone</returns>
        private int FeeNimdone()
        {
            //khandan no nimdone az tblNo/////////////////////////////////////////////
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblBNo  where No  Like '%' + @s + '%' ";
            adp.SelectCommand.Parameters.AddWithValue("@s", NoBerenj + "%");
            con.Open();
            adp.Fill(dt);
            int feenimdone = (int)dt.Rows[0]["FNimdone"];
            con.Close();
            return feenimdone;
        }
        private int FindProcessID()
        {
            int OutID = 0;
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbarKhorji where ProcessID=" + outid;
            con.Open();
            adp.Fill(dt);
            OutID = (int)dt.Rows[0]["OutputID"];
            con.Close();
            return OutID;
        }
        #endregion
        #region DataGrids
        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                con.Close();
                int indx = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + indx;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = dt.Rows[0]["Name"].ToString();// + " " + dt.Rows[0][2].ToString(); ;              
                txtInNameSearch.WatermarkText = dt.Rows[0]["Name"].ToString();
                txtInFamSearch.WatermarkText = dt.Rows[0]["Family"].ToString();
                con.Close();
                CstmCode = indx;
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                txtSID.WatermarkText = dt.Rows[0]["DastiID"].ToString();
                CstmCode = indx;
                cstmID = indx;

                NOMoshtari();

               // lblID.Text = indx.ToString();
                txtSID.Text = "";
                txtInNameSearch.Text = "";
                txtInFamSearch.Text = "";
                txtSID.Text = "";
                dgvInSearch.Visible = false;
                dgvInput.Visible = true;
                DisplayProcessView();
                DisplayProcessView1();
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
           
        }
        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            outid = -1;
            int vazninput = 0;

            try
            {

                con.Close();
                int indx1 = (int)dgvInput.Rows[e.RowIndex].Cells["InputID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_InputAndProcess where InputID=" + indx1;
                con.Open();
                adp.Fill(dt);
                this.lblInNo.Text = dt.Rows[0]["InNo"].ToString();
                InNo = dt.Rows[0]["InNo"].ToString();
                NoBerenj = dt.Rows[0]["InNo"].ToString();
                this.lblDate1.Text = dt.Rows[0]["INDate"].ToString();
                this.lblNum1.Text = dt.Rows[0]["NumberFer1"].ToString();
                this.lblTedad1.Text = dt.Rows[0]["TedadKiseFer1"].ToString();
                vazninput = (int)dt.Rows[0]["InWeight"];
                PrccID = (int)dt.Rows[0]["ProcessID"];
                TedadKise = double.Parse(dt.Rows[0]["InTedadKise"].ToString());
                dgvInput.Visible = false;
                txtTedadDone.Text = "";

                txtWNimdone.Text = "";
                txtWDone.Text = "";
                //Moadel saziha////////////////////////////////////////////////////////////////////////////////////////////
                vs1 = Convert.ToInt32(TedadKise * VaznSabosNarm);
                txtWYekob.Text = vs1.ToString();
                vs2 = (int)(TedadKise * VaznSabosDo);
                //if (NoMoshtari == "کشاورز")
                //{
                    if (InNo=="دوکشت")
                    {
                        karmozdkise = (int)(TedadKise * NKeshteDo);
                        karmozdvazn = (int)(vazninput * NKeshteDo);
                    }
                    else
                    {
                        karmozdkise = (int)(TedadKise * NKiseKeshavarz);
                        karmozdvazn = (int)(vazninput * NVazniKeshavarz);
                    }
                   
                //}

                //if (NoMoshtari == "تاجر")
                //{
                //    if (InNo == "دوکشت")
                //    {
                //        karmozdkise = (int)(TedadKise * NKeshteDo);
                //        karmozdvazn = (int)(vazninput * NKeshteDo);
                //    }
                //    else
                //    {
                //        karmozdkise = (int)(TedadKise * NkiseTajeri);
                //        karmozdvazn = (int)(vazninput * NVazniTajer);
                //    }
                //}
                ////////////////////////////////////////////////////////////////////////
                DisplayProcessView();
                fSabos = FeeSabos();
                fNimdone = FeeNimdone();
                DataTable dtable = GetNoMahsol();
                noDone = (int)(dtable.Rows[0][0]);
                
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            txtTedadDone.Focus();
        }
        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Close();
            try
            {
                Id = (int)dgvView.Rows[e.RowIndex].Cells["OutputID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblOutput where OutputID =" + Id;
                con.Open();
                adp.Fill(dt);
                outid = Id;
                OutPutID = Id;
                this.txtWNimdone.Text = dt.Rows[0]["weightNimdone"].ToString();
                this.txtWYekob.Text = dt.Rows[0]["WeightSabos1"].ToString();

                this.txtTedadDone.Text = dt.Rows[0]["TedadKiseDone"].ToString();
                this.txtWDone.Text = dt.Rows[0]["WeightDone"].ToString();

                this.txtDate.Text = dt.Rows[0]["OutDate"].ToString();

                this.txtAnbar.Text = dt.Rows[0]["Anbar"].ToString();
                PrccID = (int)dt.Rows[0]["ProcessID"];
                ProcessIdtblOutput = (int)dt.Rows[0]["ProcessID"];
                con.Close();
                dt_Done = Get_tblMahsol("tblAnbarMahsolMoshtariDone");
                dt_Ndone = Get_tblMahsol("tblAnbarMahsolMoshtariNDone");
                dt_SabosNarm = Get_tblMahsol("tblAnbarMahsolMoshtariSabosNarm");
                dgvInput.Visible = false;
            }
            catch (Exception)
            {

                MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید");
            }
        }
        #endregion
        #region EventArgs
        private void frmOutput_Load(object sender, EventArgs e)
        {
            txtDate.Text =( dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#")).ToString();
            dgvInput.Visible = false;
            dgvInSearch.Visible = false;
            lblKDone.Visible = false;
            lblWDone.Visible = false;
            lblWNimDone.Visible = false;
            lblWYekob.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            chkKise.Visible = false;
            chkVazn.Visible = false;
            GetFeeYear();
            if (chkKise.Checked == true)
            {
                NoKarmozd = 1;
                chkVazn.Checked = false;
            }
        }
        private void txtInNameSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            line3.Visible = false;
            line4.Visible = false;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInNameSearch.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            dgvInSearch.Visible = true;
            dgvInput.Visible = false;
            mt.Titr(dgvInSearch);
        }
        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
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
            dgvInput.Visible = false;
            mt.Titr(dgvInSearch);
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
           
            if (dgvInput.Visible==false)
            {
               
                dgvInput.Visible = true;
                DisplayProcessView();
            }
           else
            {
                dgvInput.Visible = false;
            }
           
        }
        private void txtTedadDone_TextChanged(object sender, EventArgs e)
        {
            try
            {

                txtWDone.Text = (Convert.ToInt64(txtTedadDone.Text)*VaznKise).ToString();
            }
            catch (Exception)
            {               
            }
        }
        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtWDone.Text != string.Empty)
                //{
                //    txtWDone.Text = string.Format("{0:N0}", double.Parse(txtWDone.Text.Replace(",", "")));
                    txtWDone.Select(txtWDone.TextLength, 0);
                //}
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtTedadNimdone_TextChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    if (txtTedadNimdone.Text != string.Empty)
            //    {
            //        txtTedadNimdone.Text = string.Format("{0:N0}", double.Parse(txtTedadNimdone.Text.Replace(",", "")));
            //        txtTedadNimdone.Select(txtTedadNimdone.TextLength, 0);
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            //}
        }
        private void txtWNimdone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtWNimdone.Text != string.Empty)
                //{
                //    txtWNimdone.Text = string.Format("{0:N0}", double.Parse(txtWNimdone.Text.Replace(",", "")));
                    txtWNimdone.Select(txtWNimdone.TextLength, 0);
                //}
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtTedadYekob_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtTedadYekob.Text != string.Empty)
            //    {
            //        txtTedadYekob.Text = string.Format("{0:N0}", double.Parse(txtTedadYekob.Text.Replace(",", "")));
            //        txtTedadYekob.Select(txtTedadYekob.TextLength, 0);
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            //}
        }
        private void txtWYekob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtWYekob.Text != string.Empty)
                //{
                    //txtWYekob.Text = string.Format("{0:N0}", double.Parse(txtWYekob.Text.Replace(",", "")));
                    txtWYekob.Select(txtWYekob.TextLength, 0);
                //}
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtTedadDokob_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtTedadDokob.Text != string.Empty)
            //    {
            //        txtTedadDokob.Text = string.Format("{0:N0}", double.Parse(txtTedadDokob.Text.Replace(",", "")));
            //        txtTedadDokob.Select(txtTedadDokob.TextLength, 0);
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            //}
        }
        private void txtWDokob_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            dgvInput.Visible = false;
            mt.Titr(dgvInSearch);
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            dgvInput.Visible = false;
            txtSID.Text = "";
            txtInNameSearch.Text = "";
            txtInNameSearch.Text = "";
            txtKhorde.Text = "";
        }
        private void chkFee_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void txtKhorde_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(txtKhorde.Text);
                y = Convert.ToDouble(txtTedadDone.Text);
                txtWDone.Text = (Convert.ToUInt64(x +( y * VaznKise))).ToString();
                nim = true;
                chk_nime = true;
                //txtTedadDone.Text = (Convert.ToInt32(txtTedadDone.Text) + 0.5).ToString();
            }
            catch (Exception)
            {

               
            }
         
        }
        private void chkKise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKise.Checked==true)
            {
                NoKarmozd = 1;
                chkVazn.Checked = false;
            }
        }
        private void chkVazn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVazn.Checked == true)
            {
                NoKarmozd = 2;
                chkKise.Checked = false;
            }
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            int PrccChecker = 1;
            #region check textbox
            if (nim == true)
            {
                if (txtKhorde.Text != "")
                {
                    txtTedadDone.Text = (Convert.ToInt32(txtTedadDone.Text) + 0.5).ToString();
                }

            }

            if (txtTedadDone.Text == "" || txtWDone.Text == "" || txtWNimdone.Text == "" || txtWYekob.Text == "")
            {
                MessageBox.Show(".لطفا فیلد های مشخص شده را پر کنید");
                if (txtTedadDone.Text == "")
                {
                    lblKDone.Visible = true;
                }
                if (txtWDone.Text == "")
                {
                    lblWDone.Visible = true;
                }
                if (txtWNimdone.Text == "")
                {
                    lblWNimDone.Visible = true;
                }
                if (txtWYekob.Text == "")
                {
                    lblWYekob.Visible = true;
                }
            }
            #endregion
            else
            {

                try
                {
                    //INSERT into [tblOutput]
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    string cmdText = "INSERT into [tblOutput](ProcessID,OutDate,TedadKiseDone,WeightDone,WeightSabos1,WightSabos2,weightNimdone,chk_Output,Anbar)values" +
                    "(" + PrccID + ",'" + txtDate.Text +
                    "'," + Convert.ToDouble(txtTedadDone.Text.Replace(",", "")) +
                    "," + Convert.ToInt32(txtWDone.Text.Replace(",", "")) +
                    "," + Convert.ToInt32(txtWYekob.Text.Replace(",", "")) +
                    "," + vs2 +
                    "," + Convert.ToInt32(txtWNimdone.Text.Replace(",", "")) +
                    "," + 1 + ",N'" + txtAnbar.Text + "')";

                    //Edid Process
                    /////////////////////////////////////////////////////////////////////////////////////////////////

                    cmdText += " Update View_prcss Set chk_Process='" + PrccChecker + "' where CstmrID =" + cstmID + "AND ProcessID=" + PrccID;
                    //insert tblAnbalMahsolMoshtari
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    cmdText += " INSERT into tblDaramadTabdil (ProcessID,Bes,Date,TedadShali)values(" + PrccID + "," + karmozdkise + ", '"+ txtDate.Text +"' ,"+ TedadKise + ")";
                    //Done 
                    cmdText += " INSERT into[tblAnbarMahsolMoshtariDone] (VaznBed,VaznBes,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz)values" +
                        "(" + Convert.ToDouble(txtWDone.Text.Replace(",", "")) + ",0," + cstmID + ",'" + txtDate.Text + "'," + Convert.ToDouble(txtTedadDone.Text.Replace(",", "")) +
                        ",0," + PrccID + ",2," + noDone + ",0)";

                    //Nimdone
                    cmdText += " INSERT into[tblAnbarMahsolMoshtariNDone] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                        "(" + Convert.ToDouble(txtWNimdone.Text.Replace(",", "")) + ",0," + cstmID + ",'" + txtDate.Text + "'," + PrccID + ",2," + noDone + "," + FeeNimdone() + ")";

                    //SabosNarm
                    cmdText += " INSERT into[tblAnbarMahsolMoshtariSabosNarm] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                        "(" + Convert.ToDouble(txtWYekob.Text.Replace(",", "")) + ",0," + cstmID + ",'" + txtDate.Text + "'," + PrccID + ",2,0," + NKharidSabos + ")";
                    //Sabos2
                    cmdText += " INSERT into[tblAnbarMahsolMoshtariSabosDo] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                        "(" + vs2 + ",0," + cstmID + ",'" + txtDate.Text + "'," + PrccID + ",2,0,0)";

                    cmdText += " INSERT into[tblAnbarMahsolKarkhaneSabosDo] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                        "(" + vs2 + ",0," + cstmID + ",'" + txtDate.Text + "'," + PrccID + ",2,0,0)";

                    //GhesmatMali///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //ReferType= , ReferID=OutID, ReferNo=Tabdil(tblGardeshMAhsol)
                    //Moshtari
                    cmdText += " insert into [tblHesabMoshtari]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                        "(" + karmozdkise + ",0," + cstmID + ",2," + PrccID + ",0,'" + txtDate.Text + "',0,0,0)";
                    //Karkhane
                    cmdText += " insert into [tblHesabKarkhane]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                        "(0," + karmozdkise + "," + cstmID + ",2," + PrccID + ",0,'" + txtDate.Text + "',0,0,0)";


                    if (trnsction.Execute_TRANSACTION(cmdText))
                    {
                        MessageBox.Show("ثبت با موفقیت انجام شد");
                        DisplayProcessView1();

                        txtTedadDone.Text = "";
                        txtWYekob.Text = "";
                        txtWNimdone.Text = "";
                        txtWDone.Text = "";
                        txtKhorde.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                }
                txtInNameSearch.Focus();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string cmdText = "";
            var result = MessageBox.Show("آیا مایل به ویرایش رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        cmdText = "Update tblOutput Set TedadKiseDone=N'" + txtTedadDone.Text.Replace(",", "") + "',WeightDone=N'" +
                            txtWDone.Text.Replace(",", "") + "',WeightSabos1=N'" + txtWYekob.Text.Replace(",", "") + "',weightNimdone=N'" +
                            txtWNimdone.Text.Replace(",", "") + "',Anbar=N'" + txtAnbar.Text.Replace(",", "") + "',OutDate=N'" + txtDate.Text + "'  where OutputID=" + Id;
                        //Edit tblAnbarMahsolMoshtariDone//////////////////////////////////////////////////////////////////////////////
                        cmdText += " Update tblAnbarMahsolMoshtariDone Set VaznBed=N'" + txtWDone.Text.Replace(",", "") + "'," +
                                                                        "TedadKiseBes=N'" + txtTedadDone.Text.Replace(",", "")+"'," +
                                                                        "Date=N'" + txtDate.Text + "'  where RefProcessID=" + PrccID;
                        //Edit tblAnbarMahsolMoshtariDone
                        cmdText += " Update tblAnbarMahsolMoshtariNDone Set VaznBed=N'" + txtWNimdone.Text.Replace(",", "") + "'," +
                                                                       "Date=N'" + txtDate.Text + "'  where RefProcessID=" + PrccID;
                        //Edit tblAnbarMahsolMoshtariDone
                        cmdText += " Update tblAnbarMahsolMoshtariSabosNarm Set VaznBed=N'" + txtWYekob.Text.Replace(",", "") + "'," +
                                                                       "Date=N'" + txtDate.Text + "'  where RefProcessID=" + PrccID;
                        trnsction.Execute_TRANSACTION(cmdText);
                        ///////////////////////////////////////////////////////////////////////////////////////////////////
                        MessageBox.Show("ویرایش اطلاعات انجام شد.");

                        DisplayProcessView1();
                        txtTedadDone.Text = "";
                        txtWYekob.Text = "";
                        txtWNimdone.Text = "";
                        txtWDone.Text = "";

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید"); }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cmdText = "";
            Process();
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    
                    try
                    {
                        cmdText = "delete from [tblOutput] where OutputID=" + Id;
                        //update
                        //Edid Process
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        int PrccChecker = 0;
                        cmdText += " Update [tblProcess] Set chk_Process='" + PrccChecker + "' where ProcessID=" + PrccID;
                        ////////////////////////////////////////////////////////////////////////////////////////////////

                       cmdText += " delete from [tblDaramadTabdil] where ProcessID=" + PrccID;

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        cmdText += " delete from [tblAnbarMahsolMoshtariDone] where RefProcessID=" + PrccID;
                        cmdText += " delete from [tblAnbarMahsolMoshtariNDone] where RefProcessID=" + PrccID;
                        cmdText += " delete from [tblAnbarMahsolMoshtariSabosNarm] where RefProcessID=" + PrccID;
                        cmdText += " delete from [tblAnbarMahsolMoshtariSabosDo] where RefProcessID=" + PrccID;
                        cmdText += " delete from [tblAnbarMahsolKarkhaneSabosDo] where RefProcessID=" + PrccID;
                        cmdText += " delete from [tblHesabMoshtari] where ReferID=" + PrccID + "and [MoshtariID]=" + cstmID + " and [RefNoGardesh]=2";
                        cmdText += " delete from [tblHesabKarkhane] where ReferID=" + PrccID + "and [MoshtariID]=" + cstmID + " and [RefNoGardesh]=2";
                        /////////////////////////////////////////////////////////////////////////////////////////////////


                        if (trnsction.Execute_TRANSACTION(cmdText))
                        {
                            MessageBox.Show("حذف اطلاعات انجام شد.");
                            txtTedadDone.Text = "";
                            DisplayProcessView1();
                            txtWYekob.Text = "";
                            txtWNimdone.Text = "";
                            txtWDone.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                        }

                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید"); }
            }
        }

    }
}
