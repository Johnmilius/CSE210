public class Vehicle
{
    private int _yearManufactured;
    private string _manufacturer;
    private string _modelName;

    public Vehicle(int yearManufactured, string manufacturer, string modelName)
    {
        _yearManufactured = yearManufactured;
        _manufacturer = manufacturer;
        _modelName = modelName;
    }

    public int GetYearManufactured()
    {
        return _yearManufactured;
    }

    public string GetManufacturer()
    {
        return _manufacturer;
    }

    public string GetModelName()
    {
        return _modelName;
    }

}

public class Car : Vehicle
{
    private int _numberOfDoors;
    public Car(int yearManufactured, string manufacturer, string modelName, int numberOfDoors)
    : base(yearManufactured, manufacturer, modelName)
    {
        _numberOfDoors = _numberOfDoors;
    }
}

public class Ford : Car
{
    public Ford(int yearManufactured, string modelName, int numberOfDoors)
    : base(yearManufactured, "Ford", modelName, numberOfDoors)
    {
        
    }
}


public class Program2
{
    public static void Main(string[] args)
    {
        Car car1 = new Car(2006, "Hyundai", "Sonata", 4);
    }
}