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
        private double s1 = 0;
        private double s2 = 0;
        private string bieuthuc = ""; // Biến lưu giữ biểu thức

        public CALCULATOR()
        {
            InitializeComponent();
        }

        // Thiết lập phép toán
        private void SetOperation(string operation)
        {
            if (txtDISPLAY.Text.Contains("√"))
            {
                string input = txtDISPLAY.Text.Replace("√", "");
                if (double.TryParse(input, out double sqrtValue))
                {
                    if (sqrtValue < 0)
                    {
                        txtDISPLAY.Text = "Invalid input";
                        return;
                    }
                    s1 = Math.Sqrt(sqrtValue); // Tính giá trị căn bậc hai
                }
                else
                {
                    txtDISPLAY.Text = "Invalid input";
                    return;
                }
            }
            else if (!double.TryParse(txtDISPLAY.Text, out s1))
            {
                txtDISPLAY.Text = "Invalid input";
                return;
            }

            pheptinh = operation; // Lưu phép toán
            txtDISPLAY.Text = ""; // Xóa màn hình
        }


        // Xử lý các nút số
        private void btn0_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn0.Text;
            bieuthuc += btn0.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn1.Text;
            bieuthuc += btn1.Text;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn2.Text;
            bieuthuc += btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn3.Text;
            bieuthuc += btn3.Text;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn4.Text;
            bieuthuc += btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn5.Text;
            bieuthuc += btn5.Text;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn6.Text;
            bieuthuc += btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn7.Text;
            bieuthuc += btn7.Text;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn8.Text;
            bieuthuc += btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btn9.Text;
            bieuthuc += btn9.Text;
        }
        private void btnCHAM_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text += btnCHAM.Text;
            bieuthuc += btnCHAM.Text;
        }

        // Xử lý dấu %
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

        // Các nút phép toán
        private void btnCONG_Click(object sender, EventArgs e)
        {
            SetOperation("➕");
            bieuthuc += " + ";
        }

        private void btnTRU_Click(object sender, EventArgs e)
        {
            SetOperation("➖");
            bieuthuc += " - ";
        }

        private void btnNHAN_Click(object sender, EventArgs e)
        {
            SetOperation("✖️");
            bieuthuc += " * ";
        }

        private void btnCHIA_Click(object sender, EventArgs e)
        {
            SetOperation("➗");
            bieuthuc += " / ";
        }

        private void btnLUYTHUA_Click(object sender, EventArgs e)
        {
            SetOperation("^");
            bieuthuc += " ^ ";
        }


        // Xử lý căn bậc hai
        private void btnCAN_Click(object sender, EventArgs e)
        {
            pheptinh = "√";
            bieuthuc += "√";
            txtDISPLAY.Text = "√";
        }


        // Xóa một ký tự
        private void btnXOA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDISPLAY.Text))
            {
                txtDISPLAY.Text = txtDISPLAY.Text.Substring(0, txtDISPLAY.Text.Length - 1);
            }
        }

        // Xử lý kết quả
        private void btnKETQUA_Click(object sender, EventArgs e)
        {
            try
            {
                double finalResult = 0;

                // Xử lý nếu chỉ có phép căn bậc hai trong màn hình
                if (txtDISPLAY.Text.StartsWith("√"))
                {
                    string input = txtDISPLAY.Text.Replace("√", "");
                    if (double.TryParse(input, out double sqrtValue))
                    {
                        if (sqrtValue < 0) // Kiểm tra số âm
                        {
                            txtDISPLAY.Text = "Invalid input";
                            return;
                        }
                        finalResult = Math.Sqrt(sqrtValue);
                        txtDISPLAY.Text = finalResult.ToString();
                        bieuthuc += $" = {finalResult}";
                        AddToHistory(bieuthuc); // Thêm biểu thức vào lịch sử
                        ResetState();
                        return;
                    }
                    else
                    {
                        txtDISPLAY.Text = "Invalid input";
                        return;
                    }
                }

                // Nếu không phải phép căn, lấy giá trị s2 từ màn hình
                if (!double.TryParse(txtDISPLAY.Text, out s2))
                {
                    txtDISPLAY.Text = "Invalid input";
                    return;
                }

                // Thực hiện phép toán dựa trên `pheptinh`
                switch (pheptinh)
                {
                    case "➕":
                        finalResult = s1 + s2;
                        break;
                    case "➖":
                        finalResult = s1 - s2;
                        break;
                    case "✖️":
                        finalResult = s1 * s2;
                        break;
                    case "➗":
                        if (s2 == 0)
                        {
                            txtDISPLAY.Text = "Cannot divide by 0";
                            return;
                        }
                        finalResult = s1 / s2;
                        break;
                    case "^":
                        finalResult = Math.Pow(s1, s2);
                        break;
                    default:
                        txtDISPLAY.Text = "Invalid operation";
                        return;
                }

                // Hiển thị kết quả và lưu vào lịch sử
                txtDISPLAY.Text = finalResult.ToString();
                bieuthuc += $" = {finalResult}";
                AddToHistory(bieuthuc); // Thêm vào lịch sử
                ResetState();
            }
            catch (Exception ex)
            {
                txtDISPLAY.Text = $"Error: {ex.Message}";
            }
        }




        // Thêm biểu thức vào lịch sử
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



        // Reset lại trạng thái sau khi tính toán
        private void ResetState()
        {
            pheptinh = "";
            s1 = 0;
            bieuthuc = "";
        }

        // Xóa toàn bộ màn hình và lịch sử
        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            txtDISPLAY.Text = "";
            ResetState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHISTORY.Text = "";  // Xóa lịch sử
        }

        private void CALCULATOR_Load(object sender, EventArgs e)
        {

        }

        private void txtHISTORY_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDISPLAY_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

