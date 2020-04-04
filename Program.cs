using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmyProjekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            // średniej i pesymistycznej złożoności wyszukiwania liniowego i binarnego.

            // Przeprowadzić analizę za pomocą instrumentacji i pomiarów czasu. W porównaniu wykorzystać tablice liczb
            // całkowitych o rozmiarze rzędu 2^30 bajtów(2^28 elementów typu uint / int).


            PesymistycznaZlozonoscWyszukiwaniaLiniowego();

            SredniaZlozonoscWyszukiwaniaLiniowego();

            PesymistycznaZlozonoscWyszukiwaniaBinarnego();

            double[] sredniaArr = new double[8];
            SredniaZlozonoscWyszukiwaniaBinarnego(ref sredniaArr);


            Wnioski(sredniaArr);


            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;

            } while (choice != ConsoleKey.Escape);
        }



        private static void SredniaZlozonoscWyszukiwaniaLiniowego()
        {
            int arrLength = Convert.ToInt32(Math.Pow(2, 28));
            int[] initialArray = new int[arrLength];
            /// Populacja tablicy
            for (int i = 0; i < initialArray.Length; i++)
            {
                initialArray[i] = (i + 1);
            }
            MyWriteLine("\n\nSrednia Zlozonosc Wyszukiwania Liniowego z_b_a_d_a_n_a\n\n");

            /// Obliczanie sredniej zlozonosci
            int counter = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < initialArray.Length / 2; i++)
            {
                if (initialArray[i] == (initialArray.Length / 2)) MyWriteLine("środek\n");
                counter++;
            }
            stopwatch.Stop();


            MyWriteLine("Średnia złożoność Wyszukiwania Liniowego wymagała dotarcia do połowy wielkości tablicy");
            MyWriteLine("Co uczyniła w {0} sekund", stopwatch.Elapsed.TotalSeconds);
            MyWriteLine("milisekund {0}", stopwatch.ElapsedMilliseconds);
            MyWriteLine("nanosekund {0}", stopwatch.Elapsed.TotalMilliseconds * 1000000);
            MyWriteLine("Lub {0} tików procesora", stopwatch.ElapsedTicks);
            MyWriteLine("Algorytm wykonał połowę z maksymalnych {0} kroków", counter);
        }


        private static void PesymistycznaZlozonoscWyszukiwaniaLiniowego()
        {
            int arrLength = Convert.ToInt32(Math.Pow(2, 28));
            int[] initialArray = new int[arrLength];
            /// Populacja tablicy
            for (int i = 0; i < initialArray.Length; i++)
            {
                initialArray[i] = (i + 1);
            }
            MyWriteLine("\n\nPesymistyczna Zlozonosc Wyszukiwania Liniowego z_b_a_d_a_n_a\n\n");

            /// Obliczanie pesymistycznej zlozonosci
            int counter = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] == initialArray.Length - 1) MyWriteLine("ostatni element\n");
                counter++;
            }
            stopwatch.Stop();
            MyWriteLine("Pesymistyczna złożoność Wyszukiwania Liniowego wymagała dotarcia do końca bądź początku tablicy");
            MyWriteLine("Co uczyniła w {0} sekund", stopwatch.Elapsed.TotalSeconds);
            MyWriteLine("milisekund {0}", stopwatch.ElapsedMilliseconds);
            MyWriteLine("nanosekund {0}", stopwatch.Elapsed.TotalMilliseconds * 1000000);
            MyWriteLine("Lub {0} tików procesora", stopwatch.ElapsedTicks);
            MyWriteLine("Algorytm wykonał wszystkie {0} kroków", counter);
        }


        private static void SredniaZlozonoscWyszukiwaniaBinarnego(ref double[] sredniaArr)
        {
            int arrLength = Convert.ToInt32(Math.Pow(2, 28));
            int[] arr = new int[arrLength];
            /// Populacja tablicy
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (i + 1);
            }
            MyWriteLine("\n\nSrednia Zlozonosc Wyszukiwania Binarnego z_b_a_d_a_n_a\n\n");


            //14 krokow
            BinarySearch(arr, 16384, ref sredniaArr);

            //15 krokow
            BinarySearch(arr, 8192, ref sredniaArr);

        }

        private static void BinarySearch(int[] arr, int v, ref double[] sredniaArr)
        {
            Stopwatch stopwatch = new Stopwatch();
            int licznik = 0;
            // Oblicz srednia zlozonosc dla wyszukiwania binarnego
            int indexPoczatkowy = 0;
            int indexKoncowy = arr.Length - 1;
            int środkowyIndex;
            int szukanaWartosc = v;

            //MyWriteLine("Tablica jest uporządkowana można przystąpić do wyszykiwania: {0}", szukanaWartosc);
            stopwatch.Start();
            while (true)
            {
                licznik++;
                środkowyIndex = (indexPoczatkowy + (indexKoncowy - indexPoczatkowy) / 2);

                if (arr[środkowyIndex] == szukanaWartosc)
                {
                    // MyWriteLine("Zakonczono algorytm poprzez odnalezienie szukanej wartości: {0}", szukanaWartosc);
                    break;
                }
                else
                {


                    if (arr[środkowyIndex] < szukanaWartosc)
                    {
                        indexPoczatkowy = środkowyIndex + 1;
                    }

                    if (arr[środkowyIndex] > szukanaWartosc)
                    {
                        indexKoncowy = środkowyIndex - 1;
                    }
                }

            };
            stopwatch.Stop();

            if (v == 16384)
            {
                sredniaArr[0] = stopwatch.ElapsedMilliseconds;
                sredniaArr[1] = stopwatch.ElapsedTicks;
                sredniaArr[2] = stopwatch.Elapsed.TotalMilliseconds * 1000000;
                sredniaArr[3] = licznik;
            }

            if (v == 8192)
            {
                sredniaArr[4] = stopwatch.ElapsedMilliseconds;
                sredniaArr[5] = stopwatch.ElapsedTicks;
                sredniaArr[6] = stopwatch.Elapsed.TotalMilliseconds * 1000000;
                sredniaArr[7] = licznik;
            }

        }

        private static void PesymistycznaZlozonoscWyszukiwaniaBinarnego()
        {
            int arrLength = Convert.ToInt32(Math.Pow(2, 28));
            int[] arr = new int[arrLength];
            /// Populacja tablicy
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (i + 1);
            }

            // Oblicz pesymistyczna zlozonosc dla wyszukiwania binarnego
            MyWriteLine("\n\nPesymistyczna Zlozonosc Wyszukiwania Binarnego z_b_a_d_a_n_a\n\n");

            Stopwatch stopwatch = new Stopwatch();
            int licznik = 0;
            int indexPoczatkowy = 0;
            int indexKoncowy = arr.Length - 1;
            int środkowyIndex;
            int szukanaWartosc = arr[arr.Length - 1];
            //MyWriteLine("Tablica jest uporządkowana można przystąpić do wyszykiwania: {0}", szukanaWartosc);
            stopwatch.Start();
            while (true)
            {
                licznik++;
                środkowyIndex = (indexPoczatkowy + (indexKoncowy - indexPoczatkowy) / 2);

                if (arr[środkowyIndex] == szukanaWartosc)
                {
                    //      MyWriteLine("Zakonczono algorytm poprzez odnalezienie szukanej wartości: {0}", szukanaWartosc);
                    break;
                }
                else
                {


                    if (arr[środkowyIndex] < szukanaWartosc)
                    {
                        indexPoczatkowy = środkowyIndex + 1;
                    }

                    if (arr[środkowyIndex] > szukanaWartosc)
                    {
                        indexKoncowy = środkowyIndex - 1;
                    }
                }

            };
            stopwatch.Stop();

            MyWriteLine("Określenie Pesymistycznej złożoności Wyszukiwania Binarnego wymagała znalezienia");
            MyWriteLine("pierwszej lub ostatniej wartosci z tablicy. Tutaj ostatniej.");
            MyWriteLine("Co uczyniła w {0} sekund", stopwatch.Elapsed.TotalSeconds);
            MyWriteLine("milisekund {0}", stopwatch.ElapsedMilliseconds);
            MyWriteLine("nanosekund {0}", stopwatch.Elapsed.TotalMilliseconds * 1000000);
            MyWriteLine("Lub {0} tików procesora", stopwatch.ElapsedTicks);
            MyWriteLine("Algorytm wykonał {0} kroków", licznik);

        }



        private static void Wnioski(double[] sredniaArr)
        {
            MyWriteLine("Określenie Średniej złożoności Wyszukiwania Binarnego wymagała znalezienia dwóch wartości.");
            MyWriteLine("Jako, że średnia złożoność wymaga wykonania połowy kroków i tym samym połowy czasu potrzebnych do zrealizowania najczarniejszego scenariusza, który wynosił 29 ktoków.");
            MyWriteLine("Do obliczenia średniego złożoności użyłem dwóch przypadków testowych");
            MyWriteLine("Wykonujących się w 14 i 15 krokach, a uzyskane wyniki podzieliłem przez 2");
            MyWriteLine("Stwierdzam, że średnia złożoność wyszukiwania binarnego na probie wielkosci 2^28 cechuje sie następująco:");

            MyWriteLine("Realizuje się w {0} sekund", ((sredniaArr[0] + sredniaArr[4]) / 2));
            MyWriteLine("nanosekund {0}", ((sredniaArr[3] + sredniaArr[6]) / 2));
            MyWriteLine("Lub {0} tików procesora", ((sredniaArr[2] + sredniaArr[5]) / 2));
            MyWriteLine("Wykonując {0} kroków", ((sredniaArr[1] + sredniaArr[4]) / 2));

            MyWriteLine("\n\nWnioski koncowe:\n\n");
            MyWriteLine("Wyszukiwanie Liniowe jest algorytmem o złożoności log (n)");
            MyWriteLine("Czas jego realizacji oraz liczba krokow jest wprost zalezna od ilosci elementow na których operuje");
            MyWriteLine("Im jest ich wiecej tym dłużej może wykonywać swoje zadanie");

            MyWriteLine("Wyszukiwanie binarne jest o wiele finezyjniejszym narzędziem");
            MyWriteLine("Ogromnie skraca czas realizacji zadania dzieląc sobie prace na etapy");
            MyWriteLine("Z kadżym zbliżając się do rezultatu.");
            MyWriteLine("Krążąc coraz bliżej niczym sęp nad ofiarą na pustyni...");


            MyWriteLine("\n\nNajmocniej przepraszam wykresów nie będzie bo jeszcze nie potrafię ich wyświetlać w konsoli.");
            MyWriteLine("Ale zapewne mieliśmy wykazać, że z racji przyjętej procedury Wyszukiwanie binarne nie wyszukuje");
            MyWriteLine("kolejnych indeksów w rosnącym czasie jak można by się intuicyjnie spodziewać.");
            MyWriteLine("");
            MyWriteLine("np dla wyszukiwania wartosci w 11 elementowej tabeli upożądkowanej wymaga to nastepujacej ilości kroków");
            Console.Write("{0,6}", 1); Console.Write("{0,6}", 2); Console.Write("{0,6}", 3); Console.Write("{0,6}", 4); Console.Write("{0,6}", 5); Console.Write("{0,6}", 6); Console.Write("{0,6}", 7); Console.Write("{0,6}", 8); Console.Write("{0,6}", 9); Console.Write("{0,6}", 10); Console.WriteLine("{0,6}", 11);
            Console.Write("{0,6}", 3); Console.Write("{0,6}", 4); Console.Write("{0,6}", 2); Console.Write("{0,6}", 4); Console.Write("{0,6}", 4); Console.Write("{0,6}", 1); Console.Write("{0,6}", 3); Console.Write("{0,6}", 4); Console.Write("{0,6}", 2); Console.Write("{0,6}", 3); Console.WriteLine("{0,6}", 4);



        }



        private static void MyWriteLine(string text, double time = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t").Append(text);
            Console.WriteLine(sb.ToString(), time);
        }

    }
}
