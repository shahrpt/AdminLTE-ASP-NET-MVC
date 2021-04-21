using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminlte.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Dashboardv1()
        {
            return View();
        }

        public ActionResult Dashboardv2()
        {
            return View();
        }


        adminlte.Models.CartRoverEntities db = new adminlte.Models.CartRoverEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.Products;
            
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] adminlte.Models.Product item)
        {
            var model = db.Products;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] adminlte.Models.Product item)
        {
            var model = db.Products;
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var modelItem = model.FirstOrDefault(it => it.PID == item.PID);
                    if (modelItem != null)
                    {
                        this.TryUpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 PID)
        {
            var model = db.Products;
            if (PID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PID == PID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}