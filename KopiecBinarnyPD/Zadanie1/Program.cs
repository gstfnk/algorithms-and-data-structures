using System;

namespace Zadanie1
{
    //Opracuj algorytm wstawiania nowej wartości do kopca, 
    //została ona opisana na wykładzie "Dodawanie elementu do kopca binarnego" (UpHeap).
    //Musisz przygotować większą tablicę i dodatkowo pamiętać ile faktycznie elementów jest w tablicy 
    //(reszta to śmieci). Metody z wykładu należy zmienić tak aby miały dodatkowy parametr faktyczną ilość 
    //elementów. Należy rozpocząć od umieszczenia nowej wartości na końcu kopca (ostatni liść). Napisz także 
    //metodę usuwania pierwszego elementu z kopca (ale kopiec ma być zachowany, wsk. wzoruj się na sortowaniu kopcowym). 
    //Narysuj kopiec po kolejnych operacjach wstawiania: 1, 5, 2, 6, 4, 7, 11, a następnie kolejno po usunięciu trzech elementów.
    class Program
    {
        //Aby usunąć pierwszy element kopca (korzeń) - zamieniam pierwszy element z ostatnim
        //(który nie jest śmieciem) i naprawiam kopiec za pomocą funkcji Napraw od 0 do faktycznej ilości elementów 
        //                                                                          (po usunięciu korzenia, więc -1)
        //Przez to, że tablica jest większa niż faktyczna ilość elementów w niej, to na indeksie przed
        //zmianą będzie na końcu widniała stara wartość, dlatego przy wypisywaniu należy wziąć to pod uwagę
        //i wypisywać do faktycznego elementu po usunięciu korzenia.

        static void UsuńPierwszyElementKopca(int[] kopiec, int faktycznaIlośćElementów)
        {
            kopiec[0] = kopiec[faktycznaIlośćElementów - 1];
            Napraw(kopiec, 0, faktycznaIlośćElementów - 1);
            //można tutaj ostatni element (który na tym etapie jest śmieciem) 
            //zamienić na zero (w tym przypadku zera traktujemy jako śmieci)
            //ale z racji że go nie wypisujemy w dalszych etapach to można pominąć
        }
        public static void ZamieńMiejscami(int[] kopiec, int indeksPierwszego, int indeksDrugiego)
        {
            int temp = kopiec[indeksPierwszego];
            kopiec[indeksPierwszego] = kopiec[indeksDrugiego];
            kopiec[indeksDrugiego] = temp;
        }
        static void Wstaw(int[] kopiec, int wartość, int faktycznaIlośćElementów)
        {
            //PSEUDOKOD:
            //wielkość = wielkość +1
            //dane[wielkość] = wartość
            //i = wielkość-1
            //dopóki (i>0 oraz dane[rodzic(i)] < wartość)
            //      zamień dane[i] z dane[rodzic(i)]
            //      i = rodzic(i)

            faktycznaIlośćElementów++;
            kopiec[faktycznaIlośćElementów] = wartość;
            int i = faktycznaIlośćElementów--;
            while (!JestKorzeniem(i) && Rodzic(kopiec,i) < wartość)
            {
                ZamieńMiejscami(kopiec, i, IndeksRodzica(i));
                i = IndeksRodzica(i);
            }
        }

        // rodzic(i) = Podłoga z (i-1)/2
        public static int IndeksRodzica(int i) => (int)Math.Floor((double)(i - 1) / 2);
        public static int Rodzic(int[] kopiec, int i) => kopiec[IndeksRodzica(i)];
        public static bool JestKorzeniem(int i) => i == 0;

        //1, 5, 2, 6, 4, 7, 11
        static void Main(string[] args)
        {
            int[] kopiec1 = new int[10];
            Wstaw(kopiec1, 1, 0);
            Wstaw(kopiec1, 5, 1);
            Wstaw(kopiec1, 2, 2);
            Wstaw(kopiec1, 6, 3);
            Wstaw(kopiec1, 4, 4);
            Wstaw(kopiec1, 7, 5);
            Wstaw(kopiec1, 11, 6);

            int[] kopiec2 = { 1, 5, 2, 6, 4, 7, 11 };
            Console.WriteLine("To wpisuje:");
            Wypisz(kopiec2, kopiec2.Length);

            Console.WriteLine("To dostaje:");
            Wypisz(kopiec1, 7);

            Console.WriteLine("Test sortowania: ");
            Sortuj(kopiec2, 7);
            Wypisz(kopiec2, 7);

            Console.WriteLine("To powinnam (wywołanie funkcji z wykładu):");
            Buduj(kopiec2, kopiec2.Length);
            Wypisz(kopiec2, 7);

            Console.WriteLine();

            Console.WriteLine("Czy mój kopiec jest kopcem? " + CzyKopiec(kopiec1, 7));
            Console.WriteLine("Liczba liści w tym kopcu wynosi " + IleLiści(kopiec1, 7));
            Console.WriteLine("Wysokość mojego kopca wynosi " + Wysokość(kopiec2, 7));

            Console.WriteLine();

            Console.WriteLine("Po pierwszym usuwaniu:");
            UsuńPierwszyElementKopca(kopiec1, 7);
            Wypisz(kopiec1, 6);
            Console.WriteLine("Czy nadal kopiec: " + CzyKopiec(kopiec1, 6));

            Console.WriteLine();

            Console.WriteLine("Po drugim usuwaniu:");
            UsuńPierwszyElementKopca(kopiec1, 6);
            Wypisz(kopiec1, 5);
            Console.WriteLine("Czy nadal kopiec: " + CzyKopiec(kopiec1, 5));

            Console.WriteLine();

            Console.WriteLine("Po trzecim usuwaniu:");
            UsuńPierwszyElementKopca(kopiec1, 5);
            Wypisz(kopiec1, 4);
            Console.WriteLine("Czy nadal kopiec: " + CzyKopiec(kopiec1, 4));

            Console.ReadKey();
        }

        //Ściągawka z ćwiczeń i wykładów dla sprawdzenia zadania
        static void Wypisz(int[] dane, int indeksy)
        {
            for (int i = 0; i < indeksy; i++)
                Console.Write(dane[i] + " ");
            Console.WriteLine();
        }
        public static int IndeksLewegoDziecka(int i) => 2 * i + 1;
        public static int IndeksPrawegoDziecka(int i) => 2 * i + 2;
        public static bool MaLeweDziecko(int i, int faktycznaIlośćElementów) => IndeksLewegoDziecka(i) < faktycznaIlośćElementów;
        public static bool MaPraweDziecko(int i, int faktycznaIlośćElementów) => IndeksPrawegoDziecka(i) < faktycznaIlośćElementów;
        public static int LeweDziecko(int[] kopiec, int i) => kopiec[IndeksLewegoDziecka(i)];
        public static int PraweDziecko(int[] kopiec, int i) => kopiec[IndeksPrawegoDziecka(i)];
        
        static void Napraw(int[] kopiec, int węzeł, int faktycznaIlośćElementów)
        {
            int największy = węzeł; // korzeń drzewa
            //int indeksLewegoDziecka = 2 * węzeł + 1;
            //int indeksPrawegoDziecka = 2 * węzeł + 2;
            // dopóki są dzieci
            if (MaLeweDziecko(węzeł, faktycznaIlośćElementów) && LeweDziecko(kopiec,węzeł) > kopiec[największy])
            {
                największy = IndeksLewegoDziecka(węzeł);
            }
            if (MaPraweDziecko(węzeł,faktycznaIlośćElementów) && PraweDziecko(kopiec,węzeł) > kopiec[największy])
            {
                największy = IndeksPrawegoDziecka(węzeł);
            }
            if (największy != węzeł)
            {
                ZamieńMiejscami(kopiec, węzeł, największy);
                Napraw(kopiec, największy, faktycznaIlośćElementów);
            }
        }
        static void Buduj(int[] kopiec, int faktycznaIlośćElementów)
        {
            int wielkość = faktycznaIlośćElementów;
            for (int i = (wielkość / 2 - 1); i >= 0; i--)
            {
                Napraw(kopiec, i, faktycznaIlośćElementów);
            }
        }
        static void Sortuj(int[] dane, int faktycznaIlośćElementów)
        {
            Buduj(dane, faktycznaIlośćElementów);

            int wielkość = faktycznaIlośćElementów;

            while (wielkość > 1)
            {
                // zamieniamy największy element z ostatnim
                int największy = dane[0];
                dane[0] = dane[wielkość - 1];
                dane[wielkość - 1] = największy;
                // naprawiamy zmniejszony kopiec
                wielkość = wielkość - 1;
                Napraw(dane, 0, wielkość);
            }
        }
        static int Wysokość(int[] kopiec, int faktycznaIlośćElementów)
        {
            int h = 0;
            for (int i = 1; i < faktycznaIlośćElementów; i = 2 * i + 1)
            {
                h++;
            }
            return h;
        }

        static int IleLiści(int[] kopiec, int faktycznaIlośćElementów)
        {
            int ile = 0;
            for (int i = 0; i < faktycznaIlośćElementów; i++)
            {
                // jak nie ma nawet lewego dziecka to liść
                if (2 * i + 1 >= faktycznaIlośćElementów)
                    ile++;
            }
            return ile;
        }

        static bool CzyKopiec(int[] kopiec, int faktycznaIlośćElementów)
        {
            bool b = true;

            for (int i = 0; b && i < faktycznaIlośćElementów / 2; i++)
            {
                if (kopiec[2 * i + 1] > kopiec[i])
                    b = false;
                if (2 * i + 2 < faktycznaIlośćElementów && kopiec[2 * i + 2] > kopiec[i])
                    b = false;
            }
            return b;
        }

    }
}
