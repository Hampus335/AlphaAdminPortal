using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;


[Route("admin")]
public class AdminController : Controller
{

    [Route("clients")]
    public IActionResult Clients()
    {
        return View();
    }
    [Route("projects")]
    public IActionResult Projects()
    {
        return View();
    }
}
