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
    public class ClientsController : Controller
    {       
        private readonly IClient _Client;
        public ClientsController(IClient _IClient)
        {
            _Client = _IClient;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            return View(_Client.GetClients);
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clients = _Client.GetClients;
            var client = clients.FirstOrDefault(m => m.ClientId == id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Accounts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client model)
        {
            if (ModelState.IsValid)
            {
                _Client.Add(model);
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
                Client model = _Client.GetClient(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Client.Remove(Id);
            return RedirectToAction("Index");
        }
    }
}
