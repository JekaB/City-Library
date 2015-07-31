using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace City_Library.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter autor name")]
        [DisplayName("Автор")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}