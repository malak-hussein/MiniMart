using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMart.Data;
using MiniMart.Models;

namespace MiniMart.Controllers
{
    //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }
        [HttpGet]
        public IActionResult GetIndexView()
        {
            return View("Index", context.Products.ToList());
        }
        [HttpGet]
        public IActionResult GetCreateView()
        {
            ViewBag.AllCategories = context.Categories.ToList();
            return View("Create");
        }
        [HttpPost]
        public IActionResult AddNew(Product product)
        {
            if (ModelState.IsValid == true)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllCategories = context.Categories.ToList();
                return View("Create", product);
            }
        }
        //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            Product product = context.Products.Include(product => product.Category).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", product);
            }
        }
        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllCategories = context.Categories.ToList();
                return View("Edit", product);
            }
        }
        //- Malak Hussein Ahmed Mohamed- Fayoum University - Faculty of Computers and Artificial Intelligence -  Up to level 4
        [HttpPost]
        public IActionResult EditCurrent(Product product)
        {
            if (ModelState.IsValid == true)
            {
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllCategories = context.Categories.ToList();
                return View("Edit", product);
            }
        }
        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Product product = context.Products.Include(product => product.Category).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", product);
            }
        }
        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Product product = context.Products.Find(id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }

    }
}
