using System;

public abstract class Jewelry
{
    public string Model { get; set; }
    public double Weight { get; set; }
    public double Complexity { get; set; }

    public abstract double GetPrice();
}

public class GoldJewelry : Jewelry
{
    public override double GetPrice()
    {
        return Weight * 50 + Complexity * 100;
    }
}

public class SilverJewelry : Jewelry
{
    public override double GetPrice()
    {
        return Weight * 30 + Complexity * 100;
    }
}

public interface IJewelryFactory
{
    Jewelry CreateJewelry(string model, double weight, double complexity);
}

public class GoldJewelryFactory : IJewelryFactory
{
    public Jewelry CreateJewelry(string model, double weight, double complexity)
    {
        return new GoldJewelry { Model = model, Weight = weight, Complexity = complexity };
    }
}

public class SilverJewelryFactory : IJewelryFactory
{
    public Jewelry CreateJewelry(string model, double weight, double complexity)
    {
        return new SilverJewelry { Model = model, Weight = weight, Complexity = complexity };
    }
}

class Program
{
    static void Main(string[] args)
    {
        IJewelryFactory jewelryFactory = null;

        Console.WriteLine("Введiть тип прикраси (золото, срiбло):");
        string type = Console.ReadLine().ToLower();

        switch (type)
        {
            case "золото":
                jewelryFactory = new GoldJewelryFactory();
                break;
            case "срiбло":
                jewelryFactory = new SilverJewelryFactory();
                break;
            default:
                Console.WriteLine("Невiдомий тип прикраси");
                return;
        }

        Console.WriteLine("Введiть модель прикраси:");
        string model = Console.ReadLine();

        Console.WriteLine("Введiть вагу прикраси:");
        double weight = double.Parse(Console.ReadLine());

        Console.WriteLine("Введiть складнiсть роботи:");
        double complexity = double.Parse(Console.ReadLine());

        Jewelry jewelry = jewelryFactory.CreateJewelry(model, weight, complexity);

        Console.WriteLine($"Модель: {jewelry.Model}, Вартiсть: {jewelry.GetPrice()}");
    }
}
