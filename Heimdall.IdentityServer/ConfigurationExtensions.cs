﻿using System;
using System.Linq;
using IdentityServerAspNetIdentity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Heimdall.IdentityServer
{
    public static class ConfigurationExtensions
    {
        public static void MigrateDatabase(this IApplicationBuilder app, ILogger logger)
        {
            try
            {
                logger.LogInformation("Checking database migrations...");
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    using (var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        if (db.Database.GetPendingMigrations().Any())
                        {
                            logger.LogInformation("Database migration started...");
                            db.Database.Migrate();
                            logger.LogInformation("Database migration finished...");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Migrating database failed...");
                throw ex;
            }
        }
    }
}
