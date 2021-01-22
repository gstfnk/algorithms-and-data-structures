using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2_Y1
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
        //Dla drzewa BST napisz metodę zliczającą liczbę elementów o wartości klucza zwartej
        //w zadanym przedziale <a,b>. Zakładamy, że klucze są unikalne. Zilustruj działanie.
        //W WĘŹLE NIE MA REFERENCJI DO RODZICA!!!!

        static int TablicaZDrzewa(Węzeł w, int[] output, int i)
        {
            if (w == null)
            {
                return i;
            }
            output[i] = w.wartość;
            i++;
            if (w.lewy != null)
            {
                i = TablicaZDrzewa(w.lewy, output, i);
            }
            if (w.prawy != null)
            {
                i = TablicaZDrzewa(w.prawy, output, i);
            }
            return i;
        }
        static int IleWęzłów(Węzeł w)
        {
            int licznik = 1;
            if (w==null)
            {
                return 0;
            }
            else
            {
                licznik += IleWęzłów(w.lewy);
                licznik += IleWęzłów(w.prawy);
                return licznik;
            }
        }
        static int Zliczaj(Węzeł w, int a, int b)
        {
            if (a > b) throw new Exception("Podano nieprawidłowy przedział!");
            int[] wartościWęzłów = new int[IleWęzłów(w)];
            int pomocnicza = TablicaZDrzewa(w, wartościWęzłów, 0);
            int licznik = 0;

            for (int i = 0; i < wartościWęzłów.Length; i++)
            {
                if (wartościWęzłów[i] >= a && wartościWęzłów[i] <= b)
                {
                    licznik++;
                }
            }
            return licznik;
        }

        static void Main(string[] args)
        {
            int[] tab = { 6, 3, 1, 2, 4, 5, 7 };

            Drzewo drzewo1 = new Drzewo();

            for (int i = 0; i < tab.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, tab[i]);
                Wstaw(drzewo1, w);
            }

            //Console.WriteLine(IleWęzłów(drzewo1.korzeń));
            //Console.WriteLine(Zliczaj(drzewo1.korzeń,1,4));
            Console.WriteLine(Zliczaj(drzewo1.korzeń, 1, 4));

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
