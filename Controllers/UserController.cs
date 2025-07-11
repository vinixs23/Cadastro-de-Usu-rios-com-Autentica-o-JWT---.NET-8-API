

using CadastroDeUsuario.Models.FormModels;
using CadastroDeUsuario.Repositorys;
using CadastroDeUsuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuario.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;
    private readonly UserRepository _repo;
    private readonly TokenService _tokenService;

    public UsersController(UserService service, UserRepository repo)
    {
        _service = service;
        _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserFormModel form)
    {
        try
        {
            var user = await _service.Register(form);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginFormModel form)
    {
        var user = await _repo.GetByEmail(form.Email);

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Update(int id, UserFormModel form)
    {
        try
        {
            await _service.Update(id, form);
            return Ok("Usuário atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok("Usuário excluído com sucesso.");
    }
}