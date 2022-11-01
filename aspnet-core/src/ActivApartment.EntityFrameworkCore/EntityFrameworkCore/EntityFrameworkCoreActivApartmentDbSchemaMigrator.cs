﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ActivApartment.Data;
using Volo.Abp.DependencyInjection;

namespace ActivApartment.EntityFrameworkCore;

public class EntityFrameworkCoreActivApartmentDbSchemaMigrator
    : IActivApartmentDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreActivApartmentDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ActivApartmentDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ActivApartmentDbContext>()
            .Database
            .MigrateAsync();
    }
}
