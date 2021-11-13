using SudiBlog.Models;
using System.Collections.Generic;

namespace SudiBlog.ViewModels
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
