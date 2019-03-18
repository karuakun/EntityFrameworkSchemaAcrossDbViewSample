using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SchemaAcrossDbViewSamle.Data;

namespace SchemaAcrossDbViewSamle
{
    /// <summary>
    /// マイグレーション用データコンテキストの設定情報を構築します。
    /// </summary>
    public class DesignTimeConfigurationBuilder
    {
        public static IConfigurationRoot BuildConfiguration(string[] args) => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddCommandLine(args)
            .AddEnvironmentVariables()
            .Build();
    }

    /// <summary>
    /// <see cref="SampleDbContext"/>のマイグレーション用データコンテキストを作成します。
    /// </summary>
    public class DesignTimeSampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public static IConfigurationRoot DesignTimeConfiguration { get; private set; }

        public SampleDbContext CreateDbContext(string[] args)
        {
            DesignTimeConfiguration = DesignTimeConfigurationBuilder.BuildConfiguration(args);
            var builder = new DbContextOptionsBuilder<SampleDbContext>()
                .UseMySql(DesignTimeConfiguration.GetConnectionString(SampleDbContext.DefaultConnectionStringName)
                );
            return new SampleDbContext(builder.Options);
        }
    }
}
