using DscApi.Interface;
using DscApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(option => {
    option.AddPolicy("dsccors", police => {
        police.WithOrigins("http://localhost:3000");
        police.AllowAnyHeader();
        police.AllowAnyMethod();
    });
});


builder.Services.AddScoped<IControl, ControlRepository>();
builder.Services.AddScoped<IControlTipo, ControlTipoRepository>();
builder.Services.AddScoped<IFormulario, FormularioRespository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("dsccors");

app.Run();
