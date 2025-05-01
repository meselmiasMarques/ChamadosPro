using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Core.Requests;

public record UsuarioChangePasswordRequest(
    [Required(ErrorMessage = "A senha atual é obrigatória.")]
    string SenhaAtual,

    [Required(ErrorMessage = "A nova senha é obrigatória.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A nova senha deve ter entre 6 e 100 caracteres.")]
    string NovaSenha
    
    );