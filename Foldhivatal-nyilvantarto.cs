using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Ingatlan_nyilvantartas
{
    class Foldhivatal_nyilvantarto
    {

        List<Ingatlan> ingatlan = new List<Ingatlan>();
        

        public void IngatlanLetrehozasa(Ingatlan e)
        {
            if(ingatlan.Count == 0)
            {
                ingatlan.Add(e);
                return;
            }
            else
                foreach (Ingatlan item in ingatlan)
                {
                    if (item.HelyrajziSzam.Contains(e.HelyrajziSzam))
                        throw new Exception("Ezen a helyrajzi számon már létezik ingatlan!");
                }

            ingatlan.Add(e);
        }


        public void LegdragabbIngatlan()
        {
            uint maxAr = ingatlan.Max(j => j.Ar);

            foreach (Ingatlan item in ingatlan)
                if (item.Ar == maxAr)
                    Console.WriteLine("A legdrágább ingatlan => {0}", item);
        }

        public float AtlagHektar(MuvelesiAg muvelesiAg)
        {
            if (ingatlan.OfType<Termofold>().Count() == 0)
                throw new Exception("Nincs egy termőföld sem a listában!");

            List<Termofold> termo = new List<Termofold>();

            foreach (Termofold item in ingatlan.OfType<Termofold>())
                if (item.MuvelesiAg == muvelesiAg)
                    termo.Add(item);

            float atlag = termo.Average(j => j.TeruletNagysaga);

            return atlag;
        }


        public List<Ingatlan> BontandoLakohazak(Lakoepulet_fajta fajta)
        {
            List<Ingatlan> bontandok = new List<Ingatlan>();

            foreach (Ingatlan item in ingatlan)
                if(item is Lakoepulet)
                {
                    Lakoepulet j = item as Lakoepulet;
                    if (j.Fajta == fajta && j.Bontando_e)
                        bontandok.Add(j);
                }


            if (bontandok.Count > 0)
                return bontandok;
            else
                throw new Exception("Nincs bontandó lakóház!");
        }

    }
}
