using LenhASP.Domain.SeedWork;
using LenhASP.Domain.Services;
using LenhASP.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
    //x => x.UseNetTopologySuite());
});

builder.Services
.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>)) // config DI for generic object
.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>))
.AddScoped(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>));

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
