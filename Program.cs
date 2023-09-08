using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Get Ip API",
        Description = "Projeto destinado a portfólio. Por favor, tenha consciência ao utilizá-lo.",
        Contact = new OpenApiContact
        {
            Name = "Romulo de Oliveira",
            Email = "devromulodeoliveira@gmail.com",
            Url = new Uri("https://github.com/romulodeoliveira"),
        },
        License = new OpenApiLicense
        {
            Name = "Licença",
            Url = new Uri("https://github.com/romulodeoliveira/IPAddressAPI/blob/main/LICENSE.md"),
        }
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
