using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        CreditContext db1 = new CreditContext();
        DepositContext db2 = new DepositContext();
        public ActionResult Credits()
        {
            IEnumerable<Credit> credits = db1.Credits;
            ViewBag.Credits = credits;
            return View("~/Views/Home/Credits.cshtml");
        }
        [HttpPost]
        public ActionResult Credits(int? sum)
        {
            IEnumerable<Credit> credits = db1.Credits;
            ViewBag.Credits = credits;
            if (sum == null)
            {
                return View();
            }
            else
            {
                ViewBag.sum = Convert.ToInt32(sum);
                return View();
            }
        }
        [HttpGet]
        public ActionResult Deposits()
        {
            IEnumerable<Deposit> deposits = db2.Deposits;
            ViewBag.Deposits = deposits;
            return View("~/Views/Home/Deposits.cshtml");
        }
        [HttpPost]
        public ActionResult Deposits(int? sum, String Limit)
        {
            IEnumerable<Deposit> deposits = db2.Deposits;
            ViewBag.Deposits = deposits;
            if (sum == null)
            {
                ViewBag.limit = null;
                return View();
            }
            else
            {
                ViewBag.sum1 = Convert.ToInt32(sum);
                if (Limit == "любой") { ViewBag.limit = null; }
                else { ViewBag.limit = Limit; }
                return View();
            }
        }

        public ActionResult DepositCalc()
        {
            return View("~/Views/Home/DepositCalc.cshtml");
        }
        public ActionResult CreditCalc()
        {
            return View("~/Views/Home/CreditCalc.cshtml");
        }
        [HttpPost]
        public ViewResult DepositCalc(int Sum, int Limit, double Rate, DateTime Start, String Period)
        {
            int period = 0;
            Limit = Limit * 365;
            switch (Period)
            {
                case ("ежедневно"):
                    period = 365;
                    break;
                case ("еженедельно"):
                    period = 52;
                    break;
                case ("раз в месяц"):
                    period = 12;
                    break;
                case ("раз в квартал"):
                    period = 4;
                    break;
                case ("раз в полгода"):
                    period = 2;
                    break;
                case ("раз в год"):
                    period = 1;
                    break;
                default:
                    break;
            }
            double procents = (Sum * Rate * Limit / 365) / 100;
            double onPeriod = procents / (period * (Limit / 365));
            ViewData["Procents"] = procents;
            ViewData["Period"] = onPeriod;
            return View("~/Views/Home/DepositCalc.cshtml");
        }
        [HttpPost]
        public ViewResult CreditCalc(int Sum, String Limit, double Rate)
        {
            int limit = 0;
            Rate = Rate / 100;
            switch (Limit)
            {
                case ("3 месяца"):
                    limit = 3;
                    break;
                case ("6 месяцев"):
                    limit = 6;
                    break;
                case ("год"):
                    limit = 12;
                    break;
                case ("2 года"):
                    limit = 24;
                    break;
                case ("4 года"):
                    limit = 48;
                    break;
                case ("5 лет"):
                    limit = 60;
                    break;
                case ("8 лет"):
                    limit = 96;
                    break;
                case ("10 лет"):
                    limit = 120;
                    break;
                case ("15 лет"):
                    limit = 180;
                    break;
                case ("20 лет"):
                    limit = 240;
                    break;
                case ("25 лет"):
                    limit = 300;
                    break;
                case ("30 лет"):
                    limit = 360;
                    break;
                default:
                    break;
            }
            double annuitet = (Rate / 12 * Math.Pow(1 + Rate / 12, limit) / (Math.Pow(1 + Rate / 12, limit) - 1));
            double annuPay = Sum * annuitet;
            double total = limit * annuPay;
            double overPay = total - Sum;
            ViewData["AnnuPay"] = annuPay;
            ViewData["Total"] = total;
            ViewData["Over"] = overPay;
            return View();
        }
    }
    
}