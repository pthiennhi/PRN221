using BusinessObjects.Models;
using DataAccessLayer;
using Repositories;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
using System.Diagnostics;

namespace PhamThienNhiWPF
{
    /// <summary>
    /// Interaction logic for CarManagementWindow.xaml
    /// </summary>
    /// 
    public class CarInformationExtended : CarInformation
    {
        public String ManufacturerName { get; set; }

        public String SupplierName { get; set; }
    }

    public partial class CarManagementWindow : Window
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        ICarInformationRepository carInformationRepository = new CarInformationRepository();
        IManufacturerRepository manufacturerRepository = new ManufacturerRepository();
        ISupplierRepository supplierRepository = new SupplierRepository();
        public List<Customer> customerList;
        public List<CarInformation> carInformationList;
        public List<RentingTransaction> transactionList;
        IRentingTransactionRepository transactionRepository = new RentingTransactionRepository();
        public CarManagementWindow()
        {
            InitializeComponent();
        }
        private List<dynamic> ToDynamicListCustomer(List<Customer> l)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (dynamic item in l)
            {
                list.Add(item);
            }
            return list;
        }

        private List<dynamic> ToDynamicListCarInforamtion(List<CarInformation> l)
        {
            List<dynamic> list = new List<dynamic>();

            foreach (var item in l)
            {
                Manufacturer manufacturer = manufacturerRepository.GetManufacturerByid(item.ManufacturerId);
                Supplier supplier = supplierRepository.GetSupplierById(item.SupplierId);
                var carData = new
                {
                    CarId = item.CarId,
                    CarName = item.CarName,
                    CarDescription = item.CarDescription,
                    NumberOfDoors = item.NumberOfDoors,
                    SeatingCapacity = item.SeatingCapacity,
                    FuelType = item.FuelType,
                    Year = item.Year,
                    ManufacturerName = manufacturer.ManufacturerName, // Fetched manufacturer name
                    SupplierName = supplier.SupplierName, // Fetch supplier name
                    CarRentingPricePerDay = item.CarRentingPricePerDay
                };

                list.Add(carData);
            }
            return list;
        }

        private List<dynamic> ToDynamicListTransaction(List<RentingTransaction> l)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (dynamic item in l)
            {
                list.Add(item);
            }
            return list;
        }

        private void SetDataSourceDataGridView(List<dynamic> list)
        {
            customerDataGrid.ItemsSource = null;
            if (list.Count > 0)
            {
                customerDataGrid.ItemsSource = list;
            }

        }

        public void LoadDataCustomer()
        {
            try
            {
                customerList = customerRepository.GetAllCustomers();
                SetDataSourceDataGridView(ToDynamicListCustomer(customerList));
            }
            catch (Exception ex)
            {
                errormessage.Text = ex.Message;
            }
        }

        public void LoadDataCar()
        {
            try
            {
                carInformationList = carInformationRepository.GetAllCars();

                if (carInformationList.Count > 0)
                {
                    carDataGrid.ItemsSource = ToDynamicListCarInforamtion(carInformationList);
                }
            }
            catch (Exception ex)
            {
                errormessage.Text = ex.Message;
            }
        }

        public void LoadDataTransaction()
        {
            try
            {
                transactionList = transactionRepository.GetAllTransactions();

                if (transactionList.Count > 0)
                {
                    transactionDataGrid.ItemsSource = ToDynamicListTransaction(transactionList);
                }
            }
            catch (Exception ex)
            {
                errormessage.Text = ex.Message;
            }
        }

        private void CarManagement_Load(object sender, RoutedEventArgs e)
        {
            LoadDataCustomer();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = string.Empty;

            string searchTerm = txtSearch.Text.Trim();
            string searchBy = (cmbSearchBy.SelectedItem as ComboBoxItem)?.Tag as string;
            System.Diagnostics.Debug.WriteLine(searchBy);


            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrEmpty(searchBy))
            {
                try
                {
                    List<Customer> searchResults = customerRepository.SearchCustomers(searchTerm, searchBy);
                    SetDataSourceDataGridView(ToDynamicListCustomer(searchResults));
                }
                catch (Exception ex)
                {
                    errormessage.Text = ex.Message;
                }
            }
            else
            {
                errormessage.Text = "Enter a keyword and select a search option";
                txtSearch.Focus();
            }
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CustomerDetail customerDetail = new CustomerDetail
            {

                AddOrUpdate = true,
            };
            customerDetail.ShowDialog();

            LoadDataCustomer();


        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (customerDataGrid.SelectedItem != null)
            {
                errormessage.Text = "";
                CustomerDetail customerDetail = new CustomerDetail
                {
                    AddOrUpdate = false,
                    ID = ((Customer)customerDataGrid.SelectedItem).CustomerId
                };
                customerDetail.ShowDialog();

                LoadDataCustomer();

            }
            else
            {
                errormessage.Text = "Select customer before updating";
            }

        }

        private void btnViewAll_Click(object sender, RoutedEventArgs e)
        {
            LoadDataCustomer();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (customerDataGrid.SelectedItem != null)
            {
                errormessage.Text = "";
                Customer customer = (Customer)customerDataGrid.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Are you sure to delete this customer?", "Confirmation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    customerRepository.DeleteCustomer(customer);
                    LoadDataCustomer();
                }


            }
            else
            {
                errormessage.Text = "Select customer before updating";
            }
        }

        private void TabConTrolSelectChanged(object sender, SelectionChangedEventArgs e)
        {

            if (tabControl.SelectedItem is TabItem selectedTab)
            {
                try
                {
                    switch (selectedTab.Header.ToString())
                    {
                        case "Manage Cars":
                            LoadDataCar();

                            break;
                        case "Manage Renting Transactions": // Replace with the actual Name of your TabItem
                            LoadDataTransaction();      // Code specific to TabItem 2
                            break;
                        // Add more cases for each TabItem if needed

                        default:
                            // Default behavior if no matching TabItem is found
                            break;
                    }
                }
                catch (Exception ex)
                {
                    errormessage.Text = ex.Message;
                }


            }
        }

        private void btnViewAllCar_Click(object sender, RoutedEventArgs e)
        {
            LoadDataCar();
        }

        private void btnSearchCar_Click(object sender, RoutedEventArgs e)
        {
            errormessage.Text = string.Empty;

            string searchTerm = txtSearchCar.Text.Trim();
            string searchBy = (cmbSearchCarBy.SelectedItem as ComboBoxItem)?.Tag as string;

            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrEmpty(searchBy))
            {
                try
                {
                    List<CarInformation> searchResults = carInformationRepository.SearchCars(searchTerm, searchBy);
                    if (carInformationList.Count > 0)
                    {
                        carDataGrid.ItemsSource = ToDynamicListCarInforamtion(searchResults);
                    }

                }
                catch (Exception ex)
                {
                    errormessage.Text = ex.Message;
                }
            }
            else
            {
                errormessage.Text = "Enter a keyword and select a search option";
                txtSearch.Focus();
            }
        }

        private void btnCreateCar_Click(object sender, RoutedEventArgs e)
        {
            CarDetailWindow carDetailWindow = new CarDetailWindow
            {
                AddOrUpdate = true,
            };
            carDetailWindow.ShowDialog();

            LoadDataCar();
        }

        private void btnUpdateCar_Click(object sender, RoutedEventArgs e)
        {
            if (carDataGrid.SelectedItem != null)
            {

                errorCar.Text = "";

                CarDetailWindow carDetail = new CarDetailWindow()
                {
                    AddOrUpdate = false,
                    ID = ((dynamic)carDataGrid.SelectedItem).CarId
                };
                carDetail.ShowDialog();

                LoadDataCar();

            }
            else
            {
                errorCar.Text = "Select car before updating";
            }
        }

        private void btnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (carDataGrid.SelectedItem != null)
            {
                errorCar.Text = "";
                dynamic car = carDataGrid.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Are you sure to delete this car?", "Confirmation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    IRentingDetailRepository repository = new RentingDetailRepository();
                    List<RentingDetail> lrd = repository.GetAllRentingDetails();
                    if (lrd.Any(item => item.CarId == car.CarId))
                    {
                        MessageBox.Show("Car is rented, cannot delete!");
                    }
                    else
                    {
                        carInformationRepository.DeleteCar(car.CarId);
                    }
                    LoadDataCar();
                }


            }
            else
            {
                errorCar.Text = "Select car before updating";
            }
        }

        private void btnViewAllTransaction_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTransaction();
        }

        private void btnCreateTransaction_Click(object sender, RoutedEventArgs e)
        {

            //LoadDataCar();
        }

        private void btnUpdateTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (transactionDataGrid.SelectedItem != null)
            {

                MessageBoxResult result = MessageBox.Show("Are you sure to update this transaction?", "Confirmation", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    RentingTransaction transaction = transactionDataGrid.SelectedItem as RentingTransaction;
                    if (transaction != null)
                    {
                        transaction.RentingStatus = (byte)(1 - transaction.RentingStatus);
                    }
                    transactionRepository.UpdateTransaction(transaction);
                    LoadDataTransaction();
                }

                LoadDataTransaction();
            }
            else
            {
                errorCar.Text = "Select car before updating";
            }


        }
    }
}
