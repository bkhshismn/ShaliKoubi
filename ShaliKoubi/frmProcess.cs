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
    public partial class frmProcess : Form
    {
        public frmProcess()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        int CstmCode = -1;
        int InputID=-1;
        int inid = -1;
        int processID = -1;

        void TedadKiseFer1()
        {
            double[] tedad = new double[30];
            for (int i = 1; i <= 30; i++)
            {
              tedad[i-1] = mt.Fer(i);
            }
            cmbFer1.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                if (tedad[i-1] <=110)
                {
                    cmbFer1.Items.Add(i);
                }
               
            }
        }

        void TedadKiseFer2()
        {
            double[] tedad = new double[30];
            for (int i = 1; i <= 30; i++)
            {
                tedad[i - 1] = mt.Fer(i);
            }
            cmbFer2.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                if (tedad[i - 1] <= 110)
                {
                    cmbFer2.Items.Add(i);
                }

            }
        }
        void DisplayProcessView()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_InputAndProcess where CstmrID=" + CstmCode;// + "AND chk_Process !=1";
            adp.Fill(ds, "View_InputAndProcess");
            dgvInput.DataSource = ds;
            dgvInput.DataMember = "View_InputAndProcess";

            //************************************
            dgvInputList.Columns["InputID"].Visible = false;
            dgvInput.Columns["Code"].HeaderText = "کد محصول";
            dgvInput.Columns["Code"].Width = 70;

            dgvInput.Columns["Name"].HeaderText = "نام مشتری ";
            dgvInput.Columns["Name"].Width = 90;
            dgvInput.Columns["Name"].Visible = false;
            dgvInput.Columns["Family"].HeaderText = "کد ملی";
            dgvInput.Columns["Family"].Visible = false;
            dgvInput.Columns["CstmrID"].HeaderText = "کد مشتری";
            dgvInput.Columns["CstmrID"].Width = 90;
            dgvInput.Columns["CstmrID"].Visible = false;
            dgvInput.Columns["InNo"].HeaderText = "نوع شالی";
            dgvInput.Columns["InNo"].Width = 90;

            dgvInput.Columns["InTedadKise"].HeaderText = "تعداد کیسه شالی";
            dgvInput.Columns["InTedadKise"].Width = 50;

            dgvInput.Columns["InDate"].HeaderText = "تاریخ ورود به کارخانه";
            dgvInput.Columns["InDate"].Width = 90;

            dgvInput.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر(قسمت اول)";
            dgvInput.Columns["inputDate1"].Width = 120;

            dgvInput.Columns["NumberFer1"].HeaderText = "(قسمت اول)شماره فر";
            dgvInput.Columns["NumberFer1"].Width = 120;

            dgvInput.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه(قسمت اول)";
            dgvInput.Columns["TedadKiseFer1"].Width = 120;

            dgvInput.Columns["inputDate2"].HeaderText = "تاریخ ورود به فر(قسمت دوم)";
            dgvInput.Columns["inputDate1"].Width = 120;

            dgvInput.Columns["NumberFer2"].HeaderText = "شماره فر(قسمت دوم)";
            dgvInput.Columns["NumberFer2"].Width = 120;

            dgvInput.Columns["TedadKiseFer2"].HeaderText = "تعداد کیسه(قسمت دوم)";
            dgvInput.Columns["TedadKiseFer2"].Width = 120;
            dgvInput.Columns["Discription"].HeaderText = "توضیحات";
            dgvInput.Columns["chk_Process"].Visible = false; 
            dgvInput.Columns["ProcessID"].Visible = false;
            dgvInput.Columns["InputID"].Visible = false;
            dgvInput.Columns["InWeight"].Visible = false;

        }
        void DisplayCustomerAndInput()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_tblCstmrAndtblInput where CstmrID=" + CstmCode + "AND PrccChecker !=" + 1;
                adp.Fill(ds, "View_tblCstmrAndtblInput");
                dgvInputList.DataSource = ds;
                dgvInputList.DataMember = "View_tblCstmrAndtblInput";
                //************************************
                //dgvCstmr.DataSource = ds;
                //dgvCstmr.DataMember = "tblCstmr";
                dgvInputList.Columns["Code"].HeaderText = "کد محصول";
                dgvInputList.Columns["Code"].Width = 70;

                dgvInputList.Columns["Name"].HeaderText = "نام مشتری ";
                dgvInputList.Columns["Name"].Width = 90;

                dgvInputList.Columns["Family"].HeaderText = "کد ملی";

                dgvInputList.Columns["CstmrID"].HeaderText = "کد مشتری";
                dgvInputList.Columns["CstmrID"].Width = 90;

                dgvInputList.Columns["InNo"].HeaderText = "نوع شالی";
                dgvInputList.Columns["InNo"].Width = 90;

                dgvInputList.Columns["InTedadKise"].HeaderText = "تعداد شالی";
                dgvInputList.Columns["InTedadKise"].Width = 70;

                dgvInputList.Columns["InWeight"].HeaderText = "وزن محصول";
                dgvInputList.Columns["InWeight"].Width = 90;

                dgvInputList.Columns["chk"].Visible = false;
                dgvInputList.Columns["CstmrID"].Visible = false;
                dgvInputList.Columns["InPic"].Visible = false;
                dgvInputList.Columns["PrccChecker"].Visible = false;
                dgvInputList.Columns["Name"].Visible = false;
                dgvInputList.Columns["Family"].Visible = false;
                dgvInputList.Columns["PrccChecker"].Visible = false;
                dgvInputList.Columns["InDate"].HeaderText = " تاریخ ورود";
                dgvInputList.Columns["InputID"].Visible = false;
            }
            catch (Exception)
            {

                
            }
           
        }
        private void txtInNameSearch_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
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

            line3.Visible = false;
            line4.Visible = false;
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

        private void frmProcess_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
            txtDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            line2.Visible = false;
            line5.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            lblChek_TedadBerenj.Visible = false;
            line3.Visible = false;
            line4.Visible = false;
            dgvInSearch.Visible = false;
            btnCloseDgv.Visible = false;
            dgvInputList.Visible = false;
            groupPanel6.Enabled = false;

            //TedadKiseFer1();
            //TedadKiseFer2();
            

        }

        private void dgvInSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                con.Close();
                int indx = (int)dgvInSearch.Rows[e.RowIndex].Cells[0].Value;
                //labelX4.Text = indx.ToString();
                cmd.Parameters.Clear();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblCstmr where id=" + indx;
                con.Open();
                adp.Fill(dt);
                this.lblName.Text = (dt.Rows[0]["Name"].ToString()) ;// + " " + dt.Rows[0][2].ToString());
                txtInNameSearch.Text = "";
                txtInFamSearch.Text = "";
                txtSID.Text = "";

                txtInNameSearch.WatermarkText = dt.Rows[0]["Name"].ToString();
                txtInFamSearch.WatermarkText = dt.Rows[0]["Family"].ToString();

                con.Close();
                CstmCode = indx;
                lblID.Text = dt.Rows[0]["DastiID"].ToString();
                txtSID.WatermarkText = dt.Rows[0]["DastiID"].ToString();
                dgvInSearch.Visible = false;
                DisplayCustomerAndInput();
                btnCloseDgv.Visible = true;
                dgvInputList.Visible = true;
                DisplayProcessView();
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است.");
            }
        
        }

        private void btnCloseDgv_Click(object sender, EventArgs e)
        {
            dgvInputList.Visible = false;
            btnCloseDgv.Visible = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            dgvInputList.Visible = true;
            btnCloseDgv.Visible = true;
            DisplayCustomerAndInput();

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtInFamSearch.Text = "";
            txtInNameSearch.Text = "";
            dgvInSearch.Visible = false;
        }

        private void dgvInputList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvInputList.SelectedCells.Count == 1)
                {
                    con.Close();
                    int indx1 = (int)dgvInputList.Rows[e.RowIndex].Cells[0].Value;
                    //labelX4.Text = indx.ToString();
                    cmd.Parameters.Clear();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand();
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandText = "select * from View_tblCstmrAndtblInput where InputID=" + indx1;
                    con.Open();
                    adp.Fill(dt);
                    this.lblInNo.Text = dt.Rows[0]["InNo"].ToString();
                    this.lblTedad.Text = dt.Rows[0]["InTedadKise"].ToString();
                    this.lblWeight.Text = dt.Rows[0]["InWeight"].ToString();
                    this.lblDate.Text = dt.Rows[0]["InDate"].ToString();
                    txtTedad1.Text = dt.Rows[0]["InTedadKise"].ToString();
                    inid = (int)dt.Rows[0]["InputID"];

                    //if (((double)dt.Rows[0][5]) <= 110)
                    //{
                    //    txtTedad1.Text = dt.Rows[0][5].ToString();
                    //}
                    //if (((double)dt.Rows[0][5]) > 110 && ((double)dt.Rows[0][5]) <= 220)
                    //{
                    //    txtTedad1.Text = "100";
                    //    txtTedad2.Text = (((double)dt.Rows[0][5]) - 110).ToString();
                    //}
                    //if (((double)dt.Rows[0][5]) > 220)
                    //{
                    //    MessageBox.Show(".تعداد کیسه این محصول شالی از 220 عدد بیشتر است و باید تقسیم گردد");
                    //}

                    dgvInputList.Visible = false;
                    btnCloseDgv.Visible = false;
                    InputID = indx1;
                    lblCodeMahsol.Text = InputID.ToString();
                    con.Close();

                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {

                
            }
            DisplayProcessView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTedad1.Text=="" && cmbFer1.Text=="")
            {
                MessageBox.Show(".لطفا فیلد های مشخص شده را پر کنید");
                line2.Visible = true;
                line5.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
            }
            else
            {
                if (chkFer2.Checked == true)
                {
                    if ((Convert.ToDouble(txtTedad1.Text))+(Convert.ToDouble(txtTedad2.Text))!= Convert.ToDouble(lblTedad.Text))
                    {
                        MessageBox.Show(".تعداد کیسه در فیلد ها با تعداد کیسه محصول ورودی برابر نیست");
                        return;
                    }
                    else
                    {
                        if (cmbFer1.Text==cmbFer2.Text)
                        {
                            MessageBox.Show(".شماره فر (خشکن) ها باهم برابر است، لطفا اصلاح نمایید");
                            return;
                        }
                        else
                        {
                            try
                            {
                                using (var ts = new System.Transactions.TransactionScope())
                                {
                                    int x = 0;
                                    con.Close();
                                    cmd.Parameters.Clear();
                                    cmd.Connection = con;
                                    cmd.CommandText = "INSERT into [tblProcess](InputID,inputDate1,inputDate2,outputDate,NumberFer1,TedadKiseFer1,NumberFer2,TedadKiseFer2,Discription)values(@InputID,@inputDate1,@inputDate2,@outputDate,@NumberFer1,@TedadKiseFer1,@NumberFer2,@TedadKiseFer2,@Discription)";
                                    cmd.Parameters.AddWithValue("@InputID", InputID);
                                    cmd.Parameters.AddWithValue("@inputDate1", txtDate1.Text);
                                    cmd.Parameters.AddWithValue("@inputDate2", txtDate2.Text);
                                    cmd.Parameters.AddWithValue("@outputDate", "0");
                                    cmd.Parameters.AddWithValue("@NumberFer1", Convert.ToInt32(cmbFer1.Text));
                                    cmd.Parameters.AddWithValue("@TedadKiseFer1", Convert.ToDouble(txtTedad1.Text));
                                    cmd.Parameters.AddWithValue("@NumberFer2", Convert.ToInt32(cmbFer2.Text));
                                    cmd.Parameters.AddWithValue("@TedadKiseFer2", Convert.ToDouble(txtTedad2.Text));
                                    cmd.Parameters.AddWithValue("@Discription", txtDiscription.Text);
                                    //cmd.Parameters.AddWithValue("@chk_Process", "0");
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    //MessageBox.Show(InputID.ToString());
                                    ///////////////////////////////////////////////////////////////////
                                    //Edit Jadval Input
                                    int PrccChecker = 1;
                                    cmd.Parameters.Clear();
                                    cmd.Connection = con;
                                    cmd.CommandText = "Update tblInput Set PrccChecker='" + PrccChecker + "' where InputID =" + InputID;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    //////////////////////////////////////////////////////////////
                                    MessageBox.Show("ثبت با موفقیت انجام شد");
                                    DisplayProcessView();
                                    ts.Complete();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                            }
                            finally { con.Close(); }
                        }
                       
                    }
                    
                }
                else
                {
                    try
                    {
                        using (var ts = new System.Transactions.TransactionScope())
                        {
                            con.Close();
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandText = "INSERT into [tblProcess](InputID,inputDate1,inputDate2,outputDate,NumberFer1,TedadKiseFer1,NumberFer2,TedadKiseFer2,Discription)values(@InputID,@inputDate1,@inputDate2,@outputDate,@NumberFer1,@TedadKiseFer1,@NumberFer2,@TedadKiseFer2,@Discription)";
                            cmd.Parameters.AddWithValue("@InputID", InputID);
                            cmd.Parameters.AddWithValue("@inputDate1", txtDate1.Text);
                            cmd.Parameters.AddWithValue("@inputDate2", "0");
                            cmd.Parameters.AddWithValue("@outputDate", "0");
                            cmd.Parameters.AddWithValue("@NumberFer1", Convert.ToInt32(cmbFer1.Text));
                            cmd.Parameters.AddWithValue("@TedadKiseFer1", Convert.ToDouble(txtTedad1.Text));
                            cmd.Parameters.AddWithValue("@NumberFer2", 0);
                            cmd.Parameters.AddWithValue("@TedadKiseFer2", 0);
                            cmd.Parameters.AddWithValue("@Discription", txtDiscription.Text);
                            //cmd.Parameters.AddWithValue("@chk_Process", 1);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //MessageBox.Show(InputID.ToString());
                            ///////////////////////////////////////////////////////////////////
                            //Edit Jadval Input
                            int PrccChecker = 1;
                            cmd.Parameters.Clear();
                            cmd.Connection = con;
                            cmd.CommandText = "Update tblInput Set PrccChecker='" + PrccChecker + "' where InputID =" + InputID;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //////////////////////////////////////////////////////////////
                            MessageBox.Show("ثبت با موفقیت انجام شد");
                            DisplayProcessView();
                            ts.Complete();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("خطایی در ثبت اطلاعات رخ داده است.");
                    }
                    finally { con.Close(); }
                }
            }          
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFer2.Checked== true)
            {
                groupPanel6.Enabled = true;
            }
            else groupPanel6.Enabled = false;

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            txtTedad1.Text = "";
            cmbFer1.Text = "";

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtTedad2.Text = "";
            cmbFer2.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا مایل به حذف رکورد هستتید؟", "هشدار", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                con.Close();
                try
                {
                    using (var ts = new System.Transactions.TransactionScope())
                    {
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Delete from [tblProcess] where ProcessID = @n";
                        cmd.Parameters.AddWithValue("@n", processID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        InputID = -1;
                        ///////////////////////////////////////////////////////////////////
                        //Edit Jadval Input
                        int PrccChecker = 0;
                        cmd.Parameters.Clear();
                        cmd.Connection = con;
                        cmd.CommandText = "Update tblInput Set PrccChecker='" + PrccChecker + "' where InputID =" + inid;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //////////////////////////////////////////////////////////////
                        MessageBox.Show("عملیات حذف با موفقیت انجام شد.");
                        DisplayProcessView();
                        ts.Complete();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("مشکلی در حذف  رخ داده است.");
                }
                finally { con.Close(); }
            }
            
        }

        private void dgvInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                processID = (int)dgvInput.Rows[e.RowIndex].Cells["ProcessID"].Value;
                inid =(int)dgvInput.Rows[e.RowIndex].Cells["InputID"].Value;
                    cmd.Parameters.Clear();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = new SqlCommand();
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandText = "select * from [tblProcess] where ProcessID =" + processID;
                    con.Open();
                    adp.Fill(dt);
                    this.txtDate1.Text = dt.Rows[0]["inputDate1"].ToString();
                    this.cmbFer1.Text = dt.Rows[0]["NumberFer1"].ToString();
                    this.txtTedad1.Text = dt.Rows[0]["TedadKiseFer1"].ToString();

                    this.cmbFer2.Text = dt.Rows[0]["NumberFer2"].ToString();
                    this.txtTedad2.Text = dt.Rows[0]["TedadKiseFer2"].ToString();
                    this.txtDate2.Text = dt.Rows[0]["inputDate1"].ToString();
                
                    this.txtDiscription.Text = dt.Rows[0]["Discription"].ToString();
;
                    con.Close();
                groupPanel6.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("خطایی در انتخاب رکورد رخ داده است");
            }

        }

        private void dgvInputList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                this.cm1.Show(this.dgvInputList, e.Location);
                cm1.Show(Cursor.Position);
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 0;
            int[] DCstmrID = new int[dgvInputList.SelectedRows.Count];
            double[] DInTedadKise = new double[dgvInputList.SelectedRows.Count];
            int[] DInWeight = new int[dgvInputList.SelectedRows.Count];
            string[] DInNo = new string[dgvInputList.SelectedRows.Count];
            string[] DInDate = new string[dgvInputList.SelectedRows.Count];
            int DCstmrID1 = -1;
            string DInTedadKise1 = "";
            string DInWeight1 = "";
            string DInNo1 = "";
            string DInDate1 = "";

            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {
                DCstmrID[i] = (int)dgvInputList.SelectedRows[i].Cells[3].Value;
                DInNo[i] = (string)dgvInputList.SelectedRows[i].Cells[4].Value;
                DInTedadKise[i] = (double)dgvInputList.SelectedRows[i].Cells[5].Value;
                DInWeight[i] = (int)dgvInputList.SelectedRows[i].Cells[6].Value;
                DInDate[i] = (string)dgvInputList.SelectedRows[i].Cells[8].Value;

            }
            for (int i = 0; i < dgvInputList.SelectedRows.Count; i++)
            {

                DInNo1 += ((string)dgvInputList.SelectedRows[i].Cells[4].Value + ",");
                DInTedadKise1 += (Convert.ToString((double)dgvInputList.SelectedRows[i].Cells[5].Value) + ",");
                DInWeight1 += (Convert.ToString((int)dgvInputList.SelectedRows[i].Cells[6].Value) + ",");
                DInDate1 += ((string)dgvInputList.SelectedRows[i].Cells[8].Value + "-");
                k = i;

            }
            DCstmrID1 = (int)dgvInputList.SelectedRows[k].Cells[3].Value;
            try
            {
                con.Close();
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into DealerInput(DCstmrID,DInNo,DInTedadKise,DInWeight,DInDate)values(@a,@b,@c,@d,@e)";
                cmd.Parameters.AddWithValue("@a", DCstmrID1.ToString());
                cmd.Parameters.AddWithValue("@b", DInNo1);
                cmd.Parameters.AddWithValue("@c", DInTedadKise1);
                cmd.Parameters.AddWithValue("@d", DInWeight1);
                cmd.Parameters.AddWithValue("@e", DInDate1);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در ثبت اطلاعات وجود دارد!");

            }
        }
        private void cmbFer1_Click(object sender, EventArgs e)
        {
            TedadKiseFer1();
            TedadKiseFer2();
        }

        private void cmbFer2_Click(object sender, EventArgs e)
        {
            TedadKiseFer1();
            TedadKiseFer2();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            new frmFer().ShowDialog();
        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {
            dgvInSearch.Visible = true;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr where id Like '%' + @s + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@s", txtSID.Text + "%");
            adp.Fill(ds, "tblCstmr");
            dgvInSearch.DataSource = ds;
            dgvInSearch.DataMember = "tblCstmr";
            //dgvInput.Visible = false;
            mt.Titr(dgvInSearch);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTedad1.Text == "" && cmbFer1.Text == "")
            {
                MessageBox.Show(".لطفا فیلد های مشخص شده را پر کنید");
                line2.Visible = true;
                line5.Visible = true;
                line3.Visible = true;
                line4.Visible = true;
                dgvInputList.Visible = true;
                btnCloseDgv.Visible = true;
            }
            else
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "update [tblProcess] Set inputDate1=N'" + txtDate1.Text + "', inputDate2=N'" + txtDate2.Text + "', NumberFer1=N'" + cmbFer1.Text + "',TedadKiseFer1=N'" + txtTedad1.Text + "',NumberFer2=N'" + cmbFer2.Text + "',TedadKiseFer2=N'" + txtTedad2.Text + "',Discription='" + txtDiscription.Text + "' where ProcessID=" + processID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ویرایش اطلاعات انجام شد.");
                    cmd.Parameters.Clear();
                    cmbFer2.Text = "";
                    cmbFer1.Text = "";
                    txtDiscription.Text = "";
                    txtTedad1.Text = "";
                    txtTedad2.Text = "";
                    groupPanel6.Enabled = false;
                    DisplayProcessView();
                }
                catch (Exception)
                {

                    MessageBox.Show("مشکلی در ویرایش اطلاعات وجود دارد!");
                }
                finally { con.Close(); }
            }
           
            
        }
        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            line3.Visible = false;
            line4.Visible = false;
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
    }
}
