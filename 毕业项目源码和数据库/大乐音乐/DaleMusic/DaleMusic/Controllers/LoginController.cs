using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DaleMusic.Models;

namespace DaleMusic.Controllers
{
    public class LoginController : Controller
    {
        DaYueDBEntities db = new DaYueDBEntities();
        // GET: Login
        //用户登录
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(string UserName, string UserPwd)
        {
            UserInfo user = db.UserInfo.Where(p => p.UserName == UserName && p.UserPwd == UserPwd).FirstOrDefault();
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Music");

            }
            else
            {
                //不存在，返回登陆界面提示信息
                return Content("<script>alert('账号或密码不正确！');history.go(-1);</script>");
            }
        }
        //用户注册
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserRegister(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo.Add(user);
                db.SaveChanges();
                Session["user"] = user;
                return RedirectToAction("UserLogin");
            }
            else
            {
                return View();
            }
        }
        ////QQ邮箱验证
        //public ActionResult QQEmailCode(string Email)
        //{

        //    try
        //    {
        //        Session["yzm"] = randomnumber(length: 4);//随机数存入session
        //        MailMessage msg = new MailMessage(from: "2785164702@qq.com", to: Email, subject: "来到忘记密码",
        //            body: "任何工作人员不会向您询问验证码，请妥善保管！您的验证码是" + Session["yzm"]);
        //        SmtpClient client = new SmtpClient(host: "smtp.qq.com", port: 587);//QQ邮箱的服务器和端口号
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;//通过网络发送
        //        client.Credentials = new NetworkCredential(userName: "2785164702@qq.com", password: "fqcqatujharldfbd");//发送人的邮箱和密码 SMTP码
        //        client.Send(msg);
        //        string Smsg = "发送成功！";
        //        return RedirectToAction("StuForgetThePpassword", new { Smsg = Smsg, Email = Email });

        //    }
        //    catch (Exception)
        //    {
        //        string Smsg = "发送失败！";
        //        return RedirectToAction("StuForgetThePpassword");
        //    }
        //}

        ////生成随机验证码
        //public string randomnumber(int length)
        //{
        //    var result = new StringBuilder();
        //    for (int i = 0; i < length; i++)
        //    {
        //        var r = new Random(Seed: Guid.NewGuid().GetHashCode());
        //        result.Append(r.Next(0, 10));
        //    }
        //    return result.ToString();
        //}

        //用户退出登录
        public ActionResult UserLogout()
        {
            //点击注销按钮，清空 Session
            Session["user"] = null;
            //Session["stu"] = null;
            //跳转到登录界面
            return RedirectToAction("UserLogin");
        }
        //管理员登录
        public ActionResult ManageLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageLogin(string ManageAccount, string ManagePwd)
        {
            Manage manage = db.Manage.Where(p => p.ManageAccount == ManageAccount && p.ManagePwd == ManagePwd).FirstOrDefault();
            if (manage != null)
            {
                Session["manage"] = manage;
                return RedirectToAction("Index", "Manage");

            }
            else
            {
                //不存在，返回登陆界面提示信息
                return Content("<script>alert('账号或密码不正确！');history.go(-1);</script>");
            }
        }
        //管理员退出登录
        public ActionResult ManageLogout()
        {
            //点击注销按钮，清空 Session
            Session["manage"] = null;
            //Session["stu"] = null;
            //跳转到登录界面
            return RedirectToAction("ManageLogin");
        }
    }
}