using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2_Z2
{
    class Drzewo
    {
        public Węzeł korzeń;
    }
    class Węzeł
    {
        public int wartość;
        public Węzeł lewy;
        public Węzeł prawy;
        public Węzeł(int wartość)
        {
            this.wartość = wartość;
        }
        public Węzeł(int wartość, Węzeł lewy, Węzeł prawy)
        {
            this.wartość = wartość;
            this.lewy = lewy;
            this.prawy = prawy;
        }
        public void DodajPrawy(Węzeł prawy)
        {
            this.prawy = prawy;
        }
        public void DodajLewy(Węzeł lewy)
        {
            this.lewy = lewy;
        }
        public int Wartość
        {
            get { return wartość; }
            set { wartość = value; }
        }
        public static bool Szukaj(Węzeł w, Węzeł k)
        {
            if (w.wartość == k.wartość) 
                return true;
            if (w.wartość > k.wartość && k.prawy != null) 
                return Szukaj(w, k.prawy);
            if (w.wartość < k.wartość && k.lewy != null) 
                return Szukaj(w, k.lewy);
            return false;
        }
        public Węzeł PierwszyPrzodek(Węzeł w, Węzeł k, Węzeł s)
        {
            if (this.lewy == null && this.prawy == null) return null;
            if (s == k && Szukaj(w, this)) return k;
            if (this == w && Szukaj(k, this)) return w;
            if (Szukaj(w, this) && Szukaj(k, this))
            {
                if (w.wartość > this.wartość) return this.prawy.PierwszyPrzodek(w, k, this);
                if (w.wartość < this.wartość) return this.lewy.PierwszyPrzodek(w, k, this);
            }
            return s;
        }
    }
    class Program
    {
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

    }
}
