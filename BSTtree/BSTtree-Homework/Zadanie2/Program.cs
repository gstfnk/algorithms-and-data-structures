using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    //Napisz metody Poprzednik i Następnik dla drzewa BST 
    //(w sensie takim jak przy przechodzeniu drzewa w porządku in-order)
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
        static void WstawRekurencyjnie(Drzewo drzewo, Węzeł węzeł)
        {
            if (drzewo.korzeń == null) drzewo.korzeń = węzeł;
            else
                WstawRekurencyjnie(drzewo.korzeń, węzeł);
        }

        static void WstawRekurencyjnie(Węzeł korzeń, Węzeł węzeł)
        {
            if (korzeń.wartość > węzeł.wartość)
            {
                if (korzeń.lewy == null) korzeń.lewy = węzeł;
                else WstawRekurencyjnie(korzeń.lewy, węzeł);
            }
            else
            {
                if (korzeń.prawy == null) korzeń.prawy = węzeł;
                else WstawRekurencyjnie(korzeń.prawy, węzeł);
            }
        }
        static void InicjujWęzeł(Węzeł węzeł, int wartość)
        {
            węzeł.wartość = wartość;
        }
        // in-order z wcięciami (odwrotnie)
        static void WypiszInOrdedWciecia(Węzeł węzeł, int poziom)
        {

            string wcięcie = "";
            int p = poziom;
            while (p-- > 0) wcięcie += " ";
            if (węzeł == null) Console.WriteLine(wcięcie + "*");
            else
            {
                if (węzeł.lewy != null || węzeł.prawy != null)
                    WypiszInOrdedWciecia((Węzeł)węzeł.prawy, poziom + 3);
                Console.WriteLine(wcięcie + węzeł.wartość);
                if (węzeł.lewy != null || węzeł.prawy != null)
                    WypiszInOrdedWciecia((Węzeł)węzeł.lewy, poziom + 3);
            }
        }
        static void Main(string[] args)
        {
            int[] array1 = { 12, 10, 11, 14, 13, 7, 8, 6, 15 };
            Drzewo tree1 = new Drzewo();

            for (int i = 0; i < array1.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, array1[i]);
                WstawRekurencyjnie(tree1, w);
            }

            WypiszInOrdedWciecia(tree1.korzeń, 0);

            Console.WriteLine("--------");

            Console.WriteLine(Następnik(tree1.korzeń, tree1.korzeń.lewy));
            Console.WriteLine(Poprzednik(tree1.korzeń, tree1.korzeń.prawy.prawy, 15));

            Console.ReadKey();
        }
        public static Węzeł Max(Węzeł root)
        {
            while (root.prawy != null)
            {
                root = root.prawy;
            }

            return root;
        }

        //Poprzednik zrobiony rekurencyjnie
        static int Poprzednik(Węzeł korzeń, Węzeł węzeł, int klucz)
        {
            if (korzeń == null)
            {
                return węzeł.wartość;
            }

            if (korzeń.wartość == klucz)
            {
                if (korzeń.lewy != null)
                {
                    return Max(korzeń.lewy).wartość;
                }
            }

            // jeśli dany klucz jest mniejszy niż węzeł główny wywołujemy rekurencję dla lewego poddrzewa
            else if (klucz < korzeń.wartość)
            {
                return Poprzednik(korzeń.lewy, węzeł, klucz);
            }

            // jeśli dany klucz jest większy niż węzeł główny wywołujemy rekurencję  dla prawego poddrzewa
            else
            {
                //aktualizuje poprzednika do bieżącego węzła przed rekursją w prawym poddrzewie
                węzeł = korzeń;
                return Poprzednik(korzeń.prawy, węzeł, klucz);
            }
            return węzeł.wartość;
        }

        //Następnik zrobiony iteracyjnie
        static int Następnik(Węzeł korzeń, Węzeł węzeł)
        {
            if (korzeń == null)
            {
                Console.WriteLine("Brak następnika!");
                return -1;
            }

            Węzeł następny = null;

            while (korzeń != null && korzeń.wartość != węzeł.wartość)
            {
                if (korzeń.wartość > węzeł.wartość)
                {
                    następny = korzeń;
                    korzeń = korzeń.lewy;
                }
                else
                {
                    korzeń = korzeń.prawy;
                }
            }
            if (korzeń == null)
            {
                Console.WriteLine("Brak następnika!");
                return -1;
            }
            if (korzeń.prawy == null)
            {
                return następny.wartość;
            }
            korzeń = korzeń.prawy;
            while (korzeń.lewy != null)
            {
                korzeń = korzeń.lewy;
            }
            return korzeń.wartość;
        }
    }


}
