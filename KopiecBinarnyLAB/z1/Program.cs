using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zadanie 1
//a) Jaka jest wysokość n-elementowego kopca ? Napisz prosta metodę wyznaczającą wysokość.
//b) Jaka jest najmniejsza i największa liczba elementów w kopcu o wysokości h?
//c) Ile jest węzłów wewnętrznych a ile liści w kopcu o liczbie węzłów n? 
//   Napisz proste metody wyznaczające liczbę węzłów wewnętrznych i liści.
//d) Gdzie w kopcu można znaleźć element najmniejszy?
//e) Czy tablica, która jest odwrotnie posortowana(tzn.nierosnąco), jest kopcem?

class Program
{
    // Interfejs kopca

    static void Napraw(int[] kopiec, int węzeł)
    {
        int wielkość = kopiec.Length;
        int największy = węzeł; // korzeń drzewa
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
            Napraw(kopiec, największy);
        }
    }

    static void Buduj(int[] kopiec)
    {
        int wielkość = kopiec.Length;
        for (int i = (wielkość - 1) / 2; i >= 0; i--)
            Napraw(kopiec, i);
    }

    static int Wysokość(int[] kopiec)
    {
        int h = 0;
        for (int i = 1; i < kopiec.Length; i = 2 * i + 1)
        {
            h++;
        }
        return h;
    }

    static int IleLiści(int[] kopiec)
    {
        int ile = 0;
        for (int i = 0; i < kopiec.Length; i++)
        {
            // jak nie ma nawet lewego dziecka to liść
            if (2 * i + 1 >= kopiec.Length) ile++;
        }
        return ile;
    }

    static bool CzyKopiec(int[] kopiec)
    {
        bool b = true;
        for (int i = 0; b && i < kopiec.Length/2; i++)
        {
            if (kopiec[2 * i + 1] > kopiec[i]) b=false;
            if (2 * i + 2 < kopiec.Length && kopiec[2 * i + 2] > kopiec[i]) b = false;
        }
        return b;
    }

    static void Main(string[] args)
    {
        int[] dane = { 7, 1, 16, 10, 9, 8, 27, 13, 12, 5, 3, 17, 23, 44, 55, 66, 77 };

        Console.WriteLine(CzyKopiec(dane));
        Buduj(dane);
        Console.WriteLine(CzyKopiec(dane));
        for (int i = 0; i < dane.Length; i++)
            Console.Write(dane[i] + " ");
        Console.WriteLine();
        Console.WriteLine(Wysokość(dane));
        Console.WriteLine(Math.Floor(Math.Log(dane.Length, 2)));

        // kiedy najwięcej elementów
        // gdy wszystkie poziomy zapełnione 
        // 1+ 2+ 2^2 + ... + 2^h = 2^(h+1) - 1   (suma ciągu geometrycznego)
        // h=0 =>  2^(h+1) - 1  = 1
        // h=1 =>  2^(h+1) - 1  = 3  

        // kiedy najmniej 
        // gdy na ostatnim poziomie jeden węzeł
        // 2^(h+1) - 1  - (2^h - 1) = 2^(h+1) - 2^h =  (2^h)*(2-1) = 2^h
        // h=0        = 1
        // h=1        = 2
        // h=2        = 4

        Console.WriteLine(IleLiści(dane));  // liście
        Console.WriteLine(dane.Length - IleLiści(dane));// pozostałe to elementy wewnętrzne
        // Liści jest tyle co węzłów wewnętrznych 
        // np. gdy na ostatmi poziomie jest jedno wolne miejsce
        // lub o 1 więcej 
        // np. gdy ostatni poziom jest całkowicie wypełniony

        //d) Gdzie w kopcu można znaleźć element najmniejszy?
        // w liściu

        dane = new int[] { 77, 66, 55, 44, 27, 23, 17, 16, 13, 12, 10, 9, 8, 7, 5, 3, 1 };
        //e) Czy tablica, która jest odwrotnie posortowana(tzn.nierosnąco), jest kopcem?
        // TAK
        Console.WriteLine(CzyKopiec(dane));
        Console.ReadKey();
    }
}

