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
            if (korzeń.lewy == null) korzeń.lewy = węzeł;
            else WstawRekurencyjnie(korzeń.lewy, węzeł);
        }
        else
        {
            if (korzeń.prawy == null) korzeń.prawy = węzeł;
            else WstawRekurencyjnie(korzeń.prawy, węzeł);
        }
    }

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

        if (węzeł.wartość > k)
        {
            return Wyszukaj(węzeł.lewy, k);
        }
        else
        {
            return Wyszukaj(węzeł.prawy, k);
        }
    }

    //   UsuńIteracyjnieL  z wykładu
    //    według zasady krok w lewo a potem do końca w prawo

    static void UsuńIteracyjnieL(Drzewo drzewo, int wartość)
    {
        if (drzewo.korzeń == null) return;
        Węzeł tmp = drzewo.korzeń;
        Węzeł rodzic = null;
        while (tmp != null)
        {
            if (tmp.wartość == wartość)
            {
                // tylko jedno dziecko albo wcale
                if (tmp.lewy == null)
                {
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = tmp.prawy;
                    }
                    else
                    {
                        if (rodzic.lewy == tmp) rodzic.lewy = tmp.prawy;
                        else rodzic.prawy = tmp.prawy;
                    }
                }
                else if (tmp.prawy == null)
                {
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = tmp.lewy;
                    }
                    else
                    {
                        if (rodzic.lewy == tmp) rodzic.lewy = tmp.lewy;
                        else rodzic.prawy = tmp.lewy;
                    }
                }
                else if (tmp.lewy != null && tmp.prawy != null)
                {// krok w lewo
                    Węzeł qRodzic = tmp;
                    Węzeł q = tmp.lewy;
                    while (q.prawy != null) // teraz do oporu w prawo
                    {
                        qRodzic = q;
                        q = q.prawy;
                    }
                    // usuwamy q z jego miejsca a na jego miejsce 
                    // wstawiamy lewego potomka (moze byc null)
                    if (qRodzic.prawy == q)
                        qRodzic.prawy = q.lewy;
                    else
                        qRodzic.lewy = q.lewy;
                    // teraz q przenosimy na miejsce tmp
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = q;
                    }
                    else
                    {
                        if (rodzic.lewy == tmp) rodzic.lewy = q;
                        else rodzic.prawy = q;
                    }
                    // na koniec wstawiamy potomkow tmp jako potomkow q
                    q.lewy = tmp.lewy;
                    q.prawy = tmp.prawy;
                }
                return;
            }
            rodzic = tmp; // szukamy dalej
            if (tmp.wartość > wartość) tmp = tmp.lewy;
            else tmp = tmp.prawy;
        }
        return; // nie znaleziono
    }

    //Napisz w C# metodę usuwającą z drzewa BST węzeł o podanej 
    //    wartości klucza (zakładamy unikalność klucza)  
    //    według zasady krok w prawo a potem do końca w lewo
    //
    // Modyfikujemy metodę UsuńIteracyjnieL
    static void UsuńIteracyjnieP(Drzewo drzewo, int wartość)
    {
        if (drzewo.korzeń == null) return;
        Węzeł tmp = drzewo.korzeń;
        Węzeł rodzic = null;
        while (tmp != null)
        {
            if (tmp.wartość == wartość)
            {
                // tylko jedno dziecko albo wcale
                if (tmp.lewy == null)
                {
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = tmp.prawy;
                    }
                    else
                    {
                        if (rodzic.lewy == tmp) rodzic.lewy = tmp.prawy;
                        else rodzic.prawy = tmp.prawy;
                    }
                }
                else if (tmp.prawy == null)
                {
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = tmp.lewy;
                    }
                    else
                    {
                        if (rodzic.lewy == tmp) rodzic.lewy = tmp.lewy;
                        else rodzic.prawy = tmp.lewy;
                    }
                }
                else if (tmp.lewy != null && tmp.prawy != null)
                {// krok w prawo
                    Węzeł qRodzic = tmp;
                    Węzeł q = tmp.prawy;
                    while (q.lewy != null) // teraz do oporu w lewo
                    {
                        qRodzic = q;
                        q = q.lewy;
                    }
                    // usuwamy q z jego miejsca a na jego miejsce 
                    // wstawiamy lewego potomka (moze byc null)
                    if (qRodzic.lewy == q)
                        qRodzic.lewy = q.prawy;
                    else
                        qRodzic.prawy = q.prawy;
                    // teraz q przenosimy na miejsce tmp
                    if (rodzic == null) // usuwamy korzeń
                    {
                        drzewo.korzeń = q;
                    }
                    else
                    {
                        if (rodzic.prawy == tmp) rodzic.prawy = q;
                        else rodzic.lewy = q;
                    }
                    // na koniec wstawiamy potomkow tmp jako potomkow q
                    q.lewy = tmp.lewy;
                    q.prawy = tmp.prawy;
                }
                return;
            }
            rodzic = tmp; // szukamy dalej
            if (tmp.wartość > wartość) tmp = tmp.lewy;
            else tmp = tmp.prawy;
        }
        return; // nie znaleziono
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
        Console.WriteLine("----- po usunięciu 7 i 15 ------");
        Console.WriteLine();
        UsuńIteracyjnieP(drzewoA, 7);
        UsuńIteracyjnieP(drzewoA, 15);
        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine();
        Console.WriteLine("----- po usunięciu korzenia ------");
        Console.WriteLine();
        UsuńIteracyjnieP(drzewoA, 10);
        Wypisuj(drzewoA.korzeń, 0);
        Console.WriteLine();

        Console.ReadKey();
    }
}



