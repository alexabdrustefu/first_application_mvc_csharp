using System.Text.Json.Serialization;
using first_mvc_pattern_c_.Data;
using first_mvc_pattern_c_.Repository;
using first_mvc_pattern_c_.Services;
using Microsoft.EntityFrameworkCore;

namespace first_mvc_pattern_c_
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Ottenere la stringa di connessione da appsettings.json
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Configuro il DbContext per MySQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 22))));

            // Configuro MVC
            services.AddControllers();
            //aggiungo i due service
            services.AddScoped<CinemaService>();
            services.AddScoped<FilmService>();
            services.AddScoped<CinemaRepositoryImpl>();

            //creo builder da dto a model
            services.AddAutoMapper(typeof(Startup), typeof(CinemaProfile), typeof(FilmProfile));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // configuro il middleware per utilizzare i controller MVC
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
