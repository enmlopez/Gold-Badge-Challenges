using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenRepo
{
    public enum TypeOfCar
    {
        Electric = 1,
        Hybrid,
        Gas,
    }
    public class Cars
    {
        public int Vin { get; set; }
        public TypeOfCar TypeOfCar { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public double CarPrice { get; set; }
        public double CostMaintenanceYearly { get; set; }
        public Cars() { }
        public Cars(int vin, TypeOfCar typeOfCar,string model, string brand, int range, double carPrice, double costMaintenanceYearly)
        {
            Vin = vin;
            Model = model;
            TypeOfCar = typeOfCar;
            Brand = brand;
            Range = range;
            CarPrice = carPrice;
            CostMaintenanceYearly = costMaintenanceYearly;
        }
    }
    //public class ElectricCar
    //{
    //    public int Range { get; set; }
    //    public string Fuel { get; set; }
    //    public double CarPrice { get; set; }
    //    public ElectricCar() { }
    //    public ElectricCar(int range, string fuel, double carPrice)
    //    {
    //        Range = range;
    //        Fuel = fuel;
    //        CarPrice = carPrice;
    //    }
    //}
    //public class HybridCar
    //{
    //    public string Fuel { get; set; }
    //    public string EngineSize { get; set; }
    //    public int Range { get; set; }
    //    public double CarPrice { get; set; }
    //    public HybridCar() { }
    //    public HybridCar(string fuel, string engineSize, int range, double carPrice)
    //    {
    //        Fuel = fuel;
    //        EngineSize = engineSize;
    //        Range = range;
    //        CarPrice = carPrice;

    //    }
    //}
    //public class GasCar
    //{
    //    public string Fuel { get; set; }
    //    public string O2Emissions { get; set; }
    //    public double CostMaintenanceYearly { get; set; }
    //    public double CarPrice { get; set; }
    //    public GasCar() { }
    //    public GasCar(string fuel, string o2Emissions, double costMaintenanceYearly, double carPrice)
    //    {
    //        Fuel = fuel;
    //        O2Emissions = o2Emissions;
    //        CostMaintenanceYearly = costMaintenanceYearly;
    //        CarPrice = carPrice;

    //    }
    //}
}
