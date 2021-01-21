using System;

namespace Zadanie2
{
    //Na bazie zadania 1 napisz klasę KolejkaPriorytetowaMin (priorytet ma element o najmniejszej wartości)  
    //przechowującą elementy typu int mającą konstruktor o parametrze int (rozmiar tablicy) 
    //oraz następujący interfejs (gdy wartości typu int):
    //int Wielkość // właściwość, aktualna liczba elementów w kolejce
    //void Wstaw(int wartość)
    //int Usun()

    class KolejkaPriorytetowaMin
    {
        public int rozmiarTablicy;
        public static int[] kopiec;
        public static int faktycznaIlośćElementów;
        public KolejkaPriorytetowaMin(int rozmiarTablicy)
        {
            this.rozmiarTablicy = rozmiarTablicy;
            kopiec = new int[rozmiarTablicy];
            faktycznaIlośćElementów = 0;
        }
        public int Wielkość
        {
            get { return rozmiarTablicy; }
        }

        //W zadaniu 1 nie robiłam kolejki na zasadzie klasy (chociaż taka możliwość też jak najbardziej jest) 
        //więc teraz staram się uprościć zapis metod dla czytelności:
        private int IndeksLewegoDziecka(int i) => 2 * i + 1;
        private int IndeksPrawegoDziecka(int i) => 2 * i + 2;
        private int IndeksRodzica(int i) => (int)Math.Floor((double)(i - 1) / 2);

        private bool MaLeweDziecko(int i) => IndeksLewegoDziecka(i) < faktycznaIlośćElementów;
        private bool MaPraweDziecko(int i) => IndeksPrawegoDziecka(i) < faktycznaIlośćElementów;
        private bool JestKorzeniem(int i) => i == 0;

        private int LeweDziecko(int i) => kopiec[IndeksLewegoDziecka(i)];
        private int PraweDziecko(int i) => kopiec[IndeksPrawegoDziecka(i)];
        private int Rodzic(int i) => kopiec[IndeksRodzica(i)];

        public void Wstaw(int value)
        {
            kopiec[faktycznaIlośćElementów] = value;
            faktycznaIlośćElementów++;
            int i = faktycznaIlośćElementów - 1;
            while (!JestKorzeniem(i) && Rodzic(i) > value)
            {
                ZamieńMiejscami(i, IndeksRodzica(i));
                i = IndeksRodzica(i);
            }
        }

        //Usuwa element o najmniejszej wartości, czyli korzeń
        public void Usun()
        {
            kopiec[0] = kopiec[faktycznaIlośćElementów - 1];
            faktycznaIlośćElementów--;
            Napraw();
        }
        private void ZamieńMiejscami(int firstIndex, int secondIndex)
        {
            int temp = kopiec[firstIndex];
            kopiec[firstIndex] = kopiec[secondIndex];
            kopiec[secondIndex] = temp;
        }

        public bool CzyJestPusta() => faktycznaIlośćElementów == 0;

        private void Napraw()
        {
            int i = 0;
            while (IndeksLewegoDziecka(i) < faktycznaIlośćElementów)
            {
                int mniejszy = IndeksLewegoDziecka(i);
                if (MaPraweDziecko(i) && PraweDziecko(i) < LeweDziecko(i))
                {
                    mniejszy = IndeksPrawegoDziecka(i);
                }

                if (kopiec[mniejszy] >= kopiec[i])
                {
                    break;
                }

                ZamieńMiejscami(mniejszy, i);
                i = mniejszy;
            }
        }
        public void Wypisz()
        {
            if (CzyJestPusta())
            {
                Console.WriteLine("Kolejka pusta!");
            }
            else
            {
                for (int i = 0; i < faktycznaIlośćElementów; i++)
                    Console.Write(kopiec[i] + " ");
                Console.WriteLine();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            KolejkaPriorytetowaMin kmp = new KolejkaPriorytetowaMin(10);
            kmp.Wypisz();

            kmp.Wstaw(1);
            kmp.Wstaw(5);
            kmp.Wstaw(2);
            kmp.Wstaw(6);
            kmp.Wstaw(4);
            kmp.Wstaw(7);
            kmp.Wstaw(11);

            kmp.Wypisz();

            kmp.Usun();
            kmp.Wypisz();

            kmp.Usun();
            kmp.Wypisz();

            kmp.Usun();
            kmp.Wypisz();

            Console.ReadKey();
        }
    }
}
