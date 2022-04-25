using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P224Allup.DAL;
using P224Allup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P224Allup.Controllers
{
    public class ProductController : Controller
    {
        private readonly AllupDbContext _context;

        public ProductController(AllupDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DetailModal(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return PartialView("_ProductDetailPartial",product);
        }

        public async Task<IActionResult> AddBasket(int? id, int count = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();
            

            return PartialView("_BasketPartial");
        }
    }
}
