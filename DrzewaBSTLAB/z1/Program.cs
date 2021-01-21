using System;
using System.Collections.Generic;

// klasa pomocnicza Węzeł
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
        //     Narysuj drzewo powstałe w wyniku kolejnego wstawiania
        int[] tab = { 16, 10, 6, 21, 20, 18, 13, 14, 17, 4, 11 };

        Drzewo drzewo1 = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewo1, w);
        }

        Wypisuj(drzewo1.korzeń, 0);

        Console.ReadKey();
    }
}



