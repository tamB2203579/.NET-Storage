using System.ComponentModel;
using Exercise2.Data;

namespace Exercise2.Repositories;

public class BookSaleRepository : IBookSaleRepository{
  BooksalesContext context;
  public BookSaleRepository(BooksalesContext context){
    this.context = context;
  }
  public async Task AddNewSale(Booksale booksale){
    this.context.Add(booksale);
    this.context.SaveChangesAsync();
  }
}