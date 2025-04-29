using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Web.Requests;

public class UsuarioEditRequest
{
    
    
    [Required(ErrorMessage = "Campo Nome é requerido")]
    private string Nome { get; set; }

    [Required(ErrorMessage = "Campo Email é requerido")]
    string Email { get; set; }
    [Required(ErrorMessage = "Campo Perfil é requerido")] 
    string Perfil { get; set; }
};