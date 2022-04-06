using FluentMigrator;

namespace MetricsMeneger.Services
{
    public class MenegerMigrations
    {

        [Migration(0)]
        public class MenagerMetricsMigration : Migration
        {
            public override void Up()
            {
                #region MetricsTable
                Create.Table("CpuMetric").WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Value").AsInt64()
                    .WithColumn("Time").AsInt32();
                Create.Table("DotNetMetric").WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Value").AsInt64()
                    .WithColumn("Time").AsInt32();
                Create.Table("HddMetric").WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Value").AsInt64()
                    .WithColumn("Time").AsInt32();
                Create.Table("NetWorkMetric").WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Value").AsInt64()
                    .WithColumn("Time").AsInt32();
                Create.Table("RumMetric").WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Value").AsInt64()
                    .WithColumn("Time").AsInt32();
                #endregion
            }

            public override void Down()
            {
                #region MetricsTable

                Delete.Table("CpuMetric");
                Delete.Table("DotNetMetric");
                Delete.Table("HddMetric");
                Delete.Table("NetWorkMetric");
                Delete.Table("RumMetric");

                #endregion
            }
        }
    }
}