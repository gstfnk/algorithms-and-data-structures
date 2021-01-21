using System;
using System.Collections.Generic;

namespace Zadanie4zLAB013
{
    //Zaimplementuj metodę oparta o DFS badającą czy graf nieskierowany jest spójny. 
    //Spójność określamy intuicyjnie – każde dwa wierzchołki można połączyć ścieżką

    class Program
    {
        static void Main(string[] args)
        {
            int[,] tab1 = {{ 0, 1, 1, 0, 0 },
                           { 1, 0, 1, 1, 0 },
                           { 1, 1, 0, 0, 1 },
                           { 0, 1, 0, 0, 1 },
                           { 0, 0, 1, 1, 0 }};

            int[,] tab2 = {{ 0, 0, 1, 0, 0 },
                           { 1, 0, 1, 0, 0 },
                           { 1, 0, 0, 0, 0 },
                           { 0, 0, 0, 0, 1 },
                           { 1, 0, 0, 1, 0 }};

            Console.WriteLine(CzySpójny(tab1,0));
            Console.WriteLine(CzySpójny(tab2,0));
            Console.Read();
        }

        static List<int> DFS(int[,] tab, int start) //Metoda pochodząca z laboratorium
        {
            Stack<int> stos = new Stack<int>();
            List<int> wyniki = new List<int>();
            bool[] odwiedzone = new bool[tab.GetLength(0)];

            stos.Push(start);
            while (stos.Count > 0)
            {
                int pobrany = stos.Pop();
                if (odwiedzone[pobrany] == false)
                {
                    odwiedzone[pobrany] = true;
                    wyniki.Add(pobrany);
                    for (int i = tab.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (tab[pobrany, i] != 0)
                        {
                            stos.Push(i);
                        }
                    }
                }
            }
            return wyniki;
        }

        // Graf spójny - graf spełniający warunek, że dla każdej pary wierzchołków istnieje ścieżka, która je łączy,
        //               czyli musimy przejść przez wszystkie wierzchołki
        // Za pomocą DFS sprawdzimy liczbę odwiedzonych wierzchołków, więc aby stwierdzić spójność grafu to ta miara
        // musi być równa liczbie wszystkich wierzchołków.

        static bool CzySpójny(int[,] tab, int start)
        {
            return tab.GetLength(0) == DFS(tab, start).Count;
        }
    }

}
