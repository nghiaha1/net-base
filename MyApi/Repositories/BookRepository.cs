using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Models;

namespace MyApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreContext _context;
    private readonly IMapper _mapper;

    public BookRepository(BookStoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<BookModel>> GetAllBookAsync()
    {
        var books = await _context.Books!.ToListAsync();
        return _mapper.Map<List<BookModel>>(books);
    }

    public async Task<BookModel> GetBookAsync(int id)
    {
        var book = await _context.Books!.FindAsync(id);
        return _mapper.Map<BookModel>(book);
    }

    public async Task<int> AddBookAsync(BookModel model)
    {
        var newBook = _mapper.Map<Book>(model);
        _context.Books!.Add(newBook);
        await _context.SaveChangesAsync();
        return newBook.Id;
    }

    public async Task UpdateBookAsync(int id, BookModel model)
    {
        if (id == model.Id)
        {
            var book = _mapper.Map<Book>(model);
            _context.Books!.Update(book);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = _context.Books!.SingleOrDefault(b => id == b.Id);
        if (book != null)
        {
            _context.Books!.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}