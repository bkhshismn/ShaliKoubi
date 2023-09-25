﻿using System;
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
    public partial class frmKharidDone : Form
    {
        public frmKharidDone()
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
        int NoDone = 0;
        double WDone = 0; double FeeDone = 0;double Majmo = 0;
        int Id = -1;
        DataTable GetNoMahsol()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select BNoID from tblBNo where No=N'" + cmbNoShali.Text + "'";
            dt = tc.ExecuteReader();
            return dt;
        }
        DataTable GetAnbarDone()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "SELECT  sum([VaznBed]) as Kharid,sum([VaznBes]) as Forosh, (sum([VaznBed])-sum([VaznBes]))  as Mande FROM [DBShalikoubi].[dbo].[tblAnbarMahsolKarkhaneDone] ";
            dt = tc.ExecuteReader();
            return dt;
        }
        DataTable GetAnbarDone(int NoDone)
        {
            DataTable dt = new DataTable();
            tc.CommandText = "SELECT  sum([VaznBed]) as Kharid,sum([VaznBes]) as Forosh, (sum([VaznBed])-sum([VaznBes])) as Mande FROM [DBShalikoubi].[dbo].[tblAnbarMahsolKarkhaneDone]  where NoDone="+NoDone;
            dt = tc.ExecuteReader();
            return dt;
        }
        string GetNoDoneComboBox(int id)
        {
            string dt = "";
            tc.CommandText = "select No from tblBNo where BNoID=N'" + id + "'";
            dt = tc.ScalerExecute();
            return dt;
        }
        string GetKharidID()
        {
            string AnbarID = "";
            tc.CommandText = "select top(1) [DoneID] from tblKDone where [DoneID] >=1 order by [DoneID] desc";
            AnbarID = tc.ScalerExecute();
            return AnbarID;
        }
        void Display()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select b.No as NoDone ,a.*  from tblBNo  as b inner join  [tblKDone] as a on a.No=b.BNoID where a.CstmrID=" + CstmrID;
            dt = tc.ExecuteReader();
            dgvShali.DataSource = dt;
            dgvShali.Columns["DoneID"].Visible = false;
            dgvShali.Columns["CstmrID"].Visible = false;
            dgvShali.Columns["No"].Visible = false;
            dgvShali.Columns["WDone"].HeaderText = "وزن برنج ";
            dgvShali.Columns["FDone"].HeaderText = "فی برنج ";
            dgvShali.Columns["Majmo"].HeaderText = "مبلغ";
            dgvShali.Columns["Discription"].HeaderText = "توضیحات ";
            dgvShali.Columns["Date"].HeaderText = "تاریخ ";
            dgvShali.Columns["Froshande"].HeaderText = "فروشنده ";
            dgvShali.Columns["NoDone"].HeaderText = "نوع برنج";


        }
        void SetLabel()
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
        private void frmKharidDone_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            mt.DisplayCombo(cmbNoShali);
            SetLabel();
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
        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CstmrID = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                //labelX4.Text = indx.ToString();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CstmrID == -1)
            {
                MessageBox.Show("لطفا ابتدا  نام مشتری را جستجو کنید");
            }
            else if (NoDone == 0)
            {
                MessageBox.Show("لطفا نوع برنج را انتخاب کنید");
            }
            else
            {
                string cmdText = "insert into  [tblKDone] ([WDone],[FDone],[CstmrID],[Froshande],[Majmo],[No],[Discription],[Date])values( N'" + WDone + "'" +
                    ",N'" + FeeDone + "'" +
                    ",N'" + CstmrID + "'" +
                    ",N'" + txtFoShali.Text + "'" +
                    ",N'" + Majmo + "'" +
                    ",N'" + NoDone + "'" +
                    ",N'" + txTozihat.Text + "'" +
                    ",N'" + txtDate.Text + "')";
                trnsction.Execute_TRANSACTION(cmdText);
                cmdText = "";
                int KharidID = Convert.ToInt32(GetKharidID());

                //Karkhane///////////////////////////////////////////////////////////////////////////////////////////////
                cmdText += " INSERT into[tblAnbarMahsolKarkhaneDone] (VaznBed,VaznBes,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz,[KharidID])values" +
                "(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                ",0,0,44," + NoDone + "," + FeeDone + ","+KharidID+")";
                //Moshtari///////////////////////////////////////////////////////////////////////////////////////////////
                //cmdText += " INSERT into[tblAnbarMahsolMoshtariDone] (VaznBes,VaznBed,MoshtariID,Date,TedadKiseBes,TedadKiseBed,RefProcessID,RefNoGardesh,NoDone,FeeRooz,[KharidID])values" +
                //"(" + WDone + ",0," + CstmrID + ",'" + txtDate.Text + "'," + 0 +
                //",0,0,44," + NoDone + "," + FeeDone + "," + KharidID + ")";
                //GhesmatMali///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                //Moshtari
                cmdText += " insert into [tblHesabMoshtari]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
               "(" + Majmo + ",0," + CstmrID + ",44," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";
                //Karkhane
                cmdText += " insert into [tblHesabKarkhane]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                    "(0," + Majmo + "," + CstmrID + ",44," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";


                 if (trnsction.Execute_TRANSACTION(cmdText))
                {
                    Display();
                    MessageBox.Show("ثبت با موفقیت انجام شد");

                }
                else
                {
                    MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                }

            }
        }
        private void cmbNoShali_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtable = GetNoMahsol();
            NoDone = (int)(dtable.Rows[0][0]);
            try
            {
                lblForosh.Text = "";
                lblKol.Text = "";
                lblMojod.Text = "";
                DataTable DtDone = GetAnbarDone(NoDone);
                lblForosh.Text = ((double)DtDone.Rows[0]["Forosh"]).ToString("N0");
                lblKol.Text = ((double)DtDone.Rows[0]["Kharid"]).ToString("N0");
                lblMojod.Text = ((double)DtDone.Rows[0]["Mande"]).ToString("N0");
            }
            catch (Exception)
            {
            }          
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
        private void dgvShali_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWShali.Text = "";
            txtFoShali.Text = "";
            txtFShali.Text = "";
            Id = -1;
            dgvShali.Rows[e.RowIndex].Selected = true;
            try
            {
                Id = (int)dgvShali.Rows[e.RowIndex].Cells["DoneID"].Value;
                txtWShali.Text = ((double)dgvShali.Rows[e.RowIndex].Cells["WDone"].Value).ToString();
                txtFShali.Text = ((int)dgvShali.Rows[e.RowIndex].Cells["FDone"].Value).ToString();
                txtFoShali.Text = (dgvShali.Rows[e.RowIndex].Cells["Froshande"].Value).ToString();
                txTozihat.Text = (dgvShali.Rows[e.RowIndex].Cells["Discription"].Value).ToString();
                cmbNoShali.Text = GetNoDoneComboBox((int)dgvShali.Rows[e.RowIndex].Cells["No"].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("لطفا روی رکورد مورد نظر کلیک کنید");
            }
        }
        private void cmbNoShali_TextChanged(object sender, EventArgs e)
        {
            DataTable dtable = GetNoMahsol();
            NoDone = (int)(dtable.Rows[0][0]);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string cmdText = "UPDATE [tblKDone] Set [WDone]=N'" + WDone + "', [FDone]=N'" + FeeDone + "', [Froshande]=N'" + txtFoShali.Text + "', [Majmo]=N'" + Majmo + "'," +
                "[Date]=N'" + txtDate.Text + "',[No]=N'" + NoDone + "',[Discription]=N'" + txTozihat.Text + "' where DoneID="+Id;
            //Done/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane
            cmdText += " UPDATE [tblAnbarMahsolKarkhaneDone] Set [VaznBed]=N'" + WDone + "'," +
               "[FeeRooz]=N'" + FeeDone + "'," +
               "[Date]=N'" + txtDate.Text + "' where [KharidID]=" + Id;
            //Mali/////////////////////////////////////////////////////////////////////////////////////////////////
            cmdText += " UPDATE [tblHesabMoshtari] Set [bes]=N'" + Majmo + "' where ReferID=" + Id + " and [RefNoGardesh] =44";
            cmdText += " UPDATE [tblHesabKarkhane] Set [bed]=N'" +Majmo + "' where ReferID=" + Id + " and [RefNoGardesh] =44";
            if(trnsction.Execute_TRANSACTION(cmdText))
            {
                Display();
                MessageBox.Show("ویرایش با موفقیت انجام شد");
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
                        cmdText = "delete from [tblKDone] where DoneID=" + Id;
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        cmdText += " delete from [tblAnbarMahsolKarkhaneDone] where KharidID=" + Id;
                        cmdText += " delete from [tblHesabMoshtari] where ReferID=" + Id+ "and [RefNoGardesh]=44";
                        cmdText += " delete from [tblHesabKarkhane] where ReferID=" + Id+ "and [RefNoGardesh]=44";
                        /////////////////////////////////////////////////////////////////////////////////////////////////

                        if (trnsction.Execute_TRANSACTION(cmdText))
                        {
                            MessageBox.Show("حذف اطلاعات انجام شد.");
                            txtFoShali.Text = "";
                            Display();
                            txtFShali.Text = "";
                            txtWShali.Text = "";
                            txTozihat.Text = "";
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
    }
}
