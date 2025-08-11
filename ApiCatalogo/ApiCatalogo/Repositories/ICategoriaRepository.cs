using ApiCatalogo.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories;

public interface ICategoriaRepository : IRepository
{
    Task<Categoria?> GetCategoriaWithProdutos(int id);
}
