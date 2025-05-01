using System.ComponentModel.DataAnnotations;
using ChamadosPro.API.Request;
using ChamadosPro.API.Response;
using ChamadosPro.Core.Models;
using ChamadosPro.Core.Requests;
using ChamadosPro.Infraestructure.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace ChamadosPro.API.EndPoints;

public static class UsuariosExtensios
{
    public static void AddEndpointsUsuarios(this WebApplication app)
    {
        var endpointUser = app.MapGroup("v1/usuarios").WithTags("Usuarios");
            
            
        endpointUser.MapGet("", async (IUsuarioRepository usuarioRepository) =>
        {
            var usuarios = await usuarioRepository.GetAllAsync();

           var response =  usuarios.Select(c => new UsuarioResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Perfil = c.Perfil
            }).ToList();
            
            return Results.Ok(response);
        });
        
        endpointUser.MapGet("/{id}", async (IUsuarioRepository usuarioRepository, int id) =>
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return Results.NotFound();
            }

          
            var response = new UsuarioResponse()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
            return Results.Ok(response);
        });


        endpointUser.MapPost("", async (IUsuarioRepository usuarioRepository, UsuarioCreateRequest model) =>
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, context, validationResults, true))
            {
                var errors = validationResults.Select(v => v.ErrorMessage).ToList();
                return Results.BadRequest(new { Errors = errors });
            }

            var usuario = new Usuarios
            {
                Nome = model.Nome,
                Email = model.Email,
                SenhaHash = model.Senha,
                Perfil = model.Perfil
            };

            await usuarioRepository.AddAsync(usuario);
            return Results.Created();

        });
        
        endpointUser.MapPut("", async (IUsuarioRepository usuarioRepository, UsuarioRequest model,int id) =>
        {
            var user = await usuarioRepository.GetByIdAsync(id);
            if (user is null)
            {
                return Results.NotFound("Usuário não encontrado!");
            }
            
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, context, validationResults, true))
            {
                var errors = validationResults.Select(v => v.ErrorMessage).ToList();
                return Results.BadRequest(new { Errors = errors });
            }

            user.Nome = model.Nome;
            user.Email = model.Email;
            user.SenhaHash = model.Senha;
            user.Perfil = model.Perfil;
            
            try
            {
                await usuarioRepository.Update(user);
            }
            catch (DbUpdateException e)
            {
                return Results.BadRequest("Erro ao atualizar usuario");
            }
            
            return Results.Ok();

        });
        
        endpointUser.MapDelete("/{id}", async (IUsuarioRepository usuarioRepository, int id) =>
        {
            var usuario = await usuarioRepository.GetByIdAsync(id);

            if (usuario == null)
            {
                return Results.NotFound("Usuário não encontrado");
            }

            try
            {
                await usuarioRepository.Delete(usuario);
          
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest("Ocorreu um erro ao excluir usuario");
            }
            
          
        });
    }
}