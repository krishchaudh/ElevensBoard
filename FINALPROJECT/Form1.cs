using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINALPROJECT
{
    public partial class Form1 : Form
    {
        private Button Restart;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private Button Replace;

        private static string[] SUITS = { "hearts", "diamonds", "spades", "clubs" };
        private static string[] RANKS = { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "king", "queen", "jack" };
        /** The board (Board subclass). */
        private ElevensBoard board = new ElevensBoard();
        private int totalWins = 0;
        private int totalGames = 0;
        private List<int> selections = new List<int>();
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private readonly int BOARD_SIZE = 9;
        SoundPlayer victory = new SoundPlayer("C:\\AnkitWork\\AnkitVSProject\\FINALPROJECT\\FINALPROJECT\\sounds\\mixkit-quick-win-video-game-notification-269.wav");
        SoundPlayer card = new SoundPlayer("C:\\AnkitWork\\AnkitVSProject\\FINALPROJECT\\FINALPROJECT\\sounds\\flipcard-91468.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Replace = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // Replace
            // 
            this.Replace.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Replace.Location = new System.Drawing.Point(920, 69);
            this.Replace.Name = "Replace";
            this.Replace.Size = new System.Drawing.Size(151, 37);
            this.Replace.TabIndex = 0;
            this.Replace.Text = "Replace";
            this.Replace.UseVisualStyleBackColor = false;
            this.Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Restart.Location = new System.Drawing.Point(920, 137);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(151, 37);
            this.Restart.TabIndex = 1;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(920, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 19);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(920, 250);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(151, 19);
            this.textBox2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(120, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 138);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(260, 55);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 138);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(400, 55);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(112, 138);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(540, 55);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(112, 138);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(680, 55);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(112, 138);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(120, 220);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(112, 138);
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(260, 220);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(112, 138);
            this.pictureBox7.TabIndex = 10;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(400, 220);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(112, 138);
            this.pictureBox8.TabIndex = 11;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(540, 220);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(112, 138);
            this.pictureBox9.TabIndex = 12;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1178, 391);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Replace);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Replace_Click(object sender, EventArgs e)
        {
            if(board.isLegal(selections))
            {
                board.replaceSelectedCards((selections));
                for(int i = 0; i < selections.Count; i++)
                {
                    pictureBoxes[i].ImageLocation = board.cardAt(selections[i]).getImagePath() + ".GIF";
                }
                pictureBoxes.Clear();
                selections.Clear();
            }
            textBox1.Text = board.deckSize().ToString() + " undealt cards remaining";
            if(board.gameIsWon())
            {
                MessageBox.Show("Congratulations! You Win! Click restart.");
                victory.Play();
                totalWins++;
                textBox2.Text = "You've won " + totalWins + " out of " + totalGames + " games";
            }
            if (!board.anotherPlayIsPossible())
            {
                MessageBox.Show("You have lost this game. Please click restart to start a new round.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changePicBox(0, pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changePicBox(1, pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changePicBox(2, pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changePicBox(3, pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            changePicBox(4, pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changePicBox(5, pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            changePicBox(6, pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            changePicBox(7, pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            changePicBox(8, pictureBox9);
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            board.newGame();
            if (!board.anotherPlayIsPossible())
            {
                MessageBox.Show("You have lost this game. Please click restart to start a new round.");
            }
            totalGames++;
            textBox1.Text = board.deckSize().ToString() + " undealt cards remaining";
            textBox2.Text = "You've won " + totalWins + " out of " + totalGames + " games";
            pictureBox1.ImageLocation = board.cardAt(0).getImagePath() + ".GIF";
            pictureBox2.ImageLocation = board.cardAt(1).getImagePath() + ".GIF";
            pictureBox3.ImageLocation = board.cardAt(2).getImagePath() + ".GIF";
            pictureBox4.ImageLocation = board.cardAt(3).getImagePath() + ".GIF";
            pictureBox5.ImageLocation = board.cardAt(4).getImagePath() + ".GIF";
            pictureBox6.ImageLocation = board.cardAt(5).getImagePath() + ".GIF";
            pictureBox7.ImageLocation = board.cardAt(6).getImagePath() + ".GIF";
            pictureBox8.ImageLocation = board.cardAt(7).getImagePath() + ".GIF";
            pictureBox9.ImageLocation = board.cardAt(8).getImagePath() + ".GIF";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            totalWins = 0;
            totalGames = 0;
            textBox1.Text = board.deckSize().ToString() + " undealt cards remaining";
            textBox2.Text = "You've won " + totalWins + " out of " + totalGames + " games";
            if (!board.anotherPlayIsPossible())
            {
                MessageBox.Show("You have lost this game. Please click restart to start a new round.");
            }
            board.newGame();
            pictureBox1.ImageLocation = board.cardAt(0).getImagePath() + ".GIF";
            pictureBox2.ImageLocation = board.cardAt(1).getImagePath() + ".GIF";
            pictureBox3.ImageLocation = board.cardAt(2).getImagePath() + ".GIF";
            pictureBox4.ImageLocation = board.cardAt(3).getImagePath() + ".GIF";
            pictureBox5.ImageLocation = board.cardAt(4).getImagePath() + ".GIF";
            pictureBox6.ImageLocation = board.cardAt(5).getImagePath() + ".GIF";
            pictureBox7.ImageLocation = board.cardAt(6).getImagePath() + ".GIF";
            pictureBox8.ImageLocation = board.cardAt(7).getImagePath() + ".GIF";
            pictureBox9.ImageLocation = board.cardAt(8).getImagePath() + ".GIF";
            
        }

        private void changePicBox(int index, PictureBox p)
        {

            if (!p.ImageLocation.Contains("S.GIF"))
            {
                p.ImageLocation = board.cardAt(index).getImagePath() + "S.GIF";
                card.Play();
                selections.Add(index);
                pictureBoxes.Add(p);
                if (p.ImageLocation.Contains("JO"))
                {
                    victory.Play();
                    MessageBox.Show("Congratulations! You win!");
                    totalWins++;
                    pictureBoxes.Clear();
                    selections.Clear();
                }
               
            }
            else
            {
                p.ImageLocation = board.cardAt(index).getImagePath() + ".GIF";
                card.Play();
                if (selections.Contains(index) && pictureBoxes.Contains(p))
                {
                    selections.Remove(index);
                    pictureBoxes.Remove(p);
                }
            }

            
        }

        
            
        
    }
}
