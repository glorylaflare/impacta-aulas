using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace TesteComApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}


public static class UserEndpoints
{
	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User").WithTags(nameof(User));

        group.MapGet("/", () =>
        {
            return new [] { new User() };
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new User { ID = id };
        })
        .WithName("GetUserById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, User input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", (User model) =>
        {
            //return TypedResults.Created($"/api/Users/{model.ID}", model);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new User { ID = id });
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}