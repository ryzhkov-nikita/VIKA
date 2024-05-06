
// Демонстрационная программа
using Lab11;
using Lab10;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

class Program
{

    static void Main()
    {
        

        TestCollections testCollections = null;

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Создать экземпляр TestCollections и заполнить коллекции");
            Console.WriteLine("2 - Добавить объект в коллекции");
            Console.WriteLine("3 - Удалить объект из коллекции по индексу");
            Console.WriteLine("4 - Выполнить тестирование производительности");
            Console.WriteLine("5 - Вывести все элементы коллекции");
            Console.WriteLine("6 - Добавить 1000000 экземпляров");
            Console.WriteLine("7 - Выход");
            switch (GetUserIntInput("Ваш выбор:", 1, 7))
            {
                case 1:
                    testCollections = new TestCollections();
                    Console.WriteLine("Коллекции созданы и заполнены");
                    break;
         
                case 2:
                    if (testCollections != null)
                    {
                        Console.Write("Введите объект для добавления: ");
                        Student student = new Student("", 0);
                        student.Init();
                        testCollections.AddToCollections(student);
                    }
                    else
                    {
                        Console.WriteLine("Сначала создайте экземпляр TestCollections!");
                    }
                    break;

                case 3:
                    if (testCollections != null)
                    {
                        Console.Write("Введите индекс объекта для удаления: ");
                        int a = testCollections.Elements();
                        int index = GetUserIntInput("Введите индекс объекта для удаления: ", 0, a);
                        testCollections.RemoveFromCollections(index);
                    }
                    else
                    {
                        Console.WriteLine("Сначала создайте экземпляр TestCollections!");
                    }
                    break;

                case 4:
                    if (testCollections != null)
                    {
                        bool flag = testCollections.RunBenchmark(testCollections);
                    }
                    else
                    {
                        Console.WriteLine("Сначала создайте экземпляр TestCollections!");
                    }
                    break;
                case 5:
                    if (testCollections != null)
                    {
                        int a = GetUserIntInput("Введите тип : ", 1, 4);
                        if (a == 1)
                        {
                            Console.WriteLine("Список HumanList:");
                            foreach (Human h in testCollections.HumanList)
                            {
                                Console.WriteLine(h.FullName);
                            }
                        }
                        else if (a == 2)
                        {
                            Console.WriteLine("\nЭлементы StringList:");
                            foreach (string s in testCollections.StringList)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        else if (a == 3)
                        {
                            Console.WriteLine("\nЭлементы StringStudentDict:");
                            foreach (KeyValuePair<string, Student> item in testCollections.StringStudentDict)
                            {
                                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
                            }
                        }
                        else if (a == 4)
                        {
                            Console.WriteLine("\nЭлементы HumanStudentDict:");
                            foreach (KeyValuePair<Human, Student> item in testCollections.HumanStudentDict)
                            {
                                Console.WriteLine("Ключ: {0}, Значение: {1}", item.Key, item.Value);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Сначала создайте экземпляр TestCollections!");
                    }
                    break;
                case 6:
                    if (testCollections != null)
                    {
                        testCollections.Add1000ToCollections();
                    }
                    else
                    {
                        Console.WriteLine("Сначала создайте экземпляр TestCollections!");
                    }
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
    static int GetUserIntInput(string message, int a, int b)
    {
        int input = 0;
        bool isCorrect = false;
        while (!isCorrect)
        {
            Console.WriteLine(message);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (input >= a && input <= b)
                {
                    isCorrect = true;
                }
                else Console.WriteLine("Число не входит в рамки дозволенного");
            }
            else
            {
                Console.WriteLine("Ошибка ввода! Введите целое число.");
            }
        }
        return input;
    }
}