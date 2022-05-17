using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using slnLINQ.Models;

namespace slnLINQ.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public string ShowArrayDesc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            var sort = score.OrderByDescending(m => m);

            //sort = from i in score
            //       orderby i descending
            //       select i;

            string show = "遞減排序:";
            foreach (var i in sort)
            {
                show += i + ",";
            }

            show += "<br />";
            show += "總和:" + sort.Sum();

            return show;
        }

        public string ShowArrayAsc()
        {
            int[] score = new int[] { 78, 99, 20, 100, 66 };
            var sort = score.OrderBy(m => m);

            //sort = from i in score
            //       orderby i ascending
            //       select i;

            string show = "遞增排序:";
            foreach (var i in sort)
            {
                show += i + ",";
            }

            show += "<br />";
            show += "平均:" + sort.Average();

            return show;
        }

        public string LoginMember(string uid, string pwd)
        {
            Member[] members = new Member[]
            {
                new Member { UId="tom", Pwd="123",Name="湯姆" },
                new Member { UId="jasper", Pwd="456",Name="賈伯斯" },
                new Member { UId="mary", Pwd="789",Name="瑪莉" }
            };

            var result = members.Where(m => m.UId == uid && m.Pwd == pwd).FirstOrDefault();

            string show = "";

            if (result != null)
            {
                show = result.Name + "歡迎進入系統";
            }
            else
            {
                show = "帳號密碼錯誤!";
            }

            return show;
        }
    }
}