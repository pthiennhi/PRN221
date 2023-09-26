using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICarInformationRepository
    {
        public List<CarInformation> GetAllCars();
        public CarInformation GetCarById(int id);
        public bool AddNewCar(CarInformation car);
        public bool UpdateCar(CarInformation car);
        public bool DeleteCar(int carId);
        public List<CarInformation> SearchCars(string searchTerm, string searchType);

    }
}
