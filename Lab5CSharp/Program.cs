using System;
using System.Collections.Generic;

namespace Lab5CSharp {
    // Task 1.4
    public abstract class Product : IComparable<Product> {
        public string Name;
        public Product() { Name = "Загальний виріб"; }
        public Product(string n) { Name = n; }
        public Product(string n, int y) { Name = n; }
        
        ~Product() { Console.WriteLine($"[Завдання 2.4] Об'єкт {Name} видалено"); }

        public abstract void Show();
        public int CompareTo(Product? o) => Name.CompareTo(o?.Name); 
    }

    public class Part : Product { 
        public Part(string n) : base(n) { }
        public override void Show() => Console.WriteLine($"Деталь: {Name}");
    }

    public class Mechanism : Product { 
        public Mechanism(string n) : base(n) { }
        public override void Show() => Console.WriteLine($"Механізм: {Name}");
    }

    public class AssemblyUnit : Product { 
        public AssemblyUnit(string n) : base(n) { }
        public override void Show() => Console.WriteLine($"Вузол: {Name}");
    }
    // Task 1.4 end

    // Task 3.9
    public abstract class Client {
        public string Name;
        public DateTime StartDate;
        public Client(string n, DateTime d) { Name = n; StartDate = d; }
        public abstract void Show();
    }

    public class Depositor : Client { 
        public Depositor(string n, DateTime d) : base(n, d) { }
        public override void Show() => Console.WriteLine($"Вкладник: {Name}, Дата: {StartDate:d}");
    }

    public class Creditor : Client { 
        public Creditor(string n, DateTime d) : base(n, d) { }
        public override void Show() => Console.WriteLine($"Кредитор: {Name}, Дата: {StartDate:d}");
    }

    public class Organization : Client { 
        public Organization(string n, DateTime d) : base(n, d) { }
        public override void Show() => Console.WriteLine($"Організація: {Name}, Дата: {StartDate:d}");
    }
    // Task 3.9 end

    class Program {
        static void Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Task 1.4
            Product[] products = { 
                new Mechanism("Редуктор"), 
                new Part("Болт"), 
                new AssemblyUnit("Двигун") 
            };
            Array.Sort(products); 
            foreach (var p in products) p.Show();
            // Task 1.4 end

            // Task 3.9
            DateTime searchDate = new DateTime(2023, 10, 10);
            Client[] clients = { 
                new Depositor("Іванов", searchDate), 
                new Creditor("Петров", DateTime.Now),
                new Organization("ТОВ 'А1'", searchDate)
            };
            Console.WriteLine($"Пошук за датою {searchDate:d}:");
            foreach (var c in clients) if (c.StartDate.Date == searchDate.Date) c.Show();
            // Task 3.9 end

            // Task 4
            new ATriangle(3, 4).Print();
            // Task 4 end

            Console.WriteLine("\nПрограму завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
