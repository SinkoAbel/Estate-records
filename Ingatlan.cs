using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Ingatlan_nyilvantartas
{
    public class Ingatlan
    {

        private string helyrajziSzam;

        public string HelyrajziSzam 
        { 
            get => helyrajziSzam;
            protected set
            {
                if (value.Length < 4)
                    throw new Exception("A szám nem lehet kisebb 4 karakternél!");

                Regex regex = new Regex(@"[0-9A-Za-z/]");

                if (!regex.IsMatch(value))
                    throw new Exception("Az érték csak számot, betűt és '/' jelet tartalmazhat!");

                helyrajziSzam = value;
            }            
        }

        private uint ar;

        public uint Ar
        {
            get { return ar; }
            set 
            { 

                if (value % 100000 != 0)
                    throw new Exception("Az árnak 100.000-el oszthatónak kell lennie!");

                ar = value; 
            }
        }

        public Ingatlan(string helyrajziSzam, uint ar)
        {
            this.HelyrajziSzam = helyrajziSzam;
            this.Ar = ar;
        }

        public Ingatlan(string helyrajziSzam)
            :this (helyrajziSzam, 100000000)
        {

        }


        public void ArMegnovelese(uint ujAr)
        {

            if (ujAr > ar)
                this.Ar += ujAr;
        }

        public override string ToString()
        {
            return string.Format("Helyrajzi szám: {0}, Ár: {1}\n", HelyrajziSzam, Ar);
        }

    }
}
