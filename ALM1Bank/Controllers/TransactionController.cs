using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM1Bank.Data;
using Microsoft.AspNetCore.Mvc;

namespace ALM1Bank.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Withdraw(decimal amount, int accountID)
        {
            var repo = new BankRepository();
            var account = repo.Withdraw(amount, accountID);

            if (account)
            {
                return View("~/Views/Home/Index.cshtml", repo);
            }
            ViewBag.Message = "Något blev fel. Vänligen försök igen.";
            return View("Index");
        }

        public IActionResult Deposit(decimal amount, int accountID)
        {
            var repo = new BankRepository();
            var account = repo.Deposit(amount, accountID);

            if (account)
            {
                return View("~/Views/Home/Index.cshtml", repo);
            }

            ViewBag.Message = "Något blev fel. Vänligen försök igen.";
            return View("Index");
        }
    }
}