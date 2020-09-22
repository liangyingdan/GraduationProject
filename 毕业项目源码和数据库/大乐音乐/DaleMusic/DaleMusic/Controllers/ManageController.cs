using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DaleMusic.Models;
using PagedList;

namespace DaleMusic.Controllers
{
    public class ManageController : Controller
    {
        DaYueDBEntities db = new DaYueDBEntities();
        // GET: Manage
        //用户列表
        public ActionResult Index(int? page = null,string UserName = "")
        {
            List<UserInfo> answers = db.UserInfo.Where(p => UserName == "" || p.UserName.Contains(UserName)).OrderByDescending(p => p.UserID).ToList();
            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;

            //每页显示多少条
            int pageSize = 4;

            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<UserInfo> answerPagedList = answers.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //新增用户
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        //用户详情
        public ActionResult Details(int? id)
        {
            UserInfo userInfo = db.UserInfo.Find(id);
            return View(userInfo);
        }


        //音乐列表
        public ActionResult MusicManage(int? page = null, string MusicName = "")
        {
            List<Music> answers = db.Music.Where(p => MusicName == "" || p.MusicName.Contains(MusicName)).OrderByDescending(p => p.MusicID).ToList();

            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;

            //每页显示多少条
            int pageSize = 4;

            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<Music> answerPagedList = answers.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //新增音乐
        public ActionResult MusicCreat()
        {
            List<Music> music = db.Music.ToList();
            ViewBag.singer = db.Singer.ToList();
            ViewBag.musictype = db.MusicType.ToList();
            return View(music);
        }
        [HttpPost]
        //判断上传文件是否为空
        public ActionResult MusicCreat(Music music, HttpPostedFileBase MusicImage, HttpPostedFileBase MusicFiles)
        {
            if (MusicImage != null)
            {
                //判断文件大小
                if (MusicImage.ContentLength > 0 && MusicImage.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string PhotofileName = Path.GetFileName(MusicImage.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string Photosuff = Path.GetExtension(PhotofileName);


                    //判断文件格式
                    if (Photosuff == ".gif" || Photosuff == ".jpg" || Photosuff == ".png")
                    {
                        //保存上传文件的路径
                        MusicImage.SaveAs(Server.MapPath("~/Content/images/" + MusicImage.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = MusicImage.FileName;
                        //存入数据库字段中
                        music.MusicImage = MusicImage.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            if (MusicFiles != null)
            {
                //判断文件大小
                if (MusicFiles.ContentLength > 0 && MusicFiles.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string MusicfileName = Path.GetFileName(MusicFiles.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string Musicsuff = Path.GetExtension(MusicfileName);

                    music.MusicFiles = "~/Content/音频/" + MusicFiles.FileName;
                    //判断文件格式
                    if (Musicsuff == ".mp3")
                    {
                        //保存上传文件的路径
                        MusicFiles.SaveAs(Server.MapPath("~/Content/音频/" + MusicFiles.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = MusicFiles.FileName;
                        //存入数据库字段中
                        music.MusicFiles = MusicFiles.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            db.Music.Add(music);
            db.SaveChanges();
            return RedirectToAction("MusicManage");
        }
        //编辑音乐
        public ActionResult MusicDetails(int? id)
        {
            Music music = db.Music.Find(id);
            ViewBag.singer = db.Singer.ToList();
            ViewBag.musictype = db.MusicType.ToList();
            return View(music);
        }
        [HttpPost]
        public ActionResult MusicDetails(Music music, HttpPostedFileBase MusicImage, HttpPostedFileBase MusicFiles)
        {
            if (MusicImage != null)
            {
                //判断文件大小
                if (MusicImage.ContentLength > 0 && MusicImage.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string fileName = Path.GetFileName(MusicImage.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string suff = Path.GetExtension(fileName);
                    //判断文件格式
                    if (suff == ".gif" || suff == ".jpg" || suff == ".png")
                    {
                        //保存上传文件的路径
                        MusicImage.SaveAs(Server.MapPath("~/Content/images/" + MusicImage.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = MusicImage.FileName;
                        //存入数据库字段中
                        music.MusicImage = MusicImage.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            if (MusicFiles != null)
            {
                //判断文件大小
                if (MusicFiles.ContentLength > 0 && MusicFiles.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string fileName = Path.GetFileName(MusicFiles.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string suff = Path.GetExtension(fileName);
                    music.MusicFiles = "~/Content/音频/" + MusicFiles.FileName;
                    //判断文件格式
                    if (suff == ".mp3")
                    {
                        //保存上传文件的路径
                        MusicFiles.SaveAs(Server.MapPath("~/Content/音频/" + MusicFiles.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = MusicFiles.FileName;
                        //存入数据库字段中
                        music.MusicFiles = MusicFiles.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            db.Entry(music).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MusicManage");
        }
        //删除音乐
        public ActionResult MusicDelete(int id)
        {
            db.Music.Find(id).IsDelete = false;
            db.SaveChanges();
            return RedirectToAction("MusicManage");
        }
        //恢复音乐
        public ActionResult MusicIsDelete(int id)
        {
            db.Music.Find(id).IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("MusicManage");
        }



        //歌手列表
        public ActionResult SingerManage(int? page = null, string SingerName = "")
        {
            List<Singer> answers = db.Singer.Where(p => SingerName == "" || p.SingerName.Contains(SingerName)).OrderByDescending(p => p.SingerID).ToList();
            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;
            //每页显示多少条
            int pageSize = 4;
            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<Singer> answerPagedList = answers.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //新增歌手
        public ActionResult SingerCreat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SingerCreat(Singer singer, HttpPostedFileBase file)
        {
            if (file!= null)
            {
                //判断文件大小
                if (file.ContentLength > 0 && file.ContentLength < 4194304)
                {
                    //获取上传文件路径
                    string fileName = Path.GetFileName(file.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string suff = Path.GetExtension(fileName);
                    //判断文件格式
                    if (suff == ".gif" || suff == ".jpg" || suff == ".png")
                    {
                        //保存上传文件的路径
                        file.SaveAs(Server.MapPath("~/Content/歌手图片/" + file.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = file.FileName;
                        //存入数据库字段中
                        singer.SingerImage = file.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }

            db.Singer.Add(singer);
            db.SaveChanges();
            return RedirectToAction("SingerManage");
        }

        //修改歌手
        public ActionResult SingerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singer = db.Singer.Find(id);
            if (singer == null)
            {
                return HttpNotFound();
            }
            return View(singer);
        }
        [HttpPost]
        public ActionResult SingerEdit([Bind(Include = "SingerID,SingerName,SingerType,SingerImage")] Singer singer, HttpPostedFileBase file)
        {
            if (file != null)
            {
                //判断文件大小
                if (file.ContentLength > 0 && file.ContentLength < 4194304)
                {

                    //获取上传文件路径
                    string fileName = Path.GetFileName(file.FileName);
                    //获取文件后缀名【两种方式-------截取==jpg，，，GetExtension== .jpg】
                    //string suff = fileName.Substring(fileName.LastIndexOf(".")+1);
                    string suff = Path.GetExtension(fileName);


                    //判断文件格式
                    if (suff == ".gif" || suff == ".jpg" || suff == ".png")
                    {
                        //保存上传文件的路径
                        file.SaveAs(Server.MapPath("~/Content/歌手图片/" + file.FileName));
                        //获取上传文件名，用于后期拿图片
                        ViewBag.img = file.FileName;
                        //存入数据库字段中
                        singer.SingerImage = file.FileName;
                    }
                    else
                    {
                        ViewBag.Message = "文件格式不正确！";
                    }
                }
                else
                {
                    ViewBag.Message = "文件大小不符合要求！";
                }
            }
            else
            {
                ViewBag.Message = "请上传文件！";
            }
            singer.SingerImage = file.FileName.ToString();
            db.Entry(singer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("SingerManage");

        }
        //删除歌手
        public ActionResult SingerDelete(int? id)
        {
            List<Singer> singer = db.Singer.Where(p => p.SingerID == id).ToList();
            if (singer.Count > 0)
            {
                return Content("<script>alert('请解除该歌手的音乐绑定，再删除该歌手');history.back(-1);</script>");
            }
            else
            {
                var user = db.Singer.Find(id);
                db.Singer.Remove(user);
                db.SaveChanges();              
            }
            return RedirectToAction("SingerManage");
        }


        //音乐类型列表
        public ActionResult MusicTypeManage(int? page = null, string TypeName = "")
        {
            List<MusicType> answers = db.MusicType.Where(p => TypeName == "" || p.TypeName.Contains(TypeName)).OrderByDescending(p => p.TypeID).ToList();

            //当前页码  
            // ?? 空合并运算符，用于为可为空的值类型和引用类型定义默认值。
            //如果不为空，则返回左侧操作数；否则返回右侧操作数。
            int pageNum = page ?? 1;

            //每页显示多少条
            int pageSize = 4;

            //通过ToPagedList扩展方法进行分页
            //参数：当前页、每页显示的页数
            IPagedList<MusicType> answerPagedList = answers.ToPagedList(pageNum, pageSize);
            return View(answerPagedList);
        }
        //新增音乐类型
        public ActionResult MusicTypeCreat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusicTypeCreat(MusicType musicType)
        {
            if (ModelState.IsValid)
            {
                db.MusicType.Add(musicType);
                db.SaveChanges();
                return RedirectToAction("MusicTypeManage");
            }
            else
            {
                return View();
            }
        }
        //删除音乐类型
        public ActionResult MusicTypeDelete(int? id)
        {
            List<MusicType> musicTypes = db.MusicType.Where(p => p.TypeID == id).ToList();
            if (musicTypes.Count > 0)
            {
                return Content("<script>alert('请解除该类型的音乐绑定，再删除该类型');history.back(-1);</script>");
            }
            else
            {
                var user = db.Singer.Find(id);
                db.Singer.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("MusicTypeManage");
        }
    }
}