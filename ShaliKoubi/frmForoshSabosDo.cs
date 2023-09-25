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
    public partial class frmForoshSabosDo : Form
    {
        public frmForoshSabosDo()
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
        double WDone = 0; double FeeDone = 0; double Majmo = 0;
        int Id = -1;
        void Display()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select *  from   [tblForoshSabosDo] as a  where a.CstmrID=" + CstmrID;
            dt = tc.ExecuteReader();
            dgvShali.DataSource = dt;
            dgvShali.Columns["SabosID"].Visible = false;
            dgvShali.Columns["CstmrID"].Visible = false;
            dgvShali.Columns["WSNarm"].HeaderText = "وزن";
            dgvShali.Columns["FSNarm"].HeaderText = "فی  ";
            dgvShali.Columns["Majmo"].HeaderText = "مبلغ";
            dgvShali.Columns["Discription"].HeaderText = "توضیحات ";
            dgvShali.Columns["Date"].HeaderText = "تاریخ ";
            dgvShali.Columns["Froshande"].HeaderText = "خریدار ";
        }
        DataTable GetAnbarDone()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "SELECT  sum([VaznBed]) as Kharid,sum([VaznBes]) as Forosh, (sum([VaznBed])-sum([VaznBes]))  as Mande FROM [tblAnbarMahsolKarkhaneSabosDo] ";
            dt = tc.ExecuteReader();
            return dt;
        }
        void SetLabels()
        {
            try
            {
                DataTable DtDone = GetAnbarDone();
                lblForosh.Text = ((double)DtDone.Rows[0]["Forosh"]).ToString("N0");
                lblKol.Text = ((double)DtDone.Rows[0]["Kharid"]).ToString("N0");
                lblMojod.Text = ((double)DtDone.Rows[0]["Mande"]).ToString("N0");
            }
            catch (Exception)
            {

            }

        }
        string GetKharidID()
        {
            string AnbarID = "";
            tc.CommandText = "select top(1) [SabosID] from tblForoshSabosDo where [SabosID] >=1 order by [SabosID] desc";
            AnbarID = tc.ScalerExecute();
            return AnbarID;
        }
        private void frmForoshSabosDo_Load(object sender, EventArgs e)
        {
            try
            {
                dgvInSearch.Visible = false;
                txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
                SetLabels();
            }
            catch (Exception)
            {

            }
        }
        private void txtInNameSearch_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtInNameSearch.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }
        private void txtInFamSearch_TextChanged(object sender, EventArgs e)
        {
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
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where DastiID Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }
        private void txtWShali_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWShali.Text != "")
                {
                    WDone = Convert.ToDouble(txtWShali.Text.Replace(",", ""));
                    Majmo = FeeDone * WDone;
                }
                lblJam.Text = Majmo.ToString("N0");
            }
            catch (Exception)
            {

            }
        }
        private void txtFShali_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFShali.Text != "")
                {
                    FeeDone = Convert.ToDouble(txtFShali.Text.Replace(",", ""));
                    Majmo = FeeDone * WDone;
                }
                lblJam.Text = Majmo.ToString("N0");
            }
            catch (Exception)
            {
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CstmrID == -1)
            {
                MessageBox.Show("لطفا ابتدا  نام مشتری را جستجو کنید");
            }
            else
            {
                string cmdText = "insert into  [tblForoshSabosDo]([WSNarm],[FSNarm],[CstmrID],[Froshande],[Majmo],[Discription],[Date])values( N'" + WDone + "'" +
                    ",N'" + FeeDone + "'" +
                    ",N'" + CstmrID + "'" +
                    ",N'" + txtFoShali.Text + "'" +
                    ",N'" + Majmo + "'" +
                    ",N'" + txTozihat.Text + "'" +
                    ",N'" + txtDate.Text + "')";
                trnsction.Execute_TRANSACTION(cmdText);
                cmdText = "";
                int KharidID = Convert.ToInt32(GetKharidID());

                //Karkhane///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolKarkhaneSabosDo] (VaznBes,VaznBed,MoshtariID,Date,RefProcessID,RefNoGardesh,FeeRooz,[ForoshID])values" +
                "(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                ",777," + FeeDone + "," + KharidID + ")";
                //GhesmatMali///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //Moshtari
                cmdText += " insert into [tblHesabMoshtari]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
               "(" + Majmo + ",0," + CstmrID + ",777," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";
                //Karkhane
                cmdText += " insert into [tblHesabKarkhane]([Bed],[bes],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                    "(0," + Majmo + "," + CstmrID + ",777," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";

                if (trnsction.Execute_TRANSACTION(cmdText))
                {
                    Display();
                    MessageBox.Show("ثبت با موفقیت انجام شد");
                    SetLabels();
                }
                else
                {
                    MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                }

            }
        }
        private void dgvShali_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWShali.Text = "";
            txtFoShali.Text = "";
            txtFShali.Text = "";
            Id = -1;

            try
            {
                dgvShali.Rows[e.RowIndex].Selected = true;
                Id = (int)dgvShali.Rows[e.RowIndex].Cells["SabosID"].Value;
                txtWShali.Text = ((double)dgvShali.Rows[e.RowIndex].Cells["WSNarm"].Value).ToString();
                txtFShali.Text = ((int)dgvShali.Rows[e.RowIndex].Cells["FSNarm"].Value).ToString();
                txtFoShali.Text = (dgvShali.Rows[e.RowIndex].Cells["Froshande"].Value).ToString();
                txTozihat.Text = (dgvShali.Rows[e.RowIndex].Cells["Discription"].Value).ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید");
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string cmdText = "UPDATE [tblForoshSabosDo] Set [WSNarm]=N'" + WDone + "', [FSNarm]=N'" + FeeDone + "', [Froshande]=N'" + txtFoShali.Text + "', [Majmo]=N'" + Majmo + "'," +
              "[Date]=N'" + txtDate.Text + "',[Discription]=N'" + txTozihat.Text + "' where SabosID=" + Id;
            //Done/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane
            cmdText += " UPDATE [tblAnbarMahsolKarkhaneSabosDo] Set [VaznBes]=N'" + WDone + "'," +
               "[FeeRooz]=N'" + FeeDone + "'," +
               "[Date]=N'" + txtDate.Text + "' where [ForoshID]=" + Id;
            //Mali/////////////////////////////////////////////////////////////////////////////////////////////////
            cmdText += " UPDATE [tblHesabMoshtari] Set [bed]=N'" + Majmo + "' where ReferID=" + Id + " and [RefNoGardesh] =777";
            cmdText += " UPDATE [tblHesabKarkhane] Set [bes]=N'" + Majmo + "' where ReferID=" + Id + " and [RefNoGardesh] =777";
            if (trnsction.Execute_TRANSACTION(cmdText))
            {
                Display();
                MessageBox.Show("ویرایش با موفقیت انجام شد");
                SetLabels();
            }
            else
            {
                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
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
                        cmdText = "delete from [tblForoshSabosDo] where SabosID=" + Id;
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        cmdText += " delete from [tblAnbarMahsolKarkhaneSabosDo] where ForoshID=" + Id;
                        cmdText += " delete from [tblHesabMoshtari] where ReferID=" + Id + "and [RefNoGardesh]=777";
                        cmdText += " delete from [tblHesabKarkhane] where ReferID=" + Id + "and [RefNoGardesh]=777";
                        /////////////////////////////////////////////////////////////////////////////////////////////////

                        if (trnsction.Execute_TRANSACTION(cmdText))
                        {
                            MessageBox.Show("حذف اطلاعات انجام شد.");
                            txtFoShali.Text = "";
                            Display();
                            txtFShali.Text = "";
                            txtWShali.Text = "";
                            txTozihat.Text = "";
                            SetLabels();
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
                else
                {
                    MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید");

                }
            }
        }

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CstmrID = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + CstmrID;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = (dt.Rows[0]["Name"].ToString());// + " "+ dt.Rows[0][2].ToString());
                txtInNameSearch.Text = "";
                txtInFamSearch.Text = "";
                txtSID.Text = "";
                con.Close();
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                dgvInSearch.Visible = false;
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
        }
    }
}
