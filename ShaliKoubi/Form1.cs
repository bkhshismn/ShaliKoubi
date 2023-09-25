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
    public partial class frmMain : Form
    {
        public string UserName { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        string dateNow;
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void CrearTables(string tblName)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from "+tblName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void DisplayCheck()
        {
            dateNow = "'" + dateNow + "'";
            DataSet ds = new DataSet();
            DataTable dtb = new DataTable();
            SqlDataAdapter adb = new SqlDataAdapter();
            adb.SelectCommand = new SqlCommand();
            adb.SelectCommand.Connection = con;
            adb.SelectCommand.CommandText = "select * from tblCheck where ChkDate=N" + dateNow;
            adb.Fill(dtb);
            int cunt = dtb.Rows.Count;
            btnChecks.Text = (" چکهای امروز" + ": " + cunt).ToString();

        }
        /// <summary>
        /// BackUp
        /// </summary>
        /// <param name="filename"></param>
        private void Backup(string filename)
        {
            SqlConnection oconnection = null;
            try
            {
                string command = @"Backup DataBase [DBShalikoubi] To Disk='" + filename + "'";
                this.Cursor = Cursors.WaitCursor;
                SqlCommand ocommand = null;
                oconnection = new SqlConnection("Data source =.;initial catalog=DBShalikoubi;integrated security = true");
                if (oconnection.State != ConnectionState.Open)
                    oconnection.Open();
                ocommand = new SqlCommand(command, oconnection);
                ocommand.ExecuteNonQuery();
                this.Cursor = Cursors.Default;
                MessageBox.Show("پشتیبان گیری انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                oconnection.Close();
            }
        }
        private void FinishBackUp()
        {
            SaveFileDialog SaveBackUp = new SaveFileDialog();
            string filename = string.Empty;
            SaveBackUp.OverwritePrompt = true;
            SaveBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            SaveBackUp.DefaultExt = "Bak";
            SaveBackUp.FilterIndex = 1;
            SaveBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            SaveBackUp.Title = "Backup SQL File";
            if (SaveBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = "d:\\test.bak";
                Backup(filename);
            }
        }
        /// <summary>
        /// Restore
        /// </summary>
        /// <param name="filename"></param>
        private void Restore(string filename)
        {
            SqlConnection oconnection = null;
            try
            {
                string command = @"ALTER DATABASE [DBShalikoubi] SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE [DBShalikoubi] FROM DISK= N'" + filename + "'WITH RECOVERY, REPLACE";
                this.Cursor = Cursors.WaitCursor;
                SqlCommand ocommand = null;
                oconnection = new SqlConnection("Data Source=.;Initial Catalog=DBShalikoubi;Integrated Security=True");
                if (oconnection.State != ConnectionState.Open)
                    oconnection.Open();
                ocommand = new SqlCommand(command, oconnection);
                ocommand.ExecuteNonQuery();
                this.Cursor = Cursors.Default;
                MessageBox.Show( "باز نشانی پشتیبان  انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                oconnection.Close();
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnCheck.Visible = false;

            dateNow = dt.GetYear(DateTime.Now).ToString() + "/" + dt.GetMonth(DateTime.Now).ToString("0#") + "/" + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            //if (UserName != "admin")
            //{
            //    btnFroshKharid.Enabled = false;
            //    btnKol.Enabled = false;
            //    btnExit.Enabled = false;
            //    buttonX6.Enabled = false;
            //    buttonX11.Visible = false;
            //}
            DisplayCheck();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog();
        }
        private void btnAddCostomer_Click(object sender, EventArgs e)
        {
            new frmCostomer().ShowDialog();

        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            new frmPrsnl().ShowDialog();
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {
            new frmInput().ShowDialog();
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            new frmProcess().ShowDialog();
        }
        private void buttonX5_Click(object sender, EventArgs e)
        {
            new frmOutput().ShowDialog();
        }
        private void buttonX6_Click(object sender, EventArgs e)
        {
            new frmPardakhtKarmozd().ShowDialog();
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            new frmCost().ShowDialog();
        }
        private void buttonX9_Click(object sender, EventArgs e)
        {
            new frmfeeYear().ShowDialog();
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            new frmSalary().ShowDialog();
        }
        private void btnSale_Click(object sender, EventArgs e)
        {
           new frmSales().ShowDialog();
        }
        private void btnKol_Click(object sender, EventArgs e)
        {

            new frmGozareshKol().ShowDialog();
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveBackUp = new SaveFileDialog();
            string filename = string.Empty;
            SaveBackUp.OverwritePrompt = true;
            SaveBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            SaveBackUp.DefaultExt = "Bak";
            SaveBackUp.FilterIndex = 1;
            SaveBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            SaveBackUp.Title = "Backup SQL File";
            if (SaveBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = SaveBackUp.FileName;
                Backup(filename);
            }
        }
        private void btbRestor_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            OpenFileDialog OpenBackUp = new OpenFileDialog();
            OpenBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            OpenBackUp.FilterIndex = 1;
            OpenBackUp.Filter = @"SQL Backup Files (*.*)|";

            OpenBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            if (OpenBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = OpenBackUp.FileName;
                Restore(filename);
            }
        }
        private void btnMahsol_Click(object sender, EventArgs e)
        {
            new  frmReportM().ShowDialog();
        }
        private void buttonX10_Click(object sender, EventArgs e)
        {
            new frmSales().ShowDialog();
        }
        private void btnReportCstmr_Click(object sender, EventArgs e)
        {
            new frmGozaresheMoshtari().ShowDialog();
        }
        private void btnHoghogh_Click(object sender, EventArgs e)
        {
            new frmReportMember().ShowDialog();
        }
        private void btnDaryafti_Click(object sender, EventArgs e)
        {
        }
        private void btnAnbar_Click(object sender, EventArgs e)
        {
            new frmConrolAnbar().ShowDialog();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            new frmConrolAnbar().ShowDialog();
        }
        private void txtTankhah_Click(object sender, EventArgs e)
        {
            new frmTankhah().ShowDialog();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            new PassChecks().ShowDialog();
        }
        private void buttonX11_Click(object sender, EventArgs e)
        {
        }
        private void btnBedehkar_Click(object sender, EventArgs e)
        {
            new frmBedehkaaran().ShowDialog();
        }
        private void btnSarbarg_Click(object sender, EventArgs e)
        {
            new frmNameKarkhane().ShowDialog();
        }
        private void btnBastanHesab_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به بستن حساب سال جاری هستید؟ ", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var result1 = MessageBox.Show(".در صورت موافقت دیگر قادر به برگشت به حساب سال پیش نیستید\n آیا موافقید؟ ", "هشدار", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    Backup("d:\\Backup\\BackupSal.bak");
                    //Clear Tabals//////////////////////////////////////////////////////////////
                    new method().InsertBedehkaranSalePish();
                    new method().InsertBestankarkaranSalePish();
                    CrearTables("tblPardakht");
                    CrearTables("tblListAnbar");
                    CrearTables("tblAnbarKhorji");
                    CrearTables("tblMahsolBedSalePish");
                    CrearTables("tblMoshtariBedehkar");
                    //Table OutPut
                    CrearTables("tblOutput");
                    //Table Process
                    CrearTables("tblProcess");
                    //Table Input
                    CrearTables("tblInput");
                    //Table tblNDone
                    CrearTables("PayCheck");
                    CrearTables("tblCost");
                    CrearTables("tblDaryaftiMotefareghe");
                    CrearTables("tblDone");
                    CrearTables("tblKDone");
                    CrearTables("tblKNDone");
                    CrearTables("tblNDone");
                    CrearTables("tblKSabosNarm");
                    CrearTables("tblMoshtariBedehkar");
                    CrearTables("tblSabosDo");
                    CrearTables("tblSabosNarm");
                    CrearTables("tblSalary");
                    CrearTables("tblSayer");
                    CrearTables("tblTankhah");
                }                  
            }          
        }
        private void btnGozareshTabdil_Click(object sender, EventArgs e)
        {
            new frmGozareshTabdilat().ShowDialog();
        }
        void update(double tedad, int id)
        {
            SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Update View_CstmrToPardakht Set KarmozdKisei=" + (tedad * 45000) + "where OutputID=" + id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void buttonX11_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_CstmrToPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    update((double)(dt.Rows[i]["InTedadKise"]), (int)dt.Rows[i]["OutputID"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            new frmModiriatCheck().ShowDialog();
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            frmNamayeshCheck frm = new frmNamayeshCheck();
            frm.Show();
        }

        private void btnGharz_Click(object sender, EventArgs e)
        {
            new frmDasti().ShowDialog();
        }

        private void buttonX13_Click_1(object sender, EventArgs e)
        {
            new frmDastiDaryaft().ShowDialog();
        }

        private void btnKharidShali_Click(object sender, EventArgs e)
        {
            new frmKharidShali().ShowDialog();
        }

        private void btnKharidDone_Click(object sender, EventArgs e)
        {
            new frmKharidDone().ShowDialog();
        }
        private void btnKharidNimdone_Click(object sender, EventArgs e)
        {
            new frmKharidNimdone().ShowDialog();
        }

        private void btnKharidSabosnarm_Click(object sender, EventArgs e)
        {
            new frmKharidSabosNarm().ShowDialog();
        }

        private void btnForoshDone_Click(object sender, EventArgs e)
        {
            new frmFororshDone().ShowDialog();

        }

        private void btnForoshNimdone_Click(object sender, EventArgs e)
        {
            new frmForoshNimdone().ShowDialog();
        }

        private void btnForoshSabpsNarm_Click(object sender, EventArgs e)
        {
            new frmFororshSabosNarm().ShowDialog();
        }

        private void btnForoshShali_Click(object sender, EventArgs e)
        {
            new frmForoshShali().ShowDialog();
        }

        private void btnForoshSabosDo_Click(object sender, EventArgs e)
        {
            new frmForoshSabosDo().ShowDialog();
        }
    }
}
