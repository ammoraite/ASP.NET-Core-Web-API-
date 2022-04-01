using FluentMigrator;

namespace First_API.Services.Migrations
{
    [Migration(5)]
    public class RumMetricsMigration : Migration
    {
        public static readonly string NameTableMetric = "RumMetric";
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
