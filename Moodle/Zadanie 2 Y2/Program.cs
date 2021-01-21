using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2_Y2
{
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
        //Dla drzewa BST napisz metodę znajdująca największą różnicę poziomów pomiędzy
        //dwoma liśćmi. Zakłdamy, że klucze są unikalne. Jeśli drzewo ma 1 liść to zwracamy 
        //wysokość drzewa
        //W WĘŹLE NIE MA REFERENCJI DO RODZICA!!!!

        static int IleLiści(Węzeł w)
        {
            if (w == null)
            {
                return 0;
            }
            if (w.lewy == null && w.prawy == null)
            {
                return 1;
            }
            else
                return IleLiści(w.lewy) + IleLiści(w.prawy);
        }

        static int PierwszyLiść(Węzeł w)
        {
            if (w == null)
            {
                return 0;
            }
            if (w.lewy == null && w.prawy == null)
            {
                return 1;
            }
            return 1 + Math.Min(PierwszyLiść(w.lewy), PierwszyLiść(w.prawy));
        }

        static int RóżnicaPoziomów(Węzeł korzeń)
        {
            if (IleLiści(korzeń) == 1)
            {
                return Wysokość(korzeń);
            }

            int pierwszy = PierwszyLiść(korzeń);
            int ostatni = Wysokość(korzeń) + 1;

            return ostatni-pierwszy;
        }

        static void Main(string[] args)
        {
            int[] tab = { 10, 6, 7, 4, 2, 5, 18, 19, 15, 16, 12 };

            Drzewo drzewo1 = new Drzewo();

            for (int i = 0; i < tab.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, tab[i]);
                Wstaw(drzewo1, w);
            }

            Console.WriteLine("Ile liści ma drzewo: " + IleLiści(drzewo1.korzeń));
            Console.WriteLine("Największa różnica: " + RóżnicaPoziomów(drzewo1.korzeń));

            Console.ReadKey();
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
    }
}
