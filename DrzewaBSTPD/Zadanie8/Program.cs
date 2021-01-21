using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie8
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
        // Metoda wstawiająca węzły do drzewa BST w wersji rekurencyjnej:
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

        static void InicjujWęzeł(Węzeł węzeł, int wartość)
        {
            węzeł.wartość = wartość;
        }

        static void Main(string[] args)
        {
            int[] array1 = { 12, 11, 14, 13, 7, 8, 6, 15 };
            Drzewo tree1 = new Drzewo();

            for (int i = 0; i < array1.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, array1[i]);
                WstawRekurencyjnie(tree1, w);
            }

            WypiszInOrdedWciecia(tree1.korzeń, 0);

            Console.WriteLine("--------");


            WstawKorzeń(ref tree1.korzeń, 10, null);
            WypiszInOrdedWciecia(tree1.korzeń, 0);

            Console.ReadKey();
        }

        //Napisz w C# metodę wstawiania węzła do korzenia przy wykorzystaniu obrotów.
        //Najpierw wstawiamy węzeł na swoje miejsce(czyli jest liściem) a następnie 
        //poprzez obroty przesuwamy ten węzeł aż stanie się korzeniem.
        static Węzeł UtwórzWęzeł(int wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            return węzeł;
        }
        public static void WstawKorzeń(ref Węzeł węzeł, int wartość, Węzeł ojciec)
        {
            if (węzeł.wartość == wartość)
                return;

            if (węzeł.wartość > wartość)
            {
                if (węzeł.lewy == null)
                {
                    węzeł.lewy = UtwórzWęzeł(wartość);
                    ObrócWPrawo(ref węzeł, ojciec);
                    return;
                }
                WstawKorzeń(ref węzeł.lewy, wartość, węzeł);
                ObrócWPrawo(ref węzeł, ojciec);
            }
            else
            {
                if (węzeł.prawy == null)
                {
                    węzeł.prawy = UtwórzWęzeł(wartość);
                    ObrócWLewo(ref węzeł, ojciec);
                    return;
                }
                WstawKorzeń(ref węzeł.prawy, wartość, węzeł);
                ObrócWLewo(ref węzeł, ojciec);
            }
        }

        static bool CzyNull(Węzeł w)
        {
            if (w == null)
                return true;
            return false;
        }
        static void Potomek(ref Węzeł węzeł, Węzeł ojciec)
        {
            //0-root 
            //null-rodzic
            //1-lewe, 
            //2-prawe

            int wynik = 0;
            if (!CzyNull(ojciec) && !CzyNull(ojciec.lewy) && (ojciec.lewy == węzeł))
                wynik = 1;
            if (!CzyNull(ojciec) && !CzyNull(ojciec.prawy) && (ojciec.prawy == węzeł))
                wynik = 2;

            if (wynik == 1)
                ojciec.lewy = węzeł;
            if (wynik == 2)
                ojciec.prawy = węzeł;

            return;
        }
        static void ObrócWLewo(ref Węzeł węzeł, Węzeł ojciec)
        {
            Potomek(ref węzeł, ojciec);

            if (węzeł.prawy == null)
                return;

            Węzeł pivot = węzeł.prawy;
            węzeł.prawy = pivot.lewy;
            pivot.lewy = węzeł;
            węzeł = pivot;
        }
        static void ObrócWPrawo(ref Węzeł węzeł, Węzeł ojciec)
        {
            Potomek(ref węzeł, ojciec);

            if (węzeł.lewy == null)
                return;

            Węzeł pivot = węzeł.lewy;
            węzeł.lewy = pivot.prawy;
            pivot.prawy = węzeł;
            węzeł = pivot;
        }
    }
}
