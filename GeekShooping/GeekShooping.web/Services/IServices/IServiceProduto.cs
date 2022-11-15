using GeekShooping.web.Models;

namespace GeekShooping.web.Services.IServices
{
    public interface IServiceProduto
    {
        Task<IEnumerable<ProdutoModel>> FindAllProdutos();
        Task<ProdutoModel> FindProdutoById(long id);
        Task<ProdutoModel> CreateProduto(ProdutoModel model);
        Task<ProdutoModel> UpdateProduto(ProdutoModel model);
        Task<bool> DeleteProdutoById(long id);
    }
}
