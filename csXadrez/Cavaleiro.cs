using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csXadrez
{
    [Serializable]
    class Cavaleiro : Peca
    {
        public override bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {
            //TODO fazer movimento do cavaleiro - Ja ta

            //Uma pra direita e 2 pra cima
            if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X - largura)))
            {
                return true;
            }
            //Uma pra esquerda 2 pra baixo
            if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X + largura)))
            {
                return true;
            }
            //um pra esquerda 2 pra cima
            if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X + largura)))
            {
                return true;
            }
            //um pra direita 2 pra baixo
            if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X - largura)))
            {
                return true;
            }
            //Uma 2 pra direita e 1 pra cima
            if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X - largura - largura)))
            {
                return true;
            }
            //Uma 2 pra esquerda e 1 pra baixo
            if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X + largura + largura)))
            {
                return true;
            }
            //Uma 2 pra esquerda e 1 pra cima
            if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X + largura + largura)))
            {
                return true;
            }
            //Uma 2 pra direita e 1 pra baixo
            if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X - largura - largura)))
            {
                return true;
            }
            else            // senao nao deixa jogar
            {
                return false;
            }
            //return false;
        }
        public bool comer(Point chegada, Point inicio, string corzinha, string corzinha2, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {

            //corzinha <-- corzinha2

            //Vermelhos
            if (corzinha2 == "peaoVermelho" || corzinha2 == "torreVermelho" || corzinha2 == "cavaleiroVermelho" || corzinha2 == "reiVermelho" || corzinha2 == "bispoVermelho" || corzinha2 == "rainhaVermelho")
            {
                if (corzinha == "peaoPreto" || corzinha == "torrePreto" || corzinha == "cavaleiroPreto" || corzinha == "reiPreto" || corzinha == "bispoPreto" || corzinha == "rainhaPreto")
                {
                    //Uma pra direita e 2 pra cima
                    if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                    //Uma pra esquerda 2 pra baixo
                    if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X + largura)))
                    {
                        return true;
                    }
                    //um pra esquerda 2 pra cima
                    if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X + largura)))
                    {
                        return true;
                    }
                    //um pra direita 2 pra baixo
                    if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra direita e 1 pra cima
                    if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X - largura - largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra esquerda e 1 pra baixo
                    if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X + largura + largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra esquerda e 1 pra cima
                    if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X + largura + largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra direita e 1 pra baixo
                    if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X - largura - largura)))
                    {
                        return true;
                    }
                    else            // senao nao deixa jogar
                    {
                        return false;
                    }
                }
            }
            //pretas
            if (corzinha == "peaoVermelho" || corzinha == "torreVermelho" || corzinha == "cavaleiroVermelho" || corzinha == "reiVermelho" || corzinha == "bispoVermelho" || corzinha == "rainhaVermelho")
            {
                if (corzinha2 == "peaoPreto" || corzinha2 == "torrePreto" || corzinha2 == "cavaleiroPreto" || corzinha2 == "reiPreto" || corzinha2 == "bispoPreto" || corzinha2 == "rainhaPreto")
                {
                    //Uma pra direita e 2 pra cima
                    if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                    //Uma pra esquerda 2 pra baixo
                    if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X + largura)))
                    {
                        return true;
                    }
                    //um pra esquerda 2 pra cima
                    if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X + largura)))
                    {
                        return true;
                    }
                    //um pra direita 2 pra baixo
                    if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra direita e 1 pra cima
                    if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X - largura - largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra esquerda e 1 pra baixo
                    if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X + largura + largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra esquerda e 1 pra cima
                    if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X + largura + largura)))
                    {
                        return true;
                    }
                    //Uma 2 pra direita e 1 pra baixo
                    if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X - largura - largura)))
                    {
                        return true;
                    }
                    else            // senao nao deixa jogar
                    {
                        return false;
                    }
                }
            }
            return false;


        }
    }
}
