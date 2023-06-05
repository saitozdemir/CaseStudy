using CaseStudy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace CaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ProductContext _context;

        public HomeController(ILogger<HomeController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ProductList = _context.Products.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Products product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            var updateProduct = _context.Products.Find(id);
            return View(updateProduct);
        }

        [HttpPost]
        public IActionResult ProductUpdate(Products product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var deleteProduct = await _context.Products.FindAsync(id);
            _context.Remove(deleteProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}