using BusinessObjects.Models;
using Repositories;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace PhamThienNhiWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ICustomerRepository _customerRepository = new CustomerRepository();
        public class Admin
        {

            public string AdminEmail { get; set; }
            public string AdminPassword { get; set; }
        }
        public LoginWindow()
        {
            InitializeComponent();

        }
        private Admin LoadAdminCredentials()
        {
            Admin admin = null;
            try
            {
                // Read the content of appsettings.json
                string json = File.ReadAllText("appsettings.json");

                // Deserialize the JSON content to an object (you need to create a class matching your JSON structure)
                admin = JsonSerializer.Deserialize<Admin>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin credentials: " + ex.Message);
            }
            return admin;
        }

        private Boolean validateInputLogin()
        {
            Boolean valid = false;
            if (textBoxEmail.Text.Trim().Length == 0 && passwordBox1.Password.Trim().Length == 0)
            {
                errormessage.Text = "Please enter email and password!";
                textBoxEmail.Focus();
            }
            else if (textBoxEmail.Text.Length == 0 && passwordBox1.Password.Length > 0)
            {
                errormessage.Text = "Enter an email";
                textBoxEmail.Focus();

            }
            else if (passwordBox1.Password.Length == 0 && textBoxEmail.Text.Length > 0)
            {
                errormessage.Text = "Enter password";
                passwordBox1.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                valid = true;
            }
            return valid;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (validateInputLogin())
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                Admin admin = LoadAdminCredentials();
                Customer customer = _customerRepository.LoginByEmailPassword(email, password);
                if (customer != null)
                {
                    ProfileWindow profileWindow = new ProfileWindow
                    {
                        ID = customer.CustomerId
                    };
                    profileWindow.Show();
                    this.Close();
                    
                }
                else if (email == admin.AdminEmail.ToString() && password == admin.AdminPassword.ToString())
                {
                    CarManagementWindow carManagementWindow = new CarManagementWindow();
                    carManagementWindow.Show();
                    this.Close();
                }
                else
                {
                    errormessage.Text = "Email or Password is incorrect";
                }
            }

        }

        private void linkToRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            errormessage.Text = "";
        }
    }
}
