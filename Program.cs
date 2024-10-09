using EventRegestration.Services.Interface;
using EventRegestration1.Data;
using EventRegestration1.Services;
using EventRegestration1.Services.Interface;
using EventRegestration1.Services.Service;
using Microsoft.EntityFrameworkCore;

namespace EventRegestration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Email
            builder.Services.AddScoped<IEmailService>(provider =>
          new EmailService(builder.Configuration["Mailjet:ApiKey"], builder.Configuration["Mailjet:SecretKey"]));
            // 1
            builder.Services.AddControllersWithViews();
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            // Db 2
            builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(ConnectionString));

            //3
            builder.Services.AddScoped<IRegistrationService, RegistrationService>();
            builder.Services.AddScoped<IEventService, EventService>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
