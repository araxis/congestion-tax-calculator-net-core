using System;

namespace congestion.calculator;

public class City
{
    private City()
    {
        
    }
    public City(string name)
    {
        Name = name;
    }

    public int Id { get;private set; }
    public string Name { get; set; }
}