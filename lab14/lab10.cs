
using System;
using System.Xml.Linq;

namespace Lab12
{
    // Библиотека классов
    public interface IInit
    {
        void Init();
        void RandomInit();
    }
    public interface ICloneable
    {
        Human ShallowCopy();
        Object Clone();
    }
    public class Human : IInit, IComparable<Human>, ICloneable
    {
        public string FullName { get; set; }

        public Human()
        {
            FullName = "Noname";
        }

        public Human(string fullName)
        {
            FullName = fullName;
        }
        public override string ToString()
        {
            return $"FullName: {FullName}";
        }
        public virtual void Init()
        {
            Console.Write("Введите ФИО: ");
            FullName = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            string[] names = { "Иванов", "Петров", "Сидоров" };
            string[] firstNames = { "Иван", "Петр", "Алексей" };
            string[] patronymics = { "Иванович", "Петрович", "Сидорович" };
            FullName = $"{names[new Random().Next(0, 3)]} {firstNames[new Random().Next(0, 3)]} {patronymics[new Random().Next(0, 3)]}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Human human)
                return FullName == human.FullName;
            return false;
        }

        public virtual void Show()
        {
            Console.WriteLine(FullName);
        }
        public void NonVirtualInit()
        {
            Console.Write("Введите ФИО: ");
            FullName = Console.ReadLine();
        }

        public void NonVirtualRandomInit()
        {
            string[] names = { "Иванов", "Петров", "Сидоров" };
            string[] firstNames = { "Иван", "Петр", "Алексей" };
            string[] patronymics = { "Иванович", "Петрович", "Сидорович" };
            FullName = $"{names[new Random().Next(0, 3)]} {firstNames[new Random().Next(0, 3)]} {patronymics[new Random().Next(0, 3)]}";
        }

        public void NonVirtualShow()
        {
            Console.WriteLine(FullName);
        }
        public int CompareTo(Human other)
        {
            return String.Compare(FullName, other.FullName);
        }
        public Human ShallowCopy()
        {
            return (Human)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Human(this.FullName);
        }
        public int GetUserIntInput(string message, int a, int b)
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

    public class Student : Human, IInit, ICloneable
    {
        public int Course { get; set; }
        public Student(string fullName, int course)
        {
            FullName = fullName;
            Course = course;

        }
        public override string ToString()
        {
            return $"FullName: {FullName}, Course: {Course}";
        }
        public override void Init()
        {
            base.Init();

            Course = GetUserIntInput("Введите курс: ", 1, 5);
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Course = new Random().Next(1, 5);
        }

        public override void Show()
        {
            Console.WriteLine(FullName + ", Студент " + Course + " курса");
        }
        public new void NonVirtualInit()
        {
            base.Init();

            Course = GetUserIntInput("Введите курс: ", 1, 5);
        }

        public new void NonVirtualRandomInit()
        {
            base.RandomInit();
            Course = new Random().Next(1, 5);
        }

        public new void NonVirtualShow()
        {
            Console.WriteLine(FullName + ", Студент " + Course + " курса");
        }
        public new Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }
        public new object Clone()
        {
            return new Student(this.FullName, this.Course);
        }

    }

    public class Teacher : Human, IInit, ICloneable
    {
        public string Position { get; set; }
        public int Experience { get; set; }
        public Teacher(string fullName, string position, int experience)
        {
            FullName = fullName;
            Position = position;
            Experience = experience;
        }
        public override string ToString()
        {
            return $"FullName: {FullName}, Position: {Position}, Experience: {Experience}";
        }
        public override void Init()
        {
            base.Init();

            Console.Write("Введите должность: ");
            Position = Console.ReadLine();
            Experience = GetUserIntInput("Введите опыт: ", 1, 35);
        }

        public override void RandomInit()
        {
            base.RandomInit();

            string[] positions = { "Ассистент", "Старший преподаватель", "Доцент", "Профессор" };
            Position = positions[new Random().Next(0, 4)];
            Experience = new Random().Next(1, 10);
        }

        public override void Show()
        {
            Console.WriteLine(FullName + ", Преподаватель, должность - " + Position + ", опыт работы - " + Experience + "лет");
        }
        public new void NonVirtualInit()
        {
            base.Init();

            Console.Write("Введите должность: ");
            Position = Console.ReadLine();
            Experience = GetUserIntInput("Введите опыт: ", 1, 35);
        }

        public new void NonVirtualRandomInit()
        {
            base.RandomInit();

            string[] positions = { "Ассистент", "Старший преподаватель", "Доцент", "Профессор" };
            Position = positions[new Random().Next(0, 4)];
            Experience = new Random().Next(1, 10);
        }

        public new void NonVirtualShow()
        {
            Console.WriteLine(FullName + ", Преподаватель, должность - " + Position + ", опыт работы - " + Experience + "лет");
        }
        public Teacher ShallowCopy()
        {
            return (Teacher)this.MemberwiseClone();
        }
        public new object Clone()
        {
            return new Teacher(this.FullName, this.Position, this.Experience);
        }
    }

    public class Worker : Human, IInit, ICloneable
    {
        public string Position { get; set; }
        public int Experience { get; set; }
        public Worker(string fullName, string position, int experience)
        {
            FullName = fullName;
            Position = position;
            Experience = experience;
        }
        public override string ToString()
        {
            return $"FullName: {FullName}, Position: {Position}, Experience: {Experience}";
        }
        public override void Init()
        {
            base.Init();

            Console.Write("Введите должность: ");
            Position = Console.ReadLine();
            Experience = GetUserIntInput("Введите опыт: ", 1, 35); ;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            string[] positions = { "Повар", "Гардеробщик", "Бухгалтер" };
            Position = positions[new Random().Next(0, 3)];
            Experience = new Random().Next(1, 10);
        }

        public override void Show()
        {
            Console.WriteLine(FullName + ", Работник университета, должность - " + Position + ", опыт работы - " + Experience + "лет");
        }
        public new void NonVirtualInit()
        {
            base.Init();

            Console.Write("Введите должность: ");
            Position = Console.ReadLine();
            Experience = GetUserIntInput("Введите опыт: ", 1, 35);
        }

        public new void NonVirtualRandomInit()
        {
            base.RandomInit();

            string[] positions = { "Рабочий", "Менеджер", "Бухгалтер" };
            Position = positions[new Random().Next(0, 3)];
            Experience = new Random().Next(1, 10);
        }

        public new void NonVirtualShow()
        {
            Console.WriteLine(FullName + ", Работник университета, должность - " + Position + ", опыт работы - " + Experience + "лет");
        }
        public Worker ShallowCopy()
        {
            return (Worker)this.MemberwiseClone();
        }
        public new object Clone()
        {
            return new Worker(this.FullName, this.Position, this.Experience);
        }
    }
    public class PositionExperienceComparer : IComparer<object>
    {

        public int Compare(object x, object y)
        {
            // Сначала по позиции
            if (x is Student)
                return 1; // студенты в конец

            if (y is Student)
                return -1; // студенты в конец
            // Сравнение по позиции
            if (x is Worker wx && y is Worker wy) 
            {
                int result = string.Compare(wx.Position, wy.Position);
                if (result != 0) return result;
            }

            if (x is Teacher tx && y is Teacher ty)
            {
                int result = string.Compare(tx.Position, ty.Position);
                if (result != 0) return result;
            }
            if (x is Worker wtx && y is Teacher twy)
            {
                return string.Compare(wtx.Position, twy.Position);
            }

            if (x is Teacher twx && y is Worker wty)
            {
                return string.Compare(twx.Position, wty.Position);
            }
 
            return 0;
        }

    }
    public class PersonComparer : IComparer<Human>
    {
        public int Compare(Human x, Human y)
        {
            return string.Compare(x.FullName, y.FullName);
        }
    }

    public class Dogs : IInit
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public Dogs()
        {
            Name = "Noname";
            Type = "Noname";
            Age = 0;
        }

        public virtual void Init()
        {
            Console.Write("Введите кличку собаки: ");
            Name = Console.ReadLine();
            Console.Write("Введите породу: ");
            Type = Console.ReadLine();
            Age = GetUserIntInput("Введите возраст: ", 1, 35);
        }

        public virtual void RandomInit()
        {
            string[] names = { "Чарли", "Бейли", "Купер", "Макс", "Белла", "Луна", "Люси", "Джиджи", "Рози" };
            Name = $"{names[new Random().Next(0, 8)]}";
            string[] types = { "Немецкий шпиц", "Чихуахуа", "Вельш-корги", "Немецкая овчарка", "Йоркширский терьер", "Лабрадор-ретривер", "Джек-рассел терьер", "Французский бульдог", "Пудель" };
            Type = $"{types[new Random().Next(0, 8)]}";
            Age = new Random().Next(1, 10);
        }
        public int GetUserIntInput(string message, int a, int b)
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
        public virtual void Show()
        {
            Console.WriteLine(Name + " - " + Type + ", " + Age + " лет");
        }
    }
    
}
