using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7zLAB013
{
    // Mamy wszystkie miasta wojewódzkie i odległości pomiędzy nimi (miasta.pdf).
    // Znajdź najkrótsze ścieżki z Warszawy do pozostałych miast wojewódzkich wiedząc, 
    // że bezpośrednio można przemieszczać się tylko do stolicy województw sąsiednich
    // (przykładowo z Lublina można jechać tylko do Białegostoku, Rzeszowa, Kielc lub Warszawy).

    class Program
    {
        static void Main(string[] args)
        {
            List<List<Krawedz>> G = new List<List<Krawedz>>();

            int[,] dystans =
            {
            { 0, 194, 214, 0, 258, 0, 0, 0, 0, 0, 0, 133, 177, 0, 161, 0},          //Warszawa
            { 194, 0, 224, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0},                //Białystok
            { 214, 224, 0, 157, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},              //Olsztyn
            { 0, 0, 157, 0, 174, 303, 340, 0, 0, 0, 0, 0, 0, 0, 0, 0},              //Gdańsk
            { 258, 0, 206, 174, 0, 129, 0, 0, 0, 0, 0, 202, 0, 0, 0, 0},            //Bydgoszcz
            { 0, 0, 0, 303, 129, 0, 238, 132, 171, 255, 0, 201, 0 , 0, 0, 0},       //Poznań
            { 0, 0, 0, 340, 0, 238, 0, 217, 0, 0, 0, 0, 0, 0, 0, 0},                //Szczecin
            { 0, 0, 0, 0, 0, 132, 217, 0, 153, 0, 0, 0, 0, 0, 0, 0},                //Zielona Góra
            { 0, 0, 0, 0, 0, 171, 0, 153, 0, 84, 0, 0, 0, 0, 0, 0},                 //Wrocław
            { 0, 0, 0, 0, 0, 255, 0, 0, 84, 0, 100, 184, 0, 0, 0, 0},               //Opole
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 193, 161, 81, 0, 0},               //Katowice
            { 133, 0, 0, 0, 202, 201, 0, 0, 0, 184, 193, 0, 147, 0, 0, 0},          //Łódź
            { 177, 0, 0, 0, 0, 0, 0, 0, 0, 0, 161, 147, 0, 117, 179, 168},          //Kielce
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 81, 0, 117, 0, 0, 162},                 //Kraków
            { 161, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 117, 0, 0, 168},              //Lublin
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 168, 162, 168, 0},                //Rzeszów
            };


            //Numeracja
            for (int i = 0; i < dystans.GetLength(0); i++)
            {
                List<Krawedz> lista = new List<Krawedz>();
                for (int j = 0; j < dystans.GetLength(1); j++)
                {
                    if (dystans[i, j] > 0)
                    {
                        lista.Add(new Krawedz(j, dystans[i, j]));
                    }
                }
                G.Add(lista);
            }

            int s = 0;
            int[] w = AlgorytmDijkstry(G, s);

            string[] miasta = { "Warszawy",
                                "Białegostoku",
                                "Olsztyna",
                                "Gdańska",
                                "Bydgoszczy",
                                "Poznania",
                                "Szczecina",
                                "Zielonej Góry",
                                "Wrocławia",
                                "Opola",
                                "Katowic",
                                "Łodzi",
                                "Kielc",
                                "Krakowa",
                                "Lublina",
                                "Rzeszowa" };

            for (int i = 1; i < w.Length; i++)
            {
                Console.WriteLine("Z {0} do {1} minimalna długość drogi wynosi {2} km", miasta[s], miasta[i], w[i]);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        // Algorytm Dijkstry służy do znajdowania najkrótszej ścieżki z pojedynczego źródła w grafie o nieujemnych wagach krawędzi
        static int[] AlgorytmDijkstry(List<List<Krawedz>> G, int s)
        {
            int n = G.Count;
            bool[] L = new bool[n];
            int[] w = new int[n];

            // Inicjacja
            for (int i = 0; i < L.Length; i++)
                w[i] = int.MaxValue;

            w[s] = 0;
            L[s] = true;

            for (int j = 0; j < G[s].Count; j++)
            {
                if (L[G[s][j].wierzcholek] == false)
                {
                    w[G[s][j].wierzcholek] = G[s][j].waga;
                }
            }

            for (int i = 1; i < n; i++)
            {
                //Znajdź pierwszy nierozważony
                int u = 0;
                for (int j = 0; j < n; j++)
                {
                    if (L[j] == false)
                    {
                        u = j;
                        break;
                    }
                }

                //Znajdź pierwszy nierozważony najbliższy s
                for (int j = 0; j < n; j++)
                {
                    if (L[j] == false && w[j] < w[u])
                    {
                        u = j;
                    }
                }

                L[u] = true;

                //Poprawianie odległości sąsiadów
                for (int j = 0; j < G[u].Count; j++)
                {
                    if (L[G[u][j].wierzcholek] == false)
                    {
                        if (w[u] + G[u][j].waga < w[G[u][j].wierzcholek])
                        {
                            w[G[u][j].wierzcholek] = w[u] + G[u][j].waga;
                        }
                    }
                }
            }

            return w;
        }

    }
    class Krawedz
    {
        public int wierzcholek;
        public int waga;

        public Krawedz(int wierzcholek, int waga)
        {
            this.wierzcholek = wierzcholek;
            this.waga = waga;
        }
    }


}
