﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    [AllowAnonymous]
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.i=id;
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}