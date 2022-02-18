using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task02
{
    [Serializable]
    public class Human
    {
        public string Name
        {
            get;
            set;
        }
        public string Grade
        {
            get;
            set;
        }
        public Human(string name)
        {
            Name = name;
            Grade = "Миничелик";
        }
        public Human() : this("Иван")
        {
            return;
        }
        public override string ToString()
        {
            return $"{this.Name}, {this.Grade};";
        }
    }
    [Serializable]
    public class Professor : Human
    {
        public Professor(string name, string grade) : base(name)
        {
            Name = name;
            Grade = grade;
        }
        public Professor() : base("Качалова")
        {

        }
    }
    [Serializable]
    [XmlInclude(typeof(Human))]
    public class Department
    {
        public string Name
        {
            get;
            set;
        }
        public List<Human> Humans
        {
            get;
            set;
        }
        public Department(string name, params Human[] humans)
        {
            Humans = new List<Human>();
            Name = name;
            foreach (var item in humans)
            {
                Humans.Add(new Professor(item.Name, item.Grade));
            }
        }
        public Department() : this("Учебный офис", new Human[] { new Professor("МиниКачалова", "МиниБухгалтер") })
        {
            return;
        }
        public override string ToString()
        {
            Array.ForEach(this.Humans.ToArray(), el => Console.Write(el + " "));
            return $"{this.Name}";
        }
    }
    [Serializable]
    [XmlInclude(typeof(Professor))]
    public class University
    {
        public string Name
        {
            get;
            set;
        }
        public Department[] Workers
        {
            get;
            set;
        }
        public University(string name, Department[] departments)
        {
            Name = name;
            Workers = departments;
        }
        public University() : this("ВШЭ", new Department[] { new Department("Учебный офис", new Human[] { new Professor("СуперКачалова", "СуперБухгалтер") }) })
        {
            return;
        }
        public override string ToString()
        {
            Array.ForEach(this.Workers, el => Console.WriteLine(el));
            return $"{this.Name}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Department[] departments = new Department[] { new Department(), new Department("Учебный офис", new Human[] { new Professor("Ломоносов", "Профессор") }) };
            University[] universities = new University[] { new University(), new University("МГУ", departments)};
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, universities);
            }
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                University[] gotGroup = (University[])formatter.Deserialize(file);
                Array.ForEach(gotGroup, el => Console.WriteLine(el));
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(University[]));
            using (FileStream file =
                new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, universities);
            }
            using (FileStream file =
                new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                University[] gotGroup2 = (University[])xmlSerializer.Deserialize(file);
                Array.ForEach(gotGroup2, el => Console.WriteLine(el));
            }
            string json = JsonSerializer.Serialize<University[]>(universities);
            University[] gotGroup3 = JsonSerializer.Deserialize<University[]>(json);
            Array.ForEach(gotGroup3, el => Console.WriteLine(el));
        }
    }
}
