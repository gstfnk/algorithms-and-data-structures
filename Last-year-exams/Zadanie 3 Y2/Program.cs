using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3_Y2
{
    //W krainie Rebor miasta połączone sa drogami. System dróg opisany jest przez
    //graf gdzie wierzchołkami są miasta, a krawędziami drogi. Władze Rebor 
    //postanowiły ograniczyć remonty dróg i utrzymywać tylko tyle dróg aby 
    //było możliwe dotarcie autem z jednego miasta do drugiego. 
    //Napisz metodę, która rozwiąże zadanie władz Rebor. Wykorzystaj stos

    class Miasta
    {
        int[,] drogi;

        public Miasta(int[,] drogi)
        {
            this.drogi = drogi;
        }

        //Odtąd jest DFS, czy coś podobnego w każdym razie, nie wiem sam pisałem..
        void Odwiedzenie(bool[] tab, int p) // Ta funkcja ma sprawdzić czy wciąż jest łączność pomiędzy miastami.
        {
            if (CzyCałaTrue(tab)) return;
            if (tab[p] == false)
            {
                tab[p] = true;
                //Console.WriteLine(p);
            }
            for (int i = 0; i < tab.Length; i++)
            {
                if (drogi[p, i] == 1 && tab[i] == false) Odwiedzenie(tab, i);
            }
        }
        public bool DFS()   // To funkcja która ma tylko wywoływać "Odwiedzenie", zwraca czy udało się przejść przez graf.
        {
            bool[] tab = new bool[5];
            Odwiedzenie(tab, 0);
            return CzyCałaTrue(tab);
        }
        public bool CzyCałaTrue(bool[] tab) // Sprawdza czy stworzona tablica cała jest True (True ustawiam gdy jest łączność między miastami). 
        {
            for (int i = 0; i < tab.Length; i++) if (tab[i] == false) return false;
            return true;
        }
        public void Drogi() // To jest główna funkcja.. Ma ona usuwać drogi a potem sprawdzać czy nadal jest łączność, jeżeli nie ma to znów oddaje drogę. 
        {
            int partner = 0;
            bool[] tab = new bool[5];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = false;
            while (!CzyCałaTrue(tab))
            {
                for (int j = 0; j < 5; j++)
                {
                    if (drogi[partner, j] == 1 && partner != j)
                    {
                        if (tab[partner] == true)
                        {
                            drogi[partner, j] = 0;
                            drogi[j, partner] = 0;
                            if (!DFS())
                            {
                                drogi[partner, j] = 1;
                                drogi[j, partner] = 1;
                            }
                        }
                        tab[partner] = true;
                    }
                }
                partner++;
            }
        }
        public void Wypisz()    //Wypisuje połączenia.
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) Console.Write(drogi[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] tab ={
            //    0 1 2 3 4
                { 1,1,0,0,0,0,0 }, // 1
                { 1,0,1,1,0,0,0 }, // 2
                { 0,0,1,0,1,0,0 }, // 3
                { 0,0,0,0,1,1,1 }, // 4
                { 0,1,0,1,0,1,0 }, // 5
                { 0,0,0,0,0,0,1 }  // 6
                 };
            Miasta m = new Miasta(tab);
            m.Drogi();
            m.Wypisz();
            Console.ReadKey();
        }
    }
}
