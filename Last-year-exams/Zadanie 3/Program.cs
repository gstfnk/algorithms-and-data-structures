using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkaPriorytetowa
{
    class Program
    {

        static int Zwracaj(int b, int[] w)
        {
            return w[b];
        }

        static void Main(string[] args)
        {

            List<List<int>> testowa1 = new List<List<int>>();

            int[,] graf1 =
            {
                {0,1,1,0,0,0},
                {1,0,0,1,0,0},
                {1,0,0,1,1,0},
                {0,1,1,0,1,1},
                {0,0,1,1,0,0},
                {0,0,0,1,0,0}

            };

            for (int i = 0; i < graf1.GetLength(0); i++)
            {
                List<int> lista = new List<int>();
                for (int j = 0; j < graf1.GetLength(1); j++)
                {
                    if (graf1[i, j] > 0)
                    {
                        lista.Add(j);
                    }
                }
                testowa1.Add(lista);
            }

            int[] t = BFS(testowa1, 0);


            Console.WriteLine("2 koszt " + Zwracaj(1, t));
            Console.WriteLine("3 koszt " + Zwracaj(2, t));
            Console.WriteLine("4 koszt " + Zwracaj(3, t));
            Console.WriteLine("5 koszt " + Zwracaj(4, t));
            Console.WriteLine("6 koszt " + Zwracaj(5, t));

            Console.ReadKey();

        }

        static int[] BFS(List<List<int>> lista, int wierzchołek)
        {
            Queue<int> kolejka = new Queue<int>();

            int[] values = new int[lista.Count];
            values[wierzchołek] = 0;

            bool[] L = new bool[lista.Count];
            L[wierzchołek] = true;

            kolejka.Enqueue(wierzchołek);

            while (kolejka.Count != 0)
            {
                int temporary = kolejka.Dequeue();

                for (int i = 0; i < lista[temporary].Count; i++)
                {

                    if (L[lista[temporary][i]] == false)
                    {

                        kolejka.Enqueue(lista[temporary][i]);

                        values[lista[temporary][i]] = values[temporary] + 1;
                        L[lista[temporary][i]] = true;
                    }
                }
            }

            return values;
        }
    }
}
