using System;
using System.Collections.Generic;

class Osoba : IComparable<Osoba>
{
    string imie;
    int wiek;
    public Osoba(string imię, int wiek)
    {
        this.imie = imię;
        this.wiek = wiek;
    }
    public override string ToString()
    {
        return "["+imie +" lat " + wiek+"]";
    }

    public int CompareTo(Osoba other)
    {
       return  wiek.CompareTo(other.wiek); // to po wieku
    }

    public class PoImieniu : IComparer<Osoba>
    {
        public int Compare(Osoba x, Osoba y)
        {
            return x.imie.CompareTo(y.imie);
        }
    }
}

class Program
{
    static void Napraw<T>(T[] kopiec, int węzeł, int wielkość) where T:IComparable<T>
    {
        int największy = węzeł; // korzeń drzewa
        int lewe = 2 * węzeł + 1;
        int prawe = 2 * węzeł + 2;
        // dopóki są dzieci
        if (lewe < wielkość && kopiec[lewe].CompareTo(kopiec[największy]) > 0)
        {
            największy = lewe;
        }
        if (prawe < wielkość && kopiec[prawe].CompareTo(kopiec[największy]) > 0)
        {
            największy = prawe;
        }
        if (największy != węzeł)
        {
            T pomoc = kopiec[węzeł];
            kopiec[węzeł] = kopiec[największy];
            kopiec[największy] = pomoc;
            Napraw(kopiec, największy, wielkość);
        }
    }

    static void Buduj<T>(T[] kopiec) where T : IComparable<T>
    {
        int wielkość = kopiec.Length;
        for (int i = (wielkość / 2 - 1); i >= 0; i--)
            Napraw(kopiec, i, kopiec.Length);
    }

    // sortowanie tablicy
    static void SortujPrzezKopcowanie<T>(T[] dane) where T : IComparable<T>
    {
        Buduj(dane);
        int wielkość = dane.Length;
        while (wielkość > 1)
        {
            // zamieniamy największy element z ostatnim
            T największy = dane[0];
            dane[0] = dane[wielkość - 1];
            dane[wielkość - 1] = największy;
            // naprawiamy zmniejszony kopiec
            wielkość = wielkość - 1;
            Napraw(dane, 0, wielkość);
        }
    }

    static void Wypisz<T>(T[] dane)
    {
        for (int i = 0; i < dane.Length; i++)
            Console.Write(dane[i] + " ");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] dane = { 7, 13, 2, 6, 8, 25, 7, 17, 20, 8, 4, 7 };
        Wypisz(dane);
        SortujPrzezKopcowanie(dane);
        Wypisz(dane);

        Osoba[] osoby = { new Osoba("Ana", 25), new Osoba("Jan", 25),  new Osoba("Jan", 22), new Osoba("Ana",24),  new Osoba("Jan", 24) };
        Wypisz(osoby);

        Array.Sort(osoby, new Osoba.PoImieniu()); // sortuję Introspection Sort z biblioteki NET
        Wypisz(osoby);
        // [Ana lat 25] [Ana lat 24] [Jan lat 25] [Jan lat 22] [Jan lat 24]
        // po sortowaniu po imieniu Ana-24 jest przed Jan-24, oraz Ana-25 jest przed Jan-25

        SortujPrzezKopcowanie(osoby); //Sortuję HeapSort
        Wypisz(osoby);
        // [Jan lat 22] [Jan lat 24] [Ana lat 24] [Jan lat 25] [Ana lat 25]
        // po sortowaniu po wieku Jan-24 jest przed Ana-24, oraz Jan-25 jest przed Ana-25 
        // Wniosek HeapSort NIE JEST STABILNY
        Console.ReadKey();
    }
}