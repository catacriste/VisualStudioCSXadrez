using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csXadrez
{
    [Serializable]
    public partial class FormChess : Form
    {
        /// <summary>
        /// Aplicação/Jogo do xadrez, FORM DE JOGO utilizada para fazer todas as atribuições necessárias
        /// O movimento é feito em classes existentes de cada peça, a função de clicar existente aqui chamada outra para seu uso *Explicado mais a baixo*
         /// </summary>

        //TODO: resolver os bugs das proteções das peças (devido aos pixeis) - Ja ta
        //TODO: fazer a proteção pro cavaleiro, bispo e rainha - Ja ta
        //TODO: Fazer os turnos dos pretos e vermelhos
        /*INICIALIZAÇÃO DAS VARIAVEIS PRINCIPAIS (CONSTANTES E OBJETOS
         * UTILIZAÇÃO DE VÁRIAS CONSTANTES PARA DETERMINAR LARGURAS DAS LABELS E PICUTURE BOX
         * Utiliza-se a Picture Box para desenhar o tabuleiro e labels para as letras e numeros das colunas
         * */


        //Form main é utilizada para enviar esta form para a formPrincipal que é o menu.
        //Lá é utilizada para , quando a aplicação é encerrada , envia esta form para lá e fecha o processo da aplicação
        
        Form main;
        SaveGame salvar;
        //Colums e rows são variaveis sem numero definido, e são usadas pra definir o ciclo for de (8 por 8)
        //O seu tipo é byte, semelhante a um inteiro mas de valor máximo mais pequeno, o que tem como objetivo
        //ocupar menos espaço na memória. 8 por 8 é tabuleiro (64) que define 64 pictureBox sendo que cada uma
        //é um quadradinho do tabuleiro onde cada peca poderá ou deve estar.
        private byte colums;
        private byte row;
        //*************Constantes Básicas atribudas  para facil edição posteriormente ******************
        private byte larguraPanel = 71;
        private byte labelSizeX = 25;
        private byte labelSizeY= 24;
        private bool turnos = true; //Se true , vez dos brancos ,se false vez dos pretos

        //Esta picutreBox (selecionada) tem como objetivo enviar a picutre box ( quando o jogar seleciona a Peça)
        //e enviar para a função de movimento se está ou não , selecionada 
        private PictureBox selecionada;
       // private PictureBox peca;

        //Array do tabuleiro de 8x8 para utilizar na definição do tababuleiro (apenas auxiliar)
        private Bitmap[,] tabuleiro = new Bitmap[8, 8];
       // Dictionary<int, string> tabuleiro = new Dictionary<int, string>();
        private Dictionary<string, PictureBox> listaPecas = new Dictionary<string, PictureBox>();
        

        /*Objetos instanciados apenas como finalidade de utilizar, por enquanto, para enviar os parametros (variaveis)
         * para a função movimento de cada peça*/
        private Peao pecaPeao = new Peao();
        private Torre pecaTorre = new Torre();
        private Rei pecaRei = new Rei();
        private Bispo pecaBispo = new Bispo();
        private Cavaleiro pecaCavaleiro = new Cavaleiro();
        private Rainha pecaRainha = new Rainha();

        private  PictureBox caixinha = new PictureBox();
       

        public FormChess(Form f)
        {
            InitializeComponent();
            
            main = f; //Recebido da form
            
        }

        private void FormXadrez_Load(object sender, EventArgs e)
        {
            //saveFile.FileName = "Sem Título.bin";
            //saveFile.Filter = "Bin files (*.bin)|*.bin|All files (*.*)|*.*";
          //  pictureMortosVer.MouseEnter += pictureBoxMouseHover;

          //  pictureMortosVer.SendToBack(caixinha);

            //Define a caixa
          /*  caixinha.BackColor = Color.Transparent;
            caixinha.Location = new Point(pictureMortosVer.Location.X, pictureMortosVer.Location.Y + 10);
            caixinha.Size = new Size(250, 250);
            caixinha.Visible = false;*/
           
            


           for(colums = 0; colums < 8; colums++)
           {
               /***********************
                * Label corresponde aos numeros gerados automaticamente
                * Coresponde  à definição gráfica da labelComumNumber
                * 
                * 
                ***********************/
               
               Label labelColumNumber = new Label();
               labelColumNumber.Size = new Size(labelSizeX, labelSizeY);
               labelColumNumber.Text = "1";
               labelColumNumber.Font = new Font("Poor Richard", 15);
               labelColumNumber.BackColor = Color.Transparent;
               labelColumNumber.ForeColor = Color.White;

               //Define a posição da label da  linha dos numeros completa de 8-1 na vertical
               labelColumNumber.Location = new Point(10, (colums * larguraPanel) + (int)(larguraPanel * 0.35) + 52);
               
               labelColumNumber.Text = "" + (8 - colums); //Altera o valor que essa label tem entre 8 e o numero total da variavel colums
               this.Controls.Add(labelColumNumber); // Adiciona a label à form
               /***********************
                * Label corresponde as Letras gerados automaticamente
                * 
                * 
                * 
                ***********************/
               //Declaração deste o tamanho , tipo etc das labels dos numeros 
               Label labelRowAtoH = new Label();

               labelRowAtoH.Size = new Size(labelSizeX, labelSizeY);
               labelRowAtoH.Text = "1";
               labelRowAtoH.Font = new Font("Poor Richard", 15);
               labelRowAtoH.BackColor = Color.Transparent;
               labelRowAtoH.ForeColor = Color.White;

               //Mostra as letras na horizontal 
               labelRowAtoH.Location = new Point((colums * larguraPanel) + (int)(larguraPanel * 0.35) + 52, 10);
               labelRowAtoH.Text = "" + (8 - colums);
               this.Controls.Add(labelRowAtoH); // Adiciona a label à form

               /*Switch precorre o for onde é definido, para além do tabuleiro, também na horizontal(row) as
                * linhas com os numero de cada letra, supostamente cada letra é um numero ,e o switch detecta
                * caso por exemplo , o colums tiver a 0 a row está no instante inicial , é onde deveria estar o A
                * substitui esse numero de 1 a 8 pela letra , sabendo sempre que a row que vai de 0-7 as letras e numeros
                * que aparecem são de 1-8 e que o Numero 1 corresponde à instancia 0 do for.
                */
               switch(colums)
               {
                   //Cases para alterar o numero consoante a letra
                   case 0:  labelRowAtoH.Text = "A";
                       break;

                   case 1: labelRowAtoH.Text = "B";
                       break;

                   case 2: labelRowAtoH.Text = "C";
                       break;

                   case 3: labelRowAtoH.Text = "D";
                       break;

                   case 4: labelRowAtoH.Text = "E";
                       break;

                   case 5: labelRowAtoH.Text = "F";
                       break;

                   case 6: labelRowAtoH.Text = "G";
                       break;

                   case 7: labelRowAtoH.Text = "H";
                       break;

               }


               for(row= 0; row < 8; row++)
               {
                  
                  
                  // Label labelRow

                   //Cria o "tabuleiro" usando for duplo
                   //Usa-se picture box e cria-se um tabuleiro de 8x8
                   PictureBox newPictureBox = new PictureBox(); //Declaração da Picture Box

                   //Determina o tamanho de cada "Quadrado" (dos 64) gerados em largura e altura (Iguais pois é um quadrado)
                   newPictureBox.Size = new Size(larguraPanel, larguraPanel);
                   //O if serve para defenir onde vai ser declarado o "padrão"(cor) de cada quadradinho
                   //usa-se percentil para definir que caso der numero impar igual a 0 , define primeiro padrão branco
                   //Se o if for == 2 ele define a vermelha primeiro, o primeiro PictureB é branco ao do lado será vermelho e
                   //Assim suscesivamente
                   if ((colums + row) % 2 == 0)
                   {
                       newPictureBox.BackgroundImage = Properties.Resources.pattern_diry;
                       
                   }
                   else
                   {
                       newPictureBox.BackgroundImage = Properties.Resources.pattern_64qv;
                      
                   }
                   /*
                    * Define a onde será começado a desenhar o tabuleiro, a partir do nr da variavel colmums(comprimento) +(largura do painel)
                    * + a altura (y) de 52. igualmente para o Row (largura)*/
                   newPictureBox.Location = new Point(colums * (larguraPanel)+52, row * (larguraPanel)+52); 
                   newPictureBox.MouseEnter += tabuleiro_AoMeterRato;  //Função executada para fazer o hover ao Passar o rato
                   newPictureBox.MouseLeave += tabuleiro_AoMeterSair;  //Função executada para fazer o hover ao tirar o rato(volta o original)
                   this.Controls.Add(newPictureBox);  // Adiciona ao controls da form estas Picture Box criadas
                   

                   //If para selecionar quando o valor da Colums for igual a 1 (primeira coluna)
                   if(colums == 1)
                   {

                       //Cria o para a linha inteira com peões
                       PictureBox pawnBlack = new PictureBox();
                       pawnBlack.Name = "pawnBlack" + colums + row;
                       pawnBlack.BackgroundImage = Properties.Resources.pawnblack;       // Declara uma imagem externa da imagem do peão

                       pawnBlack.BackgroundImageLayout = ImageLayout.Stretch;            // Ajusta a imagem ào quadrado do tabuleiro respectivo
                       pawnBlack.BackColor = Color.Transparent;                          // Define a cor de fundo da imagem, ela irá tomar o valor do fundo da form (infelizmente)
                       pawnBlack.Size = new Size(larguraPanel, larguraPanel);                                // Tamanho da imagem ( igual ao do quadrado)
                       pawnBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);       //Determina a localização do mesmo no tabuleiro ( na Posição X que a variável está no for
                    // tabuleiro[1, 0] = (Bitmap)pawn.BackgroundImage;              // determina no array a imagem
                       tabuleiro[colums, row] = (Bitmap)pawnBlack.BackgroundImage;        //Mete a imagem do peão noeao
                       this.Controls.Add(pawnBlack);                 //Adiciona à form o peão
                       pawnBlack.BringToFront();                     //Mete o peão à frente de tudo (literalmente)

                       pawnBlack.MouseClick += pecaSelecionada;
                       listaPecas.Add("peaoPreto" + listaPecas.Count(), pawnBlack);
                   }

                   //Seleciona nos indíces 0 e 0 (incial) o panel e poem no seu lugar a respetiva peça (torre)
                   if(colums == 0 && row == 0)
                   {
                       PictureBox castleBlack = new PictureBox();
                       castleBlack.Name = "castleBlack" + colums + row;
                       castleBlack.BackgroundImage = Properties.Resources.castleblack;
                       castleBlack.BackgroundImageLayout = ImageLayout.Stretch;

                       castleBlack.BackColor = Color.Transparent;
                       castleBlack.Size = new Size(larguraPanel, larguraPanel);
                       castleBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)castleBlack.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)castleBlack.BackgroundImage;

                       this.Controls.Add(castleBlack);
                       castleBlack.BringToFront();

                       castleBlack.MouseClick += pecaSelecionada;
                       listaPecas.Add("torrePreto", castleBlack);

                   }
                   //Seleciona nos indices 0 e 1 (primeira linha dos rows) e poem no lugar em cim a respetiva peca (Cavalo)
                   if (colums == 0 && row == 1)
                   {

                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox horseBlack = new PictureBox();
                       horseBlack.Name = "horseBlack" + colums + row;
                       horseBlack.BackgroundImage = Properties.Resources.horseblack;
                       horseBlack.BackgroundImageLayout = ImageLayout.Stretch;

                       horseBlack.BackColor = Color.Transparent;
                       horseBlack.Size = new Size(larguraPanel, larguraPanel);
                       horseBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)horseBlack.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)horseBlack.BackgroundImage;

                       this.Controls.Add(horseBlack);
                       horseBlack.BringToFront();
                       horseBlack.MouseClick += pecaSelecionada;
                       listaPecas.Add("cavaleiroPreto", horseBlack);

                   }
                   // Seleciona nos indices 0 e 2 (segunda linha dos rows) e poem no lugar em cim a respetiva peca (bispo)
                   if (colums == 0 && row == 2)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox bishopBlack = new PictureBox();
                       bishopBlack.Name = "bishopBlack" + colums + row;
                       bishopBlack.BackgroundImage = Properties.Resources.bishopblack;
                       bishopBlack.BackgroundImageLayout = ImageLayout.Stretch;
                       bishopBlack.BackColor = Color.Transparent;
                       bishopBlack.Size = new Size(larguraPanel, larguraPanel);
                       bishopBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)bishopBlack.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)bishopBlack.BackgroundImage;

                       this.Controls.Add(bishopBlack);
                       bishopBlack.BringToFront();

                       bishopBlack.MouseClick += pecaSelecionada;
                       listaPecas.Add("bispoPreto", bishopBlack);
                   }
                   // Seleciona nos indices 0 e 4 (quarta linha dos rows) e poem no lugar em cim a respetiva peca (rei)
                   if (colums == 0 && row == 4)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox kingBlack = new PictureBox();
                       kingBlack.Name = "kingBlack" + colums + row;
                       kingBlack.BackgroundImage = Properties.Resources.kingblack;
                       kingBlack.BackgroundImageLayout = ImageLayout.Stretch;

                       kingBlack.BackColor = Color.Transparent;
                       kingBlack.Size = new Size(larguraPanel, larguraPanel);
                       kingBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)kingBlack.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)kingBlack.BackgroundImage;

                       this.Controls.Add(kingBlack);
                       kingBlack.BringToFront();

                       kingBlack.MouseClick += pecaSelecionada;
                       listaPecas.Add("reiPreto", kingBlack);

                   }
                   // Seleciona nos indices 0 e 3 (terceira linha dos rows) e poem no lugar em cim a respetiva peca (rainha)
                   if (colums == 0 && row == 3)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox queenBlack = new PictureBox();
                       queenBlack.Name = "queenBlack" + colums + row;
                       queenBlack.BackgroundImage = Properties.Resources.queenblack;
                       queenBlack.BackgroundImageLayout = ImageLayout.Stretch;

                       queenBlack.BackColor = Color.Transparent;
                       queenBlack.Size = new Size(larguraPanel, larguraPanel);
                       queenBlack.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)queenBlack.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)queenBlack.BackgroundImage;

                       this.Controls.Add(queenBlack);
                       queenBlack.BringToFront();
                       queenBlack.MouseClick += pecaSelecionada;

                       listaPecas.Add("rainhaPreto", queenBlack);

                   }
                   // Seleciona nos indices 0 e 5 (quinta linha dos rows) e poem no lugar em cim a respetiva peca (bishop segundo)

                   if (colums == 0 && row == 5)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox bishopBlack2 = new PictureBox();
                       bishopBlack2.Name = "bishopBlack2" + colums + row;
                       bishopBlack2.BackgroundImage = Properties.Resources.bishopblack;
                       bishopBlack2.BackgroundImageLayout = ImageLayout.Stretch;

                       bishopBlack2.BackColor = Color.Transparent;
                       bishopBlack2.Size = new Size(larguraPanel, larguraPanel);
                       bishopBlack2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)bishopBlack2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)bishopBlack2.BackgroundImage;

                       this.Controls.Add(bishopBlack2);
                       bishopBlack2.BringToFront();
                       bishopBlack2.MouseClick += pecaSelecionada;
                       listaPecas.Add("bispoPreto2", bishopBlack2);

                   }
                   // Seleciona nos indices 0 e 6 (sexta linha dos rows) e poem no lugar em cim a respetiva peca (segundo cavalo)

                   if (colums == 0 && row == 6)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox horseBlack2 = new PictureBox();
                       horseBlack2.Name = "horseBlack2" + colums + row;
                       horseBlack2.BackgroundImage = Properties.Resources.horseblack;
                       horseBlack2.BackgroundImageLayout = ImageLayout.Stretch;

                       horseBlack2.BackColor = Color.Transparent;
                       horseBlack2.Size = new Size(larguraPanel, larguraPanel);
                       horseBlack2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)horseBlack2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)horseBlack2.BackgroundImage;

                       this.Controls.Add(horseBlack2);
                       horseBlack2.BringToFront();

                       horseBlack2.MouseClick += pecaSelecionada;
                       listaPecas.Add("cavaleiroPreto2", horseBlack2);
                   }
                   // Seleciona o O e 7 na colums e rows e insere  a peça (cavalo segundo)
                   if (colums == 0 && row == 7)
                   {
                       //DECLARAÇÃO DE CADA PCITURE BOX CORRESPONDENTE 
                       //DESDE ONDE ESTÁ O CAMINHO DA IMAGEM, O AJUSTAMENTO ETC...
                       PictureBox castleBlack2 = new PictureBox();
                       castleBlack2.Name = "castleBlack2" + colums + row;
                       castleBlack2.BackgroundImage = Properties.Resources.castleblack;
                       castleBlack2.BackgroundImageLayout = ImageLayout.Stretch;

                       castleBlack2.BackColor = Color.Transparent;
                       castleBlack2.Size = new Size(larguraPanel, larguraPanel);
                       castleBlack2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)castleBlack2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)castleBlack2.BackgroundImage;

                       this.Controls.Add(castleBlack2);
                       castleBlack2.BringToFront();

                       castleBlack2.MouseClick += pecaSelecionada;
                       listaPecas.Add("torrePreto2", castleBlack2);
                   }

                   /*********************************************
                    * IF para criar agora as peças no outro adversário 
                    * Apenas define cada peça do adversário onde cada um deveria estar.
                    * 
                    * 
                    * PEÇAS VERMELHAS
                    * 
                    * 
                    * 
                    * 
                    * 
                    * 
                    * */

                   if(colums == 6)
                   {
                       //Define a peca no lugar quando a colum no for estiver igual a 6
                       PictureBox pawnRed = new PictureBox();
                       pawnRed.Name = "pawnRed" + colums + row;
                       pawnRed.BackgroundImage = Properties.Resources.pawnred;
                       pawnRed.BackgroundImageLayout = ImageLayout.Stretch;

                       pawnRed.BackColor = Color.Transparent;
                       pawnRed.Size = new Size(larguraPanel, larguraPanel);
                       pawnRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)pawnRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)pawnRed.BackgroundImage;

                       this.Controls.Add(pawnRed);
                       pawnRed.BringToFront();

                       pawnRed.MouseClick += pecaSelecionada;
                       listaPecas.Add("peaoVermelho" + listaPecas.Count(), pawnRed);
                   }
                   //

                   if (colums == 7 && row == 0)
                   {
                       PictureBox castleRed = new PictureBox();
                       castleRed.Name = "castleRed" + colums + row;
                       castleRed.BackgroundImage = Properties.Resources.castle;
                       castleRed.BackgroundImageLayout = ImageLayout.Stretch;

                       castleRed.BackColor = Color.Transparent;
                       castleRed.Size = new Size(larguraPanel, larguraPanel);
                       castleRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)castleRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)castleRed.BackgroundImage;

                       this.Controls.Add(castleRed);
                       castleRed.BringToFront();

                       castleRed.MouseClick += pecaSelecionada;

                       listaPecas.Add("torreVermelho", castleRed);
                   }
                   if (colums == 7 && row == 1)
                   {
                       PictureBox horseRed = new PictureBox();
                       horseRed.Name = "horseRed" + colums + row;
                       horseRed.BackgroundImage = Properties.Resources.horsered;
                       horseRed.BackgroundImageLayout = ImageLayout.Stretch;

                       horseRed.BackColor = Color.Transparent;
                       horseRed.Size = new Size(larguraPanel, larguraPanel);
                       horseRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)horseRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)horseRed.BackgroundImage;

                       this.Controls.Add(horseRed);
                       horseRed.BringToFront();
                       listaPecas.Add("cavaleiroVermelho", horseRed);
                       horseRed.MouseClick += pecaSelecionada;


                   }
                   if (colums == 7 && row == 2)
                   {
                       PictureBox bishopRed = new PictureBox();
                       bishopRed.Name = "bishopRed" + colums + row;
                       bishopRed.BackgroundImage = Properties.Resources.bishopred;
                       bishopRed.BackgroundImageLayout = ImageLayout.Stretch;

                       bishopRed.BackColor = Color.Transparent;
                       bishopRed.Size = new Size(larguraPanel, larguraPanel);
                       bishopRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)bishopRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)bishopRed.BackgroundImage;

                       this.Controls.Add(bishopRed);
                       bishopRed.BringToFront();
                       
                       bishopRed.MouseClick += pecaSelecionada;
                       listaPecas.Add("bispoVermelho", bishopRed);
                   }

                   if (colums == 7 && row == 3)
                   {
                       PictureBox queenRed = new PictureBox();
                       queenRed.Name = "queenRed" + colums + row;
                       queenRed.BackgroundImage = Properties.Resources.queenred;
                       queenRed.BackgroundImageLayout = ImageLayout.Stretch;

                       queenRed.BackColor = Color.Transparent;
                       queenRed.Size = new Size(larguraPanel, larguraPanel);
                       queenRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)queenRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)queenRed.BackgroundImage;

                       this.Controls.Add(queenRed);
                       queenRed.BringToFront();

                       queenRed.MouseClick += pecaSelecionada;
                       listaPecas.Add("rainhaVermelho", queenRed);

                   }

                   if (colums == 7 && row == 4)
                   {
                       PictureBox kingRed = new PictureBox();
                       kingRed.Name = "kingRed" + colums + row;
                       kingRed.BackgroundImage = Properties.Resources.kingred;
                       kingRed.BackgroundImageLayout = ImageLayout.Stretch;

                       kingRed.BackColor = Color.Transparent;
                       kingRed.Size = new Size(larguraPanel, larguraPanel);
                       kingRed.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)kingRed.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)kingRed.BackgroundImage;

                       this.Controls.Add(kingRed);
                       kingRed.BringToFront();

                       kingRed.MouseClick += pecaSelecionada;
                       listaPecas.Add("reiVermelho", kingRed);
                   }

                   if (colums == 7 && row == 5)
                   {
                       PictureBox bishopRed2 = new PictureBox();
                       bishopRed2.Name = "bishopRed2" + colums + row;
                       bishopRed2.BackgroundImage = Properties.Resources.bishopred;
                       bishopRed2.BackgroundImageLayout = ImageLayout.Stretch;

                       bishopRed2.BackColor = Color.Transparent;
                       bishopRed2.Size = new Size(larguraPanel, larguraPanel);
                       bishopRed2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)bishopRed2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)bishopRed2.BackgroundImage;

                       this.Controls.Add(bishopRed2);
                       bishopRed2.BringToFront();

                       bishopRed2.MouseClick += pecaSelecionada;
                       listaPecas.Add("bispoVermelho2", bishopRed2);
                   }


                   if (colums == 7 && row == 6)
                   {
                       PictureBox horseRed2 = new PictureBox();
                       horseRed2.Name = "horseRed2" + colums + row;
                       horseRed2.BackgroundImage = Properties.Resources.horsered;
                       horseRed2.BackgroundImageLayout = ImageLayout.Stretch;

                       horseRed2.BackColor = Color.Transparent;
                       horseRed2.Size = new Size(larguraPanel, larguraPanel);
                       horseRed2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)horseRed2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)horseRed2.BackgroundImage;

                       this.Controls.Add(horseRed2);
                       horseRed2.BringToFront();

                       horseRed2.MouseClick += pecaSelecionada;
                       listaPecas.Add("cavaleiroVermelho2", horseRed2);
                   }

                   if (colums == 7 && row == 7)
                   {
                       PictureBox castleRed2 = new PictureBox();
                       castleRed2.Name = "castleRed2" + colums + row;
                       castleRed2.BackgroundImage = Properties.Resources.castle;
                       castleRed2.BackgroundImageLayout = ImageLayout.Stretch;

                       castleRed2.BackColor = Color.Transparent;
                       castleRed2.Size = new Size(larguraPanel, larguraPanel);
                       castleRed2.Location = new Point((row * 71) + 52, (colums * 71) + 52);
                       tabuleiro[0, 0] = (Bitmap)castleRed2.BackgroundImage;
                       tabuleiro[colums, row] = (Bitmap)castleRed2.BackgroundImage;

                        

                       this.Controls.Add(castleRed2);
                       castleRed2.BringToFront();

                       castleRed2.MouseClick += pecaSelecionada;
                       listaPecas.Add("torreVermelho2", castleRed2);
                   }

                   newPictureBox.MouseClick += pecaDestino;

                  
                   
                                      
                   //tabuleiro.Controls.Add(pawn);
                   
               }
           }
        }

        /// <summary>
        ///Peça selecionada com switch que diferencia 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pecaSelecionada(object sender, EventArgs e)
        {
            if(selecionada == null)
            {
                selecionada = (PictureBox)sender;  // Sender é objecto clicado (PictureBox) que vai ser guardado na var selecionada
                selecionada.BackColor = Color.Aqua;

            }
            else
            {
                /*
                selecionada.BackColor = Color.Transparent;
                selecionada = (PictureBox)sender;  // Sender é objecto clicado (PictureBox) que vai ser guardado na var selecionada
                selecionada.BackColor = Color.Aqua;*/

                switch (devolveNomePeca(selecionada))
                {
                    case "peaoVermelho": 
                        if(turnos == false)
                        {
                            if (pecaPeao.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                        }
                        break;
                    case "peaoPreto":
                        if (turnos == true)
                        {
                            if (pecaPeao.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;

                                ((PictureBox)sender).Location = new Point(-100, -100);

                              /*  foreach(KeyValuePair<string,PictureBox> pecas in listaPecas)
                                {

                                    if (pecas.Key == "peaoPreto" + listaPecas.)
                                    {
                                        ((PictureBox)sender).Location = new Point(800 + 70, 5);
                                    }
                                }
                               */
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }
                        break;
                    case "bispoPreto":
                        if (turnos == true)
                        {
                            if (pecaBispo.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                //Depois de comer a peça , ela vai pra essa localização  ("escondida");
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }

                        break;
                    case "bispoVermelho":
                        if (turnos == false)
                        {
                            if (pecaBispo.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                            
                        }
                        break;
                    case "rainhaPreto":
                        if (turnos == true)
                        {
                            if (pecaRainha.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }
                        break;
                    case "rainhaVermelho":
                        if (turnos == false)
                        {
                            if (pecaRainha.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                            
                        }
                        break;
                    case "reiPreto":
                        if (turnos == true)
                        {
                            if (pecaRei.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }
                        break;
                    case "reiVermelho":
                        if (turnos == false)
                        {
                            if (pecaRei.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                            
                        }
                        break;
                    case "cavaleiroPreto":
                        if (turnos == true)
                        {
                            if (pecaCavaleiro.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }
                        break;
                    case "cavaleiroVermelho":
                        if (turnos == false)
                        {
                            if (pecaCavaleiro.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                           
                        }

                        break;
                    case "torrePreto":
                        if (turnos == true)
                        {
                            if (pecaTorre.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = false;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos vermelhos";
                            }
                            
                            
                        }
                        break;
                    case "torreVermelho":
                        if (turnos == false)
                        {
                            if (pecaTorre.comer(((PictureBox)sender).Location, selecionada.Location, devolveNomePeca((PictureBox)sender), devolveNomePeca(selecionada), larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                ((PictureBox)sender).Location = new Point(-100, -100);
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                            
                        }
                        break;
                }
                
                selecionada.BackColor = Color.Transparent;
                selecionada = null;
                
            }
            //MessageBox.Show( ((Bitmap)((PictureBox)GetChildAtPoint(selecionada.Location)).BackgroundImage).GetPixel(203,100).ToString() );
           // MessageBox.Show( ((Bitmap)GetChildAtPoint(new Point(selecionada.Location.X-71, selecionada.Location.Y-71)).BackgroundImage).GetPixel(0,0).ToString());
        }

        public void pecaDestino(object sender, EventArgs e)
        {
           
            //Função que serve para determinar o destino da peça selecionada
            
           if(selecionada != null)
           {
               switch(devolveNomePeca(selecionada))
               {
                    //Peças Vermelhas
                   case "peaoVermelho":
                       if(turnos == false)
                       { 
                           if (pecaPeao.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this,listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = true;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos pretos";
                           }
                           
                           
                           
                       }
                    
                       break;
                   case "torreVermelho":
                       if(turnos == false)
                       {
                            if (pecaTorre.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                            {
                                //     MessageBox.Show("Entrou aqui");
                                selecionada.Location = ((PictureBox)sender).Location;
                                selecionada.BackColor = Color.Transparent;
                                turnos = true;
                                labelTurnos.Text = "";
                                labelTurnos.Text = "Vez dos pretos";
                            }
                            
                            
                       }
                          
                       break;
                   case "cavaleiroVermelho":
                       if (turnos == false)
                       {
                           if (pecaCavaleiro.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = true;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos pretos";
                           }
                           
                           
                       }
                       break;
                   case "reiVermelho":
                       if (turnos == false)
                       {
                           if (pecaRei.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = true;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos pretos";
                           }
                           
                           
                       }
                       break;
                   case "rainhaVermelho":
                       if (turnos == false)
                       {
                           if (pecaRainha.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = true;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos pretos";
                           }
                           
                           
                       }
                       break;
                   case "bispoVermelho":
                       if (turnos == false)
                       {
                           //MessageBox.Show("bispoVermelho");
                           if (pecaBispo.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = true;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos pretos";
                           }
                           
                           
                       }
                       break;

                   //Peças Pretas
                   case "peaoPreto":
                       if(turnos == true)
                       {
                           if (pecaPeao.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                           
                           
                       }                   
                       break;
                   case "torrePreto":
                       if (turnos == true)
                       {
                           if (pecaTorre.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               //     MessageBox.Show("Entrou aqui");
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                          
                           
                       }
                       break;
                   case "cavaleiroPreto":
                       if (turnos == true)
                       {
                           if (pecaCavaleiro.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                           
                           
                       }
                       break;
                   case "reiPreto":
                       if (turnos == true)
                       {
                           if (pecaRei.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                           
                           
                       }
                       break;
                   case "rainhaPreto":
                       if (turnos == true)
                       {
                           if (pecaRainha.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                           
                           
                       }
                       break;
                   case "bispoPreto":
                       if (turnos == true)
                       {
                           if (pecaBispo.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this, listaPecas)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                           {
                               selecionada.Location = ((PictureBox)sender).Location;
                               selecionada.BackColor = Color.Transparent;
                               turnos = false;
                               labelTurnos.Text = "";
                               labelTurnos.Text = "Vez dos Vermelhos";
                           }
                           
                           

                       }
                       
                       break;




                   default:
                       MessageBox.Show("nada" + devolveNomePeca(selecionada));
                       break;
                       
               }
               /*
                if (pecaPeao.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                { 
                    selecionada.Location = ((PictureBox)sender).Location;
                    selecionada.BackColor = Color.Transparent;
                }
                if(pecaTorre.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                {
               //     MessageBox.Show("Entrou aqui");
                    selecionada.Location = ((PictureBox)sender).Location;
                    selecionada.BackColor = Color.Transparent;
                }
                if (pecaRei.movimento(((PictureBox)sender).Location, selecionada.Location, selecionada, larguraPanel, this)) //chama a funcao do peao e diz se pode mover ou nao e move a peca
                {
                    selecionada.Location = ((PictureBox)sender).Location;
                    selecionada.BackColor = Color.Transparent;
                }*/
                selecionada.BackColor = Color.Transparent;
                selecionada = null;
           }
           

            
            
        }


        /*********************************************
         * Método para alterar a cor ao passar o rato em Cima
         * seleciona a Picture Box do tabuleiro
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * */
        private void tabuleiro_AoMeterRato(object sender, EventArgs e)
        {
            PictureBox hover = ((PictureBox)sender);

            if(((Bitmap)hover.BackgroundImage).GetPixel(0,0) == Properties.Resources.pattern_64qv.GetPixel(0,0))
            {
                hover.BackgroundImage = Properties.Resources.aoMeterRato2Vermelho;
            }
            else if (((Bitmap)hover.BackgroundImage).GetPixel(0, 0) == Properties.Resources.pattern_diry.GetPixel(0, 0))
            {
                hover.BackgroundImage = Properties.Resources.mudar;
            }
            

        }


        //Método para ser executado quando o evento Mouse hover for desparado
        private void pictureBoxMouseHover(object sender, EventArgs e)
        {
            this.Controls.Add(caixinha);
            //Se a picture box que chama for a pictureMortosVer
            if(((PictureBox)sender).Name == "pictureMortosVer")
            {
                
                caixinha.Visible = true;
            }
          //  caixinha.BringToFront();
           
           
            
            
        }
        private void pictureMortosVer_MouseLeave(object sender, EventArgs e)
        {
            caixinha.Visible = false;
        }


        /*********************************************
        * Método para alterar a cor ao sair com o rato
        * seleciona a Picture Box do tabuleiro
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * 
        * */
        private void tabuleiro_AoMeterSair(object sender, EventArgs e)
        {
            PictureBox hover = ((PictureBox)sender);

            if (((Bitmap)hover.BackgroundImage).GetPixel(0, 0) == Properties.Resources.aoMeterRato2Vermelho.GetPixel(0, 0))
            {
                hover.BackgroundImage = Properties.Resources.pattern_64qv;
            }
            else if (((Bitmap)hover.BackgroundImage).GetPixel(0, 0) == Properties.Resources.mudar.GetPixel(0, 0))
            {
                hover.BackgroundImage = Properties.Resources.pattern_diry;
            }


        }
       ///
        private string devolveNomePeca(PictureBox recebeSelecionada)
        {
            //PEÇAS VERMELHAS
            //Compara com o peao vermelho
            if (Properties.Resources.pawnred.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.pawnred.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.pawnred.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "peaoVermelho";
                    }
                }
            }

            if (Properties.Resources.castle.GetPixel(258, 194) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(258, 194))
            {
                if (Properties.Resources.castle.GetPixel(302, 190) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(302, 190))
                {
                    if (Properties.Resources.castle.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "torreVermelho";
                    }
                }
            }

            if (Properties.Resources.horsered.GetPixel(258, 194) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(258, 194))
            {
                if (Properties.Resources.horsered.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.horsered.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "cavaleiroVermelho";
                    }
                }
            }
            if (Properties.Resources.kingred.GetPixel(257, 174) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(257, 174))
            {
                if (Properties.Resources.kingred.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.kingred.GetPixel(260, 224) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(260, 224))
                    {
                        return "reiVermelho";
                    }
                }
            }
            if (Properties.Resources.bishopred.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.bishopred.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.bishopred.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "bispoVermelho";
                    }
                }
            }
            if (Properties.Resources.queenred.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.pawnred.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.pawnred.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "rainhaVermelho";
                    }
                }
            }

            //PEÇAS PRETAS
            if (Properties.Resources.pawnblack.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.pawnblack.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.pawnblack.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "peaoPreto";
                    }
                }
            }

            if (Properties.Resources.castleblack.GetPixel(258, 194) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(258, 194))
            {
                if (Properties.Resources.castleblack.GetPixel(302, 190) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(302, 190))
                {
                    if (Properties.Resources.castleblack.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "torrePreto";
                    }
                }
            }

            if (Properties.Resources.horseblack.GetPixel(258, 194) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(258, 194))
            {
                if (Properties.Resources.horseblack.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.horseblack.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "cavaleiroPreto";
                    }
                }
            }
            if (Properties.Resources.kingblack.GetPixel(257, 174) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(257, 174))
            {
                if (Properties.Resources.kingblack.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.kingblack.GetPixel(260, 224) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(260, 224))
                    {
                        return "reiPreto";
                    }
                }
            }
            if (Properties.Resources.bishopblack.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.bishopblack.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.bishopblack.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "bispoPreto";
                    }
                }
            }
            if (Properties.Resources.queenblack.GetPixel(255, 181) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(255, 181))
            {
                if (Properties.Resources.queenblack.GetPixel(33, 122) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(33, 122))
                {
                    if (Properties.Resources.queenblack.GetPixel(156, 156) == ((Bitmap)recebeSelecionada.BackgroundImage).GetPixel(156, 156))
                    {
                        return "rainhaPreto";
                    }
                }
            }




            return "nada";
        }
        private void timerCoiso_Tick(object sender, EventArgs e)
        {
            
        }

        private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*panel56.Controls.Add(pictureBoxPeao1);
            pictureBoxPeao1.Location = new Point(32,20);
            pictureBoxPeao1.BringToFront();    */     
        }

        private void labelFilaE_Click(object sender, EventArgs e)
        {

        }

        private void pictureMortosVer_MouseLeave_1(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                salvar = new SaveGame(listaPecas);
                SerializeWithBinaryFormatters(salvar, saveFile.InitialDirectory + saveFile.FileName);
            }

            if (saveFile.ShowDialog() == DialogResult.Cancel)
            {
                //saveFile.Show
            }



        }

        static void SerializeWithBinaryFormatters(Object obj, string fileLocation)
        {
            Stream streamToFile = File.OpenWrite(fileLocation);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(streamToFile, obj);
            streamToFile.Close();
        }

        static Object DeserializeWtihBinaryFormatters(string fileLocation)
        {
            Stream streamFromFile = File.OpenRead(fileLocation);
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(streamFromFile);
            streamFromFile.Close();
            return obj;

        }

        private void buttonAbrir_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {

              //  salvar = new SaveGame(listaPecas);
                salvar = (SaveGame)DeserializeWtihBinaryFormatters(openFile.InitialDirectory + openFile.FileName);//objeto save

                listaPecas = salvar.getGame(listaPecas);
            }

            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                //saveFile.Show
            }
        }
        
    }
}