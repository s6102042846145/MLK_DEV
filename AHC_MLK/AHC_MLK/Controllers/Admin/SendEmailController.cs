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

        // GET: MemberList/Edit/5
        public ActionResult Edit(int id)
        {
            return View(SendEmailDao.Instance.GetEmailList().Find(smodel => smodel.id == id));
        }

        // POST: MemberList/Edit/5
        [HttpPost]
        public ActionResult Edit(SendEmailDto model)
        {
            try
            {
                string result = SendEmailDao.Instance.SaveEmail(model, "edit");
                if (result != "OK")
                {
                    ViewBag.Message = result;
                }
                else
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberList/Delete/5      
        public ActionResult Delete(SendEmailDto model)
        {
            try
            {
                string result = SendEmailDao.Instance.SaveEmail(model, "del");
                if (result == "OK")
                {
                    ViewBag.Message = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error : " + e.Message.ToString();
                return View();
            }
        }
    }
}