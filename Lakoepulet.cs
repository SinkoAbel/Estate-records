using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlan_nyilvantartas
{
    class Lakoepulet : Ingatlan
    {

        private string cim;

        public string Cim
        {
            get { return cim; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("A cím nem lehet üres!");

                cim = value; 
            }
        }

        private Lakoepulet_fajta fajta;

        public Lakoepulet_fajta Fajta 
        {
            get => fajta;
            private set
            {
                fajta = value;
            } 
        }

        private bool bontando_e;

        public bool Bontando_e
        {
            get { return bontando_e; }
            set 
            { 

                if (value == false && bontando_e == true)
                    throw new Exception("Ha valami bontandó azt nem lehet visszaállítani!");

                bontando_e = value;   
            }
        }

        // 3 paraméteres konstruktor
        public Lakoepulet(string helyrajziSzam, uint epuletAra, string cim)
            :base(helyrajziSzam, epuletAra)
        {
            this.Cim = cim;
            this.Fajta = Lakoepulet_fajta.csaladi_haz;
            this.Bontando_e = false;
        }

        // 5 paraméteres konstruktor(4 helyett)
        public Lakoepulet(string helyrajziSzam, uint epuletAra, string cim, Lakoepulet_fajta fajta, bool bontando_e)
            :base(helyrajziSzam, epuletAra)
        {
            this.Cim = cim;
            this.Fajta = fajta;
            this.Bontando_e = bontando_e;
        }
    }
}
