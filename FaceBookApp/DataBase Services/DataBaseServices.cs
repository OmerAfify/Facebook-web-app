using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FaceBookApp.Models;
using System.Data.Entity;

namespace FaceBookApp.DataBase_Services
{
    public class DataBaseServices : Controller
    {
        private ApplicationDbContext _context;


        public DataBaseServices()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //DB User Services

        public User fetchUserFromId(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.id == id);
            return user;
        }

        public User FetchUserByEmailandPassword(string email, string password)
        {
            var dbuser = _context.Users.SingleOrDefault(du => du.email == email && du.password == password);
            return dbuser;
        }

        public List<User> FetchUsersByEmail(string email)
        {
            return _context.Users.Where(u => u.email == email).ToList();
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public void UpdateUserData(User OldUser, User NewUser)
        {
            OldUser.firstName = NewUser.firstName;
            OldUser.lastName = NewUser.lastName;
            OldUser.country = NewUser.country;
            OldUser.city = NewUser.city;
            OldUser.password = NewUser.password;
            OldUser.email = NewUser.email;
            OldUser.profileImage = NewUser.profileImage;

            _context.SaveChanges();

        }



        //DB Freinds requests Requests Services

        public UserRequest FetchRequest(int id, int requestedId)
        {
            return _context.UserRequests.Single(c => c.userId == requestedId && c.requestId == id);
        }

        public List<User> fetchRequestedAccounts(int id)
        {

            var requestfriendsids = _context.UserRequests.Where(c => c.requestId == id);
            var requestedAccounts = _context.Users.Where(u => requestfriendsids.Any(r => r.userId == u.id)).ToList();

            return requestedAccounts;
        }


        public bool IsRequestedFromBefore(int id, int requestedId)
        {
            if (_context.UserRequests.SingleOrDefault(u => u.userId == id && u.requestId == requestedId) != null)
                return true;
            else
                return false;
        }

        public void AddFriendRequest(int requestedto, int requestedfrom)
        {
            var userRequest = new UserRequest()
            {
                userId = requestedto,
                user = _context.Users.SingleOrDefault(u => u.id == requestedto),
                requestId = requestedfrom,
                request = _context.Users.SingleOrDefault(u => u.id == requestedfrom),
            };

            _context.UserRequests.Add(userRequest);
            _context.SaveChanges();

        }


        public void RemoveRequest(UserRequest userRequest)
        {
            _context.UserRequests.Attach(userRequest);
            _context.UserRequests.Remove(userRequest);
            _context.SaveChanges();
        }


        //DB Freinds Services

        public IEnumerable<UserFriend> fetchFriendsIds(int id)
        {
            var friendsIds = _context.UserFriends.Where(c => c.userId == id);
            return friendsIds;
        }

        public void AddFriends(int firstFriendId, int secondFriendId)
        {
            var user1FriUser2 = new UserFriend()
            {
                userId = firstFriendId,
                user = _context.Users.SingleOrDefault(u => u.id == firstFriendId),
                friendId = secondFriendId,
                friend = _context.Users.SingleOrDefault(u => u.id == secondFriendId),
            };

            var user2FriUser1 = new UserFriend()
            {
                userId = secondFriendId,
                user = _context.Users.SingleOrDefault(u => u.id == secondFriendId),
                friendId = firstFriendId,
                friend = _context.Users.SingleOrDefault(u => u.id == firstFriendId),
            };

            _context.UserFriends.Add(user1FriUser2);
            _context.UserFriends.Add(user2FriUser1);
            _context.SaveChanges();

        }

        public IEnumerable<User> fetchUsersFriendsAccounts(int id)
        {
            var friendsIds = fetchFriendsIds(id);
            var friendsAccounts = _context.Users.Where(p => friendsIds.Any(y => y.friendId == p.id)).ToList();

            return friendsAccounts;
        }

        public IEnumerable<User> fetchNonFriendsUsersAccounts(int id)
        {
            var friendsIds = fetchFriendsIds(id);
            var NonfriendsAccounts = _context.Users.Where(p => !friendsIds.Any(y => y.friendId == p.id) && p.id != id).ToList();

            var requests = _context.UserRequests.Where(c => c.userId == id);
            var requestedIds = _context.UserRequests.Where(c => c.requestId == id);

            var NonFreinds_list = _context.Users.Where(p =>
            !friendsIds.Any(y => y.friendId == p.id)
            && p.id != id
            && !requests.Any(y => y.requestId == p.id)
            && !requestedIds.Any(y => y.userId == p.id)
            ).ToList();

            return NonFreinds_list;

        }



        // DB Posts Services

        public Post FetchPostFromId(int postId)
        {
            return _context.Posts.SingleOrDefault(p => p.id == postId);
        }


        public IEnumerable<Post> fetchPosts(int id)
        {
            var posts = _context.Posts.Include(c => c.comments).Include(l => l.likes).Where(c => c.userId == id);
            return posts;
        }

        public IEnumerable<Post> fetchFriendsPosts(int id)
        {
            var friendsIds = fetchFriendsIds(id);
            var friendsPosts = _context.Posts
                               .Include(m => m.user).Include(c => c.comments).Include(l=>l.likes)
                               .Where(p => friendsIds.Any(y => y.friendId == p.userId) && p.hidden == false).ToList();

            return friendsPosts;
        }


        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }


        public void HidePost(Post post)
        {
            post.hidden = true;
            _context.SaveChanges();
        }


        public void UnHidePost(Post post)
        {
            post.hidden = false;
            _context.SaveChanges();
        }

        //DD Comments Services
        public void CreateComment(Comment comment, Post post)
        {
            _context.Comments.Add(comment);
            post.commentsNumber += 1;
            _context.SaveChanges();

        }


        //DB Likes Services
        public void AddLikeToPost(Post post, User user)
        {
            if (IsLiked(user.id, post.id) == true)
            {
                return;
            }

            var like = new Like
            {
                postId = post.id,
                post = post,
                user = user,
                userId = post.id,
            };

            post.likesNumber += 1;
            _context.Likes.Add(like);
            _context.SaveChanges();
        }


        public void RemoveLikeFromPost(Like like, Post post)
        {
            _context.Likes.Attach(like);
            _context.Likes.Remove(like);
            post.likesNumber -= 1;

            _context.SaveChanges();

        }

        public Like FindLikedPost(int userId, int postId)
        {
            var like = _context.Likes.SingleOrDefault(l => l.userId == userId && l.postId == postId);
            return like;
        }

        //DB
        public bool IsLiked(int user, int thepost)
        {
            var dbuser = _context.Users.SingleOrDefault(u => u.id == user);
            var dbpost = _context.Posts.SingleOrDefault(p => p.id == thepost);

            var Like = _context.Likes.SingleOrDefault(l => l.userId == user && l.postId == thepost);

            if (Like != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



















    }
}