namespace CadastroDeUsuario.Models.ResponseModels;

public class UserResponseModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataCriacao { get; set; }
}
