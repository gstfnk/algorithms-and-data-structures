using System;
using System.Collections.Generic;

// Zadanie 4
// a) Napisz metodę tworzącą drzewo Huffmana na podstawie podanego tekstu.
// b) Napisz także metodę wypisującą jakie kody zostały przydzielone poszczególnym znakom.
// c) (dla ambitnych) Napisz metody kodujące i dekodujące tekst kodem Huffmana
//zakładamy że tekst zawiera 26 znaków (małe litery alfabetu angielskiego) plus spacja

class Węzeł : IComparable<Węzeł>
{
    char znak;
    int waga; // krotność znaku
    Węzeł prawy;
    Węzeł lewy;

    public Węzeł(char znak, int waga)
    {
        this.znak = znak;
        this.waga = waga;
    }

    public int CompareTo(Węzeł other)
    {
        return other.waga.CompareTo(waga); // sortuje malejąco
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
        WypiszKody(w.lewy, s + "1");
        WypiszKody(w.prawy, s + "0");
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
        // 26 znaków (małe litery alfabetu angielskiego) plus spacja
        int[] znaki = new int[27];

        // zliczam krotności
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ') 
                znaki[26]++;
            else if (s[i] >= 'a' && s[i] <= 'z') // inne gdyby były ignorujemy
                znaki[s[i] - 'a']++;
        }

        // tworze listę "luźnych" węzłów
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

        // łaczę systematycznie po dwa węzły o najmniejszej wadze aż dojdę do jednego (korzenia)
        while (węzły.Count > 1)
        {
            // SPOSÓB SZYBKI ALE BARDZO NIEEFEKTYWNY
            // TU NAJLEPSZA BYŁABY KOLEJKA PRIORYTETOWA

            węzły.Sort();
            Węzeł nowy = Węzeł.Scal(węzły[węzły.Count - 1], węzły[węzły.Count - 2]);

            //usuwam węzły scalone z listy
            węzły.RemoveAt(węzły.Count - 1);
            węzły.RemoveAt(węzły.Count - 1);

            // dodaję węzeł scalony
            węzły.Add(nowy);
        }

        // powinien zostać tylko jeden węzeł na liście
        return węzły[0];
    }


    static void Main(string[] args)
    {
        Węzeł Huffman = TwórzDrzewoHuffmana("abracadabra");
        Węzeł.WypiszKody(Huffman);

        Console.WriteLine("---------------------");

        Huffman = TwórzDrzewoHuffmana("ona ma psa o imieniu abracadabra");
        Węzeł.WypiszKody(Huffman);

        Console.ReadKey();
    }
}

