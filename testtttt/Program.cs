class Program
{
    static void Main(string[] args)
    {
        Car myCar = new Car();

        myCar.Make = "Oldsmobile";
        myCar.Model = "Cutlass Supreme";
        myCar.year = 1990;
        myCar.color = "Silver";

        Car myOthercar = new Car();
        myOthercar =  myCar;

        Console.WriteLine("{0} {1} {2} {3}",
            myOthercar.year, myOthercar.color,
            myOthercar.Model, myOthercar.Make); 

        Console.WriteLine(myCar.ToString);

        Console.WriteLine(myCar);
        Console.ReadLine();
    }
}

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int year { get; set; }
    public string color { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3}",
            Make, Model, year, color);
    }   

    public Car(string make, string model, int year, string color)
    {
        Make = make;
        Model = model;
        this.year = year;
        this.color = color;
    }   

}





/*
class Program
{
    static void Main(string[] args)
    {
      Car myCar = new Car();
        myCar.Make = "Olsmobile";
        myCar.Model = "ghj";
        myCar.year = 133;
        myCar.color = "Sliver";

        Console.WriteLine("{0} {1} {2} {3}",
            myCar.Make,
            myCar.Make, myCar.year, myCar.color);


       decimal value = DeterminValue(myCar);

        Console.WriteLine("cAR PRIVE = {0}", myCar.DeterminValue());
      
        Console.ReadLine();
    }

    private static decimal DeterminValue(Car car)
    {
        decimal carValue = 100;

        return carValue;

    }
}

class Car
{
    public string Make {  get; set; }
    public string Model { get; set; } 
    public int year { get; set; }
    public string color { get; set; }

    public decimal DeterminValue()
    {

        decimal carValue;

        if (year > 1990)
        {
            carValue = 100;
        }
        else
            carValue = 200;

        return carValue;
    }   
}
*/