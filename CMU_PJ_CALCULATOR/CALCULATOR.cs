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
        private string pheptinh = "";
        private string input = "";
        private double result = 0;
        private double s1 = 0;
        public CALCULATOR()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SetOperation(string operation)
        {
            if (double.TryParse(txtDISPLAY.Text, out s1)) // Kiểm tra giá trị nhập có hợp lệ không
            {
                pheptinh = operation; // Lưu phép tính
                txtDISPLAY.Text = ""; // Xóa màn hình để nhập số tiếp theo
            }
            else
            {
                txtDISPLAY.Text = "Invalid input"; // Hiển thị lỗi nếu không hợp lệ
            }
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
            try
            {
                if (double.TryParse(txtDISPLAY.Text, out double s2))
                {
                    txtDISPLAY.Text = (s2 / 100).ToString();
                }
                else
                {
                    txtDISPLAY.Text = "Invalid input";
                }
            }
            catch
            {
                txtDISPLAY.Text = "Error";
            }
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
            SetOperation("➗");
        }

        private void btnNHAN_Click(object sender, EventArgs e)
        {
            SetOperation("✖️");
        }

        private void btnTRU_Click(object sender, EventArgs e)
        {
            SetOperation("➖");
        }

        private void btnCONG_Click(object sender, EventArgs e)
        {
            SetOperation("➕");
        }

        private void btnLUYTHUA_Click(object sender, EventArgs e)
        {
            SetOperation("^");
        }

        private void btnCAN_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtDISPLAY.Text, out double s2))
                {
                    if (s2 < 0)
                    {
                        txtDISPLAY.Text = "Invalid input";
                    }
                    else
                    {
                        txtDISPLAY.Text = Math.Sqrt(s2).ToString();
                    }
                }
                else
                {
                    txtDISPLAY.Text = "Invalid input";
                }
            }
            catch
            {
                txtDISPLAY.Text = "Error";
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDISPLAY.Text)) // Kiểm tra nếu chuỗi không rỗng
            {
                txtDISPLAY.Text = txtDISPLAY.Text.Substring(0, txtDISPLAY.Text.Length - 1); // Xóa ký tự cuối
            }
        }

        private void btnKETQUA_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtDISPLAY.Text, out double s2))
                {
                    switch (pheptinh)
                    {
                        case "➕":
                            result = s1 + s2;
                            break;
                        case "➖":
                            result = s1 - s2;
                            break;
                        case "✖️":
                            result = s1 * s2;
                            break;
                        case "➗":
                            if (s2 == 0)
                            {
                                txtDISPLAY.Text = "Cannot divide by 0";
                                return;
                            }
                            result = s1 / s2;
                            break;
                        case "^":
                            result = Math.Pow(s1, s2);
                            break;
                        default:
                            txtDISPLAY.Text = "Invalid operation";
                            return;
                    }

                    txtDISPLAY.Text = result.ToString();
                    AddToHistory($"{s1} {pheptinh} {s2} = {result}");
                }
                else
                {
                    txtDISPLAY.Text = "Invalid input";
                }
            }
            catch
            {
                txtDISPLAY.Text = "Error";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn5.Text;
        }

        private void AddToHistory(string newEntry)
        {
            if (string.IsNullOrEmpty(txtHISTORY.Text))
            {
                txtHISTORY.Text = newEntry;
            }
            else
            {
                txtHISTORY.Text += Environment.NewLine + newEntry;
            }

            // Giới hạn tối đa 10 dòng lịch sử
            var historyLines = txtHISTORY.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (historyLines.Length > 10)
            {
                txtHISTORY.Text = string.Join(Environment.NewLine, historyLines.Skip(1));
            }
        }

        private void CALCULATOR_Load(object sender, EventArgs e)
        {

        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDISPLAY.Text))
            {
                // First click: Clear txtDISPLAY
                txtDISPLAY.Text = "";
            }
            else
            {
                // Second click: Clear txtHISTORY if txtDISPLAY is already empty
                txtHISTORY.Text = "";
                pheptinh = "";
                s1 = 0;
                result = 0;
            }
        }

    }
}