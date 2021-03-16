using System;
using System.Linq;

namespace CA210316_2
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }

        //5. feladat ::: osszpontszam property
        public int Osszpontszam
        {
            get
            {
                var ideiglenes = new int[Pontok.Length];
                Array.Copy(Pontok, ideiglenes, ideiglenes.Length);
                Array.Sort(ideiglenes);
                Array.Reverse(ideiglenes);
                if (ideiglenes[6] > 0) ideiglenes[6] = 10;
                if (ideiglenes[7] > 0) ideiglenes[7] = 10;
                return ideiglenes.Sum();
            }
        }

        public Versenyzo(string r)
        {
            var t = r.Split(';');
            Nev = t[0];
            Kategoria = t[1];
            Egyesulet = t[2];
            Pontok = new int[8];
            for (int i = 3; i < t.Length; i++)
                Pontok[i - 3] = int.Parse(t[i]);
        }
    }
}
