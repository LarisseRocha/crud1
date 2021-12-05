using Microsoft.AspNetCore.Mvc;
using testStartup.Models;
using testStartup.Data;
using testStartup.Repositorio;
using System.Collections.Generic;
using System;
using System.Linq;

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
        public ActionResult<IEnumerable<Produto>> GetProduct()
        {
            return _context.Produto.ToList();
        }

        [HttpPost]
        public IActionResult CadastrarProduto([FromForm] Produto model)
        {
              _context.Add(model);
              _context.SaveChanges();
              return Ok(model);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _context.Produto.Find(id);
            return Ok(produto);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produto.Find(id);
            _context.Produto.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("{id}")]
         public IActionResult Update(int id, Produto produto)
        {
            var produtoAchado = _context.Produto.Find(id);  
            //produtoAchado = produto;
            produtoAchado.Descricao = produto.Descricao;
            produtoAchado.Preco = produto.Preco;
            _context.Produto.Update(produtoAchado);
            _context.SaveChanges();
            return Ok(produtoAchado);
        }
       
    }
}

