using GeekShooping.web.Models;
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
            var produtos = await _serviceProduto.FindAllProdutos();
            return View(produtos);
        }

        public async Task<IActionResult> ProdutoCreate()
        {
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> ProdutoCreate(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _serviceProduto.CreateProduto(model);
                if (response != null) return RedirectToAction(nameof(ProdutoIndex));
            }
            
            return View(model);
        }

        public async Task<IActionResult> ProdutoUpdate(int id)
        {
            var model = await _serviceProduto.FindProdutoById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProdutoUpdate(ProdutoModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _serviceProduto.UpdateProduto(model);
                if (response != null) return RedirectToAction(nameof(ProdutoIndex));
            }

            return View(model);
        }
    }
}

