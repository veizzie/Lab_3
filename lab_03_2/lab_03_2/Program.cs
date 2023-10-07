class Parent
{
    protected double Pole1; // сторона
    protected double Pole2; // кут в градусах
    protected double Pole3; // кут в радіанах

    public Parent()
    {
        Pole1 = 0;
        Pole2 = 0;
        Pole3 = 0;
    }

    public Parent(double side, double angleDegrees)
    {
        Pole1 = side;
        Pole2 = angleDegrees;
        Pole3 = angleDegrees * Math.PI/180;
    }

    public void Print()
    {
        Console.WriteLine($"Сторона={Pole1} кут={Pole2}");
    }

    public double Metod1()
    { return Math.Round(Pole1 * Pole1 * Math.Sin(Pole3), 2); }

    public double Metod2()
    { return Math.Round(4 * Pole1, 2); }
}

class Child : Parent
{
    public Child(double side) : base(side, 90)
    {
    }

    public double Metod3()
    { return Math.Round(Math.PI * Math.Pow(Pole1 / 2, 2), 2); }

    public double Metod4()
    { return Math.Round(Math.PI * Pole1, 2); }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            double side = random.Next(1, 11); // Випадкова сторона від 1 до 10
            double angle = random.Next(85, 91); // Випадковий кут від 85 до 90

            if (angle != 90)
            {
                // Це ромб
                Parent rhomb = new Parent(side, angle);
                rhomb.Print();
                Console.WriteLine($"Ромб: Площа={rhomb.Metod1()}, Периметр={rhomb.Metod2()}");
            }
            else
            {
                // Це квадрат
                Child square = new Child(side);
                square.Print();
                Console.WriteLine($"Квадрат: Площа={square.Metod1()}, Периметр={square.Metod2()}");
                Console.WriteLine($"Вписана окружність. Площа={square.Metod3()}, Довжина={square.Metod4()}");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}