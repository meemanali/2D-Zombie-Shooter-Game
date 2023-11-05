namespace Shoot_Down_Zombie
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu1 = new Shoot_Down_Zombie.Menu();
            this.game1 = new Shoot_Down_Zombie.Game();
            this.SuspendLayout();
            // 
            // menu1
            // 
            this.menu1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menu1.BackgroundImage")));
            this.menu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(808, 534);
            this.menu1.TabIndex = 1;
            // 
            // game1
            // 
            this.game1.AllowDrop = true;
            this.game1.AutoSize = true;
            this.game1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(100)))));
            this.game1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game1.Location = new System.Drawing.Point(0, 0);
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(808, 534);
            this.game1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 534);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.game1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();


            //after below compiler goes to form1
            //System.Windows.Forms.MessageBox.Show("Form1.designer elapsed time = " + Program.mystopwatch.ElapsedMilliseconds.ToString());
        }

        #endregion

        private Menu menu1;
        private Game game1;        
    }
}

