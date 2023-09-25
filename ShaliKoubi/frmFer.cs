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
    public partial class frmFer : Form
    {
        public frmFer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        method mt = new method();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        private void cmbFer1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_prcss where NumberFer1=" + cmbFer1.Text + "AND chk_Process =" + 0;
                adp.Fill(ds, "View_prcss");
                dgvFer.DataSource = ds;
                dgvFer.DataMember = "View_prcss";
           
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["CstmrID"].HeaderText = "کد مشتری";

            dgvFer.Columns["Name"].HeaderText = "نام مشتری";
            dgvFer.Columns["Family"].HeaderText = "نام خانوادگی";
            dgvFer.Columns["InNo"].HeaderText = "نوع برنج";
            dgvFer.Columns["InTedadKise"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["InputID"].HeaderText = "کد ورود محصول";
            dgvFer.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر";
            dgvFer.Columns["NumberFer1"].HeaderText = "شماره فر";
            dgvFer.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["inputDate2"].Visible = false;
            dgvFer.Columns["NumberFer2"].Visible = false;
            dgvFer.Columns["TedadKiseFer2"].Visible = false;
            dgvFer.Columns["Discription"].HeaderText = "توضیحات";
            dgvFer.Columns["PrccChecker"].Visible = false;

        }

        private void cmbFer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from View_prcss where NumberFer2=" + cmbFer2.Text + "AND chk_Process =" + 0;
            adp.Fill(ds, "View_prcss");
            dgvFer.DataSource = ds;
            dgvFer.DataMember = "View_prcss";
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["CstmrID"].HeaderText = "کد مشتری";
            dgvFer.Columns["Name"].HeaderText = "نام مشتری";
            dgvFer.Columns["Family"].HeaderText = "نام خانوادگی";
            dgvFer.Columns["InNo"].HeaderText = "نوع برنج";
            dgvFer.Columns["InTedadKise"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["InputID"].HeaderText = "کد ورود محصول";
            dgvFer.Columns["inputDate2"].HeaderText = "تاریخ ورود به فر";
            dgvFer.Columns["NumberFer2"].HeaderText = "شماره فر";
            dgvFer.Columns["TedadKiseFer2"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر";
            dgvFer.Columns["NumberFer1"].HeaderText = "شماره فر";
            dgvFer.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه";
            //dgvFer.Columns["inputDate1"].Visible = false;
            //dgvFer.Columns["NumberFer1"].Visible = false;
            //dgvFer.Columns["TedadKiseFer1"].Visible = false;
            dgvFer.Columns["Discription"].HeaderText = "توضیحات";
            dgvFer.Columns["PrccChecker"].Visible = false;
        }

        private void frmFer_Load(object sender, EventArgs e)
        {
            txtFerDate2.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
            txtFerDate1.Text = dt.GetYear(DateTime.Now).ToString() + dt.GetMonth(DateTime.Now).ToString("0#") + dt.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Id = (int)dgvFer.Rows[e.RowIndex].Cells[0].Value;
            SqlDataAdapter adp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from [View_prcss] where inputDate1 between '" + txtFerDate2.Text + "'and '" + txtFerDate1.Text + "' AND chk_Process =" + 0;
            adp.Fill(ds, "View_prcss");
            dgvFer.DataSource = ds;
            dgvFer.DataMember = "View_prcss";
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["CstmrID"].HeaderText = "کد مشتری";
            dgvFer.Columns["Name"].HeaderText = "نام مشتری";
            dgvFer.Columns["Family"].HeaderText = "نام خانوادگی";
            dgvFer.Columns["InNo"].HeaderText = "نوع برنج";
            dgvFer.Columns["InTedadKise"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["chk_Process"].Visible = false;
            dgvFer.Columns["InputID"].HeaderText = "کد ورود محصول";
            dgvFer.Columns["inputDate2"].HeaderText = "تاریخ ورود به فر";
            dgvFer.Columns["NumberFer2"].HeaderText = "شماره فر";
            dgvFer.Columns["TedadKiseFer2"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["inputDate1"].HeaderText = "تاریخ ورود به فر";
            dgvFer.Columns["NumberFer1"].HeaderText = "شماره فر";
            dgvFer.Columns["TedadKiseFer1"].HeaderText = "تعداد کیسه";
            dgvFer.Columns["inputDate2"].Visible = false;
            dgvFer.Columns["Discription"].HeaderText = "توضیحات";
            dgvFer.Columns["PrccChecker"].Visible = false;
            int cunt = dgvFer.Rows.Count;
            int[] numbr= new int[cunt];
            Random RandomClass = new Random();
            Color[] cl = new Color[cunt];
            for (int i = 0; i < cunt; i++)
            {
                int rndRed = RandomClass.Next(0, 255);
                int rndGreen = RandomClass.Next(0, 255);
                int rndBlue = RandomClass.Next(0, 255);
                cl[i]= Color.FromArgb(rndRed, rndGreen, rndBlue);
            }

            for (int i = 0; i < cunt; i++)
            {
                
                numbr[i]= Convert.ToInt32(dgvFer.Rows[i].Cells["NumberFer1"].Value);
                switch (numbr[i])
                {
                    case 1:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[0];
                        break;
                    case 2:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[1];
                        break;
                    case 3:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[2];
                        break;
                    case 4:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[3];
                        break;
                    case 5:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[4];
                        break;
                    case 6:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[5];
                        break;
                    case 7:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[6];
                        break;
                    case 8:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[7];
                        break;
                    case 9:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[8];
                        break;
                    case 10:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[9];
                        break;
                    case 11:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[10];
                        break;
                    case 12:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[11];
                        break;
                    case 13:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[12];
                        break;
                    case 14:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[13];
                        break;
                    case 15:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[14];
                        break;
                    case 16:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[15];
                        break;
                    case 17:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[16];
                        break;
                    case 18:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[17];
                        break;
                    case 19:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[18];
                        break;
                    case 20:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[19];
                        break;
                    case 21:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[20];
                        break;
                    case 22:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[21];
                        break;
                    case 23:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[22];
                        break;
                    case 24:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[23];
                        break;
                    case 25:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[24];
                        break;
                    case 26:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[25];
                        break;
                    case 27:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[26];
                        break;
                    case 28:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[26];
                        break;
                    case 29:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[28];
                        break;
                    case 30:
                        dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[29];
                        break;
                    //case 15:
                    //    dgvFer.Rows[i].DefaultCellStyle.BackColor = cl[14];
                    //    break;
                }
               
            }
        }
    }
}
