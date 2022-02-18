using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task01
{
    [Serializable]
    public class Student
    {
        public string Surname
        {
            get;
            set;
        }
        public int CourseNumber
        {
            get;
            set;
        }
        public Student(string surname, int number)
        {
            Surname = surname;
            CourseNumber = number;
        }
        public Student() : this("Иванов", 1)
        {
            return;
        }
        public override string ToString()
        {
            return $"{this.Surname}, {this.CourseNumber};";
        }
    }
    [Serializable]
    public class Group
    {
        public string GroupName
        {
            get;
            set;
        }
        public List<Student> Students
        {
            get;
            set;
        }
        public Group(string group, List<Student> students)
        {
            GroupName = group;
            Students = students;
        }
        public Group() : this("БПИ219", new List<Student>() { new Student("Бесшапов", 1)})
        {
            return;
        }
        public override string ToString()
        {
            Array.ForEach(this.Students.ToArray(), el => Console.Write(el + " "));
            return $"{this.GroupName}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[] { new Group(), new Group("БПИ2111", new List<Student>() { new Student("Иванов", 1), new Student("Петров", 1) })};
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, groups);
            }
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                Group[] gotGroup = (Group[])formatter.Deserialize(file);
                Array.ForEach(gotGroup, el => Console.WriteLine(el));
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Group[]));
            using (FileStream file =
                new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, groups);
            }
            using (FileStream file =
                new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                Group[] gotGroup2 = (Group[])xmlSerializer.Deserialize(file);
                Array.ForEach(gotGroup2, el => Console.WriteLine(el));
            }
            string json = JsonSerializer.Serialize<Group[]>(groups);
            Group[] gotGroup3 = JsonSerializer.Deserialize<Group[]>(json);
            Array.ForEach(gotGroup3, el => Console.WriteLine(el));
        }
    }
}