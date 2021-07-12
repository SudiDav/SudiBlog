using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace SudiBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} charaters.", MinimumLength = 3)]
        [Display(Name = "Commment")]
        public string Body { get; set; }
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} charaters.", MinimumLength = 3)]
        [Display(Name = "Moderated Commment")]
        public string ModeratedBody { get; set; }

        // Navigation properties
        public virtual Post Post { get; set; }
        public virtual IdentityUser Author { get; set; }
        public virtual IdentityUser Moderator { get; set; }
    }
}
