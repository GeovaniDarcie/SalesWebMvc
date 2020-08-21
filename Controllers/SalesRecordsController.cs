using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
         public IActionResult Index()
        {
            return View();
        }

         public IActionResult SimpleSearch()
        {
            return View();
        }

         public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}