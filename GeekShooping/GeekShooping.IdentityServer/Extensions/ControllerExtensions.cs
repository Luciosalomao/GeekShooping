using GeekShooping.IdentityServer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.IdentityServer.Extensions
{
    public static class ControllerExtensions
    {
        public static void MostrarMensagem(this Controller @this, string texto, bool erro = false)
        {
            @this.TempData["mensagem"] = MensagemViewModel.Serializar(
                texto, erro ? TipoMensagem.Erro : TipoMensagem.Informacao);
        }
    }
}
