using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    //    Zadanie 4
    //a) Napisz metodę tworzącą drzewo Huffmana na podstawie podanego tekstu.
    //b) Napisz także metodę wypisującą jakie kody zostały przydzielone poszczególnym znakom.
    //c) (dla ambitnych) Napisz metody kodujące i dekodujące tekst kodem Huffmana

    // założenie tekst 26 znaków plus spacja
    class Węzeł : IComparable<Węzeł>
    {
        char znak;
        int waga; //krotność znaku

        Węzeł prawy;
        Węzeł lewy;

        public Węzeł(char znak, int waga)
        {
            this.znak = znak;
            this.waga = waga;
        }

        public int CompareTo(Węzeł other)
        {
            return other.waga.CompareTo(waga);
        }

        public static Węzeł Scal(Węzeł w, Węzeł v)
        {
            Węzeł nowy = new Węzeł('$', w.waga + v.waga);
            nowy.lewy = w;
            nowy.prawy = v;
            return nowy;
        }

        // UWAGA
        // WYPIWSYWANIE JEST TYLKO ILUSTRACYJNIE - TWORZYMY STRING Z ZER I JEDYNEK
        // TO OCZYWIŚCIE NIE ROBI KOMPRESJI TEKSTU WRĘCZ ODWROTNIE
        // BO KOD JEST NA OGÓŁ KILKUZNAKOWY (np. znakowi 'a' odpowiada ciąg znaków '0' i '1')
        // W RZECZYWISTOŚCI w prawdziwej implementacji
        // KODY TO CIĄGI BITÓW (0 ORAZ 1) W TABLICY BAJTÓW
        // PRAWDZIWA IMPLEMENTACJA WYMAGA PRACY Z OPERATORAMI BITOWYMI

        // idę jak w pre order ale wypisuję tylko liście
        static void WypiszKody(Węzeł w, string s)
        {
            if (w.lewy == null && w.prawy == null)
            {
                Console.WriteLine(w.znak + " - " + s);
                return;
            }
            WypiszKody(w.lewy, s + "0");
            WypiszKody(w.prawy, s + "1");
        }

        public static void WypiszKody(Węzeł w)
        {
            WypiszKody(w.lewy, "1");
            WypiszKody(w.prawy, "0");
        }
    }

    class Program
    {
        // DLA NAS TO PRZYKŁAD JAK W SPOSÓB ZAUTOMATYZOWANY TWORZYĆ
        // DRZEWO WEDŁUG PEWNEJ REGUŁY
        static Węzeł TwórzDrzewoHuffmana(string s)
        {
            int[] znaki = new int[27];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    znaki[26]++;
                }
                else
                {
                    znaki[s[i] - 'a']++;
                }
            }

            List<Węzeł> węzły = new List<Węzeł>();

            if (znaki[znaki.Length - 1] > 0)
            {
                węzły.Add(new Węzeł(' ', znaki[znaki.Length - 1]));
            }

            for (int i = 0; i < znaki.Length - 1; i++)
            {
                if (znaki[i] > 0)
                {
                    węzły.Add(new Węzeł((char)('a' + i), znaki[i]));
                }
            }

            while (węzły.Count > 1)
            {
                węzły.Sort();
                Węzeł nowy = Węzeł.Scal(węzły[węzły.Count - 1], węzły[węzły.Count - 2]);
                węzły.RemoveAt(węzły.Count - 1);
                węzły.RemoveAt(węzły.Count - 1);
                węzły.Add(nowy);
            }

            return węzły[0];
        }

        static void Main(string[] args)
        {
            Węzeł Huffman = TwórzDrzewoHuffmana("aaaaabbbc");
            Węzeł.WypiszKody(Huffman);
            //Console.WriteLine("---------------------");
            //Huffman = TwórzDrzewoHuffmana("ona ma psa o imieniu abracadabra");
            //Węzeł.WypiszKody(Huffman);

            Console.ReadKey();
        }
    }
}
