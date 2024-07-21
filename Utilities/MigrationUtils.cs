using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace BirrasBares.Utilities
{
    public static class MigrationUtils
    {
        private static string Bracketed(string? name)
        {
            return string.IsNullOrEmpty(name) ? string.Empty : $"[{name?.Replace("[", string.Empty).Replace("]", string.Empty).Trim()}]";
        }

        public static OperationBuilder<SqlOperation> DropTableIfExists(this MigrationBuilder migrationBuilder, string name, string? schema = default)
        {
            var prefix = string.IsNullOrEmpty(schema) ? string.Empty : $"{Bracketed(schema)}.";
            return migrationBuilder.Sql($"DROP TABLE IF EXISTS {prefix}{Bracketed(name)};");
        }
    }
}
