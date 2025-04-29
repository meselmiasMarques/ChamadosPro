using System.ComponentModel.DataAnnotations;

namespace ChamadosPro.Web.Responses
{
    public class UsuarioResponse
    {
        public UsuarioResponse(string nome, string email, string perfil)
        {
            Nome = nome;
            Email = email;
            Perfil = perfil;
        }
        

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Perfil é obrigatório")]
        public string Perfil { get; set; }
    }
}
