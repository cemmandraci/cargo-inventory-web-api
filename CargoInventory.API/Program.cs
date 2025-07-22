using CargoInventory.Application.Commands;
using CargoInventory.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(RegisterCargoItemCommand));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/cargo", async ([FromBody] RegisterCargoItemCommand command, [FromServices] IMediator mediator) =>
{
    var id = await mediator.Send(command);
    return Results.Ok(id);
});

app.MapPost("/cargo/{hubCode}", async ([FromBody] GetCargoItemsAtHubQuery query, [FromServices] IMediator mediator) =>
{
    var result = await mediator.Send(query);
    return Results.Ok(result);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();