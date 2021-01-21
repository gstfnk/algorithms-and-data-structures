using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Para
{
    public int wpółczynnik;
    public int wykładnik;
    public Para(int współczynnik, int wykładnik)
    {
        this.wpółczynnik = współczynnik;
        this.wykładnik = wykładnik;
    }

}
class Wielomian
{
    List<Para> wielomian = new List<Para>();
    public Wielomian()
    {

    }
    public void Dodaj(Para p)
    {
        wielomian.Add(p);
    }
}
class Program
{
    public static void Wyswietl(List<Para> w)
    {
        for (int i = 0; i < w.Count; i++)
        {
            Console.Write(w[i].wpółczynnik + "^" + w[i].wykładnik + " ");
        }
    }
    public static List<Para> Zamien(int[] tab)
    {
        List<Para> wielomian = new List<Para>();
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i] != 0)
            {
                wielomian.Add(new Para(tab[i], i));
            }
        }
        return wielomian;
    }
    public static int Szukaj(List<Para> w, int wykladnik)
    {
        Para wartownik = new Para(0, wykladnik);
        w.Add(wartownik); //wartownik
        for (int i = 0; i < w.Count; i++)
        {
            if (w[i].wykładnik == wykladnik)
            {
                if (w[i].wpółczynnik == 0)
                {
                    w.RemoveAt(w.Count - 1);
                    return -1;
                }
                w.RemoveAt(w.Count - 1);
                return i;
            }
        }
        w.RemoveAt(w.Count - 1);
        return -1;
    }
    public static List<Para> Dodaj(List<Para> w1, List<Para> w2)
    {
        List<Para> wynik = new List<Para>();
        int licznik = Math.Max(w1[w1.Count-1].wykładnik, w2[w2.Count-1].wykładnik);
        for (int i = 0; i <= licznik; i++)
        {
            int tmp1 = 0;
            int tmp2 = 0;
            if (Szukaj(w1,i)!=(-1))
            {
                tmp1 = w1[Szukaj(w1, i)].wpółczynnik;
            }
            if (Szukaj(w2, i) != (-1))
            {
                tmp2 = w2[Szukaj(w2, i)].wpółczynnik;
            }
            int wspolczynnik = tmp1 + tmp2;
            if (wspolczynnik !=0)
            {
                wynik.Add(new Para(wspolczynnik, i));
            }
        }
        return wynik;
    }
    public static List<Para> Odejmij(List<Para> w1, List<Para> w2)
    {
        List<Para> wynik = new List<Para>();
        int licznik = Math.Max(w1[w1.Count - 1].wykładnik, w2[w2.Count - 1].wykładnik);
        for (int i = 0; i <= licznik; i++)
        {
            int tmp1 = 0;
            int tmp2 = 0;
            if (Szukaj(w1, i) != (-1))
            {
                tmp1 = w1[Szukaj(w1, i)].wpółczynnik;
            }
            if (Szukaj(w2, i) != (-1))
            {
                tmp2 = w2[Szukaj(w2, i)].wpółczynnik;
            }
            int wspolczynnik = tmp1 - tmp2;
            if (wspolczynnik != 0)
            {
                wynik.Add(new Para(wspolczynnik, i));
            }
        }
        return wynik;
    }
    public static List<Para> Pochodna(List<Para> w)
    {
        List<Para> wynik = new List<Para>();
        int licznik = w.Count;
        if (licznik==0)
        {
            return wynik;
        }
        int pocz = 0;
        if (w[0].wykładnik==0)
        {
            pocz++;
        }
        for (int i = pocz; i < licznik; i++)
        {
            int wsp = w[i].wpółczynnik * w[i].wykładnik;
            int wyk = w[i].wykładnik - 1;

            Para tmp = new Para(wsp, wyk);
            wynik.Add(tmp);
        }

        return wynik;
    }

    static void Main(string[] args)
    {
        List<Para> w1 = new List<Para>();
        w1.Add(new Para(1, 0));
        w1.Add(new Para(2, 1));
        w1.Add(new Para(5, 2));
        w1.Add(new Para(8, 5));

        Wyswietl(w1);

        int[] tab = { 0, 2, 1, 3, 0, 8 };
        int[] tab2 = { -1, -2, -5, 0, 0, -8 };

        List<Para> w2 = new List<Para>();
        w2 = Zamien(tab);
        Console.WriteLine();
        Wyswietl(w2);

        List<Para> w4 = new List<Para>();
        w4 = Zamien(tab2);
        Console.WriteLine();
        Wyswietl(w4);
        Console.WriteLine();
        Console.Write("------dodawanie");
        List<Para> w3 = Dodaj(w1, w2);
        Console.WriteLine();
        Wyswietl(w3);
        w3 = Dodaj(w1, w4);
        Console.WriteLine();
        Wyswietl(w3);
        Console.WriteLine(w3.Count);
        Console.WriteLine("------odejmowanie");
        w3 = Odejmij(w1, w4);
        Console.WriteLine();
        Wyswietl(w3);
        w3 = Odejmij(w1, w2);
        Console.WriteLine();
        Wyswietl(w3);
        Console.WriteLine();
        Console.WriteLine("---------pochodna");
        w3 = Pochodna(w1);
        Console.WriteLine();
        Wyswietl(w3);
        w3 = Pochodna(w3);
        Console.WriteLine();
        Wyswietl(w3);
        w3 = Pochodna(w3);
        Console.WriteLine();
        Wyswietl(w3);
        Console.ReadKey();
    }
}

