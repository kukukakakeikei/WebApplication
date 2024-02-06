using System.Reflection;
using WebApplication1.Extension;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureCors(); //×¢²á¿çÓò·þÎñ
builder.Services.ConfigureMySqlContext(builder.Configuration); //ÅäÖÃÁ¬½Ó×Ö·û´®
builder.Services.ConfigureRepositoryWrapper(); //²Ö´¢²Ù×÷

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //DtoÓ³Éä

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AnyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
