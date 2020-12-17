using AHCBL.Dao.Admin;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers.Admin
{
    public class SendEmailController : Controller
    {
        // GET: SendEmail
        // GET: SendEmail
        public ActionResult Index()
        {
            return View(SendEmailDao.Instance.GetEmailList());
        }

        // GET: SendEmail/Createsss
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendEmail/Create
        [HttpPost]
        public ActionResult Create(SendEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = SendEmailDao.Instance.SaveEmail(email, "add");
                    if (result != "OK")
                    {
                        ViewBag.Message = result;
                        ModelState.Clear();
                    }
                    else
                    {
                        //ViewBag.Status = TempData["Dropdown"];
                        ViewBag.Message = "Successfully !!";
                        //KRPBL.Component.Common.Form.SetAlertMessage(this,"ไม่พบ User ID ที่ระบุ กรุณาตรวจสอบ");
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error : " + e.Message;
                return View();
            }
        }

        // GET: SendEmail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SendEmail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SendEmail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SendEmail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
