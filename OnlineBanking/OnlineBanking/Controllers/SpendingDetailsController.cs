using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Services;

namespace OnlineBanking.Controllers
{
    public class SpendingDetailsController : Controller
    {
        private readonly ISpendingDetail _SpendingDetail;
        private readonly IClient _Client;
        private readonly ISpendingCategory _SpendingCategory;
        public SpendingDetailsController(ISpendingDetail _ISpendingDetail,
            IClient _IClient, ISpendingCategory _ISpendingCategory)
        {
            _SpendingDetail = _ISpendingDetail;
            _Client = _IClient;
            _SpendingCategory = _ISpendingCategory;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            return View(_SpendingDetail.GetSpendingDetails);
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spendingDetails = _SpendingDetail.GetSpendingDetails;
            var spendingDetail = spendingDetails.FirstOrDefault(m => m.SpendingID == id);

            if (spendingDetail == null)
            {
                return NotFound();
            }
            
            return View(spendingDetail);



        }

        // GET: Accounts/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clients = _Client.GetClients;
            ViewBag.SpendingCategories = _SpendingCategory.GetSpendingCategories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpendingDetail model)
        {

            if (ModelState.IsValid)
            {
                _SpendingDetail.Add(model);
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
                SpendingDetail model = _SpendingDetail.GetSpendingDetail(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _SpendingDetail.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
