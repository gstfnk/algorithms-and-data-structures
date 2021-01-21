using System;
using System.Collections;

//1. Zaimplementuj Zbiór wykorzystując klasę Hashtable z .NET. 
//Nie musimy implementować całego interfejsu ISet<T> 
//(wystarczy Dodaj, Usuń, CzyZawiera, CzęśćWspólnaZbiorów, SumaZbiorów).

namespace Zadanie1
{
    class Zbiór
    {
        public Hashtable elementy = new Hashtable();

        public void Usuń(Object klucz)
        {
            if (elementy.ContainsKey(klucz))
            {
                elementy.Remove(klucz);
            }
        }

        public bool CzyZawiera(Object klucz)
        {
            return elementy.ContainsKey(klucz.GetHashCode());
        }

        public static Zbiór SumaZbiorów(Zbiór a, Zbiór b)
        {
            Zbiór wynik = new Zbiór();

            foreach (DictionaryEntry item in a.elementy)
            {
                wynik.Dodaj(item.Value);
            }

            foreach (DictionaryEntry item in b.elementy)
            {
                if (!wynik.CzyZawiera(item.Key))
                {
                    wynik.Dodaj(item.Value);
                }
            }

            return wynik;
        }

        public static Zbiór CzęśćWspólnaZbiorów(Zbiór a, Zbiór b)
        {
            Zbiór wynik = new Zbiór();

            foreach (DictionaryEntry item in a.elementy)
            {
                if (b.CzyZawiera(item.Key))
                {
                    wynik.Dodaj(item.Value);
                }
            }

            return wynik;
        }

        public void Dodaj(Object wartość)
        {
            elementy.Add(wartość.GetHashCode(), wartość);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zbiór zbiorek1 = new Zbiór();

            zbiorek1.Dodaj("7");
            zbiorek1.Dodaj("5");
            zbiorek1.Dodaj("1");

            Zbiór zbiorek2 = new Zbiór();

            zbiorek2.Dodaj("1");
            zbiorek2.Dodaj("8");
            zbiorek2.Dodaj("4");

            Zbiór zbiorkiCzęśćWspólna = Zbiór.CzęśćWspólnaZbiorów(zbiorek1, zbiorek2);


            Console.WriteLine("CZĘŚĆ WSPÓLNA:");

            foreach (DictionaryEntry item in zbiorkiCzęśćWspólna.elementy)
            {
                Console.WriteLine("wartość: {0}", item.Value);
            }

            Console.WriteLine("---------------------------------------");

            Zbiór zbiorkiSumaZbiorów = Zbiór.SumaZbiorów(zbiorek1, zbiorek2);

            Console.WriteLine("SUMA:");

            foreach (DictionaryEntry item in zbiorkiSumaZbiorów.elementy)
            {
                Console.WriteLine("wartość: {0}", item.Value);
            }

            Console.ReadKey();
        }
    }
}
