using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise1NET6_SE150257
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IProductsRepository productsRepository = new ProductsRepository();
        ICategoriesRepository categoriesRepository = new CategoriesRepository();

        public ObservableCollectionListSource<Product> source = new ObservableCollectionListSource<Product>();
        public List<Product> products;
        public List<Category> categories;
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<dynamic> ToDynamicListProduct(List<Product> products)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Product product in products)
            {
                list.Add(product);
            }
            return list;
        }
        private List<dynamic> ToDynamicListCategory(List<Category> categories)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (Category category in categories)
            {
                list.Add(category.CategoryName);
            }
            return list;
        }

        private void SetDataSourceDataGridView(List<dynamic> li)
        {
            dgvProducts.ItemsSource = null;
            if (li.Count > 0)
            {
                dgvProducts.ItemsSource = li;
            }


        }
        private void SetDataSourceComboBox(List<dynamic> li)
        {
            cbCategory.ItemsSource = null;
            if (li.Count > 0)
            {
                cbCategory.ItemsSource = li;
                cbCategory.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            try
            {
                products = productsRepository.GetProducts();
                SetDataSourceDataGridView(ToDynamicListProduct(products));

                categories = categoriesRepository.GetCategories();
                SetDataSourceComboBox(ToDynamicListCategory(categories));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Data", MessageBoxButton.OK);
            }
        }


        private void wdProduct(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            string textId = txtProductID.Text.Trim();
            string textprice = txtPrice.Text.Trim();
            string textUnitsInStock = txtUnitsInStock.Text.Trim();
            Category category = categories[cbCategory.SelectedIndex];
            string textCategoryId = categories[cbCategory.SelectedIndex].CategoryId.ToString().Trim();
            string name = txtProductName.Text.Trim();

            try
            {
                if (textId.Length == 0 || name.Length == 0 || textprice.Length == 0 || textUnitsInStock.Length == 0 || textCategoryId.Length == 0)
                {
                    throw new Exception("Can not create new product if one field is null");
                }
                else
                {
                    int id = Int32.Parse(textId);
                    short price = short.Parse(textprice);
                    decimal units_instock = decimal.Parse(textUnitsInStock);
                    int categoryId = Int32.Parse(textCategoryId);

                    Product newProduct = new Product
                    {
                        ProductId = id,
                        ProductName = name,
                        UnitPrice = price,
                        UnitsInStock = (short?)units_instock,
                        CategoryId = categoryId,
                    };
                    productsRepository.CreateProduct(newProduct);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

}
