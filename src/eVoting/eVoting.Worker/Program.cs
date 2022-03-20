using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using eVoting.Infra.PostgresDb;
using System;
using Microsoft.EntityFrameworkCore;
using eVoting.Domain;

namespace eVoting.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<VoteConsumer>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddOptions<MassTransitHostOptions>()
                        .Configure(options =>
                        {
                            options.WaitUntilStarted = true;
                        });
                    
                    services.AddDbContext<EVotingDbContext>(options =>
                        options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION")));

                    services.AddTransient<IVoteRepository, VoteRepository>();
                    
                });
    }
}
