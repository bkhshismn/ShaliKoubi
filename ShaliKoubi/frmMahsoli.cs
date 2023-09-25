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
    public partial class frmMahsoli : Form
    {
        public frmMahsoli()
        {
            InitializeComponent();
        }
        public int CustmID { get; set; }
        public string CstmrName { get; set; }
        public string CstmrFam { get; set; }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int Id = -1;
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        void DisplayMahsol()
        {
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from [PayMahsol] where CstmrID=" + CustmID;
                adp.Fill(ds, "PayMahsol");
                dgvPMahsol.DataSource = ds;
                dgvPMahsol.DataMember = "PayMahsol";
                dgvPMahsol.Columns[0].HeaderText = "کد";
                dgvPMahsol.Columns[0].Visible = false;
                dgvPMahsol.Columns[1].Width = 50;
                dgvPMahsol.Columns[1].HeaderText = "کد مشتری";

                dgvPMahsol.Columns[2].HeaderText = "وزن نیمدونه";
                dgvPMahsol.Columns[3].HeaderText = "فی نیمدونه";
                dgvPMahsol.Columns[4].HeaderText = "نوع نیمدونه";

                dgvPMahsol.Columns[5].HeaderText = "وزن سبوس یک کوب";
                dgvPMahsol.Columns[6].HeaderText = "فی سبوس یک کوب";
                

                dgvPMahsol.Columns[7].HeaderText = "وزن دونه";
                dgvPMahsol.Columns[8].HeaderText = "فی دونه";
                dgvPMahsol.Columns[9].HeaderText = "نوع دونه";
                dgvPMahsol.Columns[13].Width = 120;
                dgvPMahsol.Columns[11].Visible = false;
                dgvPMahsol.Columns[13].Visible = false;
                dgvPMahsol.Columns[14].Visible = false;
                dgvPMahsol.Columns[10].HeaderText = "تاریخ";
                dgvPMahsol.Columns[12].HeaderText = "توضیحات";
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }
        /// <summary>
        /// Pardakht dastmozd karkhane be sorate Khadir Mahsol
        /// </summary>
        public void PayMahsol()
        {
            int done=0;
            int nimdone=0;
            int sabos=0;

            int wDone = 0;
            int fDone = 0;
            int wNDone = 0;
            int fNDone = 0;
            int wSabos = 0;
            int fSabos = 0;
            if (txtWNimdone.Text != "" && txtFeeNimdone.Text != "")
            {
                nimdone = (Convert.ToInt32(txtWNimdone.Text.Replace(",", ""))) * (Convert.ToInt32(txtFeeNimdone.Text.Replace(",", "")));
                wNDone = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                fNDone = Convert.ToInt32(txtFeeNimdone.Text.Replace(",", ""));
            }
            if (txtWSabos.Text != "" && txtFeeSabos.Text != "")
            {
                sabos = Convert.ToInt32(txtWSabos.Text.Replace(",", "")) * Convert.ToInt32(txtFeeSabos.Text.Replace(",", ""));
                 wSabos = Convert.ToInt32(txtWSabos.Text.Replace(",", ""));
                 fSabos = Convert.ToInt32(txtFeeSabos.Text.Replace(",", ""));
            }
            if (txtWDone.Text != "" && txtFeeDone.Text != "")
            {
                done = Convert.ToInt32(txtWDone.Text.Replace(",", "")) * Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));
                wDone = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                fDone = Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));
            }
            int jamkol = done + nimdone + sabos;
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [PayMahsol] (CstmrID,WNimdone,FeeNimDone,NoNDone,WSabos,FeeSabos,WDone,FeeDone,NoDone,MPayDate,chkMahsol,MahsolDiscription,JamKol,Takhfif)values(@CstmrID,@WNimdone,@FeeNimDone,@NoNDone,@WSabos,@FeeSabos,@WDone,@FeeDone,@NoDone,@MPayDate,@chkMahsol,@Discription,@JamKol,@Takhfif)";
                cmd.Parameters.AddWithValue("@CstmrID", CustmID);
                cmd.Parameters.AddWithValue("@WNimdone", wNDone);
                cmd.Parameters.AddWithValue("@FeeNimdone",fNDone);
                cmd.Parameters.AddWithValue("@NoNDone", cmbBerenjNo.Text);
                cmd.Parameters.AddWithValue("@WSabos", wSabos);
                cmd.Parameters.AddWithValue("@FeeSabos", fSabos);
                cmd.Parameters.AddWithValue("@WDone", wDone);
                cmd.Parameters.AddWithValue("@FeeDone", fDone);
                cmd.Parameters.AddWithValue("@NoDone", cmbBerenjNo1.Text);
                cmd.Parameters.AddWithValue("@MPayDate", txtPayDate2.Text);
                cmd.Parameters.AddWithValue("@chkMahsol", 1);
                cmd.Parameters.AddWithValue("@Discription", txtPayMahsolDiscription.Text);
                cmd.Parameters.AddWithValue("@JamKol", jamkol);
                cmd.Parameters.AddWithValue("@Takhfif", txtTakhfif.Text.Replace(",", ""));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lnNimdone.Visible = false;
                lnSabos.Visible = false;
                lnDone.Visible = false;
                MessageBox.Show("ثبت پرداخت محصول با موفقیت انجام شد");
                DisplayMahsol();
                txtWNimdone.Text = "";
                txtFeeNimdone.Text = "";

                txtWSabos.Text = "";
                txtFeeSabos.Text = "";

                txtWDone.Text = "";
                txtFeeDone.Text = "";
                txtTakhfif.Text = "";

                txtPayMahsolDiscription.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در ثبت پرداخت با محصول وجود دارد");
            }
        }
        private void buttonX7_Click(object sender, EventArgs e)
        {
            txtWNimdone.Text = "";
            txtFeeNimdone.Text = "";

            txtWSabos.Text = "";
            txtFeeSabos.Text = "";

            txtWDone.Text = "";
            txtFeeDone.Text = "";
            txtTakhfif.Text = "";
            txtPayMahsolDiscription.Text = "";
        }

        private void frmMahsoli_Load(object sender, EventArgs e)
        {
            mt.DisplayCombo(cmbBerenjNo);
            mt.DisplayCombo(cmbBerenjNo1);
            txtPayDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            lnNimdone.Visible = false;
            lnSabos.Visible = false;
            lnDone.Visible = false;
            lblID.Text = CustmID.ToString();
            lblName.Text = CstmrName.ToString();
            lblFam.Text = CstmrFam.ToString();
            DisplayMahsol();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtWNimdone.Text=="" && txtWSabos.Text == "" && txtWDone.Text == "" )
            {
                lnNimdone.Visible = true;
                lnSabos.Visible = true;
                lnDone.Visible = true;
                MessageBox.Show("لطفا فیلد های مورد نظر را پر کتید");
                return;
            }
            else
            {
                if (txtWNimdone.Text != "" && txtFeeNimdone.Text =="")
                {
                    MessageBox.Show("لطفا فیلد وزن نیمدونه را پر کتید");
                    lnNimdone.Visible = true;
                    return;
                }
                if (txtWSabos.Text != "" && txtFeeSabos.Text == "")
                {
                    MessageBox.Show("لطفا فیلد وزن سبوس را پر کتید");
                    lnSabos.Visible = true;
                    return;
                }
                if (txtWDone.Text != "" && txtFeeDone.Text == "")
                {
                    MessageBox.Show("لطفا فیلد وزن دونه را پر کتید");
                    lnDone.Visible = true;
                    return;
                }
                PayMahsol();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int done = 0;
            int nimdone = 0;
            int sabos = 0;

            int wDone = 0;
            int fDone = 0;
            int wNDone = 0;
            int fNDone = 0;
            int wSabos = 0;
            int fSabos = 0;
            int takhfif = 0;
            //if (txtWNimdone.Text != "" && txtFeeNimdone.Text != "")
            //{
            nimdone = (Convert.ToInt32(txtWNimdone.Text.Replace(",", ""))) * (Convert.ToInt32(txtFeeNimdone.Text.Replace(",", "")));
                wNDone = Convert.ToInt32(txtWNimdone.Text.Replace(",", ""));
                fNDone = Convert.ToInt32(txtFeeNimdone.Text.Replace(",", ""));
            //}
            //if (txtWSabos.Text != "" && txtFeeSabos.Text != "")
            //{
            sabos = Convert.ToInt32(txtWSabos.Text.Replace(",", "")) * Convert.ToInt32(txtFeeSabos.Text.Replace(",", ""));
            wSabos = Convert.ToInt32(txtWSabos.Text.Replace(",", ""));
                fSabos = Convert.ToInt32(txtFeeSabos.Text.Replace(",", ""));
            //}
            //if (txtWDone.Text != "" && txtFeeDone.Text != "")
            //{
            done = Convert.ToInt32(txtWDone.Text.Replace(",", "")) * Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));
            wDone = Convert.ToInt32(txtWDone.Text.Replace(",", ""));
                fDone = Convert.ToInt32(txtFeeDone.Text.Replace(",", ""));

            takhfif = Convert.ToInt32(txtTakhfif.Text.Replace(",", ""));

            //}
            int jamkol = done + nimdone + sabos;
            jamkol = jamkol - takhfif;
            if (Id != -1)
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Update [PayMahsol] Set WNimdone='" + wNDone + "',FeeNimDone ='" +fNDone + "',NoNDone=N'" + cmbBerenjNo.Text + "',WSabos ='" + wSabos + "',FeeSabos='" + fSabos + "',WDone='" + wDone + "',FeeDone='" + fDone + "',NoDone=N'" + cmbBerenjNo1.Text + "',MPayDate='" + txtPayDate2.Text + "',MahsolDiscription='" + txtPayMahsolDiscription.Text + "',Takhfif='" + txtTakhfif.Text.Replace(",", "") + "',JamKol='" + jamkol + "' where MahsolID=" + Id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    txtWNimdone.Text = "";
                    txtFeeNimdone.Text = "";

                    txtWSabos.Text = "";
                    txtFeeSabos.Text = "";

                    txtWDone.Text = "";
                    txtFeeDone.Text = "";

                    txtTakhfif.Text = "";
                    txtPayMahsolDiscription.Text = "";
                    DisplayMahsol();
                }
                catch (Exception)
                {

                    MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
                }
            }
            else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
        }
       
        private void dgvPMahsol_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id = (int)dgvPMahsol.Rows[e.RowIndex].Cells[0].Value;
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from PayMahsol where MahsolID=" + Id;
                con.Open();
                adp.Fill(dt);

                this.txtWNimdone.Text = dt.Rows[0][2].ToString();
                this.txtFeeNimdone.Text = dt.Rows[0][3].ToString();
                this.cmbBerenjNo.Text = dt.Rows[0][4].ToString();

                this.txtWSabos.Text = dt.Rows[0][5].ToString();
                this.txtFeeSabos.Text = dt.Rows[0][6].ToString();

                this.txtWDone.Text = dt.Rows[0][7].ToString();
                this.txtFeeDone.Text = dt.Rows[0][8].ToString();
                this.cmbBerenjNo1.Text = dt.Rows[0][9].ToString();

                this.txtTakhfif.Text = dt.Rows[0][14].ToString();
                this.txtPayMahsolDiscription.Text = dt.Rows[0][12].ToString();

                con.Close();
                //DisplayMahsol();
            }
            catch (Exception)
            {

                
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Id != -1)
                {
                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from [PayMahsol] where MahsolID=" + Id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("حذف اطلاعات انجام شد.");
                        DisplayMahsol();
                        txtWNimdone.Text = "";
                        txtFeeNimdone.Text = "";

                        txtWSabos.Text = "";
                        txtFeeSabos.Text = "";

                        txtWDone.Text = "";
                        txtFeeDone.Text = "";
                        txtTakhfif.Text = "";

                        txtPayMahsolDiscription.Text = "";
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("خطایی در حذف اطلاعات رخ داده است.");
                    }
                }
                else { MessageBox.Show("لطفا روی رکورد سال مورد نظر کلیک کنید"); }
            }
                
        }

        private void txtWNimdone_TextChanged(object sender, EventArgs e)
        {
            if (txtWNimdone.Text != string.Empty)
            {
                txtWNimdone.Text = string.Format("{0:N0}", double.Parse(txtWNimdone.Text.Replace(",", "")));
                txtWNimdone.Select(txtWNimdone.TextLength, 0);
            }
        }

        private void txtFeeNimdone_TextChanged(object sender, EventArgs e)
        {
            if (txtFeeNimdone.Text != string.Empty)
            {
                txtFeeNimdone.Text = string.Format("{0:N0}", double.Parse(txtFeeNimdone.Text.Replace(",", "")));
                txtFeeNimdone.Select(txtFeeNimdone.TextLength, 0);
            }
        }

        private void txtWSabos_TextChanged(object sender, EventArgs e)
        {
            if (txtWSabos.Text != string.Empty)
            {
                txtWSabos.Text = string.Format("{0:N0}", double.Parse(txtWSabos.Text.Replace(",", "")));
                txtWSabos.Select(txtWSabos.TextLength, 0);
            }
        }

        private void txtFeeSabos_TextChanged(object sender, EventArgs e)
        {
            if (txtFeeSabos.Text != string.Empty)
            {
                txtFeeSabos.Text = string.Format("{0:N0}", double.Parse(txtFeeSabos.Text.Replace(",", "")));
                txtFeeSabos.Select(txtFeeSabos.TextLength, 0);
            }
        }

        private void txtWDone_TextChanged(object sender, EventArgs e)
        {
            if (txtWDone.Text != string.Empty)
            {
                txtWDone.Text = string.Format("{0:N0}", double.Parse(txtWDone.Text.Replace(",", "")));
                txtWDone.Select(txtWDone.TextLength, 0);
            }
        }

        private void txtFeeDone_TextChanged(object sender, EventArgs e)
        {
            if (txtFeeDone.Text != string.Empty)
            {
                txtFeeDone.Text = string.Format("{0:N0}", double.Parse(txtFeeDone.Text.Replace(",", "")));
                txtFeeDone.Select(txtFeeDone.TextLength, 0);
            }
        }

        private void txtTakhfif_TextChanged(object sender, EventArgs e)
        {
            if (txtTakhfif.Text != string.Empty)
            {
                txtTakhfif.Text = string.Format("{0:N0}", double.Parse(txtTakhfif.Text.Replace(",", "")));
                txtTakhfif.Select(txtTakhfif.TextLength, 0);
            }
        }

        private void dgvPMahsol_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 3 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 5 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 6 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 7 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 8 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 13 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
            if (e.ColumnIndex == 14 && e.RowIndex != this.dgvPMahsol.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }

        }
    }
}
