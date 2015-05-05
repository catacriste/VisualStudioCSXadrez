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
    class Peao : Peca
    {
        public override bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string,PictureBox> pecas)
        {
            if (Properties.Resources.pawnred.GetPixel(255, 181) == ((Bitmap)cor.BackgroundImage).GetPixel(255, 181))
            {
                if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X)))//se quiseremos andar uma casa para a frente (clicamos uma casa a frente)
                {
                    return true;
                   
                }
                else 
                {
                    if ((inicio.Y == (chegada.Y + largura + largura)) && (inicio.X == (chegada.X) && (inicio.Y == 52+71*6 )))//se quiseremos andar duas casas a frente e esta na linha inicial
                    {
                        return true;
                    }
                    else            // senao nao deixa jogar
                    {
                        return false;
                    }
                }
            }
            if (Properties.Resources.pawnblack.GetPixel(255, 181) == ((Bitmap)cor.BackgroundImage).GetPixel(255, 181))            {
                if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X)))
                {
                    return true;
                }
                else
                {
                    if ((inicio.Y == (chegada.Y - largura - largura)) && (inicio.X == (chegada.X) && (inicio.Y == 52+largura)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;

        }


        //Funcao que alimenta o peao(comer) (PictureBox)
        public bool comer(Point chegada, Point inicio, string corzinha, string corzinha2, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {
           
            //corzinha <-- corzinha2

            //Vermelhos
            if (corzinha2 == "peaoVermelho" || corzinha2 == "torreVermelho" || corzinha2 == "cavaleiroVermelho" || corzinha2 == "reiVermelho" || corzinha2 == "bispoVermelho" || corzinha2 == "rainhaVermelho")
            {
                if (corzinha == "peaoPreto" || corzinha == "torrePreto" || corzinha == "cavaleiroPreto" || corzinha == "reiPreto" || corzinha == "bispoPreto" || corzinha == "rainhaPreto")
                {
                    if ((inicio.Y == (chegada.Y + largura)) && (inicio.X == (chegada.X + largura) || inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                }
            }
            //pretas
            if (corzinha == "peaoVermelho" || corzinha == "torreVermelho" || corzinha == "cavaleiroVermelho" || corzinha == "reiVermelho" || corzinha == "bispoVermelho" || corzinha == "rainhaVermelho")
            {
                if (corzinha2 == "peaoPreto" || corzinha2 == "torrePreto" || corzinha2 == "cavaleiroPreto" || corzinha2 == "reiPreto" || corzinha2 == "bispoPreto" || corzinha2 == "rainhaPreto")
                {
                    if ((inicio.Y == (chegada.Y - largura)) && (inicio.X == (chegada.X + largura) || inicio.X == (chegada.X - largura)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;

                
        }
    }
}

                //compara a peca selecionada com uma branca para dizer se joga para a frente ou para tras
                //bitmap - é a imagem pixel por pixel, que é usada para criar a background das pecas e do tabuleiro
        //Metodo Abstract impões que não possa ser implementado aqui, mas sim nas classes derivadas
    
        //public abstract void movimento();
