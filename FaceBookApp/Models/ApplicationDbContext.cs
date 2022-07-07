using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FaceBookApp.Models
{   
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasKey(f => new { f.userId, f.friendId });

            modelBuilder.Entity<UserRequest>().HasKey(r => new { r.userId, r.requestId });

            modelBuilder.Entity<Like>().HasKey(l => new { l.userId, l.postId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
  





    }


}