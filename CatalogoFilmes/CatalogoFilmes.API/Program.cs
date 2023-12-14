using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using CatalogoFilmes.Infra.IOC;
using CustomConverter = CatalogoFilmes.Application.Converters;


namespace CatalogoFilmes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureService(builder.Configuration);

            builder.Services.AddCors();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
              //      options.JsonSerializerOptions.Converters.Add(new CustomConverter.DateTimeConverter());
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);

                c.IncludeXmlComments(xmlPath);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(opt =>
             opt.AllowAnyOrigin()
              .AllowAnyMethod());

            app.MapControllers();

            app.Run();
        }
    }
}