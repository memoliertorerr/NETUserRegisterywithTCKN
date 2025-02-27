using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserRegisteryNET.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Swagger servisini düzenleyelim
builder.Services.AddSwaggerGen(
    swaggerGenOptions =>
    {
        // Swagger UI'da gözükecek bilgileri ayarlayal?m -> API versiyonu falan
        swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "UserRegisteryNET", Version = "v1" });
    }
    );

var app = builder.Build();

// Always use Swagger settings
app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "UserRegisteryNET";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API for User Registery");
    swaggerUIOptions.RoutePrefix = string.Empty; // Root URL'de Swagger UI'y? göster
});

app.UseHttpsRedirection();

app.MapGet("/get-all-users", async () => await UsersRepository.GetUsersAsync()).WithTags("Users Endpoints");

app.MapGet("/get-user-by-id/{userId}", async (int userId) =>
{
    User userToReturn = await UsersRepository.GetUserByIdAsync(userId: userId);

    if (userToReturn != null)
    {
        return Results.Ok(userToReturn); //Entitiy Framework = OK FOUND
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("Users Endpoints");

app.MapGet("/get-user-by-tckn/{tckn}", async (string tckn) =>
{
    User userToReturn = await UsersRepository.GetUserByTCKNAsync(tckn);

    if (userToReturn != null)
    {
        return Results.Ok(userToReturn); //Entitiy Framework = OK FOUND
    }
    else
    {
        return Results.NotFound();
    }
}).WithTags("Users Endpoints");

app.MapPost("/create-user", async (User userToCreate) =>
{
    bool createSuccessful = await UsersRepository.CreateUserAsync(userToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Creation Successful"); //Entitiy Framework = OK CREATED
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Users Endpoints"); ;

app.MapPut("/update-user", async (User userToUpdate) =>
{
    bool updateSuccessful = await UsersRepository.UpdateUserAsync(userToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful"); //Entitiy Framework = OK UPDATED
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Users Endpoints");


app.MapDelete("/delete-user-by-id/{userId}", async (int userId) =>
{
    bool deleteSuccessful = await UsersRepository.DeleteUserAsync(userId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful"); //Entitiy Framework = OK DELETED
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Users Endpoints");

app.MapDelete("/delete-user-by-tckn/{tckn}", async (string tckn) =>
{
    bool deleteSuccessful = await UsersRepository.DeleteUserByTCKNAsync(tckn);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful"); //Entitiy Framework = OK DELETED
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Users Endpoints");

app.Run();
