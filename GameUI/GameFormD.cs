using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace GameUI
{
    public partial class GameFormD : Form
    {
        private SettingsFormD m_SettingsForm;
        private readonly System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private readonly Board m_BoardOfTheGame;
        private readonly Button[,] m_ButtonsOfTheGame;

        private Player m_Player1;
        private Player m_Player2;

        private bool m_IsComputerPlaying;
        private bool m_IsFirstPick;
        private int m_TimerTicks;

        private Button m_FirstButtonPicked;
        private Button m_SecondButtonPicked;

        public GameFormD()
        {
            this.m_SettingsForm = new SettingsFormD();
            this.m_SettingsForm.ShowDialog();
            this.m_Player1 = new Player(m_SettingsForm.FirstPlayerName());
            this.m_Player2 = new Player(m_SettingsForm.SecondPlayerName());
            this.m_IsComputerPlaying = m_Player2.GetName() == "-computer-" ? true : false;
            this.m_BoardOfTheGame = new Board(m_SettingsForm.GetHieght(), m_SettingsForm.GetWidth());
            this.m_ButtonsOfTheGame = new Button[m_SettingsForm.GetHieght(), m_SettingsForm.GetWidth()];
            this.m_BoardOfTheGame.InitBoard();
            this.CardsToButtons();     
            IntializeGame();
        }

        public GameFormD(SettingsFormD i_SettingsOfGame)
        {
            this.m_SettingsForm = new SettingsFormD();
            this.m_SettingsForm = i_SettingsOfGame;
            this.m_Player1 = new Player(i_SettingsOfGame.FirstPlayerName());
            this.m_Player2 = new Player(i_SettingsOfGame.SecondPlayerName());
            this.m_IsComputerPlaying = m_Player2.GetName() == "-computer-" ? true : false;
            this.m_BoardOfTheGame = new Board(i_SettingsOfGame.GetHieght(), i_SettingsOfGame.GetWidth());
            this.m_ButtonsOfTheGame = new Button[i_SettingsOfGame.GetHieght(), i_SettingsOfGame.GetWidth()];
            this.m_BoardOfTheGame.InitBoard();            
            this.CardsToButtons();
            IntializeGame();          
        }

        private void makeAllButtonsDisable()
        {
            for (int i = 0; i < m_ButtonsOfTheGame.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsOfTheGame.GetLength(1); j++)
                {
                    if (!getCardFromButton(m_ButtonsOfTheGame[i, j]).GetIsVisible())
                    {
                        m_ButtonsOfTheGame[i, j].Enabled = false;
                    }
                }
            }          
        }

        private void makeAllButtonsEnable()
        {
            for (int i = 0; i < m_ButtonsOfTheGame.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsOfTheGame.GetLength(1); j++)
                {
                    if (!getCardFromButton(m_ButtonsOfTheGame[i, j]).GetIsVisible())
                    {
                        m_ButtonsOfTheGame[i, j].Enabled = true;
                    }
                }
            }
        }

        private void On_Tick(object sender, EventArgs e)
        {
            m_TimerTicks++;

            if (m_TimerTicks == 2)
            {
                Card FirstCardOfCpu = this.m_BoardOfTheGame.CpuMove();
                m_FirstButtonPicked = getButtonFromCard(FirstCardOfCpu);
                FirstCardOfCpu.TurnCardVisible();
                m_FirstButtonPicked.Text = m_FirstButtonPicked.Tag.ToString();
                m_FirstButtonPicked.BackColor = this.m_Player1.IsMyTurn() ? this.m_Player1ScoreLabel.BackColor : this.m_Player2ScoreLabel.BackColor;
                this.Update();
            }

            if (m_TimerTicks == 10)
            {
                Card secondCardOfCpu = null;
                
                 foreach (Card card in m_Player2.getCardsCounting())
                 {
                     if (card.GetValue() == Char.Parse(m_FirstButtonPicked.Text) && card != getCardFromButton(m_FirstButtonPicked))
                     {
                        secondCardOfCpu = card;
                     }
                 }
                 if (secondCardOfCpu == null)
                 {
                    secondCardOfCpu = this.m_BoardOfTheGame.CpuMove();
                 }

                m_SecondButtonPicked = getButtonFromCard(secondCardOfCpu);
                secondCardOfCpu.TurnCardVisible();
                m_SecondButtonPicked.Text = m_SecondButtonPicked.Tag.ToString();
                m_SecondButtonPicked.BackColor = this.m_Player1.IsMyTurn() ? this.m_Player1ScoreLabel.BackColor : this.m_Player2ScoreLabel.BackColor;
                this.Update();           
            }

            if (m_TimerTicks == 20)
            {
                myTimer.Stop();
                m_TimerTicks = 0;
                EndOfMove(m_FirstButtonPicked, m_SecondButtonPicked);
            }
        }

        public void CardsToButtons()
        {
            Card[,] cardsOfTheGame = this.m_BoardOfTheGame.GetCardsInGame();
            Button buttonToAdd;
            int x;
            int y = 30;

            for (int i = 0; i < this.m_BoardOfTheGame.GetCardsInGame().GetLength(0); i++)
            {
                x = 30;

                for (int j = 0; j < this.m_BoardOfTheGame.GetCardsInGame().GetLength(1); j++)
                {
                    buttonToAdd = new Button();
                    buttonToAdd.BackColor = Color.LightGray;

                    // store the value of button in tag
                    buttonToAdd.Tag = cardsOfTheGame[i, j].GetValue().ToString();
                    getCardFromButton(buttonToAdd).TurnCardInvisible();
                    buttonToAdd.Text = string.Empty;
                    buttonToAdd.Size = new Size(80, 75);
                    buttonToAdd.Location = new Point(x, y);
                    x += 100;
                    buttonToAdd.Click += new EventHandler(button_Click);
                    this.m_ButtonsOfTheGame[i, j] = buttonToAdd;
                    this.Controls.Add(this.m_ButtonsOfTheGame[i, j]);
                }

                y += 100;
            }
        }

        public void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.Enabled = !clickedButton.Enabled;
            clickedButton.BackColor = this.m_Player1.IsMyTurn() ? this.m_Player1ScoreLabel.BackColor : this.m_Player2ScoreLabel.BackColor;
            clickedButton.Text = clickedButton.Tag.ToString();
            this.Update();

            if (!(this.m_IsFirstPick))
            {
                Thread.Sleep(1000);
                this.m_SecondButtonPicked = clickedButton;
                getCardFromButton(this.m_SecondButtonPicked).TurnCardVisible();
                EndOfMove(this.m_FirstButtonPicked, this.m_SecondButtonPicked);
            }
            else
            {
                this.m_FirstButtonPicked = clickedButton;
                getCardFromButton(this.m_FirstButtonPicked).TurnCardVisible();
            }

            this.m_IsFirstPick = !(this.m_IsFirstPick);
        }

        public void EndOfMove(Button i_FirstButton, Button i_SecondButton)
        {
            Card card1 = getCardFromButton(i_FirstButton);
            Card card2 = getCardFromButton(i_SecondButton);

            if (i_FirstButton.Text == i_SecondButton.Text)
            {
                if (m_Player1.IsMyTurn())
                {
                    m_Player1.IncrementScore();
                    m_Player1ScoreLabel.Text = string.Format("{0}: {1} Pairs", this.m_Player1.GetName(), this.m_Player1.GetScore());
                }
                else if (m_Player2.IsMyTurn())
                {
                    m_Player2.IncrementScore();
                    m_Player2ScoreLabel.Text = string.Format("{0}: {1} Pairs", this.m_Player2.GetName(), this.m_Player2.GetScore());
                }
            }

            // ENTERS IF CARDS DOESNT MATCH
            else
            {
                card1.TurnCardInvisible();
                card2.TurnCardInvisible();

                if (m_Player1.IsMyTurn())
                {
                    m_Player1.EndTurn();
                    m_Player2.SetTurn();
                }

                else if (m_Player2.IsMyTurn())
                {
                    if (m_IsComputerPlaying)
                    {
                        makeAllButtonsEnable();
                    }                  
                    m_Player2.EndTurn();
                    m_Player1.SetTurn();
                }
                
                ClearButton(i_FirstButton);
                ClearButton(i_SecondButton);
                string currentPlayer = m_Player1.IsMyTurn() ? m_Player1.GetName() : m_Player2.GetName();
                this.m_CurrentPlayerLabel.BackColor = m_Player1.IsMyTurn() ? m_Player1ScoreLabel.BackColor : m_Player2ScoreLabel.BackColor;
                this.m_CurrentPlayerLabel.Text = string.Format("Current Player: {0}", currentPlayer);
                this.Update();
                m_Player2.AddToPlayerMemory(card1);
                m_Player2.AddToPlayerMemory(card2);
            }
            
            checkIfGameOverAndShowMessage();

            if (m_IsComputerPlaying && m_Player2.IsMyTurn())
            {
                ComputerMove();
            }
        }

        public void ComputerMove()
        {
            // SO THE USER CANT OPEN BUTTONS ON THE COMPUTER TURN
            makeAllButtonsDisable();
            myTimer.Start();
        }

        public static void ClearButton(Button i_ButtonToClear)
        {
            i_ButtonToClear.BackColor = Color.LightGray;
            i_ButtonToClear.Text = string.Empty;
            i_ButtonToClear.Enabled = true;
        }

        public Button getButtonFromCard(Card i_Card)
        {
            for (int i = 0; i < m_BoardOfTheGame.GetCardsInGame().GetLength(0); i++)
            {
                for (int j = 0; j < m_BoardOfTheGame.GetCardsInGame().GetLength(1); j++)
                {
                    if (m_BoardOfTheGame.GetCardsInGame()[i, j] == i_Card)
                    {
                        return m_ButtonsOfTheGame[i, j];
                    }
                }
            }

            return new Button();
        }

        public Card getCardFromButton(Button i_button)
        {
            for (int i = 0; i < m_ButtonsOfTheGame.GetLength(0); i++)
            {
                for (int j = 0; j < m_ButtonsOfTheGame.GetLength(1); j++)
                {
                    if (m_ButtonsOfTheGame[i, j] == i_button)
                    {
                        Card[,] cards = m_BoardOfTheGame.GetCardsInGame();
                        return cards[i, j];
                    }
                }
            }

            return new Card();
        }

        private void checkIfGameOverAndShowMessage()
        {
            if (m_BoardOfTheGame.IsAllCardsVisible())
            {
                string messageBox = string.Empty;

                if (m_Player1.GetScore() == m_Player2.GetScore())
                {
                    messageBox = string.Format(@"Its a tie with {0} points each!", m_Player1.GetScore());
                }

                else if (m_Player1.GetScore() > m_Player2.GetScore())
                {
                    messageBox = string.Format(@"The Winner is: {0} with {1} points", m_Player1.GetName(), m_Player1.GetScore());
                }

                else if (m_Player1.GetScore() < m_Player2.GetScore())
                {
                    messageBox = string.Format(@"The Winner is: {0} with {1} points", m_Player2.GetName(), m_Player2.GetScore());
                }

                messageBox = string.Format(@"{0} Do you want to play again?", messageBox);
                DialogResult dialogResult = MessageBox.Show(messageBox, "End of game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    GameFormD newGame = new GameFormD(this.m_SettingsForm);
                    this.Dispose();                 
                    newGame.ShowDialog();
                }
                else
                {
                    this.Dispose();
                    this.Close();
                }
            }
        }

        private void InitializeGameMembers()
        {
            m_Player1.SetTurn();
            m_Player1.SetScore();
            m_Player2.SetScore();
            m_IsFirstPick = true;
        }

        public void IntializeGame()
        {
            InitializeComponent();
            InitializeGameMembers();
        }
    }
}