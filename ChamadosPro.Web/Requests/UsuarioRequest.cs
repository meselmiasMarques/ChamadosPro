using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Web.Requests
{
    
    public record UsuarioRequest([Required(ErrorMessage = "Campo Nome é requerido")]string Nome,string Email,  [Required(ErrorMessage = "Campo Senha é requerido")]string Senha, [Required(ErrorMessage = "Campo Perfil é requerido")]string Perfil);

}
