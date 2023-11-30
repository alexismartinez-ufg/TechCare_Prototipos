using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Prototipos;
using Prototipos.BAL.Helpers;
using Prototipos.BAL.Interfaces;
using Prototipos.BAL.Repositorys;
using Prototipos.BAL.Services;
using Prototipos.DAL.Models;

namespace TechCare_Prototipos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = builder.Configuration.GetConnectionString("PropotitiosConnection");

            builder.Services.AddDbContext<PrototiposContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IMailNotificationService, MailNotificationService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(o =>
               {
                   o.LoginPath = "/Auth/Index";
                   o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                   o.AccessDeniedPath = "/Auth/Denied";
               });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Index}");

            app.Run();    
        }
    }

    public static class Seed
    {
        public static async Task SeedUsers(IUsuariosRepository usuariosRepository)
        {
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Alexis",
                Email = "ia.alexismartinez@ufg.edu.sv",
                Contraseña = EncryptHelper.EncryptPassword("Administrador123!"),
                Nombre = "Alexis Martínez",
                Role = RolesReferences.ResourceOwner
            });
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Cocinero01",
                Email = "cocinero01.techcare@yopmail.com",
                Contraseña = EncryptHelper.EncryptPassword("Cocinero123!"),
                Nombre = "Cocinero 01",
                Role = RolesReferences.Cocinero
            });
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Cajero01",
                Email = "cajero01.techcare@yopmail.com",
                Contraseña = EncryptHelper.EncryptPassword("Cajero123!"),
                Nombre = "Cajero 01",
                Role = RolesReferences.Cajero
            });
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Mesero01",
                Email = "mesero01.techcare@yopmail.com",
                Contraseña = EncryptHelper.EncryptPassword("Mesero123!"),
                Nombre = "Mesero 01",
                Role = RolesReferences.Mesero
            });
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Gerente01",
                Email = "gerente01.techcare@yopmail.com",
                Contraseña = EncryptHelper.EncryptPassword("Gerente123!"),
                Nombre = "Gerente 01",
                Role = RolesReferences.Gerente
            });
            await usuariosRepository.CreateUserIfNotExist(new Usuario
            {
                Username = "Administrador01",
                Email = "administrador01.techcare@yopmail.com",
                Contraseña = EncryptHelper.EncryptPassword("Administrador123!"),
                Nombre = "Administrador 01",
                Role = RolesReferences.Administrador
            });
        }
    }
}