class Parent
{
    protected int pole1; //всього місць
    protected internal int pole2; // зайнято
    protected int pole3; // вільно

    public Parent(int totalSeats)
    {
        pole1 = totalSeats;
        pole2 = 0;
        pole3 = totalSeats;
    }

    public void Print()
    {
        Console.WriteLine($"Всього місць={pole1}, зайнято={pole2}, вільно={pole3}");
    }

    public bool Metod1()
    {
        if (pole3 > 0)
        {
            pole2++;
            pole3--;
            return true;
        }
        else
        { return false;}
    }

    public bool Metod2()
    {
        if (pole2 > 0)
        {
            pole2--;
            pole3++;
            return true;
        }
        else
        { return false;}
    }
}

class Child : Parent
{
    private int pole4; // кількість зупинок судна

    public Child(int totalSeats, int stops) : base(totalSeats)
    {
        pole4 = stops;
    }

    public int Pole4
    {
        get { return pole4; }
        set { pole4 = value; }
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine($"Кількість зупинок судна: {pole4}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Random random = new Random();

        // Створення готелю
        Parent hotel = new Parent(5);
        Console.WriteLine("---Готель---");
        hotel.Print();

        int guestNumber = 1; // нумерації гостей

        // Поселення людей в готель
        int guests = random.Next(1, 7); // Випадкова кількість гостей (1-6)
        for (int i = 0; i < guests; i++)
        {
            bool settled = hotel.Metod1();
            if (settled)
            {
                Console.WriteLine($"Гість {guestNumber} оселено в готелі.");
                guestNumber++;
            }
            else
            {
                Console.WriteLine("Немає вільних місць в готелі.");
                break; // Виходимо, якщо немає вільних місць
            }
        }

        Console.WriteLine("Стан готелю після поселення:");
        hotel.Print();

        // Виселення людей з готелю
        int departures = random.Next(1, guests + 1); // Випадкова кількість виїжджаючих
        for (int i = 0; i < departures; i++)
        {
            bool departed = hotel.Metod2();
            if (departed)
            {
                Console.WriteLine($"Гість {guestNumber - 1} виселено з готелю.");
                guestNumber--;
            }
            else
            {
                Console.WriteLine("Готель порожній.");
                break; // Виходимо, якщо готель порожній
            }
        }

        Console.WriteLine("Стан готелю після виселення:");
        hotel.Print();

        // Створення круїзу
        Child cruise = new Child(7, 2);
        Console.WriteLine("\n---Круїз---");
        cruise.Print();

        // Поселення людей в круїз
        guestNumber = 1; // Скидаємо нумерацію для круїзу
        guests = random.Next(1, 8); // Випадкова кількість гостей (1-7)
        for (int i = 0; i < guests; i++)
        {
            bool settled = cruise.Metod1();
            if (settled)
            {
                Console.WriteLine($"Пасажир {guestNumber} поселено в круїз.");
                guestNumber++;
            }
            else
            {
                Console.WriteLine("Немає вільних місць в круїзі.");
                break; // Виходимо, якщо немає вільних місць
            }
        }

        Console.WriteLine("Стан круїзу після поселення:");
        cruise.Print();

        // Зупинки круїзного судна
        int stops = cruise.Pole4;
        for (int i = 0; i < stops; i++)
        {
            int passengersToDepart = random.Next(1, cruise.pole2 + 1);
            for (int j = 0; j < passengersToDepart; j++)
            {
                bool departed = cruise.Metod2();
                if (departed)
                {
                    Console.WriteLine($"Пасажир {guestNumber - 1} виселено на зупинці.");
                    guestNumber--;
                }
                else
                {
                    Console.WriteLine("Круїз порожній на даній зупинці.");
                    break; // Виходимо, якщо порожній
                }
            }

            cruise.Pole4--; // Оновлення кількості зупинок
            if (cruise.Pole4 > 0)
            {
                Console.WriteLine($"Залишилося {cruise.Pole4} зупинок.");
            }
        }

        Console.WriteLine("Стан круїзу після всіх зупинок:");
        cruise.Print();

        Console.ReadKey();
    }
}