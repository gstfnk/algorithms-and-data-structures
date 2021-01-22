using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3_Z1
{
    class Wierzchołek
    {
        public int wartość;
        public int połączenie;
        public Wierzchołek(int wartość, int połączenie)
        {
            this.wartość = wartość;
            this.połączenie = połączenie;
        }
    }
    class Program
    {
        static List<Wierzchołek> DFS(int[,] tab, int start)
        {
            Stack<int> stos = new Stack<int>(); //stos
            List<int> wyniki = new List<int>();
            List<Wierzchołek> nieod = new List<Wierzchołek>();
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
                        else
                        {
                            if (pobrany < i)
                            {
                                nieod.Add(new Wierzchołek(pobrany, i));
                            }

                        }
                    }
                }
            }
            return nieod;
        }
        static void Main(string[] args)
        {
            int[,] tab ={
                { 0,1,0,0,1,0 }, // 0
                { 1,0,1,0,1,0 }, // 1
                { 0,1,0,1,0,0 }, // 2
                { 0,0,1,0,1,1 }, // 3
                { 1,1,0,1,0,0 }, // 4
                { 0,0,0,1,0,0 }  // 5
                 };

            int s = 0;
            List<Wierzchołek> wynik = DFS(tab, s);
            foreach (Wierzchołek i in wynik)
            {
                Console.WriteLine(i.połączenie + 1 + " nie graniczy z " + (i.wartość + 1));
            }


            Console.ReadKey();
        }
    }
}
