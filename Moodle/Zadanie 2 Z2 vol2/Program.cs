using System;
using System.Collections;
using System.Collections.Generic;

namespace pd_z2
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
        static Węzeł UtwórzWęzeł(int wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            return węzeł;
        }

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
        //static Węzeł ZnajdzWspolny(Węzeł węzeł, int a, int b)
        //{
        //    if (Poprzednik(węzeł).wartość == a && Poprzednik(węzeł).wartość == b)
        //       return węzeł;
        //  If(Poprzednik(węzeł).wartość )

        //}
        static Węzeł Następnik(Węzeł w)
        {

            Węzeł następnik = null;
            if (w == null)
            {
                return w;  //jeżeli drzewo jest puste, nie ma następnika
            }
            if (w.prawy != null)
            {
                Węzeł pomocniczy = w.prawy;
                while (pomocniczy.lewy != null)
                    pomocniczy = pomocniczy.lewy;
                następnik = pomocniczy;

            }
            return następnik;

        }
        static Węzeł Poprzednik(Węzeł w)
        {
            Węzeł poprzednik = null;
            if (w == null)
            {
                return w;
            }
            if (w.lewy != null)
            {
                Węzeł pomocniczy = w.lewy;
                while (pomocniczy.prawy != null)
                    pomocniczy = pomocniczy.prawy;
                poprzednik = pomocniczy;

            }
            return poprzednik;
        }
        static int Costam(Węzeł w, int a, int b)
        {
            Węzeł temp = new Węzeł();
            Stack<Węzeł> stos = new Stack<Węzeł>();
            stos.Push(w);
            while (stos.Count != 0)
            {
                temp = stos.Pop();
                if (temp.wartość <= a && temp.wartość >= b)
                {
                    return temp.wartość;
                }
                if (temp.wartość >= a && temp.wartość <= b)
                {
                    return temp.wartość;
                }
                if (temp.wartość <= a && temp.wartość <= b)
                {
                    stos.Push(temp.prawy);
                }
                if (temp.wartość >= a && temp.wartość >= b)
                {
                    stos.Push(temp.lewy);
                }

            }
            return 0;
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


            Wypisuj(drzewo1.korzeń, 0);

            Console.WriteLine("________________");
            Węzeł następnik = Następnik(drzewo1.korzeń);
            Console.WriteLine("Następnik: {0}", następnik.wartość);
            Węzeł poprzednik = Poprzednik(drzewo1.korzeń);
            Console.WriteLine("Poprzednik: {0}", poprzednik.wartość);
            Poprzednik(drzewo1.korzeń.prawy.prawy);
            Console.WriteLine("Poprzednik: {0}", poprzednik.wartość);

            Console.WriteLine("wspólny korzeń: ");
            Console.WriteLine(Costam(drzewo1.korzeń, 2, 4));



            Console.ReadKey();
        }
    }
}