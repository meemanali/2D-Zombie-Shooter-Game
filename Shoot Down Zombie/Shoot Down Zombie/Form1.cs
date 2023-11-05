using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_Down_Zombie
{
    public partial class Form1 : Form
    {
        public static Form1 form;        
        public static UserControl usercmenu;
        public static UserControl usercgame;
        public Form1()
        {
            InitializeComponent();

            form = this;
            usercmenu = menu1;
            usercgame = game1;
                        
            //menu1.label1.Text = "elapsed time = " + Program.mystopwatch.ElapsedMilliseconds.ToString();
        }
    }
}
