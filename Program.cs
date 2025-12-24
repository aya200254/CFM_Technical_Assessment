using CFM_Technical_Assessment.Data;
using Microsoft.EntityFrameworkCore;

namespace CFM_Technical_Assessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ------------------------
            // Configure DbContext
            // ------------------------
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ------------------------
            // Add Controllers & Swagger
            // ------------------------
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ------------------------
            // Add CORS Policy
            // ------------------------
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // ------------------------
            // Middleware
            // ------------------------
            app.UseCors("AllowAll"); // Apply CORS

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(); // <--- هنا
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
