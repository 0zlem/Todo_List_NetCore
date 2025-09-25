using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo_list.Application.Interfaces;
using Todo_list.Infrastructure.Context;
using Todo_list.Infrastructure.Repositories;

namespace Todo_list.Infrastructure;

public static class InfrastructureRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            string connection = configuration.GetConnectionString("PostgreSql")!;
            opt.UseNpgsql(connection);
        });

        services.AddScoped<ITodoHeadRepository, TodoHeadRepository>();
        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}
