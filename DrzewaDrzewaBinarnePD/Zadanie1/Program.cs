using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    // Zadanie 1. 
    // Dla drzewa binarnego w implementacji dowiązaniowej napisz metodę 
    // znajdującą ojca dla danego węzła w drzewie (uwaga nie zmieniamy implementacji 
    // tzn. nie dodajemy referencji rodzic).

    // Implementacja dowiązaniowa
    class Węzeł
    {
        public String wartość;
        public Węzeł lewy;
        public Węzeł prawy;
    }

    class Drzewo
    {
        public Węzeł korzeń;
    }
    class Program
    {
        static Węzeł UtwórzWęzeł(String wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            return węzeł;
        }
        static void InicjujWęzeł(Węzeł węzeł, String wartość)
        {
            węzeł.wartość = wartość;
        }

        static void DodajLewy(Węzeł węzeł, Węzeł dziecko)
        {
            węzeł.lewy = dziecko;
        }
        static void DodajPrawy(Węzeł węzeł, Węzeł dziecko)
        {
            węzeł.prawy = dziecko;
        }

        static void ZnajdźOjca(Węzeł węzeł, string wartosc, string rodzic = "")
        {
            if (węzeł == null)
            {
                return;
            }
            if (wartosc == węzeł.wartość)
            {
                Console.WriteLine(rodzic);
            }
            else
            {
                ZnajdźOjca(węzeł.lewy, wartosc, węzeł.wartość);
                ZnajdźOjca(węzeł.prawy, wartosc, węzeł.wartość);
            }
        }

        static void ZnajdźOjca2(Węzeł korzeń, Węzeł dziecko, string rodzic = "")
        {
            if (korzeń==null)
            {
                return;
            }
            if (dziecko.wartość==korzeń.wartość)
            {
                Console.WriteLine(rodzic);
            }
            else
            {
                ZnajdźOjca(korzeń.lewy, dziecko.wartość, korzeń.wartość);
                ZnajdźOjca(korzeń.prawy, dziecko.wartość, korzeń.wartość);
            }
        }
        static void Main(string[] args)
        {
            Drzewo drzewo = new Drzewo();

            drzewo.korzeń = UtwórzWęzeł("F");
            Węzeł wB = UtwórzWęzeł("B");
            Węzeł wA = UtwórzWęzeł("A");
            Węzeł wC = UtwórzWęzeł("C");
            Węzeł wD = UtwórzWęzeł("D");
            Węzeł wE = UtwórzWęzeł("E");
            Węzeł wG = UtwórzWęzeł("G");
            Węzeł wH = UtwórzWęzeł("H");
            Węzeł wI = UtwórzWęzeł("I");

            DodajLewy(wD, wC);
            DodajPrawy(wD, wE);
            DodajLewy(wB, wA);
            DodajPrawy(wB, wD);

            DodajLewy(wI, wH);
            DodajPrawy(wG, wI);

            DodajLewy(drzewo.korzeń, wB);
            DodajPrawy(drzewo.korzeń, wG);

            ZnajdźOjca(drzewo.korzeń, "B");
            ZnajdźOjca2(drzewo.korzeń, wB);

            Console.ReadKey();
        }
    }
}
