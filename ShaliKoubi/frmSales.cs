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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        double ShaliKharidShode = 0;
        double ShaliForoshRafte = 0;
        public void KharidShali()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKShali where Bed=1";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos2 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos2 += Convert.ToInt32(dt.Rows[i]["WShali"]);
                    //majmo += Convert.ToInt32(dt.Rows[i]["ShaliMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            ShaliKharidShode = sabos2;
        }
        public void ForoshShali()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKShali where Bes=1";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            double sabos2 = 0;
            double majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos2 += Convert.ToDouble(dt.Rows[i]["WShali"]);
                    //majmo += Convert.ToInt32(dt.Rows[i]["ShaliMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            ShaliForoshRafte = sabos2;
        }
        public int KharidSabosNarm()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKSabosNarm";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WSNarm"]);

                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = sabos1;
            report[1] = majmo;
            return sabos1;
        }

        private void btnSabos_Click(object sender, EventArgs e)
        {
        }
       
        private void btnSabos2_Click(object sender, EventArgs e)
        {
        }

        private void btnNimdone_Click(object sender, EventArgs e)
        {
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
                        
        }
        string kg = " کیلوگرم ";
        private void frmSales_Load(object sender, EventArgs e)
        {
            ////Sabos 1Kob
            //Sabos kharid shode
            int[] khardiSabos1 = mt.KharidSabosNarm();
            //kol sabos karmozdi mahsol[0]
            int[] Mahsol = mt.Mahsol();
            lblSabosKol.Text = (khardiSabos1[0] + Mahsol[0]).ToString("N0")+kg;
            //Sabos Forosh rafte
            int[] Saboos1 = mt.SabosNarm();
            lblSabosFrosh.Text = Saboos1[0].ToString("N0")+kg;

            int SabosMododAnbar = ((khardiSabos1[0] + Mahsol[0]) - Saboos1[0]);
            lblSabosMojod.Text = SabosMododAnbar.ToString("N0")+kg;
            //------------------------------------------------------

            //Sabos 2Kob
            int SaboosOut = mt.Sabos2Output();
            int[] Saboos2 = mt.Sabos2();
            int Sabos2MododAnbar = SaboosOut - Saboos2[0];
            lblSabos2Kol.Text = SaboosOut.ToString("N0") + kg;
            lblSabos2Frosh.Text = Saboos2[0].ToString("N0") + kg;
            lblSabos2Mojod.Text = Sabos2MododAnbar.ToString("N0") + kg;
            //------------------------------------------------------


            //Nimdone kharid shode
            int[] KharidNimDone = mt.KharidNimDone();
            //Forosh Nimdone
            int[] NimDone = mt.NimDone();
            //Mahsol[1] Nimdone Karmozdi
            int NDoneMododAnbar = (Mahsol[1]+ KharidNimDone[0]) - NimDone[0];

            lblNDoneKol.Text = (Mahsol[1] + KharidNimDone[0]).ToString("N0") + kg;
            lblNDoneFrosh.Text = NimDone[0].ToString("N0") + kg;
            lblNDoneMojod.Text = NDoneMododAnbar.ToString("N0") + kg;
            //-----------------------------------------------------


            //Done
            int[] kharidDone = mt.KharidDone();
            int[] Done = mt.Done();
            int DoneMododAnbar = (Mahsol[2] + kharidDone[0]) - Done[0];
            lblDoneKol.Text = (Mahsol[2] + kharidDone[0]).ToString("N0") + kg;
            lblDoneFrosh.Text = Done[0].ToString("N0") + kg;
            lblDoneMojod.Text = DoneMododAnbar.ToString("N0") + kg;
            //Shali-----------------------------------------------------
            KharidShali();
            ForoshShali();
            lblKharidShali.Text = ShaliKharidShode.ToString("N0") + kg;
            lblForoshShali.Text= ShaliForoshRafte.ToString("N0") + kg;
            lblMojodShali.Text=(ShaliKharidShode - ShaliForoshRafte).ToString("N0") + kg;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmViewNimdone frmViewNimdone = new frmViewNimdone();
            frmViewNimdone.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmViewDone frmViewDone = new frmViewDone();
            frmViewDone.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new frmForoshShali().ShowDialog();
        }

        private void groupPanel8_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            new frmViewShali().ShowDialog();
        }
    }
}
