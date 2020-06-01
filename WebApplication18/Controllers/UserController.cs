using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Models;
using WebApplication18.ViewModel;

namespace WebApplication18.Controllers
{
    public class UserController : Controller
    {
        private brodenemeEntities1 db = new brodenemeEntities1();
        //Id kayıt alma Index sayfasında alınıyor.
        public static class GlobalVar
        {
            static string _globalValue;
            public static string UserId
            {
                get
                {
                    return _globalValue;
                }
                set
                {
                    _globalValue = value;
                }
            }
        }

        public ActionResult Login()
        {
            ViewBag.CheckMassage = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            var data = db.Users.ToList();

            //sql tarafına fonksiyon olarak göndermek daha iyi 
            /* var userControl = from item in data
                               where item.UserEmail == user.UserEmail && item.UserPassword == user.UserPassword
                               select item;*/

            // int check = db.Database.ExecuteSqlCommand("SELECT dbo.Login('admin','sifre')");
            //string query = "SELECT dbo.Login('admin','sifre')";
            //var check = LoginFunk("admin","sifre");

            if (ModelState.IsValid)
            {
                var query = "SELECT dbo.Login('"+user.UserName+"','"+user.UserPassword+"')";
                var check = db.Database.SqlQuery<int>(query).Single();
                if (1 == Convert.ToInt32(check))
                {
                    ViewBag.CheckMassage = "Şifre Doğru";
                }
                else
                {
                    ViewBag.CheckMassage = "Şifre Yanlış";
                }
            }
            return View(user);
        }
        // GET: User
        public ActionResult Index()
        {
            //linq
            var data = db.Users.ToList();
            List<UserViewModel> UserList = new List<UserViewModel>();
            foreach (var item in data)
            {
                UserViewModel model = new UserViewModel();
                model.UserEmail = item.UserEmail;
                model.UserName = item.UserName;
                model.UserPassword = item.UserPassword;
                //model.UserID = item.UserID;
                UserList.Add(model);
            }

            string mail = UserList[0].UserEmail;
            return View(UserList.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            UserViewModel user2 = new UserViewModel();
            //user2.UserID = user.UserID;
            user2.UserEmail = user.UserEmail;
            user2.UserName = user.UserName;
            user2.UserPassword = user.UserPassword;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                Users user2 = new Users();
                user2.UserEmail = user.UserEmail;
                user2.UserName = user.UserName;
                user2.UserPassword = user.UserPassword;
                db.Users.Add(user2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            UserViewModel user2 = new UserViewModel();
            //user2.UserID = user.UserID;
            user2.UserEmail = user.UserEmail;
            user2.UserName = user.UserName;
            user2.UserPassword = user.UserPassword;
            if(id==4)
            {
                ViewBag.kontrol = "Kontrol";
            }
            GlobalVar.UserId = id.ToString() ;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user2);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                Users user2 = new Users();
                //user2.UserID = Int32.Parse(GlobalVar.UserId);
                user2.UserEmail = user.UserEmail;
                user2.UserName = user.UserName;
                user2.UserPassword = user.UserPassword;
                db.Entry(user2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Users user = db.Users.Find(id);
            
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
