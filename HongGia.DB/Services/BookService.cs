using System;
using System.Collections.Generic;
using System.Linq;

using HongGia.Core.Interfaces.Base;
using HongGia.Core.Interfaces.Models;
using HongGia.Core.Models.Views;

using HongGia.DB.Models;

namespace HongGia.DB.Services
{
    public class BookService
    {
        public static IBooksView GetAllBookFiles()
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files == null || 
					context.Files.Any() == false ||
                    context.Catigories.Any(x => x.Type.ToLower() == "book") == false)
                {
                    return null;
                }

                var books = new List<Core.Models.Base.Book>();

                foreach (var book in context.Files)
                {
                    if (book.Catigories.Any(x => x.Type == "book"))
                    {
                        books.Add(new Core.Models.Base.Book()
                        {
                            Id = book.Id,
                            Header = book.Name,
                            Name = book.Name,
                            Path = book.Path
                        });
                    }
                }

                var allBookFiles = new BooksView()
                {
                    AllBooks = books
                };

                return allBookFiles;
            }
        }

        public static bool AddBook(IBook book)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files == null || 
					context.Files.Count() < 0 ||
                    context.Catigories.Any(x => x.Type.ToLower() == "book") == false)
                {
                    return false;
                }
                
                var selectCatigories = CatigoryService.GetCatigoriesByType("book");

                var save = new File()
                {
                    Name = book.Name,
                    Path = book.Path,
                    Date = DateTime.Now
                };

				foreach (var cat in selectCatigories)
				{
					save.Catigories.Add(cat);
					context.Catigories.Attach(cat);
				}
				context.Files.Add(save);

				context.SaveChanges();

                return true;
            }
        }

        public static bool RemoveBook(int bookId)
        {
            using (var context = new EntitiesDB())
            {
                if (context.Files.Any() == false)
                {
                    return false;
                }

                var selectBook = context.Files.FirstOrDefault(f => f.Id == bookId);

                if (selectBook == null)
                {
                    return false;
                }
                
                context.Files.Remove(selectBook);
                context.SaveChanges();

                return true;
            }
        }
    }
}
