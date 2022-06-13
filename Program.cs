using System;
using System.Linq;
using System.IO;

namespace prak16
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Введите слово, которое хотите найти(с маленькой буквы)");
            //string slovo = Console.ReadLine().ToLower();
            //if (Class1.ExamFirst(slovo)==false)
            //{
            //    Console.WriteLine(Class1.First(slovo));
            //}
            //else
            //{
            //    Console.WriteLine("Ошибка");
            //}


            //Задание 2
            //Console.WriteLine("Введите текст");
            //string[] StringMass = Console.ReadLine().Split(' ', '.', ',');
            //Console.WriteLine(Class1.Second(StringMass));
            //Console.WriteLine(Class1.Second2(StringMass));
            //Console.WriteLine(Class1.Second3(StringMass));


            //Задание 3
            double[] mass = {5.1 , 1, 3, 9.2, 2, 3, 5.1, 3};
            Class1.Third(mass);
            //for (int i = 0; i < mass2.Length; i++)
            //{
            //    Console.WriteLine($"{mass[i]} - {mass2[i]}");
            //}


            //Задание 4
            //string n = Console.ReadLine();
            //Class1.NumberOfCountries(n);




        }
    }
}
