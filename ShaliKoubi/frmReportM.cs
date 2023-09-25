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
    public partial class frmReportM : Form
    {
        public frmReportM()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
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
        //-------------------------------------------------
        double KharidVaznDone = 0;
        double KharidMDone = 0;

        double KharidVaznNimdone = 0;
        double KharidMNimdone = 0;

        double KharidVaznSabosNarm = 0;
        double KharidMSabosNarm = 0;

        double KharidVaznSabosDo = 0;
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
        double GetKharidVaznDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneDone] where [RefNoGardesh]=22 and  RefNoGardesh = 44";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetKharidMablaghDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneDone] where [RefNoGardesh]=22 and  RefNoGardesh = 44";
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
        double GetKharidVaznNDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneNDone] where [RefNoGardesh]=55  and [RefNoGardesh]=22";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetKharidMablaghNDone()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneNDone] where [RefNoGardesh]=55  and [RefNoGardesh]=22 ";
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
        double GetKharidVaznSabosNarm()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneSabosNarm] where [RefNoGardesh]=66  and RefNoGardesh =22 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        double GetKharidMablaghSabosNarme()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select (sum([VaznBes]) * sum([FeeRooz])) as Amblagh from [tblAnbarMahsolKarkhaneSabosNarm] where [RefNoGardesh]=66 and RefNoGardesh =22";
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
        double GetKharidVaznSabosDo()
        {
            double sum = 0;
            try
            {
                tc.CommandText = "select sum([VaznBes]) from [tblAnbarMahsolKarkhaneSabosDo] where [RefNoGardesh]=22 ";
                sum = Convert.ToDouble(tc.ScalerExecute());
            }
            catch (Exception)
            {
            }
            return sum;
        }
        //================================================================================
        private void frmReportM_Load(object sender, EventArgs e)
        {
            VaznDone = GetVaznDone();
            lblDW.Text = VaznDone.ToString("N0");

            ForoshDone = GetMablaghDone();
            lblDM.Text = ForoshDone.ToString("N0");

            KharidVaznDone = GetKharidVaznDone();
            lblDWK.Text = KharidVaznDone.ToString("N0");

            KharidMDone = GetKharidMablaghDone();
            lblDFK.Text = KharidMDone.ToString("N0");
            //--------------------------------------------------------------------
            VaznNimdone = GetVaznNDone();
            lblNW.Text = VaznNimdone.ToString("N0");

            ForoshNimdone = GetMablaghNDone();
            lblNDM.Text = ForoshNimdone.ToString("N0");

            KharidVaznNimdone = GetKharidVaznNDone();
            lblDFK.Text = KharidVaznNimdone.ToString("N0");

            KharidMNimdone = GetKharidMablaghNDone();
            lblDWK.Text = KharidMNimdone.ToString("N0");
            //--------------------------------------------------------------------
            VaznSabosNarm = GetVaznSabosNarm();
            lblS1W.Text = VaznSabosNarm.ToString("N0");

            ForoshSabosNarm = GetMablaghSabosNarme();
            lblS1M.Text = ForoshSabosNarm.ToString("N0");

            KharidVaznSabosNarm = GetKharidVaznSabosNarm();
            lblS1WK.Text = KharidVaznSabosNarm.ToString("N0");

            KharidMSabosNarm = GetKharidMablaghSabosNarme();
            lblS1FK.Text = KharidMSabosNarm.ToString("N0");
            //--------------------------------------------------------------------
            VaznSabosDo = GetVaznSabosDo();
            lblS2W.Text = VaznSabosDo.ToString("N0");

            ForoshSabosDo = GetMablaghSabosDo();
            lblS2M.Text = ForoshSabosDo.ToString("N0");

            KharidVaznSabosDo = GetKharidVaznSabosDo();
            lblS2WK.Text = KharidVaznSabosDo.ToString("N0");

        }
    }
}
