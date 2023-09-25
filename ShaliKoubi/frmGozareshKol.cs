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
    public partial class frmGozareshKol : Form
    {
        public frmGozareshKol()
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
        double TedadShali = 0;
        //-------------------------------------------------
        double Daramad = 0;
        double Sood = 0;
        double DaryaftAzKeshavarz = 0;
        double TalabKeshavarz = 0;
        double Mojodi = 0;
        double HesabKarkhaneBed = 0;
        double HesabKarkhaneBes = 0;
        //-------------------------------------------------
        double FororshMahsol = 0;
        double FororshSayer = 0;
        double SodMahsol = 0;
        double DayaftKarmozdmahsol = 0;
        //-------------------------------------------------
        double Tankha = 0;
        double KharidMahsol = 0;
        double Hazine = 0;
        double Hoghogh = 0;
        //-------------------------------------------------
        double DaryaftCart = 0;
        double DaryaftNaghd = 0;
        double Takhfif = 0;
        //-------------------------------------------------
        double ForoshDone = 0;
        double ForoshNimdone = 0;
        double ForoshShali = 0;
        double ForoshSabosNarm = 0;
        double ForoshSabosDo = 0;
         //-------------------------------------------------
        double VaznDone = 0;
        double VaznNimdone = 0;
        double VaznShali = 0;
        double VaznSabosNarm = 0;
        double VaznSabosDo = 0;
        //================================================================================
        double GetKarmozd()
        {
            double sum = 0;
            try
            {
               
                tc.CommandText = "select sum([Bed]) from [tblHesabMoshtari] where  [RefNoGardesh] =2";
                sum = Convert.ToDouble(tc.ScalerExecute());
               
            }
            catch (Exception)
            {

            }
            return sum;
        }
        string GetFororshMahsol()
        {
            string sum ="0";
            tc.CommandText = "select sum(bes) as Bes from tblHesabKarkhane where RefNoGardesh=333 or RefNoGardesh=444 or RefNoGardesh=555 or RefNoGardesh=666 or RefNoGardesh=777";
            sum = tc.ScalerExecute();
            if (sum =="")
            {
                return "0";
            }
            else
            {
                return sum;
            }
            
        }
        string GetKharidMahsol()
        {
            string sum = "0";
            string sum1 = "0";
            double x = 0;
            try
            {
                tc.CommandText = "select sum(bed) as Bed from tblHesabKarkhane where  RefNoGardesh=33 or RefNoGardesh=44 or RefNoGardesh=55 or RefNoGardesh=66 or RefNoGardesh=77";
                sum = tc.ScalerExecute();

                if (sum == "")
                {
                    x = 0;
                    tc.CommandText = "select sum(VazneDone * FeeDone) + sum( VazneNimdone * FeeNimdone) +   sum( VazneSabos * FeeSabos)   from tblPardakht as a";
                    sum1 = tc.ScalerExecute();
                    x += Convert.ToDouble(sum1);
                }
                else
                {
                    x = Convert.ToDouble(sum);
                    tc.CommandText = "select sum(VazneDone * FeeDone) + sum( VazneNimdone * FeeNimdone) +   sum( VazneSabos * FeeSabos)   from tblPardakht as a";
                    sum1 = tc.ScalerExecute();
                    x += Convert.ToDouble(sum1);

                }
            }
            catch (Exception)
            {

            }
          
            
            return x.ToString();
        }
        double GetTankha()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Mablagh]) from [tblTankhah] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHaine()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([CostMablagh]) from [tblCost] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHoghogh()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([SalaryMablagh]) from [tblSalary] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetCart()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Card]) from [tblPardakht] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHesabKArkhaneBed()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bed]) from [tblHesabKarkhane] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHesabKArkhaneBes()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bes]) from [tblHesabKarkhane] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetNaghd()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Nagh]) from [tblPardakht] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetTakhfif()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bed]) from [tblTakhfif] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetDaramad()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bes]) from [tblDaramadTabdil] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHesabMoshtariBed()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bed]) from [tblHesabMoshtari] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetHesabMoshtariBes()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([Bes]) from [tblHesabMoshtari] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetTedadShali()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([TedadShali]) from [tblDaramadTabdil] ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        //================================================================================
        double GetVaznDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneDone] where [RefNoGardesh]=444 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetMablaghDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneDone] where [RefNoGardesh]=444 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        //================================================================================
        double GetVaznNDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneNDone] where [RefNoGardesh]=555 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetMablaghNDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneNDone] where [RefNoGardesh]=555 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        //================================================================================
        double GetVaznSabosNarm()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneSabosNarm] where [RefNoGardesh]=666 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetMablaghSabosNarme()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneSabosNarm] where [RefNoGardesh]=666 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        //================================================================================
        double GetVaznSabosDo()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneSabosDo] where [RefNoGardesh]=666 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetMablaghSabosDo()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneSabosDo] where [RefNoGardesh]=666 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        private void frmGozareshKol_Load(object sender, EventArgs e)
        {
            #region 1
            DayaftKarmozdmahsol = GetKarmozd();
            lblDaryaftiKarmozd.Text=DayaftKarmozdmahsol.ToString("N0");

            FororshMahsol =Convert.ToDouble(GetFororshMahsol());
           lblForoshKarmozd.Text = FororshMahsol.ToString("N0");

            KharidMahsol = Convert.ToDouble(GetKharidMahsol());
            lblKharidMahsol.Text = KharidMahsol.ToString("N0");

            SodMahsol = (FororshMahsol - KharidMahsol);
            lblKarmozdSod.Text = SodMahsol.ToString("N0");

            Tankha = GetTankha();
            lblTankhah.Text=Tankha.ToString("N0");

            Hazine = GetHaine();
            lblHazine.Text = Hazine.ToString("N0");

            Hoghogh = GetHoghogh();
            lblHoghogh.Text = Hoghogh.ToString("N0");

            DaryaftCart = GetCart();
            lblCarti.Text = DaryaftCart.ToString("N0");

            DaryaftNaghd = GetNaghd();
            lblNaghd.Text = DaryaftNaghd.ToString("N0");

            Takhfif = GetTakhfif();
            lblTakhfif.Text = Takhfif.ToString("N0");
            //--------------------------------------------------------------------
            HesabKarkhaneBed = GetHesabKArkhaneBed();
            HesabKarkhaneBes = GetHesabKArkhaneBes();

            Sood = HesabKarkhaneBes - (HesabKarkhaneBed + Hazine +Hoghogh+Tankha);
            lblsod.Text= Sood.ToString("N0");

            Daramad = GetDaramad();
            lblDaramad.Text = Daramad.ToString("N0");

            TalabKeshavarz = GetHesabMoshtariBed()-GetHesabMoshtariBes();
            lblTalab.Text = TalabKeshavarz.ToString("N0");
             
            DaryaftAzKeshavarz= GetHesabMoshtariBes();
            lblDaryafti.Text = DaryaftAzKeshavarz.ToString("N0");

            TedadShali = GetTedadShali();
            lblShali.Text = TedadShali.ToString("N0");
            #endregion
            //--------------------------------------------------------------------
            VaznDone = GetVaznDone();
            lblDW.Text = VaznDone.ToString("N0");

            ForoshDone = GetMablaghDone();
            lblDM.Text = ForoshDone.ToString("N0");
            //--------------------------------------------------------------------
            VaznNimdone = GetVaznNDone();
            lblNW.Text = VaznNimdone.ToString("N0");

            ForoshNimdone = GetMablaghNDone();
            lblNDM.Text = ForoshNimdone.ToString("N0");
            //--------------------------------------------------------------------
            VaznSabosNarm = GetVaznSabosNarm();
            lblS1W.Text = VaznSabosNarm.ToString("N0");

            ForoshSabosNarm = GetMablaghSabosNarme();
            lblS1M.Text = ForoshSabosNarm.ToString("N0");
            //--------------------------------------------------------------------
            VaznSabosDo = GetVaznSabosDo();
            lblS2W.Text = VaznSabosDo.ToString("N0");

            ForoshSabosDo = GetMablaghSabosDo();
            lblS2M.Text = ForoshSabosDo.ToString("N0");
        }
    }
}
