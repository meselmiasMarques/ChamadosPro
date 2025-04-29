using System.Collections;
using ChamadosPro.Web.Responses;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace ChamadosPro.Web.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }


        public async Task<ICollection<UsuarioResponse>>? GetUsuariosAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<ICollection<UsuarioResponse>>("v1/usuarios");

                return result;
            }
          
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Erro HTTP: {httpEx.StatusCode} - {httpEx.Message}");
                throw;
            }

        }


        public async Task<UsuarioResponse?> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<UsuarioResponse>($"v1/usuarios/{id}");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> CreateAsync(UsuarioResponse model)
        {
            try
            {
                var usuario = await _httpClient.PostAsJsonAsync<UsuarioResponse>("v1/usuarios/{id}", model);

                if (!usuario.IsSuccessStatusCode)
                {
                    return false;

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateAsync(UsuarioResponse model)
        {
            try
            {
                var usuario = await GetUsuarioByIdAsync(model.Id);
                
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Perfil = model.Perfil;
                
                
                var user = await _httpClient
                    .PutAsJsonAsync<UsuarioResponse>($"v1/usuarios/{model.Id}", usuario);

                if (!user.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"v1/usuarios/{id}");
        }

    }
}
