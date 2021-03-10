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
    public class AccountsController : Controller
    {
        private readonly IAccount _Account;
        private readonly IClient _Client;
        public AccountsController(IAccount _IAccount, IClient _IClient)
        {
            _Account = _IAccount;
            _Client = _IClient;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            return View(_Account.GetAccounts);
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = _Account.GetAccounts;
            var account = accounts.FirstOrDefault(m => m.AccountId == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clients = _Client.GetClients;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                _Account.Add(model);
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
                Account model = _Account.GetAccount(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Account.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
