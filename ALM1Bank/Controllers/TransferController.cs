using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALM1Bank.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALM1Bank.Controllers
{
    public class TransferController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Transfer(decimal amount, int accountIDOne,int accountIDTwo)
        {
            var repo = new BankRepository();
            var account = repo.Transfer(amount, accountIDOne, accountIDTwo);

            if (account)
            {
                return View("~/Views/Home/Index.cshtml", repo);
            }
            ViewBag.Message = "Något blev fel. Du har antingen försökt överföra ett för stort belopp, försökt skriva andra tecken än siffror eller skrivit in ett kontonr som inte existerar.";
            return View("Index");
        }

    

    }
}
