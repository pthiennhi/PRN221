using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CarInformationDAO
    {
        private readonly FucarRentingManagementContext _context;

        public CarInformationDAO()
        {
            _context = new FucarRentingManagementContext();
        }

        public List<CarInformation> GetAllCars()
        {
            List<CarInformation> activeCar = _context.CarInformations
                 .Where(car => car.CarStatus == 1)
                 .ToList();
            return activeCar;
        }

        public bool AddNewCar(CarInformation car)
        {
            bool result = false;
            _context.CarInformations.Add(car);
            _context.SaveChanges();
            result = true;

            return result;
        }

        public bool DeleteCar(CarInformation car)
        {
            bool result = false;
            CarInformation tmp = _context.CarInformations.SingleOrDefault(c => c.CarId == car.CarId);
            if (tmp != null)
            {
                tmp.CarStatus = 0;
                _context.Entry(tmp).Property(e => e.CarStatus).IsModified = true;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool UpdateCar(CarInformation car)
        {
            bool result = false;

            try
            {
                _context.CarInformations.Update(car);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public CarInformation GetCarById(int id)
        {
            CarInformation car = _context.CarInformations.SingleOrDefault(c => c.CarId == id);

            return car;
        }

    }
}
