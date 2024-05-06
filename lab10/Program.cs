
// Демонстрационная программа
using Lab10;


class Program
{

    static void Main()
    {
        List<Human> people = new List<Human>();
        while (true)
        {
            
            ShowArray(people);
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Создать студента");           
            Console.WriteLine("2 - Создать преподавателя");
            Console.WriteLine("3 - Создать работника");
            Console.WriteLine("4 - Заполнить массив 5-ю случайными объектами");
            Console.WriteLine("5 - Отсортировать массив по имени");
            Console.WriteLine("6 - Сравнить 2 элемента массива");
            Console.WriteLine("7 - Имена студентов указанного курса");
            Console.WriteLine("8 - Имена и должность преподавателей");
            Console.WriteLine("9 - Количество студентов на указанном курсе");
            Console.WriteLine("10 - Имена рабочих заданной профессии");
            Console.WriteLine("11 - Отсортировать массив по должности");
            Console.WriteLine("12 - Поиск элемента");
            Console.WriteLine("13 - Бинарный поиск");
            Console.WriteLine("14 - Перейти к массиву с разными классами");
            Console.WriteLine("15 - Клонирование объекта");
            Console.WriteLine("16 - Поверхностное копирование");
            Console.WriteLine("17 - Создать человека");
            Console.WriteLine("0 - Выход");
            
            switch (GetUserIntInput("Сделайте выбор: ", 0, 17))
            {
                case 1:
                    CreateStudent(people);
                    break;

                case 2:
                    CreateTeacher(people);
                    break;

                case 3:
                    CreateWorker(people);
                    break;

                case 4:
                    RandomInit(people);
                    break;

                case 5:
                    SortArr(people);
                    break;

                case 6:
                    FaceToFace(people);
                    
                    break;
                case 7:
                    Query1(people);
                    break;

                case 8:
                    Query2(people);
                    break;

                case 9:
                    Query3(people);
                    break;

                case 10:
                    Query4(people);
                    break;

                case 11:
                    SortPos(people);
                    
                    break;
                case 12:
                    SearchElement(people);
                    break;
                case 13:
                    BinSearch(people);
                    break;
                case 14:
                    ShuffleArray();
                    break;
                case 15:
                    int index = GetUserIntInput("Введите индекс элемента для клонирования: ", 0, people.Count);
                    CloneHumanInList(people, index-1);
                    break;
                case 16:
                    int index1 = GetUserIntInput("Введите индекс элемента для копирования: ", 0, people.Count);
                    Human p1 = people[index1-1].ShallowCopy();
                    people.Add(p1);
                    break;
                case 17:
                    Human h = new();
                    h.Init();
                    people.Add(h);
                    break;
                case 0:
                    return;
            }
        }
    }

    static void CreateStudent(List<Human> people)
    {
        Student s = new Student("", 0);
        s.Init();
        people.Add(s);
    }

    static void CreateTeacher(List<Human> people)
    {
        Teacher t = new Teacher("", "", 0);
        t.Init();
        people.Add(t);
    }
    static void CreateWorker(List<Human> people)
    {
        Worker w = new Worker("", "", 0);
        w.Init();
        people.Add(w);
    }
    static void RandomInit(List<Human> people)
    {
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            if (rnd.Next(0, 3) == 0)
            {
                Student s = new Student("", 0);
                s.RandomInit();
                people.Add(s);
                
            }
            else
            {
                if (rnd.Next(0, 3) == 1)
                {
                    Teacher t = new Teacher("", "", 0);
                    t.RandomInit();
                    people.Add(t);
                }
                else 
                {
                    Worker w = new Worker("", "", 0);
                    w.RandomInit();
                    people.Add(w);
                }
            }
            

        }
    }

    static void ShowArray(List<Human> people)
    {
        foreach (Human h in people)
        {
            h.Show();
        }
    }
    static void CompareElements(List<Human> people, int index1, int index2)
    {
        if (index1 >= 0 && index1 < people.Count &&
           index2 >= 0 && index2 < people.Count)
        {
            if (people[index1].Equals(people[index2]))
                Console.WriteLine("Элементы равны");
            else
                Console.WriteLine("Элементы отличаются");
        }
        else
        {
            Console.WriteLine("Неверный индекс элемента!");
        }
    }
    static void Query1(List<Human> people)
    {

        int course = GetUserIntInput("Введите курс: ", 0, 16);

        // Имена студентов указанного курса
        var students = people.OfType<Student>()
                             .Where(s => s.Course == course)
                             .Select(s => s.FullName);

        Console.WriteLine($"Студенты {course} курса:");
        foreach (var s in students)
            Console.WriteLine(s);
    }
    static void Query2(List<Human> people)
    {// Имена и должности преподавателей
        var teachers = people.OfType<Teacher>()
                              .Select(t => t.FullName + ", " + t.Position);

        Console.WriteLine("Преподаватели:");
        foreach (var t in teachers)
            Console.WriteLine(t);

    }
    static void Query3(List<Human> people)
    {// Количество студентов на курсе
        int course = GetUserIntInput("Введите курс: ", 0, 16);
        int count = people.OfType<Student>()
                           .Count(s => s.Course == course);

        Console.WriteLine($"Количество студентов: {count}");

    }

    static void Query4(List<Human> people)
    {// Имена рабочих заданной профессии
        Console.Write("Введите профессию: ");
        string prof = Console.ReadLine();

        var workers = people.OfType<Worker>()
                             .Where(w => w.Position.Contains(prof))
                             .Select(w => w.FullName);

        Console.WriteLine($"Работники профессии {prof}:");
        foreach (var w in workers)
            Console.WriteLine(w);
    } 
    static void BinSearch (List<Human> people)
    {
        Human[] peopleArray3 = people.ToArray();
        Array.Sort(peopleArray3, new PersonComparer());
        string Human = Console.ReadLine();
        Human searchHuman = new Human { FullName = Human };
        int pos = BinarySearch(peopleArray3, searchHuman, new PersonComparer());
        if (pos >= 0)
        {
            Console.WriteLine("Элемент найден в позиции " + (pos + 1));
        }
        else
        {
            Console.WriteLine("Элемент не найден");
        }
        people.Clear();

        foreach (Human person in peopleArray3)
        {
            people.Add(person);
        }
    }
    static int BinarySearch(Human[] array, Human value, PersonComparer comparer)
    {
        int min = 0;
        int max = array.Length - 1;

        while (min <= max)
        {
            int mid = (min + max) / 2;

            int cmp = comparer.Compare(value, array[mid]);

            if (cmp == 0) return mid;

            if (cmp < 0)
                max = mid - 1;
            else
                min = mid + 1;
        }

        return -1;
    }

    static void ShuffleArray()
    {
        int choice = GetUserIntInput("Введите размер массива: ", 1, 1000);
        IInit[] initArray = new IInit[choice];

        for (int i = 0; i < choice; i++)
        {
            bool flag = false;
            while (!flag)
            {
            Console.WriteLine("Выбор класса:");
            Console.WriteLine("1 - Human");
            Console.WriteLine("2 - Dogs");
            int choiceClass = GetUserIntInput("Сделайте выбор: ", 1, 2);
            Console.WriteLine("Как заполнить:");
            Console.WriteLine("1 - Вручную");
            Console.WriteLine("2 - Случайно");
            int choiceType = GetUserIntInput("Сделайте выбор: ", 1, 2);
            if (choiceClass == 1)
            {
                Console.WriteLine("Выбор класса:");
                Console.WriteLine("1 - Студент");
                Console.WriteLine("2 - Преподаватель");
                Console.WriteLine("3 - Работник университета");

                int choiceClass2 = GetUserIntInput("Сделайте выбор: ", 1, 3);
                    

                if (choiceClass2 == 1)
                {   
                    Student s = new Student("", 0);

                    if (choiceType == 1)
                    {
                        s.Init();
                        
                    }
                    else if (choiceType == 2)
                    {
                        s.RandomInit();

                    }
                    initArray[i] = s;
                        flag = true;
                }
                if (choiceClass2 == 2)
                {
                    Teacher t = new Teacher("", "", 0);

                    if (choiceType == 1)
                    {
                        t.Init();

                    }
                    else if (choiceType == 2)
                    {
                        t.RandomInit();

                    }
                    initArray[i] = t;
                        flag = true;
                    }
                if (choiceClass2 == 3)
                {
                    Worker w = new Worker("", "", 0);

                    if (choiceType == 1)
                    {
                        w.Init();

                    }
                    else if (choiceType == 2)
                    {
                        w.RandomInit();

                    }
                    initArray[i] = w;
                        flag = true;
                    }
            }
            
            if (choiceClass == 2)
            {
                Dogs d = new Dogs();

                if (choiceType == 1)
                {
                    d.Init();

                }
                else if (choiceType == 2)
                {
                    d.RandomInit();

                }
                initArray[i] = d;
                    flag = true;
                }

            }
            
            
        }

        foreach (var item in initArray)
        {
            if (item is Human human)
            {
                human.Show();
            }
            else if (item is Dogs dog)
            {
                dog.Show();
            }

            Console.WriteLine();
        }
    }
    public static Human DeepCloneHuman(Human original)
    {
        if (original is Student student)
        {
            return new Student(student.FullName, student.Course);
        }
        else if (original is Teacher teacher)
        {
            return new Teacher(teacher.FullName, teacher.Position, teacher.Experience);
        }
        else if (original is Worker worker)
        {
            return new Worker(worker.FullName, worker.Position, worker.Experience);
        }
        else
        {
            return new Human(original.FullName);
        }
    }
    public static void CloneHumanInList(List<Human> humans, int index)
    {
        humans.Add(DeepCloneHuman(humans[index]));
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
    static void SortArr (List<Human> people)
    {
        Human[] peopleArray = people.ToArray();
        Array.Sort(peopleArray);
        people.Clear();

        foreach (Human person in peopleArray)
        {
            people.Add(person);
        }
    }
    static void FaceToFace(List<Human> people)
    {
        int index1;
        int index2;

        index1 = GetUserIntInput("Введите индекс первого элемента: ", 0, people.Count);


        index2 = GetUserIntInput("Введите индекс второго элемента: ", 0, people.Count);

        CompareElements(people, index1, index2);

    }
    static void SortPos(List<Human> people)
    {
        Human[] peopleArray1 = people.ToArray();
        Array.Sort(peopleArray1, new PositionExperienceComparer());
        people.Clear();

        foreach (Human person in peopleArray1)
        {
            people.Add(person);
        }
    }
    static void SearchElement(List<Human> people)
    {
        Human[] peopleArray2 = people.ToArray();
        Array.Sort(peopleArray2, new PersonComparer()); // сортируем
        string Name = Console.ReadLine();
        Human toFind = new Human { FullName = Name };

        int index = Array.BinarySearch(peopleArray2, toFind, new PersonComparer());

        if (index >= 0)
        {
            Console.WriteLine("Элемент найден в позиции " + (index + 1));
        }
        else
        {
            Console.WriteLine("Элемент не найден");
        }
        people.Clear();

        foreach (Human person in peopleArray2)
        {
            people.Add(person);
        }
    }

}