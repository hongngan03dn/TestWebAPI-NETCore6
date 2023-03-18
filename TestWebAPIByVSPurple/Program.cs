using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestWebAPIByVSPurple.Entities;
using TestWebAPIByVSPurple.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy 
    => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()) );

builder.Services.AddDbContext<MyShopContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyShop")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

app.UseSwagger(); //moi chuyen
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
