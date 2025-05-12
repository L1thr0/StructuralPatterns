class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Coffe coffe1 = new TimWendelboeCoffe();
        coffe1 = new MilkCoffe(coffe1);
        Console.WriteLine("Название: {0}", coffe1.Name);
        Console.WriteLine("Цена: {0}", coffe1.GetCost());

        Coffe coffe2 = new TimWendelboeCoffe();
        coffe2 = new CreamCoffe(coffe2);
        Console.WriteLine("Название: {0}", coffe2.Name);
        Console.WriteLine("Цена: {0}", coffe2.GetCost());

        Coffe coffe3 = new KawaCoffe();
        coffe3 = new MilkCoffe(coffe3);
        Console.WriteLine("Название: {0}", coffe3.Name);
        Console.WriteLine("Цена: {0}", coffe3.GetCost());

        Coffe coffe4 = new KawaCoffe();
        coffe4 = new MilkCoffe(coffe4);
        coffe4 = new CreamCoffe(coffe4);
        Console.WriteLine("Название: {0}", coffe4.Name);
        Console.WriteLine("Цена: {0}", coffe4.GetCost());

        Coffe coffe5 = new MOKCoffee();
        coffe5 = new MilkCoffe(coffe5);
        coffe5 = new CinnamonCoffe(coffe5);
        Console.WriteLine("Название: {0}", coffe5.Name);
        Console.WriteLine("Цена: {0}", coffe5.GetCost());

        Console.ReadLine();
    }
}

abstract class Coffe
{
    public Coffe(string n)
    {
        this.Name = n;
    }
    public string Name { get; protected set; }
    public abstract float GetCost();
}

class TimWendelboeCoffe : Coffe
{
    public TimWendelboeCoffe() : base("Кофе из кофейни TimWendelboeCoffe")
    { }
    public override float GetCost()
    {
        return 4.99f;
    }
}
class KawaCoffe : Coffe
{
    public KawaCoffe() : base("Кофе из кофейни KawaCoffe")
    { }
    public override float GetCost()
    {
        return 6.99f;
    }
}

class MOKCoffee: Coffe
{
    public MOKCoffee() : base("Кофе из кофейни MOKCoffee")
    { }
    public override float GetCost()
    {
        return 5.99f;
    }
}

abstract class СoffeDecorator : Coffe
{
    protected Coffe coffe;
    public СoffeDecorator(string n, Coffe coffe) : base(n)
    {
        this.coffe = coffe;
    }
}

class MilkCoffe : СoffeDecorator
{
    public MilkCoffe(Coffe p)
        : base(p.Name + " с молоком", p)
    {}

    public override float GetCost()
    {
        return coffe.GetCost() + 2;
    }
}

class CreamCoffe : СoffeDecorator
{
    public CreamCoffe(Coffe p)
        : base(p.Name + " со сливками", p)
    {}

    public override float GetCost()
    {
        return coffe.GetCost() + 3;
    }
}

class CinnamonCoffe : СoffeDecorator
{
    public CinnamonCoffe(Coffe p)
        : base(p.Name + " с корицей", p)
    {}

    public override float GetCost()
    {
        return coffe.GetCost() + 3;
    }
}