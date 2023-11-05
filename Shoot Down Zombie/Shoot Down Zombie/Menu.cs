using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_Down_Zombie
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();            
        }

        private void btnstart_Click(object sender, EventArgs e)
        {            
            Form1.usercgame.BringToFront();
            Form1.usercgame.Enabled = true;//when we do enabled=true ,then we also have to write focus() after it (so we can use events which work when the tool/usercontrol,control is active control of form
            Form1.usercgame.Focus();//we r using this so our event work there
            this.Enabled = false;            

            Game.timer.Enabled = true;
            Game.timer.Start();

            
            //below 2 lines r not working:
            //Game obj = new Game();
            //obj.BringToFront();            
        }

        private void btnoptions_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.SendToBack();
            tableLayoutPanel3.BringToFront();

            lblstate.Text = "Options";
            this.BackgroundImage = Properties.Resources.wp4387941;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Form1.form.Close();

            //below is not working for closing form
            //Form1 obj = new Form1();
            //obj.Close();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.BringToFront();
            tableLayoutPanel3.SendToBack();

            lblstate.Text = "Main Menu";
            this.BackgroundImage = Properties.Resources.ss_eaab0951300f3cfe5f1e582c7f99f23f9;
        }
    }
}
