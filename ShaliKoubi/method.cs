using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaliKoubi
{

    class method
    {
        //frmMali f = new frmMali();
        System.Data.SqlClient.SqlConnection con = new SqlConnection("Data source =(local);initial catalog=DBShalikoubi;integrated security = true");
        SqlCommand cmd = new SqlCommand();
        clsGozareshMoshtari Gozaresh = new clsGozareshMoshtari();
        clsNewEditing ne = new clsNewEditing();
        /// <summary>
        /// Heder haye DataGrid Search Ra Namgozari Mikonad.
        /// </summary>
        public void Titr(DataGridView dgvInSearch)
        {
            dgvInSearch.Columns["DastiID"].HeaderText = "کد مشتری";
            dgvInSearch.Columns["DastiID"].Width = 70;
            dgvInSearch.Columns[0].Visible = false;
            dgvInSearch.Columns["Name"].HeaderText = " نام";
            dgvInSearch.Columns["Name"].Width = 120;
            dgvInSearch.Columns["Family"].HeaderText = "کد ملی";
            dgvInSearch.Columns["Family"].Width = 90;
            dgvInSearch.Columns["Tel"].HeaderText = "تلفن";
            //dgvInSearch.Columns[3].Visible = false;
            dgvInSearch.Columns["Address"].HeaderText = "آدرس";
            dgvInSearch.Columns["Address"].Visible = false;
            dgvInSearch.Columns["No"].HeaderText = "نوع مشتری";
            dgvInSearch.Columns["No"].Width = 60;
        }

        /// <summary>
        /// Report az jadval PayMahsol 
        /// </summary>
        /// <returns></returns>
        public int[] Mahsol()
        {
            int[] mahsol = new int[3];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int nimdone = 0;
            int done = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["VazneSabos"]);
                    nimdone += Convert.ToInt32(dt.Rows[i]["VazneNimdone"]);
                    done += Convert.ToInt32(dt.Rows[i]["VazneDone"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            mahsol[0] = sabos1;
            mahsol[1] = nimdone;
            mahsol[2] = done;
            return mahsol;
        }

        /// <summary>
        /// Report az jadval SabosNarm
        /// </summary>
        /// <returns></returns>
        public int[] SabosNarm()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSabosNarm";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WSNarm"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["SNMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = sabos1;
            report[1] = majmo;
            return report;
        }

        /// <summary>
        /// Report az jadval SabosDo
        /// </summary>
        /// <returns></returns>
        public int[] Sabos2()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSabosDo";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos2 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos2 += Convert.ToInt32(dt.Rows[i]["WSNarm"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["SNMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = sabos2;
            report[1] = majmo;
            return report;
        }

        /// <summary>
        /// Report az jadval Output/Sabos2
        /// </summary>
        /// <returns></returns>
        public int Sabos2Output()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblOutput";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WightSabos2"]);

                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = sabos1;
            return report;
        }

        /// <summary>
        /// Report az jadval NDone(Forosh)
        /// </summary>
        /// <returns></returns>
        public int[] NimDone()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblNDone";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WNDone"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["NDoneMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = ndone;
            report[1] = majmo;
            return report;
        }

        /// <summary>
        /// Report az jadval Done
        /// </summary>
        /// <returns></returns>
        public int[] Done()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblDone";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int done = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    done += Convert.ToInt32(dt.Rows[i]["WDone"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["DoneMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = done;
            report[1] = majmo;
            return report;
        }

        ///<summary>
        ///Report mali az jadvalSayer
        /// </summary>
        public int Sayer()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSayer";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["SMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = majmo;
            return report;
        }

        /// <summary>
        /// Report az jadval Salary
        /// </summary>
        public int Salary(int id)
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblSalary where mmbrID=" + id;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int salary = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    salary += Convert.ToInt32(dt.Rows[i]["SalaryMablagh"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report = salary;
            return report;
        }

        /// <summary>
        /// Report az jadval Member
        /// </summary>
        public int MemberFee(int id)
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblMember where mmbrID=" + id;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int salary = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    salary += Convert.ToInt32(dt.Rows[i]["mmbrFee"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report = salary;
            return report;
        }

        /// <summary>
        /// Namayesh anva berenj dar ComboBax ha
        /// </summary>
        public void DisplayCombo(ComboBox cmbBerenjNo)
        {
            string query = "SELECT  No FROM [tblBNo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
            cmbBerenjNo.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbBerenjNo.Items.Add(dt.Rows[i]["No"]);
            }
        }

        /// <summary>
        /// Report az jadval PayMahsol Baraye Report kol dar form mali 
        /// </summary>
        /// <returns></returns>
        public int reportMahsol()
        {
            int jamkol = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            //int takhfif = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    jamkol += Convert.ToInt32(dt.Rows[i]["Pardakhti"]);
                    //takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            
            return jamkol;
        }
        public int TakhfifreportMahsol()
        {
            int jamkol = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayMahsol";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int takhfif = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    jamkol += Convert.ToInt32(dt.Rows[i]["JamKol"]);
                    takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            jamkol = takhfif;
            return jamkol;
        }

        ///<summary>
        ///Report mali az jadval Paycheck
        /// </summary>
        public int Chck()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayCheck";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            //int takhfif = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    //takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = majmo;
            return report;
        }
        public int TakhfifChck()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayCheck";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            int takhfif = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                    takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = takhfif;
            return report;
        }

        ///<summary>
        ///Report mali az jadval PayNaghdi
        /// </summary>
        /// 
        public int naghd()
        {
            int ngd = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ngd += Convert.ToInt32(dt.Rows[i]["Nagh"]);

                }
            }
            return ngd;
        }
        public int Naghd()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["Card"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = majmo;
            return report;
        }
        public int Takhfif()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from PayCheck";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            int takhfif = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    takhfif += Convert.ToInt32(dt.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp1 = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp1.SelectCommand = new SqlCommand();
            adp1.SelectCommand.Connection = con;
            adp1.SelectCommand.CommandText = "select * from tblPardakht";
            adp1.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    takhfif += Convert.ToInt32(dt1.Rows[i]["Takhfif"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }

            report = takhfif;
            return report;
        }

        ///<summary>
        ///Report mali az jadval PayNaghdi
        /// </summary>
        public int Hazine()
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCost";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int Hazine = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    Hazine += Convert.ToInt32(dt.Rows[i]["CostMablagh"]);
                }
            }
            else
            {

            }
            report = Hazine;
            return report;
        }

        ///<summary>
        ///Report tedad kise kol az jadval Input
        /// </summary>
        public double Kise()
        {
            double report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblInput";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            double Kise = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    Kise += Convert.ToDouble(dt.Rows[i]["InTedadKise"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            report = Kise;
            return report;
        }

        ///<summary>
        ///Gheymat sal
        /// </summary>
        public int Fee()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblFeeYear";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int fee = 0;
            fee = Convert.ToInt32(dt.Rows[0]["FeeYear"]);
            return fee;
        }
        public int Fer(int numberfer)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            //adp.SelectCommand.CommandText = "select * from tblProcess  where NumberFer1=" + numberfer + "AND PrccChecker !=" + 1;
            adp.SelectCommand.CommandText = "select * from tblProcess  where NumberFer1=" + numberfer + "AND chk_Process !=" + 1;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int tedadkise = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    tedadkise += Convert.ToInt32(dt.Rows[i]["TedadKiseFer1"]);
                }
            }
            return tedadkise;
        }

        /// <summary>
        /// Report az jadval tbkKDone
        /// </summary>
        /// <returns></returns>
        public int[] KharidDone()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKDone";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WDone"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["DoneMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد دونه خالی می باشد");
            }


            report[0] = ndone;
            report[1] = majmo;
            return report;
        }

        /// <summary>
        /// Report az jadval tblKNDone
        /// </summary>
        /// <returns></returns>
        public int[] KharidNimDone()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKNDone";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WNDone"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["NDoneMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = ndone;
            report[1] = majmo;
            return report;
        }
        public int KharidNimDone(string NoShali)
        {
            int report = 0;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKNDone";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int ndone = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    ndone += Convert.ToInt32(dt.Rows[i]["WNDone"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report = ndone;
            return report;
        }
        /// <summary>
        /// Report az jadval Sabos1
        /// </summary>
        /// <returns></returns>
        public int[] KharidSabosNarm()
        {
            int[] report = new int[2];
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblKSabosNarm";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int sabos1 = 0;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    sabos1 += Convert.ToInt32(dt.Rows[i]["WSNarm"]);
                    majmo += Convert.ToInt32(dt.Rows[i]["SNMajmo"]);
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }


            report[0] = sabos1;
            report[1] = majmo;
            return report;
        }
        /// <summary>
        /// Daryafti haye motefareghe
        /// </summary>
        /// <returns></returns>
        public int DaryaftiMotefareghe()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblDaryaftiMotefareghe ";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int majmo = 0;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    majmo += Convert.ToInt32(dt.Rows[i]["DMMablagh"]);
                }

            }
            else
            {
                //MessageBox.Show("رکورد حقوق دریافتی خالی می باشد");
            }
            return majmo;
        }

        /// <summary>
        /// Insert Anbar
        /// </summary>
        /// <param name="id"></param>
        public void InsetAnbar(int id)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT into [tblAnbar](CstmrID)values(@CstmrID)";
                cmd.Parameters.AddWithValue("@CstmrID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("ثبت درانبار ذخیره با موفقیت انجام شد");
            }
            catch (Exception)
            {

                MessageBox.Show("مشکلی در ثبت انبار وجود دارد");
            }
        }
        
        /// <summary>
        /// Update Anbar
        /// </summary>
        /// <param name="CstmCode"></param>
        /// <param name="TedadDone"></param>
        /// <param name="VaznDone"></param>
        /// <param name="TedadNimDone"></param>
        /// <param name="VaznNimDone"></param>
        public void UpdateAnbar(int CstmCode, double TedadDone,int VaznDone, double TedadNimDone,int VaznNimDone)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblAnbar where CstmrID="+ CstmCode;
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            //if (cunt > 0)
            //{
            //    for (int i = 0; i <= cunt - 1; i++)
            //    {
                    TedadDone += Convert.ToDouble(dt.Rows[0]["TDone"]);
                    VaznDone += Convert.ToInt32(dt.Rows[0]["WDone"]);

                    TedadNimDone += Convert.ToDouble(dt.Rows[0]["TNDone"]);
                    VaznNimDone += Convert.ToInt32(dt.Rows[0]["WNDone"]);
            //    }
            //}
            //else
            //{

            //}

            try
            {

                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update tblAnbar Set WDone=N'" + VaznDone + "',TDone=N'" + TedadDone + "',WNDone=N'" + VaznNimDone  + "',TNDone='" + TedadNimDone + "' where CstmrID=" + CstmCode;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ویرایش اطلاعات انجام شد.");
            }
            catch (Exception)
            {
                MessageBox.Show("خطایی در ویرایش اطلاعات رخ داده است.");
            }
        }

        public int Bedehkari()
        {
            int bedehkari = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblPardakht ";
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bedehkari += Convert.ToInt32(dt.Rows[i]["Bedehkar"]);
                    }
                }
                else
                {  
                }
                con.Close();
                ///////////////////////////////////////////////////////////////////////////
                DataSet ds1 = new DataSet();
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from View_CstmrToPardakht where Bestankar = " + 0 + " and Bedehkar = " + 0 + " and Pardakhti = " + 0 + " ";
                adp.Fill(dt1);
                int cunt1 = dt1.Rows.Count;
                if (cunt1 > 0)
                {
                    for (int i = 0; i <= cunt1 - 1; i++)
                    {
                        bedehkari += Convert.ToInt32(dt1.Rows[i]["KarmozdKisei"]);
                    }

                }
                else
                {

                }
                con.Close();

            }
            catch (Exception)
            {
            }
            return bedehkari;
        }
        public int CstmrBedehkar(int id)
        {
            int bedehkari = 0;
            int mablagh = 0;
            int tkhff = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblPardakht where CstmrID="+id;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bedehkari += Convert.ToInt32(dt.Rows[i]["Bedehkar"]);
                    }
                }
                else
                {
                }
                con.Close();
                ///////////////////////////////////////////////////////////////////////////
                DataSet ds1 = new DataSet();
                SqlDataAdapter adp1 = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                adp1.SelectCommand = new SqlCommand();
                adp1.SelectCommand.Connection = con;
                adp1.SelectCommand.CommandText = "select * from View_CstmrToPardakht where Bestankar = " + 0 + " and Bedehkar = " + 0 + " and Pardakhti = " + 0 + "  and id=" + id;
                adp.Fill(dt1);
                int cunt1 = dt1.Rows.Count;
                if (cunt1 > 0)
                {
                    for (int i = 0; i <= cunt1 - 1; i++)
                    {
                        bedehkari += Convert.ToInt32(dt1.Rows[i]["KarmozdKisei"]);
                    }

                }
                else
                {

                }
                con.Close();
                ///////////////////////////////////////////////////////////////////////////////////

                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter();
                DataTable dt2 = new DataTable();
                adp2.SelectCommand = new SqlCommand();
                adp2.SelectCommand.Connection = con;
                adp2.SelectCommand.CommandText = "select * from [PayCheck] where CstumID = " + id;
                adp2.Fill(dt2);
                int cunt2 = dt2.Rows.Count;
               
                if (cunt2 > 0)
                {
                    for (int i = 0; i <= cunt2 - 1; i++)
                    {
                        mablagh += Convert.ToInt32(dt2.Rows[i]["Mablagh"]);
                        tkhff += Convert.ToInt32(dt2.Rows[i]["Takhfif"]);
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
            return (bedehkari - mablagh)-tkhff;
        }
        public int Bedehkaran()
        {
            int bedehkaran = 0;
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }

            }
            else
            {

            }
            con.Close();
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                bedehkaran += CstmrBedehkar(id[i]);
            }
            return  bedehkaran;
        }
        public int InsertBedehkaran()
        {
            int bedehkaran = 0;
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }

            }
            else
            {

            }
            con.Close();
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] HesabMoshtari = new int[6];
                HesabMoshtari = ne.HesabMoshtari(id[i]);
                int[] mali = Gozaresh.Mali(id[i]);
                int s=((mali[1] - (mali[4] + mali[2])) +ne.BedehkariZiroZiro(id[i], 1));
                //int s = CstmrBedehkar(id[i]) ;
                //if (CstmrBedehkar(id[i]) > 0)
                if (s > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblMoshtariBedehkar](CstmrID,MablaghBed)values(@CstmrID,@MablaghBed)";
                    cmd.Parameters.AddWithValue("@CstmrID", id[i]);
                    cmd.Parameters.AddWithValue("@MablaghBed", s);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
               
            }
            return bedehkaran;
        }
        public void InsertBedehkaranSalePish()
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from [tblBedehkaranSalGozashte]";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////////////////////////////////
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }

            }
            else
            {

            }
            con.Close();
            int s = 0;
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] HesabMoshtari = new int[6];
                HesabMoshtari = ne.HesabMoshtari(id[i]);
                int[] mali = Gozaresh.Mali(id[i]);
                if ((((mali[1] - (mali[4] + mali[2])) + ne.BedehkariZiroZiro(id[i], 1))) > 0)
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblBedehkaranSalGozashte](CstmrID,MablaghBed)values(@CstmrID,@MablaghBed)";
                    cmd.Parameters.AddWithValue("@CstmrID", id[i]);
                    cmd.Parameters.AddWithValue("@MablaghBed", ((((mali[1] - (mali[4] + mali[2])) + ne.BedehkariZiroZiro(id[i], 1)))));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
        }
        public int CstmrBestankar(int id)
        {
            int bestankar = 0;
            int mablagh = 0;
            int tkhff = 0;
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                DataTable dt = new DataTable();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "select * from tblPardakht where CstmrID=" + id;
                adp.Fill(dt);
                int cunt = dt.Rows.Count;
                if (cunt > 0)
                {
                    for (int i = 0; i <= cunt - 1; i++)
                    {
                        bestankar += Convert.ToInt32(dt.Rows[i]["Bestankar"]);
                    }
                }
                else
                {
                }
                con.Close();
                ///////////////////////////////////////////////////////////////////////////////////

                DataSet ds2 = new DataSet();
                SqlDataAdapter adp2 = new SqlDataAdapter();
                DataTable dt2 = new DataTable();
                adp2.SelectCommand = new SqlCommand();
                adp2.SelectCommand.Connection = con;
                adp2.SelectCommand.CommandText = "select * from [PayCheck] where  CstumID = " + id;
                adp2.Fill(dt2);
                int cunt2 = dt2.Rows.Count;

                if (cunt2 > 0)
                {
                    for (int i = 0; i <= cunt2 - 1; i++)
                    {
                        mablagh += Convert.ToInt32(dt2.Rows[i]["Mablagh"]);
                        tkhff += Convert.ToInt32(dt2.Rows[i]["Takhfif"]);
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
            }
            return (bestankar-(mablagh + tkhff ) );
        }
        public void InsertBestankarkaranSalePish()
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from [tblBestanKareSaleGhbal]";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////////////////////////////////
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }

            }
            else
            {

            }
            con.Close();
            /////////////////////////////////////////////////////////////////////////////////////

            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] mali = Gozaresh.Mali(id[i]);
                if (mali[1] - (mali[4] + mali[2]) < 0)
                {
                    int bestankari = ((mali[1] - (mali[4] + mali[2])) * -1) - ne.BedehkariZiroZiro(id[i], 1);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblBestanKareSaleGhbal](CstmrID,MablaghBes)values(@CstmrID,@MablaghBes)";
                    cmd.Parameters.AddWithValue("@CstmrID", id[i]);
                    cmd.Parameters.AddWithValue("@MablaghBes", bestankari);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void InsertBestankarkaranSaleJari()
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from [tblMoshtariBestankar]";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ////////////////////////////////////////////////////////////////////
            DataSet ds1 = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblCstmr";
            adp.Fill(dt1);
            int cunt1 = dt1.Rows.Count;
            int[] id = new int[cunt1];
            if (cunt1 > 0)
            {
                for (int i = 0; i <= cunt1 - 1; i++)
                {
                    id[i] += Convert.ToInt32(dt1.Rows[i]["id"]);
                }

            }
            else
            {

            }
            con.Close();
            /////////////////////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= cunt1 - 1; i++)
            {
                int[] mali = Gozaresh.Mali(id[i]);
                if (mali[1] - (mali[4] + mali[2]) < 0)
                {
                    int bestankari = ((mali[1] - (mali[4] + mali[2])) * -1)- ne.BedehkariZiroZiro(id[i], 1);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT into [tblMoshtariBestankar](CstmrID,MablaghBes)values(@CstmrID,@MablaghBes)";
                    cmd.Parameters.AddWithValue("@CstmrID", id[i]);
                    cmd.Parameters.AddWithValue("@MablaghBes", bestankari);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public int KarmozdMahsol()
        {
            int karmozd = 0;
            
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblPardakht";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    karmozd += (Convert.ToInt32(dt.Rows[i]["VazneSabos"]) * (Convert.ToInt32(dt.Rows[i]["NerkhSabos"])));

                    karmozd += (Convert.ToInt32(dt.Rows[i]["VazneNimdone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhNimdone"])));

                    karmozd += (Convert.ToInt32(dt.Rows[i]["VazneDone"]) * (Convert.ToInt32(dt.Rows[i]["NerkhDone"])));
                }
            }
            else
            {
                //MessageBox.Show("رکورد خالی می باشد");
            }
            return karmozd;
        }
        //Tankhah
        public int  Tankhah()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tblTankhah";
            adp.Fill(dt);
            int cunt = dt.Rows.Count;
            int Hazine = 0;

            if (cunt > 0)
            {
                for (int i = 0; i <= cunt - 1; i++)
                {
                    Hazine += Convert.ToInt32(dt.Rows[i]["Mablagh"]);
                }
            }
            else
            {

            }
            return Hazine;
        }
        //Kharid ha az Masolat/////////////////////////////////////////////////////////////////////////////////////
        public int Kharid()
        {

            int ngd = 0;
            int [] kharidone = KharidDone();
            int[] kharidnimdone = KharidNimDone();
            int[] kharidsabos = KharidSabosNarm();
            ngd = kharidone[1] + kharidnimdone[1] + kharidsabos[1];
            return ngd;
        }


    }
}



