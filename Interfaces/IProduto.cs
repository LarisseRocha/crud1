using System.Collections.Generic;
using System.Threading.Tasks;
using testStartup.Models;

namespace teste_master.Interfaces
{
    public interface IProduto
    {
        Task<Produto> AddProdutoAsync(Produto model);
        Task<Produto> UpdateProdutoAsync(int produtoId, Produto model);
        Task<Produto> DeleteProdutoAsync(int produtoId);
        Task<ICollection<Produto>> GetAllProdutosAsync();
        Task<ICollection<Produto>> GetAllProdutosAsyncByNome( string nome);
        Task<Produto> GetProdutoAsyncById(int produtosId);
         
    }
}