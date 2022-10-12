using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameOver_For : Form
    {
        public GameOver_For()
        {
            InitializeComponent();
        }

        private void GameOver_For_Load(object sender, EventArgs e)
        {
            Button b1 = new Button();
            b1.BackgroundImage = Game.Properties.Resources._3_game_background;
            b1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b1.ForeColor = Color.White;
            b1.Location = new System.Drawing.Point(380, 260);
            b1.Name = "ExitBUtton";
            b1.Size = new Size(100, 66);
            b1.TabIndex = 0;
            b1.Text = "Exit Game";
            b1.UseVisualStyleBackColor = true;
            b1.Click += new EventHandler(this.button1_Click);
            this.Controls.Add(b1);


            Button b2 = new Button();
            b2.BackgroundImage = Game.Properties.Resources._3_game_background;
            b2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b2.ForeColor = Color.White;
            b2.Location = new System.Drawing.Point(280, 260);
            b2.Name = "ExitBUtton";
            b2.Size = new Size(100, 66);
            b2.TabIndex = 0;
            b2.Text = "Restart Game";
            b2.UseVisualStyleBackColor = true;
            b2.Click += new EventHandler(this.button2_Click);
            this.Controls.Add(b2);
        }

        void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            this.Close();
          
        }
        void button2_Click(object sender, EventArgs e)
        {
            Button b2 = sender as Button;
            this.Hide();
            GameForm f = new GameForm();
            f.Show();
        }
    }
}
