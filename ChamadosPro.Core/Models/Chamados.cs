namespace ChamadosPro.Core.Models;

public partial class Chamados
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int Status { get; set; }

    public DateTime DataAbertura { get; set; }

    public DateTime? DataConclusao { get; set; }

    public int ClienteId { get; set; }

    public int? TecnicoId { get; set; }

    public virtual Usuarios Cliente { get; set; } = null!;

    public virtual ICollection<HistoricoChamado> HistoricoChamado { get; set; } = new List<HistoricoChamado>();

    public virtual Usuarios? Tecnico { get; set; }
}
