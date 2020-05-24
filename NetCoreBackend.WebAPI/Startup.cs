using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NetCoreBackend.BLL.Abstract;
using NetCoreBackend.BLL.Concrete;
using NetCoreBackend.BLL.DependencyResolvers.Autofac;
using NetCoreBackend.Core.DependencyResolvers;
using NetCoreBackend.Core.Extensions;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.IoC;
using NetCoreBackend.Core.Utilities.Security.Encryption;
using NetCoreBackend.Core.Utilities.Security.Jwt;
using NetCoreBackend.DAL.Abstract;
using NetCoreBackend.DAL.Concrete.EntityFramework;

namespace NetCoreBackend.WebAPI
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

            //Ýsteklere izin verilir
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });

            //JWT configuration
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            //services.AddMemoryCache();
            //Bu sýnýf içerisinde eklenebilecek herhangi bir servisin(Örnek olarak bir üst satýrda AddMemoryCache), core seviyesinde tanýmlanabilmesi için yazýlan extension.
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });
        }

        //public void ConfigureContainer(ContainerBuilder containerBuilder)
        //{
        //    containerBuilder.RegisterModule(new AutofacBusinessModule());
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();//extension

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());//eklendi

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();//login(eklendi)

            app.UseAuthorization();//role

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
