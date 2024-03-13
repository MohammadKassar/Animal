using System.Xml.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Animal> Animals = new List<Animal>();
        Animals.Add(new Horse("Speedy", 200, 10, "EU"));
        Animals.Add(new Dog("ShamShoom", 25, 3, "Golden Retrievers"));
        Animals.Add(new Dog("Rex", 30, 4, "Labrdor"));
        foreach (var animal in Animals) 
        {
            Console.WriteLine(animal.Stats());
            animal.DoSound();
            if (animal is IParsable)
            {
                ((IParsable)animal).Talk();
            }
        }
        List<Dog> dogs = new List<Dog>();
        foreach (var animal in Animals) 
        {
            Console.WriteLine(animal.Stats());
        }
    }
}
interface IParsable
{
    void Talk();
}
public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public int Age { get; set; }
    public Animal(string name, double weight, int age)
    {
        Name = name;
        Weight = weight;
        Age = age;
    }
    public abstract void DoSound();
    public virtual string Stats()
    {
        return $"Name :{Name},Weight :{Weight},Age :{Age}";
    }
}
class Horse : Animal
{
    public string Origin { get; set; }
    public Horse(string name, double weight, int age, string origin) : base (name, weight, age)
    {
        Origin = origin;
    }
    public override void DoSound()
    {
        Console.WriteLine("Neygh Neygh");
    }
    public override string Stats()
    {
        return base.Stats() + $" ORIGIN : {Origin}";
    }
}

class Dog : Animal
{
    public string Breed { get; set; }
    public Dog(string name, double weight, int age, string breed) : base(name, weight, age)
    {
        Breed = breed;
    }
    public override void DoSound()
    {
        Console.WriteLine("Huff Huff");
    }
    public override string Stats()
    {
        return base.Stats() + $" BREED : {Breed}";
    }
    public string Bark()
    {
        return "woooof woooof";
    }
}
class Hedgehog : Animal
{
    public int NrOfSpikes { get; set; }
    public Hedgehog(string name, double weight, int age, int nrOfSpikes) : base(name, weight, age)
    {
        NrOfSpikes = nrOfSpikes;
    }
    public override void DoSound()
    {
        Console.WriteLine("Hiss");
    }
}
class Worm : Animal
{
    public bool Ispoisonous { get; set; }
    public Worm(string name, double weight, int age, bool ispoisonous) : base(name, weight, age)
    {
        Ispoisonous = ispoisonous;
    }
    public override void DoSound()
    {
        Console.WriteLine("Siiiiiiiii");
    }
}
class Bird : Animal
{
    public string WingSpan { get; set; }
    public Bird(string name, double weight, int age, string wingSpan) : base(name, weight, age)
    {
        WingSpan = wingSpan;
    }
    public override void DoSound()
    {
        Console.WriteLine("zi zi");
    }
}
class Wolf : Animal
{
    public bool IsAlpha { get; set; }
    public Wolf(string name, double weight, int age, bool isAlpha) : base(name, weight, age)
    {
        IsAlpha = isAlpha;
    }

    public Wolf(string name, double weight, int age) : base(name, weight, age)
    {
    }

    public override void DoSound()
    {
        Console.WriteLine("Hoooo");
    }
}
class Pelican : Bird
{
    public string MColor { get; set; }
    public Pelican(string name, double weight, int age, string wingSpan, string mColor) : base(name, weight, age, wingSpan)
    {
        MColor = mColor;
    }
    
}
class Flamingo : Bird
{
    public int LegLength { get; set; }
    public Flamingo(string name, double weight, int age, string wingSpan, int legLength) : base(name, weight, age, wingSpan)
    {
        LegLength = legLength;
    }
    
}
class Swan : Bird
{
    public int NeckLength { get; set; }
    public Swan(string name, double weight, int age, string wingSpan, int neckLength) : base(name, weight, age, wingSpan)
    {
        NeckLength = neckLength;
    }
  
}
interface IPerson
{
    void Talk();
}
class Wolfman :  Wolf, IPerson
{
    public Wolfman (string name, double weight, int age, bool isAlpha) : base(name, weight, age) 
    {
    }
    public void Talk()
    {
        Console.WriteLine("I am a person in the day and wolf in the night");
    }
}

//3.3 13  Om vi under utvecklingen kommer fram till att samtliga fåglar behöver ett nytt
// attribut, i vilken klass bör vi lägga det? Class Bird

//3.3 14  Om alla djur behöver det nya attributet, vart skulle man lägga det då? class Animal
//3.4  9 Försök att lägga till en häst i listan av hundar. Varför fungerar inte det? kan bara inh[lla objekt av typ Dog/ Horse inte är en underklass till Dog
//3.4 10 Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?  List<Animal>
//3.4  13 Förklara vad det är som händer.kommer varje djur i lista Animals gå i foreach loop o skriva ut information om all djur via Stats()
//3.4 17  Kommer du åt den metoden från Animals listan? Animals listan känner bara klass medlemmer inte subklasser på den lista jag kan bara med Stats()   
//3.