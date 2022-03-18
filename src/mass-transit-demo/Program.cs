using mass_transit_demo;
using MassTransit;

Microsoft.Extensions.Hosting.IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageConsumer>();

                x.UsingRabbitMq((context,cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService(true);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
