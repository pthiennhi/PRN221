using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWinApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyWinApp
{
    public partial class frmProduct : Form
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public frmProduct()
        {
            InitializeComponent();
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:5001/api/products";
        }

        private async void LoadProducts()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(stringData, options);

            dgvProductList.DataSource = products;
        }
        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
