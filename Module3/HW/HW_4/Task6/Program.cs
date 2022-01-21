using System;

namespace Task6
{
    public class RingIsFoundEventArgs : EventArgs
    {
        public RingIsFoundEventArgs(string s) { Message = s; }
        public String Message { get; set; }
    }
    public abstract class Creature
    {
        public string Name
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public abstract void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

    }
    public class Wizard : Creature
    {
        public delegate void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs a);
        public event RingIsFoundEventHandle RaiseRingIsFoundEvent;
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a)
        {
            return;
        }
        public Wizard(string s, string city) { Name = s; Location = city; }
        public Wizard() { }
        public void SomeThisIsChangedInTheAir()
        {
            Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
            Console.WriteLine($"Сейчас я, {Name}, в {Location}, а путь мне предстоит в Ривендейл.");
            Location = "Ривендейл";
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
            
        }
    }
    public class Hobbit : Creature
    {
        public Hobbit(string s, string city) { Name = s; Location = city; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Покидаю Шир! Иду в " + e.Message);
            Console.WriteLine($"Сейчас я, {Name}, в {Location}, а путь мне предстоит в {e.Message}.");
            Location = e.Message;
        }
    }
    public class Human : Creature
    {
        public Human(string s, string city) { Name = s; Location = city; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Волшебник {((Wizard)sender).Name} позвал. Моя цель {e.Message}");
            Console.WriteLine($"Сейчас я, {Name}, в {Location}, а путь мне предстоит в {e.Message}.");
            Location = e.Message;
        }
    }
    public class Elf : Creature
    {
        public Elf(string s, string city) { Name = s; Location = city; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в " + e.Message);
            Console.WriteLine($"Сейчас я, {Name}, в {Location}, а путь мне предстоит в {e.Message}.");
            Location = e.Message;
        }
    }
    public class Dwarf : Creature
    {
        public Dwarf(string s, string city) { Name = s; Location = city; }
        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Точим топоры, собираем припасы! Выдвигаемся в " + e.Message);
            Console.WriteLine($"Сейчас я, {Name}, в {Location}, а путь мне предстоит в {e.Message}.");
            Location = e.Message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Гендальф", "Земли Гендальфа Серого");
            Creature[] creatures = new Creature[] { new Hobbit("Бильбо", "Шир"), new Hobbit("Сэм", "Шир"),
            new Hobbit("Мэрри", "Шир"), new Hobbit("Пиппен", "Шир"), new Human("Арагорн", "Гарующий пони"),
            new Human("Боромир", "Минас тирит"), new Dwarf("Гимли", "Пустошь Смауга"), new Elf("Леголас", "Лихолесье")};
            for (int i = 0; i < creatures.Length; i++)
            {
                wizard.RaiseRingIsFoundEvent += creatures[i].RingIsFoundEventHandler;
            }
            wizard.SomeThisIsChangedInTheAir();
        }
    }
}