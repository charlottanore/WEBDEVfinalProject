using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SD208.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Showusers()
        {
            friendsEntities fe = new friendsEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }
        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["FirstName"];
            String lastName = fc["LastName"];
            String email = fc["Email"];
            String diko = fc["Password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.roleID = 1;

            friendsEntities fe = new friendsEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("ShowUsers");
        }


        [HttpPost]
        public ActionResult Edit(int id)
        {
            int x = id;


            friendsEntities user = new friendsEntities();

            var selectedUser = (from a in user.users where a.userID == x select a).ToList();


            ViewData["User"] = selectedUser;

            return View();
            //  return RedirectToAction("UserUpdate");  // Redirect to the appropriate action or view
        }
        public ActionResult Update(FormCollection fc, int id)
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userID == id
                      select a).FirstOrDefault();

            String new_first_name = fc["new_firstname"];
            String new_last_name = fc["new_lastname"];
            String new_email = fc["new_email"];
            String new_password = fc["new_password"];

            u.firstname = new_first_name;
            u.lastname = new_last_name;
            u.email = new_email;
            u.password = new_password;

            rdbe.SaveChanges();

            return RedirectToAction("ShowUsers");
        }
        public ActionResult Delete(int id)
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userID == id
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return RedirectToAction("ShowUsers");
        }



    }
}