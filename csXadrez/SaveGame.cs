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
    class SaveGame
    {
        public Dictionary<String, Point> points = new Dictionary<String, Point>();

        public SaveGame(Dictionary<String, PictureBox> leagueOfLegends)
        {
            foreach (KeyValuePair<String, PictureBox> pb in leagueOfLegends)
            {
                points.Add(pb.Value.Name,pb.Value.Location);
                Console.WriteLine(pb.Value.Name);

            }

        }

        public Dictionary<String, PictureBox> getGame(Dictionary<String, PictureBox> listaPecas)
        {
            foreach (KeyValuePair<String, Point> pos in points)
            {
                //skin.Add(ruben.Value.Location," ");
                foreach (KeyValuePair<String, PictureBox> pb in listaPecas)
                {
                    Console.WriteLine("entrou" + pb.Key + " x " + pos.Key);
                    if(pb.Value.Name == pos.Key)
                    {
                        pb.Value.Location = pos.Value;
                        Console.WriteLine("entrou");
                    }

                }

            }

            return listaPecas;
        }
    }
}
