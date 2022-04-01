using FluentMigrator;

namespace First_API.Services.Migrations
{
    [Migration(3)]
    public class HddMetricsMigration : Migration
    {
        public static readonly string NameTableMetric = "HddMetric";
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
