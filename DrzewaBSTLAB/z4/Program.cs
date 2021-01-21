using System;

class Węzeł
{
    public int wartość;
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
    static int licznik = 0; // do liczenia kroków o InOrder

    static Węzeł UtwórzWęzeł(int wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;
        return węzeł;
    }

    static void InicjujWęzeł(Węzeł węzeł, int wartość)
    {
        węzeł.wartość = wartość;
    }

    // pre-order
    static void WypisujPre(Węzeł węzeł)
    {
        if (węzeł == null) return;
        Console.Write(węzeł.wartość + " ");
        WypisujPre((Węzeł)węzeł.lewy);
        WypisujPre((Węzeł)węzeł.prawy);
    }

    // post-order
    static void WypisujPost(Węzeł węzeł)
    {
        if (węzeł == null) return;
        WypisujPost((Węzeł)węzeł.lewy);
        WypisujPost((Węzeł)węzeł.prawy);
        Console.Write(węzeł.wartość + " ");
    }

    // in-order
    static void WypisujIn(Węzeł węzeł)
    {
        licznik++; // liczę wywołania WypisujIn
                   // wchodzą w to wywołania nulli na końcach
                   // a więc powinno być  2n+1 wywołań
        if (węzeł == null) return;
        WypisujIn((Węzeł)węzeł.lewy);
        Console.Write(węzeł.wartość + " ");
        WypisujIn((Węzeł)węzeł.prawy);
    }

    // in-order z wcięciami (odwrotnie)
    static void Wypisuj(Węzeł węzeł, int poziom)
    {

        string wcięcie = "";
        int p = poziom;
        while (p-- > 0) wcięcie += " ";
        if (węzeł == null) Console.WriteLine(wcięcie + "*");
        else
        {
            if (węzeł.lewy != null || węzeł.prawy != null)
                Wypisuj((Węzeł)węzeł.prawy, poziom + 3);
            Console.WriteLine(wcięcie + węzeł.wartość);
            if (węzeł.lewy != null || węzeł.prawy != null)
                Wypisuj((Węzeł)węzeł.lewy, poziom + 3);
        }
    }

    static int Wysokość(Węzeł węzeł)
    {
        int wysokość = 0;
        if (węzeł == null) return 0;
        if (węzeł.lewy != null)
            wysokość = Math.Max(wysokość, Wysokość(węzeł.lewy) + 1);
        if (węzeł.prawy != null)
            wysokość = Math.Max(wysokość, Wysokość(węzeł.prawy) + 1);
        return wysokość;
    }// Zwraca wynik


    static void Wstaw(Drzewo drzewo, Węzeł węzeł)
    {
        if (drzewo.korzeń == null) drzewo.korzeń = węzeł;
        else
        {
            Węzeł tmp = drzewo.korzeń;
            while (tmp != null)
            {
                if (tmp.wartość > węzeł.wartość)
                {
                    if (tmp.lewy != null) tmp = tmp.lewy;
                    else
                    {
                        tmp.lewy = węzeł; return;
                    }
                }
                else
                {
                    if (tmp.prawy != null) tmp = tmp.prawy;
                    else
                    {
                        tmp.prawy = węzeł; return;
                    }
                }
            }
        }
    }




    static void Main()
    {
        //     Wykaż, że czas przechodzenia drzewa w porządku in-order jest liniowy
        //     Uzasadnienie: Każdy węzeł odwiedzony jest tylko raz

        // liczę wywołania WypisujIn
        // wchodzą w to wywołania nulli na końcach
        // a więc powinno być  2n+1 wywołań

        int[] tab = { 10, 16, 12, 7, 9, 2, 21, 6, 17, 1, 15 };

        Console.WriteLine("--- 11 węzłów ----\n");
        Drzewo drzewoA = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewoA, w);
        }
        licznik = 0;
        WypisujIn(drzewoA.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();

        Drzewo drzewoB = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length - 1 - i]);
            Wstaw(drzewoB, w);
        }

        licznik = 0;
        WypisujIn(drzewoB.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();

        Drzewo drzewoC = new Drzewo();

        for (int i = 0; i < tab.Length / 2; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewoC, w);

            w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length - 1 - i]);
            Wstaw(drzewoC, w);
        }
        if (tab.Length % 2 != 0)// nieparzyste jest element środkowy
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length / 2]);
            Wstaw(drzewoC, w);
        }

        licznik = 0;
        WypisujIn(drzewoC.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();

        Console.WriteLine("--- teraz 6 węzłów ----\n");

        tab = new int[] { 9, 2, 21, 17, 1, 15 };

        drzewoA = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewoA, w);
        }
        licznik = 0;
        WypisujIn(drzewoA.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();

        drzewoB = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length - 1 - i]);
            Wstaw(drzewoB, w);
        }

        licznik = 0;
        WypisujIn(drzewoB.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();

        drzewoC = new Drzewo();

        for (int i = 0; i < tab.Length / 2; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewoC, w);

            w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length - 1 - i]);
            Wstaw(drzewoC, w);
        }
        if (tab.Length % 2 != 0)// nieparzyste jest element środkowy
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length / 2]);
            Wstaw(drzewoC, w);
        }

        licznik = 0;
        WypisujIn(drzewoC.korzeń);
        Console.WriteLine();
        Console.WriteLine("wywołań " + licznik);
        Console.WriteLine();
        Console.ReadKey();
    }
}

