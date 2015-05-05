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
    class Rainha : Peca
    {
        public override bool movimento(Point chegada, Point inicio, PictureBox cor, byte largura, Form isto, Dictionary<string, PictureBox> pecas)
        {
            //Fazer movimento da Torre
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
            //fazer movimento do bispo
            if (chegada.X > inicio.X) //ANDAR PARA A DIREITA Baixo
            {
                // MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                if (chegada.Y > inicio.Y)
                {
                    if ((chegada.Y - inicio.Y) == (chegada.X - inicio.X))//a distancia no x e no y tem de ser sempre igual
                    {

                        foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                        {
                            if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                            {
                                if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                {
                                    if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                    {
                                        //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                        //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
            }

            if (chegada.X > inicio.X) //ANDAR PARA A direita cima
            {
                //   MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                if (chegada.Y < inicio.Y)
                {
                    if ((chegada.Y - inicio.Y) == (inicio.X - chegada.X))
                    {
                        //MessageBox.Show("");
                      
                        foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                        {
                            //MessageBox.Show("Entrou aqui 1");
                            if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                            {
                                //MessageBox.Show("Entrou aqui 2");
                                if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                {
                                    //MessageBox.Show("Entrou aqui 3");
                                    if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                    {
                                        //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                        //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            if (chegada.X < inicio.X) //ANDAR PARA A esquerda Baixo
            {
                //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                if (chegada.Y > inicio.Y)
                {
                    if ((inicio.Y - chegada.Y) == (chegada.X - inicio.X))
                    {
                        foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                        {
                            if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                            {
                                if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                {
                                    if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                    {
                                        //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                        //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
            }

            if (chegada.X < inicio.X) //ANDAR PARA A esquerda cima
            {
                //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                if (chegada.Y < inicio.Y)
                {
                    if ((inicio.Y - chegada.Y) == (inicio.X - chegada.X))
                    {
                        foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                        {
                            if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                            {
                                if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                {
                                    if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                    {
                                        //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                        //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
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
                    //Fazer movimento da Torre
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
                    //fazer movimento do bispo
                    if (chegada.X > inicio.X) //ANDAR PARA A DIREITA Baixo
                    {
                        // MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y > inicio.Y)
                        {
                            if ((chegada.Y - inicio.Y) == (chegada.X - inicio.X))//a distancia no x e no y tem de ser sempre igual
                            {

                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }

                    if (chegada.X > inicio.X) //ANDAR PARA A direita cima
                    {
                        //   MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y < inicio.Y)
                        {
                            if ((chegada.Y - inicio.Y) == (inicio.X - chegada.X))
                            {
                                //MessageBox.Show("");
                             
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    //MessageBox.Show("Entrou aqui 1");
                                    if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                                    {
                                        //MessageBox.Show("Entrou aqui 2");
                                        if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            //MessageBox.Show("Entrou aqui 3");
                                            if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    if (chegada.X < inicio.X) //ANDAR PARA A esquerda Baixo
                    {
                        //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y > inicio.Y)
                        {
                            if ((inicio.Y - chegada.Y) == (chegada.X - inicio.X))
                            {
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }

                    if (chegada.X < inicio.X) //ANDAR PARA A esquerda cima
                    {
                        //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y < inicio.Y)
                        {
                            if ((inicio.Y - chegada.Y) == (inicio.X - chegada.X))
                            {
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            //pretas
            if (corzinha == "peaoVermelho" || corzinha == "torreVermelho" || corzinha == "cavaleiroVermelho" || corzinha == "reiVermelho" || corzinha == "bispoVermelho" || corzinha == "rainhaVermelho")
            {
                if (corzinha2 == "peaoPreto" || corzinha2 == "torrePreto" || corzinha2 == "cavaleiroPreto" || corzinha2 == "reiPreto" || corzinha2 == "bispoPreto" || corzinha2 == "rainhaPreto")
                {
                    //Fazer movimento da Torre
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
                    //fazer movimento do bispo
                    if (chegada.X > inicio.X) //ANDAR PARA A DIREITA Baixo
                    {
                        // MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y > inicio.Y)
                        {
                            if ((chegada.Y - inicio.Y) == (chegada.X - inicio.X))//a distancia no x e no y tem de ser sempre igual
                            {

                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }

                    if (chegada.X > inicio.X) //ANDAR PARA A direita cima
                    {
                        //   MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y < inicio.Y)
                        {
                            if ((chegada.Y - inicio.Y) == (inicio.X - chegada.X))
                            {
                                //MessageBox.Show("");
                               
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    //MessageBox.Show("Entrou aqui 1");
                                    if ((diagonalBaixoDireita.Location.Y - inicio.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                                    {
                                        //MessageBox.Show("Entrou aqui 2");
                                        if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            //MessageBox.Show("Entrou aqui 3");
                                            if ((diagonalBaixoDireita.Location.X < chegada.X) && (diagonalBaixoDireita.Location.X > inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    if (chegada.X < inicio.X) //ANDAR PARA A esquerda Baixo
                    {
                        //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y > inicio.Y)
                        {
                            if ((inicio.Y - chegada.Y) == (chegada.X - inicio.X))
                            {
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (diagonalBaixoDireita.Location.X - inicio.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y < chegada.Y) && (diagonalBaixoDireita.Location.Y > inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }

                    if (chegada.X < inicio.X) //ANDAR PARA A esquerda cima
                    {
                        //  MessageBox.Show("Chegada1 " + chegada.ToString() + "   Inicio1" + inicio.ToString());
                        if (chegada.Y < inicio.Y)
                        {
                            if ((inicio.Y - chegada.Y) == (inicio.X - chegada.X))
                            {
                                foreach (PictureBox diagonalBaixoDireita in pecas.Values)
                                {
                                    if ((inicio.Y - diagonalBaixoDireita.Location.Y) == (inicio.X - diagonalBaixoDireita.Location.X))
                                    {
                                        if ((diagonalBaixoDireita.Location.Y > chegada.Y) && (diagonalBaixoDireita.Location.Y < inicio.Y))//se o obstaculo esta no  meio do inico e fim no y
                                        {
                                            if ((diagonalBaixoDireita.Location.X > chegada.X) && (diagonalBaixoDireita.Location.X < inicio.X))//se o obstaculo esta no  meio do inico e fim no x
                                            {
                                                //MessageBox.Show("Y:" + inicio.Y + " < " + diagonalBaixoDireita.Location.Y + " < " + chegada.Y);
                                                //MessageBox.Show("X:" + inicio.X + " < " + diagonalBaixoDireita.Location.X + " < " + chegada.X);
                                                return false;
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            return false;


        }

        
    }
}
