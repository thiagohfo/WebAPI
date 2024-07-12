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
    }
}