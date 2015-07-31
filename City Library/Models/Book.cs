using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace City_Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [DisplayName("Название книги")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }

        
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        
        public int BookSeriesId { get; set; }
        public virtual BookSeries BookSeries { get; set; }

       
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        
    }
}