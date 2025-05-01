using ChamadosPro.Web.Responses;
using ChamadosPro.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ChamadosPro.Web.Pages.Usuarios;

public partial class ListUsuariosPage : ComponentBase
{
    #region Propriedades

    public List<UsuarioResponse>? Usuarios { get; set; } = [];
    public string SearchTerm { get; set; } = string.Empty;

    
    #endregion


    #region Serviços

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public UsuarioService _usuarioService { get; set; } = null!;

    #endregion

    #region Overrides

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Usuarios = await _usuarioService.GetUsuariosAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao carregar usuários: " + ex.Message);
        }
    }

    #endregion

    #region Metodos


    public async void OnDeleteButtonClickedAsync(int id, string nome)
    {
        var result = await DialogService.ShowMessageBox(
            "Atenção", 
            $"Deseja mesmo excluir o usuário: {nome} ?",
            "EXCLUIR", "Cancelar");

        if (result is true)
        {
            await onDeleteAsync(id,nome);
        }
    }

    private async Task onDeleteAsync(int id, string nome)
    {
        try
        {
            await _usuarioService.DeleteAsync(id);
            Usuarios?.RemoveAll(u => u.Id == id);
            Snackbar.Add($"usuario {nome} excluído", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);

        }
    }
    
    public Func<UsuarioResponse, bool> Filter => usuario =>
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return true;
    
        if (usuario.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;
    
        if (usuario.Nome.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;
    
        if (usuario.Email is not null &&
            usuario.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            return true;
    
        return false;
    };

    #endregion

}