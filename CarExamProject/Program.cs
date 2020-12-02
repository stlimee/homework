using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExamProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDAO carDAO = new SqlCarDAO();
            IList<Car> cars = carDAO.GetAllCars();

            Console.WriteLine(cars.Count());
        }
    }
}
