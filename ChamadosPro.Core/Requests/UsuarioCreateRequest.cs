using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Core.Requests;

public class UsuarioCreateRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O perfil é obrigatório.")]
    [RegularExpression("^(Cliente|Tecnico|Administrador)$", ErrorMessage = "Perfil inválido.")]
    public string Perfil { get; set; }
};