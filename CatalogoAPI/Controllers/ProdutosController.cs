using CatalogoAPI.Context;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Controllers
{
    [Route("[Controller]")]
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
                return NotFound();
            }
            return produtos;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p=> p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created();
        }

    }
}
