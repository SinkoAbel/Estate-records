using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Ingatlan_nyilvantartas
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader("real_estate.txt");
            Foldhivatal_nyilvantarto nyilvantarto = new Foldhivatal_nyilvantarto();

            Ingatlan ujIngatlan;


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(';');

                switch (data.Length)
                {
                    case 1:
                        ujIngatlan = new Ingatlan(data[0]);
                        break;

                    case 2:
                        ujIngatlan = new Ingatlan(data[0], uint.Parse(data[1]));
                        break;

                    case 3:
                        ujIngatlan = new Lakoepulet(data[0], uint.Parse(data[1]), data[2]);
                        break;

                    case 4:
                        ujIngatlan = new Termofold(data[0], uint.Parse(data[1]), (MuvelesiAg)Enum.Parse(typeof(MuvelesiAg), data[2]), 
                                                  float.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat));
                        break;

                    case 5:
                        ujIngatlan = new Lakoepulet(data[0], uint.Parse(data[1]), data[2], 
                                                   (Lakoepulet_fajta)Enum.Parse(typeof(Lakoepulet_fajta), data[3]), bool.Parse(data[4]));
                        break;


                    default:
                        throw new Exception("Csak 1, 2, 3 vagy 4 paraméterrel rendelkező elemek lehetnek a listában!");
                }

                nyilvantarto.IngatlanLetrehozasa(ujIngatlan);

            }

            reader.Close();

            nyilvantarto.LegdragabbIngatlan();

            Console.WriteLine("Az erdők átlagos területe {0} hektár.\n", nyilvantarto.AtlagHektar(MuvelesiAg.erdo).ToString("0.00")); 

            List<Ingatlan> bontandoCsaladiHazak = nyilvantarto.BontandoLakohazak(Lakoepulet_fajta.csaladi_haz);
            Console.WriteLine("Bontandó családi házak:");
            foreach (Ingatlan item in bontandoCsaladiHazak)
                Console.WriteLine(item);            



        }
    }
}
