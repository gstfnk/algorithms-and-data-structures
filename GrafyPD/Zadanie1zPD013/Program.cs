using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1zPD013
{
    //Zaimplementuj metodę oparta o BFS badającą czy graf nieskierowany jest spójny. 
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

            Console.WriteLine(CzySpójny(tab1, 0));
            Console.WriteLine(CzySpójny(tab2, 0));
            Console.Read();
        }

        // Przechodzenie grafu BFS rozpoczyna się od zadanego wierzchołka s i polega na 
        // odwiedzeniu wszystkich osiągalnych z niego wierzchołków.

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

        // Graf spójny - graf spełniający warunek, że dla każdej pary wierzchołków istnieje ścieżka, która je łączy,
        //               czyli musimy przejść przez wszystkie wierzchołki
        // Za pomocą BFS sprawdzimy liczbę odwiedzonych wierzchołków, więc aby stwierdzić spójność grafu to ta miara
        // musi być równa liczbie wszystkich wierzchołków.

        static bool CzySpójny(int[,] tab, int start = 0)
        {
            return tab.GetLength(0) == BFS(tab, start).Count;
        }
    }
}
