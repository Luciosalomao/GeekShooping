using GeekShooping.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IServiceProduto serviceProduto)
        {
            _serviceProduto = serviceProduto ?? throw new ArgumentNullException(nameof(serviceProduto));
        }

        public async Task<IActionResult> ProdutoIndex()
        {
            var produtos = _serviceProduto.FindAllProdutos();
            return View(produtos);
        }
    }
}
