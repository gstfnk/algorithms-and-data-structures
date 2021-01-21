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

    // iteracyjna
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


    //Napisz w C# metodę wstawiającą węzły do drzewa BST w wersji rekurencyjnej.

    static void WstawRekurencyjnie(Drzewo drzewo, Węzeł węzeł)
    {
        if (drzewo.korzeń == null) drzewo.korzeń = węzeł;
        else
            WstawRekurencyjnie(drzewo.korzeń, węzeł);
    }

    static void WstawRekurencyjnie(Węzeł korzeń, Węzeł węzeł)
    {
        if (korzeń.wartość > węzeł.wartość)
        {
            if (korzeń.lewy == null) korzeń.lewy = węzeł;// to jest jego miejsce
            else WstawRekurencyjnie(korzeń.lewy, węzeł);// sukamy miejsca dalej
        }
        else
        {
            if (korzeń.prawy == null) korzeń.prawy = węzeł;// to jest jego miejsce
            else WstawRekurencyjnie(korzeń.prawy, węzeł);// sukamy miejsca dalej
        }
    }

    //Napisz w C# metody znajdujące w drzewie BST 
    // węzeł z maksymalnym kluczem, oraz węzeł z minimalnym kluczem.

    static int Max(Drzewo d)
    {
        Węzeł tmp = d.korzeń;
        while (tmp.prawy != null)
            tmp = tmp.prawy;
        return tmp.wartość;
    }

    static int Min(Drzewo d)
    {
        Węzeł tmp = d.korzeń;
        while (tmp.lewy != null)
            tmp = tmp.lewy;
        return tmp.wartość;
    }

    // wyszukanie
    static Węzeł Wyszukaj(Węzeł węzeł, int k)
    {
        if (węzeł == null) return null; // nie znaleziono wartości
        if (węzeł.wartość == k) return węzeł; // znaleziono

        // szukamy dalej
        if (węzeł.wartość > k)
        {
            return Wyszukaj(węzeł.lewy, k);
        }
        else
        {
            return Wyszukaj(węzeł.prawy, k);
        }
    }

    static void Main()
    {
        int[] tab = { 10, 16, 12, 7, 9, 2, 21, 6, 17, 1, 15 };

        Drzewo drzewoA = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            WstawRekurencyjnie(drzewoA, w);
        }

        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine();
        Console.WriteLine("min =" + Min(drzewoA));
        Console.WriteLine("max =" + Max(drzewoA));
        Console.WriteLine("--------------------------");
        Console.WriteLine();
        Drzewo drzewoB = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[tab.Length - 1 - i]);
            WstawRekurencyjnie(drzewoB, w);
        }

        Wypisuj(drzewoB.korzeń, 0);
        Console.WriteLine();
        Console.WriteLine("min =" + Min(drzewoB));
        Console.WriteLine("max =" + Max(drzewoB));
        Console.WriteLine("--------------------------");
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

        Wypisuj(drzewoC.korzeń, 0);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("min =" + Min(drzewoC));
        Console.WriteLine("max =" + Max(drzewoC));

        Console.WriteLine("--------------------------");
        Console.WriteLine();
        Węzeł wynik = Wyszukaj(drzewoA.korzeń, 10);
        if (wynik != null)
            Console.WriteLine("znaleziono " + wynik.wartość);
        else
            Console.WriteLine("NIE znaleziono ");
        wynik = Wyszukaj(drzewoA.korzeń, 1);
        if (wynik != null)
            Console.WriteLine("znaleziono " + wynik.wartość);
        else
            Console.WriteLine("NIE znaleziono ");
        wynik = Wyszukaj(drzewoA.korzeń, 44);
        if (wynik != null)
            Console.WriteLine("znaleziono " + wynik.wartość);
        else
            Console.WriteLine("NIE znaleziono ");
        wynik = Wyszukaj(drzewoA.korzeń, 5);
        if (wynik != null)
            Console.WriteLine("znaleziono " + wynik.wartość);
        else
            Console.WriteLine("NIE znaleziono ");

        Console.ReadKey();
    }
}


