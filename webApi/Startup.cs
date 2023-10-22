using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace webApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();
    
            services.AddDbContext<Data.ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            // services.AddDbContext<SQLiteDbContext>(options =>
            // {
            //     options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection"));
            // });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TecAir API", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TecAir API REST");
        
            });
            

            // Configura la canalización de solicitud HTTP aquí
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //Ruta de los controladores
                endpoints.MapControllers();
            });
        }
    }
}