using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using testStartup.Data;
using testStartup.Models;

namespace testStartup.Repositorio
{
    public class RepositorioProduto{

        public readonly DataContext _dataContext;

        public RepositorioProduto(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Produto> GetTodosOsProdutos()
        {
           // IQueryable<Produto> query = _dataContext.Produto;
               
           // query = query.AsNoTracking().OrderBy(p => p.Id);
           
           var produtos = _dataContext.Produto;
            return produtos;
        }
    }
}