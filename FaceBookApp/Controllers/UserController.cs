using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceBookApp.Models;
using FaceBookApp.ViewModels;



namespace FaceBookApp.Controllers
{
    [System.Runtime.InteropServices.Guid("3E19AFC9-CEC9-4191-B0BF-F8F62E1901B5")]
    public class UserController : Controller
    {
        private DataBase_Services.DataBaseServices DB;


        public UserController()
        {
            DB = new DataBase_Services.DataBaseServices();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var dbuser = DB.FetchUserByEmailandPassword(user.email, user.password);
            if (dbuser == null) {
                ViewBag.ErrorMessage = "Unavailable user, PLease make sure you entered the username and password correctly";
                return View("Login");
            }
            else
            {
                return RedirectToAction("Profile", "User", new { id = dbuser.id });
            }


        }

    
        public ActionResult CreateAccount()
        {
            var user = new User();

            return View("AccountForm",user);
        }

        [HttpPost]
        public ActionResult SaveAccount(User user , HttpPostedFileBase file)
        {

            if(!ModelState.IsValid){

                return View("AccountForm",user);
            }
            
            
            
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/ProfilePictures/"), pic);
                file.SaveAs(path);
                user.profileImage = pic;
            }
            else
            {
                user.profileImage = "DefaultProfilePicture.jpg";
            }


            if (user.id == 0) { //new user
                DB.AddUser(user);
            }
            else{ // user clicking edit profile

                var dbUser = DB.fetchUserFromId(user.id);
                DB.UpdateUserData(dbUser, user);
            }

            return RedirectToAction("Profile", "User", new { id = user.id });
        }

      

        public ActionResult Edit(int id)
        {
            var dbUser = DB.fetchUserFromId(id);
            if (dbUser == null)
                return HttpNotFound();
            else {
                User user = dbUser;
                return View("AccountForm",user);
            }
        }


        public ActionResult Profile(int id)
        {
            var user = DB.fetchUserFromId(id);
            var freindsposts = DB.fetchFriendsPosts(id).ToList();

            var usersFriendsPostsViewModel = new UserPostsViewModel()
            {
                user = user,
                posts = freindsposts
            };


            return View(usersFriendsPostsViewModel);
        }


        public ActionResult MyProfilePage(int id)
        {
            var posts = DB.fetchPosts(id).ToList();
            var user = DB.fetchUserFromId(id);

            var usersOwnPostsViewModel = new UserPostsViewModel()
            {
                user = user,
                posts = posts
            };

            if (usersOwnPostsViewModel.user == null)
                return HttpNotFound();

            return View(usersOwnPostsViewModel);
        }


        public ActionResult FreindsPage(int id)
        {
            var userFriends = new UserFreindsViewModel()
            {
                user = DB.fetchUserFromId(id),
                friends = DB.fetchUsersFriendsAccounts(id).ToList()

            };
            return View(userFriends);
        }


        public ActionResult FindFreinds(int id)
        {
            var vm = new UserFreindsViewModel()
            {
                user = DB.fetchUserFromId(id),
                friends = DB.fetchNonFriendsUsersAccounts(id).ToList()
            };

            return View(vm);

        }


        public ActionResult ShowRequests(int id)
        {
            var requestedAccounts = DB.fetchRequestedAccounts(id);

            var requestedAccountsViewModel = new UserFreindsViewModel() //same view model that shows freinds is used here to show non freinds 
            {
                user = DB.fetchUserFromId(id),
                friends = requestedAccounts

            };

            return View(requestedAccountsViewModel);

        }



        [HttpPost]
        public void SendFriendRequest(int id, int r_user)
        {

            if (DB.IsRequestedFromBefore(id, r_user) == true)
                return;

            if (DB.IsRequestedFromBefore(r_user, id) == true)
                return;

            DB.AddFriendRequest(id ,r_user);

        }


        [HttpPost]
        public void RespondToFriendRequest(int id, int r_user, bool accept)
        {
            var req = DB.FetchRequest(id,r_user);

            DB.RemoveRequest(req);

            if (accept)
            {
                DB.AddFriends(id, r_user);
            }
          
        }




    }
}