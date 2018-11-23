using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region variables 

        // Variable, welche die generierte Zufallszahl aufnimmt 
        int _number = 0;

        // Variable,in welcher die Anzahl Versuche gespeichert werden
        int _countOfTrials = 0;

        // Liste, welche alle vom Benutzer eingegebenen Zahlen speichert 
        List<int> _guessed = new List<int>();

        #endregion

        #region constructors 

        public Form1()
        {
            InitializeComponent();
        }

        #endregion 

        #region event handler 

        private void buttonGuess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGuess.Text))
                return;

            int guess = Convert.ToInt32(textBoxGuess.Text);

            if (_guessed.Contains(guess))
                MessageBox.Show("Mit dieser Zahl haben Sie es schon einmal versucht.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                _guessed.Add(guess);

            if (guess.Equals(_number))
            {
                textBoxMessage.Text = "Zahl stimmt! (" + _countOfTrials.ToString() + " Versuche)";
                buttonGuess.Enabled = false;
                return;
            }

            if (guess > _number)
                textBoxMessage.Text = "Zahl zu gross!";
            else if (guess < _number)
                textBoxMessage.Text = "Zahl zu klein!";

            textBoxGuess.Focus();
            textBoxGuess.SelectAll();

            _countOfTrials++;
        }

        private void textBoxGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow the user to add numbers and {Backspace}
            if (!char.IsDigit(e.KeyChar) && !e.KeyChar.Equals('\b'))
                e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Zufallszahl zwischen 1 und 100 generieren 
            _number = (new Random().Next(1, 101));
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 
    }
}
