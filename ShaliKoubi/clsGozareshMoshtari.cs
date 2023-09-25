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
    class clsGozareshMoshtari
    {
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();

        //int CstmCode = -1;
        //int cstmID = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        clsNewEditing ne = new clsNewEditing();
        public double TedadKise(int CstmrID)
        {
            double tedad = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblInput where CstmrID=" + CstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    tedad += Convert.ToDouble(dt.Rows[i]["InTedadKise"]);
                }
            }
            else
            {
                MessageBox.Show("رکورد خالی می باشد");
            }
            return tedad;
        }
        public int Vazn(int CstmrID)
        {
            int vazn = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblInput where CstmrID=" + CstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    vazn += Convert.ToInt32(dt.Rows[i]["InWeight"]);
                }
            }
            else
            {
                MessageBox.Show("رکورد خالی می باشد");
            }
            return vazn;
        }
        public int[] MohasebeKarmozdKol(int cstmrID,string cstmrNo)
        {
            int[] nerkh = new int[2];
            int[] Karmozd = new int[2];
            int nerkhvazni = 0;
            int nerkhkisei = 0;
            try
            {               
                double tedadkise = TedadKise(cstmrID);
                int vazneshali = Vazn(cstmrID);
                nerkh = ne.NerkhKise(cstmrNo);
                nerkhkisei = (int)(nerkh[0] * tedadkise);
                nerkhvazni = (int)(nerkh[1] * vazneshali);

            }
            catch (Exception)
            {

            }

            Karmozd[0] = nerkhkisei;
            Karmozd[1] = nerkhvazni;
            return Karmozd;
        }
        public int[] Mali(int CstmrID)
        {
            int[] mali = new int[5];
            int bes = 0;
            int bed = 0;
            int pardakhti = 0;
            int takhfif = 0;
            int chek = 0;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht where CstmrID=" + CstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    bes += Convert.ToInt32(dt.Rows[i]["Bestankar"]);
                    bed += Convert.ToInt32(dt.Rows[i]["Bedehkar"]);
                    pardakhti += Convert.ToInt32(dt.Rows[i]["Pardakhti"]);
                    takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
            }
            ///////////////////////////////////////////////////////////////////////////////////

            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            adp2.SelectCommand = new SqlCommand();
            adp2.SelectCommand.Connection = con;
            adp2.SelectCommand.CommandText = "select * from [PayCheck] where CstumID = " + CstmrID;
            adp2.Fill(dt2);
            int cunt2 = dt2.Rows.Count;

            if (cunt2 > 0)
            {
                for (int i = 0; i <= cunt2 - 1; i++)
                {
                    pardakhti += Convert.ToInt32(dt2.Rows[i]["Mablagh"]);
                    takhfif += Convert.ToInt32(dt2.Rows[i]["Takhfif"]);
                    chek += Convert.ToInt32(dt2.Rows[i]["Mablagh"]);
                }
            }
            else
            {

            }
            mali[0] = pardakhti;
            mali[1] = bed;
            mali[2] = bes;
            mali[3] = takhfif;
            mali[4] = chek;
            return mali;
        }
        public int PardakhtiBedehkariSalePish(int CstmrID)
        {

            int bes = 0;
            int bed = 0;
            int pardakhti = 0;
            int takhfif = 0;

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblBedehkaranSalGozashte where CstmrID=" + CstmrID;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    pardakhti += Convert.ToInt32(dt.Rows[i]["Pardakhti"]);
                    takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
            }
            ///////////////////////////////////////////////////////////////////////////////////

            DataSet ds2 = new DataSet();
            SqlDataAdapter adp2 = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            adp2.SelectCommand = new SqlCommand();
            adp2.SelectCommand.Connection = con;
            adp2.SelectCommand.CommandText = "select * from [tblMahsolBedSalePish] where CstmrID=" + CstmrID;
            adp2.Fill(dt2);
            int cunt2 = dt2.Rows.Count;

            if (cunt2 > 0)
            {
                for (int i = 0; i <= cunt2 - 1; i++)
                {
                    pardakhti += Convert.ToInt32(dt2.Rows[i]["MablaghMahsol"]);
                }
            }
            else
            {

            }
            return (pardakhti - takhfif);
        }

    }
}
