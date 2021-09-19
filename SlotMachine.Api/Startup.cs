using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SlotMachine.Api.Interfaces;
using SlotMachine.Api.Services;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;
using SlotMachine.Domain.Services;

namespace SlotMachine.Api
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
            services.AddControllers();

            services.Configure<ReelOptions>(_configuration.GetSection(ReelOptions.SectionName));

            services.AddScoped<ISlotMachineService, SlotMachineService>();

            services.AddSingleton<IWinLineVisitor, HorizontalWinLineVisitor>();
            services.AddSingleton<IWinLineVisitor, DiagonalWinLineVisitor>();
            services.AddSingleton<ISlotMachine>(sp =>
            {
                var reelOptions = sp.GetRequiredService<IOptions<ReelOptions>>().Value;

                var reel1 = new Reel(reelOptions.Reel1.Select(r => (Symbol)r).ToList());
                var reel2 = new Reel(reelOptions.Reel2.Select(r => (Symbol)r).ToList());
                var reel3 = new Reel(reelOptions.Reel3.Select(r => (Symbol)r).ToList());

                return new SlotMachineImpl(new IReel[] { reel1, reel2, reel3 }, sp.GetServices<IWinLineVisitor>());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SlotMachine}/{action=GetWinLines}");
            });
        }
    }
}
