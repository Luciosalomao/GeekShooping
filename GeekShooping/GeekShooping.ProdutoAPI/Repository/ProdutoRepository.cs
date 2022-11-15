using AutoMapper;
using GeekShooping.ProdutoAPI.Data.ValueObjects;
using GeekShooping.ProdutoAPI.Model;
using GeekShooping.ProdutoAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProdutoAPI.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SQLServerContext _context;
        private IMapper _mapper;

        public ProdutoRepository(SQLServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoVO>> FindAll()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();
            return _mapper.Map<List<ProdutoVO>>(produtos);
        }

        public async Task<ProdutoVO> FindById(long Id)
        {
            Produto produto = await _context.Produtos.Where(p => p.Id == Id).FirstOrDefaultAsync() ?? new Produto();
            return _mapper.Map<ProdutoVO>(produto);
        }

        public async Task<ProdutoVO> Create(ProdutoVO VO)
        {
            Produto produto = _mapper.Map<Produto>(VO);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }
        public async Task<ProdutoVO> Update(ProdutoVO VO)
        {
            Produto produto = _mapper.Map<Produto>(VO);
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoVO>(produto);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Produto produto = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Produto();
                if (produto.Id <= 0) return false;
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception)
            {
                return false;
            }
        }
    }
}
