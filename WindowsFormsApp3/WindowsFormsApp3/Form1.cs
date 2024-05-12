using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }
        Player CurrentPlayer;
        Random random = new Random();
        int PlayerWinCount = 0;
        int CPUWinCount = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUTimer_Tick(object sender, EventArgs e)
        {

        }

        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                CurrentPlayer = Player.O;
                buttons[index].Text = CurrentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                CheckGame();
                CPUTimer.Stop();
            }
        }

        private void PlayerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            CurrentPlayer = Player.X;
            button.Text = CurrentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.DarkCyan;
            buttons.Remove(button);
            CheckGame();
            CPUTimer.Start();
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
               || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
               || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUTimer.Stop();
                MessageBox.Show("You Won!! Congrats", "Tic Tac Toe");
                PlayerWinCount++;
                label1.Text = "Player Wins:" + PlayerWinCount;
                RestartGame();
            }

            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
            || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
            || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
            || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
            || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
            || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
            || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
            || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUTimer.Stop();
                MessageBox.Show("You Lost!! Better luck next time. LOL", "Tic Tac Toe");
                CPUWinCount++;
                label2.Text = "PC Wins:" + CPUWinCount;
                RestartGame();
            }
            else if (buttons.Count == 0)
            {
                CPUTimer.Stop();
                MessageBox.Show("Nobody won! Try again", "Tic Tac Toe");
                RestartGame();
            }

        }
        private void RestartGame()
        {
            buttons = new List<Button>
           { button1, button2, button3, button4, button5, button6, button7, button8, button9};
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
