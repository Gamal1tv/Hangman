using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangmanSummerCamp
{
    public partial class Form1 : Form
    {
        //Globals
        List<string> words = new List<string> {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
        Stack<Button> unenabledButtons = new Stack<Button>();
        string wordToGuess;
        int listIndex;

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        //Letter Button Click Event
        private void button_Click(object sender, EventArgs e)
        {
            //if play again is not visible
            if (btnPlayAgain.Visible == false)
            {
                bool changed = false; //changed set to false
                Button letter = sender as Button;
                char[] labelChar = lblWord.Text.ToCharArray(); //convert lbl to character array

                //loop through characters in word
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    //if character is in word
                    if (Convert.ToChar(letter.Text.ToLower()) == wordToGuess[i])
                    {
                        string newLabel = ""; //empty string
                        //if it is the first letter in the word
                        if (i == 0)
                        {
                            labelChar[i] = Convert.ToChar(letter.Text); //set the first index in char array to the letter
                            //create string of the characters
                            foreach (char c in labelChar)
                            {
                                newLabel += c;
                            }
                            lblWord.Text = newLabel; //set label as string
                            changed = true; //set changed to true
                        }
                        //if it is not the first letter
                        else
                        {
                            labelChar[i + i] = Convert.ToChar(letter.Text); //set letter as index in character array
                            //create string of the characters
                            foreach (char c in labelChar)
                            {
                                newLabel += c;
                            }
                            lblWord.Text = newLabel; //set label as string
                            changed = true; //set changed to true
                        }

                    }
                }
                //If user guessed the wrong letter 
                if (changed == false)
                {
                    if (pbHangman.Image == null) //change image to 1st wrong
                    {
                        pbHangman.Image = Properties.Resources._1_Wrong;
                        pbHangman.Tag = "1Wrong";
                        changed = true;
                    }
                    else if (pbHangman.Tag == "1Wrong") //change image to 2nd wrong
                    {
                        pbHangman.Image = Properties.Resources._2_Wrong;
                        pbHangman.Tag = "2Wrong";
                        changed = true;
                    }
                    else if (pbHangman.Tag == "2Wrong") //change image to 3rd wrong
                    {
                        pbHangman.Image = Properties.Resources._3_Wrong;
                        pbHangman.Tag = "3Wrong";
                        changed = true;
                    }
                    else if (pbHangman.Tag == "3Wrong") //change image to 4th wrong
                    {
                        pbHangman.Image = Properties.Resources._4_Wrong;
                        pbHangman.Tag = "4Wrong";
                        changed = true;
                    }
                    else if (pbHangman.Tag == "4Wrong") //game over
                    {
                        pbHangman.Image = Properties.Resources.Full_Skeleton;
                        lblWinLose.Text = "YOU LOSE!!";
                        lblWinLose.Visible = true;
                        btnPlayAgain.Visible = true;
                        changed = true;
                    }

                }
                //if there are no more letter to guess - WIN
                if (!lblWord.Text.Contains("_"))
                {
                    lblWinLose.Text = "YOU WIN!!";
                    lblWinLose.Visible = true;
                    btnPlayAgain.Visible = true;
                }
                unenabledButtons.Push(letter); //add letter to stack
                letter.BackColor = Color.DarkGray; //change button color
                letter.Enabled = false; //disable button
            }
        }


        //Start Method
        private void Start()
        {
            //Pick random word from list
            Random rnd = new Random();
            listIndex = rnd.Next(words.Count - 1); 
            wordToGuess = words[listIndex];

            lblWord.Text = "";//set label to blank

            //add underscore to label for each character in word 
            for (int i = 0; i < words[listIndex].Length; i++)
            {
                if (i < words[listIndex].Length - 1)
                {
                    lblWord.Text += "_ ";
                }
                else
                {
                    lblWord.Text += "_";
                }
            }

            //set background color for each button
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackColor = Color.Gainsboro;
            }
        }

        //Play Again Button Click Event
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //make button and label invisble
            lblWinLose.Visible = false;
            btnPlayAgain.Visible = false;

            pbHangman.Image = null; //set image to blank
            //enable each button that is disabled
            foreach (Button b in unenabledButtons)
            {
                b.Enabled = true;
            }
            unenabledButtons.Clear(); //clear stack

            Start(); //start over
        }

        //Keyboard Click Method
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                btnA.PerformClick();
            }
            else if (e.KeyCode == Keys.B) 
            {
                btnB.PerformClick();
            }
            else if (e.KeyCode == Keys.C)
            {
                btnC.PerformClick();
            }
            else if (e.KeyCode == Keys.D)
            {
                btnD.PerformClick();
            }
            else if (e.KeyCode == Keys.E)
            {
                btnE.PerformClick();
            }
            else if (e.KeyCode == Keys.F)
            {
                btnF.PerformClick();
            }
            else if (e.KeyCode == Keys.G)
            {
                btnG.PerformClick();
            }
            else if (e.KeyCode == Keys.H)
            {
                btnH.PerformClick();
            }
            else if (e.KeyCode == Keys.I)
            {
                btnI.PerformClick();
            }
            else if (e.KeyCode == Keys.J)
            {
                btnJ.PerformClick();
            }
            else if (e.KeyCode == Keys.K)
            {
                btnK.PerformClick();
            }
            else if (e.KeyCode == Keys.L)
            {
                btnL.PerformClick();
            }
            else if (e.KeyCode == Keys.M)
            {
                btnM.PerformClick();
            }
            else if (e.KeyCode == Keys.N)
            {
                btnN.PerformClick();
            }
            else if (e.KeyCode == Keys.O)
            {
                btnO.PerformClick();
            }
            else if (e.KeyCode == Keys.P)
            {
                btnP.PerformClick();
            }
            else if (e.KeyCode == Keys.Q)
            {
                btnQ.PerformClick();
            }
            else if (e.KeyCode == Keys.R)
            {
                btnR.PerformClick();
            }
            else if (e.KeyCode == Keys.S)
            {
                btnS.PerformClick();
            }
            else if (e.KeyCode == Keys.T)
            {
                btnT.PerformClick();
            }
            else if (e.KeyCode == Keys.U)
            {
                btnU.PerformClick();
            }
            else if (e.KeyCode == Keys.V)
            {
                btnV.PerformClick();
            }
            else if (e.KeyCode == Keys.W)
            {
                btnW.PerformClick();
            }
            else if (e.KeyCode == Keys.X)
            {
                btnX.PerformClick();
            }
            else if (e.KeyCode == Keys.Y)
            {
                btnY.PerformClick();
            }
            else if (e.KeyCode == Keys.Z)
            {
                btnZ.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (btnPlayAgain.Enabled == true)
                    btnPlayAgain.PerformClick();
            }
        }
    }
}
