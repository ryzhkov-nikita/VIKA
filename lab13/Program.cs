using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            
                MyNewCollection<Human> collection1 = new MyNewCollection<Human>("Collection1");
                MyNewCollection<Human> collection2 = new MyNewCollection<Human>("Collection2");

                Journal journal1 = new ();
                Journal journal2 = new ();

                collection1.CollectionCountChanged += journal1.AddEntry;
                collection1.CollectionReferenceChanged += journal1.AddEntry;

                collection2.CollectionReferenceChanged += journal1.AddEntry;
                collection2.CollectionReferenceChanged += journal2.AddEntry;
                while (true)
                {

                Console.WriteLine("Меню:");
                Console.WriteLine("1.1 - Добавить элемент в коллекцию 1");
                Console.WriteLine("1.2 - Добавить элемент в коллекцию 2");
                Console.WriteLine("2 - Добавление 5 случайных элементов - 1");
                Console.WriteLine("3 - Добавление 5 случайных элементов - 2");
                Console.WriteLine("4 - Удаление элемента");
                Console.WriteLine("5 - Удаление элемента");
                Console.WriteLine("6 - Вывести журнал");
                Console.WriteLine("7 - Изменить в коллекции 2");
                Console.WriteLine("8 - Изменить в коллекции 1");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 11:
                            AddElement(collection1);
                            break;
                        case 12:
                            AddElement(collection2);
                            break;
                        case 2:
                            AddRandomElements(collection1, 5);
                            break;
                        case 3:
                            // Добавление 5 случайных элементов
                            AddRandomElements(collection2, 5);
                            break;
                        case 4:
                            if (int.TryParse(Console.ReadLine(), out int index))
                            {
                                collection1.Remove(index);
                            }
                            break;
                        case 5:
                            if (int.TryParse(Console.ReadLine(), out int index1))
                            {
                                collection2.Remove(index1);
                            }
                           
                            break;
                        case 6:
                            // Поиск элемента по значению
                            Console.WriteLine("Journal 1:");
                            Console.WriteLine(journal1.ToString());

                            Console.WriteLine("\nJournal 2:");
                            Console.WriteLine(journal2.ToString());
                            break;
                        case 7:
                            if (int.TryParse(Console.ReadLine(), out int index2))
                            {
                                Console.WriteLine("Выберите тип элемента для добавления:");
                                Console.WriteLine("1 - Human");
                                Console.WriteLine("2 - Student");
                                Console.WriteLine("3 - Teacher");
                                Console.WriteLine("4 - Worker");

                                if (int.TryParse(Console.ReadLine(), out int choice1))
                                {
                                    Human newElement;
                                    switch (choice1)
                                    {
                                        case 1:
                                            newElement = new Human();
                                            break;
                                        case 2:
                                            newElement = new Student("", 0); // Инициализируйте имя и курс
                                            break;
                                        case 3:
                                            newElement = new Teacher("", "", 0); // Инициализируйте имя и предмет
                                            break;
                                        case 4:
                                            newElement = new Worker("", "", 0); // Инициализируйте имя и должность
                                            break;
                                        default:
                                            Console.WriteLine("Некорректный выбор.");
                                            return;
                                    }

                                    newElement.Init(); // Инициализация свойств элемента
                                    collection2[index2] = newElement;
                                }

                            }

                            break;
                        case 8:
                            if (int.TryParse(Console.ReadLine(), out int index3))
                            {
                                Console.WriteLine("Выберите тип элемента для добавления:");
                                Console.WriteLine("1 - Human");
                                Console.WriteLine("2 - Student");
                                Console.WriteLine("3 - Teacher");
                                Console.WriteLine("4 - Worker");

                                if (int.TryParse(Console.ReadLine(), out int choice1))
                                {
                                    Human newElement;
                                    switch (choice1)
                                    {
                                        case 1:
                                            newElement = new Human();
                                            break;
                                        case 2:
                                            newElement = new Student("", 0); // Инициализируйте имя и курс
                                            break;
                                        case 3:
                                            newElement = new Teacher("", "", 0); // Инициализируйте имя и предмет
                                            break;
                                        case 4:
                                            newElement = new Worker("", "", 0); // Инициализируйте имя и должность
                                            break;
                                        default:
                                            Console.WriteLine("Некорректный выбор.");
                                            return;
                                    }

                                    newElement.Init(); // Инициализация свойств элемента
                                    collection1[index3] = newElement;
                                }

                            }
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Некорректный пункт меню.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите число.");
                }
            }
            Console.WriteLine();
        }

        static void AddElement(MyCollection<Human> collection)
        {
            Console.WriteLine("Выберите тип элемента для добавления:");
            Console.WriteLine("1 - Human");
            Console.WriteLine("2 - Student");
            Console.WriteLine("3 - Teacher");
            Console.WriteLine("4 - Worker");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Human newElement;
                switch (choice)
                {
                    case 1:
                        newElement = new Human();
                        break;
                    case 2:
                        newElement = new Student("", 0); // Инициализируйте имя и курс
                        break;
                    case 3:
                        newElement = new Teacher("", "", 0); // Инициализируйте имя и предмет
                        break;
                    case 4:
                        newElement = new Worker("", "", 0); // Инициализируйте имя и должность
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        return;
                }

                newElement.Init(); // Инициализация свойств элемента
                collection.Add(newElement); // Добавление элемента в коллекцию
                Console.WriteLine("Элемент успешно добавлен в коллекцию.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        static void AddRandomElements(MyCollection<Human> collection, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int type = random.Next(1, 5); // Генерация случайного типа элемента
                Human newElement;
                switch (type)
                {
                    case 1:
                        newElement = new Human();
                        break;
                    case 2:
                        newElement = new Student("", 0); // Инициализируйте имя и курс
                        break;
                    case 3:
                        newElement = new Teacher("", "", 0); // Инициализируйте имя и предмет
                        break;
                    case 4:
                        newElement = new Worker("", "", 0); // Инициализируйте имя и должность
                        break;
                    default:
                        continue; // Пропуск некорректного типа
                }

                newElement.RandomInit(); // Инициализация свойств элемента случайными значениями
                collection.Add(newElement); // Добавление элемента в коллекцию
            }
            Console.WriteLine($"{count} случайных элементов успешно добавлены.");
        }


    }
}
            // Присваивание нового значения элементу коллекции

        
   
