using BusinessObjects.Models;
using Repositories.Interface;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PhamThienNhiWPF
{
    /// <summary>
    /// Interaction logic for CustomerDetail.xaml
    /// </summary>
    public partial class CustomerDetail : Window
    {
        public bool AddOrUpdate { get; set; }
        public int ID { get; set; }
        private DispatcherTimer messageTimer;
        private ICustomerRepository _customerRepository = new CustomerRepository();
        public CustomerDetail()
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
        private void CustomerDetail_Loaded(object sender, RoutedEventArgs e)
        {
            if (AddOrUpdate)
            {
                btnUpdate.Visibility = Visibility.Hidden;
            }
            else
            {
                btnCreate.Visibility = Visibility.Hidden;
                Customer customer = _customerRepository.GetCustomerById(ID);
                if (customer != null)
                {
                    textBoxName.Text = customer.CustomerName;
                    textBoxEmail.Text = customer.Email;
                    textBoxPhone.Text = customer.Telephone;
                    DateTime dateTime = (DateTime)customer.CustomerBirthday;
                    dpBirthday.SelectedDate = dateTime;
                }
            }
        }

        private Boolean validateInput()
        {
            Boolean result = false;
            String patternPhone = @"^(0[2-9]|0[1-9][0-9])([0-9]{7})$|^(03[2-9]|03[1-9][0-9])([0-9]{6})$|^(05[6-9]|05[0-9][0-9])([0-9]{6})$|^(07[0-9]|07[0-9][0-9])([0-9]{6})$|^(08[1-9]|08[1-9][0-9])([0-9]{6})$|^(09[0-9]|09[0-9][0-9])([0-9]{6})$";
            String patternName = "^[a-zA-Z]+$";
            String patternEmail = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            if (textBoxName.Text.Trim().Length == 0 || textBoxEmail.Text.Trim().Length == 0
                || textBoxPhone.Text.Length == 0 || textBoxPhone.Text.Length == 0 || !dpBirthday.SelectedDate.HasValue
                || passwordBox.Password.Length == 0 || confirmPasswordBox.Password.Length == 0
                )
            {
                errormessage.Text = "Please enter all field";
            }
            else if (!Regex.IsMatch(textBoxName.Text, patternName))
            {
                errormessage.Text = "Enter a valid name";
                textBoxName.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, patternEmail))
            {
                errormessage.Text = "Enter a valid Email";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxPhone.Text, patternPhone) || textBoxPhone.Text.Length > 12
                || textBoxPhone.Text.Length < 10
                || (!textBoxPhone.Text.StartsWith("0") && !textBoxPhone.Text.StartsWith("84"))
                )
            {
                errormessage.Text = "Enter a valid Phone";
                textBoxPhone.Focus();
            }
            else if (passwordBox.Password != confirmPasswordBox.Password)
            {
                errormessage.Text = "Confirm Password is not match with password";
                confirmPasswordBox.Focus();
            }
            else
            {
                result = true;
            }
            return result;

        }
        private Boolean validateInputUpdate()
        {
            Boolean result = false;
            String patternPhone = @"^(0[2-9]|0[1-9][0-9])([0-9]{7})$|^(03[2-9]|03[1-9][0-9])([0-9]{6})$|^(05[6-9]|05[0-9][0-9])([0-9]{6})$|^(07[0-9]|07[0-9][0-9])([0-9]{6})$|^(08[1-9]|08[1-9][0-9])([0-9]{6})$|^(09[0-9]|09[0-9][0-9])([0-9]{6})$";
            String patternName = "^[a-zA-Z]+$";
            String patternEmail = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            
            if (!Regex.IsMatch(textBoxName.Text, patternName))
            {
                errormessage.Text = "Enter a valid name";
                textBoxName.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, patternEmail))
            {
                errormessage.Text = "Enter a valid Email";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxPhone.Text, patternPhone) || textBoxPhone.Text.Length > 12
                || textBoxPhone.Text.Length < 10
                || (!textBoxPhone.Text.StartsWith("0") && !textBoxPhone.Text.StartsWith("84"))
                )
            {
                errormessage.Text = "Enter a valid Phone";
                textBoxPhone.Focus();
            }
            else if (passwordBox.Password != confirmPasswordBox.Password)
            {
                errormessage.Text = "Confirm Password is not match with password";
                confirmPasswordBox.Focus();
            }
            else
            {
                result = true;
            }
            return result;
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
                String name = textBoxName.Text.Trim();
                String email = textBoxEmail.Text.Trim();
                String phone = Regex.Replace(textBoxPhone.Text, @"\s", "");
                DateTime birthday = dpBirthday.SelectedDate.Value;
                String password = passwordBox.Password;
                Customer customer = new Customer
                {
                    CustomerName = name,
                    CustomerBirthday = birthday,
                    Telephone = phone,
                    Email = email,
                    Password = password,
                    CustomerStatus = 1
                };

                if (_customerRepository.AddNewCustomer(customer))
                {
                    message.Height = 25;
                    message.Text = "Create New Account Successfully!";
                    messageTimer.Start();

                }
                else
                {
                    errormessage.Text = "Email is already used. Please enter another email.";
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            errormessage.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (validateInputUpdate())
            {
                String name = textBoxName.Text.Trim();
                String email = textBoxEmail.Text.Trim();
                String phone = Regex.Replace(textBoxPhone.Text, @"\s", "");
                DateTime birthday = dpBirthday.SelectedDate.Value;
                String password = passwordBox.Password;
                Customer c = _customerRepository.GetCustomerById(ID);
                if (textBoxName.Text.Trim().Length == 0)
                {
                    name = c.CustomerName;
                }
                else if(textBoxEmail.Text.Trim().Length == 0)
                {
                    email = c.Email;
                }
                else if(textBoxPhone.Text.Length == 0)
                {
                    phone = c.Telephone;
                }
                else if (!dpBirthday.SelectedDate.HasValue)
                {
                    birthday = (DateTime)c.CustomerBirthday;
                }
                else if(passwordBox.Password.Length == 0)
                {
                    password = c.Password;
                }
                Customer customer = new Customer
                {
                    CustomerId = ID,
                    CustomerName = name,
                    CustomerBirthday = birthday,
                    Telephone = phone,
                    Email = email,
                    Password = password,
                    CustomerStatus = 1
                };

                if (_customerRepository.UpdateCustomer(customer))
                {
                    message.Height = 25;
                    message.Text = "Update Account Successfully!";
                    messageTimer.Start();

                }
                else
                {
                    errormessage.Text = "Can not update";
                }
            }
        }

        
    }
}
