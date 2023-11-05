namespace Shoot_Down_Zombie
{
    partial class Game
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblzombies = new System.Windows.Forms.Label();
            this.lblammo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.picbplayer = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblkills = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbplayer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 120;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblzombies
            // 
            this.lblzombies.AutoSize = true;
            this.lblzombies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblzombies.ForeColor = System.Drawing.SystemColors.Control;
            this.lblzombies.Location = new System.Drawing.Point(413, 5);
            this.lblzombies.Margin = new System.Windows.Forms.Padding(5);
            this.lblzombies.Name = "lblzombies";
            this.lblzombies.Size = new System.Drawing.Size(74, 18);
            this.lblzombies.TabIndex = 1;
            this.lblzombies.Text = "Zombies :";
            // 
            // lblammo
            // 
            this.lblammo.AutoSize = true;
            this.lblammo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblammo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblammo.Location = new System.Drawing.Point(5, 5);
            this.lblammo.Margin = new System.Windows.Forms.Padding(5);
            this.lblammo.Name = "lblammo";
            this.lblammo.Size = new System.Drawing.Size(64, 18);
            this.lblammo.TabIndex = 0;
            this.lblammo.Text = "Ammo : ";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(700, 5);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 22);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 100;
            // 
            // picbplayer
            // 
            this.picbplayer.Image = global::Shoot_Down_Zombie.Properties.Resources.playerup;
            this.picbplayer.Location = new System.Drawing.Point(289, 340);
            this.picbplayer.Name = "picbplayer";
            this.picbplayer.Size = new System.Drawing.Size(60, 60);
            this.picbplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbplayer.TabIndex = 4;
            this.picbplayer.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblkills, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblammo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblzombies, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(0, 34);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 32);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblkills
            // 
            this.lblkills.AutoSize = true;
            this.lblkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkills.ForeColor = System.Drawing.SystemColors.Control;
            this.lblkills.Location = new System.Drawing.Point(209, 5);
            this.lblkills.Margin = new System.Windows.Forms.Padding(5);
            this.lblkills.Name = "lblkills";
            this.lblkills.Size = new System.Drawing.Size(47, 18);
            this.lblkills.TabIndex = 3;
            this.lblkills.Text = "Kills : ";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(100)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.picbplayer);
            this.Name = "Game";
            this.Size = new System.Drawing.Size(817, 534);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyisDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyisUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbplayer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblzombies;
        private System.Windows.Forms.Label lblammo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblkills;
        private System.Windows.Forms.PictureBox picbplayer;
    }
}
