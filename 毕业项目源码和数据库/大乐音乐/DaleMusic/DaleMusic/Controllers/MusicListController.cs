using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaleMusic.Models;

namespace DaleMusic.Controllers
{
    public class MusicListController : Controller
    {
        DaYueDBEntities db = new DaYueDBEntities();
        // GET: MusicList
        public ActionResult Index()
        {
            UserInfo userInfo = Session["user"] as UserInfo;
            List<MusicList> musicList = db.MusicList.Where(p=>p.UserID==userInfo.UserID).ToList();
            return View(musicList);
        }
        //收藏音乐
        public ActionResult Create(int type,int id )
        {
            UserInfo userInfo = Session["user"] as UserInfo;
            if (type==0)
            {
                MusicList music = db.MusicList.Where(p => p.UserID == userInfo.UserID && p.MusicID == id).FirstOrDefault();
                db.MusicList.Remove(music);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {   
                MusicList musicList = new MusicList { MusicID = id, UserID = userInfo.UserID , IsDelete=true };

                db.MusicList.Add(musicList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}