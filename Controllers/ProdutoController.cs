using Microsoft.AspNetCore.Mvc;
using testStartup.Models;
using testStartup.Data;
using testStartup.Repositorio;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste_master.Interfaces;
using Microsoft.AspNetCore.Http;

namespace testStartup.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ProdutoController : ControllerBase
    {
        private IProduto _repositorioProduto;
        //private readonly IMapper _mapper;
    
        public ProdutoController(IProduto repositorioProduto)
        {
           
            _repositorioProduto = repositorioProduto;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduct()
        {
            
            try
            {
                var listaProduto =  await _repositorioProduto.GetAllProdutosAsync();
                return Ok(listaProduto);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter so produtos. Erro: {exeption.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromForm] Produto model)
        {
              await _repositorioProduto.AddProdutoAsync(model);
              return Ok(model);
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _repositorioProduto.GetProdutoAsyncById(id);
            return Ok(produto);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             try
            {
                var produto =  await _repositorioProduto.DeleteProdutoAsync(id);
                if(produto == null){

                    throw new InvalidOperationException("Produto com esse ID não existe!");  
                }
                return Ok("Produto deletado com sucesso");
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter so produtos. Erro: {exeption.Message}");
            }
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> Update(int id, Produto produto)
        {
           // var produtoAntes = _repositorioProduto.GetProdutoAsyncById(id);
            var produtoAchado = await _repositorioProduto.UpdateProdutoAsync(id, produto);
            return Ok(produtoAchado);
        }
       
    }
}

