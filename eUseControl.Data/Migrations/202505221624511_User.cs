namespace eUseControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ULoginDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Credential = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        LoginDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ULoginDatas");
        }
    }
}
