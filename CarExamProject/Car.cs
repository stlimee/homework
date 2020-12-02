using System;
using System.Collections.Generic;
using System.Text;
public enum Color
{
    Red,
    Green,
    Blue,
    Yellow,
    Brown,
    White,
    Orange,
    Pink,
    Black
}

namespace CarExamProject
{
    public class Car
    {
        public string Mark { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public double Price { get; set; }
        public double FuelConsumption { get; set; }
        public int Mileage { get; set; }

        public Car() { }

        public Car(string mark, string color, double engine, double price, double fuelConsumption, int mileage)
        {
            Mark = mark;
            Color = color;
            Engine = engine;
            Price = price;
            FuelConsumption = fuelConsumption;
            Mileage = mileage;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Mark))
            {
                return base.ToString();
            }

            return "Mark: " + Mark +
                "\nColor: " + Color +
                "\nEngine: " + Engine +
                "\nPrice: " + Price +
                "\nFuel consumption: " + FuelConsumption +
                "\nMileage: " + Mileage;
        }
    }
}
