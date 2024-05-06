using Lab12;
using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Human> collection = null;

            while (true)
            {
                if (collection != null)
                {
                    Console.WriteLine("Элементы коллекции collection:");
                    foreach (var item in collection)
                    {
                        item.Show();
                    }

                }
                

                Console.WriteLine("Меню:");
                Console.WriteLine("1.1 - Создание пустой коллекции");
                Console.WriteLine("1.2 - Создание коллекции с заданной емкостью");
                Console.WriteLine("1.3 - Создание коллекции из другой коллекции");
                Console.WriteLine("2 - Добавление элемента");
                Console.WriteLine("3 - Добавление 5 случайных элементов");
                Console.WriteLine("4 - Удаление элемента(ов)");
                Console.WriteLine("5 - Удаление 5 случайных элементов");
                Console.WriteLine("6 - Поиск элемента по значению");
                Console.WriteLine("7 - Глубокое клонирование коллекции");
                Console.WriteLine("8 - Поверхностное копирование коллекции");
                Console.WriteLine("9 - Удаление коллекции из памяти");
                Console.WriteLine("0 - Выход");
                Console.Write("Выберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 11:
                            collection = new MyCollection<Human>();
                            Console.WriteLine("Пустая коллекция создана.");
                            break;
                        case 12:
                            Console.Write("Введите начальную емкость коллекции: ");
                            if (int.TryParse(Console.ReadLine(), out int capacity))
                            {
                                collection = new MyCollection<Human>(capacity);
                                Console.WriteLine("Пустая коллекция с заданной емкостью создана.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректное значение емкости.");
                            }
                            break;
                        case 13:
                            if (collection != null)
                            {
                                MyCollection<Human> clonedCollection = new MyCollection<Human>(collection);
                                Console.WriteLine("Коллекция создана как глубокая копия другой коллекции.");
                            }
                            else
                            {
                                Console.WriteLine("Коллекция не создана или удалена ранее.");
                            }
                            break;
                        case 2:
                            // Добавление элемента
                            AddElement(collection);
                            break;
                        case 3:
                            // Добавление 5 случайных элементов
                            AddRandomElements(collection, 5);
                            break;
                        case 4:
                            // Удаление элемента(ов)
                            RemoveElements(collection);
                            break;
                        case 5:
                            // Удаление 5 случайных элементов
                            RemoveRandomElements(collection, 5);
                            break;
                        case 6:
                            // Поиск элемента по значению
                            FindElement(collection);
                            break;
                        case 7:
                            if (collection != null)
                            {
                                MyCollection<Human> clonedCollection = collection.DeepClone();
                                Console.WriteLine("Коллекция успешно создана как глубокая копия.");
                            }
                            else
                            {
                                Console.WriteLine("Коллекция не создана или удалена ранее.");
                            }
                            break;
                        case 8:
                            if (collection != null)
                            {
                                MyCollection<Human> shallowCopy = collection.ShallowCopy();
                                Console.WriteLine("Коллекция успешно создана как поверхностная копия.");
                            }
                            else
                            {
                                Console.WriteLine("Коллекция не создана или удалена ранее.");
                            }
                            break;
                        case 9:
                            if (collection != null)
                            {
                                collection.Clear();
                                collection = null;
                                Console.WriteLine("Коллекция успешно удалена из памяти.");
                            }
                            else
                            {
                                Console.WriteLine("Коллекция не создана или уже удалена ранее.");
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

                Console.WriteLine();
            }
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
                        newElement = new Student("", 0);
                        break;
                    case 3:
                        newElement = new Teacher("", "", 0); 
                        break;
                    case 4:
                        newElement = new Worker("", "", 0); 
                        break;
                    default:
                        continue; // Пропуск некорректного типа
                }

                newElement.RandomInit(); // Инициализация свойств элемента случайными значениями
                collection.Add(newElement); // Добавление элемента в коллекцию
            }
            Console.WriteLine($"{count} случайных элементов успешно добавлены.");
        }

        static void RemoveElements(MyCollection<Human> collection)
        {
            Console.Write("Введите индекс элемента для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 0 && index < collection.Count)
                {
                    // Удаление элемента по индексу
                    collection.RemoveAt(index - 1);
                    Console.WriteLine("Элемент успешно удален.");
                }
                else
                {
                    Console.WriteLine("Индекс выходит за пределы коллекции.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод индекса.");
            }
        }

        static void RemoveRandomElements(MyCollection<Human> collection, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, collection.Count);
                collection.RemoveAt(index);
            }
            Console.WriteLine($"{count} случайных элементов успешно удалены.");
        }

        static void FindElement(MyCollection<Human> collection)
        {
            Console.Write("Введите имя для поиска: ");
            string name = Console.ReadLine();
            Human found = collection.Find(item => item.FullName == name);
            if (found != null)
            {
                Console.WriteLine("Найден элемент: " + found.FullName);
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }
        }
    }
}