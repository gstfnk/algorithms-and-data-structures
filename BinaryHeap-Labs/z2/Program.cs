using System;


//Zadanie 2
//Napisz metodę sprawdzającą czy tablica jest kopcem.
//Sprawdz, czy tablica  jest kopcem
//a) (27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0)
//b) (23, 17, 14, 6, 13, 10, 1, 5, 7, 12)
//Jeżeli nie, wykonaj krok po kroku(wypisuj stan tablicy) algorytm naprawiania kopca.

class Program
{
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
            Wypisz(kopiec);
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
            if (2 * i + 1 >= kopiec.Length) ile++;
        }
        return ile;
    }

    static bool CzyKopiec(int[] kopiec)
    {
        bool b = true;
        for (int i = 0; i < kopiec.Length / 2; i++)
        {
            if (kopiec[2 * i + 1] > kopiec[i])
            {
                b = false;
                Console.WriteLine(i); // wypisuję złe indeksy
            }
            if (2 * i + 2 < kopiec.Length && kopiec[2 * i + 2] > kopiec[i])
            {
                b = false;
                Console.WriteLine(i); // wypisuję złe indeksy
            }
        }
        return b;
    }

    static void Wypisz(int[] dane)
    {
        for (int i = 0; i < dane.Length; i++)
            Console.Write(dane[i] + " ");
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        int[] dane = { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };

        Console.WriteLine(CzyKopiec(dane));
        //  Buduj(dane);
        // korzystam z tego, że źle tylko w jednym węźle
        // mogę ten węzeł naprawić
        // gdyby w wielu miejscach bylo źle to raczej wywołałalibyśmy buduj
        Console.WriteLine("naprawianie");
        Napraw(dane, 2);
        Console.WriteLine("po naprawie");
        Console.WriteLine(CzyKopiec(dane));      
        for (int i = 0; i < dane.Length; i++)
            Console.Write(dane[i] + " ");
        Console.WriteLine();
        Console.WriteLine("-----------------------");
        dane = new int[] { 23, 17, 14, 6, 13, 10, 1, 5, 7, 12 };
        Console.WriteLine(CzyKopiec(dane));
        // Buduj(dane);
        // korzystam z tego, że źle tylko w jednym węźle
        // mogę ten węzeł naprawić
        // gdyby w wielu miejscach bylo źle to raczej wywołałalibyśmy buduj
        Console.WriteLine("naprawianie");
        Napraw(dane, 3);
        Console.WriteLine("po naprawie");
        Console.WriteLine(CzyKopiec(dane));
        for (int i = 0; i < dane.Length; i++)
            Console.Write(dane[i] + " ");
        Console.WriteLine();
    }
}

