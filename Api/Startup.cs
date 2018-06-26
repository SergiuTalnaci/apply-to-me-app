using Api.ConfigurationModels;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    private OwinConfiguration _owinConfiguration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      _owinConfiguration = new OwinConfiguration();
      Configuration.GetSection("OwinConfiguration").Bind(_owinConfiguration);

      var connectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<AppDb>(options => { options.UseSqlServer(connectionString); });

      services.AddTransient<QuestionAnswerRepository, QuestionAnswerRepository>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddCors(options =>
      {
        options.AddPolicy("default", policy =>
        {
          policy
              .WithOrigins(_owinConfiguration.WithOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseCors(policy =>
      {
        policy.WithOrigins(_owinConfiguration.WithOrigins);
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
      });

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
