using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FP_Set_2;
namespace FP_Set_2
{
    public class Helpers
    {
        public static int IntInput(string txt)
        {
            int[] src = IntInputArray(txt);
            return src == null ? int.MinValue : src[0];
        }

        public static int[] IntInputArray(string txt)
        {
            try
            {
                Console.Write(txt);
                char[] sep = { ' ', '.', ',', ';', '/' };
                string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                if (src.Length == 0) return null;
                int[] output = new int[src.Length];
                int i = 0;
                foreach (string s in src)
                {
                    //Console.WriteLine($"DEBUG: input {i} = {s}");
                    checked { output[i] = int.Parse(s); }
                    i++;
                }
                return output;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"ERROR: input was too high / big or too low");
                return null;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"ERROR: input 'opt' was empty");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e}");
                return null;
            }
        }

        public static string[] GenericInput(string txt)
        {
            Console.Write(txt);
            char[] sep = { ' ', '.', ',', ';', '/' };
            string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (src.Length == 0) return null;
            return src;
        }
    }
}
namespace FP_Set2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alegeti problema:\n" +
            "\t1.Numere pare\n" +
            "\t2.Numere negative, zero si pozitive\n" +
            "\t3.Suma si produsul numerelor de la 1 la n\n" +
            "\t4.Pozitia din secventa a numarului a\n" +
            "\t5.Elemente egale cu pozitia lor\n" +
            "\t6.Ordine crescatoare\n" +
            "\t7.Minimul si Maximul\n" +
            "\t8.Al n numar din sirul lui Fibonaci\n" +
            "\t9.Secventa monotona\n" +
            "\t10.Numarul maxim de numere consecutive egale din secventa\n" +
            "\t11.Suma inverselor \n" +
            "\t12.Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere\n" +
            "\t13.Secventa crescatoare rotita\n" +
            "\t14.Secventa monotona rotita\n" +
            "\t15.Secventa bitonica\n" +
            "\t16.Secventa bitonica rotita\n" +
            "\t17.Determinati daca secventa reprezinta o secventa de paranteze corecta\n");
            bool ok = true;
            while (ok)
            {
                int opt = Helpers.IntInput("Problema selectata: ");
                switch (opt)
                {
                    case 1: P1(); break;
                    case 2: P2(); break;
                    case 3: P3(); break;
                    case 4: P4(); break;
                    case 5: P5(); break;
                    case 6: P6(); break;
                    case 7: P7(); break;
                    case 8: P8(); break;
                    case 9: P9(); break;
                    case 10: P10(); break;
                    case 11: P11(); break;
                    case 12: P12(); break;
                    case 13: P13(); break;
                    case 14: P14(); break;
                    case 15: P15(); break;
                    case 16: P16(); break;
                    case 17: P17(); break;
                    case int.MinValue: Console.WriteLine("Invalid Problem number, exiting program..."); ok = false; break;
                }
            }

        }
        private static void P1()
        {
            //Se da o secventa de n numere.
            //Sa se determine cate din ele sunt pare. 

            int n, count = 0, nr;

            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 1; i < n + 1; i++)
            {

                nr = int.Parse(Console.ReadLine());
                if (nr % 2 == 0)
                    count++;

            }
            if (count != 0)
                Console.WriteLine($"Exista {count} numere pare");
            else Console.WriteLine("Nu exista numere pare");

            Console.ReadKey();
        }
        private static void P2()
        {
            // Se da o secventa de n numere.
            // Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive. 

            int n, nr, neg = 0, z = 0, p = 0;
            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");

            for (int i = 1; i <= n + 1; i++)
            {
                nr = int.Parse(Console.ReadLine());
                if (nr < 0)
                    neg++;

                else if (nr == 0)
                    z++;
                else { p++; }

            }
            if (neg != 0 || z != 0 || p != 0)
                Console.WriteLine($"Exista {neg} nr negative, {z} egale cu zero si {p} pozitive");

        }
        private static void P3()
        {
            //Calculati suma si produsul numerelor de la 1 la n. 
            int n;
            int s = 0;
            long p = 1;
            Console.WriteLine("Introduceti n: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n + 1; i++)
            {
                s = s + i;
                p = p * i;
            }
            Console.WriteLine($"Suma numerelor este {s}");
            Console.WriteLine($"Produsul numerelor este {p}");
        }
        private static void P4()
        {
            //Se da o secventa de n numere.
            //Determinati pe ce pozitie se afla in secventa un numara a.
            //Se considera ca primul element din secventa este pe pozitia zero.
            //Daca numarul nu se afla in secventa raspunsul va fi -1. 

            int n, nr, a;
            Console.Write("Introduceti numarul de elemente al secventei si valoarea cautata: ");
            n = int.Parse(Console.ReadLine());
            a = int.Parse(Console.ReadLine());

            int k = -1;

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 0; i < n; i++)
            {

                nr = int.Parse(Console.ReadLine());
                if (a == nr)

                    k = i;

            }

            Console.WriteLine($"Elementul este pe pozitia {k}");
        }
        private static void P5()
        {
            //Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa?
            //Se considera ca primul element din secventa este pe pozitia 0.



            int n, nr;

            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            int k = -1;
            int p = 0;
            for (int i = 0; i < n; i++)
            {
                nr = int.Parse(Console.ReadLine());
                k = i;
                if (nr == k)
                    p++;

            }

            Console.WriteLine($"Exista {p} elemente egale cu pozitia lor");
        }
        private static void P6()
        {
            //Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare. 
            int n, nr;

            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());
            int x = -9999999;
            int k = 1;
            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 0; i < n; i++)
            {

                nr = int.Parse(Console.ReadLine());
                if (nr <= x)
                {
                    k = 0;
                }
                else
                    x = nr;

            }
            if (k == 1)
            {
                Console.WriteLine("Numerele sunt in ordine crescatoare");
            }
            else
            {
                Console.WriteLine("Numerele nu sunt in ordine crescatoare");
            }
        }
        private static void P7()
        {
            //Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa. 
            int n, nr, min = int.MaxValue, max = 0;

            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 0; i < n; i++)
            {
                nr = int.Parse(Console.ReadLine());
                
                if (max < nr)
                {

                    max = nr;
                }
                if (nr < min)
                {

                    min = nr;
                }

            }
            Console.WriteLine($"Cea mai mica valoare este: {min} ; cea mai mare valoare este: {max}");
        }
        private static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
            private static void P8()
        {
            //Determianti al n-lea numar din sirul lui Fibonacci.
            //Sirul lui Fibonacci se construieste astfel: f1 = 0, f2 = 1, f_n = f(n - 1) + f(n - 2).Exemplu: 0, 1, 1, 2, 3, 5, 8...
            int n = int.Parse(Console.ReadLine());
            Fibonacci(n);
            Console.WriteLine(Fibonacci(n));
        }
        private static void P9()
        {
            //Sa se determine daca o secventa de n numere este monotona.
            //Secventa monotona = secventa monoton crescatoare sau monoton descrescatoare. 

            int n, nr;

            Console.Write("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());
            int x = -1;
            int k = 1;
            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 0; i < n; i++)
            {

                nr = int.Parse(Console.ReadLine());

                if (nr < x)
                {
                    k = 0;
                }
                else
                    x = nr;

            }
            if (k == 1)
            {
                Console.WriteLine("Secventa este monoton crescatoare");
            }
            else
            {
                Console.WriteLine("Secventa este monoton descrescatoare");
            }
        }
        private static void P10()
        {
            //Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa. 

            int n, nr;
            int nrc = 1;
            int l = 0;

            int i = 0;


            Console.WriteLine("Introduceti numarul de elemente al secventei");
            n = int.Parse(Console.ReadLine());
            int x = 0;
            Console.WriteLine("Introduceti elementele secventei");

            for (i = 0; i < n; i++)
            {
                nr = int.Parse(Console.ReadLine());

                if (x == nr)
                {
                    nrc++;
                }

                else
                    nrc = 1;
                x = nr;


                if (nrc > l)
                {
                    l = nrc;
                }

            }

            Console.WriteLine($"Numarul maxim de numere consecutive este: {l}");

        }
        private static void P11()
        {
            //	Se da o secventa de n numere. Se cere sa se caculeze suma inverselor acestor numere. 
            int n, nr;
            int s = 0;
            Console.WriteLine("Introduceti numarul de elemente al secventei: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Introduceti elementele secventei, pe rand (urmate de tasta Enter): ");
            for (int i = 0; i < n; i++)
            {
                int invers = 0;
                nr = int.Parse(Console.ReadLine());

                while (nr != 0)
                {
                    invers = invers * 10 + nr % 10;
                    nr = nr / 10;
                }

                s = s + invers;

            }

            Console.WriteLine($"Suma inverselor este  {s} ");
        }
        private static void P12()
        {
            //Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere.
            //Considerati fiecare astfel de grup ca fiind un cuvant, zero fiind delimitator de cuvinte.
            //De ex. pentru secventa 1, 2, 0, 3, 4, 5, 0, 0, 6, 7, 0, 0 raspunsul este 3

            string str;
            Console.WriteLine("Introduceti sirul de numere (dupa fiecare nr. apasati tasta 'Space')");
            str = Console.ReadLine();
            var str2 = String.Concat(str.Where(s => !Char.IsWhiteSpace(s)));

            int Count = 0;
            char[] delimiterChars = { '0' };

            string[] str1 = str2.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in str1)
            {

                Count++;

            }

            Console.WriteLine($"Exista {Count} grupuri de numere consecutive diferite de 0");
        }
        private static void P13()
        {
            //O <secventa crescatoare rotita> este o secventa de numere care este in ordine crescatoare
            //sau poate fi transformata intr-o secventa in ordine crescatoare prin rotiri succesive
            //(rotire cu o pozitie spre stanga = toate elementele se muta cu o pozitie spre stanga
            //si primul element devine ultimul).
            //Determinati daca o secventa de n numere este o secventa crescatoare rotita. 

            int x, i = 0, l = 0, max = int.MinValue, min;
            bool ok1 = true, ok2 = true;
            Console.WriteLine("Introduceti lungimea secventei, apoi introduceti secventa(dupa fiecare numar apasati tasta 'Space')");
            x = Helpers.IntInput("");
            min = x;
            while (x != int.MinValue)
            {
                if (i >= 1 && l > x && ok1 == true)
                {
                    ok1 = false;
                    max = l;
                    min = x;

                }
                else if (ok1 == false && (x > max && x < min) && max < min)
                {
                    ok2 = false;
                }

                i++;
                l = x;
                x = Helpers.IntInput("");
            }

            if (ok2)
                Console.WriteLine("Secventa rotita este crescatoare");
            else
                Console.WriteLine("Secventa rotita nu este crescatoare");
        }
        private static void P14()
        {
            //O <secventa monotona rotita> este o secventa de numere monotona sau poate fi transformata intr-o secventa montona prin rotiri succesive.
            //Determinati daca o secventa de n numere este o secventa monotona rotita. 
            int x, i = 0, l = 0, max1 = int.MinValue, min1, max2, min2 = int.MaxValue;
            bool ok1 = true, ok2 = true, ok3 = true, ok4 = true;
            Console.WriteLine("Introduceti cate numere sa aiba secventa, iar dupa ce apasati 'Space' incepeti sa introduceti secventa ");
            x = Helpers.IntInput("");
            min1 = max2 = x;
            while (x != int.MinValue)
            {
                if (i >= 1 && l > x && ok1 == true)
                {
                    ok1 = false;
                    max1 = l;
                    min1 = x;
                }
                else if (ok1 == false && (x > max1 || x < min1))
                {
                    ok2 = false;

                }

                if (i >= 1 && l < x && ok3 == true)
                {
                    ok3 = false;
                    min2 = l;
                    max2 = x;
                }
                else if (ok3 == false && (x < min2 || x > max2))
                {
                    ok4 = false;
                }

                i++;
                l = x;
                x = Helpers.IntInput("");
            }

            if (ok2)
                Console.WriteLine("Secventa rotita este crescatoare");
            else if
                (ok4) Console.WriteLine("Secventa rotita este descrescatoare");
            else
                Console.WriteLine("Secventa rotita nu este monotona");
        }
        private static void P15()
        {
            //O secventa bitonica este o secventa de numere care incepe monoton crescator si continua monoton descrecator.
            //De ex. 1,2,2,3,5,4,4,3 este o secventa bitonica.
            //Se da o secventa de n numere. Sa se determine daca este bitonica. 
            int x, i = 0, l = 0;
            bool ok1 = true, ok2 = false;
            Console.WriteLine("Introduceti lungimea secventei, apoi introduceti secventa(dupa fiecare numar apasati tasta 'Space') ");
            x = Helpers.IntInput("");
            while (x != int.MinValue)
            {
                if (ok1)
                    if (i >= 1 && l >= x)
                    {
                        ok1 = false;
                        ok2 = true;
                    }
                    else if (i >= 1 && l <= x)
                        ok2 = false;
                i++;
                l = x;
                x = Helpers.IntInput("");
            }
            if (ok2)
                Console.WriteLine("Secventa este bitonica");
            else
                Console.WriteLine("Secventa nu este bitonica");
        }
        private static void P16()
        {
            //O <secventa bitonica rotita> este o secventa bitonica sau una ca poate fi
            //transformata intr-o secventa bitonica prin rotiri succesive (rotire = primul element devine ultimul).
            //Se da o secventa de n numere.
            //Se cere sa se determine daca este o secventa bitonica rotita.
            int x, i = 0, l = 0, max1 = int.MinValue, min1, max2, min2 = int.MaxValue;
            bool ok1 = true, ok2 = true, ok3 = true, ok4 = false;
            Console.WriteLine("Introduceti secventa(dupa fiecare numar apasati tasta 'Enter')");
            x = Helpers.IntInput("");
            min1 = max2 = x;
            while (x != int.MinValue)
            {
                if (ok2 == true)
                {
                    if (i >= 1 && l > x && ok1 == true)
                    {
                        ok1 = false;
                        max1 = l; min1 = x;
                    }
                    else if (ok1 == false && (x > max1 || x < min1))
                    {
                        ok2 = false; ok4 = true;
                    }
                }
                else
                {
                    if (i >= 1 && l < x && ok3 == true)
                    {
                        ok3 = false;
                        min2 = l; max2 = x;
                    }
                    else if (ok3 == false && (x < min2 || x > max2))
                    {
                        ok4 = false;
                    }
                }

                i++;
                l = x;
                x = Helpers.IntInput("");
            }

            if (ok4) Console.WriteLine("Secventa rotita este bitonica");
            else Console.WriteLine("Secventa rotita nu este bitonica");
        }
        private static void P17()
        {
            //Se da o secventa de 0 si 1, unde 0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa.
            //Determinati daca secventa reprezinta o secventa de paranteze corecta si,  daca este, determinati nivelul maxim de incuibare a parantezelor.
            //De exemplu 0 1 0 0 1 0 1 1 este corecta si are nivelul maxim de incuibare 2 pe cand 0 0 1 1 1 0 este incorecta.
            Console.WriteLine("Introduceti lungimea secventei, apoi introduceti elementele (dupa fiecare numar, apasati tasta 'Enter')");
            int x = Helpers.IntInput("");
            int c1 = 0, c2 = 0;
            bool ok = false;
            while (x != int.MinValue)
            {
                if (x == 1) c1++;
                x = Helpers.IntInput("");
            }
            if (c1 % 2 == 0)
            {
                ok = true; c2 = c1 / 2;
            }
            if (ok) Console.WriteLine($"Secventa valida, grad de incuibare: {c2}");
            else Console.WriteLine("Secventa invalida");
        }
    }
}