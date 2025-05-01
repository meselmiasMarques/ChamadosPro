using ChamadosPro.Core.Requests;
using ChamadosPro.Web.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ChamadosPro.Web.Pages.Usuarios;

public partial class CadastrarUsuarioPage : ComponentBase
{

    #region Propriedades
        public UsuarioCreateRequest InputModel { get; set; } = new();

    #endregion
    
    #region Serviços

    [Inject]
    public UsuarioService usuarioService { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Métodos

    public async Task OnValidSubmitAsync()
    {
        try
        {
            var result = await usuarioService.CreateAsync(InputModel);
            if (result)
            {
                Snackbar.Add("Usuário Criado com Sucesso", Severity.Success);
                NavigationManager.NavigateTo("/usuarios");
            }
            else
                Snackbar.Add("Ocorreu um Erro ao cadastrar usuário", Severity.Error);
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
    }
    
    #endregion
    
}