namespace csXadrez
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.labelTitlo = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitlo
            // 
            this.labelTitlo.AutoSize = true;
            this.labelTitlo.BackColor = System.Drawing.Color.Transparent;
            this.labelTitlo.Font = new System.Drawing.Font("Poor Richard", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlo.ForeColor = System.Drawing.Color.Silver;
            this.labelTitlo.Location = new System.Drawing.Point(283, 32);
            this.labelTitlo.Name = "labelTitlo";
            this.labelTitlo.Size = new System.Drawing.Size(221, 55);
            this.labelTitlo.TabIndex = 0;
            this.labelTitlo.Text = "Red Chess";
            this.labelTitlo.Click += new System.EventHandler(this.labelTitlo_Click);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.BackgroundImage = global::csXadrez.Properties.Resources.pattern_598k1;
            this.buttonNewGame.FlatAppearance.BorderColor = System.Drawing.Color.Moccasin;
            this.buttonNewGame.FlatAppearance.BorderSize = 3;
            this.buttonNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGame.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewGame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNewGame.Location = new System.Drawing.Point(293, 133);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(193, 52);
            this.buttonNewGame.TabIndex = 1;
            this.buttonNewGame.Text = "New  Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackgroundImage = global::csXadrez.Properties.Resources.pattern_598k1;
            this.buttonQuit.FlatAppearance.BorderColor = System.Drawing.Color.Moccasin;
            this.buttonQuit.FlatAppearance.BorderSize = 3;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Font = new System.Drawing.Font("Poor Richard", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonQuit.Location = new System.Drawing.Point(293, 324);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(193, 52);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::csXadrez.Properties.Resources.mudarato;
            this.ClientSize = new System.Drawing.Size(803, 471);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelTitlo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Menu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitlo;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonQuit;
    }
}