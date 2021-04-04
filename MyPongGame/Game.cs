using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPongGame
{
 

    public partial class Game : Form
    {
        bool goUp; // boolean to be used to detect player up position
        bool goDown; // boolean to be used to detect player down position
        int speed = 5; // integer called speed holding value of 5
        int ballX = 5; // horizontal X speed value for the ball object 
        int ballY = 5; // vertical Y speed value for the ball object
        int score = 0;  // score for the player
        int cpuPoint = 0;  // score for the CPU
        public Game()
        {
            InitializeComponent();
        }

        //X Is pressed
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Main Controller
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                //Press up and the player moves up.
                goUp = true;
            }
            if(e.KeyCode == Keys.Down)
            {

                //Press down and the player moves down
                goDown = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if(e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

        }

        private void timerTick(object sender, EventArgs e)
        {
            playerScore.Text = "" + score;
            cpuScore.Text = "" + cpuPoint;

            Ball.Top -= ballY; // moves the ball
            Ball.Left -= ballX; // moves the ball

            CPU.Top += speed;  // Controlls the CPU


            //Keeps CPU in game range
            if(score < 5)
            {
                if(CPU.Top < 0 || CPU.Top > 455)
                {
                    speed = -speed;
                }
            }
            else
            {
                CPU.Top = Ball.Top + 30;
            }

            if(Ball.Left < 0)
            {
                Ball.Left = 434;
                ballX = -ballX;
                ballX -= 2;
                cpuPoint++;
            }

            if(Ball.Left + Ball.Width > ClientSize.Width)
            {
                Ball.Left = 434;
                ballX = -ballX;
                ballX += 2;
                score++;
            }
            if(goUp == true && Player.Top > 0)
            {
                Player.Top -= 8;
            }
            if(goDown == true && Player.Top < 455)
            {
                Player.Top += 8;
            }
            if(score > 10)
            {
                Ball.Location = new Point(434, 241);
                gameTimer.Stop();
                MessageBox.Show("You win this game");
            }
            if(cpuPoint > 10)
            {
                Ball.Location = new Point(434, 241);
                gameTimer.Stop();
                MessageBox.Show("CPU Wins, you LOSE !!!");
            }
            if(Ball.Top < 0 || Ball.Top + Ball.Height > ClientSize.Height)
            {
                ballY = -ballY;
            }
            if(Ball.Bounds.IntersectsWith(Player.Bounds) || Ball.Bounds.IntersectsWith(CPU.Bounds))
            {
                ballX = -ballX;
            }

        }
    }
}
