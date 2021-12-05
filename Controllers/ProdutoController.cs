using Microsoft.AspNetCore.Mvc;
using testStartup.Models;
using testStartup.Data;
using testStartup.Repositorio;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testStartup.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ProdutoController : ControllerBase
    {
        private DataContext _context;
        //private RepositorioProduto _repositorioProduto;
        //private readonly IMapper _mapper;
    
        public ProdutoController(
            DataContext context)
        {
            _context = context;
           // _repositorioProduto = repositorioProduto;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduct()
        {
            var produto =  await _context.Produto.ToListAsync();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromForm] Produto model)
        {
              _context.Add(model);
              _context.SaveChanges();
              return Ok(model);
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            return Ok(produto);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> Update(int id, Produto produto)
        {
            var produtoAchado = await _context.Produto.FindAsync(id);  
            //produtoAchado = produto;
            produtoAchado.Descricao = produto.Descricao;
            produtoAchado.Preco = produto.Preco;
            _context.Produto.Update(produtoAchado);
            _context.SaveChanges();
            return Ok(produtoAchado);
        }
       
    }
}

