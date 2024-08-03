using CloudinaryForo.Database;
using CloudinaryForo.Services;
using CloudinaryForo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CloudinaryForo
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Context

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Custom Services

            services.AddTransient<IImageService, ImageService>();

            //Automapper

            services.AddAutoMapper(typeof(Startup));

            //services.AddCors(options =>
            //{

            //    options.AddDefaultPolicy(builder =>
            //    {

            //        builder.WithOrigins(Configuration["FrontendURL"])
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();

            //    });

            //});

            services.AddHttpContextAccessor();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoits =>
            {

                endpoits.MapControllers();

            });

        }

    }
}
