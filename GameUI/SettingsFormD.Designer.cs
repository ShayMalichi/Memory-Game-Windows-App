
namespace GameUI
{
    partial class SettingsFormD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.AgainstComputerButton = new System.Windows.Forms.Button();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.FirstPlayerTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.AccessibleName = "";
            this.StartButton.BackColor = System.Drawing.Color.LimeGreen;
            this.StartButton.Location = new System.Drawing.Point(394, 170);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(76, 32);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // AgainstComputerButton
            // 
            this.AgainstComputerButton.AccessibleName = "";
            this.AgainstComputerButton.Location = new System.Drawing.Point(315, 45);
            this.AgainstComputerButton.Name = "AgainstComputerButton";
            this.AgainstComputerButton.Size = new System.Drawing.Size(155, 34);
            this.AgainstComputerButton.TabIndex = 1;
            this.AgainstComputerButton.Text = "Against a Friend";
            this.AgainstComputerButton.UseVisualStyleBackColor = true;
            this.AgainstComputerButton.Click += new System.EventHandler(this.againstComputerButton_Click);
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.AccessibleName = "";
            this.BoardSizeButton.BackColor = System.Drawing.Color.SlateBlue;
            this.BoardSizeButton.Location = new System.Drawing.Point(24, 115);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(118, 77);
            this.BoardSizeButton.TabIndex = 2;
            this.BoardSizeButton.Text = "4 x 4";
            this.BoardSizeButton.UseVisualStyleBackColor = false;
            this.BoardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // FirstPlayerTextBox
            // 
            this.FirstPlayerTextBox.AccessibleName = "FirstPlayerTextBox";
            this.FirstPlayerTextBox.Location = new System.Drawing.Point(183, 22);
            this.FirstPlayerTextBox.Name = "FirstPlayerTextBox";
            this.FirstPlayerTextBox.Size = new System.Drawing.Size(109, 22);
            this.FirstPlayerTextBox.TabIndex = 3;
            // 
            // SecondPlayerTextBox
            // 
            this.SecondPlayerTextBox.AccessibleName = "";
            this.SecondPlayerTextBox.BackColor = System.Drawing.Color.LightGray;
            this.SecondPlayerTextBox.Enabled = false;
            this.SecondPlayerTextBox.Location = new System.Drawing.Point(183, 51);
            this.SecondPlayerTextBox.Name = "SecondPlayerTextBox";
            this.SecondPlayerTextBox.Size = new System.Drawing.Size(109, 22);
            this.SecondPlayerTextBox.TabIndex = 4;
            this.SecondPlayerTextBox.Text = "-computer-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Board Size:";
            // 
            // SettingsFormD
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 226);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecondPlayerTextBox);
            this.Controls.Add(this.FirstPlayerTextBox);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.AgainstComputerButton);
            this.Controls.Add(this.StartButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFormD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game -Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormD_FormClosing_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button AgainstComputerButton;
        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.TextBox FirstPlayerTextBox;
        private System.Windows.Forms.TextBox SecondPlayerTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}