namespace LanguageSnippets.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsStarredColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Snippet", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Snippet", "IsStarred");
        }
    }
}
