using Hotel_AllFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_AllFrameWork.Controllers
{
    public class CeoController : Controller
    {

        List<Ceo> listOfCeo = new List<Ceo>()
       {
           new Ceo(0, "Yafit Samuel",22,"yafit642@gmail.com",16000),
            new Ceo(0, "keren Samuel",22,"yafit642@gmail.com",16000),
             new Ceo(0, "eden Samuel",22,"yafit642@gmail.com",16000),
              new Ceo(0, "tikva Samuel",22,"yafit642@gmail.com",16000),
                new Ceo(0, "lemlem Samuel",22,"yafit642@gmail.com",16000)
       };

        // GET: Ceo
        public ActionResult Name()
        {
            return View(listOfCeo[4]);
        }

        public ActionResult CeoById(int id)
        {
            return View(listOfCeo[id]);
        }
    
    }
}