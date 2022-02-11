using Microsoft.AspNetCore.Mvc;

using ResponsiveAdminDashboard_UI.Models;

using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace ResponsiveAdminDashboard_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listOrderSampleData = CreateSampleData(14);
            return View(listOrderSampleData);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Order> CreateSampleData(int quantity)
        {
            //sample data

            var status = new List<string>() { "Delivery", "Pending", "Declined" };
            var payment = new List<string>() { "Paid", "In-progress", "Return" };

            List<Order> listOrderData = new List<Order>();
            var random = new Random();
            for (int i = 0; i < quantity; i++)
            {
                int index = random.Next(status.Count);
                int paystatus = random.Next(payment.Count);

                var orderData = new Order
                {
                    productName = RandomString(10),
                    projductNumber = random.Next(0, 1000000).ToString("D6"),
                    paymentStatus = payment[index],
                    shipping = status[paystatus],
                };

                listOrderData.Add(orderData);

            }

           

            return listOrderData;
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}