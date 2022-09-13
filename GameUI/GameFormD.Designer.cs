using System;
using System.Drawing;


namespace GameUI
{
    partial class GameFormD
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
            this.myTimer.Tick += new EventHandler(On_Tick);
            int lengthOfForm = this.m_ButtonsOfTheGame.GetLength(1) * 80 + 10;
            int widthOfForm = this.m_ButtonsOfTheGame.GetLength(0) * 75 + 150;

            this.m_CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.m_Player1ScoreLabel = new System.Windows.Forms.Label();
            this.m_Player2ScoreLabel = new System.Windows.Forms.Label();
        
            //
            // CurrentPlayer label
            // 

            this.m_CurrentPlayerLabel.AutoSize = true;
            this.m_CurrentPlayerLabel.Location = new System.Drawing.Point(20, widthOfForm-90);
            this.m_CurrentPlayerLabel.Name = "label1";
            this.m_CurrentPlayerLabel.Size = new System.Drawing.Size(118, 16);
            this.m_CurrentPlayerLabel.TabIndex = 5;
            this.m_CurrentPlayerLabel.Text = string.Format("Current Player: {0}", this.m_Player1.GetName());
            this.m_CurrentPlayerLabel.BackColor = Color.LightGreen;
            //
            // m_Player1ScoreLabel label
            // 

            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(20, widthOfForm - 60);
            this.m_Player1ScoreLabel.Name = "label1";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(118, 16);
            this.m_Player1ScoreLabel.TabIndex = 5;
            this.m_Player1ScoreLabel.Text = string.Format("{0}: {1} Pairs", this.m_Player1.GetName(), this.m_Player1.GetScore());
            this.m_Player1ScoreLabel.BackColor = Color.LightGreen;
            //
            // m_Player2ScoreLabel label
            // 

            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(20, widthOfForm - 30);
            this.m_Player2ScoreLabel.Name = "label1";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(118, 16);
            this.m_Player2ScoreLabel.TabIndex = 5;
            this.m_Player2ScoreLabel.Text = string.Format("{0}: {1} Pairs", this.m_Player2.GetName(), this.m_Player2.GetScore()); ;
            this.m_Player2ScoreLabel.BackColor = Color.LightBlue;

            // 
            // GameFormD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;         
            this.ClientSize = new System.Drawing.Size(lengthOfForm, widthOfForm);
            this.Name = "Memory Game";
            this.Text = "Memory Game";
            this.Controls.Add(this.m_CurrentPlayerLabel);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label m_CurrentPlayerLabel;
        private System.Windows.Forms.Label m_Player1ScoreLabel;
        private System.Windows.Forms.Label m_Player2ScoreLabel;
    }
}