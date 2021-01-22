using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7
{
    // Napisz w C# metodę obrotu węzła w prawo i w lewo.
    // klasa pomocnicza Węzeł
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


            ObrócWLewo(ref tree1.korzeń, null);
            WypiszInOrdedWciecia(tree1.korzeń, 0);

            Console.WriteLine("--------");

            ObrócWPrawo(ref tree1.korzeń, null);
            WypiszInOrdedWciecia(tree1.korzeń, 0);

            Console.ReadKey();
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
        static void ObrócWLewo(ref Węzeł węzeł, Węzeł rodzic)
        {
            Potomek(ref węzeł, rodzic);

            if (węzeł.prawy == null) 
                return;

            Węzeł pivot = węzeł.prawy;
            węzeł.prawy = pivot.lewy;
            pivot.lewy = węzeł;
            węzeł = pivot;
        }
        static void ObrócWPrawo(ref Węzeł węzeł, Węzeł rodzic)
        {
            Potomek(ref węzeł, rodzic);

            if (węzeł.lewy == null) 
                return;

            Węzeł pivot = węzeł.lewy;
            węzeł.lewy = pivot.prawy;
            pivot.prawy = węzeł;
            węzeł = pivot;
        }

        //Pierwsze próby
        public static Węzeł ObrotWPrawo(Węzeł w)
        {
            Węzeł pom = w.lewy;
            w.lewy = pom.prawy;
            pom.prawy = w;
            w = pom;
            return w;
        }
        public static Węzeł ObrotWLewo(Węzeł w)
        {
            Węzeł pom = w.prawy;
            w.prawy = pom.lewy;
            pom.lewy = w;
            w = pom;
            return w;
        }
    }
}
