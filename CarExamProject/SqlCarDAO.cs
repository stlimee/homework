using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CarExamProject
{
    public class SqlCarDAO : SqlAbstractDAO, ICarDAO
    {
        private const string SELECT_ALL_CARS = "SELECT * FROM Car";
        private const string SELECT_CAR = "SELECT * FROM Car WHERE car_id = @id";
        private const string INSERT_CAR = "INSERT INTO Car(mark, engine, fuelConsumption, color, price, mileage) " +
            "VALUES(@mark, @engine, @fuelCounsumption, @color, @price, @mileage)";
        private const string UPDATE_CAR = "UPDATE Car SET mark = @mark, engine = @engine, fuelConsumption = @fuelConsumption, " +
            "color = @color, price = @price, mileage = @mileage WHERE car_id = @id";
        private const string DELETE_CAR = "DELETE FROM Car WHERE car_id = @id";
        private const string SELECT_AVG_PRICE = "SELECT convert(real, avg(price), 5) FROM Car";
        public void DeleteCar(int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(DELETE_CAR, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.Direction = ParameterDirection.Input;

            sqlCommand.Parameters.Add(idParam);

            sqlCommand.ExecuteNonQuery();

            ReleaseConnection(connection);
        }

        public IList<Car> GetAllCars()
        {
            IList<Car> cars = new List<Car>();
            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(SELECT_ALL_CARS, connection);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Car car = new Car();

                    if (!reader.IsDBNull(1))
                    {
                        car.Mark = Convert.ToString(reader["mark"]);
                    }
                    
                    car.Engine = Convert.ToDouble(reader["engine"]);
                    car.FuelConsumption = Convert.ToDouble(reader["fuelConsumption"]);
                    car.Color = Convert.ToString(reader["color"]);
                    
                    if (!reader.IsDBNull(5))
                    {
                        car.Price = Convert.ToDouble(reader["price"]);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        car.Mileage = Convert.ToInt32(reader["mileage"]);
                    }

                    cars.Add(car);
                }
            }

            ReleaseConnection(connection);

            return cars;
        }

        public Car GetCar(int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(SELECT_CAR, connection);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.Direction = ParameterDirection.Input;

            sqlCommand.Parameters.Add(idParam);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            Car car = new Car();

            if (reader.HasRows)
            {
                reader.Read();
                car.Mark = Convert.ToString(reader["mark"]);
                car.Engine = Convert.ToDouble(reader["engine"]);
                car.FuelConsumption = Convert.ToDouble(reader["fuelConsumption"]);
                car.Color = Convert.ToString(reader["color"]);
                car.Price = Convert.ToDouble(reader["price"]);
                car.Mileage = Convert.ToInt32(reader["mileage"]);
            }

            ReleaseConnection(connection);

            return car;
        }

        public double GetCarAvgPrice()
        {
            SqlConnection connection = (SqlConnection)GetConnection();

            SqlCommand sqlCommand = new SqlCommand(SELECT_AVG_PRICE, connection);

            double avgPrice = (double)sqlCommand.ExecuteScalar();

            ReleaseConnection(connection);

            return avgPrice;
        }

        public void InsertCar(Car car)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(INSERT_CAR, connection);

            SqlParameter markParam = new SqlParameter();
            markParam.Value = car.Mark;
            markParam.ParameterName = "@mark";
            markParam.SqlDbType = SqlDbType.NVarChar;
            markParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(markParam);

            SqlParameter engineParam = new SqlParameter();
            engineParam.Value = car.Engine;
            engineParam.ParameterName = "@engine";
            engineParam.SqlDbType = SqlDbType.Float;
            engineParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(engineParam);

            SqlParameter fuelConsumptionParam = new SqlParameter();
            fuelConsumptionParam.Value = car.FuelConsumption;
            fuelConsumptionParam.ParameterName = "@fuelConsumption";
            fuelConsumptionParam.SqlDbType = SqlDbType.Float;
            fuelConsumptionParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(fuelConsumptionParam);

            SqlParameter colorParam = new SqlParameter();
            colorParam.Value = car.Color;
            colorParam.ParameterName = "@color";
            colorParam.SqlDbType = SqlDbType.NVarChar;
            colorParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(colorParam);

            SqlParameter priceParam = new SqlParameter();
            priceParam.Value = car.Price;
            priceParam.ParameterName = "@price";
            priceParam.SqlDbType = SqlDbType.Float;
            priceParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(priceParam);

            SqlParameter mileageParam = new SqlParameter();
            mileageParam.Value = car.Mileage;
            mileageParam.ParameterName = "@mileage";
            mileageParam.SqlDbType = SqlDbType.Int;
            mileageParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(mileageParam);

            cmd.ExecuteNonQuery();

            ReleaseConnection(connection);
        }

        public void UpdateCar(Car car, int id)
        {
            SqlConnection connection = (SqlConnection)GetConnection();
            SqlCommand cmd = new SqlCommand(UPDATE_CAR, connection);

            SqlParameter markParam = new SqlParameter();
            markParam.Value = car.Mark;
            markParam.ParameterName = "@mark";
            markParam.SqlDbType = SqlDbType.NVarChar;
            markParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(markParam);

            SqlParameter engineParam = new SqlParameter();
            engineParam.Value = car.Engine;
            engineParam.ParameterName = "@engine";
            engineParam.SqlDbType = SqlDbType.Float;
            engineParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(engineParam);

            SqlParameter fuelConsumptionParam = new SqlParameter();
            fuelConsumptionParam.Value = car.FuelConsumption;
            fuelConsumptionParam.ParameterName = "@fuelConsumption";
            fuelConsumptionParam.SqlDbType = SqlDbType.Float;
            fuelConsumptionParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(fuelConsumptionParam);

            SqlParameter colorParam = new SqlParameter();
            colorParam.Value = car.Color;
            colorParam.ParameterName = "@color";
            colorParam.SqlDbType = SqlDbType.NVarChar;
            colorParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(colorParam);

            SqlParameter priceParam = new SqlParameter();
            priceParam.Value = car.Price;
            priceParam.ParameterName = "@price";
            priceParam.SqlDbType = SqlDbType.Float;
            priceParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(priceParam);

            SqlParameter mileageParam = new SqlParameter();
            mileageParam.Value = car.Mileage;
            mileageParam.ParameterName = "@mileage";
            mileageParam.SqlDbType = SqlDbType.Int;
            mileageParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(mileageParam);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.Direction = ParameterDirection.Input;

            cmd.Parameters.Add(idParam);

            cmd.ExecuteNonQuery();

            ReleaseConnection(connection);

        }
    }
}
