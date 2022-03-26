using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlan_nyilvantartas
{
    class Termofold : Ingatlan
    {

        private MuvelesiAg muvelesiAg;

        public MuvelesiAg MuvelesiAg
        {
            get => muvelesiAg;
            private set
            {
                muvelesiAg = value;
            }
        }

        private float teruletNagysaga;

        /// <summary>
        /// Hektár
        /// </summary>
        public float TeruletNagysaga
        {
            get => teruletNagysaga;
            set
            {
                if (value < 1)
                    throw new Exception("Az értéknek nagyobbnak kell lennie mint 0!");

                teruletNagysaga = value;
            }
        }

        // 4 paraméteres
        /// <summary>
        /// A helyrajzi számnak 0-val kell kezdődnie!
        /// </summary>
        /// <param name="helyrajziSzam"></param>
        /// <param name="foldAra"></param>
        /// <param name="muvelesiAg"></param>
        /// <param name="teruletNagysaga"></param>
        public Termofold(string helyrajziSzam, uint foldAra, MuvelesiAg muvelesiAg, float teruletNagysaga)
            :base(helyrajziSzam, foldAra)
        {
            if (helyrajziSzam[0] != '0')
                throw new Exception("Termőföld esetén a helyrajzi számnak 0-val kell kezdődnie!");

            this.MuvelesiAg = muvelesiAg;
            this.TeruletNagysaga = teruletNagysaga;
        }

        /// <summary>
        /// A hektáronkénti árat növeli a metódusban megadott százalékkal, mely csak egész százalék lehet.
        /// </summary>
        public void HektaronkentiArNovelese(byte szazalek)
        {
            if (szazalek < 1 || szazalek > 100)
                throw new Exception("A megadott értéknek 1 és 100 közé kell esnie.");


            float hektaronkentiAr = Ar / TeruletNagysaga;

            float szorzandoErtek = (szazalek / 100) + 1;

            Ar = (uint)(hektaronkentiAr * szorzandoErtek);
        }
    }
}
