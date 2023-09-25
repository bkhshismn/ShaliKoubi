using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaliKoubi
{
    /// <summary>
    /// In Class Baraye Virayesh Dovom Narmafzar Ijad SHode
    /// </summary>
    class clsNewEditing
    {
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        //---------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// TedadKise Moshtari
        /// </summary>
        /// <param name="cstmrID"></param>
        /// <returns></returns>
        public double KiseMoshtari(int cstmrID)
        {
            double report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblInput] where CstmrID=" + cstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            double Kise = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    Kise += Convert.ToDouble(dt.Rows[i]["InTedadKise"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = Kise;
            return report;
        }
        public int[] ReportPardakhtMoshtari(int cstmrID)
        {
            int PardakhtKol = 0;
            int Bedehkar = 0;
            int PardakhtBaMahsol = 0;
            int PardakhtBaChek = 0;
            int PardakhtNaghd = 0;
            int Takhfif = 0;
            int[] report = new int[6];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [tblPardakht] Where CstmrID="+cstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                //for (int i = 0; i <= cunt - 1; i++)
                //{
                //    sabos1 += Convert.ToInt32(dt.Rows[i]["WSNarm"]);
                //    majmo += Convert.ToInt32(dt.Rows[i]["SNMajmo"]);
                //}
            }
            else
            {
                report[0] = PardakhtKol;
                report[1] = Bedehkar;
                report[2] = PardakhtBaMahsol;
                report[3] = PardakhtBaChek;
                report[4] = PardakhtNaghd;
                report[5] = Takhfif;
            }
            
            return report;
        }
        public int KarmozdKise(int cstmrID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [View_CstmrToKhorojAnbar] where id=" + cstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int KarmozdKisei = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    KarmozdKisei += Convert.ToInt32(dt.Rows[i]["KarmozdKisei"]);
                   
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            return KarmozdKisei;
        }
        public int KarmozdVazn(int cstmrID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [View_CstmrToKhorojAnbar] where id=" + cstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int KarmozdVazn = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    KarmozdVazn += Convert.ToInt32(dt.Rows[i]["KarmozdVazni"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            return KarmozdVazn;
        }
        public int BedehkariZiroZiro( int id , int no)
        {
            int bedehkari = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_CstmrToPardakht where Bestankar = " + 0 + " and Bedehkar = " + 0 + " and Pardakhti = " + 0 + "  and id=" + id;
            adp.Fill(dt);
            int cunt1 = dt.Rows.Count;
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    if (no==1)
                    {
                        bedehkari += Convert.ToInt32(dt.Rows[i]["KarmozdKisei"]);
                    }  
                    else
                    {
                        bedehkari += Convert.ToInt32(dt.Rows[i]["KarmozdVazni"]);
                    }
                }

            }
            else
            {

            }
            con.Close();
            return bedehkari;
        }
        public int[] HesabMoshtari(int cstmrID)
        {
            int[] report = new int[6];
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
                    Mahsol += ((Convert.ToInt32(dt.Rows[i]["VazneSabos"])* (Convert.ToInt32(dt.Rows[i]["NerkhSabos"])))+ (Convert.ToInt32(dt.Rows[i]["VazneNimdone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhNimdone"])))+ (Convert.ToInt32(dt.Rows[i]["VazneDone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhDone"]))));
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
            return report;
        }

        public int[] NerkhKise(string CstmrNo)
        {
            int[] nerkh = new int[2];
            int NerkhKisei = 0;
            int NerkhVazni = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblFeeYear] ";
                adp.Fill(dt);
                if (CstmrNo == "کشاورز")
                {
                    NerkhKisei = Convert.ToInt32(dt.Rows[0]["FeeYear"]);
                    NerkhVazni = Convert.ToInt32(dt.Rows[0]["VaznKeshavarzi"]);
                }
                if (CstmrNo == "تاجر")
                {
                    NerkhKisei = Convert.ToInt32(dt.Rows[0]["KiseTajeri"]);
                    NerkhVazni = Convert.ToInt32(dt.Rows[0]["VaznTajeri"]);
                }
                nerkh[0] = NerkhKisei;
                nerkh[1] = NerkhVazni;
            }
            catch (Exception)
            {

            }
           
            return nerkh;
        }
    }
}
