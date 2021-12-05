using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste_master.Interfaces;
using testStartup.Data;
using testStartup.Models;

namespace testStartup.Repositorio
{
    public class RepositorioProduto : IProduto{

        public readonly DataContext _dataContext;

        public RepositorioProduto(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Produto> AddProdutoAsync(Produto model)
        {
              await _dataContext.AddAsync(model);
              _dataContext.SaveChanges();
              return model;
        }

        public async Task<Produto> DeleteProdutoAsync(int produtoId)
        {
           var produto = await _dataContext.Produto.FindAsync(produtoId);
            _dataContext.Produto.Remove(produto);
            _dataContext.SaveChanges();
            return produto;
        }

        public async Task<ICollection<Produto>> GetAllProdutosAsync()
        {
             var listaProduto =  await _dataContext.Produto.ToListAsync();
             return listaProduto;
        }

        public async Task<ICollection<Produto>> GetAllProdutosAsyncByNome(string nome)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Produto> GetProdutoAsyncById(int id)
        {
            var produto = await _dataContext.Produto.FindAsync(id);
            return produto;
        }

        public async Task<Produto> UpdateProdutoAsync(int produtoId, Produto model)
        {
             var produtoAchado = await _dataContext.Produto.FindAsync(produtoId);  
            produtoAchado.Descricao = model.Descricao;
            produtoAchado.Preco = model.Preco;
            _dataContext.Produto.Update(produtoAchado);
            _dataContext.SaveChanges();
            return produtoAchado;
        }
    }
}