 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace Game
{
    public partial class GameForm : Form
    {
      

       int Spider1FireCurrentTime;
       int Spider1FireGenearationTime;

        int PumkinFireCurrentTime;
        int PumpkinFireGenerationTime;

        ProgressBar HealthBar;
        PictureBox hallowenEnemey1;
        PictureBox PumpkinEnemey;
        PictureBox Player;
        PictureBox House;
        PictureBox key;
        List<PictureBox> PlayerFire = new List<PictureBox>();
        List<PictureBox> SpiderFire = new List<PictureBox>();
        List<PictureBox> PlayerPills = new List<PictureBox>();
        List<PictureBox> PumpkinFires = new List<PictureBox>();
        Label lblscore;
        string HallowenDirection = "Left";
        int score = 0;

        public GameForm()
        {
            InitializeComponent();
        }


        private void gameLoop_Tick(object sender, EventArgs e)
        {
            DetectPlayerFireCollision();
            DecrementInHealthBar();
            movePlayerLeft();
            movePlayerRight();
            movePlayerUp();
            movePlayerDown();
            MovementOFHallowen();

            PlayerFiree();
            moveFire();
            removeFireFromList();
            DetectKey();
            //SpiderFire
            Spider1FireCurrentTime++;
            if (Spider1FireCurrentTime == Spider1FireGenearationTime)
            {
                createSpiderFire();
                Spider1FireCurrentTime = 0;
            }
            
            removeSpiderFire();

            //Pumpkin Fire
            PumkinFireCurrentTime++;
            if (PumkinFireCurrentTime == PumpkinFireGenerationTime)
            {
                createPunmpkinFire(); 
                PumkinFireCurrentTime = 0;
            }
            
            RemovePumpkinFire();


            detectPillsCollision();

            if(HealthBar.Value ==0)
            {
                gameLoop.Enabled = false;
                this.Close();
                GameOver_For f = new GameOver_For();
                f.Show();
            }

            if(score == 9 && key.Visible == false && Player.Bounds.IntersectsWith(House.Bounds))
            {
                gameLoop.Enabled = false;
                this.Close();
                Won_Form f = new Won_Form();
                f.Show();
            }

            if(Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Hide();
                Main_Menu_From f = new Main_Menu_From();
                f.Show();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateLevelBar();
            CreateKey();
            CreatePills(20,20);
            CreatePills(120, 120);
            CreatePills(120, 320);
            CreatePills(220, 220);
            CreatePills(620, 120);
            CreatePills(620, 320);
            CreatePills(150 , 420);
            CreatePills(250, 420);
            CreatePills(550, 420);
            CreateHallowan();
            CreatePumpkinEnemey();
            CreatePlayer();
            CreateHouse();
            CreateScoreLabel();
           
            Spider1FireGenearationTime = 50;
            Spider1FireCurrentTime = 0;

            PumkinFireCurrentTime = 0;
            PumpkinFireGenerationTime = 50;


        }



        //--------------------------------------------PLayer Movement--------------------------------------------------
        private void movePlayerLeft()
        {
            if (Player.Left > 0)
            {
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    Player.Left -= 10;
                }
            }

        }
        private void movePlayerRight()
        {
            if (Player.Left < this.Width - Player.Width - 15)
            {
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    Player.Left += 10;
                }
            }


        }
        private void movePlayerDown()
        {
            if (Player.Top > 0)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    Player.Top -= 10;
                }
            }


        }
        private void movePlayerUp()
        {
            if (Player.Top < this.Height - Player.Height - 50)
            {
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    Player.Top += 10;
                }
            }
        }
        private void PlayerFiree()
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                CreatePLayerBullet();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------



        //------------------------------------------------Enemey Movement--------------------------------------------------
        private void MovementOFHallowen()
        {
            if (HallowenDirection == "Left")
            {
                hallowenEnemey1.Left -= 10;
            }
            if (HallowenDirection == "Right")
            {
                hallowenEnemey1.Left += 10;
            }
            if (hallowenEnemey1.Left <= 0)
            {
                HallowenDirection = "Right";
            }
            if (hallowenEnemey1.Left >= this.Width - 200)
            {
                HallowenDirection = "Left";
            }
        }
        //------------------------------------------------------------------------------------------------------------------


        //----------------------------------------------Dyanamic Controls--------------------------------------------------


        private void CreateKey()
        {
            key = new PictureBox();
            Image img = Game.Properties.Resources.key;
            key.Image = img;
            key.Width = img.Width;
            key.Height = img.Height;
            key.Location = new System.Drawing.Point(270, 0);
            key.Name = "Key";
            key.BackColor = Color.Transparent;
            key.Size = new Size(30, 30);
            key.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(key);
        }
        private void CreateHallowan()
        {
            hallowenEnemey1 = new PictureBox();
            Image img = Game.Properties.Resources.halloween_g4c8ea9547_1280;
            hallowenEnemey1.Image = img;
            hallowenEnemey1.Width = img.Width;
            hallowenEnemey1.Height = img.Height;
            hallowenEnemey1.Location = new System.Drawing.Point(345, 15);
            hallowenEnemey1.Name = "Hallowen Enmey";
            hallowenEnemey1.BackColor = Color.Transparent;
            hallowenEnemey1.Size = new Size(80, 80);
            hallowenEnemey1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(hallowenEnemey1);

        }
        private void CreatePumpkinEnemey()
        {
            PumpkinEnemey = new PictureBox();
            Image img2 = Game.Properties.Resources.pumpkin_g0ca6c1bfe_1280;
            PumpkinEnemey.Image = img2;
            PumpkinEnemey.Width = img2.Width;
            PumpkinEnemey.Height = img2.Height;
            PumpkinEnemey.Location = new System.Drawing.Point(775, 145);
            PumpkinEnemey.Name = "PumpkinEnemey";
            PumpkinEnemey.BackColor = Color.Transparent;
            PumpkinEnemey.Size = new Size(80, 80);
            PumpkinEnemey.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(PumpkinEnemey);

        }
        private void CreatePlayer()
        {
            Player = new PictureBox();
            Image img3 = Game.Properties.Resources.ghost_g0e5e97918_1280;
            Player.Image = img3;
            Player.Width = img3.Width;
            Player.Height = img3.Height;
            Player.Location = new System.Drawing.Point(0, 380);
            Player.Name = "Player";
            Player.BackColor = Color.Transparent;
            Player.Size = new Size(80, 80);
            Player.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(Player);
        }
        private void CreateHouse()
        {
            House = new PictureBox();
            Image img4 = Game.Properties.Resources.old_house_g89c916556_640;
            House.Image = img4;
            House.Width = img4.Width;
            House.Height = img4.Height;
            House.Location = new System.Drawing.Point(730, 2);
            House.Name = "House";
            House.BackColor = Color.Transparent;
            House.Size = new Size(130, 130);
            House.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(House);
        }
        private void CreateScoreLabel()
        {
            lblscore = new Label();
            lblscore.AutoSize = true;
            lblscore.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblscore.Location = new System.Drawing.Point(0, 0);
            lblscore.Name = "lblScore";
            lblscore.Size = new Size(120, 35);
            lblscore.TabIndex = 0;
            lblscore.Text = "Score:0";
            lblscore.BackColor = Color.Transparent;
            lblscore.ForeColor = Color.White;
            // lblscore.Click += new System.EventHandler(this.label1_Click);
            this.Controls.Add(lblscore);
        }
        private void CreatePLayerBullet()
        {
            PictureBox bullet = new PictureBox();
            Image img = Game.Properties.Resources.Bullet_004;
            bullet.Image = img;
            bullet.Width = img.Width;
            bullet.Height = img.Height;
            bullet.BackColor = Color.Transparent;
            bullet.Left = Player.Left + 20;
            bullet.Top = Player.Top - 20;
            bullet.Size = new Size(80, 80);
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            PlayerFire.Add(bullet);
            this.Controls.Add(bullet);
        }

        private void createSpiderFire()
        {
            PictureBox s_bullet = new PictureBox();
            Image img = Game.Properties.Resources.laserRed02;
            s_bullet.Image = img;
            s_bullet.Width = img.Width;
            s_bullet.Height = img.Height;
            s_bullet.BackColor = Color.Transparent;
            // s_bullet.Left = Player.Left + 20;
            // s_bullet.Top = Player.Top - 20;
            s_bullet.Size = new Size(10, 30);
            s_bullet.Location = new System.Drawing.Point(357, 150);
            s_bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            SpiderFire.Add(s_bullet);
            this.Controls.Add(s_bullet);
        }

        private void createPunmpkinFire()
        {
            PictureBox p_bullet = new PictureBox();
            Image img = Game.Properties.Resources.explosion_1293246__480;
            p_bullet.Image = img;
            p_bullet.Width = img.Width;
            p_bullet.Height = img.Height;
            p_bullet.BackColor = Color.Transparent;
            // s_bullet.Left = Player.Left + 20;
            // s_bullet.Top = Player.Top - 20;
            p_bullet.Size = new Size(100, 60);
            p_bullet.Location = new System.Drawing.Point(680, 170);
            p_bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            PumpkinFires.Add(p_bullet);
            this.Controls.Add(p_bullet);
        }

        private void CreatePills(int x , int y)
        {
            PictureBox pill = new PictureBox();
            Image img = Game.Properties.Resources.pill_yellow;
            pill.Image = img;
            pill.Width = img.Width;
            pill.Height = img.Height;
            pill.BackColor = Color.Transparent;
            pill.Size = new Size(30, 30);
            pill.Location = new System.Drawing.Point(x,y);
            pill.SizeMode = PictureBoxSizeMode.StretchImage;
            PlayerPills.Add(pill);
            this.Controls.Add(pill);
        }
        private void CreateLevelBar()
        {
            HealthBar = new ProgressBar();
            HealthBar.Location = new System.Drawing.Point(70, 0);
            HealthBar.Name = "Health Bar";
            HealthBar.Size = new Size(70, 23);
            HealthBar.TabIndex = 0;
            HealthBar.Value = 100;
            this.Controls.Add(HealthBar);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //-------------------------------------------Other Functions----------------------------------------------------
        private void moveFire()
        {
            foreach (PictureBox bullet in PlayerFire)
            {
                bullet.Left += 10;
            }
            foreach (PictureBox s_bullet in SpiderFire)
            {
                s_bullet.Top += 10;
            }
            foreach (PictureBox p_bullet in PumpkinFires)
            {
                p_bullet.Left -= 10;
            }

        }
        private void removeFireFromList()
        {
            for (int i = 0; i < PlayerFire.Count; i++)
            {
                if (PlayerFire[i].Right <= 0)
                {
                    PlayerFire.Remove(PlayerFire[i]);
                }
            }
        }
       
        public void removeSpiderFire() 
        {
            for (int i = 0; i < SpiderFire.Count; i++)
            {
                if (SpiderFire[i].Top >= this.Height)
                {
                    SpiderFire.Remove(SpiderFire[i]);
                }
            }
        }
        public void RemovePumpkinFire()
        {
            for (int i = 0; i < PumpkinFires.Count; i++)
            {
                if (PumpkinFires[i].Top <= 0)
                {
                    PumpkinFires.Remove(PumpkinFires[i]);
                }
            }
        }
        
        private void detectPillsCollision()
        {
            for(int i =0; i< PlayerPills.Count;i++)
            { 
                if(Player.Bounds.IntersectsWith(PlayerPills[i].Bounds) && PlayerPills[i].Visible)
                {
                    score++;
                    lblscore.Text = "Score:" + score.ToString();
                    PlayerPills[i].Visible = false;
                    this.Controls.Remove(PlayerPills[i]);
                    PlayerPills.Remove(PlayerPills[i]);
                }
            }
        }
        private void DetectKey()
        {
            if(Player.Bounds.IntersectsWith(key.Bounds))
            {
                key.Visible = false;
                this.Controls.Remove(key);
            }
        }
        private void DecrementInHealthBar()
        {
            foreach(PictureBox bullet in SpiderFire)
            {
                if(bullet.Bounds.IntersectsWith(Player.Bounds))
                {
                    HealthBar.Value -= 10;
                    bullet.Hide();
                }
            }
            foreach(PictureBox b in PumpkinFires)
            { 
                if(b.Bounds.IntersectsWith(Player.Bounds))
                {
                    HealthBar.Value -= 10;
                     b.Hide();
                }
            }
            if(Player.Bounds.IntersectsWith(hallowenEnemey1.Bounds))
            {
                HealthBar.Value -= 10;
            }
        }
        private void DetectPlayerFireCollision()
        {
            foreach(PictureBox bullet in PlayerFire)
            {
                if(bullet.Bounds.IntersectsWith(hallowenEnemey1.Bounds))
                {
                    hallowenEnemey1.Visible = false;
                    this.Controls.Remove(hallowenEnemey1);
                    
                }
            }
            foreach (PictureBox bullet in PlayerFire)
            {
                if (bullet.Bounds.IntersectsWith(PumpkinEnemey.Bounds))
                {
                    PumpkinEnemey.Visible = false;
                    this.Controls.Remove(PumpkinEnemey);


                    
                }
            }
            if(PumpkinEnemey.Visible == false )
            {
                for(int i =0; i < PumpkinFires.Count;i++)
                {
                    PumpkinFires[i].Visible = false;
                    this.Controls.Remove(PumpkinFires[i]);
                    PumpkinFires.Remove(PumpkinFires[i]);
                }
            }
        }

    }
}
