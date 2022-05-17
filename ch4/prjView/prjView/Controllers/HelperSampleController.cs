using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjView.Models;

namespace prjView.Controllers
{
    public class HelperSampleController : Controller
    {
        // GET: HelperSample
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            string msg = "註冊資料如下:<br>帳號:" + member.UserId + "<br>密碼:" + member.Pwd + "<br>姓名:" + member.Name + "<br>信箱:" + member.Email + "<br>生日:" + member.Birthday.ToShortDateString();

            ViewBag.Msg = msg;
            return View(member);
        }
    }
}