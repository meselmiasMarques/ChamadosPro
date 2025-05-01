namespace ChamadosPro.Core.Models;

public class Usuarios
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SenhaHash { get; set; } = null!;

    public string Perfil { get; set; } = null!;

    public virtual ICollection<Chamados> ChamadosCliente { get; set; } = new List<Chamados>();

    public virtual ICollection<Chamados> ChamadosTecnico { get; set; } = new List<Chamados>();
}
