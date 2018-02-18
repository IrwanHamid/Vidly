namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Type) VALUES ( 1, 'Comedy')");
            Sql("INSERT INTO GENRES (Id, Type) VALUES ( 2, 'Action')");
            Sql("INSERT INTO GENRES (Id, Type) VALUES ( 3, 'Family')");
            Sql("INSERT INTO GENRES (Id, Type) VALUES ( 4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
