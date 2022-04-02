using FluentMigrator;

namespace First_API.Services.Migrations
{
    [Migration(1)]
    public class MetricsMigration : Migration
    {

        public override void Up()
        {
            Create.Table("CpuMetric")
           .WithColumn("Id").AsInt64().PrimaryKey().Identity()
           .WithColumn("Value").AsInt64()
           .WithColumn("Time").AsInt32();

            Create.Table("DotNetMetric")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt64()
                .WithColumn("Time").AsInt32();

            Create.Table("HddMetric")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt64()
                .WithColumn("Time").AsInt32();

            Create.Table("NetWorkMetric")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt64()
                .WithColumn("Time").AsInt32();

            Create.Table("RumMetric")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt64()
                .WithColumn("Time").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("CpuMetric");
            Delete.Table("DotNetMetric");
            Delete.Table("NetWorkMetric");
            Delete.Table("RumMetric");
            Delete.Table("HddMetric");
        }
    }
}
