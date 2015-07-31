using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Threading;

using City_Library.Models;

namespace City_Library.Context
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookSeries> BookSeries { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }


        public BookContext()
        {
            if (!Authors.Any())
            {
                Author author1 = new Author { Name = "Симмонс Дэн", Description = "Американский писатель фантаст" };
                Author author2 = new Author { Name = "Холдеман Джо", Description = "Американский писатель фантаст" };
                Author author3 = new Author { Name = "Исуна Хасэкура", Description = "Японский писатель" };
                Author author4 = new Author { Name = "Железяны Роджер", Description = "Американский писатель фантаст" };
                Author author5 = new Author { Name = "Кларк Артур", Description = "Aнглийский писатель, учёный, футуролог и изобретатель" };
                Authors.Add(author1);
                Authors.Add(author2);
                Authors.Add(author3);
                Authors.Add(author4);
                Authors.Add(author5);
                SaveChanges();
            }

            if (!BookSeries.Any())
            {
                BookSeries bookSeries1 = new BookSeries { Name = "Дэн Симмонс. Собрание сочинений", Description = "Год открытия: 2012 (Серия закрыта)" };
                BookSeries bookSeries2 = new BookSeries { Name = "Фантастика", Description = "Искусство воображения, фантазия" };
                BookSeries bookSeries3 = new BookSeries { Name = "Фэнтези", Description = "Жанр фантастической литературы, основанный на использовании мифологических и сказочных мотивов." };
                BookSeries.Add(bookSeries1);
                BookSeries.Add(bookSeries2);
                BookSeries.Add(bookSeries3);
                SaveChanges();
            }

            if (!Publishers.Any())
            {
                Publisher publisher1 = new Publisher { Name = "Флибуста", Description = "Бесплатная некоммерческая онлайн-библиотека." };
                Publisher publisher2 = new Publisher { Name = "Либрусек", Description = "Веб-сайт, предоставляющий пользователям возможность читать и скачивать тексты книг, в том числе защищённых авторским правом" };
                Publisher publisher3 = new Publisher { Name = "O’Reilly Media", Description = "Американская издательская компания, основанная Тимом О’Райли в 1978 году. Публикует книги компьютерной тематики" };
                Publisher publisher4 = new Publisher { Name = "Apress", Description = "Одно из крупнейших издательств, занимающееся выпуском книг по информационным технологиям" };
                Publishers.Add(publisher1);
                Publishers.Add(publisher2);
                Publishers.Add(publisher3);
                Publishers.Add(publisher4);
                SaveChanges();
            }

            

            if (!Books.Any())
            {
                Book book1 = new Book { Name = "Фонтаны рая", Description = "Сам Кларк считал этот роман своим лучшим произведением.", 
                    AuthorId = 5, BookSeriesId = 2, PublisherId = 1 };
                Book book2 = new Book { Name = "Гиперион", Description = "Первая книга тетралогии «Песни Гипериона».", 
                    AuthorId = 1, BookSeriesId = 1, PublisherId = 1 };
                Book book3 = new Book { Name = "Волчица и пряности", Description = "Популярная японская серия «лайт-новел»", 
                    AuthorId = 3, BookSeriesId = 3, PublisherId = 2 };
                Book book4 = new Book { Name = "Бесконечная война", Description = "Самый известный роман американского писателя Джо Холдемана.", 
                    AuthorId = 2, BookSeriesId = 2, PublisherId = 1 };
                Book book5 = new Book { Name = "Падение Гипериона ", Description = "Вторая книга тетралогии «Песни Гипериона», продолжение романа «Гиперион». ", 
                    AuthorId = 1, BookSeriesId = 1, PublisherId = 2 };
                Book book6 = new Book { Name = "Девять принцев Амбера", Description = "Первая книга из первой пенталогии цикла романов «Хроники Амбера».", 
                    AuthorId = 4, BookSeriesId = 3, PublisherId = 1 };
                Book book7 = new Book { Name = "Звёздный десант", Description = "Несмотря на увлекательный сюжет, в романе обсуждается ряд серьёзных политических и социальных вопросов.", 
                    AuthorId = '2', BookSeriesId = '2', PublisherId = '1' };
                Books.Add(book1);
                Books.Add(book2);
                Books.Add(book3);
                Books.Add(book4);
                Books.Add(book5);
                Books.Add(book6);               
                SaveChanges();

                Thread.Sleep(100); // Задержка для правильного отображения стартовой страницы
                                   // без нее при первом запуске столбцы Автор, Серия, Издательство не отображаются до обновления страницы
                
            }
                
           

            

        }
    }

}