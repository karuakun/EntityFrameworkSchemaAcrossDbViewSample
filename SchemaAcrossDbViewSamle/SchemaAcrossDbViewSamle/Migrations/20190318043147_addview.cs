using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using SchemaAcrossDbViewSamle.Configuration;

namespace SchemaAcrossDbViewSamle.Migrations
{
    public partial class addview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(this.GetSqlText(this.GetId(), "up.v_seconddb_test2.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(this.GetSqlText(this.GetId(), "down.v_seconddb_test2.sql"));
        }
    }

    public static class MigrationExtensions
    {
        public static string GetSqlText(this Migration source, string migrationId, string fileName)
        {
            var sqlPath = Path.Combine(Environment.CurrentDirectory, "Migrations", "manual", migrationId, fileName);
            if (!File.Exists(sqlPath))
                throw new FileNotFoundException(sqlPath);

            var sqlText = File.ReadAllText(sqlPath);
            if (string.IsNullOrEmpty(sqlText))
                throw new InvalidOperationException($"sqlfile is empty: {sqlText}");

            var settings = GetMigrationSettings();
            var schemaReplacedSqlText = sqlText.Replace("$SecondDb$", settings.SecondDb);
            return schemaReplacedSqlText;
        }

        private static MigrationSchemaMappings GetMigrationSettings()
        {
            var configuration = DesignTimeSampleDbContextFactory.DesignTimeConfiguration;
            var migrationType = configuration.GetValue<string>("MigrationSettings:MigrationType");
            return configuration.GetSection($"MigrationSettings:SchemaMappings:{migrationType}")
                .Get<MigrationSchemaMappings>();
        }
    }

}
