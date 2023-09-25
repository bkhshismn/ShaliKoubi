using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaliKoubi
{
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            pr.Value += 10;
            if (pr.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    new frmLogin().ShowDialog();
                    this.Close();
                }               
            //}
            //catch
            //{

            //}
        }

    }
}
