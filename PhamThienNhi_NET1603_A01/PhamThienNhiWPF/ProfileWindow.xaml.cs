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
using BusinessObjects.Models;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace PhamThienNhiWPF
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        Customer customer;
        public int ID { get; set; }
        private DispatcherTimer messageTimer;

       
        public ProfileWindow()
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
        private void LoadCustomer(object sender, RoutedEventArgs e)
        {
            customer = customerRepository.GetCustomerById(ID);

            textBoxName.Text = customer.CustomerName;
            textBoxEmail.Text = customer.Email;
            textBoxPhone.Text = customer.Telephone;
            dpBirthday.SelectedDate = customer.CustomerBirthday;
            passwordBox.Password = customer.Password;
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

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            if (validateInputUpdate())
            {
                String name = textBoxName.Text.Trim();
                String email = textBoxEmail.Text.Trim();
                String phone = Regex.Replace(textBoxPhone.Text, @"\s", "");
                DateTime birthday = dpBirthday.SelectedDate.Value;
                String password = passwordBox.Password;
                Customer c = customerRepository.GetCustomerById(ID);
                if (textBoxName.Text.Trim().Length == 0)
                {
                    name = c.CustomerName;
                }
                else if (textBoxEmail.Text.Trim().Length == 0)
                {
                    email = c.Email;
                }
                else if (textBoxPhone.Text.Length == 0)
                {
                    phone = c.Telephone;
                }
                else if (!dpBirthday.SelectedDate.HasValue)
                {
                    birthday = (DateTime)c.CustomerBirthday;
                }
                else if (passwordBox.Password.Length == 0)
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

                if (customerRepository.UpdateCustomer(customer))
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
