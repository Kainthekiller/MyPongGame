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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //MainMenu Start Button
        private void StartBtn_Click(object sender, EventArgs e)
        {
            //Main Game Menu is Shown and MainMenu Is hidden
            Game gameWindow = new Game();
            gameWindow.Show();
            this.Hide();
        }
    }
}
