using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Timer
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IntCheck()
        {
            if (Information.IsNumeric(this.txtNum.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show("숫자를 입력하세요~", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNum.Focus(); // 숫자 입력 강조하기
                return false;
            }
        }

        private void BtnCount_Click(object sender, EventArgs e)
        {
            if (IntCheck())
            {
                this.CountOrgNum = Convert.ToInt32(this.txtNum.Text);
                // Convert.ToInt32로 문자열을 숫자로 바꿈
                this.txtNum.ReadOnly = true; // 입력 칸에 숫자를 입력할 수 없음
                this.Timer.Enabled = true; // start timer
            }
            else
            {
                this.txtNum.Text = "";
                this.txtNum.Focus();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CountOrgNum < 1)
            { // 0이 될 경우
                this.Timer.Enabled = false;
                this.txtNum.ReadOnly = false;
                this.txtNum.Text = "";
                MessageBox.Show("펑!", "알림",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNum.Focus();
            }
            else
            {
                this.CountOrgNum--;
                this.txtCountDown.Text = Convert.ToString(this.CountOrgNum);
            }

        }
    }
}
