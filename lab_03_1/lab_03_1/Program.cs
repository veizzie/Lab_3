class Parent
{
    protected double Pole1; // висота в м.

    public Parent(double pole1)
    {
        Pole1 = pole1;
    }

    public void Print()
    {
        Console.WriteLine("\nВисота в м: " + Pole1);
    }

    public void Method()
    {
        double foundationDepth = Math.Round(Pole1 * 0.03, 2);
        Console.WriteLine($"Глибина фундамента {foundationDepth} м");
    }
}

class Child1 : Parent
{
    private int Pole2; // кількість поверхів

    public Child1(double pole1, int pole2) : base(pole1)
    {
        Pole2 = pole2;
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine("Всього поверхів: " + Pole2);
    }

    public new void Method()
    {
        if (Pole2 > 10)
        {
            double foundationDepth = Pole1 * 0.03 + 0.005 * Pole2;
            string formattedFoundationDepth = string.Format("{0:0.00}", foundationDepth);
            Console.WriteLine($"Глибина фундамента офіса: {formattedFoundationDepth} м");
        }
    }
}

class Child2 : Parent
{
    private double Pole3; // вага в тоннах
    
    public Child2(double pole1, double pole3) : base(pole1)
    {
        Pole3 = pole3;
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine($"Вага {Pole3} тонн");
    }

    public new void Method()
    {
        double foundationDepth = Pole1 * 0.03 + 0.000002 * Pole3;
        Console.WriteLine($"Глибина фундамента завода: {foundationDepth} м");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Parent parent = new Parent(55);
        Child1 child1 = new Child1(34, 12);
        Child2 child2 = new Child2(75, 5000);

        parent.Print();
        parent.Method();

        child1.Print();
        child1.Method();

        child2.Print();
        child2.Method();

        Console.ReadKey();
    }
}