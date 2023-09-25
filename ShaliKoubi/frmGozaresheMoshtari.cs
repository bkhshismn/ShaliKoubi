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
using Stimulsoft.Report;

namespace ShaliKoubi
{
    public partial class frmGozaresheMoshtari : Form
    {
        public frmGozaresheMoshtari()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int CstmrID = -1;
        double GetBedehkari(int CstmrID)
        {
            double bed = 0;
            try
            {
                tc.CommandText = "select (sum(bed)-sum(bes)) as bed from tblHesabMoshtari where MoshtariID=" + CstmrID;
                bed = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
           
           
            return bed;
        }
        double GetKiseShali(int CstmrID)
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([InTedadKise]) from [tblInput] where [CstmrID]=" + CstmrID;
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {

            }
            
            return sum;
        }
        double GetKarmozd(int CstmrID)
        {
            double sum = 0;
            try
            {
                
                tc.CommandText = "select sum([Bed]) from [tblHesabMoshtari] where [MoshtariID]=" + CstmrID + "and [RefNoGardesh] =2";
                sum = Convert.ToDouble(tc.ScalerExecute());
               
            }
            catch (Exception)
            {


            }
            return sum;
        }
        double GetKarmozdPardakhtshode(int CstmrID)
        {
            double sum = 0;
            double sum1 = 0;
            try
            {  
                tc.CommandText = "select sum([Bes]) from [tblHesabMoshtari] where [MoshtariID]=" + CstmrID + "and [RefNoGardesh] =22";
                sum = Convert.ToDouble(tc.ScalerExecute());
                tc.CommandText = "select sum([Bed]) from [tblHesabMoshtari] where [MoshtariID]=" + CstmrID + "and [RefNoGardesh] =222";
                sum1 = Convert.ToDouble(tc.ScalerExecute());
                
            }
            catch (Exception)
            {
            }
            return sum - sum1;
        }
        void DisplayInput()
        {
            try
            {
                DataTable dt = new DataTable();
                tc.CommandText = "select * from tblInput where CstmrID=" + CstmrID;
                dt = tc.ExecuteReader();
                //************************************
                dgvInput.DataSource = dt;

                dgvInput.Columns["InputID"].HeaderText = "کد محصول";
                dgvInput.Columns["InputID"].Visible = false;
                dgvInput.Columns["Code"].HeaderText = "کد محصول";
                dgvInput.Columns["Code"].Width = 60;
                dgvInput.Columns["CstmrID"].Visible = false;
                dgvInput.Columns["InNo"].HeaderText = "نوع شالی";
                dgvInput.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
                dgvInput.Columns["InTedadKise"].Width = 120;
                dgvInput.Columns["InWeight"].HeaderText = "وزن";
                dgvInput.Columns["InWeight"].Width = 100;
                dgvInput.Columns["InWeight"].Visible = false;
                dgvInput.Columns["InPic"].Visible = false;
                dgvInput.Columns["InDate"].HeaderText = " تاریخ ورود";
                dgvInput.Columns["InDate"].Width = 120;
                dgvInput.Columns["Discription"].HeaderText = " توضیحات";
                dgvInput.Columns["Discription"].Width = 200;
                dgvInput.Columns["chk"].Visible = false;
                dgvInput.Columns["PrccChecker"].Visible = false;

            }
            catch (Exception)
            {
                MessageBox.Show("خظایی در نمایش ورود شالی رخ داده است");

            }

        }
        void DisplayFer()
        {
            try
            {
                DataTable dt = new DataTable();
                tc.CommandText = "select * from View_InputAndProcess where CstmrID=" + CstmrID;
                dt = tc.ExecuteReader();
                //************************************
                dgvFer.DataSource = dt;

                dgvFer.Columns["InputID"].Visible = false;
                dgvFer.Columns["Code"].HeaderText = "کد محصول";
                dgvFer.Columns["Code"].Width = 70;

                dgvFer.Columns["Name"].HeaderText = "نام مشتری ";
                dgvFer.Columns["Name"].Width = 90;
                dgvFer.Columns["Name"].Visible = false;
                dgvFer.Columns["Family"].HeaderText = "کد ملی";
                dgvFer.Columns["Family"].Visible = false;
                dgvFer.Columns["CstmrID"].HeaderText = "کد مشتری";
                dgvFer.Columns["CstmrID"].Width = 90;
                dgvFer.Columns["CstmrID"].Visible = false;
                dgvFer.Columns["InNo"].HeaderText = "نوع شالی";
                dgvFer.Columns["InNo"].Width = 90;

                dgvFer.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
                dgvFer.Columns["InTedadKise"].Width = 50;

                dgvFer.Columns["InDate"].HeaderText = "تاریخ ورود به کارخانه";
                dgvFer.Columns["InDate"].Width = 90;

                dgvFer.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر(قسمت اول)";
                dgvFer.Columns["inputDate1"].Width = 120;

                dgvFer.Columns["NumberFer1"].HeaderText = "(قسمت اول)شماره فر";
                dgvFer.Columns["NumberFer1"].Width = 120;

                dgvFer.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه(قسمت اول)";
                dgvFer.Columns["TedadKiseFer1"].Width = 120;

                dgvFer.Columns["inputDate2"].HeaderText = "تاریخ ورود به فر(قسمت دوم)";
                dgvFer.Columns["inputDate1"].Width = 120;

                dgvFer.Columns["NumberFer2"].HeaderText = "شماره فر(قسمت دوم)";
                dgvFer.Columns["NumberFer2"].Width = 120;

                dgvFer.Columns["TedadKiseFer2"].HeaderText = "تعداد کیسه(قسمت دوم)";
                dgvFer.Columns["TedadKiseFer2"].Width = 120;
                dgvFer.Columns["Discription"].HeaderText = "توضیحات";
                dgvFer.Columns["chk_Process"].Visible = false;
                dgvFer.Columns["ProcessID"].Visible = false;
                dgvFer.Columns["InputID"].Visible = false;
                dgvFer.Columns["InWeight"].Visible = false;

            }
            catch (Exception)
            {
                MessageBox.Show("خظایی در نمایش فر(خشکن) رخ داده است");
            }
           
            //dgvInput.Columns[5].Visible = false;
        }
        void DisplayTabdil()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_cstmrToOutputNew where Id=" + CstmrID;
                adp.Fill(ds, "View_cstmrToOutputNew");
                dgvTabdil.DataSource = ds;
                dgvTabdil.DataMember = "View_cstmrToOutputNew";

                //************************************

                dgvTabdil.Columns["ProcessID"].Visible = false;
                dgvTabdil.Columns["OutputID"].Visible = false;
                dgvTabdil.Columns["chk_Output"].Visible = false;
                dgvTabdil.Columns["chk_Process"].Visible = false;
                dgvTabdil.Columns["id"].Visible = false;
                dgvTabdil.Columns["WightSabos2"].Visible = false;
                dgvTabdil.Columns["Code"].HeaderText = "کد محصول";
                dgvTabdil.Columns["InNo"].HeaderText = "نوع شالی";
                dgvTabdil.Columns["Code"].Width = 70;

                dgvTabdil.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
                dgvTabdil.Columns["InTedadKise"].Width = 90;

                dgvTabdil.Columns["TedadKiseDone"].HeaderText = "تعداد برنج";
                dgvTabdil.Columns["TedadKiseDone"].Width = 90;

                dgvTabdil.Columns["WeightDone"].HeaderText = "وزن برنج";
                dgvTabdil.Columns["WeightDone"].Width = 90;

                dgvTabdil.Columns["WeightSabos1"].HeaderText = "وزن سبوس";
                dgvTabdil.Columns["WeightSabos1"].Width = 90;

                dgvTabdil.Columns["weightNimdone"].HeaderText = "وزن نیم دونه";
                dgvTabdil.Columns["weightNimdone"].Width = 90;

                dgvTabdil.Columns["OutDate"].HeaderText = "تاریخ تبدیل";
                dgvTabdil.Columns["OutDate"].Width = 90;

                dgvTabdil.Columns["Anbar"].HeaderText = "شماره انبار";
                dgvTabdil.Columns["Anbar"].Width = 50;
            }
            catch (Exception)
            {
                MessageBox.Show("خظایی در نمایش  تبدیل رخ داده است");
            }
           

        }
        void GetKhorojDone()
        {
            try
            {
                DataTable dt = new DataTable();
                tc.CommandText = "select [VaznBes],[Date],b.GrdeshNo, c.InNo,c.InTedadKise,c.InDate from tblAnbarMahsolMoshtariDone as a " +
                    "inner join [tblNoGaredeshMahsol] as b on a.RefNoGardesh=b.GardeshID " +
                    "inner join View_InputAndProcess as c on a.RefProcessID = c.ProcessID where a.VaznBes >0 and  [MoshtariID]=" + CstmrID;
                dt = tc.ExecuteReader();
                dgvDone.DataSource = dt;

                dgvDone.Columns["VaznBes"].HeaderText = "وزن";
                dgvDone.Columns["Date"].HeaderText = "تاریخ خروج";
                dgvDone.Columns["GrdeshNo"].HeaderText = "نوع خروج";
                dgvDone.Columns["InNo"].HeaderText = "نوع شالی";
                dgvDone.Columns["InTedadKise"].HeaderText = "تعداد شالی";
                dgvDone.Columns["InDate"].HeaderText = "تاریخ ورود";
            }
            catch (Exception)
            {

                MessageBox.Show("خظایی در نمایش  خروج برنج رخ داده است");
            }
            
        }
        void GetKhorojNimDone()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select [VaznBes],[Date],b.GrdeshNo, c.InNo,c.InTedadKise,c.InDate from tblAnbarMahsolMoshtariNDone as a " +
                "inner join [tblNoGaredeshMahsol] as b on a.RefNoGardesh=b.GardeshID " +
                "inner join View_InputAndProcess as c on a.RefProcessID = c.ProcessID where a.VaznBes >0 and  [MoshtariID]=" + CstmrID;
            dt = tc.ExecuteReader();
            dgvNimdone.DataSource = dt;

            dgvNimdone.Columns["VaznBes"].HeaderText = "وزن";
            dgvNimdone.Columns["Date"].HeaderText = "تاریخ خروج";
            dgvNimdone.Columns["GrdeshNo"].HeaderText = "نوع خروج";
            dgvNimdone.Columns["InNo"].HeaderText = "نوع شالی";
            dgvNimdone.Columns["InTedadKise"].HeaderText = "تعداد شالی";
            dgvNimdone.Columns["InDate"].HeaderText = "تاریخ ورود";

        }
        void GetKhorojSabos()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select [VaznBes],[Date],b.GrdeshNo, c.InNo,c.InTedadKise,c.InDate from tblAnbarMahsolMoshtariSabosNarm as a " +
                "inner join [tblNoGaredeshMahsol] as b on a.RefNoGardesh=b.GardeshID " +
                "inner join View_InputAndProcess as c on a.RefProcessID = c.ProcessID where a.VaznBes >0 and  [MoshtariID]=" + CstmrID;
            dt = tc.ExecuteReader();
            dgvSabos.DataSource = dt;

            dgvSabos.Columns["VaznBes"].HeaderText = "وزن";
            dgvSabos.Columns["Date"].HeaderText = "تاریخ خروج";
            dgvSabos.Columns["GrdeshNo"].HeaderText = "نوع خروج";
            dgvSabos.Columns["InNo"].HeaderText = "نوع شالی";
            dgvSabos.Columns["InTedadKise"].HeaderText = "تعداد شالی";
            dgvSabos.Columns["InDate"].HeaderText = "تاریخ ورود";

        }
        void SetForm()
        {

            lblBedehkar.Text= GetBedehkari(CstmrID).ToString("N0");
            lblTedad.Text = GetKiseShali(CstmrID).ToString("N0");
            lblKarmozdKise.Text = GetKarmozd(CstmrID).ToString("N0");
            lblPadakhShode.Text = GetKarmozdPardakhtshode(CstmrID).ToString("N0");
            DisplayInput();
            DisplayFer();
            DisplayTabdil();
            GetKhorojDone();
            GetKhorojNimDone();
            GetKhorojSabos();
        }
     
        private void frmGozaresheMoshtari_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            mt.DisplayCombo(cmbBerenjNo);
            txtFerDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtFerDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
        }
        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvInSearch.Visible = true;
                dgvInSearch.Visible = true;
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", txtSName.Text + "%");
                adp.Fill(ds, "tblCstmr");
                dgvInSearch.DataSource = ds;
                dgvInSearch.DataMember = "tblCstmr";
                mt.Titr(dgvInSearch);
            }
            catch (Exception)
            {

            }
            
        }
        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvInSearch.Visible = true;
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
            catch (Exception)
            {
            }
            
        }
        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            try
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
                mt.Titr(dgvInSearch);
            }
            catch (Exception)
            {
            }
          
        }
        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CstmrID = (int)dgvInSearch.Rows[e.RowIndex].Cells["id"].Value;
                con.Close();
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + CstmrID;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = dt.Rows[0]["Name"].ToString();// + " " + dt.Rows[0][2].ToString(); ; 
                con.Close();
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                txtSName.Text = "";
                txtSID.Text = "";
                txtInFamSearch.Text = "";
                tbExit.Enabled = true;
                dgvInSearch.Visible = false;
                SetForm();
            }
            catch (Exception)
            {

            }
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_CstmrOutputReport  where InDate between '" + txtFerDate1.Text + "' and '" + txtFerDate2.Text + "' and id=" + CstmrID + " and InNo  Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", cmbBerenjNo.Text + "%");
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int nimdone = 0;
            double tdone = 0;
            int vdone = 0;
            double shali = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WeightSabos1"]);
                    nimdone += Convert.ToInt32(dt.Rows[i]["weightNimdone"]);
                    vdone += Convert.ToInt32(dt.Rows[i]["TedadKiseDone"]);
                    tdone += Convert.ToInt32(dt.Rows[i]["WeightDone"]);
                    shali += Convert.ToInt32(dt.Rows[i]["InTedadKise"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            lbltBereng.Text = vdone.ToString("N0");
            lblVberenj.Text = tdone.ToString("N0");
            lblVNimdone.Text = nimdone.ToString("N0");
            lblVSabos.Text = sabos1.ToString("N0");
            lblShali.Text = shali.ToString("N0");
        }
        private void btnInputReport_Click(object sender, EventArgs e)
        {
            StiReport st = new StiReport();
            st["@ID"] = CstmrID;
            st.Load(Application.StartupPath + "/Report/rptInput.mrt");
            st.Show();
        }

        private void btnFerReport_Click(object sender, EventArgs e)
        {
            StiReport st = new StiReport();
            st["@ID"] = CstmrID;
            st.Load(Application.StartupPath + "/Report/rptFer.mrt");
            st.Show();
        }

        private void btnOutPrint_Click(object sender, EventArgs e)
        {
            StiReport st = new StiReport();
            st["@ID"] = CstmrID;
            st.Load(Application.StartupPath + "/Report/rptOutput.mrt");
            st.Show();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (tbDone.IsSelected==true)
            {
                StiReport st = new StiReport();
                st["@ID"] = CstmrID;
                st.Load(Application.StartupPath + "/Report/rptOutDone.mrt");
                st.Show();
            }
            else if (tbNimdone.IsSelected == true)
            {
                StiReport st = new StiReport();
                st["@ID"] = CstmrID;
                st.Load(Application.StartupPath + "/Report/rptOutNimdone.mrt");
                st.Show();
            }
            else if (tbSabos.IsSelected == true)
            {
                StiReport st = new StiReport();
                st["@ID"] = CstmrID;
                st.Load(Application.StartupPath + "/Report/rptOutSabos.mrt");
                st.Show();
            }
        }
    }
}
