using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Węzeł
{
    public String wartość;
    public ArrayList dzieci;
}
// klasa Drzewo
class Drzewo
{
    public Węzeł korzeń;
}


class Program
    {
    static List<int> BFS(int[,] tab, int start)
    {
        Queue<int> kolejka = new Queue<int>(); //kolejka
        List<int> wyniki = new List<int>();
        bool[] odwiedzone = new bool[tab.GetLength(0)];
        kolejka.Enqueue(start);

        while (kolejka.Count > 0)
        {
            int pobrany = kolejka.Dequeue();
            if (odwiedzone[pobrany] == false)
            {
                odwiedzone[pobrany] = true;
                wyniki.Add(pobrany);
                for (int i = 0; i < tab.GetLength(1); i++)
                {
                    if (tab[pobrany, i] != 0)
                    {
                        kolejka.Enqueue(i);
                    }
                }
            }
        }
        return wyniki;
    }
    static Węzeł UtwórzWęzeł(string wartość)
    {
        Węzeł węzeł = new Węzeł();
        węzeł.wartość = wartość;
        węzeł.dzieci = new ArrayList();
        return węzeł;
    }
    static void DodajWęzeł(Węzeł węzeł, Węzeł dziecko)
    {
        węzeł.dzieci.Add(dziecko);
    }
    // pre-order
    static void Wypisuj(Węzeł węzeł)
    {
        Console.Write("(" + węzeł.wartość);
        if (węzeł.dzieci.Count > 0)
        {
            for (int i = 0; i < węzeł.dzieci.Count; i++)
            {
                Wypisuj((Węzeł)węzeł.dzieci[i]);
            }
        }
        Console.Write(")");
    }
    static void LevelOrder(Drzewo d)
    {
        Queue<Węzeł> kolejka = new Queue<Węzeł>();
        kolejka.Enqueue(d.korzeń);
        while (kolejka.Count > 0)
        {
            Węzeł pobrany = kolejka.Dequeue();
            Console.Write(pobrany.wartość+" ");
            for (int i = 0; i < pobrany.dzieci.Count; i++)
            {
                kolejka.Enqueue((Węzeł)pobrany.dzieci[i]);
            }
           
        }
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
        DodajWęzeł(wD, wC);
        DodajWęzeł(wD, wE);
        DodajWęzeł(wB, wA);
        DodajWęzeł(wB, wD);
        DodajWęzeł(wI, wH);
        DodajWęzeł(wG, wI);
        DodajWęzeł(drzewo.korzeń, wB);
        DodajWęzeł(drzewo.korzeń, wG);
        Console.WriteLine("Pre");
        Wypisuj(drzewo.korzeń);
        Console.WriteLine();
        LevelOrder(drzewo);
        Console.ReadLine();
        }
    }

