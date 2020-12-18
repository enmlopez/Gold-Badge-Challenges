using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenRepo
{
    public class KomodoCarRepo
    {
        List<Cars> carList = new List<Cars>();
        public void AddCartoList(Cars newCar)
        {
            carList.Add(newCar);
        }
        public List<Cars> SeeCarList()
        {
            return carList;
        }
        public bool UpdateCarOnList(int vin, Cars oldCar)
        {
            Cars updateCar = GetCarByVin(vin);
            if(oldCar != null)
            {
                updateCar.Vin = oldCar.Vin;
                updateCar.TypeOfCar = oldCar.TypeOfCar;
                updateCar.Brand = oldCar.Brand;
                updateCar.Model = oldCar.Model;
                updateCar.Range = oldCar.Range;
                updateCar.CarPrice = oldCar.CarPrice;
                updateCar.CostMaintenanceYearly = oldCar.CostMaintenanceYearly;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteCarFromList(int vin)
        {
            Cars removeCar = GetCarByVin(vin);
            carList.Remove(removeCar);
        }
        public Cars GetCarByVin(int vin)
        {
            foreach (Cars car in carList)
            {
                if(vin == car.Vin)
                {
                    return car;
                }
            }
            return null;
        }
    }
}

