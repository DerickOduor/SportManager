using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SportManager.Controllers
{
    public class LogoutController : Controller
    {
        // GET: LogoutController
        public ActionResult Index()
        {
            try
            {
                HttpContext.Session.Clear();
            }catch(Exception ex)
            {
                
            }
            return RedirectToAction("Index","Login");
        }
    }
}
