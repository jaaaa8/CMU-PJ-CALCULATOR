using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMU_PJ_CALCULATOR
{
    public partial class CALCULATOR : DevExpress.XtraEditors.XtraForm
    {
        private string pheptinh = " ";
        private double s1, s2;
        public CALCULATOR()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn3.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn6.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn9.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn8.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn7.Text;
        }

        private void btnPHANTRAM_Click(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn0.Text;
        }

        private void btnCHAM_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btnCHAM.Text;
        }

        private void btnCHIA_Click(object sender, EventArgs e)
        {
            pheptinh = "➗";
            s1 = double.Parse(txtDISPLAY.Text);
            txtDISPLAY.Text = "";
        }

        private void btnNHAN_Click(object sender, EventArgs e)
        {
            pheptinh = "✖️";
            s1 = double.Parse(txtDISPLAY.Text);
            txtDISPLAY.Text = "";
        }

        private void btnTRU_Click(object sender, EventArgs e)
        {
            pheptinh = "➖";
            s1 = double.Parse(txtDISPLAY.Text);
            txtDISPLAY.Text = "";
        }

        private void btnCONG_Click(object sender, EventArgs e)
        {
            pheptinh = "➕";
            s1 = double.Parse(txtDISPLAY.Text);
            txtDISPLAY.Text = "";
        }

        private void btnLUYTHUA_Click(object sender, EventArgs e)
        {

        }

        private void btnCAN_Click(object sender, EventArgs e)
        {

        }

        private void btnXOA_Click(object sender, EventArgs e)
        {

        }

        private void btnKETQUA_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn5.Text;
        }
    }
}