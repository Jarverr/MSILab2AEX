using System;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] Osobnik;
            int[] Osobnik;
            int[][] Populacja=new int[100][]; //składa się z osobników 
            int[][] NowaPopulacja=new int[100][];
            //powiedzmy ze mamy 60 pozycji czyli rozw mozliwych 2^60 co by zajeło ok 300 lat wiec uzyjemy alo gen zeby skrocic nakład obliczeniowy zbiór za duzy wiec to ogra
            //niczymy.
            //wygeneruj wzorzec
            Random  random = new Random();
            int[] wzorzec =new int[60];

            int number;

            for (int i = 0; i < wzorzec.Length; i++)
            {
                number=random.Next(0,2);
                //Console.WriteLine(number);
                wzorzec[i]= number;
            }
            //foreach (var item in wzorzec)
            //{
            //    Console.Write(item);
            //}


            Console.WriteLine();
            //najpierw stworzymy losowo 100 osobnikow z loswymi wartosciami na 60 pozycjach
            for (int j = 0; j < Populacja.GetLength(0); j++)
            {
                Osobnik = new int[60];
                Populacja[j] = Osobnik;
                for (int i = 0; i < Osobnik.Length; i++)
                {
                    number = random.Next(0, 2);
                    Populacja[j][i] = number;
                }
            }

            //for (int i = 0; i < Populacja.Length; i++)
            //{
            //    for (int j = 0; j < Populacja[i].Length; j++)
            //    {
            //        Console.Write(Populacja[i][j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine();

            //robimy fitness czyli porwnujemy ze wzrocem na ilu pozycjach ma się zgadzać osobnik z fitnesem jak na 3 to f=3
            int[] fitness = new int[100];
            for (int i = 0; i < Populacja.Length; i++)
            {
                fitness[i] = 0;
                for (int j = 0; j < Populacja[i].Length;j ++)
                {
                    if (wzorzec[j] == Populacja[i][j])
                        fitness[i]++;
                }
            }
            //int h = 0;
            //foreach (var item in fitness)
            //{
            //    Console.WriteLine("Osobnik{1} fitness= {0}", item,h);
            //    h++;
            //}

            //obimy selekcje - ktorzy rodzice maja wejsc do pracy krzyzowania  poprzez sume selkecji i podizelenie na ttyle koło i losujemy 1 z tego
            //albo metoda turniejowa wybieramy los 2 z nich i wybeiramy lepszego
            int[] osobnik1 = new int[60];
            int osoba1;


            int[] osobnik2 = new int[60];
            int osoba2;

            int[][] parents = new int[100][];

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = new int[2];
                for (int j = 0; j < parents[i].Length; j++)
                {
                    number = random.Next(0, 100);
                    osobnik1 = Populacja[number];
                    osoba1 = number;
                    number = random.Next(0, 100);
                    osoba2 = number;
                    osobnik2 = Populacja[number];
                    if (fitness[osoba1] > fitness[osoba2])
                        parents[i][j] = osoba1;
                    else
                        parents[i][j] = osoba2;
                }  
            }

            //krzyzowanie losowo wybrani 2 w selekjc rodizce, losujemy punkt podziału i bierzemy do dziecka jedna czesc z jednego rodzica i druga czesc z drugiego rodzica
            //generujemy tyle dzieci ile jest rodziców

            int[][] children = new int[100][];
            for (int i = 0; i < children.Length; i++)
            {
                children[i] = new int[60];
                number = random.Next(0, 60);
                for (int j = 0; j < children[i].Length; j++)
                {
                    if (j < number)
                        children[i][j] = Populacja[ parents[i][0]][j];
                    else
                        children[i][j]= Populacja[ parents[i][1]][j];
                }
            }
            //for (int i = 0; i < children.Length; i++)
            //{
            //    for (int j = 0; j < children[i].Length; j++)
            //    {
            //        Console.Write(children[i][j]);
            //    }
            //    Console.WriteLine();
            //}

            //int[][][] children = new int[100][][];
            
            //for (int i = 0; i < parents.Length; i++)
            //{
            //    children[i] = new int[2][];

            //    for (int j = 0; j < children.Length; j++)
            //    {
            //        number = random.Next(0, 60);
            //        children[i][j] = new int[60];
            //        for (int k = 0; k < children[i][j].Length; k++)
            //        {
            //            if (k < number)
            //                children[i][j][k] = Populacja[parents[i][0]][k];
            //            else
            //                children[i][j][k] = Populacja[parents[i][1]][k];
            //        }
            //    }
            //}

            //gdy mamy n dzieci zastępuje n rodziców czyli potrzebne są dwie tablice populacji
            //łaczneie z n dzieci i n rodzicó wybieramy n najlepszych
            //elityzm: powiedzmy ze wchodzi 20% najelpszych rodzicó i 80% najlepszych dzieci
            for (int i = 0; i < NowaPopulacja.Length; i++)
            {
                NowaPopulacja[i] = new int[60];
                for (int j = 0; j < NowaPopulacja[i].Length; j++)
                {
                    NowaPopulacja[i][j] = children[i][j];
                }
            }

            //wyswietlanie nowej populacji
            //for (int i = 0; i < NowaPopulacja.Length; i++)
            //{
            //    for (int j = 0; j < NowaPopulacja[i].Length; j++)
            //    {
            //        Console.Write(NowaPopulacja[i][j]);
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();


            int[] fitnessChildren = new int[100];
            for (int i = 0; i < NowaPopulacja.Length; i++)
            {
                fitnessChildren[i] = 0;
                for (int j = 0; j < NowaPopulacja[i].Length; j++)
                {
                    if (wzorzec[j] == NowaPopulacja[i][j])
                        fitnessChildren[i]++;
                }
            }
            //int h = 0;
            //foreach (var item in fitnessChildren)
            //{
            //    Console.WriteLine("Osobnik{1} fitness= {0}", item, h);
            //    h++;
            //}

            number = 0;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(fitnessChildren[i]-fitness[i]>0?number++:number--);
            }
            //cossover AEX
            //comparsion of eight evolutionary crossover operators for the vehicle routing problem

            //creating two random parents
            int[] p1 = new int[9];
            int[] p2 = new int[9];
            number = random.Next(1, 10);
            for (int i = 0; i < p1.Length; i++)
            {
                do
                {
                    number = random.Next(1, 10);
                } while (p1.Contains(number));
                p1[i] = number;
                do
                {
                    number = random.Next(1, 10);
                } while (p2.Contains(number));
                p2[i] = number;
            }
            foreach (var item in p1)
            {
                Console.Write("{0} ",item);
            }
            Console.WriteLine();
            foreach (var item in p2)
            {
                Console.Write("{0} ",item);
            }

            Console.WriteLine();
            //crossover children by AEX
            //Enumerable.Range(0,100).OrderBy(x => Guid.NewGuid()).Take(20);
            //https://codereview.stackexchange.com/questions/61338/generate-random-numbers-without-repetitions

            int[] c = new int[9];
            for (int i = 1; i < c.Length; i++)
            {
                c[i] = 0;
            }
            c[0] = p1[0]; //jezeli dobrze rozumiem dziecko pierwsza wartosc dostaje pierwsza wartosc od rodzica 1-szego a nie losowa, czy losowa?
            for (int i = 1; i < c.Length; i++)
            {
                number = Array.IndexOf(p2,c[i-1]);
                if (number==8 || c.Contains(p2[number+1])) //jezeli dobrze zrozumiałem to jak trafimy sie nam wartosc koncowa u rodzica musimy wziac randomową liczbe jak
                {
                    number = random.Next(1, 10);
                    while (c.Contains(number))
                    {
                        number = random.Next(1, 10);
                    }
                    number = Array.IndexOf(p2, number)-1;
                }
                c[i] = p2[number + 1]; //jakby to przypisywanie działało jakby hromosom był jak w przykłądzie z zadania z zajec. Mam na myśli zero jedynkowy wtedy na jakiej podstawie by szukał tego sąsiada? 
                i++; // chodzi o to co by bylo gdyby wartosci rodzicow nei były unikatowe
                number = Array.IndexOf(p1,c[i-1]);
                if (number == 8 || c.Contains(p1[number+1]))
                {
                    number = random.Next(1, 10);
                    while (c.Contains(number))
                    {
                        number = random.Next(1, 10);
                    }
                    number = Array.IndexOf(p1, number) - 1;
                }
                c[i] = p1[number + 1];
            }
            foreach (var item in c)
            {
                Console.Write("{0} ",item);
            }


        }
    }
}
