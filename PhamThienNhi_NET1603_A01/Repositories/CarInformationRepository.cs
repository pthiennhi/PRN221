using BusinessObjects.Models;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories
{
    public class CarInformationRepository : ICarInformationRepository
    {
        public bool AddNewCar(CarInformation car) => new CarInformationDAO().AddNewCar(car);

        public bool DeleteCar(int carId)
        {
            CarInformation car = GetCarById(carId);

            return new CarInformationDAO().DeleteCar(car);
        }

        public List<CarInformation> GetAllCars() => new CarInformationDAO().GetAllCars();

        public CarInformation GetCarById(int id) => new CarInformationDAO().GetCarById(id);
        public bool UpdateCar(CarInformation car) => new CarInformationDAO().UpdateCar(car);
        public List<CarInformation> SearchCars(string searchTerm, string searchType)
        {
            List<CarInformation> cars = new CarInformationDAO().GetAllCars();
            List<Manufacturer> manufacturers = new ManufacturerDAO().getAllManufacturer();
            List<Supplier> suppliers = new SupplierDAO().getSupplierList();
            IQueryable<CarInformation> query = cars.AsQueryable();
            IQueryable<Manufacturer> queryManufacturer = manufacturers.AsQueryable();
            IQueryable<Supplier> querySupplier = suppliers.AsQueryable();
            switch (searchType)
            {
                case "Id":
                    if (int.TryParse(searchTerm, out int CarId))
                    {
                        query = query.Where(c => c.CarId == CarId);
                    }
                    break;

                case "Name":
                    query = query.Where(c => c.CarName.Contains(searchTerm));
                    break;

                case "NumberOfDoors":
                    query = query.Where(c => c.NumberOfDoors.Equals(searchTerm));
                    break;

                case "SeatingCapacity":
                    query = query.Where(c => c.SeatingCapacity.Equals(searchTerm));
                    break;

                case "FuelType":
                    query = query.Where(c => c.FuelType.Contains(searchTerm));
                    break;

                case "Year":
                    query = query.Where(c => c.Year.Equals(searchTerm));
                    break;

                case "CarRentingPricePerDay":
                    if (searchTerm.All(char.IsDigit))
                    {

                        query = query.Where(c => c.CarRentingPricePerDay <= Decimal.Parse(searchTerm));
                    }
                    else
                    {
                        return new List<CarInformation>();
                    }
                    break;

                case "ManufacturerID":
                    queryManufacturer = queryManufacturer.Where(m => m.ManufacturerName.Contains(searchTerm));
                    query = query.Where(c => queryManufacturer.Any(cc => cc.ManufacturerId == c.ManufacturerId));
                    break;

                case "SupplierID":
                    querySupplier = querySupplier.Where(q => q.SupplierName.Contains(searchTerm));
                    query = query.Where(c => querySupplier.Any(cc => cc.SupplierId == c.SupplierId));
                    break;
                default:
                    return new List<CarInformation>();
            }

            List<CarInformation> searchResults = query.ToList();
            return searchResults;
        }
    }
}