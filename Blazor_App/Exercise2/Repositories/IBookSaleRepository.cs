using Exercise2.Data;

namespace Exercise2.Repositories;

public interface IBookSaleRepository{
    Task AddNewSale(Booksale booksale);
}