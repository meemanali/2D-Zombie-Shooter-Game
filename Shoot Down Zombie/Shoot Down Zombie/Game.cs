using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WMPLib;

using System.Diagnostics;

namespace Shoot_Down_Zombie
{
    public partial class Game : UserControl
    {       
        public static Timer timer;//it creating complexity between timer and timer

        WindowsMediaPlayer windowmediaplayer = new WindowsMediaPlayer();

        bool goleft, goright, goup, godown;       
        string facing = "Up";
        int score = 0, speed = 60, ammo = 10, zombiespeed = 18;//, playerhealth = 100;        

        public Random random = new Random();

        ListBox zombielist = new ListBox();
        
        public Game()
        {
            InitializeComponent();
            timer = timer1;            

            //it will appear when we open game it means this method ( Game() ) will load when we open game thus it effects speed of our game
            //MessageBox.Show("Test");

            for (int i = 0; i < 6; i++)
            {
                makezombie();
            }
        }


        //in key press event ie (Game_KeyPress(object sender, KeyPressEventArgs e)) we were not getting e.keycode but in keyup event we got this
        private void Game_KeyisUp(object sender, KeyEventArgs e)
        {
            //this event is not considering up,down,right,left keys as keys so we use a,s,w,d keys fro moving of player
            if (e.KeyCode == Keys.A)
                goleft = false;

            else if (e.KeyCode == Keys.D)
                goright = false;

            else if (e.KeyCode == Keys.W)
                goup = false;

            else if (e.KeyCode == Keys.S)
                godown = false;            
                       

            //we also use here e.keyvalue (but then use convert.toint)
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
                this.Enabled = false;

                DialogResult result = MessageBox.Show("Resume the game", "Pause", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    Form1.usercmenu.BringToFront();
                    Form1.usercmenu.Enabled = true;                           
                }
                else
                {
                    timer1.Start();
                    this.Enabled = true;
                    this.Focus();
                }
            }
        }        
        
        private void Game_KeyisDown(object sender, KeyEventArgs e)
        {                        
            if (e.KeyCode == Keys.A)
            {
                goleft = true;
                facing = "Left";
                picbplayer.Image = Properties.Resources.playerleft;
            }
            if (e.KeyCode == Keys.D)
            {
                goright = true;
                facing = "Right";
                picbplayer.Image = Properties.Resources.playerright;
            }
            if (e.KeyCode == Keys.W)
            {
                goup = true;
                facing = "Up";
                picbplayer.Image = Properties.Resources.playerup;
            }
            if (e.KeyCode == Keys.S)
            {
                godown = true;
                facing = "Down";
                picbplayer.Image = Properties.Resources.playerdown;
            }

            if (e.KeyCode == Keys.Space && ammo > 0)//remove ammo condition for unlimited bullets
            {
                shootbullet(facing);
                //ammo--; // now ammo will not end

                //if (ammo<1)
                //    dropammo();        

                //if (true) //if u want unlimited bullets then make this boolean value true and comment below condition
                //    ammo++;
            }

            if (e.KeyCode == Keys.Z)            
                makezombie();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            lblammo.Text = "Ammo : " + ammo;
            lblzombies.Text = "Zombies : " + zombiecounter();
            lblkills.Text = "Kills : " + score;            

            if (progressBar1.Value < 4)
            {
                //picbplayer.Image = Properties.Resources._3vC34TA;//dead gif
                timer1.Stop();
                this.Enabled = false;              

                //below removes zombies
                foreach (Control item in this.Controls) //if we set var instead of Control then we dont get properties of item in below condition
                    if (item is PictureBox && (string)item.Tag == "zombie")
                        this.Controls.Remove(item);                

                //player dead music
                windowmediaplayer.URL = @"E:\Courses & Programming\C#\C# Programs\Games By Me\Shoot Down Zombie\Shoot Down Zombie\Resources\Sounds\Scream Of Dying Man Sound Effect HD _ No Copyright(MP3_160K).mp3";
                windowmediaplayer.controls.play();

                DialogResult result = MessageBox.Show("Start A New Game", "Score : " + score, MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                ammo = 10;
                score = 0;
                progressBar1.Value = 100;

                if (result == DialogResult.No)
                {
                    Form1.usercmenu.BringToFront();
                    Form1.usercmenu.Enabled = true;                    
                    this.Enabled = false;
                }                
                else if (result == DialogResult.Yes)
                {                    
                    for (int i = zombiecounter(); i < 6; i++)
                        makezombie();                    
                    
                    zombielist.Items.Clear();

                    goleft = goright = goup = godown = false;

                    this.Enabled = true;
                    this.Focus();

                    timer1.Start();
                }
            }


            if (goleft == true && picbplayer.Left > 0)            
                picbplayer.Left -= speed;            

            if (goright == true && picbplayer.Left + picbplayer.Width < this.ClientSize.Width)            
                picbplayer.Left += speed;
            
            if (goup == true && picbplayer.Top > 50)//it stops picbplayer before 50p from above           
                picbplayer.Top -= speed;
            
            if (godown == true && picbplayer.Top + picbplayer.Height < this.ClientSize.Height)            
                picbplayer.Top += speed;            

            foreach (Control picingame in this.Controls)//We cant write picturebox instaed of control (so sad). if we use var instead of control then we cant get properties of item after writing dot after item
            {
                if (picingame is PictureBox && (string)picingame.Tag == "ammo")
                {
                    if (picbplayer.Bounds.IntersectsWith(picingame.Bounds))
                    {                        
                        picingame.Dispose();                        
                        ammo += 5;

                        windowmediaplayer.URL = @"E:\Courses & Programming\C#\C# Programs\Games By Me\Shoot Down Zombie\Shoot Down Zombie\Resources\Gun Clock Sound Effect _ Gun Sound Effect(MP3_320K).mp3";
                        windowmediaplayer.controls.play();                        
                    }                    
                }

                if (picingame is PictureBox && (string)picingame.Tag == "zombie")
                {                    
                    if (picbplayer.Bounds.IntersectsWith(picingame.Bounds) && progressBar1.Value > 0)
                        progressBar1.Value -= 2;

                    //windowmediaplayer.URL = @"E:\Courses & Programming\C#\C# Programs\Games By Me\Shoot Down Zombie\Shoot Down Zombie\Resources\Crunch sound effect _ No copyright(MP3_160K).mp3";
                    //windowmediaplayer.controls.play();
                    

                    //below moves zombies towarads player
                    if (picingame.Left > picbplayer.Left)
                    {
                        picingame.Left -= zombiespeed;
                        ((PictureBox)picingame).Image = Properties.Resources.faceplayer_left;//if we do this conversion then x get the properties of picturebox
                    }
                    if (picingame.Left < picbplayer.Left)
                    {
                        picingame.Left += zombiespeed;
                        ((PictureBox)picingame).Image = Properties.Resources.faceplayer_right;
                    }
                    if (picingame.Top > picbplayer.Top)
                    {
                        picingame.Top -= zombiespeed;
                        ((PictureBox)picingame).Image = Properties.Resources.faceplayer_up;
                    }
                    if (picingame.Top < picbplayer.Top)
                    {
                        picingame.Top += zombiespeed;
                        ((PictureBox)picingame).Image = Properties.Resources.faceplayer_down;
                    }

                    if (zombiecounter() > 6)
                        this.Controls.Remove(picingame);
                    else if (zombiecounter() < 6)
                    {
                        for (int i = zombiecounter(); i < 6; i++)
                        {
                            makezombie();
                        }
                    }
                }
                

                foreach (Control picingame2 in this.Controls) // we cant write picturebox instead of control cause there are other controls other than picturebox
                {
                    if (picingame2 is PictureBox && (string)picingame2.Tag == "bullet" && picingame is PictureBox && (string)picingame.Tag == "zombie") //
                    {
                        if (picingame.Bounds.IntersectsWith(picingame2.Bounds))
                        {
                            score++;
                            makezombie();

                            picingame.Dispose();
                            picingame2.Dispose();

                            //windowmediaplayer.URL = @"E:\Courses & Programming\C#\C# Programs\Games By Me\Shoot Down Zombie\Shoot Down Zombie\Resources\SMASH - sound effect(MP3_128K).mp3";
                            //windowmediaplayer.controls.play();                            

                            //windowmediaplayer.URL = @"F:\Eeman Data\Songs\PEAKY BLINDERS music.mp3";

                            //this.Controls.Remove(picingame);
                            //this.Controls.Remove(picingame2);                            
                        }
                    }

                    //by below method zombies r running away from our player
                    //if (picingame2.Tag == "zombie" && picingame.Tag == "zombie") //picingame2 is PictureBox && (string) && picingame is PictureBox && 
                    //{
                    //    if (picingame.Bounds.IntersectsWith(picingame2.Bounds))
                    //    {
                    //        //picbzombie.Top += 5;
                    //        //picbzombie.Left += 5;
                    //    }                        
                    //}
                    
                }//inner foreach end
            }//ist foreach end            


            //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString()); // results 71,75,81 etc

            //if (zombiecounter() < 3)
            //{
            //    makezombie();//adding new zombies
            //}
        }//timer end

        private void shootbullet(string direction)
        {
            Bullet shootbullet = new Bullet();
            shootbullet.bulletdirection = direction;
            shootbullet.bulletleft = picbplayer.Left + (picbplayer.Width / 2);
            shootbullet.bullettop = picbplayer.Top + (picbplayer.Height / 2);
            shootbullet.MakeBullet(this);
        }        

        private void dropammo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.bullet;
            ammo.SizeMode = PictureBoxSizeMode.StretchImage;
            ammo.Size = new Size(35, 35);
            ammo.Left = random.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = random.Next(70, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            picbplayer.BringToFront();
        }

        private int zombiecounter()
        {
            zombielist.Items.Clear();
            foreach (Control item in this.Controls)
            {
                if (item is PictureBox && (string)item.Tag == "zombie")
                {
                    zombielist.Items.Add(item);
                }
            }
            return zombielist.Items.Count;
        }

        public void makezombie()
        {
            PictureBox picbzombie = new PictureBox();
            picbzombie.Tag = "zombie";
            picbzombie.Image = Properties.Resources.faceplayer_up;
            picbzombie.Size = new Size(60, 60);
            picbzombie.SizeMode = PictureBoxSizeMode.StretchImage;
            picbzombie.Left = random.Next(10, 1200);
            picbzombie.Top = random.Next(10, 700);
            this.Controls.Add(picbzombie);//Form1.usercgame is not working so we "this" keyword
            
            picbplayer.BringToFront();
        }

        
        
        //code (of youtuber) inside foreach loop

        //makezombie();

        //for (int i = 0; i < 3; i++)
        //{
        //    makezombie();
        //}
        //foreach (Control x in this.Controls)
        //{
        //    if (x is PictureBox && (string)x.Tag == "ammo")
        //    {
        //        if (picbplayer.Bounds.IntersectsWith(x.Bounds))
        //        {
        //            this.Controls.Remove(x);
        //            ((PictureBox)x).Dispose();
        //            ammo += 5;
        //        }
        //    }


        //    if (x is PictureBox && (string)x.Tag == "zombie")
        //    {
        //          if (true)
        //          {

        //          }

        //        if (x.Left > picbplayer.Left)
        //        {
        //            x.Left -= zombiespeed;
        //            ((PictureBox)x).Image = Properties.Resources.faceplayer_left;//if we do this conversion then x get the properties of picturebox
        //        }
        //        if (x.Left < picbplayer.Left)
        //        {
        //            x.Left += zombiespeed;
        //            ((PictureBox)x).Image = Properties.Resources.faceplayer_right;
        //        }
        //        if (x.Top > picbplayer.Top)
        //        {
        //            x.Top -= zombiespeed;
        //            ((PictureBox)x).Image = Properties.Resources.faceplayer_up;
        //        }
        //        if (x.Top < picbplayer.Top)
        //        {
        //            x.Top += zombiespeed;
        //            ((PictureBox)x).Image = Properties.Resources.faceplayer_down;
        //        }
        //    }


        //    foreach (Control j in Form1.usercgame.Controls)
        //    {
        //        if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
        //        {
        //            if (x.Bounds.IntersectsWith(j.Bounds))
        //            {
        //                score++;

        //                Form1.usercgame.Controls.Remove(j);
        //                ((PictureBox)j).Dispose();
        //                Form1.usercgame.Controls.Remove(x);
        //                ((PictureBox)x).Dispose();
        //                zombielist.Remove(((PictureBox)x));
        //                //makezombie();
        //            }
        //        }
        //    }
        //}




        //private void Restartgame()
        //{
        //    picbplayer.Image = Properties.Resources.playerup;

        //    foreach (PictureBox i in zombielist)
        //    {
        //        Form1.usercgame.Controls.Remove(i);
        //    }

        //    zombielist.Clear();

        //    //for (int i = 0; i < 3; i++)
        //    //{
        //    //    makezombie();
        //    //}

        //    godown = false;
        //    goleft = false;
        //    goup = false;
        //    godown = false;

        //    playerhealth = 100;
        //    score = 0;
        //    ammo = 10;

        //    //timer1.Start();
        //}

        //private void makezombie()
        //{
        //    //PictureBox zombie = new PictureBox();            
        //    pictureBox1.Tag = "zombie";
        //    ///pictureBox1.Image = Properties.Resources.faceplayer_down;
        //    ///pictureBox1.Size = new Size(45, 45);
        //    pictureBox1.Left = random.Next(0, 1350);
        //    pictureBox1.Top = random.Next(0, 750);
        //    ///pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    zombielist.Add(pictureBox1);
        //    //Form1.usercgame.ActiveControl.Select();//incremented by me,throughing execption
        //    Form1.usercgame.Controls.Add(pictureBox1);
        //    ///picbplayer.BringToFront();
        //}
    }
}