using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum Length required is 2.")]
       public string Title { get; set; }

        [Required, MinLength(4, ErrorMessage = "Minimum Length required is 4")]
        public string Description { get; set; }
    }
}
