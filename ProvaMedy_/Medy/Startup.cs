using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Medy.Dominio;
using Medy.Contexto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Medy.Util;

namespace Medy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbConexaoSqlServ"), b => b.MigrationsAssembly("Medy"))
            );

            var mappingconfig = new MapperConfiguration(
                           mc => mc.AddProfile(new MappinProfile())
                       );
            IMapper mapper = mappingconfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRetornaIdade, RetornaIdade>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
