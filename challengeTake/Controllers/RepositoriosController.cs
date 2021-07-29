using challengeTake.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace challengeTake.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepositoriosController : ControllerBase
    {
        private readonly IRepositorioService _repositorioService;

        public RepositoriosController(IRepositorioService repositorioService)
        {
            _repositorioService = repositorioService;
        }

        [HttpGet]
        public async Task<ActionResult> ObterRepositorios()
        {
            var repositorios = await _repositorioService.GetRepositorios();

            if (repositorios == null) return NotFound();

            return Ok(repositorios);
        }
    }
}
