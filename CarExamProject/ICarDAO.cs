using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExamProject
{
    public interface ICarDAO 
    {
        IList<Car> GetAllCars();
        void InsertCar(Car car);
        void DeleteCar(int id);
        void UpdateCar(Car car, int id);
        double GetCarAvgPrice();
        Car GetCar(int id);
    }
}
