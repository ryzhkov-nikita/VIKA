
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Security.Cryptography;
using Lab10;
using System.ComponentModel;

namespace Lab11
{
    public class TestCollections
    {
        public List<Human> HumanList;
        public List<string> StringList;

        public Dictionary<string, Student> StringStudentDict;
        public Dictionary<Human, Student> HumanStudentDict;

        public TestCollections()
        {
            HumanList = new List<Human>();

            StringList = new List<string>();

            StringStudentDict = new Dictionary<string, Student>();

            HumanStudentDict = new Dictionary<Human, Student>();

            for (int i = 0; i < 1000; i++)
            {
                Student student = new Student("", 0);
                student.RandomInit();

                HumanList.Add(student.BaseHuman);

                StringList.Add(student.ToString());

                student.StudentId = Guid.NewGuid().ToString();
                StringStudentDict.Add(student.StudentId, student);

                HumanStudentDict.Add(student.BaseHuman, student);
            }
        }

        public void AddToCollections(Student student)
        {
            HumanList.Add(student.BaseHuman);
            StringList.Add(student.ToString());
            student.StudentId = Guid.NewGuid().ToString();
            StringStudentDict.Add(student.StudentId, student);
            HumanStudentDict.Add(student.BaseHuman, student);
        }
        public void Add1000ToCollections()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Student student = new Student("", 0);
                student.RandomInit();

                HumanList.Add(student.BaseHuman);

                StringList.Add(student.ToString());

                student.StudentId = Guid.NewGuid().ToString();
                StringStudentDict.Add(student.StudentId, student);

                HumanStudentDict.Add(student.BaseHuman, student);
            }
        }
        public void RemoveFromCollections(int index)
        {
            HumanList.RemoveAt(index);
            StringList.RemoveAt(index);

            // Извлечь элемент для удаления 
            var student = StringStudentDict.Values.ElementAt(index);
            var student1 = StringStudentDict.Values.ElementAt(index);
            StringStudentDict.Remove(student.StudentId);
            HumanStudentDict.Remove(student1.BaseHuman);
        }

        public bool RunBenchmark(TestCollections test)
        {
            bool result = true;


            Test1(test);
            Test2(test);
            Test3(test);
            Test4(test); 
            Test5(test);
            Test6(test);
            Test7(test);
            Test8(test);
            Test9(test);
            Test10(test);
            Test11(test);
            Test12(test);
            Test13(test);
            Test14(test);
            Test15(test);
            Test16(test);
            return result;
        }

        public bool Test1(TestCollections test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.HumanList.Contains(test.HumanList[0]);
            sw.Stop();
            Console.WriteLine("Поиск первого элемента в HumanList занял {0} мс ", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test2(TestCollections test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.StringList.Contains(test.StringList[0]);
            sw.Stop();
            Console.WriteLine("Поиск первого элемента в StringList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test3(TestCollections test)
        {

            int midIndex = test.HumanList.Count / 2;

            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.HumanList.Contains(test.HumanList[midIndex]);
            sw.Stop();
            Console.WriteLine("Поиск центрального элемента в HumanList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test4(TestCollections test)
        {
            int midIndex = test.HumanList.Count / 2;
            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.StringList.Contains(test.StringList[midIndex]);
            sw.Stop();
            Console.WriteLine("Поиск центрального элемента в StringList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test5(TestCollections test)
        {
            int lastIndex = test.HumanList.Count - 1;
            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.HumanList.Contains(test.HumanList[lastIndex]);
            sw.Stop();
            Console.WriteLine("Поиск последнего элемента в HumanList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test6(TestCollections test)
        {
            int lastIndex = test.HumanList.Count - 1;
            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.StringList.Contains(test.StringList[lastIndex]);
            sw.Stop();
            Console.WriteLine("Поиск последнего элемента в StringList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test7(TestCollections test)
        {

            Human nonexistent = new Human("Не существующий");

            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.HumanList.Contains(nonexistent);
            sw.Stop();
            Console.WriteLine("Поиск несуществующего элемента в HumanList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test8(TestCollections test)
        {
            string nonexistentString = "Несуществующая строка";

            Stopwatch sw = Stopwatch.StartNew();
            bool contains = test.StringList.Contains(nonexistentString);
            sw.Stop();
            Console.WriteLine("Поиск несуществующего элемента в StringList занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test9(TestCollections test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool keyExists = test.StringStudentDict.ContainsKey(test.StringStudentDict.Keys.ElementAt(0));
            sw.Stop();
            Console.WriteLine("Поиск первого ключа в StringStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test10(TestCollections test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            bool keyExists = test.HumanStudentDict.ContainsKey(test.HumanStudentDict.Keys.ElementAt(0));
            sw.Stop();
            Console.WriteLine("Поиск первого ключа в HumanStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test11(TestCollections test)
        {

            
            int midKeyIndex = test.StringStudentDict.Count / 2;
            Stopwatch sw = Stopwatch.StartNew();

            
            bool keyExists = test.StringStudentDict.ContainsKey(test.StringStudentDict.Keys.ElementAt(midKeyIndex));
            sw.Stop();
            Console.WriteLine("Поиск центрального ключа в StringStudentDict занял {0} мс", sw.ElapsedMilliseconds);
           
            return true;
        }
        public bool Test12(TestCollections test)
        {
            int midKeyIndex = test.StringStudentDict.Count / 2;
            Stopwatch sw = Stopwatch.StartNew();
            bool keyExists = test.HumanStudentDict.ContainsKey(test.HumanStudentDict.Keys.ElementAt(midKeyIndex));
            sw.Stop();
            Console.WriteLine("Поиск центрального ключа в HumanStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test13(TestCollections test)
        {
            
            Stopwatch sw = Stopwatch.StartNew();
            int lastKeyIndex = test.StringStudentDict.Count - 1;

            
            bool keyExists = test.StringStudentDict.ContainsKey(test.StringStudentDict.Keys.ElementAt(lastKeyIndex));
            sw.Stop();
            Console.WriteLine("Поиск последнего ключа в StringStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test14(TestCollections test)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int lastKeyIndex = test.StringStudentDict.Count - 1;
            bool contains = test.HumanStudentDict.ContainsKey(test.HumanStudentDict.Keys.ElementAt(lastKeyIndex));
            sw.Stop();
            Console.WriteLine("Поиск последнего ключа в HumanStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test15(TestCollections test)
        {
            string nonExistentKey = "Несуществующий ключ";
            

            Stopwatch sw = Stopwatch.StartNew();
            bool keyExists = test.StringStudentDict.ContainsKey(nonExistentKey);
            sw.Stop();
            Console.WriteLine("Поиск несуществующего ключа в StringStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public bool Test16(TestCollections test)
        {
            Human nonExistentHuman = new Human("Несуществующий человек");

            Stopwatch sw = Stopwatch.StartNew();
            bool keyExists = test.HumanStudentDict.ContainsKey(nonExistentHuman);
            sw.Stop();
            Console.WriteLine("Поиск несуществующего ключа в HumanStudentDict занял {0} мс", sw.ElapsedMilliseconds);
            return true;
        }
        public int Elements ()
        {
            return HumanList.Count;
        }
    }


}
