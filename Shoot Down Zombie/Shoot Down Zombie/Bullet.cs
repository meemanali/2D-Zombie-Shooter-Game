using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;//by using this class we can access Color class
using System.Windows.Forms;

namespace Shoot_Down_Zombie
{
    class Bullet
    {        
        public string bulletdirection;
        public int bulletleft, bullettop;
        int bulletspeed = 100;

        PictureBox bulletpic = new PictureBox();
        Timer bullettimer = new Timer();

        public void MakeBullet(UserControl bulletusercontrol)
        {
            //MessageBox.Show(Form1.usercgame.ClientSize.ToString());

            bulletpic.BackColor = Color.Black;
            bulletpic.Size = new Size(6, 6);
            bulletpic.Left = bulletleft;
            bulletpic.Top = bullettop;
            bulletpic.Tag = "bullet";
            bulletpic.BringToFront();

            bulletusercontrol.Controls.Add(bulletpic);

            bullettimer.Interval = bulletspeed;
            bullettimer.Tick += new EventHandler (Bullettimerevent);//cause there is no gui so we r using this method
            bullettimer.Start();
        }

        private void Bullettimerevent(object sender, EventArgs e)//we need an object to send this event
        {
            if (bulletdirection == "Left")
            {
                bulletpic.Left -= bulletspeed;
            }
            else if (bulletdirection == "Right")
            {
                bulletpic.Left += bulletspeed;
            }
            else if (bulletdirection == "Down")
            {
                bulletpic.Top += bulletspeed;
            }
            else if (bulletdirection == "Up")
            {
                bulletpic.Top -= bulletspeed;
            }

            if (bulletpic.Left < 10 || bulletpic.Left > Form1.usercgame.ClientSize.Width || bulletpic.Top < 10 || bulletpic.Top > Form1.usercgame.ClientSize.Height) //width is 1350 and hieght is 750 ,limit of bullet
            {
                bullettimer.Stop();
                bullettimer.Dispose();
                bulletpic.Dispose();
                bulletpic = null;
                bullettimer = null;
            }
        }
    }
}
