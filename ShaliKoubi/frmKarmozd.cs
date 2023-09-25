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
    public partial class frmKarmozd : Form
    {
        public frmKarmozd()
        {
            InitializeComponent();
        }
        method mt = new method();
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        clsNewEditing ne = new clsNewEditing();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        public int ProcessID { get; set; }
        public int CstmrID { get; set; }
        public string Name { get; set; }
        int PardakhtID = -1;
        bool Find(string tblName)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from ["+ tblName + "] where  ProcessID =N'" + ProcessID + "'";
            dt = tc.ExecuteReader();

            if (dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        DataTable GetNoMahsol(int ProcessID)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from [View_MahsolKarmozd] where ProcessID=N'" + ProcessID + "'";
            dt = tc.ExecuteReader();
            return dt;
        }
        double GetBedehkari(int CstmrID)
        {
            double bed = 0;
            tc.CommandText = "select (sum(bed)-sum(bes)) as bed from tblHesabMoshtari where MoshtariID=" + CstmrID;
            bed = Convert.ToDouble(tc.ScalerExecute());
            return bed;
        }
        double GetBedehkariMande(int CstmrID)
        {
            double bed = 0;
            tc.CommandText = "select (sum(bed)-sum(bes)) as bed from tblHesabMoshtari where MoshtariID=" + CstmrID+ " and RefNoGardesh = 222 and  ReferID =" + ProcessID;
            bed = Convert.ToDouble(tc.ScalerExecute());
            return bed;
        }
        string GetKarmozd()
        {
            string karmozd = "0";
            tc.CommandText = "select Bes from tblDaramadTabdil where ProcessID=" + ProcessID;
            karmozd = tc.ScalerExecute();
            return karmozd;
        }
        void Get_tblPardakht(int Pardakhtid)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from [tblPardakht] where [PardakhtID] =N'" + Pardakhtid + "'";
            dt = tc.ExecuteReader();
            txtDate.Text =(dt.Rows[0]["PardakhtDate"]).ToString();
            txtFeeDone.Text = ((double)dt.Rows[0]["FeeDone"]).ToString("N0");
            txtWDone.Text = ((double)dt.Rows[0]["VazneDone"]).ToString("N0");
            txtFeeNimdone.Text = ((double)dt.Rows[0]["FeeNimdone"]).ToString("N0");
            txtWNimdone.Text = ((double)dt.Rows[0]["VazneNimdone"]).ToString("N0");
            txtFeeSabos.Text = ((double)dt.Rows[0]["FeeSabos"]).ToString("N0");
            txtWSabos.Text = ((double)dt.Rows[0]["VazneSabos"]).ToString("N0");
            txtPayCard.Text = ((double)dt.Rows[0]["Card"]).ToString("N0");
            txtPayNaghd.Text = ((double)dt.Rows[0]["Nagh"]).ToString("N0");
            txtTakhfif.Text = ((double)dt.Rows[0]["Takhfif"]).ToString("N0");
        }
        void Display()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from [tblPardakht] where [ProcessID] =N'" + ProcessID + "'";
            dt = tc.ExecuteReader();
            dgvView.DataSource = dt;
            dgvView.Columns["PardakhtID"].Visible = false;
            dgvView.Columns["CstmrID"].Visible = false;
            dgvView.Columns["ProcessID"].Visible = false;
            dgvView.Columns["Nagh"].HeaderText = "نقد";
            dgvView.Columns["Card"].HeaderText = "کارت";
            dgvView.Columns["VazneSabos"].HeaderText = "وزن سبوس";
            dgvView.Columns["FeeSabos"].HeaderText = "فی سبوس";
            dgvView.Columns["VazneNimdone"].HeaderText = "وزن نیمدانه ";
            dgvView.Columns["FeeNimdone"].HeaderText = "فی نیمدانه ";
            dgvView.Columns["VazneDone"].HeaderText = "وزن برنج ";
            dgvView.Columns["FeeDone"].HeaderText = "فی برنج ";
            dgvView.Columns["Jam"].HeaderText = "جمع";
            dgvView.Columns["Takhfif"].HeaderText = "تخفیف ";
            dgvView.Columns["PardakhtDate"].HeaderText = "تاریخ ";

        }
        private void SetIntoTextBox(DataTable dt)
        {
            txtWDone.WatermarkText = dt.Rows[0]["Done"].ToString();
            txtWNimdone.WatermarkText = dt.Rows[0]["NimDone"].ToString();
            txtWSabos.WatermarkText = dt.Rows[0]["Sabos"].ToString();
            txtFeeDone.Text = dt.Rows[0]["FeeDone"].ToString();
            txtFeeNimdone.Text = dt.Rows[0]["feeNimDone"].ToString();
            txtFeeSabos.Text = dt.Rows[0]["FeeSabos"].ToString();
            ////////////////////////////////////////////////////////////
            lblNoShali.Text = dt.Rows[0]["InNo"].ToString();
            lblTedadShali.Text = dt.Rows[0]["InTedadKise"].ToString();
            lblInDate.Text = dt.Rows[0]["InDate"].ToString();
            ///////////////////////////////////////////////////////////
            lblVDone.Text = dt.Rows[0]["Done"].ToString();
            lblVNimdone.Text = dt.Rows[0]["NimDone"].ToString();
            lblVSabos.Text = dt.Rows[0]["Sabos"].ToString();
            lblTDone.Text = dt.Rows[0]["TedadKiseDone"].ToString();
            CstmrID = (int)dt.Rows[0]["CstmrID"];
            lblbed.Text = ((int)GetBedehkari((int)dt.Rows[0]["CstmrID"])).ToString("N0");
           // lblMande.Text = (((int)GetBedehkari((int)dt.Rows[0]["CstmrID"])) - (int)GetBedehkariMande((int)dt.Rows[0]["CstmrID"])).ToString("N0");
            lblMande.Text = ((int)GetBedehkari((int)dt.Rows[0]["CstmrID"])).ToString("N0");
            lblName.Text = Name;
            lblID.Text = CstmrID.ToString();
            lblKarmozdKisei.Text = (Convert.ToDouble(GetKarmozd())).ToString("N0"); ;

        }
        private double Calculate()
        {
            double hasel = 0;
            double PayNaghd = 0; double PayCard = 0;
            double WSabos = 0; double FeeSabos = 0;
            double WNimdone = 0; double FeeNimdone = 0;
            double WDone = 0; double FeeDone = 0;
            double Takhfif = 0;
            try
            {

                if (txtPayNaghd.Text != "")
                {
                    PayNaghd = Convert.ToDouble(txtPayNaghd.Text.Replace(",", ""));
                }
                if (txtPayCard.Text != "")
                {
                    PayCard = Convert.ToDouble(txtPayCard.Text.Replace(",", ""));
                }
                if (txtWSabos.Text != "")
                {
                    WSabos = Convert.ToDouble(txtWSabos.Text.Replace(",", ""));
                }
                if (txtFeeSabos.Text != "")
                {
                    FeeSabos = Convert.ToDouble(txtFeeSabos.Text.Replace(",", ""));
                }
                if (txtWNimdone.Text != "")
                {
                    WNimdone = Convert.ToDouble(txtWNimdone.Text.Replace(",", ""));
                }
                if (txtFeeNimdone.Text != "")
                {
                    FeeNimdone = Convert.ToDouble(txtFeeNimdone.Text.Replace(",", ""));
                }
                if (txtFeeDone.Text != "")
                {
                    FeeDone = Convert.ToDouble(txtFeeDone.Text.Replace(",", ""));
                }
                if (txtWDone.Text != "")
                {
                    WDone = Convert.ToDouble(txtWDone.Text.Replace(",", ""));
                }
                if (txtTakhfif.Text != "")
                {
                    Takhfif = Convert.ToDouble(txtTakhfif.Text.Replace(",", ""));
                }
                hasel = PayNaghd +
                        PayCard +
                        (WSabos * FeeSabos) +
                        (WNimdone * FeeNimdone) +
                        (FeeDone * WDone) +
                         Takhfif;
                lblMande.Text = (Convert.ToDouble(GetKarmozd()) - hasel).ToString("N0");

            }
            catch (Exception)
            {

            }
            
            return hasel;
        }
        DataTable GetNoMahsol()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select BNoID from tblBNo where No=N'" + lblNoShali.Text + "'";
            dt = tc.ExecuteReader();
            return dt;
        }

        double ConvertToNum(string text)
        {
            double c = 0;
           c = Convert.ToDouble(text.Replace(",", ""));
            return c;
        }
        private void frmKarmozd_Load(object sender, EventArgs e)
        {
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            SetIntoTextBox(GetNoMahsol(ProcessID));
            Display();
            //btnPardakht.Visible = false;
            //bool CheckFind = Find("tblPardakht");
            if ( Find("tblPardakht"))
            {
                btnSave.Visible = false;
                btnEdit.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtable = GetNoMahsol();
            int noDone = (int)(dtable.Rows[0][0]);

            double hasel = 0;
            double PayNaghd = 0; double PayCard = 0;
            double WSabos = 0; double FeeSabos = 0;
            double WNimdone = 0; double FeeNimdone = 0;
            double WDone = 0; double FeeDone = 0;
            double Takhfif = 0;
            try
            {

                if (txtPayNaghd.Text != "")
                {
                    PayNaghd = Convert.ToDouble(txtPayNaghd.Text.Replace(",", ""));
                }
                if (txtPayCard.Text != "")
                {
                    PayCard = Convert.ToDouble(txtPayCard.Text.Replace(",", ""));
                }
                if (txtWSabos.Text != "")
                {
                    WSabos = Convert.ToDouble(txtWSabos.Text.Replace(",", ""));
                }

                if (txtFeeSabos.Text != "")
                {
                    FeeSabos = Convert.ToDouble(txtFeeSabos.Text.Replace(",", ""));
                }
                if (txtWNimdone.Text != "")
                {
                    WNimdone = Convert.ToDouble(txtWNimdone.Text.Replace(",", ""));
                }
                if (txtFeeNimdone.Text != "")
                {
                    FeeNimdone = Convert.ToDouble(txtFeeNimdone.Text.Replace(",", ""));
                }
                if (txtFeeDone.Text != "")
                {
                    FeeDone = Convert.ToDouble(txtFeeDone.Text.Replace(",", ""));
                }
                if (txtWDone.Text != "")
                {
                    WDone = Convert.ToDouble(txtWDone.Text.Replace(",", ""));
                }
                if (txtTakhfif.Text != "")
                {
                    Takhfif = Convert.ToDouble(txtTakhfif.Text.Replace(",", ""));
                }
                if (txtTakhfif.Text != "")
                {
                    Takhfif = Convert.ToDouble(txtTakhfif.Text.Replace(",", ""));
                }
            }
            catch { }
            string cmdText = "Insert into [tblPardakht] ([CstmrID],[ProcessID],[Nagh],[Card],[VazneSabos],[FeeSabos],[VazneNimdone],[FeeNimdone],[VazneDone],[FeeDone],[Jam],[Takhfif],[PardakhtDate]) values" +
                "(" + CstmrID + "," + ProcessID +
                "," + PayNaghd +
                "," + PayCard +
                "," + WSabos +
                "," + FeeSabos +
                "," + WNimdone +
                "," + FeeNimdone +
                "," + WDone +
                "," + FeeDone +
                "," + Convert.ToDouble(lblJameKol.Text.Replace(",", "")) +
                 "," + Takhfif +
                  "," + "'" + txtDate.Text + "'" + ")";

            /////////////////////////////////////////////////////////////////////////////////////////////////
            //Done 
            //if (txtWDone.Text != "" && ConvertToNum(txtWDone.Text) > 0)
            //{
                //Karkhane///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolKarkhaneDone] (VaznBed,VaznBes,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz)values" +
                "(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                ",0," + ProcessID + ",22," + noDone + "," + FeeDone + ")";
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariDone] (VaznBes,VaznBed,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz)values" +
                "(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                ",0," + ProcessID + ",22," + noDone + "," + FeeDone + ")";
            //}

            //Nimdone
            //if (txtWNimdone.Text != "" && ConvertToNum(txtWNimdone.Text) > 0)
            //{
                //Karkhane///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolKarkhaneNDone] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                "(" + WNimdone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",22," + noDone + "," + FeeNimdone + ")";
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariNDone] (VaznBes,VaznBed,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                "(" + WNimdone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",22," + noDone + "," + FeeNimdone + ")";
            //}

            //SabosNarm
            //if (txtWSabos.Text != "" && ConvertToNum(txtWSabos.Text) > 0)
            //{
                //Karkhane///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolKarkhaneSabosNarm] (VaznBed,VaznBes,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                "(" + WSabos + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",22,0," + FeeSabos + ")";
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariSabosNarm] (VaznBes,VaznBed,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz)values" +
                "(" + WSabos + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",22,0," + FeeSabos + ")";
            //}

            //GhesmatMali///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //ReferType= , ReferID=OutID, ReferNo=Tabdil(tblGardeshMAhsol)
            //Moshtari
            cmdText += " insert into [tblHesabMoshtari]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                "("  +Convert.ToDouble(lblJameKol.Text.Replace(",", ""))  + ",0," + CstmrID + ",22," + ProcessID + ",0,'" + txtDate.Text + "',0,0,0)";
            //Karkhane
            cmdText += " insert into [tblHesabKarkhane]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                "(0," + Convert.ToDouble(lblJameKol.Text.Replace(",", "")) + "," + CstmrID + ",22," + ProcessID + ",0,'" + txtDate.Text + "',0,0,0)";

            //Takhfif
            cmdText += " INSERT into tblTakhfif (ProcessID,Bed,Date)values(" + ProcessID + "," + Takhfif + ", '" + txtDate.Text + "' )";

            if (trnsction.Execute_TRANSACTION(cmdText))
            {
                Display();
                MessageBox.Show("ثبت با موفقیت انجام شد");
                btnSave.Visible = false;
                btnEdit.Visible = true;

            }
            else
            {
                MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataTable dtable = GetNoMahsol();
            int noDone = (int)(dtable.Rows[0][0]);

            double hasel = 0;
            double PayNaghd = 0; double PayCard = 0;
            double WSabos = 0; double FeeSabos = 0;
            double WNimdone = 0; double FeeNimdone = 0;
            double WDone = 0; double FeeDone = 0;
            double Takhfif = 0;
            try
            {

                if (txtPayNaghd.Text != "")
                {
                    PayNaghd = Convert.ToDouble(txtPayNaghd.Text.Replace(",", ""));
                }
                if (txtPayCard.Text != "")
                {
                    PayCard = Convert.ToDouble(txtPayCard.Text.Replace(",", ""));
                }
                if (txtWSabos.Text != "")
                {

                    WSabos = Convert.ToDouble(txtWSabos.Text.Replace(",", ""));
                }

                if (txtFeeSabos.Text != "")
                {
                    FeeSabos = Convert.ToDouble(txtFeeSabos.Text.Replace(",", ""));
                }
                if (txtWNimdone.Text != "")
                {
                    WNimdone = Convert.ToDouble(txtWNimdone.Text.Replace(",", ""));
                }
                if (txtFeeNimdone.Text != "")
                {
                    FeeNimdone = Convert.ToDouble(txtFeeNimdone.Text.Replace(",", ""));
                }
                if (txtFeeDone.Text != "")
                {
                    FeeDone = Convert.ToDouble(txtFeeDone.Text.Replace(",", ""));
                }
                if (txtWDone.Text != "")
                {
                    WDone = Convert.ToDouble(txtWDone.Text.Replace(",", ""));
                }
                if (txtTakhfif.Text != "")
                {
                    Takhfif = Convert.ToDouble(txtTakhfif.Text.Replace(",", ""));
                }
                if (txtTakhfif.Text != "")
                {
                    Takhfif = Convert.ToDouble(txtTakhfif.Text.Replace(",", ""));
                }
            }
            catch { }
            string cmdText = "UPDATE [tblPardakht] Set [Nagh]=N'" + PayNaghd + "'," +
                "[Card]=N'" + PayCard + "'," +
                "[VazneSabos]=N'" + WSabos + "'," +
                "[FeeSabos]=N'" + FeeSabos + "'," +
                "[VazneNimdone]=N'" + WNimdone + "'," +
                "[FeeNimdone]=N'" + FeeNimdone + "'," +
                "[VazneDone]=N'" + WDone + "'," +
                "[FeeDone]=N'" + FeeDone + "'," +
                "[Jam]=N'" + Convert.ToDouble(lblJameKol.Text.Replace(",", "")) + "'," +
                "[Takhfif]=N'" + Takhfif + "'," +
                "[PardakhtDate]=N'" + txtDate.Text + "' where PardakhtID="+PardakhtID;
            //Done/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane
            //if (txtWDone.Text != "" && ConvertToNum(txtFeeNimdone.Text) > 0)
            //{
                cmdText += " UPDATE [tblAnbarMahsolKarkhaneDone] Set [VaznBed]=N'" + WDone + "'," +
                "[FeeRooz]=N'" + FeeDone + "'," +
                "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID;
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariDone] Set [VaznBes]=N'" + WDone + "'," +
                    "[FeeRooz]=N'" + FeeDone + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + " and [RefNoGardesh] =22";
            //}
            //Nimdone/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane
            //if (txtWNimdone.Text != "" && ConvertToNum(txtWNimdone.Text) > 0)
            //{
                cmdText += " UPDATE [tblAnbarMahsolKarkhaneNDone] Set [VaznBed]=N'" + WNimdone + "'," +
                "[FeeRooz]=N'" + FeeNimdone + "'," +
                "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID;
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariNDone] Set [VaznBes]=N'" + WNimdone + "'," +
                    "[FeeRooz]=N'" + FeeNimdone + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + " and [RefNoGardesh] =22";
            //}
            //Sabos/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane
            //if (txtWSabos.Text != "" && ConvertToNum(txtWSabos.Text) > 0)
            //{
                cmdText += " UPDATE [tblAnbarMahsolKarkhaneSabosNarm] Set [VaznBed]=N'" + WSabos + "'," +
                "[FeeRooz]=N'" + FeeSabos + "'," +
                "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID;
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariSabosNarm] Set [VaznBes]=N'" + WSabos + "'," +
                    "[FeeRooz]=N'" + FeeSabos + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + "and [RefNoGardesh] =22";
            //}
            //Mali/////////////////////////////////////////////////////////////////////////////////////////////////
            cmdText += " UPDATE [tblHesabMoshtari] Set [bes]=N'" + Convert.ToDouble(lblJameKol.Text.Replace(",", "")) + "' where ReferID=" + ProcessID + " and [RefNoGardesh] =22";
            cmdText += " UPDATE [tblHesabKarkhane] Set [bed]=N'" + Convert.ToDouble(lblJameKol.Text.Replace(",", "")) + "' where ReferID=" + ProcessID + " and [RefNoGardesh] =22";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            cmdText += " UPDATE [tblTakhfif] Set [Bed]=N'" + Takhfif + "' where [ProcessID]=" + ProcessID;

            if (trnsction.Execute_TRANSACTION(cmdText))
            {
                Display();
                MessageBox.Show("ویرایش با موفقیت انجام شد");
            }
            else
            {
                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
        }
        #region TextBoxs
        private void txtFeeNimdone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeNimdone.Text != string.Empty)
                {
                    txtFeeNimdone.Text = string.Format("{0:N0}", double.Parse(txtFeeNimdone.Text.Replace(",", "")));
                    txtFeeNimdone.Select(txtFeeNimdone.TextLength, 0);
                }
                lblJameKol.Text = Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtFeeSabos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeSabos.Text != string.Empty)
                {
                    txtFeeSabos.Text = string.Format("{0:N0}", double.Parse(txtFeeSabos.Text.Replace(",", "")));
                    txtFeeSabos.Select(txtFeeSabos.TextLength, 0);
                }
                lblJameKol.Text = Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtFeeDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeDone.Text != string.Empty)
                {
                    txtFeeDone.Text = string.Format("{0:N0}", double.Parse(txtFeeDone.Text.Replace(",", "")));
                    txtFeeDone.Select(txtFeeDone.TextLength, 0);
                }
                lblJameKol.Text = Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtPayCard_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPayCard.Text != string.Empty)
                {
                    txtPayCard.Text = string.Format("{0:N0}", double.Parse(txtPayCard.Text.Replace(",", "")));
                    txtPayCard.Select(txtPayCard.TextLength, 0);
                }
                lblJameKol.Text = Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtPayNaghd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPayNaghd.Text != string.Empty)
                {
                    txtPayNaghd.Text = string.Format("{0:N0}", double.Parse(txtPayNaghd.Text.Replace(",", "")));
                    txtPayNaghd.Select(txtPayNaghd.TextLength, 0);
                }
               lblJameKol.Text= Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtWNimdone_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtWNimdone.Text != string.Empty)
                {
                    txtWNimdone.Text = string.Format("{0:N0}", double.Parse(txtWNimdone.Text.Replace(",", "")));
                    txtWNimdone.Select(txtWNimdone.TextLength, 0);
                }
                //if (ConvertToNum(txtWNimdone.Text) > ConvertToNum(txtWNimdone.WatermarkText))
                //{
                //    MessageBox.Show("مقدار وزن نیمدانه وارد شده از مقدار موجود در انبار بیشتر می باشد");
                //}
                //else
                //{
                    lblJameKol.Text = Calculate().ToString("N0");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtWSabos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWSabos.Text != string.Empty)
                {
                    txtWSabos.Text = string.Format("{0:N0}", double.Parse(txtWSabos.Text.Replace(",", "")));
                    txtWSabos.Select(txtWSabos.TextLength, 0);
                }
                //if (ConvertToNum(txtWSabos.Text) > ConvertToNum(txtWSabos.WatermarkText))
                //{
                    //MessageBox.Show("مقدار وزن سبوس وارد شده از مقدار موجود در انبار بیشتر می باشد");
                //}
                //else
                //{
                    lblJameKol.Text = Calculate().ToString("N0");
                //}
                   
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWDone.Text != string.Empty)
                {
                    txtWDone.Text = string.Format("{0:N0}", double.Parse(txtWDone.Text.Replace(",", "")));
                    txtWDone.Select(txtWDone.TextLength, 0);
                }
                //if (ConvertToNum(txtWDone.Text) > ConvertToNum(txtWDone.WatermarkText))
                //{
                //    MessageBox.Show("مقدار وزن برنج وارد شده از مقدار موجود در انبار بیشتر می باشد");
                //}
                //else
                //{
                    lblJameKol.Text = Calculate().ToString("N0");
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
        private void txtTakhfif_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTakhfif.Text != string.Empty)
                {
                    txtTakhfif.Text = string.Format("{0:N0}", double.Parse(txtTakhfif.Text.Replace(",", "")));
                    txtTakhfif.Select(txtTakhfif.TextLength, 0);
                }
                lblJameKol.Text = Calculate().ToString("N0");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }

        #endregion

        private void frmKarmozd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            Get_tblPardakht((int)dgvView.CurrentRow.Cells["PardakhtID"].Value);
            PardakhtID = (int)dgvView.CurrentRow.Cells["PardakhtID"].Value;


        }

        private void dgvView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvView.Columns["Nagh"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["Card"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["Jam"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["Takhfif"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["feeNimDone"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["FeeSabos"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == dgvView.Columns["FeeDone"].Index && e.RowIndex != this.dgvView.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }

        private void lblMande_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblMande.Text.Replace(",","")) < 0)
            {
                btnPardakht.Visible = true;
            }
            else btnPardakht.Visible = false;
        }

        private void btnPardakht_Click(object sender, EventArgs e)
        {
            string cmdText = "";
            //Moshtari
            cmdText += " insert into [tblHesabMoshtari]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                "(" + ((Convert.ToDouble(lblMande.Text.Replace(",", "")))*-1) + ",0," + CstmrID + ",222," + ProcessID + ",0,'" + txtDate.Text + "',0,0,0)";
            //Karkhane
            cmdText += " insert into [tblHesabKarkhane]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                "(0," + ((Convert.ToDouble(lblMande.Text.Replace(",", "")) )* -1) + "," + CstmrID + ",222," + ProcessID + ",0,'" + txtDate.Text + "',0,0,0)";
            if (trnsction.Execute_TRANSACTION(cmdText))
            {
                Display();
                MessageBox.Show("ثبت با موفقیت انجام شد");
                btnSave.Visible = false;
                btnEdit.Visible = true;
                lblMande.Text = ((int)GetBedehkari(CstmrID)).ToString("N0");
                lblName.Text = Name;
            }
            else
            {
                MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            StiReport st = new StiReport();
            st["@ProcessID"] = ProcessID;
            st.Load(Application.StartupPath + "/Report/rptPardakht.mrt");
            st.Show();
        }
    }
}
