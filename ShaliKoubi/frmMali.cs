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
    public partial class frmMali : Form
    {
        public int tchk { get; set; }
        public int tmhsl { get; set; }
        public int tnghd { get; set; }
        public int fee { get; set; }

        int Sayer = 0;
        int DaryaftiKarmozdMahsol = 0;
        int jamkol = 0;
        int chk = 0;
        int naghdi = 0;
        int naghd = 0;
        int hazine = 0;
        int salary = 0;
        int tkol = 0;
        int kharidmahsolat = 0;
        int tankhah = 0;
        int sandogh = 0;
        int KharidMahsolMazad = 0;
        int MablaghForoshMahsol = 0;
        Int64 daramad = 0;
        int Talab = 0;
        Int64 sodshali = 0;
        int daryaftimotefareghe = 0;
        public int GetGharz()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblHesab]";
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
            adp.SelectCommand.CommandText = "select * from [tblHesab] ";
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
        /// <summary>
        /// Repot az jadval Salary
        /// </summary>
        /// <returns></returns>
        int Salary()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSalary ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["SalaryMablagh"]);
                }

            }
            else
            {
               // MessageBox.Show("رکورد حقوق دریافتی خالی می باشد");
            }
            return majmo;
        }

     
        public frmMali()
        {
            InitializeComponent();
        }
        method mt = new method();
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        clsNewEditing ne = new clsNewEditing();
        int s = 0;
        public int Bedehkaran()
        {
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }
            }
            else
            {

            }
            con.Close();
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] HesabMoshtari = new int[6];
                HesabMoshtari = ne.HesabMoshtari(id[i]);
                int[] mali = Gozaresh.Mali(id[i]);
                s += ((mali[1] - (mali[4] + mali[2])) + ne.BedehkariZiroZiro(id[i], 1));
            }
            return s;
        }
        public int BedSalePish()
        {
            int bed = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblBedehkaranSalGozashte";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bed += Convert.ToInt32(dt.Rows[i]["Pardakhti"]);
                }
            }
            else
            {

            }
            return bed;
        }
        public int BedSalePishMahsoli()
        {
            int bed = 0;
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp1.SelectCommand = new SqlCommand();
            adp1.SelectCommand.Connection = con;
            adp1.SelectCommand.CommandText = "select * from tblMahsolBedSalePish";
            adp1.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    bed += Convert.ToInt32(dt1.Rows[i]["MablaghMahsol"]);
                }
            }
            else
            {

            }
            return bed;
        }
        public int DaryaftiMotefareghe()
        {
            int bed = 0;
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp1.SelectCommand = new SqlCommand();
            adp1.SelectCommand.Connection = con;
            adp1.SelectCommand.CommandText = "select * from tblDaryaftiMotefareghe";
            adp1.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    bed += Convert.ToInt32(dt1.Rows[i]["DMMablagh"]);
                }
            }
            else
            {

            }
            return bed;
        }
        public int BesSalePish()
        {
            int bes = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblBestanKareSaleGhbal";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bes += Convert.ToInt32(dt.Rows[i]["MablaghBes"]);
                }
            }
            else
            {

            }
            return bes;
        }
        private void frmMali_Load(object sender, EventArgs e)
        {
            #region
            lblNaghd.Text = naghd.ToString("N0");
            ////////////////////////////////////////////
            //DaryaftiMotefareghe
            daryaftimotefareghe = DaryaftiMotefareghe();
            //ForoshNimDone
            int[] NimDone = { 0,0 };          
            NimDone = mt.NimDone();
            lblNDM.Text = NimDone[1].ToString("N0");
            lblNW.Text = NimDone[0].ToString("N0");
            MablaghForoshMahsol += NimDone[1];

            //ForoshDone
            int[] Done = { 0, 0 }; Done= mt.Done();
            lblDM.Text = Done[1].ToString("N0");
            lblDW.Text = Done[0].ToString("N0");
            MablaghForoshMahsol += Done[1];

            //ForoshSabos1kob
            int[] Saboos1 = { 0, 0 }; Saboos1= mt.SabosNarm();
            lblS1W.Text = Saboos1[1].ToString("N0");
            lblS1M.Text = Saboos1[0].ToString("N0");
            MablaghForoshMahsol += Saboos1[1];

            //ForoshSabos2Kob
            int[] Saboos2 = { 0, 0 }; Saboos2 = mt.Sabos2();
            lblS2W.Text = Saboos2[0].ToString("N0");
            lblS2M.Text = Saboos2[1].ToString("N0");
            MablaghForoshMahsol += Saboos2[1];
            //ForoshSayer

            Sayer = mt.Sayer();
            lblSayer.Text = Sayer.ToString("N0");
            //karmozd += Sayer;
            lblForoshKarmozd.Text = MablaghForoshMahsol.ToString("N0");
            lblFSayer.Text = Sayer.ToString("N0");
            //Kharid Done,Nimdone,Sabos/////////////////////////////////////////////////////

            int[] KharidDone = { 0, 0 }; KharidDone=mt.KharidDone();
            KharidMahsolMazad += KharidDone[1];

            int[] KhariNimDone = { 0, 0 }; KhariNimDone=mt.KharidNimDone();
            KharidMahsolMazad += KhariNimDone[1];

            int[] KharidSaboos1 = { 0, 0 }; KharidSaboos1= mt.KharidSabosNarm();
            KharidMahsolMazad += KharidSaboos1[1];

            #endregion
            ////////////////////////////////////////////////////////////////////////////////
            DaryaftiKarmozdMahsol = mt.KarmozdMahsol();//jam karmozd daryafti az mahsolat
            lblDaryaftiKarmozd.Text = DaryaftiKarmozdMahsol.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Sod Az Karmozd
            int sod = 0;
            sod = MablaghForoshMahsol - (mt.KarmozdMahsol() + KharidMahsolMazad);//Sod hasel az forosh mahsol karmozd// +);
            lblKarmozdSod.Text = sod.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //JamKol/           
            jamkol = mt.reportMahsol();//jam kole karmozd daryaft shode
            //------------------------------------------------------------------------------------------------------------------------
            //Cheki
            chk=mt.Chck();
            lblCheki.Text = chk.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Naghdi Cart         
            naghdi= mt.Naghd();
            lblNaghdi.Text = naghdi.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Hazine            
            hazine= mt.Hazine();         
            lblHazine.Text = hazine.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Hoghogh(Salary)            
            salary = Salary();
            lblHoghogh.Text= salary.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Takhfif 
            tkol = mt.Takhfif(); ;
            lblTakhfif.Text = tkol.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------
            //Kharid Mahsolat
            kharidmahsolat = mt.Kharid();
            lblKharidMahsol.Text = kharidmahsolat.ToString("N0");
            //Tankhah gardan
            tankhah = mt.Tankhah();
            lblTankhah.Text = tankhah.ToString("N0");
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            //Bed Sale pish naghd
            int bedsalepishnaghd = 0;
            bedsalepishnaghd = BedSalePish();
            //------------------------------------------------------------------------------------------------------------------------
            int bessalepish = BesSalePish();
            //Mojodi naghdo Bank
            sandogh = ((MablaghForoshMahsol + Sayer + chk + naghdi + naghd + /*bedsalepishnaghd +*/ daryaftimotefareghe) - (kharidmahsolat + salary + hazine + tankhah + bessalepish));
            lblNaghdoBank.Text = sandogh.ToString("N0");
            //------------------------------------------------------------------------------------------------------------------------

            //Bedehkaran
            double tedadkise = mt.Kise();
            int bayadDad = 0;
            bayadDad= new method().Bedehkaran();

            int dade = 0;
            dade =(jamkol + chk );

            
            
            Talab = Bedehkaran();
            //Talab = bayadDad;
            lblTalab.Text = Talab.ToString("N0"); ;
            //
            //Daryafti motafareghe
            //
            int daryaftiMotefareghe= 0;
            daryaftiMotefareghe = mt.DaryaftiMotefareghe();
            //Shali--------------------------------------------------------------------------------
            //
            //Daramad
            //
            Int64 daryaftgharz = GetGharzDaryaft();
            Int64 pardakhtgharz = GetGharz();
            daramad = ((MablaghForoshMahsol + Sayer + chk + naghdi + naghd + DaryaftiKarmozdMahsol + bedsalepishnaghd + BedSalePishMahsoli() + daryaftimotefareghe +(int) sodshali + daryaftgharz) - (kharidmahsolat + salary + hazine + tankhah + bessalepish+ pardakhtgharz));
            lblDaramad.Text = daramad.ToString("N0");

            //Dayafti
            int daryafti = 0;
            daryafti = (chk + naghdi + naghd + DaryaftiKarmozdMahsol);
            lblDaryafti.Text = (daryafti).ToString("N0");

            //Tedad Kise
            lblKise.Text = tedadkise.ToString("N1");
            

            ////Update Jadval ReportAkhar
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Reportakhar Set DaryaftiKarmozd='" + DaryaftiKarmozdMahsol +
                    "',FroshMahsolat='" + kharidmahsolat + 
                    "',Sod='" + sod + 
                    "',Hazine='" + hazine +
                    "',DaryaftCheck='" + chk +
                    "',DaryaftNaghd='" + naghd + 
                    "',FroshSayer='" + Sayer + 
                    "',Takhfif='" + tkol + 
                    "',Daramad='" + daramad + 
                    "',Talab='" + Talab +
                    "',Daryaftiazkeshavarz='" + daryafti +
                    "',PardakhtiHoghogh='" + salary +
                    "',FNDone='" + NimDone[1] +
                    "',WNdone='" + NimDone[0] + 
                    "',FS1='" + Saboos1[1] + 
                    "',WS1='" + Saboos1[0] +
                    "',FS2='" + Saboos2[1] + 
                    "',WS2='" + Saboos2[0] +
                    "',FDone='" + Done[1] + 
                    "',WDone='" + Done[0] + 
                    "',TedadKise='" + tedadkise +
                    "',Tankhah='" + tankhah +
                    "',KharidMahsol='" + kharidmahsolat +
                    "',Mojodi='" + sandogh +
                    "',Card='" + naghdi +
                    "'where RepitrID =1";// +1;
                //cmd.CommandText = "Update ReportAkhar Set TedadKise=N'" + tedadkise + "'where RepitrID ="+ 1;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
               // MessageBox.Show("ویرایش اطلاعات انجام شد.");
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            
        }
    }
}
