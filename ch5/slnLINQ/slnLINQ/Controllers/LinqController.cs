using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using slnLINQ.Models;

namespace slnLINQ.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        public string ShowEmployee()
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.員工;

            string show = "";

            foreach (var i in result)
            {
                show += "編號:" + i.員工編號 + "<br />";
                show += "姓名:" + i.姓名 + i.稱呼 + "<br />";
                show += "職稱:" + i.職稱 + "<hr>";
            }

            return show;
        }

        public string ShowCustomByAddress(string keyword)
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.客戶.Where(m => m.地址.Contains(keyword));

            string show = "";
            foreach (var i in result)
            {
                show += "公司:" + i.公司名稱 + "<br />";
                show += "姓名:" + i.連絡人 + i.連絡人職稱 + "<br />";
                show += "地址:" + i.地址 + "<hr>";
            }

            return show;
        }

        public string ShowProduct()
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.產品資料.Where(m => m.單價 > 30).OrderBy(m => m.單價).ThenByDescending(m => m.庫存量);

            string show = "";
            foreach (var i in result)
            {
                show += "產品:" + i.產品 + "<br />";
                show += "單價:" + i.單價 + "<br />";
                show += "庫存量:" + i.庫存量 + "<hr>";
            }
            return show;
        }

        public string ShowProductInfo()
        {
            NorthwindEntities db = new NorthwindEntities();

            var result = db.產品資料;

            string show = "";
            show += "平均價:" + result.Average(m => m.單價) + "<br />";
            show += "總和:" + result.Sum(m => m.單價) + "<br />";
            show += "筆數:" + result.Count() + "<br />";
            show += "最高價:" + result.Max(m => m.單價) + "<br />";
            show += "最低價:" + result.Min(m => m.單價) + "<hr>";


            return show;
        }
    }
}