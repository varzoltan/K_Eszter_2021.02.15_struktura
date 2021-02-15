using System;
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
            Adat[] adatok = new Adat[500];
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
        }
    }
}
