﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace K_Eszter_2021._02._15_struktura
{
    class Program
    {
        //Szabályok:
        //1.: A Main-en kívül, de az osztályon belül hozzuk létre
        //2. :Kötelező elem a "struct" nevű osztályváltozó
        //3.: A "struct" kulcsszó után adjuk meg a struktúra nevét
        //4.: Adattagok létrehozása, melynek az osztályon belül publikusnak kell lennie
        //5.: A public láthatóság után meg kell adni a mező típusát, majd egy nevet.

        struct Adat
        {
            public string Versenyzok;
            public int Rajtszam;
            public string Kategoriak;
            public string Versenyido;
            public int TavSzazalek;
        }
        static void Main(string[] args)
        {
            //Példányosítani kell az adatstruktúrát ahhoz, hogy a Main azt kezelni tudja!!!
            //2.feladat
            Adat[] adatok = new Adat[500];//Példányosítani kell!!!
            StreamReader olvas = new StreamReader(@"E:\OneDrive - Kisvárdai SZC Móricz Zsigmond Szakgimnáziuma és Szakközépiskolája\Oktatas\Programozas\Jakab_Acs_Eszter\Erettsegi_feladatok\2019_maj_Ultrabalaton\ub2017egyeni.txt");
            string elsosor = olvas.ReadLine();
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split(';');
                adatok[n].Versenyzok = db[0];
                adatok[n].Rajtszam = int.Parse(db[1]);
                adatok[n].Kategoriak = db[2];
                adatok[n].Versenyido = db[3];
                adatok[n].TavSzazalek = int.Parse(db[4]);
                n++;
            }
            olvas.Close();
            Console.WriteLine("2.feladat\nBeolvasás kész!");

            //3.feladat
            Console.WriteLine($"3. feladat: Egyéni indulók: {n} fő");

            //4.feladat
            int nok = 0;//Megszámlálás tétele!
            for (int i=0;i<n;i++)
            {
                if (adatok[i].Kategoriak == "Noi" && adatok[i].TavSzazalek == 100)
                {
                    nok++;
                }
            }
            Console.WriteLine($"4. feladat: Célba érkező női sportolók: {nok} fő");

            //5.feladat
            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            string Nev = Console.ReadLine();
            bool volt = false;
            for (int i = 0;i<n;i++)
            {
                if (Nev == adatok[i].Versenyzok)
                {
                    volt = true;
                    Console.WriteLine($"\tIndult egyéniben a sportoló? Igen");
                    if (adatok[i].TavSzazalek == 100)
                    {
                        Console.WriteLine($"\tTeljesítette a teljes távot? Igen");
                    }
                    else
                    {
                        Console.WriteLine($"\tTeljesítette a teljes távot? Nem");
                    }                  
                }              
            }

            if (!volt)
            {
                Console.WriteLine($"\tIndult egyéniben a sportoló? Nem");
            }

            //6.feladat
            Console.WriteLine(IdőÓrában(adatok[0].Versenyido).ToString("0.00"));

            //7.feladat
            int ferfi = 0;
            double ora = 0;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].Kategoriak == "Ferfi" && adatok[i].TavSzazalek == 100)
                {
                    ferfi++;
                    ora = ora + IdőÓrában(adatok[i].Versenyido);
                }
            }
            double atlag = ora / ferfi;
            Console.WriteLine($"7. feladat: Átlagos idő: {atlag} óra");

            //8.feladat
            double ferfi_min = double.MaxValue;
            double noi_min = double.MaxValue;
            int j=-1, k=-1;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].Kategoriak == "Ferfi")
                {
                    if (adatok[i].TavSzazalek == 100)
                    {
                        if (IdőÓrában(adatok[i].Versenyido) < ferfi_min)
                        {
                            ferfi_min = IdőÓrában(adatok[i].Versenyido);
                            j = i;
                        }
                    }
                }
                else
                {
                    if (adatok[i].TavSzazalek == 100)
                    {
                        if (IdőÓrában(adatok[i].Versenyido) < noi_min)
                        {
                            noi_min = IdőÓrában(adatok[i].Versenyido);
                            k = i;
                        }
                    }
                }
            }
            Console.WriteLine("8. feladat: Verseny győztesei");
            Console.WriteLine("\tNők: "+adatok[k].Versenyzok+" ("+adatok[k].Rajtszam+".) - "+adatok[k].Versenyido);
            Console.WriteLine("\tFérfiak: " + adatok[j].Versenyzok + " (" + adatok[j].Rajtszam + ".) - " + adatok[j].Versenyido);
            Console.ReadKey();
        }

        //6.feladat
        static double IdőÓrában(string versenyido)
        {
            string[] db = versenyido.Split(':');
            double ora = double.Parse(db[0]) + (double.Parse(db[1]) / 60) + (double.Parse(db[2]) / 3600);
            return ora;
        }
    }
}
