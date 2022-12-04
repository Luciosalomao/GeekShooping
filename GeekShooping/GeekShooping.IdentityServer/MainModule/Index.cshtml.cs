using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foo.Pages.Home;

[AllowAnonymous]
public class Index : PageModel
{
    public string Version;
        
    public void OnGet()
    {
       
    }
}