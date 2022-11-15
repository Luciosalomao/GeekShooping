using GeekShooping.web.Models;
using GeekShooping.web.Services.IServices;
using GeekShooping.web.Utils;

namespace GeekShooping.web.Services
{
    public class ProdutoService : IServiceProduto
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/produto";

        public ProdutoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProdutoModel>> FindAllProdutos()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProdutoModel>>();
        }

        public async Task<ProdutoModel> FindProdutoById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProdutoModel>();
        }
        public async Task<ProdutoModel> CreateProduto(ProdutoModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<ProdutoModel> UpdateProduto(ProdutoModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProdutoModel>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

        public async Task<bool> DeleteProdutoById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Algo deu errado ao chamar a API");
        }

    }
}
