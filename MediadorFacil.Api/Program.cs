using MediadorFacil.Application;
using Microsoft.EntityFrameworkCore;
using MediadorFacil.Infrastructure;
using Microsoft.Extensions.Options;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        builder.Services.RegisterApplication(builder.Configuration)
                        .RegisterRepository(builder.Configuration.GetConnectionString("MediadorFacilApi"));

            
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

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
        app.MapRazorPages();

        app.Run();
    }
}