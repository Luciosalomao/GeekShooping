using GeekShooping.IdentityServer.Extensions;
using GeekShooping.IdentityServer.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.IdentityServer.MainModule
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsuarioController(UserManager<IdentityUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var usuarioDB = await _userManager.FindByNameAsync(id);

                if (usuarioDB == null)
                {
                    this.MostrarMensagem("Usuário não encontrado.", true);
                    return RedirectToAction("Index", "Home");
                }

                var usuarioVM = new CadastrarUsuarioViewModel
                {
                    Id = usuarioDB.Id,
                    NomeUsuario = usuarioDB.UserName,
                    Email = usuarioDB.Email,
                    Telefone = usuarioDB.PhoneNumber
                };
                
                return View(usuarioVM);
            }

            return View(new CadastrarUsuarioViewModel());
        }

        private bool EntidadeExiste(String id)
        {
            return (_userManager.Users.AsNoTracking().Any(u => u.Id == id));
        }

        private static void MapearCadastrarUsuarioViewModel(CadastrarUsuarioViewModel entidadeOrigem, IdentityUser entidadeDestino)
        {
            entidadeDestino.UserName = entidadeOrigem.NomeUsuario;
            entidadeDestino.NormalizedUserName = entidadeOrigem.NomeUsuario.ToUpper().Trim();
            entidadeDestino.Email = entidadeOrigem.Email;
            entidadeDestino.NormalizedEmail = entidadeOrigem.Email.ToUpper().Trim();
            entidadeDestino.PhoneNumber = entidadeOrigem.Telefone;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            [FromForm] CadastrarUsuarioViewModel usuarioVM)
        {

            if (!string.IsNullOrEmpty(usuarioVM.Id))
            {
                ModelState.Remove("Senha");
                ModelState.Remove("ConfSenha");
            }

            if (EntidadeExiste(usuarioVM.Id))
            {
                var usuarioDB = await _userManager.FindByIdAsync(usuarioVM.Id);
                if ((usuarioVM.Email != usuarioDB.Email) &&
                    (_userManager.Users.Any(u => u.NormalizedEmail == usuarioVM.Email.ToUpper().Trim())))
                {

                    ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");
                    return View(usuarioVM);
                }
                MapearCadastrarUsuarioViewModel(usuarioVM, usuarioDB);

                var resultado = await _userManager.UpdateAsync(usuarioDB);


                if (resultado.Succeeded)
                {
                    this.MostrarMensagem("Usuário alterado com sucesso.");
                    return RedirectToAction("Index");

                }
                else
                {
                    this.MostrarMensagem("Não foi possível alterar o usuário.", true);
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(usuarioVM);
                }

            }
            else
            {
                var usuarioDB = await _userManager.FindByIdAsync(usuarioVM.Email);
                if (usuarioDB != null)
                {

                    ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");
                    return View(usuarioDB);
                }

                usuarioDB = new IdentityUser();

                MapearCadastrarUsuarioViewModel(usuarioVM, usuarioDB);

                var resultado = await _userManager.CreateAsync(usuarioDB, usuarioVM.Senha);




                if (resultado.Succeeded)
                {
                    this.MostrarMensagem("Usuário cadastrado com sucesso. Use suas credenciais para entrar no sistema");
                    return RedirectToAction("Login");
                }
                else
                {
                    this.MostrarMensagem("Erro ao cadastrar usuário.", true);
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(usuarioVM);
                }
            }

        }
    }
}
