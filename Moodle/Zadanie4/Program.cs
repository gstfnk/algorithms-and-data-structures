using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{

    class Węzeł
    {
        public int wartość;
        public Węzeł lewy;
        public Węzeł prawy;
    }
    class Drzewo
    {
        public Węzeł korzeń;
    }

    class Program
    {
        static Węzeł UtwórzWęzeł(int wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            return węzeł;
        }

        static void Wstaw(Drzewo drzewo, Węzeł węzeł)
        {
            if (drzewo.korzeń == null) 
                drzewo.korzeń = węzeł;
            else
            {
                Węzeł tmp = drzewo.korzeń;
                while (tmp != null)
                {
                    if (tmp.wartość > węzeł.wartość)
                    {
                        if (tmp.lewy != null) 
                            tmp = tmp.lewy;
                        else
                        {
                            tmp.lewy = węzeł; return;
                        }
                    }
                    else
                    {
                        if (tmp.prawy != null) 
                            tmp = tmp.prawy;
                        else
                        {
                            tmp.prawy = węzeł; return;
                        }
                    }
                }
            }
        }

        static int[] WypisujPre(Węzeł węzeł)
        {
            Stack<Węzeł> stos = new Stack<Węzeł>();
            int[] tab = new int[100];
            int i = 0;
            stos.Push(węzeł);
            while (stos.Count != 0)
            {
                węzeł = stos.Pop();
                tab[i] = węzeł.wartość;
                i++;
                if (węzeł.prawy != null)
                {
                    stos.Push(węzeł.prawy);
                }
                if (węzeł.lewy != null)
                {
                    stos.Push(węzeł.lewy);
                }
            }
            return tab;
        }

        static Drzewo TworzenieZPreorder(int[] tab)
        {
            Drzewo drzewo1 = new Drzewo();
            for (int i = 0; i < tab.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, tab[i]);
                Wstaw(drzewo1, w);
            }
            int[] wyn = WypisujPre(drzewo1.korzeń);
            for (int i = 0; i < tab.Length; i++)
            {
                if (wyn[i] != tab[i])
                {
                    return new Drzewo();
                }
            }
            return drzewo1;
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
            Drzewo drzewo1 = new Drzewo();
            Drzewo drzewo2 = new Drzewo();
            Drzewo drzewo3 = new Drzewo();

            int[] tablica1 = { 6, 3, 1, 2, 4, 5, 7 };
            int[] tablica2 = { 6, 3, 1, 2, 4, 7, 5 };
            int[] tablica3 = { 6, 3, 1, 2, 4, 7, 5 };


            for (int i = 0; i < tablica1.Length; i++)
            {
                Węzeł w = new Węzeł();
                InicjujWęzeł(w, tablica3[i]);
                Wstaw(drzewo3, w);
            }

            drzewo1 = TworzenieZPreorder(tablica1);

            WypiszInOrdedWciecia(drzewo1.korzeń, 0);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            drzewo2 = TworzenieZPreorder(tablica2);

            WypiszInOrdedWciecia(drzewo2.korzeń, 0);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            WypiszInOrdedWciecia(drzewo3.korzeń, 0);

            Console.ReadKey();
        }
    }
}
