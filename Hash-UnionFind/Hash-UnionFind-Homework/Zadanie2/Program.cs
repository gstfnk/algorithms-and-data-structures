using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    //2. Napisz program generujący labirynt następująca metodą: 
    //Na początku każda komnata jest otoczona ścianami. 
    //W każdym kroku wybieramy losowo ścianę i usuwamy ją, 
    //jeśli komnaty po jej obu stronach nie są jeszcze 
    //połączone żadną drogą. (zadanie z ważniaka, wykorzystujemy Union-Find)

    class Program
    {
        static void Main(string[] args)
        {
           

            Console.ReadKey();
        }

        class Węzeł
        {
            public Węzeł Rodzic { get; set; }
            public Komórka Wartość { get; set; }
            public int Ranga { get; set; }
        }

        class Set
        {

            public void ZróbZestaw(Węzeł node)
            {
                node.Rodzic = null;
                node.Ranga = 0;
            }

            public Węzeł Znajdź(Węzeł wezelek)
            {
                if (wezelek.Rodzic == null)
                {
                    return wezelek;
                }

                wezelek.Rodzic = Znajdź(wezelek.Rodzic);

                return wezelek.Rodzic;
            }

            public void Union(Węzeł wezelek1, Węzeł wezelek2)
            {
                Węzeł korzen1 = Znajdź(wezelek1);
                Węzeł korzen2 = Znajdź(wezelek2);

                if (korzen1.Ranga > korzen2.Ranga)
                {
                    korzen2.Rodzic = korzen1;
                }
                else if (korzen1.Ranga < korzen2.Ranga)
                {
                    korzen1.Rodzic = korzen2;
                }
                else if (korzen1 != korzen2)
                {
                    korzen2.Rodzic = korzen1;
                    korzen1.Ranga++;
                }
            }
        }

        class Komórka
        {
            public bool Prawa { get; set; } = true;
            public bool Dolna { get; set; } = true;
        }

        class Maze
        {
            public Komórka[,] ZbiórKomórek { get; set; }
            public int Wiersze { get; }
            public int Kolumny { get; }

            public Maze(int szerokość, int wysokość)
            {
                ZbiórKomórek = new Komórka[wysokość, szerokość];

                Wiersze = wysokość;
                Kolumny = szerokość;

                for (int y = 0; y < Wiersze; ++y)
                {
                    for (int x = 0; x < Kolumny; ++x)
                    {
                        ZbiórKomórek[y, x] = new Komórka();
                    }
                }
            }

            public override string ToString()
            {
                string output = "";

                for (int x = 0; x < Kolumny; ++x)
                {
                    output += " _";
                }

                output += "\n";

                for (int y = 0; y < Wiersze; ++y)
                {
                    output += y == 0 ? " " : "|";

                    for (int x = 0; x < Kolumny; ++x)
                    {
                        Komórka komoreczka = ZbiórKomórek[y, x];

                        if (komoreczka.Dolna && komoreczka.Prawa)
                        {
                            if (y == Wiersze - 1 && x == Kolumny - 1)
                            {
                                output += "_ ";
                            }

                            else
                            {
                                output += "_|";
                            }
                        }

                        else if (komoreczka.Dolna)
                        {
                            output += " _";
                        }

                        else if (komoreczka.Prawa)
                        {
                            output += " |";
                        }
                    }

                    output += "\n";
                }

                return output;
            }
        }


    }
}
