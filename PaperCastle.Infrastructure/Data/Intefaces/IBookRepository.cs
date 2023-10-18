using PaperCastle.Core.Entity;
namespace PaperCastle.Infrastructure.Data.Intefaces
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetBooksAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetBookByTitleAsync(string title);
        Task<decimal> GetBookRatingAsync(int bookId);
        Task CreateAsync(Book book);
        bool BookExists(int id);
        Task UpdateAsync(int id, Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
    }
}
