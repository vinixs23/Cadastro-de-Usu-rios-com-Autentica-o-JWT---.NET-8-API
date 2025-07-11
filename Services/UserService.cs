using CadastroDeUsuario.Models;
using CadastroDeUsuario.Models.FormModels;
using CadastroDeUsuario.Models.ResponseModels;
using CadastroDeUsuario.Repositorys;

namespace CadastroDeUsuario.Services;


public class UserService
{
    private readonly UserRepository _repo;

    public UserService(UserRepository repo)
    {
        _repo = repo;
    }

    public async Task<UserResponseModel> Register(UserFormModel form)
    {
        var existing = await _repo.GetByEmail(form.Email);
        if (existing != null)
            throw new Exception("Email já cadastrado.");

        var user = new User
        {
            Nome = form.Nome,
            Email = form.Email,
            DataCriacao = DateTime.UtcNow
        };

        user.Id = await _repo.Create(user);

        return new UserResponseModel
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            DataCriacao = user.DataCriacao
        };
    }

    public async Task<UserResponseModel> GetById(int id)
    {
        var user = await _repo.GetById(id);
        if (user == null) return null;

        return new UserResponseModel
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email,
            DataCriacao = user.DataCriacao
        };
    }

    public async Task<IEnumerable<UserResponseModel>> GetAll()
    {
        var users = await _repo.GetAll();
        return users.Select(u => new UserResponseModel
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            DataCriacao = u.DataCriacao
        });
    }

    public async Task Update(int id, UserFormModel form)
    {
        var user = await _repo.GetById(id);
        if (user == null)
            throw new Exception("Usuário não encontrado.");

        user.Nome = form.Nome;
        user.Email = form.Email;

        await _repo.Update(user);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    }
}
