using System;
namespace csXadrez
{
    partial class FormChess
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
            this.timerCoiso = new System.Windows.Forms.Timer(this.components);
            this.labelTurnos = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonAbrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerCoiso
            // 
            this.timerCoiso.Tick += new System.EventHandler(this.timerCoiso_Tick);
            // 
            // labelTurnos
            // 
            this.labelTurnos.AutoSize = true;
            this.labelTurnos.Location = new System.Drawing.Point(318, 642);
            this.labelTurnos.Name = "labelTurnos";
            this.labelTurnos.Size = new System.Drawing.Size(40, 13);
            this.labelTurnos.TabIndex = 0;
            this.labelTurnos.Text = "Turnos";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(48, 632);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 1;
            this.btnGravar.Text = "Guardar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // buttonAbrir
            // 
            this.buttonAbrir.Location = new System.Drawing.Point(547, 632);
            this.buttonAbrir.Name = "buttonAbrir";
            this.buttonAbrir.Size = new System.Drawing.Size(75, 23);
            this.buttonAbrir.TabIndex = 2;
            this.buttonAbrir.Text = "Abrir";
            this.buttonAbrir.UseVisualStyleBackColor = true;
            this.buttonAbrir.Click += new System.EventHandler(this.buttonAbrir_Click);
            // 
            // FormChess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::csXadrez.Properties.Resources.Capturar;
            this.ClientSize = new System.Drawing.Size(679, 678);
            this.Controls.Add(this.buttonAbrir);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.labelTurnos);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormChess";
            this.Text = "Xadrez";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
            this.Load += new System.EventHandler(this.FormXadrez_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerCoiso;
        private System.Windows.Forms.Label labelTurnos;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button buttonAbrir;
    }
}

