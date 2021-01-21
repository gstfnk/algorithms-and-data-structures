using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    static void InicjujWęzeł(Węzeł węzeł, int wartość)
    {
        węzeł.wartość = wartość;
    }
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
    static int []  WypisujPre(Węzeł węzeł)
    {
        Stack<Węzeł> stos = new Stack<Węzeł>();
        int[] tab = new int[100];
        int i = 0;
        stos.Push(węzeł);
        while (stos.Count !=0)
        {
            węzeł = stos.Pop();
            tab[i] = węzeł.wartość;
            i++;
            if (węzeł.prawy != null)
            {
                stos.Push(węzeł.prawy);
            }
            if (węzeł.lewy != null)
            {
                stos.Push(węzeł.lewy);
            }
        }
        return tab;
    }
    static Drzewo TworzenieZPreorder(int [] tab)
    {
        Drzewo drzewo1 = new Drzewo();

        for (int i = 0; i < tab.Length; i++)
        {
            Węzeł w = new Węzeł();
            InicjujWęzeł(w, tab[i]);
            Wstaw(drzewo1, w);
        }
        int[] wyn = WypisujPre(drzewo1.korzeń);
        for (int i = 0; i < tab.Length; i++)
        {
            if (wyn[i]!=tab[i])
            {
                return new Drzewo();
            }
        }
        return drzewo1;
    }

    static void Main(string[] args)
    {
        int[] tab2 = { 35, 40, 26, 22, 39, 47, 28, 36 };
        int[] tab = { 6,3,1,2,4,5,7};
        int[] tab3 = { 6,3,1,2,4,7,5};

        //Drzewo drzewo1 = new Drzewo();

        //for (int i = 0; i < tab.Length; i++)
        //{
        //    Węzeł w = new Węzeł();
        //    InicjujWęzeł(w, tab[i]);
        //    Wstaw(drzewo1, w);
        //}

        Drzewo d1 = new Drzewo();
        Drzewo d2 = new Drzewo();
        Drzewo d3 = new Drzewo();

        d1 = TworzenieZPreorder(tab2);
        d2 = TworzenieZPreorder(tab);
        d3 = TworzenieZPreorder(tab3);

        Wypisuj(d1.korzeń, 0);
        Console.WriteLine();
        Wypisuj(d2.korzeń, 0);
        Console.WriteLine();
        Wypisuj(d3.korzeń, 0);

      
        Console.ReadKey();
    }
}

