using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaleMusic.Models;

namespace DaleMusic.Controllers
{
    public class UserController : Controller
    {
        DaYueDBEntities db = new DaYueDBEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        //查看个人信息
        public ActionResult UserDetails(int? id)
        {
            UserInfo user = db.UserInfo.Find(id); 
            return View(user);
        }
        //编辑个人信息
        public ActionResult UserEdit(int? id)
        {
            UserInfo user = db.UserInfo.Where(p => p.UserID == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult UserEdit(UserInfo user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UserDetails",new { id= user.UserID});
        }
        //用户上传
        public ActionResult UserUpload()
        {
            return View();
        }
    }
}