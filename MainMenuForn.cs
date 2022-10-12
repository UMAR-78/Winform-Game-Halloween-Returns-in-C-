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
    public partial class Main_Menu_From : Form
    {
        public Main_Menu_From()
        {
            InitializeComponent();
        }

        private void Main_Menu_From_Load(object sender, EventArgs e)
        {
         Button b = new Button();
         b.BackgroundImage = Game.Properties.Resources._4183289;
         b.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         b.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         b.ForeColor = Color.White;
         b.Location = new System.Drawing.Point(350, 140);
         b.Name = "StartBUtton";
         b.Size = new Size(110,50);
         b.TabIndex = 0;
         b.Text = "Start Game";
         b.UseVisualStyleBackColor = true;
         b.Click += new EventHandler(this.button1_Click);
         this.Controls.Add(b);
         

         

            Button b1 = new Button();
            b1.BackgroundImage = Game.Properties.Resources._4183289;
            b1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b1.ForeColor = Color.White;
            b1.Location = new System.Drawing.Point(350, 190);
            b1.Name = "ExitBUtton";
            b1.Size = new Size(110,50);
            b1.TabIndex = 0;
            b1.Text = "Exit Game";
            b1.UseVisualStyleBackColor = true;
            b1.Click += new EventHandler(this.button2_Click);
            this.Controls.Add(b1);
            //       b.Click += new EventHandler(b.StartBUtton_Click);

        }
        //START button
        void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            this.Hide();
            GameForm f = new GameForm();
            f.Show();
        }
        //Exit button
        void button2_Click(object sender, EventArgs e)
        {
            Button b2 = sender as Button;
            this.Close();
        }
    }
}
