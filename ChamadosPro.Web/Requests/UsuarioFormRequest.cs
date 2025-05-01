using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Web.Requests;

public class UsuarioFormRequest
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    public string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmaSenha { get; set; } = string.Empty;

    [Required(ErrorMessage = "O perfil é obrigatório.")]
    [StringLength(50, ErrorMessage = "O perfil não pode ter mais de 50 caracteres.")]
    public string Perfil { get; set; } = string.Empty;
}