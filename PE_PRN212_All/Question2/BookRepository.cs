using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class BookRepository
    {
        public List<Book> GetAllRoomInformation() => BookDAO.Instance.GetAllRoomInformation();
        public void UpdateBook(Book book) => BookDAO.Instance.UpdateBook(book);

    }
}
