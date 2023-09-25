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
    public partial class ftmveiwAnbar : Form
    {
        #region Property
        public string CstmrName { get; set; }
        public int CstmrID { get; set; }
        public int ProcessID { get; set; }
        public double Done { get; set; }
        public double Sabos { get; set; }
        public double Nimdone { get; set; }
        public string NoDone { get; set; }
        public double TShali { get; set; }
        public int ShFer { get; set; }
        public string DateFer { get; set; }
        #endregion
        public ftmveiwAnbar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        int Id = -1;
        int EditDone = 0;
        int EditNDone = 0;
        int EditSabos = 0;
        int RefAnbarID = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        //-------------------------------------------

        double ConvertToNum(string text)
        {
            double c = 0;
            c = Convert.ToDouble(text.Replace(",", ""));
            return c;
        }
        DataTable GetNoMahsol()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select BNoID from tblBNo where No=N'" + NoDone + "'";
            dt = tc.ExecuteReader();
            return dt;
        }
        string GetAnbarID()
        {
            string AnbarID = "";
            tc.CommandText = "select top(1) AnbarID from tblListAnbar where AnbarID >1 order by AnbarID desc";
            AnbarID = tc.ScalerExecute();
            return AnbarID;
        }
        void Display()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from [tblListAnbar] inner join [tblNoGaredeshMahsol] on tblListAnbar.NahveKhoroj=tblNoGaredeshMahsol.[GardeshID] where [OutputID] =N'" + ProcessID + "' ";
            dt = tc.ExecuteReader();
            dgvAnbar.DataSource = dt;
            dgvAnbar.Columns["AnbarID"].Visible = false;
            dgvAnbar.Columns["OutputID"].Visible = false;
            dgvAnbar.Columns["TDone"].Visible = false;
            dgvAnbar.Columns["No"].Visible = false;
            dgvAnbar.Columns["CstmrID"].Visible = false;
            dgvAnbar.Columns["GrdeshNo"].HeaderText = "نحوه خروج";
            dgvAnbar.Columns["GardeshID"].Visible = false;
            dgvAnbar.Columns["NahveKhoroj"].Visible = false;

            dgvAnbar.Columns["WSabos"].HeaderText = "وزن سبوس";
            dgvAnbar.Columns["WNDone"].HeaderText = "وزن نیمدانه ";
            dgvAnbar.Columns["wDone"].HeaderText = "وزن برنج ";
            dgvAnbar.Columns["Outdate"].HeaderText = "تاریخ ";
        }
        private void ftmveiwAnbar_Load(object sender, EventArgs e)
        {
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lblName.Text = CstmrName.ToString(); 
            lblID.Text = CstmrID.ToString();
            txtWDone.WatermarkText = Done.ToString();
            txtWNimdone.WatermarkText = Nimdone.ToString(); 
            txtWSabos.WatermarkText = Sabos.ToString(); 
            lblVDone.Text= Done.ToString();
            lblVNimdone.Text= Nimdone.ToString();
            lblVSabos.Text = Sabos.ToString();
            lblInNo.Text = NoDone;
            lblTedad.Text = TShali.ToString();
            lblDate.Text = DateFer.ToString();
            GetNoMahsol();

            Display();

        }
        private void dgvAnbar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            txtWSabos.Text = "";
            txtWNimdone.Text = "";
            txtWDone.Text = "";
            Id = -1;
            dgvAnbar.Rows[e.RowIndex].Selected = true;
            try
            {
                Id = (int)dgvAnbar.Rows[e.RowIndex].Cells["AnbarID"].Value;
                EditDone = (int)dgvAnbar.Rows[e.RowIndex].Cells["wDone"].Value;
                EditNDone = (int)dgvAnbar.Rows[e.RowIndex].Cells["WNDone"].Value;
                EditSabos = (int)dgvAnbar.Rows[e.RowIndex].Cells["WSabos"].Value;
                txtWDone.Text = ((int)dgvAnbar.Rows[e.RowIndex].Cells["wDone"].Value).ToString();
                txtWSabos.Text = ((int)dgvAnbar.Rows[e.RowIndex].Cells["WSabos"].Value).ToString();
                txtWNimdone.Text = ((int)dgvAnbar.Rows[e.RowIndex].Cells["WNDone"].Value).ToString();
                RefAnbarID = (int)dgvAnbar.Rows[e.RowIndex].Cells["AnbarID"].Value;
                txtCostDis.Text= (dgvAnbar.Rows[e.RowIndex].Cells["Tozihat"].Value).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید");
            }
        }
        private void btnMaliPrint_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtable = GetNoMahsol();
            int noDone = (int)(dtable.Rows[0][0]);


            double WSabos = 0; double FeeSabos = 0;
            double WNimdone = 0; double FeeNimdone = 0;
            double WDone = 0; double FeeDone = 0;
            try
            {              
                if (txtWNimdone.Text != "")
                {
                    WNimdone = Convert.ToDouble(txtWNimdone.Text.Replace(",", ""));
                }
               
                if (txtWDone.Text != "")
                {
                    WDone = Convert.ToDouble(txtWDone.Text.Replace(",", ""));
                }
                if (txtWSabos.Text != "")
                {
                    WSabos = Convert.ToDouble(txtWSabos.Text.Replace(",", ""));
                }
            }
            catch { }
            //DataTable no = GetNoMahsol();
            string cmdText = " INSERT into[tblListAnbar] (OutputID,No,WDone,WNDone,WSabos,CstmrID,Outdate,NahveKhoroj,Tozihat)values" +
                    "(" + ProcessID + ",N'" +NoDone+ "'," + WDone + "," + WNimdone + "," + WSabos + "," + CstmrID + ",'" + txtDate.Text + "',11,'"+txtCostDis.Text+"')";
            trnsction.Execute_TRANSACTION(cmdText);
            cmdText = "";
            int anbarID = Convert.ToInt32(GetAnbarID());
            /////////////////////////////////////////////////////////////////////////////////////////////////
            //Done 
            //if (txtWDone.Text != "" && ConvertToNum(txtWDone.Text) > 0)
            //{
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariDone] (VaznBes,VaznBed,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz,AnbarID)values" +
                "(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                ",0," + ProcessID + ",11," + noDone + "," + FeeDone + ","+anbarID+")";
            //}

            //Nimdone
            //if (txtWNimdone.Text != "" && ConvertToNum(txtWNimdone.Text) > 0)
            //{
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariNDone] (VaznBes,VaznBed,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz,AnbarID)values" +
                "(" + WNimdone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",11," + noDone + "," + FeeNimdone + "," + anbarID + ")";
            //}

            //SabosNarm
            //if (txtWSabos.Text != "" && ConvertToNum(txtWSabos.Text) > 0)
            //{
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolMoshtariSabosNarm] (VaznBes,VaznBed,MoshtariID,Date,RefProcessID,RefNoGardesh,NoNDone,FeeRooz,AnbarID)values" +
                "(" + WSabos + ",0," + CstmrID + ",'" + txtDate.Text + "'," + ProcessID + ",11,0," + FeeSabos + ","+ anbarID + ")";
            //}

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


            double WSabos = 0;
            double WNimdone = 0;
            double WDone = 0;

            try
            {
                if (txtWSabos.Text != "")
                {

                    WSabos = Convert.ToDouble(txtWSabos.Text.Replace(",", ""));
                }
                if (txtWNimdone.Text != "")
                {
                    WNimdone = Convert.ToDouble(txtWNimdone.Text.Replace(",", ""));
                }
                if (txtWDone.Text != "")
                {
                    WDone = Convert.ToDouble(txtWDone.Text.Replace(",", ""));
                }

            }
            catch { }
            string cmdText = "UPDATE [tblListAnbar] Set [WDone]=N'" + WDone + "',[WNDone]=N'" + WNimdone + "',[WSabos]=N'" + WSabos + "' ,[Tozihat]=N'" + txtCostDis.Text + "' ,[Outdate]=N'" + txtDate.Text + "' where AnbarID=" + RefAnbarID;
            //if (txtWDone.Text != "" && ConvertToNum(txtWDone.Text) > 0)
            //{
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariDone] Set [VaznBes]=N'" + WDone + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + "and [RefNoGardesh] =11 and AnbarID=" + RefAnbarID;
            //}

            //Nimdone/////////////////////////////////////////////////////////////////////////////////////////////////
            //if (txtWNimdone.Text != "" && ConvertToNum(txtWNimdone.Text) > 0)
            //{
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariNDone] Set [VaznBes]=N'" + WNimdone + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + "and  [RefNoGardesh] =11 and AnbarID=" + RefAnbarID;
            //}
            //Sabos/////////////////////////////////////////////////////////////////////////////////////////////////
            //if (txtWSabos.Text != "" && ConvertToNum(txtWSabos.Text) > 0)
            //{
                //Moshtari
                cmdText += " UPDATE [tblAnbarMahsolMoshtariSabosNarm] Set [VaznBes]=N'" + WSabos + "'," +
                    "[Date]=N'" + txtDate.Text + "' where RefProcessID=" + ProcessID + " and [RefNoGardesh] =11 and AnbarID=" + RefAnbarID;
            //}

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

        private void ftmveiwAnbar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cmdText = "";
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {

                    try
                    {
                        cmdText = "delete from [tblListAnbar] where AnbarID=" + Id;
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        cmdText += " delete from [tblAnbarMahsolMoshtariDone] where AnbarID=" + RefAnbarID;
                        cmdText += " delete from [tblAnbarMahsolMoshtariNDone] where AnbarID=" + RefAnbarID;
                        cmdText += " delete from [tblAnbarMahsolMoshtariSabosNarm] where AnbarID=" + RefAnbarID;
                        /////////////////////////////////////////////////////////////////////////////////////////////////


                        if (trnsction.Execute_TRANSACTION(cmdText))
                        {
                            MessageBox.Show("حذف اطلاعات انجام شد.");
                            txtCostDis.Text = "";
                            Display();
                            txtWSabos.Text = "";
                            txtWNimdone.Text = "";
                            txtWDone.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                else { MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید"); }
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtCostDis.Text = "";
            txtWDone.Text = "";
            txtWNimdone.Text = "";
            txtWSabos.Text = "";
        }
    }
}
