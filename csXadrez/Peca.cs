using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace csXadrez
{
    [Serializable]
    abstract class Peca
    {

        private bool cor;
        // private Point movimento;

        //Construtor Vazio

        public Peca()
        {
            // TODO: Construtor por predefinir atualmente, não serve para nada
        }

        public void setCor(bool cor)
        {
            this.cor = cor;
        }

        public abstract bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string, PictureBox> pecas);
    }
}

        

