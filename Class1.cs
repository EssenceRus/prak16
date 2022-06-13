using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;

namespace prak16
{
    class Class1
    {
        public static bool ExamFirst(string slovo)
        {
            if (slovo != string.Empty)
            {
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (char.IsDigit(slovo[i]))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public static string First(string slovo)
        {
            StreamReader sr = new StreamReader("test.txt");
            string[] mass = sr.ReadToEnd().Split(' ', '.', ',');
            int count = (from i in mass where i.ToLower() == slovo select i).Count();
            sr.Close();
            string str = $"Ваше слово {slovo} встретилось в файле {count} раз";
            return str;

        }

        public static string Second(string[] mass)
        {
            int count=0;
            for (int i = 0; i < mass.Length; i++)
            {
                char[] str = new char[mass[i].Length];
                for (int j = 0; j < mass[i].Length; j++)
                {
                    str[j] = mass[i][j];
                }
                count += (from k in str where char.IsNumber(k) select i).Count();

            }
            return $"Кол-во цифр {count}";
        }

        public static string Second2(string[] mass)
        {
            string str = string.Empty;
            var vivod = mass.TakeWhile(x => !x.Contains('/'));
            foreach (var item in vivod)
            {
                str += item + " ";
            }
            return str;
        }

        public static string Second3(string[] mass)
        {
            string str = string.Empty;
            var vivod = mass.SkipWhile(x => !x.Contains('/'));
            foreach (var item in vivod)
            {
                str += item+ " ";
            }
            string vivod2 = new string(str.Select(ch => char.IsLower(ch) ? char.ToUpper(ch) : char.ToLower(ch)).ToArray());
            StreamWriter sr = new StreamWriter("zad2.txt");
            sr.WriteLine(vivod2);
            sr.Close();
            return vivod2;
        }

        //public static double[] Third(double[] mass)
        //{
        //    double[] mass3 = new double[mass.Length];
        //    int[] mass2 = new int[mass.Length];
        //    for (int i = 0; i < mass.Length; i++)
        //    {
                
        //        if (!mass3.Contains(mass[i]))
        //        {
        //            int count = (from x in mass where x == mass[i] select x).Count();
        //            mass2[i] = count;
        //            mass3[i] = mass[i];
        //        }
        //    }
        //    return mass3;
        //}

        //public static int[] Third2(double[] mass)
        //{
        //    double[] mass3 = new double[mass.Length];
        //    int[] mass2 = new int[mass.Length];
        //    for (int i = 0; i < mass.Length; i++)
        //    {

        //        if (!mass3.Contains(mass[i]))
        //        {
        //            int count = (from x in mass where x == mass[i] select x).Count();
        //            mass2[i] = count;
        //            mass3[i] = mass[i];
        //        }
        //    }
        //    return mass2;
        //}


        static Queue<Countries> myQueue = new Queue<Countries>();
        public static void NumberOfCountries(string n)
        {
            StreamReader sr = new StreamReader("infostran.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] lines = line.Split(' ');
                if (examination(lines[0], lines[1], n) == true)
                {

                    Countries countrie = new Countries();
                    countrie.countrie = lines[0];
                    countrie.population = int.Parse(lines[1]);
                    myQueue.Enqueue(countrie);
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
            }
            sr.Close();
            IEnumerable<Countries> countries = myQueue.OrderBy(x => x.countrie.Length).ThenBy(x => x.countrie).Where(x => x.population > int.Parse(n));
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.countrie} {item.population}");
            }

        }
        public static bool examination(string countrie, string population, string n)
        {
            for (int i = 0; i < countrie.Length; i++)
            {
                if (char.IsDigit(countrie[i]))
                {
                    return false;
                }
            }
            for (int i = 0; i < population.Length; i++)
            {
                if (char.IsLetter(population[i]))
                {
                    return false;
                }
            }
            try
            {
                int.Parse(n);
                return true;
            }
            catch
            {

                return false;
            }
            return true;
        }
        public static void Third(double[] mass)
        {
            Queue<doubleList> myQueue = new Queue<doubleList>();
            int[] mass2 = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                int count = (from x in mass where x == mass[i] select x).Count();
                mass2[i] = count;

            }
            int j = 0;
            double[] mass3 = new double[mass.Length];
            while (j != mass.Length)
            {
                if (!mass3.Contains(mass[j]))
                {
                    doubleList num = new doubleList();
                    num.Number = mass[j];
                    num.Ch = mass2[j];
                    myQueue.Enqueue(num);
                    mass3[j] = mass[j];
                }
                j++;
            }
            Console.WriteLine("-------------------");
            foreach (doubleList bam in myQueue)
            {
                Console.WriteLine($"{bam.Number} - {bam.Ch}");
            }
            Console.WriteLine("-------------------");
            foreach (doubleList bam in myQueue)
            {
                Console.WriteLine($"{bam.Number * bam.Ch} - {bam.Ch}");
            }
        }
    }
    public class doubleList
    {
        private double number;
        private int ch;

        public int Ch
        {
            get { return ch; }
            set { ch = value; }
        }


        public double Number
        {
            get { return number; }
            set { number = value; }
        }


    }
}


