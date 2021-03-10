using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Services;
using OnlineBanking.Models;

namespace OnlineBanking.Controllers
{
    public class SpendingCategoriesController : Controller
    {
        private readonly ISpendingCategory _SpendingCategory;
        public SpendingCategoriesController(ISpendingCategory _ISpendingCategory)
        {
            _SpendingCategory = _ISpendingCategory;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            return View(_SpendingCategory.GetSpendingCategories);
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingCategories = _SpendingCategory.GetSpendingCategories;
            var spendingCategory = spendingCategories.FirstOrDefault(m => m.CategoryID == id);

            if (spendingCategory == null)
            {
                return NotFound();
            }

            return View(spendingCategory);
        }

        // GET: Accounts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpendingCategory model)
        {
            if (ModelState.IsValid)
            {
                _SpendingCategory.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Accounts/Create
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                SpendingCategory model = _SpendingCategory.GetSpendingCategory(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _SpendingCategory.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
