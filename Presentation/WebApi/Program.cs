
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HayvanContext>(options =>
           options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection")
           ));

            // Add services to the container.

            builder.Services.AddScoped<HayvanContext>();
            builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
