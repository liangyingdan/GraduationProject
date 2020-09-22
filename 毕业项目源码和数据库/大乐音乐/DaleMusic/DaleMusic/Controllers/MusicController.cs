using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaleMusic.Models;
using PagedList;

namespace DaleMusic.Controllers
{
    public class MusicController : Controller
    {
        DaYueDBEntities db = new DaYueDBEntities();
        // GET: Music
        public ActionResult Index(int? page = null, string MusicName = "")
        {
            List<Music> answers = db.Music.Where(p => MusicName == "" || p.MusicName.Contains(MusicName)).OrderByDescending(p => p.MusicID).ToList();
            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;
            //每页显示多少条
            int pageSize = 3;
            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<Music> answerPagedList = answers.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //歌曲详情
        public ActionResult Detail(int? id)
        {
            Music music = db.Music.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }
        //歌手筛选
        public ActionResult SingerIndex(int? page = null, string SingerName = "")
        {
            List<Singer> singer = db.Singer.Where(p => SingerName == "" || p.SingerName.Contains(SingerName)).OrderByDescending(p => p.SingerID).ToList();
            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;
            //每页显示多少条
            int pageSize = 3;
            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<Singer> answerPagedList = singer.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //歌手详情
        public ActionResult SingerDatail(int? id)
        {
            Singer singer = db.Singer.Find(id);
            return View(singer);
        }
        //分类歌单
        public ActionResult TypeIndex(int? page = null, string TypeName = "")
        {
            List<MusicType> musicTypes = db.MusicType.Where(p => TypeName == "" || p.TypeName.Contains(TypeName)).OrderByDescending(p => p.TypeID).ToList();
            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;
            //每页显示多少条
            int pageSize = 10;
            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<MusicType> answerPagedList = musicTypes.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //分类详情
        public ActionResult TypeDatail(int? id)
        {
            MusicType musicType = db.MusicType.Find(id);
            return View(musicType);
        }
        //音乐下载
        public ActionResult Down(string file)
        {
            var path = Server.MapPath("~/Content/音频/" + file);
            var name = System.IO.Path.GetFileName(path);
            return File(path, "application/x-zip-compressed", name);
        }
    }
}