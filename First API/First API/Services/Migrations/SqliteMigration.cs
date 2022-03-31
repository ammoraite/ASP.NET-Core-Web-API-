using FluentMigrator;

namespace First_API.Services.Migrations
{
    [Migration(1)]
    public class SqliteMigration: Migration
    {
        public override void Up()

        {        Create.Table("metrics")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsDateTime();
        }
        public override void Down()
        {
            Delete.Table("metrics");
        }

    }
}
