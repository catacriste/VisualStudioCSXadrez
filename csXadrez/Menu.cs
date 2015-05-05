using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csXadrez
{
    [Serializable]
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
        private void labelTitlo_Click(object sender, EventArgs e)
        {

        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            FormChess fc = new FormChess(this);
            FormMenu.ActiveForm.Hide();
            fc.Show();
            
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
