using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CA210316_2
{
    class Program
    {
        static void Main()
        {
            var versenyzok = new List<Versenyzo>();
            var sr = new StreamReader(@"..\..\RES\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream) versenyzok.Add(new Versenyzo(sr.ReadLine()));
            sr.Close();

            //3. feladat ::: összes indulo a 2 kat.-ban
            Console.WriteLine($"3. feladat: Versenyzők száma: {versenyzok.Count}");

            //4. feladat ::: noi versenyzok aranya
            Console.WriteLine("4. feladat: Női versenyzők aránya: {0:0.00}%", 
                versenyzok.Count(x => x.Kategoria == "Noi") / (float)versenyzok.Count * 100);

            //6. feladat ::: noi bajnok
            var b = versenyzok
                .Find(x => x.Osszpontszam == versenyzok
                .Where(y => y.Kategoria == "Noi").Max(y => y.Osszpontszam));
            Console.WriteLine("6. feladat: a bajnok női versenyző" +
                $"\n\tNév: {b.Nev}" +
                $"\n\tEgyesület: {b.Egyesulet}" +
                $"\n\tÖsszpont: {b.Osszpontszam}");

            //7. feladat ::: ferfiak fileba
            var sw = new StreamWriter(@"..\..\RES\osszpontFF.txt", false, Encoding.UTF8);
            versenyzok.Where(x => x.Kategoria == "Felnott ferfi").ToList()
                .ForEach(x => sw.WriteLine($"{x.Nev};{x.Osszpontszam}"));
            sw.Close();

            //8. feladat ::: egyesuletek induloi
            Console.WriteLine("8. feladat: egyesület statisztika");
            versenyzok.GroupBy(x => x.Egyesulet)
                .Where(x => x.Key != "n.a." && x.Count() > 2).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key} - {x.Count()} fő"));

            Console.ReadKey();

        }
    }
}
