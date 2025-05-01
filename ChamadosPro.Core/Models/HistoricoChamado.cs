namespace ChamadosPro.Core.Models;

public partial class HistoricoChamado
{
    public int Id { get; set; }

    public int ChamadoId { get; set; }

    public int StatusAnterior { get; set; }

    public int StatusAtual { get; set; }

    public DateTime DataAlteracao { get; set; }

    public string Observacao { get; set; } = null!;

    public virtual Chamados Chamado { get; set; } = null!;
}
