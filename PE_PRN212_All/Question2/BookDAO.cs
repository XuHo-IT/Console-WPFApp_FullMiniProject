using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class BookDAO
    {
        private static BookDAO? instance = null;
        private static readonly object instanceLock = new object();
        private PePrn24fallB1Context _context;

        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }


        private BookDAO() { }


        public List<Book> GetAllRoomInformation()
        {
            using (var _context = new PePrn24fallB1Context())
            {
                return _context.Books.ToList();
            }
        }
        public void UpdateBook(Book book)
        {
            using (var context = new PePrn24fallB1Context())
            {
                context.Books.Update(book);
                context.SaveChanges();
            }
        }
    }
}
