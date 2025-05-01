using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Core.Requests;

public record UsuarioUpdateRequest(
    
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email informado não é válido.")]
    string Email,

    [Required(ErrorMessage = "O perfil é obrigatório.")]
    [RegularExpression("^(Cliente|Tecnico|Administrador)$", ErrorMessage = "Perfil inválido.")]
    string Perfil
    
    );