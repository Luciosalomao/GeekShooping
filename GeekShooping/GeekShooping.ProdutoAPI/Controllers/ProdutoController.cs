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
            if (produto.Id <= 0) return NotFound();
            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> FindAll()
        {
            var produtos = await _repository.FindAll();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> Create([FromBody] ProdutoVO VO)
        {
            if (VO == null) return BadRequest();
            var produtos = await _repository.Create(VO);
            return Ok(produtos);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProdutoVO>>> Update([FromBody] ProdutoVO VO)
        {
            if (VO == null) return BadRequest();
            var produtos = await _repository.Update(VO);
            return Ok(produtos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoVO>> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return NoContent();
        }

    }
}
