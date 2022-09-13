using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameUI
{
    public partial class SettingsFormD : Form
    {
        private int m_Height = 4;
        private int m_Width = 4;

        public int GetHieght()
        {
            return this.m_Height;
        }

        public int GetWidth()
        {
            return this.m_Width;
        }

        public SettingsFormD()
        {
            InitializeComponent();
        }

        public string FirstPlayerName()
        {
            return FirstPlayerTextBox.Text;
        }

        public string SecondPlayerName()
        {
            return SecondPlayerTextBox.Text;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();           
        }

        private void againstComputerButton_Click(object sender, EventArgs e)
        {
            SecondPlayerTextBox.Enabled = !SecondPlayerTextBox.Enabled;

            if (SecondPlayerTextBox.Enabled)
            {
                AgainstComputerButton.Text = "Against Computer";
                SecondPlayerTextBox.Text = String.Empty;
                SecondPlayerTextBox.BackColor = Color.White;
            }
            else
            {
                AgainstComputerButton.Text = "Against a Friend";
                SecondPlayerTextBox.Text = "-computer-";
                SecondPlayerTextBox.BackColor = Color.LightGray;
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            if (this.m_Height == 6 && this.m_Width != 6)
            {
                this.m_Width = (this.m_Width + 1) % 14;
                this.m_Height = 4;
            }
            else if (this.m_Height == 5)
            {
                this.m_Height += 1;
            }
            else if (this.m_Height == 4)
            {
                if (this.m_Width % 2 == 0)
                {
                    this.m_Height += 1;
                }
                else
                {
                    this.m_Height += 2;
                }
            }
            else if (this.m_Width == 6 && this.m_Height == 6)
            {
                this.m_Height = 4;
                this.m_Width = 4;
            }

            BoardSizeButton.Text = string.Format("{0} x {1}", this.m_Width, this.m_Height);
        }

        private void SettingsFormD_FormClosing_1(object sender, FormClosingEventArgs e)
        {   
            if (this.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
