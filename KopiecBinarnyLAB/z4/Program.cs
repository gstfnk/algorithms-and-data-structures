using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zadanie 4
//Przeanalizuj sortowanie przez kopcowanie na przykładzie tablicy:
//(5, 13, 2, 25, 7, 17, 20, 8, 4).

class Program
{
    static void Napraw(int[] kopiec, int węzeł, int wielkość)
    {
        // korzeń drzewa
        int największy = węzeł; 
        int lewe = 2 * węzeł + 1;
        int prawe = 2 * węzeł + 2;
        // dopóki są dzieci
        if (lewe < wielkość && kopiec[lewe] > kopiec[największy])
        {
            największy = lewe;
        }
        if (prawe < wielkość && kopiec[prawe] > kopiec[największy])
        {
            największy = prawe;
        }
        if (największy != węzeł)
        {
            int pomoc = kopiec[węzeł];
            kopiec[węzeł] = kopiec[największy];
            kopiec[największy] = pomoc;
            Napraw(kopiec, największy, wielkość);
        }
    }

    static void Buduj(int[] kopiec)
    {
        int wielkość = kopiec.Length;
        for (int i = (wielkość / 2 - 1); i >= 0; i--)
            Napraw(kopiec, i, kopiec.Length);
    }

    // sortowanie tablicy
    static void Sortuj(int[] dane)
    {
        Buduj(dane);
        int wielkość = dane.Length;
        while (wielkość > 1)
        {
            Console.WriteLine("kopiec przed zamianą");
            Wypisz(dane);
            // zamieniamy największy element z ostatnim
            int największy = dane[0];
            dane[0] = dane[wielkość - 1];
            dane[wielkość - 1] = największy;
            Console.WriteLine("po zamianie");
            Wypisz(dane);
            // naprawiamy zmniejszony kopiec
            wielkość = wielkość - 1;
            Napraw(dane, 0, wielkość);
        }
    }

    static void Wypisz(int[] dane)
        {
            for (int i = 0; i < dane.Length; i++)
                Console.Write(dane[i] + " ");
            Console.WriteLine();
        }
    static void Main(string[] args)
    {
        int[] dane = { 5, 13, 2, 25, 7, 17, 20, 8, 4 };
        Console.WriteLine("przed sortowaniem");
        Wypisz(dane);
        Sortuj(dane);
        Console.WriteLine("po sortowaniu");
        Wypisz(dane);
    }
}

