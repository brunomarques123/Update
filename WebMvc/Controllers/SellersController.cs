using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        
        public IActionResult Index()//controlado e o Index
        {
            var list = _sellerService.FindAll(); // controlador acessa o Model pega o dado na lista
            return View(list); //retorna na view a list
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
