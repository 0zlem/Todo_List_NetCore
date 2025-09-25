
using Scalar.AspNetCore;
using Todo_list.Application;
using Todo_list.Infrastructure;
using Todo_list.WebAPI.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(opt =>
{
    opt.EnableForHttps = true;
});

//Services
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();



var app = builder.Build();

app.RegisterTodoHeadRoutes();
app.RegisterTodoItemRoutes();

app.MapGet("/", () => Results.Redirect("/scalar/v1"));
app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();


app.UseHttpsRedirection();

app.Run();

