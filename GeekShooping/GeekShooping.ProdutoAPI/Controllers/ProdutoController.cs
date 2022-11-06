using GeekShooping.ProdutoAPI.Data.ValueObjects;
using GeekShooping.ProdutoAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProdutoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoVO>> FindById(long id)
        {
            var produto = await _repository.FindById(id);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> FindAll()
        {
            var produtos = await _repository.FindAll();
            return Ok(produtos);
        }
    }
}
