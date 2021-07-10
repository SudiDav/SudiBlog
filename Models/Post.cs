using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudiBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string AutorId { get; set; }
        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 3)]
        public string Abstract { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [Display(Name = "Updated Date")]
        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; }
        public bool IsReady { get; set; }
        public string Slug { get; set; }
        public byte[] ImageData { get; set; }
        [Display(Name = "Image Type")]
        public string COntentType { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
