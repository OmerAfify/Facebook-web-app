using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceBookApp.Models;
using FaceBookApp.ViewModels;

namespace FaceBookApp.Controllers
{
    public class PostController : Controller
    {
        private DataBase_Services.DataBaseServices DB;

        public PostController()
        {
            DB = new DataBase_Services.DataBaseServices();
        }


        public ActionResult AddPost(int id) {

            var userPost = new PostandUserViewModel()
            {
                user = DB.fetchUserFromId(id)
                
            };

            return View(userPost);
        }   

        
        [HttpPost]
        public ActionResult PublishPost(Post post)
        {
            DB.CreatePost(post);
            return RedirectToAction("Profile","User",new { id = post.userId });
        }


        [HttpPost]
        public void HideOrViewPost(int id, bool hidden)
        {
            var post = DB.FetchPostFromId(id);

            if (hidden)
                DB.UnHidePost(post);
            else
                DB.HidePost(post);

        }


        [HttpPost]
        public void AddComment(int user, int thepost, string comment)
        {
            var dbuser = DB.fetchUserFromId(user);
            var dbpost = DB.FetchPostFromId(thepost);

            var NewComment = new Comment()
            {
                postId = thepost,
                post = dbpost,
                User = dbuser,
                userId = thepost,
                text = comment
            };

            DB.CreateComment(NewComment, dbpost);

        }

      

        [HttpPost]
        public void AddLike(int user, int thepost)
        {
            var dbuser = DB.fetchUserFromId(user);
            var dbpost = DB.FetchPostFromId(thepost);


            if (DB.IsLiked(user,thepost) == true)
            {
                return;
            }

            DB.AddLikeToPost(dbpost, dbuser);


        }

     

        [HttpPost]
        public void RemoveLike(int user, int thepost) {

            if (DB.IsLiked(user, thepost) == true) {


            var Like = DB.FindLikedPost(user,thepost);
            var dbpost = DB.FetchPostFromId(thepost);

                DB.RemoveLikeFromPost(Like,dbpost);

            }

        }

      


    }
}