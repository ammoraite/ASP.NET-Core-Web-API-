using FluentMigrator;

namespace First_API.Services.Migrations
{
    [Migration(2)]
    public class DotNetMetricsMigration : Migration
    {
        public static readonly string NameTableMetric = "DotNetMetric";

        public override void Up()
        {
            Create.Table(NameTableMetric)
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt64()
                .WithColumn("Time").AsInt32();
        }

        public override void Down()
        {
            Delete.Table(NameTableMetric);
        }

    }
}