using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibimon
{
    public class tibimonok
    {
        public string nev { get; set; }
        public double hp { get; set; }
        public double tamadas { get; set; }
        public double vedekezes { get; set; }
        public int gyorsasag { get; set; }
        public List<string> tipusok { get; set; }
        public string leiras { get; set; }
        public string[] erossegek { get; set; }
        public string[] gyengesegek { get; set; }
        public int kepId { get; set; }
        public double kezdoElet { get; set; }

        public tibimonok(string besor, int beKepId)
        {
            tipusok = new List<string>();
            erossegek = new string[15];
            gyengesegek = new string[15];


            kepId = beKepId;
            string[] segedTomb = besor.Split(';');
            string[] segedTomb2 = segedTomb[1].Split(',');
            nev = segedTomb[0];
            hp = int.Parse(segedTomb2[0]);
            kezdoElet = int.Parse(segedTomb2[0]);
            tamadas = int.Parse(segedTomb2[1]);
            vedekezes = int.Parse(segedTomb2[2]);
            gyorsasag = int.Parse(segedTomb2[3]);

            if(segedTomb[3].Contains(' '))
            {
                tipusok.Add(segedTomb[2]);
                leiras = segedTomb[3];

                if (segedTomb[4] == "")
                {
                    erossegek[0] = "-";
                }
                else
                {
                    if (segedTomb[4].Contains(","))
                    {
                        erossegek = segedTomb[4].Split(',');
                    }
                    else
                    {
                        erossegek[0] = segedTomb[4];
                    }
                }

                if (segedTomb[5] == "")
                {
                    gyengesegek[0] = "-";
                }
                else
                {
                    if (segedTomb[5].Contains(","))
                    {
                        gyengesegek = segedTomb[5].Split(',');
                    }
                    else
                    {
                        gyengesegek[0] = segedTomb[5];
                    }
                }
            }
            else
            {
                tipusok.Add(segedTomb[2]);
                tipusok.Add(segedTomb[3]);
                leiras = segedTomb[4];

                if (segedTomb[5] == "")
                {
                    erossegek[0] = "-";
                }
                else
                {
                    if (segedTomb[5].Contains(","))
                    {
                        erossegek = segedTomb[5].Split(',');
                    }
                    else
                    {
                        erossegek[0] = segedTomb[5];
                    }
                }

                if (segedTomb[5] == "")
                {
                    gyengesegek[0] = "-";
                }
                else
                {
                    if (segedTomb[5].Contains(","))
                    {
                        gyengesegek = segedTomb[5].Split(',');
                    }
                    else
                    {
                        gyengesegek[0] = segedTomb[5];
                    }
                }
            }
        }
    }
}
