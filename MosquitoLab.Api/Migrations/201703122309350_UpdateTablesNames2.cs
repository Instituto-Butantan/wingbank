namespace MosquitoLab.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesNames2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "Id");
            RenameColumn(table: "dbo.Users", name: "Id", newName: "Id");
            RenameColumn(table: "dbo.UserClaims", name: "Id", newName: "Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.UserClaims", name: "Id", newName: "UserClaimId");
            RenameColumn(table: "dbo.Users", name: "Id", newName: "UserId");
            RenameColumn(table: "dbo.Roles", name: "Id", newName: "RoleId");
        }
    }
}
