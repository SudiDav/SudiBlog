﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SudiBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and more than {1} characters long.", MinimumLength = 3)]
        public string Text { get; set; }
        public virtual Post Post { get; set; }
        public virtual IdentityUser Author { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}