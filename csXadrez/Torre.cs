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
    class Torre : Peca
    {
        public override bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {
           
            if (chegada.Y == inicio.Y)//se quiseremos andar de frente
            {
                if(chegada.X < inicio.X)//jogar para esquerda
                {
                    foreach(PictureBox cima in pecas.Values)
                    {
                        if(cima.Location.Y == chegada.Y)
                        {
                            if(cima.Location.X > chegada.X)
                            {
                                if(cima.Location.X < inicio.X)
                                {

                                    return false;
                                }

                            }
                        }
                    }
                }

                if (chegada.X > inicio.X)//jogar para direita
                {
                    foreach (PictureBox baixo in pecas.Values)
                    {
                        if (baixo.Location.Y == chegada.Y)
                        {
                            if (baixo.Location.X < chegada.X)
                            {
                                if (baixo.Location.X > inicio.X)
                                {
                                    return false;
                                }

                            }
                        }
                    }
                }
                return true;
            }

            if (chegada.X == inicio.X)//Se esta na mesma linha vertical
            {
                if(chegada.Y < inicio.Y)//jogar para cima
                {
                    foreach(PictureBox esquerda in pecas.Values)
                    {
                        if (esquerda.Location.X == chegada.X)
                        {
                            if (esquerda.Location.Y > chegada.Y)
                            {
                                if (esquerda.Location.Y < inicio.Y)
                                {
                                    return false;
                                }

                            }
                        }
                    }
                }

                if (chegada.Y > inicio.Y)//jogar para baixo
                {
                    foreach (PictureBox direita in pecas.Values)
                    {
                        if (direita.Location.X == chegada.X)
                        {
                            if (direita.Location.Y < chegada.Y)
                            {
                                if (direita.Location.Y > inicio.Y)
                                {
                                    return false;
                                }

                            }
                        }
                    }
                }
                return true;
            }
            else            // senao nao deixa jogar
            {
                return false;
            }



            
        }
        public bool comer(Point chegada, Point inicio, string corzinha, string corzinha2, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {

            //corzinha <-- corzinha2

            //Vermelhos
            if (corzinha2 == "peaoVermelho" || corzinha2 == "torreVermelho" || corzinha2 == "cavaleiroVermelho" || corzinha2 == "reiVermelho" || corzinha2 == "bispoVermelho" || corzinha2 == "rainhaVermelho")
            {
                if (corzinha == "peaoPreto" || corzinha == "torrePreto" || corzinha == "cavaleiroPreto" || corzinha == "reiPreto" || corzinha == "bispoPreto" || corzinha == "rainhaPreto")
                {
                    if (chegada.Y == inicio.Y)//se quiseremos andar de frente
                    {
                        if (chegada.X < inicio.X)//jogar para esquerda
                        {
                            foreach (PictureBox cima in pecas.Values)
                            {
                                if (cima.Location.Y == chegada.Y)
                                {
                                    if (cima.Location.X > chegada.X)
                                    {
                                        if (cima.Location.X < inicio.X)
                                        {

                                            return false;
                                        }

                                    }
                                }
                            }
                        }

                        if (chegada.X > inicio.X)//jogar para direita
                        {
                            foreach (PictureBox baixo in pecas.Values)
                            {
                                if (baixo.Location.Y == chegada.Y)
                                {
                                    if (baixo.Location.X < chegada.X)
                                    {
                                        if (baixo.Location.X > inicio.X)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
                        return true;
                    }

                    if (chegada.X == inicio.X)//Se esta na mesma linha vertical
                    {
                        if (chegada.Y < inicio.Y)//jogar para cima
                        {
                            foreach (PictureBox esquerda in pecas.Values)
                            {
                                if (esquerda.Location.X == chegada.X)
                                {
                                    if (esquerda.Location.Y > chegada.Y)
                                    {
                                        if (esquerda.Location.Y < inicio.Y)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }

                        if (chegada.Y > inicio.Y)//jogar para baixo
                        {
                            foreach (PictureBox direita in pecas.Values)
                            {
                                if (direita.Location.X == chegada.X)
                                {
                                    if (direita.Location.Y < chegada.Y)
                                    {
                                        if (direita.Location.Y > inicio.Y)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
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
                    if (chegada.Y == inicio.Y)//se quiseremos andar de frente
                    {
                        if (chegada.X < inicio.X)//jogar para esquerda
                        {
                            foreach (PictureBox cima in pecas.Values)
                            {
                                if (cima.Location.Y == chegada.Y)
                                {
                                    if (cima.Location.X > chegada.X)
                                    {
                                        if (cima.Location.X < inicio.X)
                                        {

                                            return false;
                                        }

                                    }
                                }
                            }
                        }

                        if (chegada.X > inicio.X)//jogar para direita
                        {
                            foreach (PictureBox baixo in pecas.Values)
                            {
                                if (baixo.Location.Y == chegada.Y)
                                {
                                    if (baixo.Location.X < chegada.X)
                                    {
                                        if (baixo.Location.X > inicio.X)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
                        return true;
                    }

                    if (chegada.X == inicio.X)//Se esta na mesma linha vertical
                    {
                        if (chegada.Y < inicio.Y)//jogar para cima
                        {
                            foreach (PictureBox esquerda in pecas.Values)
                            {
                                if (esquerda.Location.X == chegada.X)
                                {
                                    if (esquerda.Location.Y > chegada.Y)
                                    {
                                        if (esquerda.Location.Y < inicio.Y)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }

                        if (chegada.Y > inicio.Y)//jogar para baixo
                        {
                            foreach (PictureBox direita in pecas.Values)
                            {
                                if (direita.Location.X == chegada.X)
                                {
                                    if (direita.Location.Y < chegada.Y)
                                    {
                                        if (direita.Location.Y > inicio.Y)
                                        {
                                            return false;
                                        }

                                    }
                                }
                            }
                        }
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
