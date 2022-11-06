using GeekShooping.ProdutoAPI.Data.ValueObjects;

namespace GeekShooping.ProdutoAPI.Repository
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoVO>> FindAll();
        Task<ProdutoVO> FindById(long Id);
        Task<ProdutoVO> Create(ProdutoVO VO);
        Task<ProdutoVO> Update(ProdutoVO VO);
        Task<bool> Delete(long id);
    }
}
