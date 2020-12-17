using AHCBL.Dao.Admin;
using AHCBL.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHC_MLK.Controllers.Admin
{
    public class MemberListController : Controller
    {
        // GET: MemberList
        public ActionResult Index()
        {
            return View(MemberListDao.Instance.GetMemberList());
        }

        // GET: MemberList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberList/Create
        [HttpPost]
        public ActionResult Create(MemberListDto Member)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string result = MemberListDao.Instance.SaveMember(Member, "add");
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
            return View(MemberListDao.Instance.GetMemberList().Find(smodel => smodel.id == id));
        }

        // POST: MemberList/Edit/5
        [HttpPost]
        public ActionResult Edit(MemberListDto Member)
        {
            try
            {
                string result = MemberListDao.Instance.SaveMember(Member, "edit");
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
        public ActionResult Delete(MemberListDto Member)
        {
            try
            {
                string result = MemberListDao.Instance.SaveMember(Member, "del");
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
