using System;
using System.Collections.Generic;

// Zadanie 2
// Dla drzewa binarnego w implementacji dowiązaniowej napisz:
// a) metodę wyszukującą czy istnieje element (węzeł) o zadanej wartości.
// b) metodę przechodzenia pre-order nierekurencyjną (wsk.wykorzystaj stos)

class Węzeł
{
    public String wartość;
    public Węzeł lewy;
    public Węzeł prawy;
}

// klasa Drzewo
class Drzewo
{
    public Węzeł korzeń;
}


class Program
{
    static Węzeł UtwórzWęzeł(String wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;
        return węzeł;
    }

    static void DodajLewy(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.lewy = dziecko;
    }
    static void DodajPrawy(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.prawy = dziecko;
    }

    //  metodę wyszukującą czy istnieje element(węzeł) o zadanej wartości.

    static Węzeł WyszukujPre(Węzeł węzeł, String s)
    {
        if (węzeł.wartość == s) return węzeł;
        if (węzeł.lewy != null)
        {
            Węzeł w = WyszukujPre(węzeł.lewy, s);
            if (w != null) return w;
        }
        if (węzeł.prawy != null)
        {
            Węzeł w = WyszukujPre(węzeł.prawy, s);
            if (w != null) return w;
        }
        return null;
    }

    // pre-order
    static void WypisujIterPre(Węzeł węzeł)
    {
        Węzeł m;
        Stack<Węzeł> S = new Stack<Węzeł>();
        if (węzeł == null) return;
        m = węzeł;
        while (true)
        {
            if (m != null)
            {
                Console.Write(m.wartość + " ");
                // prawą gałąź odkładamy na później
                if (m.prawy != null) 
                    S.Push(m.prawy);
                // zajmujemy się lewą gałęzią
                m = m.lewy;
            }
            else
            {
                if (S.Count == 0) return;
                m = S.Pop();
            }
        }
    }

    // nieco inny sposób ale robi to samo
    static void WypisujIterPre2(Węzeł węzeł)
    {
        Węzeł m;
        Stack<Węzeł> S = new Stack<Węzeł>();
        if (węzeł != null) S.Push(węzeł);
        while (S.Count > 0)
        {
            m = S.Pop();
            Console.Write(m.wartość + " ");

            if (m.prawy != null) S.Push(m.prawy);
            if (m.lewy != null) S.Push(m.lewy);
            // lewy jest teraz na wierzchołu stosu 
            // więc w następnym obrocie while zostanie zdjęty
        }
        //return gdy stos już pusty
    }

    static void Main(string[] args)
    {
        Drzewo drzewo = new Drzewo();

        drzewo.korzeń = UtwórzWęzeł("F");
        Węzeł wB = UtwórzWęzeł("B");
        Węzeł wA = UtwórzWęzeł("A");
        Węzeł wC = UtwórzWęzeł("C");
        Węzeł wD = UtwórzWęzeł("D");
        Węzeł wE = UtwórzWęzeł("E");
        Węzeł wG = UtwórzWęzeł("G");
        Węzeł wH = UtwórzWęzeł("H");
        Węzeł wI = UtwórzWęzeł("I");

        DodajLewy(wD, wC);
        DodajPrawy(wD, wE);

        DodajLewy(wB, wA);
        DodajPrawy(wB, wD);

        DodajLewy(wI, wH);

        DodajPrawy(wG, wI);

        DodajLewy(drzewo.korzeń, wB);
        DodajPrawy(drzewo.korzeń, wG);

        Węzeł w = WyszukujPre(drzewo.korzeń, "H");
        if (w != null) Console.WriteLine(w.wartość);
        else Console.WriteLine("nie znaleziono");

        w = WyszukujPre(drzewo.korzeń, "X");
        if (w != null) Console.WriteLine(w.wartość);
        else Console.WriteLine("nie znaleziono");

        WypisujIterPre(drzewo.korzeń);
        Console.WriteLine();
        WypisujIterPre2(drzewo.korzeń);

        Console.ReadKey();
    }
}

