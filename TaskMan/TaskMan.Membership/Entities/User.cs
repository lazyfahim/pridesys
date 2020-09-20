using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TaskMan.Data;

namespace TaskMan.Membership.Entities
{
    public class User : IdentityUser<int>, IEntity<int>
    {
        // New Properties added for user
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime JoinedDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }

        public string ProfilePicture { get; set; }

        public User() : base()
        {
            this.JoinedDate = DateTime.UtcNow;
        }

        public User(string username) : base(username)
        {
            this.JoinedDate = DateTime.UtcNow;

        }

        public User(string username, string email) : base(username)
        {
            this.Email = email;
            this.JoinedDate = DateTime.UtcNow;
        }
    }
}