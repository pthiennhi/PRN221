 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyWebApp.Controllers
{
    public class ProductManagerController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public ProductManagerController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:5001/api/products";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(listProducts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ProductApiUrl, contentData);
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Insert successfully!";
                }
                else
                {
                    ViewBag.Message = "Error while calling WebAPI!";
                }
            }
            return View(p);
        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        TempData["Message"] = "Delete successfully!";
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Error while calling WebAPI!";
        //    }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
