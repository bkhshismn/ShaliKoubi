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
    public partial class frmKargarMotfareghe : Form
    {
        public frmKargarMotfareghe()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();

        public void DisplayCombo()
        {
            string query = "SELECT  SharheKharid FROM [tblSharhKharid]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
            cmbSharh.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbSharh.Items.Add(dt.Rows[i]["SharheKharid"]);
            }
        }
        private void frmKargarMotfareghe_Load(object sender, EventArgs e)
        {
            DisplayCombo();
        }

        private void cmbSharh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblcost where SharhHazine  Like '%' + @s + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@s", cmbSharh.Text + "%");
                adp.Fill(ds, "tblcost");
                dgvHazine.DataSource = ds;
                dgvHazine.DataMember = "tblcost";
                dgvHazine.Columns[0].HeaderText = "کد";
                dgvHazine.Columns[0].Width = 70;
                dgvHazine.Columns[1].HeaderText = " مبلغ";
                dgvHazine.Columns[2].HeaderText = "شرح هزینه";
                dgvHazine.Columns[3].HeaderText = "توسط";
                dgvHazine.Columns[4].HeaderText = "تاریخ هزینه";
                dgvHazine.Columns[5].HeaderText = "توضیحات";
            }
            catch (Exception)
            {
                MessageBox.Show("رکورد خالی می باشد");
            }
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void dgvHazine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dgvHazine.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("#,##0.##");
            }
        }
    }
}
