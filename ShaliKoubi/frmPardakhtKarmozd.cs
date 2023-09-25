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
    public partial class frmPardakhtKarmozd : Form
    {
        public frmPardakhtKarmozd()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        clsNewEditing ne = new clsNewEditing();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        int CstmCode = -1;
        int no = 0;
        int id = -1;
        double TedadShali = 0;
        string NoShali = "";
        string InDate = "";
        int ProcessID = -1;
        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_New_customerToHesab where Id=" + CstmCode;
            adp.Fill(ds, "View_New_customerToHesab");
            dgvAnbar.DataSource = ds;

            dgvAnbar.DataMember = "View_New_customerToHesab";

            //************************************

            dgvAnbar.Columns["ProcessID"].Visible = false;
            dgvAnbar.Columns["OutputID"].Visible = false;
            dgvAnbar.Columns["CstmrID"].Visible = false;
            dgvAnbar.Columns["Name"].Visible = false;
            dgvAnbar.Columns["Family"].Visible = false;
            dgvAnbar.Columns["MoshtariID"].Visible = false;
            dgvAnbar.Columns["id"].Visible = false;
            dgvAnbar.Columns["InTedadKise"].HeaderText = "تعداد شالی";
            dgvAnbar.Columns["InTedadKise"].Width = 50;
            dgvAnbar.Columns["InNo"].HeaderText = "نوع شالی";
            dgvAnbar.Columns["InDate"].HeaderText = "تاریخ ورود";

            dgvAnbar.Columns["Code"].HeaderText = "کد محصول";
            dgvAnbar.Columns["Code"].Width = 60;

            dgvAnbar.Columns["TedadKiseDone"].HeaderText = "تعداد برنج";
            dgvAnbar.Columns["TedadKiseDone"].Width = 50;

            dgvAnbar.Columns["WeightDone"].HeaderText = "وزن برنج";
            dgvAnbar.Columns["WeightDone"].Width = 70;
            dgvAnbar.Columns["WeightDone"].Visible = false;
            dgvAnbar.Columns["Done"].HeaderText = "وزن برنج";
            dgvAnbar.Columns["Done"].Width = 70;

            dgvAnbar.Columns["WeightSabos1"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["WeightSabos1"].Width = 70;
            dgvAnbar.Columns["WeightSabos1"].Visible = false;
            dgvAnbar.Columns["Sabos"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["Sabos"].Width = 70;


            dgvAnbar.Columns["weightNimdone"].HeaderText = "وزن نیم دانه";
            dgvAnbar.Columns["weightNimdone"].Width = 70;
            dgvAnbar.Columns["weightNimdone"].Visible = false;
            dgvAnbar.Columns["Nimdone"].HeaderText = "وزن نیم دانه";
            dgvAnbar.Columns["Nimdone"].Width = 70;

            dgvAnbar.Columns["OutDate"].HeaderText = "تاریخ تبدیل";
            dgvAnbar.Columns["OutDate"].Width = 90;

            dgvAnbar.Columns["Anbar"].HeaderText = "شماره انبار";
            dgvAnbar.Columns["Anbar"].Width = 50;

            dgvAnbar.Columns["bed"].HeaderText = "بدهی";
            dgvAnbar.Columns["bed"].Width = 200;

            dgvAnbar.Columns["InWeight"].HeaderText = "وزن شالی";
            dgvAnbar.Columns["InWeight"].Width = 50;

        }
        public void AddButton()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "تسویه حساب";
            btn.Name = "btnTasvie";
            btn.Text = "تسویه";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 50;
            dgvAnbar.Columns.Add(btn);
        }
        int GetPardakhti(int outcode)
        {
            int pardakhti = 0;
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_CstmrToPardakht where OutputID=" + outcode;
            con.Open();
            adp.Fill(dt);
            pardakhti = (int)dt.Rows[0]["Pardakhti"];
            con.Close();
            return pardakhti;
        }
        /// <summary>
        /// Daryaft moshakhasat shali vorodi
        /// </summary>
        void Shali(int outcode)
        {
            con.Close();
            cmd.Parameters.Clear();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_CstmrToKhorojAnbar where OutputID=" + outcode;
            con.Open();
            adp.Fill(dt);
            TedadShali =(double) dt.Rows[0]["InTedadKise"];
            NoShali = dt.Rows[0]["InNo"].ToString();
            InDate = dt.Rows[0]["InDate"].ToString();
            con.Close();
        }
      
        private void LoadfrmPardakht(int outid)
        {
            frmKarmozd krmzd = new frmKarmozd();

            krmzd.ProcessID = ProcessID;
            krmzd.Name= lblName.Text;

            if (krmzd.ShowDialog()== DialogResult.OK)
            {
                
                Display();

            }  
        }
        //gharz--------------------------------------------------
        public int GetGharz()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblHesab] where MoshtariID=" + CstmCode;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int mablagh = 0;
            if (cunt > 0)
            {

                for (int i = 0; i <= cunt - 1; i++)
                {

                    mablagh += Convert.ToInt32(dt.Rows[i]["Bed"]);

                }
            }
            return mablagh;
        }
        public int GetGharzDaryaft()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblHesab] where MoshtariID=" + CstmCode;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int mablagh = 0;
            if (cunt > 0)
            {

                for (int i = 0; i <= cunt - 1; i++)
                {

                    mablagh += Convert.ToInt32(dt.Rows[i]["Bes"]);

                }
            }
            return mablagh;
        }
        public int[] HesabMoshtari(int cstmrID)
        {
            int[] report = new int[7];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblPardakht] where CstmrID=" + cstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int Pardakhti = 0;
            int Bestankar = 0;
            int Naghd = 0;
            int Mahsol = 0;
            int Takhfif = 0;
            if (cunt > 0)
            {

                for (int i = 0; i <= cunt - 1; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["Pardakhti"]) == 0 && Convert.ToInt32(dt.Rows[i]["Bestankar"]) == 0)
                    {

                    }
                    Pardakhti += Convert.ToInt32(dt.Rows[i]["Pardakhti"]);
                    Bestankar += Convert.ToInt32(dt.Rows[i]["Bestankar"]);
                    Naghd += (Convert.ToInt32(dt.Rows[i]["Nagh"]) + Convert.ToInt32(dt.Rows[i]["Card"]));
                    Mahsol += ((Convert.ToInt32(dt.Rows[i]["VazneSabos"]) * (Convert.ToInt32(dt.Rows[i]["NerkhSabos"]))) + (Convert.ToInt32(dt.Rows[i]["VazneNimdone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhNimdone"]))) + (Convert.ToInt32(dt.Rows[i]["VazneDone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhDone"]))));
                    Takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            //////////////////////////////////////////////////////////////////////////////
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp1.SelectCommand = new SqlCommand();
            adp1.SelectCommand.Connection = con;
            adp1.SelectCommand.CommandText = "select * from [PayCheck] where CstumID=" + cstmrID;
            adp1.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int mablagh = 0;
            int tkhff = 0;
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    mablagh += Convert.ToInt32(dt1.Rows[i]["Mablagh"]);
                    tkhff += Convert.ToInt32(dt1.Rows[i]["Takhfif"]);
                }
            }
            else
            {

            }

            Pardakhti += mablagh;
            Takhfif += tkhff;
            report[0] = Pardakhti;
            report[1] = Takhfif;
            report[2] = Bestankar;
            report[3] = Naghd;
            report[4] = Mahsol;
            report[5] = mablagh;
            report[6] = GetGharz();
            return report;
        }
        double GetBedehkari(int CstmrID)
        {
            double bed = 0;
            tc.CommandText = "select (sum(bed)-sum(bes)) as bed from tblHesabMoshtari where MoshtariID=" + CstmrID;
            bed = Convert.ToUInt64(tc.ScalerExecute());
            return bed;
        }
        //-------------------
        private void frmPardakhtKarmozd_Load(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = false;
            txtInNameSearch.Focus();

            
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
            mt.Titr(dgvInSearch);
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
            mt.Titr(dgvInSearch);

        }
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
                id = indx;
               // lblID.Text = indx.ToString();
                txtSID.Text = "";
                txtInNameSearch.Text = "";
                txtInFamSearch.Text = "";
                txtSID.Text = "";
                dgvInSearch.Visible = false;
                lblTedad.Text = (ne.KiseMoshtari(CstmCode)).ToString();
                //int[] riportmoshtari = ne.ReportPardakhtMoshtari(CstmCode);
                //lblNTakhfif.Text = riportmoshtari[5].ToString("N0");
                //lblNaghdi.Text = riportmoshtari[4].ToString("N0");
                //lblcheck.Text = riportmoshtari[3].ToString("N0");
                //lblMahsol.Text = riportmoshtari[2].ToString("N0");
                //lblBedehkar.Text = riportmoshtari[1].ToString("N0");
                //lblkolemablagh.Text = riportmoshtari[0].ToString("N0");
                Display();
                //if (dgvAnbar.Columns.Count <= 22)
                //{
                    AddButton();                    
                //}
                
                int[] Hesab = new int[7];
                //Hesab = HesabMoshtari(CstmCode);
               // lblBedehkar.Text = ((((/*ne.KarmozdKise(CstmCode) + */ne.BedehkariZiroZiro(CstmCode, 1)) - Hesab[0]) + GetGharz() - GetGharzDaryaft())).ToString("N0");
                lblBedehkar.Text = ((int)GetBedehkari(CstmCode)).ToString("N0");
            }
            catch (Exception)
            {
            }
        }
        private void dgvAnbar_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dgvAnbar.Rows[e.RowIndex].Selected = true;
                if (dgvAnbar.Columns[e.ColumnIndex].Name == "btnTasvie")
                {
                    int outId = (int)dgvAnbar.Rows[e.RowIndex].Cells["OutputID"].Value;
                    ProcessID = (int)dgvAnbar.Rows[e.RowIndex].Cells["ProcessID"].Value;
                    LoadfrmPardakht(ProcessID);
                }
            }
            catch (Exception)
            {
            }
        }
        private void btbRefresh_Click(object sender, EventArgs e)
        {
            Display();

        }
        private void buttonX10_Click(object sender, EventArgs e)
        {
           
        }
        private void dgvAnbar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvAnbar.Columns["Bed"].Index && e.RowIndex != this.dgvAnbar.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
    
        }

    }
}
