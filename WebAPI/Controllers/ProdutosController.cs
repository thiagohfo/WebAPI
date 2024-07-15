using WebAPI.Context;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();

            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
        
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]

        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            return produto;
        }
    }
}