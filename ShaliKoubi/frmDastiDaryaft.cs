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
    public partial class frmDastiDaryaft : Form
    {
        public frmDastiDaryaft()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        int CstmrID = -1;
        int HesabId = -1;
        long bed = 0;
        method mt = new method();
        clsNewEditing ne = new clsNewEditing();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        string GetKharidID()
        {
            string AnbarID = "";
            tc.CommandText = "select top(1) [GharzID] from tblGharz where [GharzID] >=1 order by [GharzID] desc";
            AnbarID = tc.ScalerExecute();
            return AnbarID;
        }
        double GetBedehkari(int CstmrID)
        {
            double bed = 0;
            tc.CommandText = "select (sum(bed)-sum(bes)) as bed from tblHesabMoshtari where MoshtariID=" + CstmrID;
            bed = Convert.ToDouble(tc.ScalerExecute());
            return bed;
        }
        void Display()
        {
            DataTable dt = new DataTable();
            tc.CommandText = "select * from [tblGharz] where [MoshtariID] =N'" + CstmrID + "'";
            dt = tc.ExecuteReader();
            dgvInput.DataSource = dt;
            //**************************************************************
            dgvInput.Columns["GharzID"].Visible = false;
            dgvInput.Columns["MoshtariID"].Visible = false;
            dgvInput.Columns["Bed"].Visible = false;
            dgvInput.Columns["bes"].HeaderText = "مبلغ ";
            dgvInput.Columns["Date"].HeaderText = " تاریخ ";
            dgvInput.Columns["Tozihat"].HeaderText = " توضیحات";
            dgvInput.Columns["Tozihat"].Width = 300;
            lblBedehkar.Text = GetBedehkari(CstmrID).ToString("N0");
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where Name Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtName.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
            dgvInSearch.Visible = true;
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where DastiID Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            mt.Titr(dgvInSearch);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMablagh.Text == "")
                {
                    bed = Convert.ToInt64(txtMablagh.Text.Replace(",", ""));
                    string cmdText = "insert into tblGharz(Bes,Date,Tozihat,MoshtariID)values(" + bed + ",'" + txtDate.Text + "','" + txtTozihat.Text + "'," + CstmrID + ")";

                    trnsction.Execute_TRANSACTION(cmdText);
                    cmdText = "";
                    int KharidID = Convert.ToInt32(GetKharidID());
                    cmdText += " insert into [tblHesabMoshtari]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                      "(" + bed + ",0," + CstmrID + ",100," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";
                    //Karkhane
                    cmdText += " insert into [tblHesabKarkhane]([bes],[Bed],[MoshtariID],[RefNoGardesh],[ReferID],[Takhfif],[Date],[Tozihat],[Years],[Month])values" +
                        "(0," + bed + "," + CstmrID + ",100," + KharidID + ",0,'" + txtDate.Text + "',0,0,0)";

                    if (trnsction.Execute_TRANSACTION(cmdText))
                    {
                        txtMablagh.Text = "";
                        Display();
                        txtTozihat.Text = "";
                        MessageBox.Show("ثبت با موفقیت انجام شد");

                    }
                    else
                    {
                        MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                    }

                }
                else
                {
                    MessageBox.Show("لطفا فیلد مبلغ را پر کنید");
                }
            }
            catch (Exception)
            {

            }
           

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtMablagh.Text == "")
            {
                bed = Convert.ToInt64(txtMablagh.Text.Replace(",", ""));
            }
            string cmdText = "UPDATE [tblGharz] Set [Bes]=N'" + bed+ "',[Date]=N'" + txtDate.Text + "',[Tozihat]=N'" + txtTozihat.Text + "' where GharzID=" + HesabId;
            //Done/////////////////////////////////////////////////////////////////////////////////////////////////
            //Karkhane

            //Mali/////////////////////////////////////////////////////////////////////////////////////////////////
            cmdText += " UPDATE [tblHesabMoshtari] Set [bes]=N'" + bed + "' where ReferID=" + HesabId + " and [RefNoGardesh] =10";
            cmdText += " UPDATE [tblHesabKarkhane] Set [bed]=N'" + bed + "' where ReferID=" + HesabId + " and [RefNoGardesh] =10";
            if (trnsction.Execute_TRANSACTION(cmdText))
            {
                txtMablagh.Text = "";
                Display();
                txtTozihat.Text = "";
                HesabId = -1;
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
                if (HesabId != -1)
                {

                    try
                    {
                        cmdText = "delete from [tblGharz] where GharzID=" + HesabId;
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        cmdText += " delete from [tblHesabMoshtari] where ReferID=" + HesabId + "and [RefNoGardesh]=100";
                        cmdText += " delete from [tblHesabKarkhane] where ReferID=" + HesabId + "and [RefNoGardesh]=100";
                        /////////////////////////////////////////////////////////////////////////////////////////////////

                        if (trnsction.Execute_TRANSACTION(cmdText))
                        {
                            MessageBox.Show("حذف اطلاعات انجام شد.");
                            txtMablagh.Text = "";
                            Display();
                            HesabId = -1;
                            txtTozihat.Text = "";
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

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CstmrID = (int)dgvInSearch.Rows[e.RowIndex].Cells["id"].Value;
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
                txtName.Text = "";
                txtID.Text = "";
                txtName.WatermarkText = dt.Rows[0]["Name"].ToString();
                con.Close();
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                txtID.WatermarkText = dt.Rows[0]["DastiID"].ToString();
                dgvInSearch.Visible = false;
                txtMablagh.Text = "";
                txtTozihat.Text = "";
                Display();


            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
        }

        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HesabId = (int)dgvInput.Rows[e.RowIndex].Cells["GharzID"].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [tblGharz] where GharzID =" + HesabId;
                con.Open();
                adp.Fill(dt);
                this.txtMablagh.Text =((int) dt.Rows[0]["Bes"]).ToString("N0");
                this.txtTozihat.Text = dt.Rows[0]["Tozihat"].ToString();
                this.txtDate.Text = dt.Rows[0]["Date"].ToString();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
            }
        }

        private void frmDastiDaryaft_Load(object sender, EventArgs e)
        {
            dgvInSearch.Visible = false;
            txtDate.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");

        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMablagh.Text != string.Empty)
                {
                    txtMablagh.Text = string.Format("{0:N0}", double.Parse(txtMablagh.Text.Replace(",", "")));
                    txtMablagh.Select(txtMablagh.TextLength, 0);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در درج اطلاعات رخ داده است.");
            }
        }
    }
}
