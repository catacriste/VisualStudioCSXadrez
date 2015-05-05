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
    class Rei : Peca
    {

        public override bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {
            //MessageBox.Show("ENTREI NO MOVE" + chegada.ToString() + " " + inicio.ToString());
            if (((inicio.Y - largura) == chegada.Y) && (inicio.X == chegada.X)) //O Rei anda uma pa cima
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-1");
                return true;
            }
            if (inicio.Y + largura == chegada.Y && inicio.X == chegada.X)//O Rei anda uma pa baixo
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-2");
                return true;
            }
            if (inicio.X - largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado esquerdo
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-3");
                return true;
            }
            if (inicio.X + largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado direito
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-4");
                return true;
            }
            if (inicio.Y - largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa cima e uma pa esquerda
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-5");
                return true;
            }
            if (inicio.Y - largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa cima e uma pa direita
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-6");
                return true;
            }
            if (inicio.Y + largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa baixo e uma pa esquerda
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-7");
                return true;
            }

            if (inicio.Y + largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa baixo e uma pa direita
            {
                //MessageBox.Show("ENTREI NO MOVE-IF-8");
                return true;
            }
            return false;

        }

        public bool comer(Point chegada, Point inicio, string corzinha, string corzinha2, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {

            //corzinha <-- corzinha2

            //Vermelhos
            if (corzinha2 == "peaoVermelho" || corzinha2 == "torreVermelho" || corzinha2 == "cavaleiroVermelho" || corzinha2 == "reiVermelho" || corzinha2 == "bispoVermelho" || corzinha2 == "rainhaVermelho")
            {
                if (corzinha == "peaoPreto" || corzinha == "torrePreto" || corzinha == "cavaleiroPreto" || corzinha == "reiPreto" || corzinha == "bispoPreto" || corzinha == "rainhaPreto")
                {
                    //MessageBox.Show("ENTREI NO MOVE" + chegada.ToString() + " " + inicio.ToString());
                    if (((inicio.Y - largura) == chegada.Y) && (inicio.X == chegada.X)) //O Rei anda uma pa cima
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-1");
                        return true;
                    }
                    if (inicio.Y + largura == chegada.Y && inicio.X == chegada.X)//O Rei anda uma pa baixo
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-2");
                        return true;
                    }
                    if (inicio.X - largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado esquerdo
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-3");
                        return true;
                    }
                    if (inicio.X + largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado direito
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-4");
                        return true;
                    }
                    if (inicio.Y - largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa cima e uma pa esquerda
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-5");
                        return true;
                    }
                    if (inicio.Y - largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa cima e uma pa direita
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-6");
                        return true;
                    }
                    if (inicio.Y + largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa baixo e uma pa esquerda
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-7");
                        return true;
                    }

                    if (inicio.Y + largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa baixo e uma pa direita
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-8");
                        return true;
                    }
                    return false;
                }
            }
            //pretas
            if (corzinha == "peaoVermelho" || corzinha == "torreVermelho" || corzinha == "cavaleiroVermelho" || corzinha == "reiVermelho" || corzinha == "bispoVermelho" || corzinha == "rainhaVermelho")
            {
                if (corzinha2 == "peaoPreto" || corzinha2 == "torrePreto" || corzinha2 == "cavaleiroPreto" || corzinha2 == "reiPreto" || corzinha2 == "bispoPreto" || corzinha2 == "rainhaPreto")
                {
                    //MessageBox.Show("ENTREI NO MOVE" + chegada.ToString() + " " + inicio.ToString());
                    if (((inicio.Y - largura) == chegada.Y) && (inicio.X == chegada.X)) //O Rei anda uma pa cima
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-1");
                        return true;
                    }
                    if (inicio.Y + largura == chegada.Y && inicio.X == chegada.X)//O Rei anda uma pa baixo
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-2");
                        return true;
                    }
                    if (inicio.X - largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado esquerdo
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-3");
                        return true;
                    }
                    if (inicio.X + largura == chegada.X && inicio.Y == chegada.Y)//O Rei anda uma pa o lado direito
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-4");
                        return true;
                    }
                    if (inicio.Y - largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa cima e uma pa esquerda
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-5");
                        return true;
                    }
                    if (inicio.Y - largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa cima e uma pa direita
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-6");
                        return true;
                    }
                    if (inicio.Y + largura == chegada.Y && inicio.X - largura == chegada.X)//O Rei anda uma pa baixo e uma pa esquerda
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-7");
                        return true;
                    }

                    if (inicio.Y + largura == chegada.Y && inicio.X + largura == chegada.X)//O Rei anda uma pa baixo e uma pa direita
                    {
                        //MessageBox.Show("ENTREI NO MOVE-IF-8");
                        return true;
                    }
                    return false;
                }
            }
            return false;


        }
    }
}
