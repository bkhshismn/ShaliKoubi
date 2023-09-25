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
    public partial class frmBedehkaaran : Form
    {
        public frmBedehkaaran()
        {
            InitializeComponent();
        }
        method mt = new method();
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        clsNewEditing ne = new clsNewEditing();
        System.Globalization.PersianCalendar dt = new System.Globalization.PersianCalendar();
        TConnection tc = new TConnection();
        TransactionQueryClass trnsction = new TransactionQueryClass();
        int set = 0;
        int id = -1;

        void Display()
        {
            try
            {

                dgvBed.Columns["MoshtariID"].HeaderText = "کد";
                dgvBed.Columns["MoshtariID"].Width = 70;
                dgvBed.Columns["MoshtariID"].Visible = false;
               dgvBed.Columns["Name"].HeaderText = " نام";
                dgvBed.Columns["Family"].HeaderText = "کد ملی";
                //dgvBed.Columns["No"].HeaderText = "نوع مشتری";
                dgvBed.Columns["bed"].HeaderText = "مبلغ بدهی";
                dgvBed.Columns["DastiID"].HeaderText = " کد دستی"; 
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
        }


        DataTable GetBedehkari()
        {
            DataTable bed = new DataTable();
            try
            {
                tc.CommandText = "select MoshtariID ,b.DastiID, b.Name, b.Family ,(sum(bed)-sum(bes)) as bed from tblHesabMoshtari as a inner join tblCstmr  as b on a.MoshtariID=b.id " +
                    "group by DastiID,MoshtariID, Name, Family ";
                bed = tc.ExecuteReader();
            }
            catch (Exception)
            {
            }
            return bed;
        }
        private void btnBedJari_Click(object sender, EventArgs e)
        {
           dgvBed.DataSource= GetBedehkari();
            Display();
        }

        private void btnBedGozashte_Click(object sender, EventArgs e)
        {

        }

        private void dgvBed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvBed.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {

            }
          
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //    if (set == 1)
                //    {
                //        DataSet ds = new DataSet();
                //        SqlDataAdapter adp = new SqlDataAdapter();
                //        adp.SelectCommand = new SqlCommand();
                //        adp.SelectCommand.Connection = con;
                //        adp.SelectCommand.CommandText = "select * from View_BedehKaran where Name Like '%' + @s + '%'";
                //        adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                //        adp.Fill(ds, "View_BedehKaran");
                //        dgvBed.DataSource = ds;
                //        dgvBed.DataMember = "View_BedehKaran";
                //        dgvBed.Columns["id"].HeaderText = "کد";
                //        dgvBed.Columns["id"].Width = 70;
                //        dgvBed.Columns["Name"].HeaderText = " نام";
                //        dgvBed.Columns["Family"].HeaderText = "نام خانوادگی";
                //        dgvBed.Columns["No"].HeaderText = "نوع مشتری";
                //        dgvBed.Columns["MablaghBed"].HeaderText = "مبلغ بدهکاری";
            //}
                //else if (set == 2)
                //{
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter adp = new SqlDataAdapter();
                //    adp.SelectCommand = new SqlCommand();
                //    adp.SelectCommand.Connection = con;
                //    adp.SelectCommand.CommandText = "select * from View_BedehkaranSaleGozashte where Name Like '%' + @s + '%'";
                //    adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                //    adp.Fill(ds, "View_BedehkaranSaleGozashte");
                //    dgvBed.DataSource = ds;
                //    dgvBed.DataMember = "View_BedehkaranSaleGozashte";
                //    dgvBed.Columns["id"].HeaderText = "کد";
                //    dgvBed.Columns["id"].Width = 70;
                //    dgvBed.Columns["Name"].HeaderText = " نام";
                //    dgvBed.Columns["Family"].HeaderText = "نام خانوادگی";
                //    dgvBed.Columns["No"].HeaderText = "نوع مشتری";
                //    dgvBed.Columns["MablaghBed"].HeaderText = "مبلغ بدهکاری";
                //}
                //else if (set == 3)
                //{
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter adp = new SqlDataAdapter();
                //    adp.SelectCommand = new SqlCommand();
                //    adp.SelectCommand.Connection = con;
                //    adp.SelectCommand.CommandText = "select * from View_MoshtariBestankarJari where Name Like '%' + @s + '%'";
                //    adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                //    adp.Fill(ds, "View_MoshtariBestankarJari");
                //    dgvBed.DataSource = ds;
                //    dgvBed.DataMember = "View_MoshtariBestankarJari";
                //    dgvBed.Columns["id"].HeaderText = "کد";
                //    dgvBed.Columns["id"].Width = 70;
                //    dgvBed.Columns["Name"].HeaderText = " نام";
                //    dgvBed.Columns["Family"].HeaderText = "نام خانوادگی";
                //    dgvBed.Columns["No"].HeaderText = "نوع مشتری";
                //    dgvBed.Columns["MablaghBes"].HeaderText = "مبلغ بستانکاری";
                //}
                //else if (set == 4)
                //{
                //    DataSet ds = new DataSet();
                //    SqlDataAdapter adp = new SqlDataAdapter();
                //    adp.SelectCommand = new SqlCommand();
                //    adp.SelectCommand.Connection = con;
                //    adp.SelectCommand.CommandText = "select * from View_BestankaranSaleGozashte where Name Like '%' + @s + '%'";
                //    adp.SelectCommand.Parameters.AddWithValue("@s", textBoxX1.Text + "%");
                //    adp.Fill(ds, "View_BestankaranSaleGozashte");
                //    dgvBed.DataSource = ds;
                //    dgvBed.DataMember = "View_BestankaranSaleGozashte";
                //    dgvBed.Columns["id"].HeaderText = "کد";
                //    dgvBed.Columns["id"].Width = 70;
                //    dgvBed.Columns["Name"].HeaderText = " نام";
                //    dgvBed.Columns["Family"].HeaderText = "نام خانوادگی";
                //    dgvBed.Columns["No"].HeaderText = "نوع مشتری";
                //    dgvBed.Columns["MablaghBes"].HeaderText = "مبلغ بستانکاری";
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی در نمایش اطلاعات رخ داده است");
            }
          
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = "";
        }

        private void btnBesJari_Click(object sender, EventArgs e)
        {

        }

        private void btnBesGozashte_Click(object sender, EventArgs e)
        {

        }

        private void frmBedehkaaran_Load(object sender, EventArgs e)
        {
            groupPanel5.Visible = false;
            btnBedGozashte.Visible = false;
            
        }

        private void dgvBed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvBed.Columns["bed"].Index && e.RowIndex != this.dgvBed.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
    }
}
