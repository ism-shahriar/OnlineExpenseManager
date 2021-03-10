using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Services;

namespace OnlineBanking.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransaction _Transaction;
        private readonly IAccount _Account;
        public TransactionsController(ITransaction _ITransaction, IAccount _IAccount)
        {
            _Transaction = _ITransaction;
            _Account = _IAccount;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            return View(_Transaction.GetTransactions);
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = _Transaction.GetTransactions;
            var transaction = transactions.FirstOrDefault(m => m.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Accounts/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Accounts = _Account.GetAccounts;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction model)
        {
            if (ModelState.IsValid)
            {
                _Transaction.Add(model);
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
                Transaction model = _Transaction.GetTransaction(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Transaction.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
