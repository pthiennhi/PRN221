using Repositories.Interface;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using BusinessObjects.Models;
using System.Diagnostics;

namespace PhamThienNhiWPF
{
    /// <summary>
    /// Interaction logic for CarDetailWindow.xaml
    /// </summary>
    public partial class CarDetailWindow : Window
    {
        public bool AddOrUpdate { get; set; }
        public int ID { get; set; }
        private DispatcherTimer messageTimer;
        private ICarInformationRepository carInformationRepository = new CarInformationRepository();
        private IManufacturerRepository manufacturerRepository = new ManufacturerRepository();
        private ISupplierRepository supplierRepository = new SupplierRepository();

        private List<Manufacturer> manufacturerList;
        private List<Supplier> supplierList;
        public CarDetailWindow()
        {
            InitializeComponent();
            messageTimer = new DispatcherTimer();
            messageTimer.Tick += MessageTimer_Tick;
            messageTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            message.Text = string.Empty;
            message.Height = 0;
            messageTimer.Stop();
            this.Close();
        }
        private List<dynamic> ToDynamicListManufacturer(List<Manufacturer> l)
        {
            List<dynamic> list = new List<dynamic>();

            foreach (var item in l)
            {
                list.Add(item.ManufacturerName);
            }
            return list;
        }
        private List<dynamic> ToDynamicListSupplier(List<Supplier> l)
        {
            List<dynamic> list = new List<dynamic>();

            foreach (var item in l)
            {
                list.Add(item.SupplierName);
            }
            return list;
        }
        private void SetDataSourceComboBoxManufacturer(List<dynamic> li)
        {
            cbManufacturer.ItemsSource = null;
            if (li.Count > 0)
            {
                cbManufacturer.ItemsSource = li;
                cbManufacturer.SelectedIndex = 0;
            }
        }
        private void SetDataSourceComboBoxSupplier(List<dynamic> li)
        {
            cbSupplier.ItemsSource = null;
            if (li.Count > 0)
            {
                cbSupplier.ItemsSource = li;
                cbSupplier.SelectedIndex = 0;
            }
        }

        private void CarDetailWindow_Loaded(object sender, RoutedEventArgs e)
        {
            manufacturerList = manufacturerRepository.GetAllManufacturer();
            SetDataSourceComboBoxManufacturer(ToDynamicListManufacturer(manufacturerList));
            supplierList = supplierRepository.GetSupplierList();
            SetDataSourceComboBoxSupplier(ToDynamicListSupplier(supplierList));
            if (AddOrUpdate)
            {
                btnUpdate.Visibility = Visibility.Hidden;
            }
            else
            {
                btnCreate.Visibility = Visibility.Hidden;
                CarInformation car = carInformationRepository.GetCarById(ID);
                if (car != null)
                {
                    textBoxName.Text = car.CarName;
                    textBoxDescription.Text = car.CarDescription;
                    textBoxNumberOfDoors.Text = car.NumberOfDoors.ToString();
                    textBoxSeatingCapacity.Text = car.SeatingCapacity.ToString();
                    textBoxFuelType.Text = car.FuelType;
                    int yearToSet = car.Year.Value;
                    DateTime selectedDate = new DateTime(yearToSet, 1, 1);
                    dpYear.SelectedDate = selectedDate;

                    string manufacturerName = manufacturerList.FirstOrDefault(manufacturer => manufacturer.ManufacturerId == car.ManufacturerId)?.ManufacturerName;

                    if (!string.IsNullOrEmpty(manufacturerName))
                    {

                        cbManufacturer.SelectedItem = manufacturerName;
                    }

                    string supplierName = supplierList.FirstOrDefault(supplier => supplier.SupplierId == car.SupplierId)?.SupplierName;
                    if (!string.IsNullOrEmpty(supplierName))
                    {
                        cbSupplier.SelectedItem = supplierName;
                    }
                    textBoxPrice.Text = car.CarRentingPricePerDay.ToString();
                }
            }
        }

        private void btnCreateCar_Click(object sender, RoutedEventArgs e)
        {
            string selectedManufacturerName = cbManufacturer.SelectedItem as string;
            Manufacturer selectedManufacturer = manufacturerList.FirstOrDefault(manufacturer => manufacturer.ManufacturerName == selectedManufacturerName);

            string selectedSupplierName = cbSupplier.SelectedItem as string;
            Supplier selectedSupplier = supplierList.FirstOrDefault(supplier => supplier.SupplierName == selectedSupplierName);

            if (selectedManufacturer != null && selectedSupplier != null)
            {
                CarInformation car = new CarInformation
                {
                    CarName = (String)textBoxName.Text,
                    CarDescription = (String)textBoxDescription.Text,
                    NumberOfDoors = (int)Int32.Parse(textBoxNumberOfDoors.Text),
                    SeatingCapacity = (int)Int32.Parse(textBoxSeatingCapacity.Text),
                    FuelType = (String)textBoxFuelType.Text,
                    Year = (int)dpYear.SelectedDate.Value.Year,
                    ManufacturerId = (int)selectedManufacturer.ManufacturerId, // Use the ManufacturerId from the selected manufacturer
                    SupplierId = (int)selectedSupplier.SupplierId, // Use the SupplierId from the selected supplier
                    CarRentingPricePerDay = (decimal)Decimal.Parse(textBoxPrice.Text),
                    CarStatus = 1
                };

                if (carInformationRepository.UpdateCar(car))
                {
                    message.Height = 25;
                    message.Text = "Update Car Successfully!";
                    messageTimer.Start();
                }
                else
                {
                    errormessage.Text = "Cannot update";
                }
            }
        }

        private void btnUpdateCar_Click(object sender, RoutedEventArgs e)
        {
            string selectedManufacturerName = cbManufacturer.SelectedItem as string;
            Manufacturer selectedManufacturer = manufacturerList.FirstOrDefault(manufacturer => manufacturer.ManufacturerName == selectedManufacturerName);

            string selectedSupplierName = cbSupplier.SelectedItem as string;
            Supplier selectedSupplier = supplierList.FirstOrDefault(supplier => supplier.SupplierName == selectedSupplierName);

            if (selectedManufacturer != null && selectedSupplier != null)
            {
                CarInformation car = new CarInformation
                {
                    CarName = (String)textBoxName.Text,
                    CarDescription = (String)textBoxDescription.Text,
                    NumberOfDoors = (int)Int32.Parse(textBoxNumberOfDoors.Text),
                    SeatingCapacity = (int)Int32.Parse(textBoxSeatingCapacity.Text),
                    FuelType = (String)textBoxFuelType.Text,
                    Year = (int)dpYear.SelectedDate.Value.Year,
                    ManufacturerId = (int)selectedManufacturer.ManufacturerId, // Use the ManufacturerId from the selected manufacturer
                    SupplierId = (int)selectedSupplier.SupplierId, // Use the SupplierId from the selected supplier
                    CarRentingPricePerDay = (decimal)Decimal.Parse(textBoxPrice.Text),
                    CarStatus = 1
                };

                if (carInformationRepository.UpdateCar(car))
                {
                    message.Height = 25;
                    message.Text = "Update Car Successfully!";
                    messageTimer.Start();
                }
                else
                {
                    errormessage.Text = "Cannot update";
                }
            }
        }
    }
}
