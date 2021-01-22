using System;
using System.Collections.Generic;

//    Zadanie 1
// Dla drzewa(A(B(F)(D(H))(J))(C(G) (E(K)))) napisz na kartce kolejność przechodzenia 
// węzłów pre-order i post-order.
// Następnie sprawdź swoje wyniki korzystając z implementacji dowiązaniowej.

class Węzeł
{
    public String wartość;
    public List<Węzeł> dzieci;
}

// klasa Drzewo
class Drzewo
{
    public Węzeł korzeń;
}

class Program
{
    //to mógłby być konstruktor klasy Węzeł
    static Węzeł UtwórzWęzeł(String wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;
        węzeł.dzieci = new List<Węzeł>();
        return węzeł;
    }

    static void DodajWęzeł(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.dzieci.Add(dziecko);
    }

    static void WypisujPre(Węzeł węzeł)
    {
        Console.Write(" " + węzeł.wartość);
        if (węzeł.dzieci.Count > 0)
        {
            for (int i = 0; i < węzeł.dzieci.Count; i++)
            {
                WypisujPre(węzeł.dzieci[i]);
            }
        }
    }
    static void WypisujPost(Węzeł węzeł)
    {
        if (węzeł.dzieci.Count > 0)
        {
            for (int i = 0; i < węzeł.dzieci.Count; i++)
            {
                WypisujPost(węzeł.dzieci[i]);
            }
        }
        Console.Write(" " + węzeł.wartość);
    }

    //  napisz metodę sprawdzającą czy istnieje element(węzeł) o zadanej wartości.
    static bool WyszukujPre(Węzeł węzeł, String s)
    {
        if (węzeł.wartość == s)
        {
            return true;
        }

        bool b = false;

        if (węzeł.dzieci.Count > 0)
        {
            for (int i = 0; !b && i < węzeł.dzieci.Count; i++)
            {
                b = WyszukujPre(węzeł.dzieci[i], s);
            }
        }

        return b;
    }

    // (A (B(F)(D(H))(J)) (C(G)(E(K))))

    static void Main(string[] args)
    {
        Drzewo d = new Drzewo();
        d.korzeń = UtwórzWęzeł("A");
        Węzeł wB = UtwórzWęzeł("B");
        Węzeł wC = UtwórzWęzeł("C");
        Węzeł wD = UtwórzWęzeł("D");
        Węzeł wE = UtwórzWęzeł("E");
        Węzeł wF = UtwórzWęzeł("F");
        Węzeł wG = UtwórzWęzeł("G");
        Węzeł wH = UtwórzWęzeł("H");
        Węzeł wJ = UtwórzWęzeł("J");
        Węzeł wK = UtwórzWęzeł("K");

        DodajWęzeł(d.korzeń, wB);
        DodajWęzeł(d.korzeń, wC);

        DodajWęzeł(wB, wF);
        DodajWęzeł(wB, wD);
        DodajWęzeł(wB, wJ);
        DodajWęzeł(wD, wH);
        DodajWęzeł(wC, wG);
        DodajWęzeł(wC, wE);
        DodajWęzeł(wE, wK);

        WypisujPre(d.korzeń);
        Console.WriteLine();

        WypisujPost(d.korzeń);
        Console.WriteLine();

        Console.WriteLine(WyszukujPre(d.korzeń, "F"));
        Console.WriteLine(WyszukujPre(d.korzeń, "X"));

        Console.ReadKey();
    }
}

